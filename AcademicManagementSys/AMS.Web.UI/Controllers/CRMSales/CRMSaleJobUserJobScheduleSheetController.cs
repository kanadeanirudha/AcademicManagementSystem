using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;

namespace AMS.Web.UI.Controllers
{
    public class CRMSaleJobUserJobScheduleSheetController : BaseController
    {
        ICRMSaleJobUserJobScheduleSheetServiceAccess cRMSaleJobUserJobScheduleSheetServiceAccess = null;
        ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleJobUserJobScheduleSheetController()
        {
            cRMSaleJobUserJobScheduleSheetServiceAccess = new CRMSaleJobUserJobScheduleSheetServiceAccess();
            _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = new CRMSaleEnquiryMasterAndAccountDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods

        public ActionResult Index()
        {
            return View("/Views/CRMSales/CRMSaleJobUserJobScheduleSheet/Index.cshtml");
        }

        public ActionResult List(string selectedDate, string actionMode, Int16 callerJobStatus = 0)
        {
            try
            {
                CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();

                ////~~~~~~~~~~~Caller Job status ~~~~~~~~~~~~~~~~~~~~~~~~         
                List<SelectListItem> UserCallerJobStatus = new List<SelectListItem>();
                ViewBag.UserCallerJobStatus = new SelectList(UserCallerJobStatus, "Value", "Text");
                List<SelectListItem> UserCallerJobStatus_li = new List<SelectListItem>();
                UserCallerJobStatus_li.Add(new SelectListItem { Text = "All", Value = "0" });
                UserCallerJobStatus_li.Add(new SelectListItem { Text = "Completed", Value = "1" });
                UserCallerJobStatus_li.Add(new SelectListItem { Text = "In Progress", Value = "2" });
                UserCallerJobStatus_li.Add(new SelectListItem { Text = "Pending", Value = "3" });
                UserCallerJobStatus_li.Add(new SelectListItem { Text = "Forword", Value = "4" });
                model.CallerJobStatus = callerJobStatus;
                model.SelectedDate = selectedDate;

                ViewData["CallerJobStatus"] = new SelectList(UserCallerJobStatus_li, "Value", "Text", model.CallerJobStatus);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleSheet/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
            
            //~~~~~~~~~Job Type~~~~~~~~~~~~~~~~~         
            List<SelectListItem> UserJobType = new List<SelectListItem>();
            ViewBag.UserJobType = new SelectList(UserJobType, "Value", "Text");
            List<SelectListItem> UserJobType_li = new List<SelectListItem>();
            UserJobType_li.Add(new SelectListItem { Text = "----Select Job Type----", Value = "" });
            UserJobType_li.Add(new SelectListItem { Text = "Newly Allocated", Value = "NEW" });
            UserJobType_li.Add(new SelectListItem { Text = "Existing", Value = "EXIST" });
            UserJobType_li.Add(new SelectListItem { Text = "Other", Value = "OTHER" });
            UserJobType_li.Add(new SelectListItem { Text = "Call", Value = "CALL" });
            ViewData["JobType"] = new SelectList(UserJobType_li, "Value", "Text");

            //~~~~~~~~~~~~Schedule Type ~~~~~~~~~~           
            List<SelectListItem> UserScheduleType = new List<SelectListItem>();
            ViewBag.UserScheduleType = new SelectList(UserScheduleType, "Value", "Text");
            List<SelectListItem> UserScheduleType_li = new List<SelectListItem>();
            UserScheduleType_li.Add(new SelectListItem { Text = "----Select Schedule Type----", Value = "" });
            UserScheduleType_li.Add(new SelectListItem { Text = "Meeting", Value = "1" });
            UserScheduleType_li.Add(new SelectListItem { Text = "Survey", Value = "2" });
            //UserScheduleType_li.Add(new SelectListItem { Text = "Other", Value = "3" });
            ViewData["ScheduleType"] = new SelectList(UserScheduleType_li, "Value", "Text");

            //~~~~~~~~~~~~Sub Schedule Type ~~~~~~~~~~            
            List<SelectListItem> UserMeetingType = new List<SelectListItem>();
            ViewBag.UserMeetingType = new SelectList(UserMeetingType, "Value", "Text");
            List<SelectListItem> UserMeetingType_li = new List<SelectListItem>();
            UserMeetingType_li.Add(new SelectListItem { Text = "----Select Meeting Type----", Value = "" });
            UserMeetingType_li.Add(new SelectListItem { Text = "Pitch Meeting", Value = "1" });
            UserMeetingType_li.Add(new SelectListItem { Text = "Introductory Meeting", Value = "2" });
            UserMeetingType_li.Add(new SelectListItem { Text = "Presentation", Value = "3" });
            UserMeetingType_li.Add(new SelectListItem { Text = "Follow-up", Value = "4" });
            ViewData["SubScheduleType"] = new SelectList(UserMeetingType_li, "Value", "Text");

            ////~~~~~~~~~~~Caller Job status ~~~~~~~~~~~~~~~~~~~~~~~~         
            List<SelectListItem> UserCallerJobStatus = new List<SelectListItem>();
            ViewBag.UserCallerJobStatus = new SelectList(UserCallerJobStatus, "Value", "Text");
            List<SelectListItem> UserCallerJobStatus_li = new List<SelectListItem>();
            UserCallerJobStatus_li.Add(new SelectListItem { Text = "----Select Caller Job Status----", Value = "" });
            UserCallerJobStatus_li.Add(new SelectListItem { Text = "Completed", Value = "1" });
            UserCallerJobStatus_li.Add(new SelectListItem { Text = "In Progress", Value = "2" });
            UserCallerJobStatus_li.Add(new SelectListItem { Text = "Pending", Value = "3" });
            UserCallerJobStatus_li.Add(new SelectListItem { Text = "Forword", Value = "4" });
            ViewData["CallerJobStatus"] = new SelectList(UserCallerJobStatus_li, "Value", "Text");

            //Get Employee
            model.ListEmpEmployeeMaster = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotInTargetException");          

            return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleSheet/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleJobUserJobScheduleSheetViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleJobUserJobScheduleSheetDTO != null)
                {
                    model.CRMSaleJobUserJobScheduleSheetDTO.ConnectionString = _connectioString;
                    model.CRMSaleJobUserJobScheduleSheetDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.CRMSaleJobUserJobScheduleSheetDTO.JobCreationAllocationID = model.JobCreationAllocationID;
                    model.CRMSaleJobUserJobScheduleSheetDTO.GeneralOtherJobTypeID = model.GeneralOtherJobTypeID;
                    model.CRMSaleJobUserJobScheduleSheetDTO.Relatedwith = model.Relatedwith;
                    model.CRMSaleJobUserJobScheduleSheetDTO.JobType = model.JobType;
                    model.CRMSaleJobUserJobScheduleSheetDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                    model.CRMSaleJobUserJobScheduleSheetDTO.TransactionDate = model.TransactionDate;
                    model.CRMSaleJobUserJobScheduleSheetDTO.FromTime = model.FromTime;
                    model.CRMSaleJobUserJobScheduleSheetDTO.UpToTime = model.UpToTime;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleType = model.ScheduleType;
                    if (model.ScheduleType == 1)
                    {
                        model.CRMSaleJobUserJobScheduleSheetDTO.SubScheduleType = model.SubScheduleType;
                    }
                    model.CRMSaleJobUserJobScheduleSheetDTO.IsAttendOther = model.IsAttendOther;
                    if (model.IsAttendOther == true)
                    {
                        model.CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeId = model.OtherListEmployeId;
                        model.CRMSaleJobUserJobScheduleSheetDTO.OtherListEmployeIDXml = model.OtherListEmployeIDXml;
                    }
                    model.CRMSaleJobUserJobScheduleSheetDTO.CallerJobStatus = model.CallerJobStatus;
                    model.CRMSaleJobUserJobScheduleSheetDTO.ScheduleDescription = model.ScheduleDescription;

                   IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = cRMSaleJobUserJobScheduleSheetServiceAccess.InsertCRMSaleJobUserJobScheduleSheet(model.CRMSaleJobUserJobScheduleSheetDTO);
                   model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                   return Json(model.CRMSaleJobUserJobScheduleSheetDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewJobSchedule(int ID)
        {
            try
            {
                CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
                model.ListCRMSaleJobUserJobScheduleSheet = GetCRMSaleJobUserJobScheduleSheetList(ID);
                if (model.ListCRMSaleJobUserJobScheduleSheet.Count > 0 && model.ListCRMSaleJobUserJobScheduleSheet != null)
                {
                    model.ScheduleDescription = model.ListCRMSaleJobUserJobScheduleSheet[0].ScheduleDescription;
                    //model.ScheduleType = model.ListCRMSaleJobUserJobScheduleSheet[0].ScheduleType;

                    List<SelectListItem> UserScheduleType = new List<SelectListItem>();
                    ViewBag.UserScheduleType = new SelectList(UserScheduleType, "Value", "Text");
                    List<SelectListItem> UserScheduleType_li = new List<SelectListItem>();
                    UserScheduleType_li.Add(new SelectListItem { Text = "----Select Schedule Type----", Value = "" });
                    UserScheduleType_li.Add(new SelectListItem { Text = "Meeting", Value = "1" });
                    UserScheduleType_li.Add(new SelectListItem { Text = "Survey", Value = "2" });
                    UserScheduleType_li.Add(new SelectListItem { Text = "Other", Value = "3" });
                    UserScheduleType_li.Add(new SelectListItem { Text = "Call", Value = "4" });
                    ViewData["ScheduleType"] = new SelectList(UserScheduleType_li, "Value", "Text", model.ListCRMSaleJobUserJobScheduleSheet[0].ScheduleType);

                   // model.SubScheduleType = model.ListCRMSaleJobUserJobScheduleSheet[0].SubScheduleType;

                    List<SelectListItem> UserMeetingType = new List<SelectListItem>();
                    ViewBag.UserMeetingType = new SelectList(UserMeetingType, "Value", "Text");
                    List<SelectListItem> UserMeetingType_li = new List<SelectListItem>();
                    UserMeetingType_li.Add(new SelectListItem { Text = "----Select Meeting Type----", Value = "0" });
                    UserMeetingType_li.Add(new SelectListItem { Text = "Pitch Meeting", Value = "1" });
                    UserMeetingType_li.Add(new SelectListItem { Text = "Introductory Meeting", Value = "2" });
                    UserMeetingType_li.Add(new SelectListItem { Text = "Presentation", Value = "3" });
                    UserMeetingType_li.Add(new SelectListItem { Text = "Follow-up", Value = "4" });
                    ViewData["SubScheduleType"] = new SelectList(UserMeetingType_li, "Value", "Text", model.ListCRMSaleJobUserJobScheduleSheet[0].SubScheduleType);

                    model.FromTime = model.ListCRMSaleJobUserJobScheduleSheet[0].FromTime;
                    model.UpToTime = model.ListCRMSaleJobUserJobScheduleSheet[0].UpToTime;
                    model.TransactionDate = model.ListCRMSaleJobUserJobScheduleSheet[0].TransactionDate;
                    model.AccountName = model.ListCRMSaleJobUserJobScheduleSheet[0].AccountName;
                    model.ContactPerson = model.ListCRMSaleJobUserJobScheduleSheet[0].ContactPerson;
                }


                return PartialView("/Views/CRMSales/CRMSaleJobUserJobScheduleSheet/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #endregion

        //Non-Action Methods
        #region
        //=====================AccountName============
        [HttpPost]
        public JsonResult GetAccountDetails(string term)
        {
            Int16 AccountProgressTypeID = 0;
            Int32 CRMSaleEnquiryAccountMasterID = 0;
            Int16 AccountType = 2;
            var data = GetAccountDetails(term, AccountProgressTypeID, AccountType, CRMSaleEnquiryAccountMasterID, Convert.ToInt32(Session["PersonID"]));
            var result = (from r in data
                          select new
                          {
                              id = r.CRMSaleEnquiryAccountMasterID,
                              name = r.AccountName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //=====================ContactPerson=============
        [HttpPost]
        public JsonResult GetEnquiryContactPersonDetails(string term, string AccountMasterID)
        {
            var data = GetEnquiryContactPersonDetails(term, Convert.ToInt32(AccountMasterID), 0);
            var result = (from r in data
                          select new
                          {
                              id = r.CRMSaleEnquiryAccountContactPersonID,
                              name = String.Concat(r.FirstName, ' ', r.LastName),
                              enquiryId = r.CRMSaleEnquiryAccountMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<CRMSaleEnquiryMasterAndAccountDetails> GetEnquiryContactPersonDetails(string SearchKeyWord, Int32 AccountMasterID, Int32 EnquiryContactPersonID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest = new CRMSaleEnquiryMasterAndAccountDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ContactPersonName = SearchKeyWord;
            searchRequest.CRMSaleEnquiryAccountMasterID = AccountMasterID;
            searchRequest.CRMSaleEnquiryAccountContactPersonNameID = EnquiryContactPersonID;
            searchRequest.EnquiryAccountType = 2;

            List<CRMSaleEnquiryMasterAndAccountDetails> listAccount = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.GetCRMSaleEnquiryAccountContactPersonSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }
        
       //===============End of Contact Person===============
        public IEnumerable<CRMSaleJobUserJobScheduleSheetViewModel> GetCRMSaleJobUserJobScheduleSheet(Int16 callerJobStatus, string selectedDate, out int TotalRecords)
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.SelectedDate = selectedDate;
                    searchRequest.CallerJobStatus = callerJobStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.SelectedDate = selectedDate;
                    searchRequest.CallerJobStatus = callerJobStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.SelectedDate = selectedDate;
                searchRequest.CallerJobStatus = callerJobStatus;
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            }
            List<CRMSaleJobUserJobScheduleSheetViewModel> listCRMSaleJobUserJobScheduleSheetVM = new List<CRMSaleJobUserJobScheduleSheetViewModel>();
            List<CRMSaleJobUserJobScheduleSheet> listCRMJobScheduleSheet = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.GetBySearchCRMSaleJobUserJobScheduleSheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMJobScheduleSheet = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleJobUserJobScheduleSheet item in listCRMJobScheduleSheet)
                    {
                        CRMSaleJobUserJobScheduleSheetViewModel CRMSaleGroupMasterViewModel = new CRMSaleJobUserJobScheduleSheetViewModel();
                        CRMSaleGroupMasterViewModel.CRMSaleJobUserJobScheduleSheetDTO = item;
                        listCRMSaleJobUserJobScheduleSheetVM.Add(CRMSaleGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMSaleJobUserJobScheduleSheetVM;
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEmployeeJobs(string jobType)
        {
            int employeeID = Convert.ToInt32(Session["PersonID"]);
            var job = GetEmployeeJobsList(jobType, employeeID);
            var result = (from s in job
                          select new
                          {
                              id = s.JobCreationAllocationID,
                              name = s.JobName,   //+ "~" + s.AccountName + "~" + s.ContactPerson
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        protected List<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsList(string jobType, int employeeID)
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.JobType = jobType;
            searchRequest.EmployeeID = employeeID;

            List<CRMSaleJobUserJobScheduleSheet> listJobType = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.GetEmployeeJobsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobType;
        }

        //List GetByAccountName

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEmployeeJobsByAccount(string jobType, int EnquiryAccountMasterId, int EnquiryAccountContactPersonId)
       
        {
            int employeeID = Convert.ToInt32(Session["PersonID"]);
            var job = GetEmployeeJobsByAccountList(jobType, employeeID, EnquiryAccountMasterId, EnquiryAccountContactPersonId);
            var result = (from s in job
                          select new
                          {
                              id = s.JobCreationAllocationID,
                              name = s.JobName,   //+ "~" + s.AccountName + "~" + s.ContactPerson
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsByAccountList(string jobType, int employeeID, int EnquiryAccountMasterId, int EnquiryAccountContactPersonId)
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.JobType = jobType;
            searchRequest.EmployeeID = employeeID;
            searchRequest.EnquiryAccountMasterId = EnquiryAccountMasterId;
            searchRequest.EnquiryAccountContactPersonId = EnquiryAccountContactPersonId;

            List<CRMSaleJobUserJobScheduleSheet> listJobType = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.GetEmployeeJobsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobType;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAllocatedJobEmployee(int jobCreationMasterID)
        {
            int employeeID = Convert.ToInt32(Session["PersonID"]);
            var job = GetAllocatedJobEmployeeList(jobCreationMasterID, employeeID);
            var result = (from s in job
                          select new
                          {
                              accountName = s.AccountName,
                              cantactPerson = s.ContactPerson,   //+ "~" + s.AccountName + "~" + s.ContactPerson
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<CRMSaleJobUserJobScheduleSheet> GetAllocatedJobEmployeeList(int jobCreationMasterID, int employeeID)
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.JobCreationMasterID = jobCreationMasterID;
            searchRequest.EmployeeID = employeeID;

            List<CRMSaleJobUserJobScheduleSheet> listJobType = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.GetAllocatedJobEmployeeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobType;
        }


        protected List<CRMSaleJobUserJobScheduleSheet> GetCRMSaleJobUserJobScheduleSheetList(int iD)
        {

            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleJobUserJobScheduleSheet> listJobUserJobScheduleSheet = new List<CRMSaleJobUserJobScheduleSheet>();
            searchRequest.ID = iD;
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.SelectByCRMSaleJobUserJobScheduleSheetID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobUserJobScheduleSheet = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listJobUserJobScheduleSheet;
        }
                
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetGeneralOtherJobType()
        {

            var job = GetGeneralOtherJobTypeList();
            var result = (from s in job
                          select new
                          {
                              id = s.GeneralOtherJobTypeID,
                              name = s.Relatedwith,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<CRMSaleJobUserJobScheduleSheet> GetGeneralOtherJobTypeList()
        {
            CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest = new CRMSaleJobUserJobScheduleSheetSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);           

            List<CRMSaleJobUserJobScheduleSheet> listJobType = new List<CRMSaleJobUserJobScheduleSheet>();
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollectionResponse = cRMSaleJobUserJobScheduleSheetServiceAccess.GetGeneralOtherJobTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobType;
        }




        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string selectedDate, Int16 callerJobStatus, JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleJobUserJobScheduleSheetViewModel> filteredCRMSaleJobUserJobScheduleSheet;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "YEAR(A.TransactionDate) " + sortDirection + ",MONTH(A.TransactionDate) " + sortDirection + ",DAY(A.TransactionDate) " + sortDirection + ", A.ScheduleDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.ScheduleType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "A.SubScheduleType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "A.FromTime";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "A.CallerJobStatus";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //_searchBy = "A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%' or A.TransactionDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = " A.TransactionDate Like '%" + param.sSearch + "%' or A.ScheduleDescription Like '%" + param.sSearch + "%' or A.ScheduleType Like '%" + param.sSearch + "%' or A.SubScheduleType Like '%" + param.sSearch + "%'  or A.CallerJobStatus Like '%" + param.sSearch + "%' or A.FromTime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                //if (!string.IsNullOrEmpty(transactionDate) && Convert.ToInt16(callerJobStatus) > 0)
                //{
                filteredCRMSaleJobUserJobScheduleSheet = GetCRMSaleJobUserJobScheduleSheet(Convert.ToInt16(callerJobStatus), selectedDate, out TotalRecords);
                //}
                //else
                //{
                //    filteredCRMSaleJobUserJobScheduleSheet = new List<CRMSaleJobUserJobScheduleSheetViewModel>();
                //    TotalRecords = 0;
                //}
                var records = filteredCRMSaleJobUserJobScheduleSheet.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.TransactionDate), Convert.ToString(c.ScheduleDescription), Convert.ToString(c.ScheduleType), Convert.ToString(c.SubScheduleType), Convert.ToString(c.FromTime + " - " + c.UpToTime), Convert.ToString(c.CallerJobStatus), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion



    }
}

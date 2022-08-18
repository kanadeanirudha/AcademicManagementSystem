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
    public class FeeStructureApplicableController : BaseController
    {
        IFeeStructureApplicableServiceAccess _feeStructureApplicableServiceAcess = null;
        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
        IFeeStructureMasterAndDetailsServiceAccess _feeStructureMasterAndDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        const int _recordsPerPage = 5;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeStructureApplicableController()
        {
            _feeStructureApplicableServiceAcess = new FeeStructureApplicableServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
            _feeStructureMasterAndDetailsServiceAccess = new FeeStructureMasterAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Fees/FeeStructureApplicable/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string feeCriteriaMasterID)
        {
            try
            {
                FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;

                }
                model.SelectedFeeCriteriaMasterID = feeCriteriaMasterID;
                model.ListGetFeeCriteria = GetFeeCriteriaMasterAndDetails(Convert.ToInt16(Session["BalancesheetID"]));
                return PartialView("/Views/Fees/FeeStructureApplicable/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string ID)
        {
            string abc = Resources.ResourceManager.GetString("Message_RecordAlreadyExists");
            FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
            model.FeeStructureMasterList = GetFeeStructureDetails(Convert.ToInt32(ID));
            model.FeeCriteriaValueCombinationDescription = model.FeeStructureMasterList.Count > 0 ? model.FeeStructureMasterList[0].FeeCriteriaCombinationName : string.Empty;
            model.TotalFeeAmount = model.FeeStructureMasterList.Count > 0 ? model.FeeStructureMasterList[0].TotalFeeAmount : new decimal();
            model.FeeStructureSessionMasterID = model.FeeStructureMasterList.Count > 0 ? model.FeeStructureMasterList[0].FeeStructureSessionMasterID : 0;
            model.ApplicableFromDate = model.FeeStructureMasterList.Count > 0 ? model.FeeStructureMasterList[0].FeeStructureApplicableFromDate : string.Empty;
            model.IsInstallmentApplicable = model.FeeStructureMasterList[0].IsInstallmentApplicable;
            model.FeeStructureMasterID = Convert.ToInt32(ID);
            if (model.FeeStructureMasterList.Count > 0 ? model.FeeStructureMasterList[0].IsInstallmentApplicable : false)
            {
                model.FeeStructureInstallmentList = GetFeeStructureInstallmentDetails(Convert.ToInt32(ID));
                model.FeeStructureSessionInstallmentDetailsID = model.FeeStructureInstallmentList.Count > 0 ? model.FeeStructureInstallmentList[0].FeeStructureSessionInstallmentDetailsID : 0;
            }

            model.StructureApplicableStudentList = StudentListAccordingToFeeStructure(ID, 0, _recordsPerPage);

            return PartialView("~/Views/Fees/FeeStructureApplicable/FeeStructure.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FeeStructureApplicableViewModel model)
        {
            try
            {
                model.FeeStructureApplicableDTO.ConnectionString = _connectioString;
                model.FeeStructureApplicableDTO.FeeStructureSessionMasterID = model.FeeStructureSessionMasterID;
                model.FeeStructureApplicableDTO.IsInstallmentApplicable = model.IsInstallmentApplicable;
                model.FeeStructureApplicableDTO.FeeStructureMasterID = model.FeeStructureMasterID;
                model.FeeStructureApplicableDTO.ApplicableFromDate = model.ApplicableFromDate;
                model.FeeStructureApplicableDTO.AccBalsheetID = model.AccBalsheetID;
                model.FeeStructureApplicableDTO.XMLstring = model.XMLstring;
                model.FeeStructureApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeStructureApplicable> response = _feeStructureApplicableServiceAcess.InsertFeeStructureApplicable(model.FeeStructureApplicableDTO);
                model.FeeStructureApplicableDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult GetStudentList(int? pageNum, string ID)
        {
            pageNum = pageNum ?? 0;
            int from = ((pageNum ?? 0) * _recordsPerPage);
            int to = from + _recordsPerPage;
            FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
            model.StructureApplicableStudentList = StudentListAccordingToFeeStructure(ID, from, to);
            return PartialView("~/Views/Fees/FeeStructureApplicable/StudentList.cshtml", model.StructureApplicableStudentList);
        }

        [HttpGet]
        public ActionResult FeeStructureApplicableRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);


            model.FeeStructureCriteriaApprovalList = GetFeeStructureCriteriaApprovalList(PersonID, Convert.ToInt32(TNMID));
            if (model.FeeStructureCriteriaApprovalList.Count > 0)
            {
                model.StudentName = model.FeeStructureCriteriaApprovalList[0].StudentName;
                model.SectionDescription = model.FeeStructureCriteriaApprovalList[0].SectionDescription;
                model.AdmitAcademicYear = model.FeeStructureCriteriaApprovalList[0].AdmitAcademicYear;
                model.AdmissionPattern = model.FeeStructureCriteriaApprovalList[0].AdmissionPattern;
                model.FeeStructureMasterID = model.FeeStructureCriteriaApprovalList[0].FeeStructureMasterID;
                model.StudentID = model.FeeStructureCriteriaApprovalList[0].StudentID;
                model.AccBalanceSheetID = model.FeeStructureCriteriaApprovalList[0].AccBalanceSheetID;
                model.AccountSessionID = model.FeeStructureCriteriaApprovalList[0].AccountSessionID;
                model.FeeStructureApplicableHistoryID = model.FeeStructureCriteriaApprovalList[0].FeeStructureApplicableHistoryID;
            }
            return View("/Views/Fees/FeeStructureApplicable/FeeStructureApplicableRequestApproval.cshtml", model);
        }

        //Create Fee Structure Request Approval
        [HttpPost]
        public ActionResult CreateFeeStructureRequestApproval(FeeStructureApplicableViewModel model)
        {
            model.FeeStructureApplicableDTO.ConnectionString = _connectioString;
            model.FeeStructureApplicableDTO.FeeApprovalXmlstring = model.FeeApprovalXmlstring;
            model.FeeStructureApplicableDTO.StudentID = model.StudentID;
            model.FeeStructureApplicableDTO.AccBalanceSheetID = model.AccBalanceSheetID;
            model.FeeStructureApplicableDTO.AccountSessionID = model.AccountSessionID;
            model.FeeStructureApplicableDTO.FeeStructureApplicableHistoryID = model.FeeStructureApplicableHistoryID;
            model.FeeStructureApplicableDTO.FeeStructureMasterID = model.FeeStructureMasterID;
            model.FeeStructureApplicableDTO.RequestApprovalStatus = model.RequestApprovalStatus;
            model.FeeStructureApplicableDTO.PersonID = model.PersonID;
            model.FeeStructureApplicableDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.FeeStructureApplicableDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.FeeStructureApplicableDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.FeeStructureApplicableDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.FeeStructureApplicableDTO.IsLastRecord = model.IsLastRecord;

            model.FeeStructureApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

            IBaseEntityResponse<FeeStructureApplicable> response = _feeStructureApplicableServiceAcess.CreateFeeStructureRequestApproval(model.FeeStructureApplicableDTO);
            model.FeeStructureApplicableDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FeeStructureApplicableRequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            FeeStructureApplicableViewModel model = new FeeStructureApplicableViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);


            model.FeeStructureCriteriaApprovalList = GetFeeStructureCriteriaApprovalList(PersonID, Convert.ToInt32(TNMID));
            if (model.FeeStructureCriteriaApprovalList.Count > 0)
            {
                model.StudentName = model.FeeStructureCriteriaApprovalList[0].StudentName;
                model.SectionDescription = model.FeeStructureCriteriaApprovalList[0].SectionDescription;
                model.AdmitAcademicYear = model.FeeStructureCriteriaApprovalList[0].AdmitAcademicYear;
                model.AdmissionPattern = model.FeeStructureCriteriaApprovalList[0].AdmissionPattern;
                model.FeeStructureMasterID = model.FeeStructureCriteriaApprovalList[0].FeeStructureMasterID;
                model.StudentID = model.FeeStructureCriteriaApprovalList[0].StudentID;
                model.AccBalanceSheetID = model.FeeStructureCriteriaApprovalList[0].AccBalanceSheetID;
                model.AccountSessionID = model.FeeStructureCriteriaApprovalList[0].AccountSessionID;
                model.FeeStructureApplicableHistoryID = model.FeeStructureCriteriaApprovalList[0].FeeStructureApplicableHistoryID;
            }
            return View("/Views/Fees/FeeStructureApplicable/FeeStructureApplicableRequestApprovalV2.cshtml", model);
        }

        //Create Fee Structure Request Approval
        [HttpPost]
        public ActionResult CreateFeeStructureRequestApprovalV2(FeeStructureApplicableViewModel model)
        {
            model.FeeStructureApplicableDTO.ConnectionString = _connectioString;
            model.FeeStructureApplicableDTO.FeeApprovalXmlstring = model.FeeApprovalXmlstring;
            model.FeeStructureApplicableDTO.StudentID = model.StudentID;
            model.FeeStructureApplicableDTO.AccBalanceSheetID = model.AccBalanceSheetID;
            model.FeeStructureApplicableDTO.AccountSessionID = model.AccountSessionID;
            model.FeeStructureApplicableDTO.FeeStructureApplicableHistoryID = model.FeeStructureApplicableHistoryID;
            model.FeeStructureApplicableDTO.FeeStructureMasterID = model.FeeStructureMasterID;
            model.FeeStructureApplicableDTO.RequestApprovalStatus = model.RequestApprovalStatus;
            model.FeeStructureApplicableDTO.PersonID = model.PersonID;
            model.FeeStructureApplicableDTO.StageSequenceNumber = model.StageSequenceNumber;
            model.FeeStructureApplicableDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
            model.FeeStructureApplicableDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
            model.FeeStructureApplicableDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
            model.FeeStructureApplicableDTO.IsLastRecord = model.IsLastRecord;

            model.FeeStructureApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

            IBaseEntityResponse<FeeStructureApplicable> response = _feeStructureApplicableServiceAcess.CreateFeeStructureRequestApproval(model.FeeStructureApplicableDTO);
            model.FeeStructureApplicableDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        [NonAction]
        protected List<FeeStructureMasterAndDetails> GetFeeStructureDetails(int feeStructureMasterID)
        {

            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeStructureMasterAndDetails> listFeeStructureMasterAndDetails = new List<FeeStructureMasterAndDetails>();
            searchRequest.FeeStructureMasterID = feeStructureMasterID;
            searchRequest.AccBalsheetMstID = !string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Convert.ToInt32(Session["BalancesheetID"]) : 0;
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetFeeStructureDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeStructureMasterAndDetails;
        }

        [NonAction]
        protected List<FeeStructureApplicable> StudentListAccordingToFeeStructure(string id, int startRow, int endRow)
        {

            FeeStructureApplicableSearchRequest searchRequest = new FeeStructureApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeStructureApplicable> studentList = new List<FeeStructureApplicable>();
            searchRequest.FeeStructureMasterID = !string.IsNullOrEmpty(id) ? Convert.ToInt32(id) : 0;
            searchRequest.StartRow = startRow;
            searchRequest.EndRow = endRow;
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollectionResponse = _feeStructureApplicableServiceAcess.GetStudentListAccordingToFeeStructure(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    studentList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return studentList;
        }

        [NonAction]
        protected List<FeeStructureMasterAndDetails> GetFeeStructureInstallmentDetails(int feeStructureMasterID)
        {

            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeStructureMasterAndDetails> listFeeStructureMasterAndDetails = new List<FeeStructureMasterAndDetails>();
            searchRequest.FeeStructureMasterID = feeStructureMasterID;
            searchRequest.AccBalsheetMstID = !string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Convert.ToInt32(Session["BalancesheetID"]) : 0;
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetFeeStructureInstallmentList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeStructureMasterAndDetails;
        }

        [NonAction]
        protected List<FeeCriteriaMasterAndDetails> GetFeeCriteriaMasterAndDetails(Int16 accBalanceSheetID)
        {

            FeeCriteriaMasterAndDetailsSearchRequest searchRequest = new FeeCriteriaMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeCriteriaMasterAndDetails> listFeeCriteriaMasterAndDetails = new List<FeeCriteriaMasterAndDetails>();
            searchRequest.AccBalanceSheetID = accBalanceSheetID;
            IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> baseEntityCollectionResponse = _feeCriteriaMasterAndDetailsServiceAccess.GetCriteriaMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeCriteriaMasterAndDetails;
        }

        [NonAction]
        public IEnumerable<FeeStructureApplicableViewModel> GetFeeStructureApplicable(int feeCriteriaMasterId, int selectedBalsheetID, out int TotalRecords)
        {
            FeeStructureApplicableSearchRequest searchRequest = new FeeStructureApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = selectedBalsheetID;
            searchRequest.FeeCriteriaMasterID = feeCriteriaMasterId;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<FeeStructureApplicableViewModel> listFeeStructureApplicableViewModel = new List<FeeStructureApplicableViewModel>();
            List<FeeStructureApplicable> listFeeStructureApplicable = new List<FeeStructureApplicable>();
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollectionResponse = _feeStructureApplicableServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeStructureApplicable item in listFeeStructureApplicable)
                    {
                        FeeStructureApplicableViewModel FeeStructureApplicableViewModel = new FeeStructureApplicableViewModel();
                        FeeStructureApplicableViewModel.FeeStructureApplicableDTO = item;
                        listFeeStructureApplicableViewModel.Add(FeeStructureApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeStructureApplicableViewModel;
        }

        [NonAction]
        protected List<FeeStructureApplicable> GetFeeStructureCriteriaApprovalList(int personId, int taskNotificationMasterID)
        {
            FeeStructureApplicableSearchRequest searchRequest = new FeeStructureApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<FeeStructureApplicable> listFeeApproval = new List<FeeStructureApplicable>();
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollectionResponse = _feeStructureApplicableServiceAcess.GetFeeStructureCriteriaApprovalList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeApproval = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeApproval;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string selectedFeeCriteriaMasterID, string selectedBalsheetID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeStructureApplicableViewModel> filteredFeeStructureApplicable;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FeeCriteriaValueCombinationDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like  '%" + param.sSearch + "%' ";
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(selectedBalsheetID) && !string.IsNullOrEmpty(selectedFeeCriteriaMasterID))
            {
                filteredFeeStructureApplicable = GetFeeStructureApplicable(Convert.ToInt32(selectedFeeCriteriaMasterID), Convert.ToInt32(selectedBalsheetID), out TotalRecords);
            }
            else
            {
                filteredFeeStructureApplicable = new List<FeeStructureApplicableViewModel>();
                TotalRecords = 0;
            }
            var records = filteredFeeStructureApplicable.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaValueCombinationDescription), Convert.ToString(Math.Round(c.TotalFeeAmount, 2)), Convert.ToString(c.IsInstallmentApplicable), Convert.ToString(c.StatusFlag), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureSessionMasterID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}
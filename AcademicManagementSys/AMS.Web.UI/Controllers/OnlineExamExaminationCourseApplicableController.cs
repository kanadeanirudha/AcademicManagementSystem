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
    public class OnlineExamExaminationCourseApplicableController : BaseController
    {
        IOnlineExamExaminationCourseApplicableServiceAccess _OnlineExamExaminationCourseApplicableServiceAcess = null;

        IGeneralSessionMasterServiceAccess _GeneralSessionMasterServiceAccess=null;
        IOrganisationCourseYearDetailsServiceAccess _OrganisationCourseYearDetailsServiceAccess=null;
        IOrganisationSemesterMasterServiceAccess _OrganisationSemesterMasterServiceAccess=null;
        IOnlineExamExaminationCourseApplicableViewModel  _OnlineExamExaminationCourseApplicableViewModel =null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OnlineExamExaminationCourseApplicableController()
        {
            _OnlineExamExaminationCourseApplicableServiceAcess = new OnlineExamExaminationCourseApplicableServiceAccess();

            _GeneralSessionMasterServiceAccess = new GeneralSessionMasterServiceAccess();
            _OrganisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
            _OnlineExamExaminationCourseApplicableViewModel =new OnlineExamExaminationCourseApplicableViewModel ();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/OnlineExam/OnlineExamExaminationCourseApplicable/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OnlineExamExaminationCourseApplicableViewModel model = new OnlineExamExaminationCourseApplicableViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/OnlineExam/OnlineExamExaminationCourseApplicable/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(String actionMode, int IDs)
        {
           // string tempId = IDs;
            OnlineExamExaminationCourseApplicableViewModel model = new OnlineExamExaminationCourseApplicableViewModel();
            model.OnlineExamExaminationMasterId = IDs;

            //************* Static DropDownList For ExaminationStatus***************************

            List<SelectListItem> ExaminationStatus = new List<SelectListItem>();
            ViewBag.ExaminationStatus = new SelectList(ExaminationStatus, "Value", "Text");//Define ViewBag For the List
            List<SelectListItem> li_ExaminationStatus = new List<SelectListItem>();

            li_ExaminationStatus.Add(new SelectListItem { Text = "Completed",  Value = "1" });
            li_ExaminationStatus.Add(new SelectListItem { Text = "In progress",Value = "2" });
            li_ExaminationStatus.Add(new SelectListItem { Text = "Pending",    Value = "3" });

            ViewBag.ExaminationStatus = li_ExaminationStatus;
            if (!string.IsNullOrEmpty(actionMode))
            {
                TempData["ActionMode"] = actionMode;
            }


            //************************** Dynamic Drop Down For Course Year **********************

            List<OrganisationCourseYearDetails> OrganisationCourseYearDetails = GetListOrganisationCourseYearDetails();
            
            List<SelectListItem> OrganisationCourseYearDetailsList = new List<SelectListItem>();
            
            foreach (OrganisationCourseYearDetails item in OrganisationCourseYearDetails)
            {
                OrganisationCourseYearDetailsList.Add(new SelectListItem { Text = item.CourseDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.OrganisationCourseYearDetailsListt = new SelectList(OrganisationCourseYearDetailsList, "Value", "Text");
            

            return PartialView("/Views/OnlineExam/OnlineExamExaminationCourseApplicable/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExamExaminationCourseApplicableViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.OnlineExamExaminationCourseApplicableDTO != null)
                {
                    model.OnlineExamExaminationCourseApplicableDTO.ConnectionString = _connectioString;
                    model.OnlineExamExaminationCourseApplicableDTO.CourseYearID = model.CourseYearID;
                    model.OnlineExamExaminationCourseApplicableDTO.SemesterMstID = model.SemesterMstID;
                    model.OnlineExamExaminationCourseApplicableDTO.DepartmentID= model.DepartmentID;
                    model.OnlineExamExaminationCourseApplicableDTO.ExaminationStatus = model.ExaminationStatus;
                    model.OnlineExamExaminationCourseApplicableDTO.ExaminationStartDate = model.ExaminationStartDate;
                    model.OnlineExamExaminationCourseApplicableDTO.ExaminationEndDate = model.ExaminationEndDate;
                    model.OnlineExamExaminationCourseApplicableDTO.ResultAnnounceDate = model.ResultAnnounceDate;
                    model.OnlineExamExaminationCourseApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = _OnlineExamExaminationCourseApplicableServiceAcess.InsertOnlineExamExaminationCourseApplicable(model.OnlineExamExaminationCourseApplicableDTO);

                    model.OnlineExamExaminationCourseApplicableDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.OnlineExamExaminationCourseApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    OnlineExamExaminationCourseApplicableViewModel model = new OnlineExamExaminationCourseApplicableViewModel();
        //    try
        //    {
        //        model.OnlineExamExaminationCourseApplicableDTO = new OnlineExamExaminationCourseApplicable();
        //        model.OnlineExamExaminationCourseApplicableDTO.ID = id;
        //        model.OnlineExamExaminationCourseApplicableDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = _OnlineExamExaminationCourseApplicableServiceAcess.SelectByID(model.OnlineExamExaminationCourseApplicableDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OnlineExamExaminationCourseApplicableDTO.ID = response.Entity.ID;
        //            model.OnlineExamExaminationCourseApplicableDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OnlineExamExaminationCourseApplicableDTO.GroupCode = response.Entity.GroupCode;
        //            model.OnlineExamExaminationCourseApplicableDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(OnlineExamExaminationCourseApplicableViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.OnlineExamExaminationCourseApplicableDTO != null)
        //        {
        //            if (model != null && model.OnlineExamExaminationCourseApplicableDTO != null)
        //            {
        //                model.OnlineExamExaminationCourseApplicableDTO.ConnectionString = _connectioString;
        //                model.OnlineExamExaminationCourseApplicableDTO.MovementType = model.MovementType;
        //                model.OnlineExamExaminationCourseApplicableDTO.MovementCode = model.MovementCode;
        //                model.OnlineExamExaminationCourseApplicableDTO.IsActive = model.IsActive;
                      
        //                model.OnlineExamExaminationCourseApplicableDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = _OnlineExamExaminationCourseApplicableServiceAcess.UpdateOnlineExamExaminationCourseApplicable(model.OnlineExamExaminationCourseApplicableDTO);
        //                model.OnlineExamExaminationCourseApplicableDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.OnlineExamExaminationCourseApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        OnlineExamExaminationCourseApplicableViewModel model = new OnlineExamExaminationCourseApplicableViewModel();
        //        model.OnlineExamExaminationCourseApplicableDTO = new OnlineExamExaminationCourseApplicable();
        //        model.OnlineExamExaminationCourseApplicableDTO.ID = Convert.ToInt16(ID);
        //        model.OnlineExamExaminationCourseApplicableDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = _OnlineExamExaminationCourseApplicableServiceAcess.SelectByID(model.OnlineExamExaminationCourseApplicableDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.OnlineExamExaminationCourseApplicableDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.OnlineExamExaminationCourseApplicableDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.OnlineExamExaminationCourseApplicableDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.OnlineExamExaminationCourseApplicableDTO.GenServiceRequiredID);

        //        return PartialView("/Views/OnlineExamExaminationCourseApplicable/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = null;
                OnlineExamExaminationCourseApplicable OnlineExamExaminationCourseApplicableDTO = new OnlineExamExaminationCourseApplicable();
                OnlineExamExaminationCourseApplicableDTO.ConnectionString = _connectioString;
                OnlineExamExaminationCourseApplicableDTO.ID = Convert.ToInt32(ID);
                OnlineExamExaminationCourseApplicableDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _OnlineExamExaminationCourseApplicableServiceAcess.DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicableDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

             //For GetSemester By CourseYear

        public ActionResult GetSemesterByCourseYear(String CourseYearID)
        {
           
            if (String.IsNullOrEmpty(CourseYearID))
            {
                throw new ArgumentNullException("CourseYearID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CourseYearID, out id);
            var Semester = GetSemesterListOrganisationSemesterMaster(CourseYearID);
            var result = (from s in Semester
                          select new
                          {
                              id = s.ID,
                              name = s.OrgSemesterName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //For GetDepartment By CourseYear

        public ActionResult GetDepartmentByCourseYear(String CourseYearID)
        {

            if (String.IsNullOrEmpty(CourseYearID))
            {
                throw new ArgumentNullException("CourseYearID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CourseYearID, out id);
            var Department = GetDepartmentListOrganisationDepartmentMaster(CourseYearID);
            var result = (from s in Department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Non-Action Method
        #region Methods
       
        //************ Dynamic DropdownList Call For Course Year***************** 
        protected List<OrganisationCourseYearDetails> GetListOrganisationCourseYearDetails()
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _OrganisationCourseYearDetailsServiceAccess.GetCourseYearDetailDescription(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }

   

        public IEnumerable<OnlineExamExaminationCourseApplicableViewModel> GetOnlineExamExaminationCourseApplicable(out int TotalRecords)
        {
            OnlineExamExaminationCourseApplicableSearchRequest searchRequest = new OnlineExamExaminationCourseApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
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
            List<OnlineExamExaminationCourseApplicableViewModel> listOnlineExamExaminationCourseApplicableViewModel = new List<OnlineExamExaminationCourseApplicableViewModel>();
            List<OnlineExamExaminationCourseApplicable> listOnlineExamExaminationCourseApplicable = new List<OnlineExamExaminationCourseApplicable>();
            IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> baseEntityCollectionResponse = _OnlineExamExaminationCourseApplicableServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamExaminationCourseApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamExaminationCourseApplicable item in listOnlineExamExaminationCourseApplicable)
                    {
                        OnlineExamExaminationCourseApplicableViewModel OnlineExamExaminationCourseApplicableViewModel = new OnlineExamExaminationCourseApplicableViewModel();
                        OnlineExamExaminationCourseApplicableViewModel.OnlineExamExaminationCourseApplicableDTO = item;
                        listOnlineExamExaminationCourseApplicableViewModel.Add(OnlineExamExaminationCourseApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamExaminationCourseApplicableViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<OnlineExamExaminationCourseApplicableViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ExaminationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%"+param.sSearch+"%' or A.ExaminationFor Like'%"+param.sSearch+"%'";  //this if block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.Purpose";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.AcadSessionId";
                        if(string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "A.ExaminationFor";
                        if(string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ExaminationName Like '%" + param.sSearch + "%'  or A.Purpose Like '%" + param.sSearch + "%'or A.AcadSessionId Like'%" + param.sSearch + "%' or A.ExaminationFor Like'%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetOnlineExamExaminationCourseApplicable(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ExaminationName), Convert.ToString(c.DepartmentName),Convert.ToString(c.Semester), Convert.ToString(c.ExaminationStartDate), Convert.ToString(c.ExaminationEndDate), Convert.ToString(c.ResultAnnounceDate), Convert.ToString(c.ID), Convert.ToString(c.OnlineExamExaminationMasterId) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}
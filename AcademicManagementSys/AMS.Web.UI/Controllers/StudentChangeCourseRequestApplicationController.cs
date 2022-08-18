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

namespace AMS.Web.UI.Controllers
{
    public class StudentChangeCourseRequestApplicationController : BaseController
    {
        IOrganisationBranchDetailsServiceAccess _OrganisationBranchDetailsServiceAccess = null;
        IOrganisationDepartmentMasterServiceAccess _OrganisationDepartmentMasterServiceAccess = null;
        IStudentChangeCourseRequestApplicationServiceAccess _StudentChangeCourseRequestApplicationServiceAccess = null;
        IToolTemplateApplicableServiceAccess _ToolTemplateApplicableServiceAccess = null;
        private readonly ILogger _logException;
        StudentChangeCourseRequestApplicationViewModel _StudentChangeCourseRequestApplicationViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentChangeCourseRequestApplicationController()
        {
            _StudentChangeCourseRequestApplicationServiceAccess = new StudentChangeCourseRequestApplicationServiceAccess();
            _StudentChangeCourseRequestApplicationViewModel = new StudentChangeCourseRequestApplicationViewModel();
            _ToolTemplateApplicableServiceAccess = new ToolTemplateApplicableServiceAccess();
            _OrganisationBranchDetailsServiceAccess = new OrganisationBranchDetailsServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                StudentChangeCourseRequestApplicationViewModel model = new StudentChangeCourseRequestApplicationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("List", model);
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
            StudentChangeCourseRequestApplicationViewModel model = new StudentChangeCourseRequestApplicationViewModel();
            model.StudentChangeCourseRequestApplicationDTO = new StudentChangeCourseRequestApplication();
            
            model.StudentChangeCourseRequestApplicationDTO.UserLoginId = "1";
            model.StudentChangeCourseRequestApplicationDTO.ConnectionString = _connectioString;
            model.UserLoginId = model.StudentChangeCourseRequestApplicationDTO.UserLoginId;
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = _StudentChangeCourseRequestApplicationServiceAccess.SelectByUserLoginId(model.StudentChangeCourseRequestApplicationDTO);
            if (response != null && response.Entity != null)
            {
                model.StudentChangeCourseRequestApplicationDTO.Id = response.Entity.Id;
                model.CentreName = response.Entity.CentreName;
                model.UniversityName = response.Entity.UniversityName;
                model.AdmittedCourse = response.Entity.BranchDescription;
                model.NewCourseId = response.Entity.NewCourseId;
                model.UniversityID = response.Entity.UniversityID;
                model.CenterCode = response.Entity.CenterCode;
                model.OldCourseId = response.Entity.OldCourseId;
                model.OldSectionDetailID = response.Entity.OldSectionDetailID;
                //model.ApplicationStatus = response.Entity.ApplicationStatus;
                //model.ApplicationReason = response.Entity.ApplicationReason;
            }


            //For Baranch
            //  int UniversityID = 0;
            List<StudentChangeCourseRequestApplication> StudentChangeCourseRequestApplicationlist = GetListStudentChangeCourseRequestApplication(model.StudentChangeCourseRequestApplicationDTO.UniversityID, model.StudentChangeCourseRequestApplicationDTO.CenterCode);
            List<SelectListItem> StudentChangeCourseRequestApplication = new List<SelectListItem>();
            foreach (StudentChangeCourseRequestApplication item in StudentChangeCourseRequestApplicationlist)
            {
                StudentChangeCourseRequestApplication.Add(new SelectListItem { Text = item.BranchDescription, Value = item.BranchID.ToString() });
            }
            ViewBag.StudentChangeCourseRequestApplication = new SelectList(StudentChangeCourseRequestApplication, "Value", "Text");


            return PartialView(model);

        }


        [HttpPost]
        public ActionResult Create(StudentChangeCourseRequestApplicationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentChangeCourseRequestApplicationDTO != null)
                    {
                      
                        model.StudentChangeCourseRequestApplicationDTO.ConnectionString = _connectioString;

                        model.StudentChangeCourseRequestApplicationDTO.UniversityID = model.UniversityID;
                        model.StudentChangeCourseRequestApplicationDTO.UniversityName = model.UniversityName;
                        model.StudentChangeCourseRequestApplicationDTO.CentreName = model.CentreName;
                        model.StudentChangeCourseRequestApplicationDTO.CenterCode = model.CenterCode;
                        model.StudentChangeCourseRequestApplicationDTO.OldCourseId = model.OldCourseId;
                        model.StudentChangeCourseRequestApplicationDTO.NewCourseId = model.NewCourseId;
                        model.StudentChangeCourseRequestApplicationDTO.OldSectionDetailID = model.OldSectionDetailID;
                        model.StudentChangeCourseRequestApplicationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentChangeCourseRequestApplication> response = _StudentChangeCourseRequestApplicationServiceAccess.InsertStudentChangeCourseRequestApplication(model.StudentChangeCourseRequestApplicationDTO);
                        model.StudentChangeCourseRequestApplicationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.StudentChangeCourseRequestApplicationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    StudentChangeCourseRequestApplicationViewModel model = new StudentChangeCourseRequestApplicationViewModel();
        //    try
        //    {
        //        string SelectedCountryID = string.Empty;
        //        List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
        //        List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
        //        foreach (GeneralRegionMaster item in generalRegionMasterList)
        //        {
        //            generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
        //        }
        //        model.StudentChangeCourseRequestApplicationDTO = new StudentChangeCourseRequestApplicationMaster();
        //        model.StudentChangeCourseRequestApplicationDTO.ID = id;
        //        model.StudentChangeCourseRequestApplicationDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<StudentChangeCourseRequestApplicationMaster> response = _StudentChangeCourseRequestApplicationMasterServiceAcess.SelectByID(model.StudentChangeCourseRequestApplicationDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.StudentChangeCourseRequestApplicationDTO.ID = response.Entity.ID;
        //            model.StudentChangeCourseRequestApplicationDTO.Description = response.Entity.Description;
        //            model.StudentChangeCourseRequestApplicationDTO.DefaultFlag = response.Entity.DefaultFlag;
        //            model.StudentChangeCourseRequestApplicationDTO.CreatedBy = response.Entity.CreatedBy;
        //            ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.RegionID.ToString());

        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(StudentChangeCourseRequestApplicationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentChangeCourseRequestApplicationDTO != null)
                    {
                        if (model != null && model.StudentChangeCourseRequestApplicationDTO != null)
                        {
                            model.StudentChangeCourseRequestApplicationDTO.ConnectionString = _connectioString;
                            model.StudentChangeCourseRequestApplicationDTO.Id = model.Id;
                            model.StudentChangeCourseRequestApplicationDTO.ChangeRequestMasterId = model.ChangeRequestMasterId;
                            model.StudentChangeCourseRequestApplicationDTO.StudentId = model.StudentId;
                            model.StudentChangeCourseRequestApplicationDTO.ApplicationDate = model.ApplicationDate;
                            model.StudentChangeCourseRequestApplicationDTO.AcademicYearId = model.AcademicYearId;
                            model.StudentChangeCourseRequestApplicationDTO.OldCourseId = model.OldCourseId;
                            model.StudentChangeCourseRequestApplicationDTO.NewCourseId = model.NewCourseId;
                            model.StudentChangeCourseRequestApplicationDTO.ApprovalStatus = model.ApprovalStatus;
                            model.StudentChangeCourseRequestApplicationDTO.NewSectionDetailsID = model.NewSectionDetailsID;
                            model.StudentChangeCourseRequestApplicationDTO.OldSectionDetailID = model.OldSectionDetailID;
                            model.StudentChangeCourseRequestApplicationDTO.RequestSectionDetailID = model.RequestSectionDetailID;
                            model.StudentChangeCourseRequestApplicationDTO.CenterCode = model.CenterCode;
                            model.StudentChangeCourseRequestApplicationDTO.UniversityID = model.UniversityID;
                            model.StudentChangeCourseRequestApplicationDTO.University = model.University;
                            model.StudentChangeCourseRequestApplicationDTO.AdmittedCourse = model.AdmittedCourse;
                            model.StudentChangeCourseRequestApplicationDTO.AdmittedCourse = model.NewCourse;
                            model.StudentChangeCourseRequestApplicationDTO.OldSection = model.OldSection;
                            model.StudentChangeCourseRequestApplicationDTO.NewSection = model.NewSection;
                            model.StudentChangeCourseRequestApplicationDTO.RoleID = model.RoleID;
                            model.StudentChangeCourseRequestApplicationDTO.ApprovalDate = model.ApprovalDate;
                            model.StudentChangeCourseRequestApplicationDTO.ApplicationReason = model.ApplicationReason;
                            model.StudentChangeCourseRequestApplicationDTO.CancellationReason = model.CancellationReason;
                            model.StudentChangeCourseRequestApplicationDTO.ApplicationStatus = model.ApplicationStatus;
                            model.StudentChangeCourseRequestApplicationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = _StudentChangeCourseRequestApplicationServiceAccess.UpdateStudentChangeCourseRequestApplication(model.StudentChangeCourseRequestApplicationDTO);
                            model.StudentChangeCourseRequestApplicationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.StudentChangeCourseRequestApplicationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        // Non-Action Method
        #region Methods

        // for new Course

        protected List<StudentChangeCourseRequestApplication> GetListStudentChangeCourseRequestApplication(int UniversityID, string CenterCode)
        {
            StudentChangeCourseRequestApplicationSearchRequest searchRequest = new StudentChangeCourseRequestApplicationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CenterCode = CenterCode;
            searchRequest.UniversityID = UniversityID;
            //searchRequest.SearchType = 1;
            List<StudentChangeCourseRequestApplication> listNewCourse = new List<StudentChangeCourseRequestApplication>();
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> baseEntityCollectionResponse = _StudentChangeCourseRequestApplicationServiceAccess.GetBySearchlist(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listNewCourse = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listNewCourse;
        }

        public IEnumerable<StudentChangeCourseRequestApplicationViewModel> GetStudentChangeCourseRequestApplicationMaster(out int TotalRecords)
        {
            StudentChangeCourseRequestApplicationSearchRequest searchRequest = new StudentChangeCourseRequestApplicationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
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
            List<StudentChangeCourseRequestApplicationViewModel> listStudentChangeCourseRequestApplicationViewModel = new List<StudentChangeCourseRequestApplicationViewModel>();
            List<StudentChangeCourseRequestApplication> listStudentChangeCourseRequestApplicationMaster = new List<StudentChangeCourseRequestApplication>();
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> baseEntityCollectionResponse = _StudentChangeCourseRequestApplicationServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentChangeCourseRequestApplicationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (StudentChangeCourseRequestApplication item in listStudentChangeCourseRequestApplicationMaster)
                    {
                        StudentChangeCourseRequestApplicationViewModel generalRegionMasterViewModel = new StudentChangeCourseRequestApplicationViewModel();
                        generalRegionMasterViewModel.StudentChangeCourseRequestApplicationDTO = item;
                        listStudentChangeCourseRequestApplicationViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listStudentChangeCourseRequestApplicationViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<StudentChangeCourseRequestApplicationViewModel> filteredStudentChangeCourseRequestApplicationViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = " AdmittedCourse";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " AdmittedCourse Like '%" + param.sSearch + "%' or NewCourse Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = " NewCourse";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdmittedCourse Like '%" + param.sSearch + "%' or NewCourse Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ApplicationStatus";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AdmittedCourse Like '%" + param.sSearch + "%' or NewCourse Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredStudentChangeCourseRequestApplicationViewModel = GetStudentChangeCourseRequestApplicationMaster(out TotalRecords);
            var records = filteredStudentChangeCourseRequestApplicationViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.AdmittedCourse.ToString(), c.NewCourse, Convert.ToString(c.ApplicationStatus), Convert.ToString(c.Id) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

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
    public class StudentAdmissionCancelController : BaseController
    {
        IStudentMasterServiceAccess _studentMasterServiceAccess = null;
        IOrganisationCourseYearDetailsServiceAccess _organisationCourseYearDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentAdmissionCancelController()
        {
            _studentMasterServiceAccess = new StudentMasterServiceAccess();
            _organisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Student/StudentAdmissionCancel/Index.cshtml");
        }

        public ActionResult List(string centerCode, string courseYearDetailsID, string actionMode)
        {
            try
            {
                StudentMasterViewModel model = new StudentMasterViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.ListOrganisationCourseYearDetails = GetCourseYearDetailsByCentreCode(splitCentreCode[0]);
                }
                model.SelectedCentreCode = centerCode;
                model.SelectedCourseYearDetailsID = courseYearDetailsID;


                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Student/StudentAdmissionCancel/List.cshtml", model);

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
            StudentMasterViewModel model = new StudentMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(StudentMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.StudentMasterDTO != null)
                    {
                        model.StudentMasterDTO.ConnectionString = _connectioString;
                        // model.StudentMasterDTO.CountryName = model.CountryName;
                        //// model.StudentMasterDTO.SeqNo = model.SeqNo; ;
                        // model.StudentMasterDTO.ContryCode = model.ContryCode;
                        // model.StudentMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.StudentMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.InsertStudentMaster(model.StudentMasterDTO);
                        model.StudentMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.StudentMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentMasterViewModel model = new StudentMasterViewModel();
            try
            {
                model.StudentMasterDTO = new StudentMaster();
                model.StudentMasterDTO.ID = id;
                model.StudentMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.SelectByID(model.StudentMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentMasterDTO.ID = response.Entity.ID;
                    // model.StudentMasterDTO.CountryName = response.Entity.CountryName;
                    //// model.StudentMasterDTO.SeqNo = response.Entity.SeqNo;
                    // model.StudentMasterDTO.ContryCode = response.Entity.ContryCode;
                    // model.StudentMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    // model.StudentMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.StudentMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.StudentMasterDTO != null)
                {
                    if (model != null && model.StudentMasterDTO != null)
                    {
                        model.StudentMasterDTO.ConnectionString = _connectioString;
                        //model.StudentMasterDTO.CountryName = model.CountryName;
                        //model.StudentMasterDTO.SeqNo = model.SeqNo;
                        //model.StudentMasterDTO.ContryCode = model.ContryCode;
                        //model.StudentMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.StudentMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.UpdateStudentMaster(model.StudentMasterDTO);
                        model.StudentMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.StudentMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        #endregion

        // Non-Action Method
        #region Methods

        public ActionResult GetCourseYearDetailsCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            //  _StudentMasterViewModel.SelectedCentreName = splited[1];
            SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var CourseYearDetails = GetCourseYearDetailsByCentreCode(SelectedCentreCode);
            var result = (from s in CourseYearDetails
                          select new
                          {
                              id = s.ID,
                              name = s.CourseYearCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<OrganisationCourseYearDetails> GetCourseYearDetailsByCentreCode(string CentreCode)
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetCourseYearDetailsByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }
        [NonAction]
        public IEnumerable<StudentMasterViewModel> GetStudentAdmissionCancel(string centerCode, int courseYearDetailsId, out int TotalRecords)
        {
            StudentMasterSearchRequest searchRequest = new StudentMasterSearchRequest();
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

                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.CourseYearId = courseYearDetailsId;
                  
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";

                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.CourseYearId = courseYearDetailsId;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;

                string[] Centre_code = centerCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                searchRequest.CourseYearId = courseYearDetailsId;
            }

            List<StudentMasterViewModel> listStudentMasterViewModel = new List<StudentMasterViewModel>();
            List<StudentMaster> listStudentMaster = new List<StudentMaster>();
            IBaseEntityCollectionResponse<StudentMaster> baseEntityCollectionResponse = _studentMasterServiceAccess.GetStudentAdmissionCancel(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (StudentMaster item in listStudentMaster)
                    {
                        StudentMasterViewModel StudentMasterViewModel = new StudentMasterViewModel();
                        StudentMasterViewModel.StudentMasterDTO = item;
                        listStudentMasterViewModel.Add(StudentMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listStudentMasterViewModel;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedCourseYearDetailsID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<StudentMasterViewModel> filteredStudentAdmissionCancel;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedCourseYearDetailsID))
                {
                    filteredStudentAdmissionCancel = GetStudentAdmissionCancel(SelectedCentreCode, Convert.ToInt32(SelectedCourseYearDetailsID), out TotalRecords);
                }
                else
                {
                    filteredStudentAdmissionCancel = new List<StudentMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredStudentAdmissionCancel.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.StudentFullName), Convert.ToString(c.StudentGender), Convert.ToString(c.ID) };

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
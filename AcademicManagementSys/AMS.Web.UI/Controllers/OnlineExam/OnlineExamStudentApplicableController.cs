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
    public class OnlineExamStudentApplicableController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExamStudentApplicableServiceAccess _OnlineExamStudentApplicableServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public OnlineExamStudentApplicableController()
        {
            _OnlineExamStudentApplicableServiceAcess = new OnlineExamStudentApplicableServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            OnlineExamStudentApplicableViewModel model = new OnlineExamStudentApplicableViewModel();
            var AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
            }
            else
            {
                AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
            }
            List<AdminRoleApplicableDetails> AdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(Convert.ToInt32(AdminRoleMasterID));
            List<SelectListItem> listAdminRoleApplicableDetails = new List<SelectListItem>();
            foreach (AdminRoleApplicableDetails item in AdminRoleApplicableDetails)
            {
                listAdminRoleApplicableDetails.Add(new SelectListItem { Text = item.CentreName, Value = Convert.ToString(item.CentreCode) });
            }

            ViewBag.listAdminRoleApplicableDetails = new SelectList(listAdminRoleApplicableDetails, "Value", "Text");

            return View("~/Views/OnlineExam/OnlineExamStudentApplicable/Index.cshtml");
        }

        public ActionResult List(string actionmode)
        {
            try
            {
                OnlineExamStudentApplicableViewModel model = new OnlineExamStudentApplicableViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamStudentApplicable/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AllocatedStudentList(string actionmode)
        {
            try
            {
                OnlineExamStudentApplicableViewModel model = new OnlineExamStudentApplicableViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamStudentApplicable/AllocatedStudentList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult AddStudentForExam(OnlineExamStudentApplicableViewModel model)
        {
            try
            {
                model.OnlineExamStudentApplicableDTO.ConnectionString = _connectioString;
                model.OnlineExamStudentApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                model.OnlineExamStudentApplicableDTO.XMLString = model.XMLString;
                model.OnlineExamStudentApplicableDTO.OnlineExamSubjectGroupScheduleID = model.OnlineExamSubjectGroupScheduleID;
                model.OnlineExamStudentApplicableDTO.CenterwiseSessionID = model.CenterwiseSessionID;

                IBaseEntityResponse<OnlineExamStudentApplicable> response = _OnlineExamStudentApplicableServiceAcess.AddStudentForExam(model.OnlineExamStudentApplicableDTO);
                model.OnlineExamStudentApplicableDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                return Json(model.OnlineExamStudentApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RemoveStudentFromExam(OnlineExamStudentApplicableViewModel model)
        {
            try
            {
                model.OnlineExamStudentApplicableDTO.ConnectionString = _connectioString;
                model.OnlineExamStudentApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                model.OnlineExamStudentApplicableDTO.XMLString = model.XMLString;
                model.OnlineExamStudentApplicableDTO.OnlineExamSubjectGroupScheduleID = model.OnlineExamSubjectGroupScheduleID;
                model.OnlineExamStudentApplicableDTO.CenterwiseSessionID = model.CenterwiseSessionID;

                IBaseEntityResponse<OnlineExamStudentApplicable> response = _OnlineExamStudentApplicableServiceAcess.RemoveStudentFromExam(model.OnlineExamStudentApplicableDTO);
                model.OnlineExamStudentApplicableDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                return Json(model.OnlineExamStudentApplicableDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult GetOnlineExamGetExaminationListCentreWise(string CentreCode)
        {
            int EmployeeID = Convert.ToInt32(Session["PersonID"]);
            int RoleMasterID = Convert.ToInt32(Session["RoleID"]);

            var CuurentSession = GetCurrentSession(CentreCode);

            var resultCuurentSession = (from s in CuurentSession
                                        select new
                                        {
                                            ID = s.ID,
                                            SessionID = s.SessionID,
                                        }).ToList();

            if (resultCuurentSession.Count != 0)
            {
                int SessionID = resultCuurentSession[0].SessionID;
                int CenterwiseSessionID = resultCuurentSession[0].ID;

                var ExaminationMaster = OnlineExamGetExaminationListCentreWise(CentreCode, SessionID, EmployeeID, RoleMasterID);
                var result = (from s in ExaminationMaster
                              select new
                              {
                                  id = s.ID,
                                  name = s.ExaminationName,
                                  CenterwiseSessionID = CenterwiseSessionID,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCourseYearListOnlineExaminationMasterWise(int OnlineExaminationMasterID, string CentreCode)
        {

            var CourseYearList = CourseYearListOnlineExaminationMasterWise(OnlineExaminationMasterID, CentreCode);
            var result = (from s in CourseYearList
                          select new
                          {
                              id = s.CourseYearID,
                              name = s.CourseYearDescription,
                              dataAttr = s.SemesterMstID,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        protected List<OnlineExamStudentApplicable> CourseYearListOnlineExaminationMasterWise(int OnlineExaminationMasterID, string CentreCode)
        {

            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExaminationMasterID = OnlineExaminationMasterID;
            searchRequest.CentreCode = CentreCode;
            List<OnlineExamStudentApplicable> listExamination = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAcess.CourseYearListOnlineExaminationMasterWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamination;
        }

        public ActionResult GetSubjectListOnlineCourseYearWise(int CourseYearID, int SemesterMstID, int OnlineExaminationMasterID)
        {

            var SubjectList = SubjectListOnlineCourseYearWise(OnlineExaminationMasterID, CourseYearID, SemesterMstID);
            var result = (from s in SubjectList
                          select new
                          {
                              id = s.SubjectID,
                              name = s.SubjectDescription,
                              OnlineExamSubjectGroupScheduleID = s.OnlineExamSubjectGroupScheduleID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        protected List<OnlineExamStudentApplicable> SubjectListOnlineCourseYearWise(int OnlineExaminationMasterID, int CourseYearID, int SemesterMstID)
        {

            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExaminationMasterID = OnlineExaminationMasterID;
            searchRequest.CourseYearID = CourseYearID;
            searchRequest.SemesterMstID = SemesterMstID;
            List<OnlineExamStudentApplicable> listExamination = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAcess.SubjectListOnlineCourseYearWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamination;
        }

        public ActionResult GetSectionListOnlineCourseYearWise(int CourseYearID)
        {

            var SectionList = SectionListOnlineCourseYearWise(CourseYearID);
            var result = (from s in SectionList
                          select new
                          {
                              id = s.SectionDetailID,
                              name = s.SectionDetailDescription,
                             
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        protected List<OnlineExamStudentApplicable> SectionListOnlineCourseYearWise(int CourseYearID)
        {

            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = CourseYearID;
            List<OnlineExamStudentApplicable> listExamination = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAcess.SectionListOnlineCourseYearWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamination;
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public IEnumerable<OnlineExamStudentApplicableViewModel> GetOnlineExamStudentApplicableList(out int TotalRecords, string CentreCode, int OnlineExaminationMasterID, int CourseYearID, int SectionDetailID, int SubjectID)
        {
            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.OnlineExaminationMasterID = OnlineExaminationMasterID;
            searchRequest.CourseYearID = CourseYearID;
            searchRequest.SectionDetailID = SectionDetailID;
            searchRequest.SubjectID = SubjectID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.FirstName asc, A.MiddleName asc, A.LastName ";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "asc";
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
            List<OnlineExamStudentApplicableViewModel> listOnlineExamStudentApplicableViewModel = new List<OnlineExamStudentApplicableViewModel>();
            List<OnlineExamStudentApplicable> listOnlineExamStudentApplicable = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAcess.GetOnlineExamStudentApplicableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamStudentApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamStudentApplicable item in listOnlineExamStudentApplicable)
                    {
                        OnlineExamStudentApplicableViewModel OnlineExamStudentApplicableViewModel = new OnlineExamStudentApplicableViewModel();
                        OnlineExamStudentApplicableViewModel.OnlineExamStudentApplicableDTO = item;
                        listOnlineExamStudentApplicableViewModel.Add(OnlineExamStudentApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamStudentApplicableViewModel;
        }

        public IEnumerable<OnlineExamStudentApplicableViewModel> GetOnlineExamStudentAllotedList(out int TotalRecords, string CentreCode, int OnlineExaminationMasterID, int CourseYearID, int SectionDetailID, int SubjectID)
        {
            OnlineExamStudentApplicableSearchRequest searchRequest = new OnlineExamStudentApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.OnlineExaminationMasterID = OnlineExaminationMasterID;
            searchRequest.CourseYearID = CourseYearID;
            searchRequest.SectionDetailID = SectionDetailID;
            searchRequest.SubjectID = SubjectID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.FirstName asc, A.MiddleName asc, A.LastName ";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "asc";
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
            List<OnlineExamStudentApplicableViewModel> listOnlineExamStudentApplicableViewModel = new List<OnlineExamStudentApplicableViewModel>();
            List<OnlineExamStudentApplicable> listOnlineExamStudentApplicable = new List<OnlineExamStudentApplicable>();
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> baseEntityCollectionResponse = _OnlineExamStudentApplicableServiceAcess.OnlineExamStudentAllotedList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamStudentApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamStudentApplicable item in listOnlineExamStudentApplicable)
                    {
                        OnlineExamStudentApplicableViewModel OnlineExamStudentApplicableViewModel = new OnlineExamStudentApplicableViewModel();
                        OnlineExamStudentApplicableViewModel.OnlineExamStudentApplicableDTO = item;
                        listOnlineExamStudentApplicableViewModel.Add(OnlineExamStudentApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamStudentApplicableViewModel;
        }

        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, int OnlineExaminationMasterID, int CourseYearID, int SectionDetailID, int SubjectID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamStudentApplicableViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";   
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamStudentApplicableList(out TotalRecords, CentreCode, OnlineExaminationMasterID, CourseYearID, SectionDetailID, SubjectID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.StudentID), Convert.ToString(c.StudentName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllocatedStudentAjaxHandler(JQueryDataTableParamModel param, string CentreCode, int OnlineExaminationMasterID, int CourseYearID, int SectionDetailID, int SubjectID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamStudentApplicableViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.FirstName " + sortDirection + ", A.MiddleName " + sortDirection + ", A.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamStudentAllotedList(out TotalRecords, CentreCode, OnlineExaminationMasterID, CourseYearID, SectionDetailID, SubjectID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.StudentID), Convert.ToString(c.StudentName), Convert.ToString(c.OnlineExamIndStudentExamInfoID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
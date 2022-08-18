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
    public class OnlineExamStudentQuePaperCheckDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExamStudentQuePaperCheckDetailsServiceAccess _OnlineExamStudentQuePaperCheckDetailsServiceAcess = null;
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
        public OnlineExamStudentQuePaperCheckDetailsController()
        {
            _OnlineExamStudentQuePaperCheckDetailsServiceAcess = new OnlineExamStudentQuePaperCheckDetailsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            //OnlineExamViewModel model = new OnlineExamViewModel();
            return View("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/Index.cshtml");
        }

        public ActionResult List(string actionmode)
        {
            try
            {
                OnlineExamStudentQuePaperCheckDetailsViewModel model = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult StudentList(int OnlineExamSubjectGroupScheduleID, int OnlineExamQuestionPaperCheckerID)
        {
            OnlineExamStudentQuePaperCheckDetailsViewModel model = new OnlineExamStudentQuePaperCheckDetailsViewModel();
            model.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID;
            model.OnlineExamQuestionPaperCheckerID = OnlineExamQuestionPaperCheckerID;
            return View("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/StudentList.cshtml", model);
        }
        public ActionResult StudentApplicableList(string actionmode)
        {
            try
            {
                OnlineExamStudentQuePaperCheckDetailsViewModel model = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/StudentApplicableList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewQuestion(int OnlineExamIndStudentExamInfoID, int OnlineExamSubjectGroupScheduleID, int OnlineExamQuestionPaperCheckerID)
        {
            OnlineExamStudentQuePaperCheckDetailsViewModel model = new OnlineExamStudentQuePaperCheckDetailsViewModel();
            model.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
            model.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID;
            model.OnlineExamQuestionPaperCheckerID = OnlineExamQuestionPaperCheckerID;
            return PartialView("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/ViewQuestion.cshtml", model);
        }
        public ActionResult ViewQuestionList(string actionmode)
        {
            try
            {
                OnlineExamStudentQuePaperCheckDetailsViewModel model = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }

                return PartialView("~/Views/OnlineExam/OnlineExamStudentQuePaperCheckDetails/ViewQuestionList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //----------------Marks obtain on each Descriptive question and Save Button ------------------
        public ActionResult MarksObtainInExamination(decimal MarkObtained, int OnlineExamIndQuestionPaperID)
        {
            var errorMessage = string.Empty;
          
            {
                IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = null;
                OnlineExamStudentQuePaperCheckDetails OnlineExamStudentQuePaperCheckDetailsDTO = new OnlineExamStudentQuePaperCheckDetails();
                OnlineExamStudentQuePaperCheckDetailsDTO.ConnectionString = _connectioString;
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndQuestionPaperID = OnlineExamIndQuestionPaperID;
                OnlineExamStudentQuePaperCheckDetailsDTO.MarkObtained = MarkObtained;
                response = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.MarksObtainInExamination(OnlineExamStudentQuePaperCheckDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
//----------------------------for Descriptive Submit button------------------

        public ActionResult OnlineDescriptiveIsCheckedQuestion(int OnlineExamIndStudentExamInfoID, int OnlineExamSubjectGroupScheduleID)
        {
            var errorMessage = string.Empty;

            {
                IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = null;
                OnlineExamStudentQuePaperCheckDetails OnlineExamStudentQuePaperCheckDetailsDTO = new OnlineExamStudentQuePaperCheckDetails();
                OnlineExamStudentQuePaperCheckDetailsDTO.ConnectionString = _connectioString;
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID;
                response = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.OnlineDescriptiveIsCheckedQuestion(OnlineExamStudentQuePaperCheckDetailsDTO);
                if (response.Entity.ErrorCode == 12)
                {
                    string[] arrayList = {"Some Question are Not Checked.", "warning", string.Empty };
                    errorMessage = string.Join(",", arrayList);
                }
                else
                {
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }

            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        //---------------------------for the IsAllChecked Question---------------------------------
        public ActionResult OnlineExamIsAllCheckedQuestion(int OnlineExamQuestionPaperCheckerID, int OnlineExamSubjectGroupScheduleID)
        {
            var errorMessage = string.Empty;

            {
                IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = null;
                OnlineExamStudentQuePaperCheckDetails OnlineExamStudentQuePaperCheckDetailsDTO = new OnlineExamStudentQuePaperCheckDetails();
                OnlineExamStudentQuePaperCheckDetailsDTO.ConnectionString = _connectioString;
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamQuestionPaperCheckerID = OnlineExamQuestionPaperCheckerID;
                OnlineExamStudentQuePaperCheckDetailsDTO.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID;
                response = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.OnlineExamIsAllCheckedQuestion(OnlineExamStudentQuePaperCheckDetailsDTO);
                if (response.Entity.ErrorCode == 13)
                {
                    string[] arrayList = { "Some Question are Not Checked.", "warning", string.Empty };
                    errorMessage = string.Join(",", arrayList);
                }
                else
                {
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }

            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> GetOnlineExamStudentQuePaperCheckDetails(out int TotalRecords)
        {
            OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest = new OnlineExamStudentQuePaperCheckDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = Convert.ToInt32(Session["PersonID"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
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
            List<OnlineExamStudentQuePaperCheckDetailsViewModel> listOnlineExamStudentQuePaperCheckDetailsViewModel = new List<OnlineExamStudentQuePaperCheckDetailsViewModel>();
            List<OnlineExamStudentQuePaperCheckDetails> listOnlineExamStudentQuePaperCheckDetails = new List<OnlineExamStudentQuePaperCheckDetails>();
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollectionResponse = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.GetOnlineExamStudentQuePaperCheckDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamStudentQuePaperCheckDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamStudentQuePaperCheckDetails item in listOnlineExamStudentQuePaperCheckDetails)
                    {
                        OnlineExamStudentQuePaperCheckDetailsViewModel OnlineExamStudentQuePaperCheckDetailsViewModel = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                        OnlineExamStudentQuePaperCheckDetailsViewModel.OnlineExamStudentQuePaperCheckDetailsDTO = item;
                        listOnlineExamStudentQuePaperCheckDetailsViewModel.Add(OnlineExamStudentQuePaperCheckDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamStudentQuePaperCheckDetailsViewModel;
        }
        // -------Student Applicable List-------------
        public IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> GetOnlineExamExaminationStudentApplicableList(out int TotalRecords, int OnlineExamSubjectGroupScheduleID, int OnlineExamQuestionPaperCheckerID)
        {
            OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest = new OnlineExamStudentQuePaperCheckDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(Session["PersonID"]);
            searchRequest.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID ;
            searchRequest.OnlineExamQuestionPaperCheckerID = OnlineExamQuestionPaperCheckerID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.FirstName asc, A.MiddleName asc, A.LastName" ;
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
                    searchRequest.SearchBy = "ExaminationName like '%'";
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
            List<OnlineExamStudentQuePaperCheckDetailsViewModel> listOnlineExamStudentQuePaperCheckDetailsViewModel = new List<OnlineExamStudentQuePaperCheckDetailsViewModel>();
            List<OnlineExamStudentQuePaperCheckDetails> listOnlineExamStudentQuePaperCheckDetails = new List<OnlineExamStudentQuePaperCheckDetails>();
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollectionResponse = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.OnlineExamExaminationStudentApplicableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamStudentQuePaperCheckDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamStudentQuePaperCheckDetails item in listOnlineExamStudentQuePaperCheckDetails)
                    {
                        OnlineExamStudentQuePaperCheckDetailsViewModel OnlineExamStudentQuePaperCheckDetailsViewModel = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                        OnlineExamStudentQuePaperCheckDetailsViewModel.OnlineExamStudentQuePaperCheckDetailsDTO = item;
                        listOnlineExamStudentQuePaperCheckDetailsViewModel.Add(OnlineExamStudentQuePaperCheckDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamStudentQuePaperCheckDetailsViewModel;
        }
        public IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> GetOnlineExamExaminationViewQuestionsList(out int TotalRecords, int OnlineExamIndStudentExamInfoID, int OnlineExamSubjectGroupScheduleID)
        {
            OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest = new OnlineExamStudentQuePaperCheckDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(Session["PersonID"]);
            searchRequest.OnlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
            searchRequest.OnlineExamSubjectGroupScheduleID = OnlineExamSubjectGroupScheduleID;
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
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
            List<OnlineExamStudentQuePaperCheckDetailsViewModel> listOnlineExamStudentQuePaperCheckDetailsViewModel = new List<OnlineExamStudentQuePaperCheckDetailsViewModel>();
            List<OnlineExamStudentQuePaperCheckDetails> listOnlineExamStudentQuePaperCheckDetails = new List<OnlineExamStudentQuePaperCheckDetails>();
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollectionResponse = _OnlineExamStudentQuePaperCheckDetailsServiceAcess.OnlineExamExaminationViewQuestionsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamStudentQuePaperCheckDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamStudentQuePaperCheckDetails item in listOnlineExamStudentQuePaperCheckDetails)
                    {
                        OnlineExamStudentQuePaperCheckDetailsViewModel OnlineExamStudentQuePaperCheckDetailsViewModel = new OnlineExamStudentQuePaperCheckDetailsViewModel();
                        OnlineExamStudentQuePaperCheckDetailsViewModel.OnlineExamStudentQuePaperCheckDetailsDTO = item;
                        listOnlineExamStudentQuePaperCheckDetailsViewModel.Add(OnlineExamStudentQuePaperCheckDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamStudentQuePaperCheckDetailsViewModel;
        }



     

        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ExaminationName,D.Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "D.Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamStudentQuePaperCheckDetails(out TotalRecords);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamQuestionPaperCheckerID), Convert.ToString(c.SubjectGroupID), Convert.ToString(c.SubjectID), Convert.ToString(c.ExaminationName), Convert.ToString(c.SubjectDescription), Convert.ToString(c.OnlineExamSubjectGroupScheduleID),Convert.ToString(c.IsAllChecked),Convert.ToString(c.OnlineExamExaminationCourseApplicableID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        //-----------Student Applicale List--------------------------
        public ActionResult StudentApplicableListAjaxHandler(JQueryDataTableParamModel param, int OnlineExamSubjectGroupScheduleID, int OnlineExamQuestionPaperCheckerID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "D.FirstName " + sortDirection + ", D.MiddleName " + sortDirection + ", D.LastName ";   
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or D.MiddleName Like '%" + param.sSearch + "%' or D.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "D.FirstName " + sortDirection + ", D.MiddleName " + sortDirection + ", D.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or D.MiddleName Like '%" + param.sSearch + "%' or D.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "D.FirstName " + sortDirection + ", D.MiddleName " + sortDirection + ", D.LastName ";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or D.MiddleName Like '%" + param.sSearch + "%' or D.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamExaminationStudentApplicableList(out TotalRecords, OnlineExamSubjectGroupScheduleID,OnlineExamQuestionPaperCheckerID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.StudentName),Convert.ToString(c.FirstName),Convert.ToString(c.MiddleName),Convert.ToString(c.LastName),Convert.ToString(c.OnlineExamIndStudentExamInfoID),Convert.ToString(c.OnlineExamQuestionPaperCheckerID),Convert.ToString(c.OnlineExamSubjectGroupScheduleID),Convert.ToString(c.IsExaminationOver),Convert.ToString(c.StudentID),Convert.ToString(c.IsChecked),Convert.ToString(c.OnlineExamExaminationCourseApplicableID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        //-----------------------Question List--------------------
        public ActionResult ViewQuestionListAjaxHandler(JQueryDataTableParamModel param,int OnlineExamIndStudentExamInfoID ,int OnlineExamSubjectGroupScheduleID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamStudentQuePaperCheckDetailsViewModel> filteredOnlineExam;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "OnlineExamQuestionBankDetailsID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QuestionLableText Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "QuestionLableText";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QuestionLableText Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamExaminationViewQuestionsList(out TotalRecords,OnlineExamIndStudentExamInfoID,OnlineExamSubjectGroupScheduleID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamIndQuestionPaperID),Convert.ToString(c.QuestionLableText),Convert.ToString(c.ImageType),Convert.ToString(c.ImageName),Convert.ToString(c.OnlineExamQuestionBankDetailsID),Convert.ToString(c.DescriptiveAnswer),Convert.ToString(c.AttachedDocument),Convert.ToString(c.MarksForQuestion),Convert.ToString(c.IsAttachmentCompalsary),Convert.ToString(c.MarkObtained)};
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
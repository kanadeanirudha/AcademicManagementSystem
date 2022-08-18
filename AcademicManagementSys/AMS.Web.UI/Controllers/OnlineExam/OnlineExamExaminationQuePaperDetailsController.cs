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
    public class OnlineExamExaminationQuePaperDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExamExaminationQuePaperDetailsServiceAccess _OnlineExamExaminationQuePaperDetailsServiceAcess = null;
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
        public OnlineExamExaminationQuePaperDetailsController()
        {
            _OnlineExamExaminationQuePaperDetailsServiceAcess = new OnlineExamExaminationQuePaperDetailsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            //OnlineExamViewModel model = new OnlineExamViewModel();
            return View("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/Index.cshtml");
        }

        public ActionResult AddQuestion(string PaperDetails)
        {
            OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();

            string[] PaperDetailsSplit = PaperDetails.Split('~');
            model.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(PaperDetailsSplit[0]);
            model.SubjectGroupID = Convert.ToInt32(PaperDetailsSplit[1]);
            model.SubjectID = Convert.ToInt32(PaperDetailsSplit[2]);
            model.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(PaperDetailsSplit[3]);

            List<OnlineExamExaminationQuePaperDetails> QuestionBankMaster = GetListQuestionBankMaster(Convert.ToInt32(PaperDetailsSplit[1]), Convert.ToInt32(PaperDetailsSplit[2]));
            List<SelectListItem> QuestionBankMasterList = new List<SelectListItem>();
            foreach (OnlineExamExaminationQuePaperDetails item in QuestionBankMaster)
            {
                QuestionBankMasterList.Add(new SelectListItem { Text = item.QuestionBankMasterDescription, Value = Convert.ToString(item.OnlineExamQuestionBankMasterID) });
            }
            ViewBag.QuestionBankMasterList = new SelectList(QuestionBankMasterList, "Value", "Text");

            return View("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/AddQuestion.cshtml", model);
        }

        public ActionResult ViewQuestion(string OnlineExamExaminationQuestionPaperID, string SubjectGroupID, string SubjectID, string OnlineExamSubjectGroupScheduleID, string IsFinal)
        {
            OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
            model.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(OnlineExamExaminationQuestionPaperID);
            model.SubjectGroupID = Convert.ToInt32(SubjectGroupID);
            model.SubjectID = Convert.ToInt32(SubjectID);
            model.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(OnlineExamSubjectGroupScheduleID);
            model.IsFinal = Convert.ToBoolean(IsFinal);
            return View("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/ViewQuestion.cshtml", model);
        }
        public ActionResult List(string actionmode)
        {
            try
            {
                OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult QuestionList(string actionmode)
        {
            try
            {
                OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
                if (!string.IsNullOrEmpty(actionmode))
                {
                    TempData["actionmode"] = actionmode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/QuestionList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ViewQuestionList(string IsFinal)
        {
            try
            {
                OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
                model.IsFinal = Convert.ToBoolean(IsFinal);
                    //TempData["actionmode"] = actionmode;
                
                return PartialView("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/ViewQuestionList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        public ActionResult AddQuestionToExamPaper(string QuestionDetail, Int16 MarksForQuestion)
        {
            OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
            try
            {
                var errorMessage = string.Empty;
                string[] PaperDetailsSplit = QuestionDetail.Split('~');

                model.OnlineExamExaminationQuePaperDetailsDTO.ConnectionString = _connectioString;
                model.OnlineExamExaminationQuePaperDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankMasterID = Convert.ToInt32(PaperDetailsSplit[0]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankDetailsID = Convert.ToInt32(PaperDetailsSplit[1]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(PaperDetailsSplit[2]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(PaperDetailsSplit[3]);
                model.OnlineExamExaminationQuePaperDetailsDTO.MarksForQuestion = MarksForQuestion;

                IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = _OnlineExamExaminationQuePaperDetailsServiceAcess.AddQuestionToExamPaper(model.OnlineExamExaminationQuePaperDetailsDTO);
                if (response.Entity.ErrorCode == 26)
                {
                    string[] arrayList = { "Add Question greater than the number of Total Question.", "warning", string.Empty};
                    errorMessage = string.Join(",", arrayList);
                }
                else if (response.Entity.ErrorCode == 30)
                {
                    string[] arrayList = { "Add Question Marks greater than the number of Total Question Marks.", "warning", string.Empty };
                    errorMessage = string.Join(",", arrayList);
                }
                else
                {
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                //return Json(model.OnlineExamExaminationQuePaperDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

    //------Remove Button
        public ActionResult RemoveQuestionFromExamPaper(string QuestionDetail)
        {
            OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
            try
            {
                string[] PaperDetailsSplit = QuestionDetail.Split('~');

                model.OnlineExamExaminationQuePaperDetailsDTO.ConnectionString = _connectioString;
                model.OnlineExamExaminationQuePaperDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                //model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankMasterID = Convert.ToInt32(PaperDetailsSplit[0]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamQuestionBankDetailsID = Convert.ToInt32(PaperDetailsSplit[0]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(PaperDetailsSplit[1]);
                model.OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(PaperDetailsSplit[2]);

                IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = _OnlineExamExaminationQuePaperDetailsServiceAcess.RemoveQuestionFromExamPaper(model.OnlineExamExaminationQuePaperDetailsDTO);
                model.OnlineExamExaminationQuePaperDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                return Json(model.OnlineExamExaminationQuePaperDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        [HttpGet]
        public ActionResult Create(string PaperDetails)
        {
            OnlineExamExaminationQuePaperDetailsViewModel model = new OnlineExamExaminationQuePaperDetailsViewModel();
            string[] PaperDetailsSplit = PaperDetails.Split('~');
            model.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(PaperDetailsSplit[0]);
            model.SubjectGroupID = Convert.ToInt32(PaperDetailsSplit[1]);
            model.SubjectID = Convert.ToInt32(PaperDetailsSplit[2]);

            List<OnlineExamExaminationQuePaperDetails> QuestionBankMaster = GetListQuestionBankMaster(Convert.ToInt32(PaperDetailsSplit[1]), Convert.ToInt32(PaperDetailsSplit[2]));
            List<SelectListItem> QuestionBankMasterList = new List<SelectListItem>();
            foreach (OnlineExamExaminationQuePaperDetails item in QuestionBankMaster)
            {
                QuestionBankMasterList.Add(new SelectListItem { Text = item.QuestionBankMasterDescription, Value = Convert.ToString(item.OnlineExamQuestionBankMasterID) });
            }
            ViewBag.QuestionBankMasterList = new SelectList(QuestionBankMasterList, "Value", "Text");

            return PartialView("~/Views/OnlineExam/OnlineExamExaminationQuePaperDetails/Create.cshtml", model);
        }

        //[HttpPost]
        //public ActionResult Create(OnlineExaminationMasterViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (model != null && model.OnlineExaminationMasterDTO != null)
        //            {
        //                model.OnlineExaminationMasterDTO.ConnectionString = _connectioString;
        //                model.OnlineExaminationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
        //                model.OnlineExaminationMasterDTO.TotalPaperSet= 0;
        //                IBaseEntityResponse<OnlineExaminationMaster> response = _OnlineExaminationMasterServiceAcess.InsertOnlineExaminationMaster(model.OnlineExaminationMasterDTO);
        //                model.OnlineExaminationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
        //            }
        //            return Json(model.OnlineExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    OnlineExaminationMasterViewModel model = new OnlineExaminationMasterViewModel();
        //    model.OnlineExaminationMasterDTO = new OnlineExaminationMaster();
        //    model.OnlineExaminationMasterDTO.ID = ID;
        //    return PartialView("~/Views/OnlineExam/OnlineExaminationMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OnlineExaminationMasterViewModel model)
        //{
        //    if (model.ID > 0)
        //    {
        //        OnlineExaminationMaster OnlineExaminationMasterDTO = new OnlineExaminationMaster();
        //        OnlineExaminationMasterDTO.ConnectionString = _connectioString;
        //        OnlineExaminationMasterDTO.ID = model.ID;
        //        OnlineExaminationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //        IBaseEntityResponse<OnlineExaminationMaster> response = _OnlineExaminationMasterServiceAcess.DeleteOnlineExaminationMaster(OnlineExaminationMasterDTO);
        //        model.OnlineExaminationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //    }
        //    return Json(model.OnlineExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult QuestionPaperFinalSubmit(int OnlineExamExaminationQuestionPaperID)
        {
            var errorMessage = string.Empty;
            if (OnlineExamExaminationQuestionPaperID > 0)
            {
                IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = null;
                OnlineExamExaminationQuePaperDetails OnlineExamExaminationQuePaperDetailsDTO = new OnlineExamExaminationQuePaperDetails();
                OnlineExamExaminationQuePaperDetailsDTO.ConnectionString = _connectioString;
                OnlineExamExaminationQuePaperDetailsDTO.OnlineExamExaminationQuestionPaperID = OnlineExamExaminationQuestionPaperID;
                response = _OnlineExamExaminationQuePaperDetailsServiceAcess.QuestionPaperFinalSubmit(OnlineExamExaminationQuePaperDetailsDTO);
                if (response.Entity.ErrorCode == 25) 
                {
                    string[] arrayList = { "Please Add Question Equal To Total Question Defined In Schedule.", "warning", string.Empty };
                    errorMessage= string.Join(",", arrayList);
                }
                 else if (response.Entity.ErrorCode == 31)
                {
                    string[] arrayList = { "Please Add Question Marks Equal To Total Question Marks Defined In Schedule Not Match.", "warning", string.Empty };
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

        protected List<OnlineExamExaminationQuePaperDetails> GetListQuestionBankMaster(int SubjectGroupID,int SubjectID)
        {
            OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest = new OnlineExamExaminationQuePaperDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectGroupID = SubjectGroupID;
            searchRequest.SubjectID = SubjectID;
            List<OnlineExamExaminationQuePaperDetails> listQuestionBankMaster = new List<OnlineExamExaminationQuePaperDetails>();
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollectionResponse = _OnlineExamExaminationQuePaperDetailsServiceAcess.GetListQuestionBankMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listQuestionBankMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listQuestionBankMaster;
        }

        public IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> GetOnlineExamExaminationQuePaperDetails(out int TotalRecords)
        {
            OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest = new OnlineExamExaminationQuePaperDetailsSearchRequest();
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
            List<OnlineExamExaminationQuePaperDetailsViewModel> listOnlineExamExaminationQuePaperDetailsViewModel = new List<OnlineExamExaminationQuePaperDetailsViewModel>();
            List<OnlineExamExaminationQuePaperDetails> listOnlineExamExaminationQuePaperDetails = new List<OnlineExamExaminationQuePaperDetails>();
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollectionResponse = _OnlineExamExaminationQuePaperDetailsServiceAcess.GetOnlineExamExaminationQuePaperDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamExaminationQuePaperDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamExaminationQuePaperDetails item in listOnlineExamExaminationQuePaperDetails)
                    {
                        OnlineExamExaminationQuePaperDetailsViewModel OnlineExamExaminationQuePaperDetailsViewModel = new OnlineExamExaminationQuePaperDetailsViewModel();
                        OnlineExamExaminationQuePaperDetailsViewModel.OnlineExamExaminationQuePaperDetailsDTO = item;
                        listOnlineExamExaminationQuePaperDetailsViewModel.Add(OnlineExamExaminationQuePaperDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamExaminationQuePaperDetailsViewModel;
        }

        public IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> GetOnlineExamExaminationQuestionsList(out int TotalRecords, int OnlineExamQuestionBankMasterID, int OnlineExamExaminationQuestionPaperID, int OnlineExamSubjectGroupScheduleID)
        {
            OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest = new OnlineExamExaminationQuePaperDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(Session["PersonID"]);
            searchRequest.OnlineExamQuestionBankMasterID = OnlineExamQuestionBankMasterID;
            searchRequest.OnlineExamExaminationQuestionPaperID = OnlineExamExaminationQuestionPaperID;
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
            List<OnlineExamExaminationQuePaperDetailsViewModel> listOnlineExamExaminationQuePaperDetailsViewModel = new List<OnlineExamExaminationQuePaperDetailsViewModel>();
            List<OnlineExamExaminationQuePaperDetails> listOnlineExamExaminationQuePaperDetails = new List<OnlineExamExaminationQuePaperDetails>();
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollectionResponse = _OnlineExamExaminationQuePaperDetailsServiceAcess.OnlineExamExaminationQuestionsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamExaminationQuePaperDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamExaminationQuePaperDetails item in listOnlineExamExaminationQuePaperDetails)
                    {
                        OnlineExamExaminationQuePaperDetailsViewModel OnlineExamExaminationQuePaperDetailsViewModel = new OnlineExamExaminationQuePaperDetailsViewModel();
                        OnlineExamExaminationQuePaperDetailsViewModel.OnlineExamExaminationQuePaperDetailsDTO = item;
                        listOnlineExamExaminationQuePaperDetailsViewModel.Add(OnlineExamExaminationQuePaperDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamExaminationQuePaperDetailsViewModel;
        }

        public IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> GetOnlineExamExaminationViewQuestionsList(out int TotalRecords,int OnlineExamExaminationQuestionPaperID, int OnlineExamSubjectGroupScheduleID)
        {
            OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest = new OnlineExamExaminationQuePaperDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(Session["PersonID"]);
            searchRequest.OnlineExamExaminationQuestionPaperID = OnlineExamExaminationQuestionPaperID;
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
            List<OnlineExamExaminationQuePaperDetailsViewModel> listOnlineExamExaminationQuePaperDetailsViewModel = new List<OnlineExamExaminationQuePaperDetailsViewModel>();
            List<OnlineExamExaminationQuePaperDetails> listOnlineExamExaminationQuePaperDetails = new List<OnlineExamExaminationQuePaperDetails>();
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollectionResponse = _OnlineExamExaminationQuePaperDetailsServiceAcess.OnlineExamExaminationViewQuestionsList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExamExaminationQuePaperDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExamExaminationQuePaperDetails item in listOnlineExamExaminationQuePaperDetails)
                    {
                        OnlineExamExaminationQuePaperDetailsViewModel OnlineExamExaminationQuePaperDetailsViewModel = new OnlineExamExaminationQuePaperDetailsViewModel();
                        OnlineExamExaminationQuePaperDetailsViewModel.OnlineExamExaminationQuePaperDetailsDTO = item;
                        listOnlineExamExaminationQuePaperDetailsViewModel.Add(OnlineExamExaminationQuePaperDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExamExaminationQuePaperDetailsViewModel;
        }


        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> filteredOnlineExam;
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
                        _searchBy = "D.Description Like '%" + param.sSearch + "%' or A.PaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.PaperSet";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "D.Description Like '%" + param.sSearch + "%' or A.PaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOnlineExam = GetOnlineExamExaminationQuePaperDetails(out TotalRecords);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamExaminationQuestionPaperID), Convert.ToString(c.SubjectGroupID), Convert.ToString(c.SubjectID), Convert.ToString(c.ExaminationName), Convert.ToString(c.SubjectDescription), Convert.ToString(c.PaperSet), Convert.ToString(c.OnlineExamSubjectGroupScheduleID),Convert.ToString(c.IsFinal) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuestionListAjaxHandler(JQueryDataTableParamModel param, int OnlineExamQuestionBankMasterID, int OnlineExamExaminationQuestionPaperID, int OnlineExamSubjectGroupScheduleID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> filteredOnlineExam;
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
                        _searchBy = "QuestionLableText Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
            filteredOnlineExam = GetOnlineExamExaminationQuestionsList(out TotalRecords, OnlineExamQuestionBankMasterID, OnlineExamExaminationQuestionPaperID, OnlineExamSubjectGroupScheduleID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamQuestionBankDetailsID), Convert.ToString(c.QuestionLableText), Convert.ToString(c.ImageType), Convert.ToString(c.ImageName), Convert.ToString(c.IsQuestionInImage), Convert.ToString(c.OptionImageList), Convert.ToString(c.OptionTextList), Convert.ToString(c.OnlineExamExaminationQuePaperDetailsID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewQuestionListAjaxHandler(JQueryDataTableParamModel param, int OnlineExamExaminationQuestionPaperID, int OnlineExamSubjectGroupScheduleID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExamExaminationQuePaperDetailsViewModel> filteredOnlineExam;
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
            filteredOnlineExam = GetOnlineExamExaminationViewQuestionsList(out TotalRecords, OnlineExamExaminationQuestionPaperID, OnlineExamSubjectGroupScheduleID);
            var records = filteredOnlineExam.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.OnlineExamQuestionBankDetailsID), Convert.ToString(c.QuestionLableText), Convert.ToString(c.ImageType), Convert.ToString(c.ImageName), Convert.ToString(c.IsQuestionInImage), Convert.ToString(c.OptionImageList), Convert.ToString(c.OptionTextList), Convert.ToString(c.OnlineExamStudentApplicableID), Convert.ToString(c.IsFinal), Convert.ToString(c.MarksForQuestion) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
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
    public class OnlineExaminationQuestionPaperSetMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExaminationQuestionPaperSetMasterServiceAccess _OnlineExaminationQuestionPaperSetMasterServiceAcess = null;
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
        public OnlineExaminationQuestionPaperSetMasterController()
        {
            _OnlineExaminationQuestionPaperSetMasterServiceAcess = new OnlineExaminationQuestionPaperSetMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View("~/Views/OnlineExam/OnlineExaminationQuestionPaperSetMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OnlineExaminationQuestionPaperSetMasterViewModel model = new OnlineExaminationQuestionPaperSetMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExaminationQuestionPaperSetMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int ID, string Exam, int TotalQue)
        {
            OnlineExaminationQuestionPaperSetMasterViewModel model = new OnlineExaminationQuestionPaperSetMasterViewModel();
            model.ApplicableQuestionList = GetApplicableQuestionList(ID);
            model.ExaminationName = Exam.Replace('~',' ');
            model.PaperSetCode = Exam.Replace('~', ' ').Split('-')[1].Split(']')[0].Trim();
            model.OnlineExamExaminationMasterID = ID;
            model.TotalQuestion = TotalQue;
            return PartialView("~/Views/OnlineExam/OnlineExaminationQuestionPaperSetMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExaminationQuestionPaperSetMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OnlineExaminationQuestionPaperSetMasterDTO != null)
                    {
                        model.OnlineExaminationQuestionPaperSetMasterDTO.ConnectionString = _connectioString;
                        model.OnlineExaminationQuestionPaperSetMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> response = _OnlineExaminationQuestionPaperSetMasterServiceAcess.InsertOnlineExaminationQuestionPaperSetMaster(model.OnlineExaminationQuestionPaperSetMasterDTO);
                        model.OnlineExaminationQuestionPaperSetMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OnlineExaminationQuestionPaperSetMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult SpinQuestionList(int ID)
        {
            OnlineExaminationQuestionPaperSetMasterViewModel model = new OnlineExaminationQuestionPaperSetMasterViewModel();
            model.ApplicableQuestionList = GetApplicableQuestionList(ID);
            return PartialView("~/Views/OnlineExam/OnlineExaminationQuestionPaperSetMaster/QuestionList.cshtml", model.ApplicableQuestionList);
        }

        [HttpGet]
        public ActionResult View(int ID, string Exam)
        {
            try
            {
                OnlineExaminationQuestionPaperSetMasterViewModel model = new OnlineExaminationQuestionPaperSetMasterViewModel();
                OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest = new OnlineExaminationQuestionPaperSetMasterSearchRequest();
                searchRequest.ID = ID;
                searchRequest.ConnectionString = _connectioString;
                model.IsViewOnly = true;
                model.ExaminationName = Exam.Replace('~', ' ');
                model.PaperSetCode = Exam.Replace('~', ' ').Split('-')[1].Split(']')[0].Trim();
                IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollectionResponse = _OnlineExaminationQuestionPaperSetMasterServiceAcess.SelectByID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                   model.ApplicableQuestionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
                return PartialView("~/Views/OnlineExam/OnlineExaminationQuestionPaperSetMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public IEnumerable<OnlineExaminationQuestionPaperSetMasterViewModel> GetOnlineExaminationQuestionPaperSetMaster(out int TotalRecords)
        {
            OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest = new OnlineExaminationQuestionPaperSetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = "ExaminationName like '%'";
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
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
            List<OnlineExaminationQuestionPaperSetMasterViewModel> listOnlineExaminationQuestionPaperSetMasterViewModel = new List<OnlineExaminationQuestionPaperSetMasterViewModel>();
            List<OnlineExaminationQuestionPaperSetMaster> listOnlineExaminationQuestionPaperSetMaster = new List<OnlineExaminationQuestionPaperSetMaster>();
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollectionResponse = _OnlineExaminationQuestionPaperSetMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExaminationQuestionPaperSetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExaminationQuestionPaperSetMaster item in listOnlineExaminationQuestionPaperSetMaster)
                    {
                        OnlineExaminationQuestionPaperSetMasterViewModel OnlineExaminationQuestionPaperSetMasterViewModel = new OnlineExaminationQuestionPaperSetMasterViewModel();
                        OnlineExaminationQuestionPaperSetMasterViewModel.OnlineExaminationQuestionPaperSetMasterDTO = item;
                        listOnlineExaminationQuestionPaperSetMasterViewModel.Add(OnlineExaminationQuestionPaperSetMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExaminationQuestionPaperSetMasterViewModel;
        }

        [NonAction] // gets question list applicable to exam and spins records
        public List<OnlineExaminationQuestionPaperSetMaster> GetApplicableQuestionList(int ID)
        {
            List<OnlineExaminationQuestionPaperSetMaster> questionList = new List<OnlineExaminationQuestionPaperSetMaster>();
            OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest = new OnlineExaminationQuestionPaperSetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollectionResponse = _OnlineExaminationQuestionPaperSetMasterServiceAcess.GetOnlineExaminationQuestionPaperSetMasterBySpin(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    questionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return questionList;
        }
        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExaminationQuestionPaperSetMasterViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ExaminationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "ExaminationName like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or PaperSetCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;               
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetOnlineExaminationQuestionPaperSetMaster(out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] {
                                                        Convert.ToString(c.ExaminationName),
                                                        Convert.ToString( c.PaperSetCode), 
                                                        Convert.ToString(c.OnlineExamExaminationMasterID), 
                                                        Convert.ToString(c.ID),
                                                        Convert.ToString(c.TotalQuestion),
    
            };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
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
    public class OnlineExaminationMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IOnlineExaminationMasterServiceAccess _OnlineExaminationMasterServiceAcess = null;
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
        public OnlineExaminationMasterController()
        {
            _OnlineExaminationMasterServiceAcess = new OnlineExaminationMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            return View("~/Views/OnlineExam/OnlineExaminationMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OnlineExaminationMasterViewModel model = new OnlineExaminationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("~/Views/OnlineExam/OnlineExaminationMaster/List.cshtml", model);
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
            OnlineExaminationMasterViewModel model = new OnlineExaminationMasterViewModel();
            model.AcademicSessionList = GetListGeneralSessionMaster();
            model.QuestionTypeList = GetQuestionTypeList();
            return PartialView("~/Views/OnlineExam/OnlineExaminationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OnlineExaminationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OnlineExaminationMasterDTO != null)
                    {
                        model.OnlineExaminationMasterDTO.ConnectionString = _connectioString;
                        model.OnlineExaminationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.OnlineExaminationMasterDTO.TotalPaperSet= 0;
                        IBaseEntityResponse<OnlineExaminationMaster> response = _OnlineExaminationMasterServiceAcess.InsertOnlineExaminationMaster(model.OnlineExaminationMasterDTO);
                        model.OnlineExaminationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OnlineExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
            OnlineExaminationMasterViewModel model = new OnlineExaminationMasterViewModel();
            model.OnlineExaminationMasterDTO = new OnlineExaminationMaster();
            model.OnlineExaminationMasterDTO.ID = ID;
            return PartialView("~/Views/OnlineExam/OnlineExaminationMaster/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(OnlineExaminationMasterViewModel model)
        {
            if (model.ID > 0)
            {
                OnlineExaminationMaster OnlineExaminationMasterDTO = new OnlineExaminationMaster();
                OnlineExaminationMasterDTO.ConnectionString = _connectioString;
                OnlineExaminationMasterDTO.ID = model.ID;
                OnlineExaminationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<OnlineExaminationMaster> response = _OnlineExaminationMasterServiceAcess.DeleteOnlineExaminationMaster(OnlineExaminationMasterDTO);
                model.OnlineExaminationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }
            return Json(model.OnlineExaminationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public IEnumerable<OnlineExaminationMasterViewModel> GetOnlineExaminationMaster(out int TotalRecords)
        {
            OnlineExaminationMasterSearchRequest searchRequest = new OnlineExaminationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
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
            List<OnlineExaminationMasterViewModel> listOnlineExaminationMasterViewModel = new List<OnlineExaminationMasterViewModel>();
            List<OnlineExaminationMaster> listOnlineExaminationMaster = new List<OnlineExaminationMaster>();
            IBaseEntityCollectionResponse<OnlineExaminationMaster> baseEntityCollectionResponse = _OnlineExaminationMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOnlineExaminationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OnlineExaminationMaster item in listOnlineExaminationMaster)
                    {
                        OnlineExaminationMasterViewModel OnlineExaminationMasterViewModel = new OnlineExaminationMasterViewModel();
                        OnlineExaminationMasterViewModel.OnlineExaminationMasterDTO = item;
                        listOnlineExaminationMasterViewModel.Add(OnlineExaminationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOnlineExaminationMasterViewModel;
        }
        
        #endregion

        #region  ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OnlineExaminationMasterViewModel> filteredCountryMaster;
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
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "Purpose";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "Purpose like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "TotalQuestion";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "TotalQuestion like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "TotalMarks";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "TotalMarks like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "TotalTime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "TotalTime like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 5:
                    _sortBy = "TotalPaperSet";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "TotalPaperSet like '%'";
                    }
                    else
                    {
                        _searchBy = "ExaminationName Like '%" + param.sSearch + "%' or Purpose Like '%" + param.sSearch + "%' or TotalQuestion Like '%" + param.sSearch + "%' or TotalMarks Like '%" + param.sSearch + "%' or TotalTime Like '%" + param.sSearch + "%' or TotalPaperSet Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetOnlineExaminationMaster(out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] {
                                                        Convert.ToString(c.ExaminationName),
                                                        Convert.ToString( c.Purpose), 
                                                        Convert.ToString(c.TotalQuestion), 
                                                        Convert.ToString(c.TotalMarks),
                                                        Convert.ToString(c.TotalTime),
                                                        Convert.ToString(c.TotalPaperSet), 
                                                        Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
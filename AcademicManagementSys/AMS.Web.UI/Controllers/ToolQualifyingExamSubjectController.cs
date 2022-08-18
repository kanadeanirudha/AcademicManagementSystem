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
    public class ToolQualifyingExamSubjectController : BaseController
    {
        IToolQualifyingExamSubjectServiceAccess _ToolQualifyingExamSubjectServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public ToolQualifyingExamSubjectController()
        {
            _ToolQualifyingExamSubjectServiceAcess = new ToolQualifyingExamSubjectServiceAccess();

        }

        #region Controller Methods

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string actionMode)
        {
            try
            {
                ToolQualifyingExamSubjectViewModel model = new ToolQualifyingExamSubjectViewModel();
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
        public ActionResult Create(string IDs)
        {
            ToolQualifyingExamSubjectViewModel model = new ToolQualifyingExamSubjectViewModel();
            try
            {
                string[] Array = IDs.Split('~');
                model.QualifyingExamMstID = Convert.ToInt32(Array[0]);
                model.ExamName = Array[1].ToString();
              //  model.ID = Convert.ToInt32(Array[2]);
               // For Subject
                model.ToolQualifyingExamSubjectList = GetListToolQualifyingExamSubject(model.QualifyingExamMstID);
            }
            catch (Exception)
            {

                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolQualifyingExamSubjectViewModel model)
        {
           try 
            { 

            if (ModelState.IsValid)
            {
                if (model != null && model.ToolQualifyingExamSubjectDTO != null)
                {
                    model.ToolQualifyingExamSubjectDTO.ConnectionString = _connectioString;
                    model.ToolQualifyingExamSubjectDTO.QualifyingExamMstID = model.QualifyingExamMstID;
                    if (model.SelectedIDs != null)
                    {
                        model.ToolQualifyingExamSubjectDTO.SelectedIDs = model.SelectedIDs.Replace("&", "And"); ;
                    }
                    else
                        model.ToolQualifyingExamSubjectDTO.SelectedIDs = "";
                    model.ToolQualifyingExamSubjectDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);  //model.CreatedBy;
                    IBaseEntityResponse<ToolQualifyingExamSubject> response = _ToolQualifyingExamSubjectServiceAcess.InsertToolQualifyingExamSubject(model.ToolQualifyingExamSubjectDTO);
                    model.ToolQualifyingExamSubjectDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                // return Content(Boolean.TrueString);
                return Json(model.ToolQualifyingExamSubjectDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Methods

        public IEnumerable<ToolQualifyingExamSubjectViewModel> GetToolQualifyingExamSubject(out int TotalRecords)
        {
            ToolQualifyingExamSubjectSearchRequest searchRequest = new ToolQualifyingExamSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "ExamName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ExamName";
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
            List<ToolQualifyingExamSubjectViewModel> listToolQualifyingExamSubjectViewModel = new List<ToolQualifyingExamSubjectViewModel>();
            List<ToolQualifyingExamSubject> listToolQualifyingExamSubject = new List<ToolQualifyingExamSubject>();
            IBaseEntityCollectionResponse<ToolQualifyingExamSubject> baseEntityCollectionResponse = _ToolQualifyingExamSubjectServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualifyingExamSubject = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualifyingExamSubject item in listToolQualifyingExamSubject)
                    {
                        ToolQualifyingExamSubjectViewModel ToolQualifyingExamSubjectViewModel = new ToolQualifyingExamSubjectViewModel();
                        ToolQualifyingExamSubjectViewModel.ToolQualifyingExamSubjectDTO = item;
                        listToolQualifyingExamSubjectViewModel.Add(ToolQualifyingExamSubjectViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listToolQualifyingExamSubjectViewModel;
        }
        protected List<ToolQualifyingExamSubject> GetListToolQualifyingExamSubject(int QualifyingExamMstID)
        {
            ToolQualifyingExamSubjectSearchRequest searchRequest = new ToolQualifyingExamSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.QualifyingExamMstID = QualifyingExamMstID;
            List<ToolQualifyingExamSubject> OrganisationSubjectTypeList = new List<ToolQualifyingExamSubject>();
            IBaseEntityCollectionResponse<ToolQualifyingExamSubject> baseEntityCollectionResponse = _ToolQualifyingExamSubjectServiceAcess.GetByQualifyingExamSubjectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubjectTypeList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubjectTypeList;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
           
            IEnumerable<ToolQualifyingExamSubjectViewModel> filteredRegionMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ExamName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ExamName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
              
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredRegionMaster = GetToolQualifyingExamSubject(out TotalRecords);               
            var displayedPosts = filteredRegionMaster.Skip(0).Take(param.iDisplayLength);


            var result = from c in displayedPosts select new[] { c.ExamName.ToString(), Convert.ToString(c.StatusFlag), Convert.ToString(c.QualifyingExamMstID + "~" + c.ExamName.Replace(" ", "`")) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
           JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
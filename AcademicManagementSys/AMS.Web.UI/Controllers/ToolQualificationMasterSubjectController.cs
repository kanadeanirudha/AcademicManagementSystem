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
    public class ToolQualificationMasterSubjectController : BaseController
    {
        IToolQualificationMasterSubjectServiceAccess _ToolQualificationMasterSubjectServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public ToolQualificationMasterSubjectController()
        {
            _ToolQualificationMasterSubjectServiceAcess = new ToolQualificationMasterSubjectServiceAccess();

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
                ToolQualificationMasterSubjectViewModel model = new ToolQualificationMasterSubjectViewModel();
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
            ToolQualificationMasterSubjectViewModel model = new ToolQualificationMasterSubjectViewModel();
            try
            {
                string[] Array = IDs.Split('~');
                model.QualificationMstID = Convert.ToInt32(Array[0]);
                model.QualificationName = Array[1].ToString().Replace('`',' ');
                //  model.ID = Convert.ToInt32(Array[2]);
                // For Subject
                model.ToolQualificationMasterSubjectList = GetListToolQualificationMasterSubject(model.QualificationMstID);
            }
            catch (Exception)
            {

                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolQualificationMasterSubjectViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (model != null && model.ToolQualificationMasterSubjectDTO != null)
                    {
                        model.ToolQualificationMasterSubjectDTO.ConnectionString = _connectioString;
                        model.ToolQualificationMasterSubjectDTO.QualificationMstID = model.QualificationMstID;
                        if (model.SelectedIDs != null)
                        {
                            model.ToolQualificationMasterSubjectDTO.SelectedIDs = model.SelectedIDs.Replace("&", "And"); ;
                        }
                        else
                            model.ToolQualificationMasterSubjectDTO.SelectedIDs = "";
                        model.ToolQualificationMasterSubjectDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);  //model.CreatedBy;
                        IBaseEntityResponse<ToolQualificationMasterSubject> response = _ToolQualificationMasterSubjectServiceAcess.InsertToolQualificationMasterSubject(model.ToolQualificationMasterSubjectDTO);
                        model.ToolQualificationMasterSubjectDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    // return Content(Boolean.TrueString);
                    return Json(model.ToolQualificationMasterSubjectDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<ToolQualificationMasterSubjectViewModel> GetToolQualificationMasterSubject(out int TotalRecords)
        {
            ToolQualificationMasterSubjectSearchRequest searchRequest = new ToolQualificationMasterSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "QualificationName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "QualificationName";
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
            List<ToolQualificationMasterSubjectViewModel> listToolQualificationMasterSubjectViewModel = new List<ToolQualificationMasterSubjectViewModel>();
            List<ToolQualificationMasterSubject> listToolQualificationMasterSubject = new List<ToolQualificationMasterSubject>();
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> baseEntityCollectionResponse = _ToolQualificationMasterSubjectServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualificationMasterSubject = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualificationMasterSubject item in listToolQualificationMasterSubject)
                    {
                        ToolQualificationMasterSubjectViewModel ToolQualificationMasterSubjectViewModel = new ToolQualificationMasterSubjectViewModel();
                        ToolQualificationMasterSubjectViewModel.ToolQualificationMasterSubjectDTO = item;
                        listToolQualificationMasterSubjectViewModel.Add(ToolQualificationMasterSubjectViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listToolQualificationMasterSubjectViewModel;
        }
        protected List<ToolQualificationMasterSubject> GetListToolQualificationMasterSubject(int QualificationMstID)
        {
            ToolQualificationMasterSubjectSearchRequest searchRequest = new ToolQualificationMasterSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.QualificationMstID = QualificationMstID;
            List<ToolQualificationMasterSubject> OrganisationSubjectTypeList = new List<ToolQualificationMasterSubject>();
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> baseEntityCollectionResponse = _ToolQualificationMasterSubjectServiceAcess.GetByQualificationMasterSubjectList(searchRequest);
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

            IEnumerable<ToolQualificationMasterSubjectViewModel> filteredRegionMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "QualificationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "QualificationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
                    _sortDirection = sortDirection;
                    _rowLength = param.iDisplayLength;
                    _startRow = param.iDisplayStart;
                    filteredRegionMaster = GetToolQualificationMasterSubject(out TotalRecords);
                    var displayedPosts = filteredRegionMaster.Skip(0).Take(param.iDisplayLength);


                    var result = from c in displayedPosts select new[] { c.QualificationName.ToString(), Convert.ToString(c.StatusFlag), Convert.ToString(c.QualificationMstID + "~" + c.QualificationName.Replace(" ","`")) };
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

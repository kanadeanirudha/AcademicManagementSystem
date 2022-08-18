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
    public class ToolQualifyingExamMasterController : BaseController
    {
        IToolQualifyingExamMasterServiceAccess _ToolQualifyingExamMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public ToolQualifyingExamMasterController()
        {
            _ToolQualifyingExamMasterServiceAcess = new ToolQualifyingExamMasterServiceAccess();

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
                ToolQualifyingExamMasterViewModel model = new ToolQualifyingExamMasterViewModel();
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
            ToolQualifyingExamMasterViewModel model = new ToolQualifyingExamMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolQualifyingExamMasterViewModel model)
        {
           try
            { 

            if (ModelState.IsValid)
            {
                if (model != null && model.ToolQualifyingExamMasterDTO != null)
                {
                    model.ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
                    model.ToolQualifyingExamMasterDTO.ExamName = model.ExamName;

                    model.ToolQualifyingExamMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);  //model.CreatedBy;
                    IBaseEntityResponse<ToolQualifyingExamMaster> response = _ToolQualifyingExamMasterServiceAcess.InsertToolQualifyingExamMaster(model.ToolQualifyingExamMasterDTO);
                    model.ToolQualifyingExamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                // return Content(Boolean.TrueString);
                return Json(model.ToolQualifyingExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {

            ToolQualifyingExamMasterViewModel model = new ToolQualifyingExamMasterViewModel();
            try
            {
                model.ToolQualifyingExamMasterDTO = new ToolQualifyingExamMaster();
                model.ToolQualifyingExamMasterDTO.ID = id;
                model.ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ToolQualifyingExamMaster> response = _ToolQualifyingExamMasterServiceAcess.SelectByID(model.ToolQualifyingExamMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.ToolQualifyingExamMasterDTO.ID = response.Entity.ID;
                    model.ToolQualifyingExamMasterDTO.ExamName = response.Entity.ExamName;
                   
                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(ToolQualifyingExamMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.ToolQualifyingExamMasterDTO != null)
                    {
                        if (model != null && model.ToolQualifyingExamMasterDTO != null)
                        {
                            model.ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
                            model.ToolQualifyingExamMasterDTO.ExamName = model.ExamName;
                            model.ToolQualifyingExamMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                            IBaseEntityResponse<ToolQualifyingExamMaster> response = _ToolQualifyingExamMasterServiceAcess.UpdateToolQualifyingExamMaster(model.ToolQualifyingExamMasterDTO);
                            model.ToolQualifyingExamMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }

                    return Json(model.ToolQualifyingExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    ToolQualifyingExamMasterViewModel model = new ToolQualifyingExamMasterViewModel();
        //    model.ToolQualifyingExamMasterDTO = new ToolQualifyingExamMaster();
        //    model.ToolQualifyingExamMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(ToolQualifyingExamMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            ToolQualifyingExamMaster ToolQualifyingExamMasterDTO = new ToolQualifyingExamMaster();
        //            ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
        //            ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
        //            ToolQualifyingExamMasterDTO.ID = model.ID;
        //            ToolQualifyingExamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<ToolQualifyingExamMaster> response = _ToolQualifyingExamMasterServiceAcess.DeleteToolQualifyingExamMaster(ToolQualifyingExamMasterDTO);
        //            model.ToolQualifyingExamMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.ToolQualifyingExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            ToolQualifyingExamMasterViewModel model = new ToolQualifyingExamMasterViewModel();

            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    ToolQualifyingExamMaster ToolQualifyingExamMasterDTO = new ToolQualifyingExamMaster();
                    ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
                    ToolQualifyingExamMasterDTO.ConnectionString = _connectioString;
                    ToolQualifyingExamMasterDTO.ID = ID;
                    ToolQualifyingExamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<ToolQualifyingExamMaster> response = _ToolQualifyingExamMasterServiceAcess.DeleteToolQualifyingExamMaster(ToolQualifyingExamMasterDTO);
                    model.ToolQualifyingExamMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.ToolQualifyingExamMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }

        #endregion

        #region Methods

        public IEnumerable<ToolQualifyingExamMasterViewModel> GetToolQualifyingExamMaster(out int TotalRecords)
        {
            ToolQualifyingExamMasterSearchRequest searchRequest = new ToolQualifyingExamMasterSearchRequest();
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
            List<ToolQualifyingExamMasterViewModel> listToolQualifyingExamMasterViewModel = new List<ToolQualifyingExamMasterViewModel>();
            List<ToolQualifyingExamMaster> listToolQualifyingExamMaster = new List<ToolQualifyingExamMaster>();
            IBaseEntityCollectionResponse<ToolQualifyingExamMaster> baseEntityCollectionResponse = _ToolQualifyingExamMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualifyingExamMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualifyingExamMaster item in listToolQualifyingExamMaster)
                    {
                        ToolQualifyingExamMasterViewModel ToolQualifyingExamMasterViewModel = new ToolQualifyingExamMasterViewModel();
                        ToolQualifyingExamMasterViewModel.ToolQualifyingExamMasterDTO = item;
                        listToolQualifyingExamMasterViewModel.Add(ToolQualifyingExamMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listToolQualifyingExamMasterViewModel;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            
            IEnumerable<ToolQualifyingExamMasterViewModel> filteredRegionMaster;
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
           
                filteredRegionMaster = GetToolQualifyingExamMaster(out TotalRecords);                 
            var displayedPosts = filteredRegionMaster.Skip(0).Take(param.iDisplayLength);


            var result = from c in displayedPosts select new[] { c.ExamName.ToString(), Convert.ToString(c.ID) };
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
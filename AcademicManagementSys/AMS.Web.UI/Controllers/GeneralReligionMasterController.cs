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
    public class GeneralReligionMasterController :BaseController
    {
        IGeneralReligionMasterServiceAccess _languageMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralReligionMasterController()
        {
            _languageMasterServiceAcess = new GeneralReligionMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
           try
            {
            GeneralReligionMasterViewModel model = new GeneralReligionMasterViewModel();
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
            GeneralReligionMasterViewModel model = new GeneralReligionMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralReligionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralReligionMasterDTO != null)
                    {
                        model.GeneralReligionMasterDTO.ConnectionString = _connectioString;
                        model.GeneralReligionMasterDTO.Description = model.Description;
                        model.GeneralReligionMasterDTO.CreatedBy =Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralReligionMaster> response = _languageMasterServiceAcess.InsertGeneralReligionMaster(model.GeneralReligionMasterDTO);
                        model.GeneralReligionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                   return Json(model.GeneralReligionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            GeneralReligionMasterViewModel model = new GeneralReligionMasterViewModel();
            model.GeneralReligionMasterDTO = new GeneralReligionMaster();
            model.GeneralReligionMasterDTO.ID = ID;
            model.GeneralReligionMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralReligionMaster> response = _languageMasterServiceAcess.SelectByID(model.GeneralReligionMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralReligionMasterDTO.ID = response.Entity.ID;
                model.GeneralReligionMasterDTO.Description = response.Entity.Description;
                model.GeneralReligionMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralReligionMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralReligionMasterDTO != null)
                    {
                        if (model != null && model.GeneralReligionMasterDTO != null)
                        {
                            model.GeneralReligionMasterDTO.ConnectionString = _connectioString;
                            model.GeneralReligionMasterDTO.Description = model.Description;
                            model.GeneralReligionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                            IBaseEntityResponse<GeneralReligionMaster> response = _languageMasterServiceAcess.UpdateGeneralReligionMaster(model.GeneralReligionMasterDTO);
                            model.GeneralReligionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                   return Json(model.GeneralReligionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    GeneralReligionMasterViewModel model = new GeneralReligionMasterViewModel();
        //    model.GeneralReligionMasterDTO = new GeneralReligionMaster();
        //    model.GeneralReligionMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralReligionMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.GeneralReligionMasterDTO != null)
        //            {
        //            GeneralReligionMaster GeneralReligionMasterDTO = new GeneralReligionMaster();
        //            GeneralReligionMasterDTO.ConnectionString = _connectioString;
        //            GeneralReligionMasterDTO.ID = model.ID;
        //            GeneralReligionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralReligionMaster> response = _languageMasterServiceAcess.DeleteGeneralReligionMaster(GeneralReligionMasterDTO);
        //            model.GeneralReligionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.GeneralReligionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
            
        //     catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            GeneralReligionMasterViewModel model = new GeneralReligionMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    
                        GeneralReligionMaster GeneralReligionMasterDTO = new GeneralReligionMaster();
                        GeneralReligionMasterDTO.ConnectionString = _connectioString;
                        GeneralReligionMasterDTO.ID = ID;
                        GeneralReligionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralReligionMaster> response = _languageMasterServiceAcess.DeleteGeneralReligionMaster(GeneralReligionMasterDTO);
                        model.GeneralReligionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                    
                    return Json(model.GeneralReligionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
       
        // Non-Action Methods
        #region Methods
        public IEnumerable<GeneralReligionMasterViewModel> GetGeneralReligionMasterDetails(out int TotalRecords)
        {
            GeneralReligionMasterSearchRequest searchRequest = new GeneralReligionMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<GeneralReligionMasterViewModel> listGeneralReligionMasterViewModel = new List<GeneralReligionMasterViewModel>();
            List<GeneralReligionMaster> listGeneralReligionMaster = new List<GeneralReligionMaster>();
            IBaseEntityCollectionResponse<GeneralReligionMaster> baseEntityCollectionResponse = _languageMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralReligionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralReligionMaster item in listGeneralReligionMaster)
                    {
                        GeneralReligionMasterViewModel languageMasterViewModel = new GeneralReligionMasterViewModel();
                        languageMasterViewModel.GeneralReligionMasterDTO = item;
                        listGeneralReligionMasterViewModel.Add(languageMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralReligionMasterViewModel;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
     
            IEnumerable<GeneralReligionMasterViewModel> filteredGeneralReligionMasterViewModel;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralReligionMasterViewModel = GetGeneralReligionMasterDetails(out TotalRecords);
            var records = filteredGeneralReligionMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), Convert.ToString(c.ID),c.IsUserDefined.ToString() };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}



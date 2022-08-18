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
    public class GeneralLanguageMasterController : BaseController
    {
         IGeneralLanguageMasterServiceAccess _languageMasterServiceAcess = null;
         private readonly ILogger _logException;
         ActionModeEnum actionModeEnum;
         string _actionMode = string.Empty;
         string _sortBy = string.Empty;
         string _searchBy = string.Empty;
         string _sortDirection = string.Empty;
         int _startRow;
         int _rowLength;
         private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralLanguageMasterController()
        {
            _languageMasterServiceAcess = new GeneralLanguageMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
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
            GeneralLanguageMasterViewModel model = new GeneralLanguageMasterViewModel();
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
            GeneralLanguageMasterViewModel model = new GeneralLanguageMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralLanguageMasterViewModel model)
        {
             try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralLanguageMasterDTO != null)
                {
                    model.GeneralLanguageMasterDTO.ConnectionString = _connectioString;
                    model.GeneralLanguageMasterDTO.LanguageName = model.LanguageName;
                    model.GeneralLanguageMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralLanguageMaster> response = _languageMasterServiceAcess.InsertGeneralLanguageMaster(model.GeneralLanguageMasterDTO);
                    model.GeneralLanguageMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.GeneralLanguageMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            GeneralLanguageMasterViewModel model = new GeneralLanguageMasterViewModel();
            model.GeneralLanguageMasterDTO = new GeneralLanguageMaster();
            model.GeneralLanguageMasterDTO.ID = ID;
            model.GeneralLanguageMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralLanguageMaster> response = _languageMasterServiceAcess.SelectByID(model.GeneralLanguageMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralLanguageMasterDTO.ID = response.Entity.ID;
                model.GeneralLanguageMasterDTO.LanguageName = response.Entity.LanguageName;
                model.GeneralLanguageMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralLanguageMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralLanguageMasterDTO != null)
                {
                    if (model != null && model.GeneralLanguageMasterDTO != null)
                    {
                        model.GeneralLanguageMasterDTO.ConnectionString = _connectioString;
                        model.GeneralLanguageMasterDTO.LanguageName = model.LanguageName;
                        model.GeneralLanguageMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralLanguageMaster> response = _languageMasterServiceAcess.UpdateGeneralLanguageMaster(model.GeneralLanguageMasterDTO);
                        model.GeneralLanguageMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralLanguageMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralLanguageMasterViewModel model = new GeneralLanguageMasterViewModel();
        //    model.GeneralLanguageMasterDTO = new GeneralLanguageMaster();
        //    model.GeneralLanguageMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralLanguageMasterViewModel model)
        //{
        //   try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            if (model.ID > 0)
        //            {
        //                GeneralLanguageMaster GeneralLanguageMasterDTO = new GeneralLanguageMaster();
        //                GeneralLanguageMasterDTO.ConnectionString = _connectioString;
        //                GeneralLanguageMasterDTO.ID = model.ID;
        //                GeneralLanguageMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<GeneralLanguageMaster> response = _languageMasterServiceAcess.DeleteGeneralLanguageMaster(GeneralLanguageMasterDTO);
        //                model.GeneralLanguageMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.GeneralLanguageMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
        //   catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        
        public ActionResult Delete(int ID)
        {
            GeneralLanguageMasterViewModel model = new GeneralLanguageMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                    if (ID > 0)
                    {
                        GeneralLanguageMaster GeneralLanguageMasterDTO = new GeneralLanguageMaster();
                        GeneralLanguageMasterDTO.ConnectionString = _connectioString;
                        GeneralLanguageMasterDTO.ID = ID;
                        GeneralLanguageMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralLanguageMaster> response = _languageMasterServiceAcess.DeleteGeneralLanguageMaster(GeneralLanguageMasterDTO);
                        model.GeneralLanguageMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralLanguageMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion
       
        // Non-Action Methods
        #region Methods
        public IEnumerable<GeneralLanguageMasterViewModel> GetGeneralLanguageMasterDetails(out int TotalRecords)
        {
            GeneralLanguageMasterSearchRequest searchRequest = new GeneralLanguageMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update 
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
            List<GeneralLanguageMasterViewModel> listGeneralLanguageMasterViewModel = new List<GeneralLanguageMasterViewModel>();
            List<GeneralLanguageMaster> listGeneralLanguageMaster = new List<GeneralLanguageMaster>();
            IBaseEntityCollectionResponse<GeneralLanguageMaster> baseEntityCollectionResponse = _languageMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLanguageMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralLanguageMaster item in listGeneralLanguageMaster)
                    {
                        GeneralLanguageMasterViewModel languageMasterViewModel = new GeneralLanguageMasterViewModel();
                        languageMasterViewModel.GeneralLanguageMasterDTO = item;
                        listGeneralLanguageMasterViewModel.Add(languageMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralLanguageMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
    
            IEnumerable<GeneralLanguageMasterViewModel> filteredGeneralLanguageMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LanguageName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LanguageName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralLanguageMaster = GetGeneralLanguageMasterDetails(out TotalRecords);
            var displayedPosts = filteredGeneralLanguageMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.LanguageName.ToString(), Convert.ToString(c.ID), c.IsUserDefined.ToString() };
           
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}



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
    public class GeneralCasteMasterController : BaseController
    {
        IGeneralCasteMasterServiceAccess _generalCasteMasterServiceAcess = null;
        private readonly ILogger _logException;
        IGeneralCasteMasterBaseViewModel _generalCasteMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _Category = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCasteMasterController()
        {
            _generalCasteMasterServiceAcess = new GeneralCasteMasterServiceAccess();
            _generalCasteMasterBaseViewModel = new GeneralCasteMasterBaseViewModel();
        }

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
            GeneralCasteMasterViewModel model = new GeneralCasteMasterViewModel();
            if (!string.IsNullOrEmpty(actionMode ))
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
        public ActionResult Create(string Category)
        {            
            GeneralCasteMasterViewModel model = new GeneralCasteMasterViewModel();
            try
            {
                List<GeneralCategoryMaster> GeneralCategoryMasterList = GetListGeneralCategoryMaster();
                List<SelectListItem> GeneralCategoryMaster = new List<SelectListItem>();
                foreach (GeneralCategoryMaster item in GeneralCategoryMasterList)
                {
                    GeneralCategoryMaster.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCategoryMaster = new SelectList(GeneralCategoryMaster, "Value", "Text");

            }
            catch (Exception)
            {
                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralCasteMasterViewModel model)
        {
             try
            { 
            //if (ModelState.IsValid)
            //{
                if (model != null && model.GeneralCasteMasterDTO != null)
                {
                    model.GeneralCasteMasterDTO.ConnectionString = _connectioString;
                    model.GeneralCasteMasterDTO.CategoryID = Convert.ToInt32(model.SelectedCategoryID); 
                    model.GeneralCasteMasterDTO.Description = model.Description;
                    model.GeneralCasteMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralCasteMaster> response = _generalCasteMasterServiceAcess.InsertGeneralCasteMaster(model.GeneralCasteMasterDTO);
                    model.GeneralCasteMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.GeneralCasteMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }                
            //}
            else
            {
                return Json("Please review your form");
            }
        }

          catch (Exception)
           {
               throw;
           }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralCasteMasterViewModel model = new GeneralCasteMasterViewModel();
            try
            {
                List<GeneralCategoryMaster> GeneralCategoryMasterList = GetListGeneralCategoryMaster();
                List<SelectListItem> GeneralCategoryMaster = new List<SelectListItem>();
                foreach (GeneralCategoryMaster item in GeneralCategoryMasterList)
                {
                    GeneralCategoryMaster.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                }
                model.GeneralCasteMasterDTO = new GeneralCasteMaster();
                model.GeneralCasteMasterDTO.ID = id;
                model.GeneralCasteMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralCasteMaster> response = _generalCasteMasterServiceAcess.SelectByID(model.GeneralCasteMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralCasteMasterDTO.ID = response.Entity.ID;
                    model.GeneralCasteMasterDTO.IsUserDefined= response.Entity.IsUserDefined;
                    model.GeneralCasteMasterDTO.Description = response.Entity.Description;
                    ViewBag.GeneralCategoryMaster = new SelectList(GeneralCategoryMaster, "Value", "Text", response.Entity.CategoryID.ToString());

                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralCasteMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralCasteMasterDTO != null)
                    {
                        if (model != null && model.GeneralCasteMasterDTO != null)
                        {
                            model.GeneralCasteMasterDTO.ConnectionString = _connectioString;
                            model.GeneralCasteMasterDTO.Description = model.Description;
                            model.GeneralCasteMasterDTO.CategoryID = Convert.ToInt32(model.SelectedCategoryID);
                            model.GeneralCasteMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralCasteMaster> response = _generalCasteMasterServiceAcess.UpdateGeneralCasteMaster(model.GeneralCasteMasterDTO);
                            model.GeneralCasteMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.GeneralCasteMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;

            }

        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    GeneralCasteMasterViewModel model = new GeneralCasteMasterViewModel();
        //    model.GeneralCasteMasterDTO = new GeneralCasteMaster();
        //    model.GeneralCasteMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralCasteMasterViewModel model)
        //{
        //    try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralCasteMaster orgStreamMasterDTO = new GeneralCasteMaster();
        //            orgStreamMasterDTO.ConnectionString = _connectioString;
        //            orgStreamMasterDTO.ID = model.ID;
        //            orgStreamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralCasteMaster> response = _generalCasteMasterServiceAcess.DeleteGeneralCasteMaster(orgStreamMasterDTO);
        //            model.GeneralCasteMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.GeneralCasteMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }

        //}

        
        public ActionResult Delete(int ID)
        {
            GeneralCasteMasterViewModel model = new GeneralCasteMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                    if (ID > 0)
                    {
                        GeneralCasteMaster orgStreamMasterDTO = new GeneralCasteMaster();
                        orgStreamMasterDTO.ConnectionString = _connectioString;
                        orgStreamMasterDTO.ID = ID;
                        orgStreamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCasteMaster> response = _generalCasteMasterServiceAcess.DeleteGeneralCasteMaster(orgStreamMasterDTO);
                        model.GeneralCasteMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralCasteMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}

            }
            catch (Exception)
            {
                throw;

            }

        }
        #endregion

        //  Non-Action Method
       #region Methods
        public IEnumerable<GeneralCasteMasterViewModel> GetGeneralCasteMaster(out int TotalRecords)
        {
            GeneralCasteMasterSearchRequest searchRequest = new GeneralCasteMasterSearchRequest();
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
            List<GeneralCasteMasterViewModel> listGeneralCasteMasterViewModel = new List<GeneralCasteMasterViewModel>();
            List<GeneralCasteMaster> listGeneralCasteMaster = new List<GeneralCasteMaster>();
            IBaseEntityCollectionResponse<GeneralCasteMaster> baseEntityCollectionResponse = _generalCasteMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCasteMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCasteMaster item in listGeneralCasteMaster)
                    {
                        GeneralCasteMasterViewModel GeneralCasteMasterViewModel = new GeneralCasteMasterViewModel();
                        GeneralCasteMasterViewModel.GeneralCasteMasterDTO = item;
                        listGeneralCasteMasterViewModel.Add(GeneralCasteMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCasteMasterViewModel;
        }
        #endregion    
     
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            IEnumerable<GeneralCasteMasterViewModel> filteredGeneralCasteMaster;

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
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CategoryName Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CategoryName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CategoryName Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralCasteMaster = GetGeneralCasteMaster(out TotalRecords);
            var records = filteredGeneralCasteMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.CategoryName.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}












      
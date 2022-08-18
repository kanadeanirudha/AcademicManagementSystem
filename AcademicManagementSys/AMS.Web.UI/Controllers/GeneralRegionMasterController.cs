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
    public class GeneralRegionMasterController : BaseController
    {
        IGeneralRegionMasterServiceAccess _generalRegionMasterServiceAcess = null;
        private readonly ILogger _logException;
        GeneralRegionMasterBaseViewModel _generalRegionMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralRegionMasterController()
        {
            _generalRegionMasterServiceAcess = new GeneralRegionMasterServiceAccess();
            _generalRegionMasterBaseViewModel = new GeneralRegionMasterBaseViewModel();           
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
            GeneralRegionMasterViewModel model = new GeneralRegionMasterViewModel();
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
        public ActionResult Create(string Division)
        {
            GeneralRegionMasterViewModel model = new GeneralRegionMasterViewModel();
            try
            {
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> orgDivisionMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    orgDivisionMaster.Add(new SelectListItem { Text = item.CountryName, Value = (item.ID + "~" + item.ContryCode).ToString().Trim() });
                }
                ViewBag.GenNationalityMaster = new SelectList(orgDivisionMaster, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralRegionMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralRegionMasterDTO != null)
                {
                    model.GeneralRegionMasterDTO.ConnectionString = _connectioString;
                    model.GeneralRegionMasterDTO.RegionName = model.RegionName;
                    model.GeneralRegionMasterDTO.CountryID =Convert.ToInt32(model.SelectedCountryID);
                    model.GeneralRegionMasterDTO.CountryCode = model.CountryCode;
                    model.GeneralRegionMasterDTO.ShortName = model.ShortName;
                    model.GeneralRegionMasterDTO.DefaultFlag = model.DefaultFlag;
                    model.GeneralRegionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); 
                    IBaseEntityResponse<GeneralRegionMaster> response = _generalRegionMasterServiceAcess.InsertGeneralRegionMaster(model.GeneralRegionMasterDTO);
                    model.GeneralRegionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.GeneralRegionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            GeneralRegionMasterViewModel model = new GeneralRegionMasterViewModel();
            try
            {
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = (item.ID + "~" + item.ContryCode).ToString().Trim() });
                }
                model.GeneralRegionMasterDTO = new GeneralRegionMaster();
                model.GeneralRegionMasterDTO.ID = id;
                model.GeneralRegionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralRegionMaster> response = _generalRegionMasterServiceAcess.SelectByID(model.GeneralRegionMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralRegionMasterDTO.ID = response.Entity.ID;
                    model.GeneralRegionMasterDTO.RegionName = response.Entity.RegionName;
                    model.GeneralRegionMasterDTO.ShortName = response.Entity.ShortName;
                    model.GeneralRegionMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    model.GeneralRegionMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.CountryCode = response.Entity.CountryID + "~" + response.Entity.CountryCode;//3007~INDI
                    model.GeneralRegionMasterDTO.CreatedBy = response.Entity.CreatedBy;
                    ViewBag.GeneralCountryMaster = new SelectList(GeneralCountryMaster, "Value", "Text", (model.CountryCode).ToString().Trim());

                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralRegionMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralRegionMasterDTO != null)
                {
                    if (model != null && model.GeneralRegionMasterDTO != null)
                    {
                        model.GeneralRegionMasterDTO.ConnectionString = _connectioString;
                        model.GeneralRegionMasterDTO.RegionName = model.RegionName;
                        model.GeneralRegionMasterDTO.CountryID = Convert.ToInt32(model.SelectedCountryID);
                        model.GeneralRegionMasterDTO.CountryCode = model.CountryCode;
                        model.GeneralRegionMasterDTO.ShortName = model.ShortName;
                        model.GeneralRegionMasterDTO.DefaultFlag = model.DefaultFlag;
                
                        model.GeneralRegionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]); 
                        IBaseEntityResponse<GeneralRegionMaster> response = _generalRegionMasterServiceAcess.UpdateGeneralRegionMaster(model.GeneralRegionMasterDTO);
                        model.GeneralRegionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralRegionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // [HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    GeneralRegionMasterViewModel model = new GeneralRegionMasterViewModel();
        //    model.GeneralRegionMasterDTO = new GeneralRegionMaster();
        //    model.GeneralRegionMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralRegionMasterViewModel model)
        //{
        //    try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralRegionMaster generalRegionMaster = new GeneralRegionMaster();
        //            generalRegionMaster.ConnectionString = _connectioString;
        //            generalRegionMaster.ID = model.ID;
        //            generalRegionMaster.DeletedBy = Convert.ToInt32(Session["UserID"]); 
        //            IBaseEntityResponse<GeneralRegionMaster> response = _generalRegionMasterServiceAcess.DeleteGeneralRegionMaster(generalRegionMaster);
        //            model.GeneralRegionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.GeneralRegionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        public ActionResult Delete(int ID)
        {
            GeneralRegionMasterViewModel model = new GeneralRegionMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        GeneralRegionMaster generalRegionMaster = new GeneralRegionMaster();
                        generalRegionMaster.ConnectionString = _connectioString;
                        generalRegionMaster.ID = ID;
                        generalRegionMaster.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralRegionMaster> response = _generalRegionMasterServiceAcess.DeleteGeneralRegionMaster(generalRegionMaster);
                        model.GeneralRegionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralRegionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralRegionMasterViewModel> GetGeneralRegionMaster(out int TotalRecords)
        {
            GeneralRegionMasterSearchRequest searchRequest = new GeneralRegionMasterSearchRequest();
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
            List<GeneralRegionMasterViewModel> listGeneralRegionMasterViewModel = new List<GeneralRegionMasterViewModel>();
            List<GeneralRegionMaster> listGeneralRegionMaster = new List<GeneralRegionMaster>();
            IBaseEntityCollectionResponse<GeneralRegionMaster> baseEntityCollectionResponse = _generalRegionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRegionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralRegionMaster item in listGeneralRegionMaster)
                    {
                        GeneralRegionMasterViewModel generalRegionMasterViewModel = new GeneralRegionMasterViewModel();
                        generalRegionMasterViewModel.GeneralRegionMasterDTO = item;
                        listGeneralRegionMasterViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRegionMasterViewModel;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralRegionMasterViewModel> filteredRegionMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "RegionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CountryName Like '%" + param.sSearch + "%' or RegionName Like '%" + param.sSearch + "%' or ShortName Like '%"+param.sSearch+"%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 1:
                    _sortBy = "ShortName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CountryName Like '%" + param.sSearch + "%' or RegionName Like '%" + param.sSearch + "%' or ShortName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CountryName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CountryName Like '%" + param.sSearch + "%' or RegionName Like '%" + param.sSearch + "%' or ShortName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;           
            filteredRegionMaster = GetGeneralRegionMaster(out TotalRecords);
            var records = filteredRegionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.RegionName.ToString(), c.ShortName.ToString(), c.CountryName.ToString(), Convert.ToString(c.ID),Convert.ToString(c.IsUserDefined) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
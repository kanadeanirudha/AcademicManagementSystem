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
    public class GeneralCityMasterController : BaseController
    {
        IGeneralCityMasterServiceAccess _generalCityMasterServiceAcess = null;
        private readonly ILogger _logException;
        GeneralCityMasterBaseViewModel _generalCityMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCityMasterController()
        {
            _generalCityMasterServiceAcess = new GeneralCityMasterServiceAccess();
            _generalCityMasterBaseViewModel = new GeneralCityMasterBaseViewModel();
        }

        //  Controller Methods
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
            GeneralCityMasterViewModel model = new GeneralCityMasterViewModel();
            if (! string.IsNullOrEmpty(actionMode))
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
            GeneralCityMasterViewModel model = new GeneralCityMasterViewModel();
            try
            {
                string SelectedCountryID = string.Empty;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();

                List<GeneralCountryMaster> generalCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> generalCountryMaster = new List<SelectListItem>();


                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = (item.ID + "~" + item.ShortName).ToString().Trim() });
                }
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");


                foreach (GeneralCountryMaster item in generalCountryMasterList)
                {
                    generalCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCountryMaster = new SelectList(generalCountryMaster, "Value", "Text");

            }
            catch (Exception)
            {
                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralCityMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralCityMasterDTO != null)
                    {
                        model.GeneralCityMasterDTO.ConnectionString = _connectioString;

                        model.GeneralCityMasterDTO.Description = model.Description;
                         //model.GeneralLocationMasterDTO.CountryID = Convert.ToInt32(model.SelectedCountryID);
                        model.GeneralCityMasterDTO.RegionID = Convert.ToInt32(model.SelectedRegionID);
                        model.GeneralCityMasterDTO.RegionCode = model.RegionCode;
                        model.GeneralCityMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralCityMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCityMaster> response = _generalCityMasterServiceAcess.InsertGeneralCityMaster(model.GeneralCityMasterDTO);
                        model.GeneralCityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                       
                    }
                    return Json(model.GeneralCityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
              
        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralCityMasterViewModel model = new GeneralCityMasterViewModel();
            try
            {
             
                //Fill Country DropDown
                List<GeneralCountryMaster> generalCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> generalCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in generalCountryMasterList)
                {
                    generalCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCountryMaster = new SelectList(generalCountryMaster, "Value", "Text");


                model.GeneralCityMasterDTO = new GeneralCityMaster();
                model.GeneralCityMasterDTO.ID = id;
                model.GeneralCityMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralCityMaster> response = _generalCityMasterServiceAcess.SelectByID(model.GeneralCityMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralCityMasterDTO.ID = response.Entity.ID;
                    model.GeneralCityMasterDTO.Description = response.Entity.Description;
                    model.GeneralCityMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    model.GeneralCityMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.RegionCode = response.Entity.RegionID + "~" + response.Entity.RegionCode;
                    model.GeneralCityMasterDTO.CountryID = response.Entity.CountryID;
                    model.GeneralCityMasterDTO.CreatedBy = response.Entity.CreatedBy;
                 

                }
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(model.GeneralCityMasterDTO.CountryID));
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = (item.ID + "~" + item.ShortName).ToString().Trim() });
                }
                ViewBag.GeneralCountryMaster = new SelectList(generalCountryMaster, "Value", "Text", model.GeneralCityMasterDTO.CountryID);
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", model.RegionCode.Trim());
              
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralCityMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralCityMasterDTO != null)
                {
                    if (model != null && model.GeneralCityMasterDTO != null)
                    {
                        model.GeneralCityMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCityMasterDTO.Description = model.Description;
                        model.GeneralCityMasterDTO.RegionID = Convert.ToInt32(model.SelectedRegionID);
                        model.GeneralCityMasterDTO.RegionCode = model.RegionCode;
                        model.GeneralCityMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralCityMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCityMaster> response = _generalCityMasterServiceAcess.UpdateGeneralCityMaster(model.GeneralCityMasterDTO);
                        model.GeneralCityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralCityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    GeneralCityMasterViewModel model = new GeneralCityMasterViewModel();
        //    model.GeneralCityMasterDTO = new GeneralCityMaster();
        //    model.GeneralCityMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralCityMasterViewModel model)
        //{
        //    try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralCityMaster generalCityMasterDTO = new GeneralCityMaster();
        //            generalCityMasterDTO.ConnectionString = _connectioString;
        //            generalCityMasterDTO.ID = model.ID;
        //            generalCityMasterDTO.DeletedBy= Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralCityMaster> response = _generalCityMasterServiceAcess.DeleteGeneralCityMaster(generalCityMasterDTO);
        //            model.GeneralCityMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.GeneralCityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralCityMasterViewModel model = new GeneralCityMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        GeneralCityMaster generalCityMasterDTO = new GeneralCityMaster();
                        generalCityMasterDTO.ConnectionString = _connectioString;
                        generalCityMasterDTO.ID = ID;
                        generalCityMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCityMaster> response = _generalCityMasterServiceAcess.DeleteGeneralCityMaster(generalCityMasterDTO);
                        model.GeneralCityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralCityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        #endregion




        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetRegionByCountryID(string SelectedCountryID)
        {
            if (String.IsNullOrEmpty(SelectedCountryID))
            {
                throw new ArgumentNullException("SelectedCountryID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var Region = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in Region select new { id = s.ID+"~"+ s.ShortName, name = s.RegionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralCityMasterViewModel> GetGeneralCityMaster(out int TotalRecords)
        {
            GeneralCityMasterSearchRequest searchRequest = new GeneralCityMasterSearchRequest();
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
            List<GeneralCityMasterViewModel> listGeneralCityMasterViewModel = new List<GeneralCityMasterViewModel>();
            List<GeneralCityMaster> listGeneralCityMaster = new List<GeneralCityMaster>();
            IBaseEntityCollectionResponse<GeneralCityMaster> baseEntityCollectionResponse = _generalCityMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCityMaster item in listGeneralCityMaster)
                    {
                        GeneralCityMasterViewModel generalRegionMasterViewModel = new GeneralCityMasterViewModel();
                        generalRegionMasterViewModel.GeneralCityMasterDTO = item;
                        listGeneralCityMasterViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCityMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralCityMasterViewModel> filteredGeneralCityMasterViewModel ;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch ))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or RegionName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 1:
                    _sortBy = "RegionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or RegionName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralCityMasterViewModel = GetGeneralCityMaster(out TotalRecords);
            var records = filteredGeneralCityMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.RegionName, Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
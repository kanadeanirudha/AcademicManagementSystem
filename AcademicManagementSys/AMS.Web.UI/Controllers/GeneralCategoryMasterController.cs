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
    public class GeneralCategoryMasterController : BaseController
    {
        IGeneralCategoryMasterServiceAccess _generalCategoryMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCategoryMasterController()
        {
            _generalCategoryMasterServiceAcess = new GeneralCategoryMasterServiceAccess();
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
            GeneralCategoryMasterViewModel model = new GeneralCategoryMasterViewModel();
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
            GeneralCategoryMasterViewModel model = new GeneralCategoryMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            //li.Add(new SelectListItem { Text = "Select Type", Value = "0" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Open, Value = "Open" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Reserved, Value = "Reserved" });
            ViewData["CategoryType"] = li;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(GeneralCategoryMasterViewModel model)
        {
         try
            {   

            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralCategoryMasterDTO != null)
                {
                    model.GeneralCategoryMasterDTO.ConnectionString = _connectioString;
                    model.GeneralCategoryMasterDTO.CategoryName = model.CategoryName;
                    model.GeneralCategoryMasterDTO.CategoryCode = model.CategoryCode;
                    model.GeneralCategoryMasterDTO.CategoryType = model.CategoryType;
                    model.GeneralCategoryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);   
                    IBaseEntityResponse<GeneralCategoryMaster> response = _generalCategoryMasterServiceAcess.InsertGeneralCategoryMaster(model.GeneralCategoryMasterDTO);
                    model.GeneralCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.GeneralCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralCategoryMasterViewModel model = new GeneralCategoryMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Open, Value = "Open" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Reserved, Value = "Reserved" });

            model.GeneralCategoryMasterDTO = new GeneralCategoryMaster();
            model.GeneralCategoryMasterDTO.ID = id;
            model.GeneralCategoryMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<GeneralCategoryMaster> response = _generalCategoryMasterServiceAcess.SelectByID(model.GeneralCategoryMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.GeneralCategoryMasterDTO.ID = response.Entity.ID;
                model.GeneralCategoryMasterDTO.CategoryName = response.Entity.CategoryName;
                model.GeneralCategoryMasterDTO.CategoryCode = response.Entity.CategoryCode;
                model.GeneralCategoryMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                ViewData["CategoryType"] = new SelectList(li, "Text", "Value",response.Entity.CategoryType);
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(GeneralCategoryMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralCategoryMasterDTO != null)
                {
                    if (model != null && model.GeneralCategoryMasterDTO != null)
                    {
                        model.GeneralCategoryMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCategoryMasterDTO.CategoryName = model.CategoryName;
                        model.GeneralCategoryMasterDTO.CategoryCode = model.CategoryCode;
                        model.GeneralCategoryMasterDTO.CategoryType = model.CategoryType;
                        model.GeneralCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);   
                
                        IBaseEntityResponse<GeneralCategoryMaster> response = _generalCategoryMasterServiceAcess.UpdateGeneralCategoryMaster(model.GeneralCategoryMasterDTO);
                        model.GeneralCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //public ActionResult Delete(int ID)
        //{
        //    GeneralCategoryMasterViewModel model = new GeneralCategoryMasterViewModel();
        //    model.GeneralCategoryMasterDTO = new GeneralCategoryMaster();
        //    model.GeneralCategoryMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(GeneralCategoryMasterViewModel model)
        //{
        //    try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            GeneralCategoryMaster GeneralCategoryMasterDTO = new GeneralCategoryMaster();
        //            GeneralCategoryMasterDTO.ConnectionString = _connectioString;
        //            GeneralCategoryMasterDTO.ID = model.ID;
        //            GeneralCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);   
        //            IBaseEntityResponse<GeneralCategoryMaster> response = _generalCategoryMasterServiceAcess.DeleteGeneralCategoryMaster(GeneralCategoryMasterDTO);
        //            model.GeneralCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.GeneralCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            GeneralCategoryMasterViewModel model = new GeneralCategoryMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                    if (ID > 0)
                    {
                        GeneralCategoryMaster GeneralCategoryMasterDTO = new GeneralCategoryMaster();
                        GeneralCategoryMasterDTO.ConnectionString = _connectioString;
                        GeneralCategoryMasterDTO.ID = ID;
                        GeneralCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCategoryMaster> response = _generalCategoryMasterServiceAcess.DeleteGeneralCategoryMaster(GeneralCategoryMasterDTO);
                        model.GeneralCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.GeneralCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralCategoryMasterViewModel> GetGeneralCategoryMaster(out int TotalRecords)
        {
            GeneralCategoryMasterSearchRequest searchRequest = new GeneralCategoryMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                      // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<GeneralCategoryMasterViewModel> listGeneralCategoryMasterViewModel = new List<GeneralCategoryMasterViewModel>();
            List<GeneralCategoryMaster> listGeneralCategoryMaster = new List<GeneralCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralCategoryMaster> baseEntityCollectionResponse = _generalCategoryMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCategoryMaster item in listGeneralCategoryMaster)
                    {
                        GeneralCategoryMasterViewModel GeneralCategoryMasterViewModel = new GeneralCategoryMasterViewModel();
                        GeneralCategoryMasterViewModel.GeneralCategoryMasterDTO = item;
                        listGeneralCategoryMasterViewModel.Add(GeneralCategoryMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCategoryMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralCategoryMasterViewModel> filteredGeneralCategoryMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CategoryName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CategoryName Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%' or CategoryType Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CategoryCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CategoryName Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%' or CategoryType Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CategoryType";
                    if (param.sSearch == null)
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CategoryName Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%' or CategoryType Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralCategoryMaster = GetGeneralCategoryMaster(out TotalRecords);
            var records = filteredGeneralCategoryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CategoryName.ToString(), c.CategoryCode.ToString(), c.CategoryType.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
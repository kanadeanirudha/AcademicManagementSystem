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
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class InventoryItemCategoryMasterController : BaseController
    {
        IInventoryItemCategoryMasterServiceAccess _InventoryItemCategoryMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryItemCategoryMasterController()
        {
            _InventoryItemCategoryMasterServiceAcess = new InventoryItemCategoryMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryItemCategoryMaster/Index.cshtml");
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
                InventoryItemCategoryMasterViewModel model = new InventoryItemCategoryMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryItemCategoryMaster/List.cshtml", model);
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
            InventoryItemCategoryMasterViewModel model = new InventoryItemCategoryMasterViewModel();
            return PartialView("/Views/Inventory/InventoryItemCategoryMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryItemCategoryMasterViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.InventoryItemCategoryMasterDTO != null)
                    {
                        model.InventoryItemCategoryMasterDTO.ConnectionString = _connectioString;
                        model.InventoryItemCategoryMasterDTO.CategoryDescription = model.CategoryDescription;
                       // model.InventoryItemCategoryMasterDTO.SeqNo = model.SeqNo; ;
                        model.InventoryItemCategoryMasterDTO.CategoryCode = model.CategoryCode;
                        model.InventoryItemCategoryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryItemCategoryMaster> response = _InventoryItemCategoryMasterServiceAcess.InsertInventoryItemCategoryMaster(model.InventoryItemCategoryMasterDTO);
                        model.InventoryItemCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);
                        return Json(model.InventoryItemCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                    
                    return Json("Please review your form");
                
               
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
            InventoryItemCategoryMasterViewModel model = new InventoryItemCategoryMasterViewModel();
            try
            {                
                model.InventoryItemCategoryMasterDTO = new InventoryItemCategoryMaster();
                model.InventoryItemCategoryMasterDTO.ID = id;
                model.InventoryItemCategoryMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryItemCategoryMaster> response = _InventoryItemCategoryMasterServiceAcess.SelectByID(model.InventoryItemCategoryMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryItemCategoryMasterDTO.ID = response.Entity.ID;
                    model.InventoryItemCategoryMasterDTO.CategoryDescription = response.Entity.CategoryDescription;
                   // model.InventoryItemCategoryMasterDTO.SeqNo = response.Entity.SeqNo;
                    model.InventoryItemCategoryMasterDTO.CategoryCode = response.Entity.CategoryCode;
                   // model.InventoryItemCategoryMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.InventoryItemCategoryMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryItemCategoryMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryItemCategoryMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryItemCategoryMasterDTO != null)
                {
                    if (model != null && model.InventoryItemCategoryMasterDTO != null)
                    {
                        model.InventoryItemCategoryMasterDTO.ConnectionString = _connectioString;
                        model.InventoryItemCategoryMasterDTO.CategoryDescription = model.CategoryDescription;
                       // model.InventoryItemCategoryMasterDTO.SeqNo = model.SeqNo;
                        model.InventoryItemCategoryMasterDTO.CategoryCode = model.CategoryCode;
                        model.InventoryItemCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryItemCategoryMaster> response = _InventoryItemCategoryMasterServiceAcess.UpdateInventoryItemCategoryMaster(model.InventoryItemCategoryMasterDTO);
                        model.InventoryItemCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryItemCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    InventoryItemCategoryMasterViewModel model = new InventoryItemCategoryMasterViewModel();
        //    model.InventoryItemCategoryMasterDTO = new InventoryItemCategoryMaster();
        //    model.InventoryItemCategoryMasterDTO.ID = ID;
        //    return PartialView("/Views/Inventory/InventoryItemCategoryMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(InventoryItemCategoryMasterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            InventoryItemCategoryMaster InventoryItemCategoryMasterDTO = new InventoryItemCategoryMaster();
        //            InventoryItemCategoryMasterDTO.ConnectionString = _connectioString;
        //            InventoryItemCategoryMasterDTO.ID = model.ID;
        //            InventoryItemCategoryMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<InventoryItemCategoryMaster> response = _InventoryItemCategoryMasterServiceAcess.DeleteInventoryItemCategoryMaster(InventoryItemCategoryMasterDTO);
        //            model.InventoryItemCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.InventoryItemCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            InventoryItemCategoryMasterViewModel model = new InventoryItemCategoryMasterViewModel();
            if (ID > 0)
            {
                if (ID > 0)
                {
                    InventoryItemCategoryMaster InventoryItemCategoryMasterDTO = new InventoryItemCategoryMaster();
                    InventoryItemCategoryMasterDTO.ConnectionString = _connectioString;
                    InventoryItemCategoryMasterDTO.ID = ID;
                    InventoryItemCategoryMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryItemCategoryMaster> response = _InventoryItemCategoryMasterServiceAcess.DeleteInventoryItemCategoryMaster(InventoryItemCategoryMasterDTO);
                    model.InventoryItemCategoryMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.InventoryItemCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryItemCategoryMasterViewModel> GetInventoryItemCategoryMaster(out int TotalRecords)
        {
            InventoryItemCategoryMasterSearchRequest searchRequest = new InventoryItemCategoryMasterSearchRequest();
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
            List<InventoryItemCategoryMasterViewModel> listInventoryItemCategoryMasterViewModel = new List<InventoryItemCategoryMasterViewModel>();
            List<InventoryItemCategoryMaster> listInventoryItemCategoryMaster = new List<InventoryItemCategoryMaster>();
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> baseEntityCollectionResponse = _InventoryItemCategoryMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryItemCategoryMaster item in listInventoryItemCategoryMaster)
                    {
                        InventoryItemCategoryMasterViewModel InventoryItemCategoryMasterViewModel = new InventoryItemCategoryMasterViewModel();
                        InventoryItemCategoryMasterViewModel.InventoryItemCategoryMasterDTO = item;
                        listInventoryItemCategoryMasterViewModel.Add(InventoryItemCategoryMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryItemCategoryMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryItemCategoryMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CategoryDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CategoryDescription Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                            _searchBy = "CategoryDescription Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetInventoryItemCategoryMaster(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<InventoryItemCategoryMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CategoryDescription.ToString(), c.CategoryCode.ToString(), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
               //return RedirectToAction("Login", "Account");
                var result = 0;
               return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}
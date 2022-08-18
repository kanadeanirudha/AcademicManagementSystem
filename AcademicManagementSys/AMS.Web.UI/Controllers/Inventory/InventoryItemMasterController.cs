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
    public class InventoryItemMasterController : BaseController
    {
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAcess = null;
        IGeneralUnitMasterServiceAccess _generalUnitMasterServiceAcess = null;
        IInventoryItemCategoryMasterServiceAccess _inventoryItemCategoryMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryItemMasterController()
        {
            _inventoryItemMasterServiceAcess = new InventoryItemMasterServiceAccess();
            _generalUnitMasterServiceAcess = new GeneralUnitMasterServiceAccess();
            _inventoryItemCategoryMasterServiceAccess = new InventoryItemCategoryMasterServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryItemMaster/Index.cshtml");
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
                InventoryItemMasterViewModel model = new InventoryItemMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryItemMaster/List.cshtml", model);
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
            InventoryItemMasterViewModel model = new InventoryItemMasterViewModel();
            model.GeneralUnitMasterList = GetListGeneralUnitMaster();

            List<InventoryItemCategoryMaster> listAdminRoleApplicableDetails = GetInventoryItemCategoryMaster();
            InventoryItemCategoryMaster a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {

                a = new InventoryItemCategoryMaster();
                a.CategoryCode = item.CategoryCode;
                a.CategoryDescription = item.CategoryDescription;
                model.InventoryItemCategoryMasterList.Add(a);
            }
            // model.InventoryItemCategoryMasterList = GetInventoryItemCategoryMaster();

            model.GeneralCurrencyMasterList = GetGeneralCurrencyMaster();

            model.GeneralTaxGroupMasterList = GetGeneralTaxGroupMaster();

            return PartialView("/Views/Inventory/InventoryItemMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryItemMasterViewModel model)
        {
            try
            {
                if (model != null && model.InventoryItemMasterDTO != null)
                {
                    model.InventoryItemMasterDTO.ConnectionString = _connectioString;
                    model.InventoryItemMasterDTO.ID = model.ID;
                    model.InventoryItemMasterDTO.ItemCategoryCode = model.ItemCategoryCode;
                    model.InventoryItemMasterDTO.ItemName = model.ItemName;
                    model.InventoryItemMasterDTO.ItemCode = model.ItemCode;
                    model.InventoryItemMasterDTO.WholeSaleRate = model.WholeSaleRate;
                    model.InventoryItemMasterDTO.RetailRate = model.RetailRate;
                    model.InventoryItemMasterDTO.SpecialRate = model.SpecialRate;
                    model.InventoryItemMasterDTO.MaximumRetialPrice = model.MaximumRetialPrice;
                    model.InventoryItemMasterDTO.CurrencyCode = model.CurrencyCode;
                    model.InventoryItemMasterDTO.Picture = model.Picture;
                    model.InventoryItemMasterDTO.GenTaxGroupMasterID = model.GenTaxGroupMasterID;
                    model.InventoryItemMasterDTO.UnitID = model.UnitID;
                    model.InventoryItemMasterDTO.IsSerialNumber = model.IsSerialNumber;
                    model.InventoryItemMasterDTO.IsRateTaxesCentrerwise = model.IsRateTaxesCentrerwise;
                    model.InventoryItemMasterDTO.IsSaleRateDependOnPuchase = model.IsSaleRateDependOnPuchase;
                    model.InventoryItemMasterDTO.SaleRateFactorInPercentage = model.SaleRateFactorInPercentage;
                    model.InventoryItemMasterDTO.RetailRateFactorInPercentage = model.RetailRateFactorInPercentage;
                    model.InventoryItemMasterDTO.ItemFamily = model.ItemFamily;
                    model.InventoryItemMasterDTO.PackingUnit = model.PackingUnit;
                    model.InventoryItemMasterDTO.PackingType = model.PackingType;
                    model.InventoryItemMasterDTO.IsExpiry = model.IsExpiry;
                    model.InventoryItemMasterDTO.IsTaxInclusive = model.IsTaxInclusive;
                    model.InventoryItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.InventoryItemMasterDTO.ItemFamilyMasterID = model.ItemFamilyMasterID;
                    model.InventoryItemMasterDTO.ItemPackingUnitMasterID = model.ItemPackingUnitMasterID;
                    model.InventoryItemMasterDTO.ItemPackingTypeMasterID = model.ItemPackingTypeMasterID;
                    model.InventoryItemMasterDTO.MinIndentLevel = model.MinIndentLevel;

                    if (model.ID == 0)
                    {
                        IBaseEntityResponse<InventoryItemMaster> response = _inventoryItemMasterServiceAcess.InsertInventoryItemMaster(model.InventoryItemMasterDTO);
                        model.InventoryItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else
                    {
                        IBaseEntityResponse<InventoryItemMaster> response = _inventoryItemMasterServiceAcess.UpdateInventoryItemMaster(model.InventoryItemMasterDTO);
                        model.InventoryItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }                   

                    return Json(model.InventoryItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            InventoryItemMasterViewModel model = new InventoryItemMasterViewModel();
            model.GeneralUnitMasterList = GetListGeneralUnitMaster();
            model.InventoryItemMasterDTO = new InventoryItemMaster();
            model.InventoryItemMasterDTO.ID = id;
            model.InventoryItemMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventoryItemMaster> response = _inventoryItemMasterServiceAcess.SelectByID(model.InventoryItemMasterDTO);
            if (response != null && response.Entity != null)
            {
                model.InventoryItemMasterDTO.ID = response.Entity.ID;
                model.InventoryItemMasterDTO.ItemName = response.Entity.ItemName;
                model.InventoryItemMasterDTO.ItemCode = response.Entity.ItemCode;
                model.InventoryItemMasterDTO.PurchaseRate = response.Entity.PurchaseRate;
                model.InventoryItemMasterDTO.SaleRate = response.Entity.SaleRate;
                model.InventoryItemMasterDTO.UnitID = response.Entity.UnitID;
            }
            return PartialView("/Views/Inventory/InventoryItemMaster/Create.cshtml", model);
        }


        [HttpGet]
        public ActionResult Delete(int ID)
        {
            InventoryItemMasterViewModel model = new InventoryItemMasterViewModel();

            model.InventoryItemMasterDTO = new InventoryItemMaster();
            model.InventoryItemMasterDTO.ID = ID;
            model.InventoryItemMasterDTO.ConnectionString = _connectioString;

            //IBaseEntityResponse<InventoryItemMaster> response = _inventoryItemMasterServiceAcess.SelectByID(model.InventoryItemMasterDTO);
            //if (response != null && response.Entity != null)
            //{
            //    model.InventoryItemMasterDTO.ID = response.Entity.ID;
            //}
            return PartialView("/Views/Inventory/InventoryItemMaster/Delete.cshtml", model);
        }



        [HttpPost]
        public ActionResult Delete(InventoryItemMasterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        InventoryItemMaster InventoryItemMasterDTO = new InventoryItemMaster();
                        InventoryItemMasterDTO.ConnectionString = _connectioString;
                        InventoryItemMasterDTO.ID = model.ID;
                        InventoryItemMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
                        IBaseEntityResponse<InventoryItemMaster> response = null;
                        response = _inventoryItemMasterServiceAcess.DeleteInventoryItemMaster(InventoryItemMasterDTO);
                        model.InventoryItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.InventoryItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult GetItemFamilySearchList(string term)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;

            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAcess.GetItemFamilySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listInventoryItemMaster
                          select new
                          {
                              id = r.ItemFamilyMasterID,
                              name = r.ItemFamily
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemPackingUnitSearchList(string term)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;

            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAcess.GetItemPackingUnitSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listInventoryItemMaster
                          select new
                          {
                              id = r.ItemPackingUnitMasterID,
                              name = r.PackingUnit
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemPackingTypeSearchList(string term)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;

            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAcess.GetItemPackingTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listInventoryItemMaster
                          select new
                          {
                              id = r.ItemPackingTypeMasterID,
                              name = r.PackingType
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckFocusOnAction(string actionOn, string data)
        {
            InventoryItemMasterViewModel model = new InventoryItemMasterViewModel();
            model.InventoryItemMasterDTO = new InventoryItemMaster();
            model.InventoryItemMasterDTO.ActionOn = actionOn;
            model.InventoryItemMasterDTO.ActionName = data;
            model.InventoryItemMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventoryItemMaster> response = _inventoryItemMasterServiceAcess.CheckFocusOnAction(model.InventoryItemMasterDTO);
            if (response != null && response.Entity != null)
            {
                model.InventoryItemMasterDTO.ActionID = response.Entity.ActionID;
            }
            return Json(model.InventoryItemMasterDTO.ActionID, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public ActionResult GetItemCode(string ItemCode)
        {
            InventoryItemMaster InventoryItemMasterDTO = new InventoryItemMaster();
            InventoryItemMasterDTO.ItemCode = ItemCode;
            InventoryItemMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventoryItemMaster> response = null;
            response = _inventoryItemMasterServiceAcess.GetItemCode(InventoryItemMasterDTO);
            // var result = response.Entity.ItemCode;
            return Json(response.Entity.ItemCode, JsonRequestBehavior.AllowGet);
        }


        protected List<InventoryItemCategoryMaster> GetInventoryItemCategoryMaster()
        {
            InventoryItemCategoryMasterSearchRequest searchRequest = new InventoryItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryItemCategoryMaster> listInventoryItemCategoryMaster = new List<InventoryItemCategoryMaster>();
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> baseEntityCollectionResponse = _inventoryItemCategoryMasterServiceAccess.GetInventoryItemCategoryMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInventoryItemCategoryMaster;
        }


        public IEnumerable<InventoryItemMasterViewModel> GetInventoryItemMaster(out int TotalRecords)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<InventoryItemMasterViewModel> listInventoryItemMasterViewModel = new List<InventoryItemMasterViewModel>();
            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryItemMaster item in listInventoryItemMaster)
                    {
                        InventoryItemMasterViewModel InventoryItemMasterViewModel = new InventoryItemMasterViewModel();
                        InventoryItemMasterViewModel.InventoryItemMasterDTO = item;
                        listInventoryItemMasterViewModel.Add(InventoryItemMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryItemMasterViewModel;
        }
        
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryItemMasterViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.ItemName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%' or A.ItemCode Like '%" + param.sSearch + "%' or B.SHORTCODE Like '%" + param.sSearch + "%' or C.CategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.WholeSaleRate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%' or A.ItemCode Like '%" + param.sSearch + "%' or B.SHORTCODE Like '%" + param.sSearch + "%' or C.CategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
                case 2:
                    _sortBy = "A.RetailRate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%' or A.ItemCode Like '%" + param.sSearch + "%' or B.SHORTCODE Like '%" + param.sSearch + "%' or C.CategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
                case 3:
                    _sortBy = "A.MaximumRetialPrice";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%' or A.ItemCode Like '%" + param.sSearch + "%' or B.SHORTCODE Like '%" + param.sSearch + "%' or C.CategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
                case 4:
                    _sortBy = "B.SHORTCODE";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%' or A.ItemCode Like '%" + param.sSearch + "%' or B.SHORTCODE Like '%" + param.sSearch + "%' or C.CategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetInventoryItemMaster(out TotalRecords);
            if ((filteredCountryMaster.Count()) == 0)
            {
                filteredCountryMaster = new List<InventoryItemMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ItemCategoryDescription.ToString(), c.ItemName.ToString() + "( " + c.ItemCode.ToString() + " )", Convert.ToString(c.WholeSaleRate), Convert.ToString(c.RetailRate), Convert.ToString(c.MaximumRetialPrice), Convert.ToString(c.UnitCode), Convert.ToString(c.ID), };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}
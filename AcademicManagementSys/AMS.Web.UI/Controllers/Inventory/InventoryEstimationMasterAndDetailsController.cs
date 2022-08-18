using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class InventoryEstimationMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryEstimationMasterAndDetailsServiceAccess _inventoryEstimationMasterAndDetailsServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        InventoryCustomerMasterServiceAccess _inventoryCustomerMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryEstimationMasterAndDetailsController()
        {
            _inventoryEstimationMasterAndDetailsServiceAccess = new InventoryEstimationMasterAndDetailsServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            _inventoryCustomerMasterServiceAccess = new InventoryCustomerMasterServiceAccess();

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
                return View("/Views/Inventory/InventoryEstimationMasterAndDetails/Index.cshtml");
        }
        [HttpGet]
        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    IInventoryEstimationMasterAndDetailsViewModel model = new InventoryEstimationMasterAndDetailsViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Inventory/InventoryEstimationMasterAndDetails/List.cshtml", model);
                }
                else
                {
                    return RedirectToActionPermanent("UnauthorizedAccess", "Home");
                }
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
            IInventoryEstimationMasterAndDetailsViewModel model = new InventoryEstimationMasterAndDetailsViewModel();
            return PartialView("/Views/Inventory/InventoryEstimationMasterAndDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryEstimationMasterAndDetailsViewModel model)
        {
            try
            {
                model.InventoryEstimationMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.InventoryEstimationMasterAndDetailsDTO.BalanceSheetID = model.BalanceSheetID;
                model.InventoryEstimationMasterAndDetailsDTO.CustomerName = model.CustomerName;
                model.InventoryEstimationMasterAndDetailsDTO.CustomerID = model.CustomerID;
                model.InventoryEstimationMasterAndDetailsDTO.CustomerMobileNumber = model.CustomerMobileNumber;
                model.InventoryEstimationMasterAndDetailsDTO.CustomerAddress = model.CustomerAddress;
                model.InventoryEstimationMasterAndDetailsDTO.EstimationAmount = model.EstimationAmount;
                model.InventoryEstimationMasterAndDetailsDTO.TotalTaxAmount = model.TotalTaxAmount;
                model.InventoryEstimationMasterAndDetailsDTO.TotalDiscountAmount = model.TotalDiscountAmount;
                model.InventoryEstimationMasterAndDetailsDTO.XMLstring = model.XMLstring;
                model.InventoryEstimationMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = _inventoryEstimationMasterAndDetailsServiceAccess.InsertInventoryEstimationMasterAndDetails(model.InventoryEstimationMasterAndDetailsDTO);
                model.InventoryEstimationMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.InventoryEstimationMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult View(int id, int balancesheetId)
        {
            try
            {
                IInventoryEstimationMasterAndDetailsViewModel model = new InventoryEstimationMasterAndDetailsViewModel();

                model.InventoryEstimationMasterAndDetailsList = GetInventoryEstimationMasterAndDetails(id, false,Convert.ToInt16(balancesheetId));
                if (model.InventoryEstimationMasterAndDetailsList.Count > 0 && model.InventoryEstimationMasterAndDetailsList != null)
                {
                    model.CustomerName = model.InventoryEstimationMasterAndDetailsList[0].CustomerName;
                    model.CustomerMobileNumber = model.InventoryEstimationMasterAndDetailsList[0].CustomerMobileNumber;
                    model.CustomerAddress = model.InventoryEstimationMasterAndDetailsList[0].CustomerAddress;
                   // model.EstimationAmount =Math.Round((from a in model.InventoryEstimationMasterAndDetailsList select (a.Rate * a.Quantity)).Sum(),2);
                    model.EstimationAmount = model.InventoryEstimationMasterAndDetailsList[0].GrossAmount;
                    model.TransactionDate = model.InventoryEstimationMasterAndDetailsList[0].TransactionDate;
                    model.DiscountAmountForItem = model.InventoryEstimationMasterAndDetailsList[0].DiscountAmountForItem;
                    model.TotalTaxForItem = model.InventoryEstimationMasterAndDetailsList[0].TotalTaxForItem;
                }

                return PartialView("/Views/Inventory/InventoryEstimationMasterAndDetails/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AllocateEstimation(int id, int balancesheetId)
        {
            try
            {
                IInventoryEstimationMasterAndDetailsViewModel model = new InventoryEstimationMasterAndDetailsViewModel();
                model.InventoryEstimationMasterAndDetailsList = GetInventoryEstimationMasterAndDetails(id, true, Convert.ToInt16(balancesheetId));
                if (model.InventoryEstimationMasterAndDetailsList.Count > 0 && model.InventoryEstimationMasterAndDetailsList != null)
                {
                    model.CustomerName = model.InventoryEstimationMasterAndDetailsList[0].CustomerName;
                    model.CustomerMobileNumber = model.InventoryEstimationMasterAndDetailsList[0].CustomerMobileNumber;
                    model.CustomerAddress = model.InventoryEstimationMasterAndDetailsList[0].CustomerAddress;
                    model.EstimationAmount =Math.Round((from a in model.InventoryEstimationMasterAndDetailsList select (a.Rate * a.Quantity)).Sum(),2);
                    model.TransactionDate = model.InventoryEstimationMasterAndDetailsList[0].TransactionDate;
                }

                model.LocationList = GetLocationList(balancesheetId);
                //ViewBag.OrganisationDivisionMaster = new SelectList(orgDivisionMaster, "Value", "Text");
                return PartialView("/Views/Inventory/InventoryEstimationMasterAndDetails/AllocateEstimation.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult AllocateEstimation(InventoryEstimationMasterAndDetailsViewModel model)
        {
            try
            {
                model.InventoryEstimationMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.InventoryEstimationMasterAndDetailsDTO.ID= model.ID;
                model.InventoryEstimationMasterAndDetailsDTO.LocationID = model.LocationID;
                model.InventoryEstimationMasterAndDetailsDTO.EstimateLocationWiseXMLstring = model.EstimateLocationWiseXMLstring;
                model.InventoryEstimationMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = _inventoryEstimationMasterAndDetailsServiceAccess.InsertInventoryEstimationToLocation(model.InventoryEstimationMasterAndDetailsDTO);
                model.InventoryEstimationMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.InventoryEstimationMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //print function
        [HttpGet]
        public ActionResult PrintBill(string selectedBalsheet, string InvSaleMasterID)
        {
            List<InventoryEstimationMasterAndDetails> listInventoryEstimationMasterAndDetails = new List<InventoryEstimationMasterAndDetails>();
            InventoryEstimationMasterAndDetailsSearchRequest searchRequest = new InventoryEstimationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = Convert.ToInt32(InvSaleMasterID);
            searchRequest.AccBalancesheetID = Convert.ToInt16(selectedBalsheet);
            if (searchRequest.ID > 0 && searchRequest.AccBalancesheetID > 0)
            {
                IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> baseEntityCollectionResponse = _inventoryEstimationMasterAndDetailsServiceAccess.GetInventoryEstimationMasterAndDetails(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventoryEstimationMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
            }

            return Json(listInventoryEstimationMasterAndDetails, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
          [NonAction]
        protected List<InventoryLocationMaster> GetLocationList(int balancesheet)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryLocationMasterServiceAccess.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        [NonAction]
          protected List<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetails(int id, bool isAllocateToLocation, int selectedBalsheet)
        {
            InventoryEstimationMasterAndDetailsSearchRequest searchRequest = new InventoryEstimationMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            searchRequest.IsAllocateToLocation = isAllocateToLocation;
            searchRequest.AccBalancesheetID = Convert.ToInt16(selectedBalsheet);
            List<InventoryEstimationMasterAndDetails> listDumpAndShrinkDetails = new List<InventoryEstimationMasterAndDetails>();
            IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> baseEntityCollectionResponse = _inventoryEstimationMasterAndDetailsServiceAccess.GetInventoryEstimationMasterAndDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDumpAndShrinkDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listDumpAndShrinkDetails;
        }

        ////Non-Action method to fetch list of items
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string locationID, string selectedBalsheet)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(locationID) ? locationID : null);
            searchRequest.SearchWord = term;
            searchRequest.AccBalsheetMstID = Convert.ToInt16(selectedBalsheet);
            //searchRequest.AccBalsheetMstID = Convert.ToInt16(selectedBalsheet);
            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemSearchListForEstimation(searchRequest);
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
                              id = r.ID,
                              name = r.ItemName,
                              itemCode = r.ItemCode,
                              rate = r.SaleRate,
                              picture = r.Picture,
                              currencyCode = r.CurrencyCode,
                              currentStockQty = r.CurrentStockQty,
                              unitID = r.UnitID,
                              unitCode = r.UnitCode,
                              GenTaxGroupMasterID = r.GenTaxGroupMasterID,
                              TaxRatePercentage = r.TaxRatePercentage,
                              RateDecreaseByPercentage=r.RateDecreaseByPercentage
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        ////Non-Action method Customer Searchlist
        public JsonResult GetCustomerNameSearchList(string term)
        {
            InventoryCustomerMasterSearchRequest searchRequest = new InventoryCustomerMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<InventoryCustomerMaster> listInventoryCustomerMaster = new List<InventoryCustomerMaster>();
            IBaseEntityCollectionResponse<InventoryCustomerMaster> baseEntityCollectionResponse = _inventoryCustomerMasterServiceAccess.GetInventoryCustomerMasterSelectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listInventoryCustomerMaster
                          select new
                          {
                              id = r.ID,
                              name = r.Name,
                              contactNumber = r.ContactNumber,
                              address = r.Address,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventoryEstimationMasterAndDetails> GetListInventoryEstimationMasterAndDetails(string SelectedBalanceSheet, out int TotalRecords)
        {
            List<InventoryEstimationMasterAndDetails> listInventoryEstimationMasterAndDetails = new List<InventoryEstimationMasterAndDetails>();
            InventoryEstimationMasterAndDetailsSearchRequest searchRequest = new InventoryEstimationMasterAndDetailsSearchRequest();
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
                    searchRequest.AccBalancesheetID=Convert.ToInt16( SelectedBalanceSheet);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AccBalancesheetID = Convert.ToInt16(SelectedBalanceSheet);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccBalancesheetID = Convert.ToInt16(SelectedBalanceSheet);
            }
            IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> baseEntityCollectionResponse = _inventoryEstimationMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryEstimationMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryEstimationMasterAndDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string selectedBalanceSheetID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryEstimationMasterAndDetails> filteredInventoryEstimationMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CustomerName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CustomerName Like '%" + param.sSearch + "%' or CustomerMobileNumber Like '%" + param.sSearch + "%' or CustomerAddress Like '%" + param.sSearch + "%'  or EstimationAmount Like '%" + param.sSearch + "%'  or TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CustomerMobileNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CustomerName Like '%" + param.sSearch + "%' or CustomerMobileNumber Like '%" + param.sSearch + "%' or CustomerAddress Like '%" + param.sSearch + "%'  or EstimationAmount Like '%" + param.sSearch + "%'  or TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "CustomerAddress";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CustomerName Like '%" + param.sSearch + "%' or CustomerMobileNumber Like '%" + param.sSearch + "%' or CustomerAddress Like '%" + param.sSearch + "%'  or EstimationAmount Like '%" + param.sSearch + "%'  or TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "EstimationAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CustomerName Like '%" + param.sSearch + "%' or CustomerMobileNumber Like '%" + param.sSearch + "%' or CustomerAddress Like '%" + param.sSearch + "%'  or EstimationAmount Like '%" + param.sSearch + "%'  or TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CustomerName Like '%" + param.sSearch + "%' or CustomerMobileNumber Like '%" + param.sSearch + "%' or CustomerAddress Like '%" + param.sSearch + "%'  or EstimationAmount Like '%" + param.sSearch + "%'  or TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if ((!string.IsNullOrEmpty(selectedBalanceSheetID) || Convert.ToString(Session["UserType"]) == "A"))
            {
                filteredInventoryEstimationMasterAndDetails = GetListInventoryEstimationMasterAndDetails(selectedBalanceSheetID, out TotalRecords);    
            }
            else
            {
                filteredInventoryEstimationMasterAndDetails = new List<InventoryEstimationMasterAndDetails>();
                TotalRecords = 0;
            }
            if ((filteredInventoryEstimationMasterAndDetails.Count()) == 0)
            {
                filteredInventoryEstimationMasterAndDetails = new List<InventoryEstimationMasterAndDetails>();
                TotalRecords = 0;
            }


            var records = filteredInventoryEstimationMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CustomerName), Convert.ToString(c.CustomerMobileNumber), Convert.ToString(c.CustomerAddress), Convert.ToString(Math.Round(c.EstimationAmount, 2)), Convert.ToString(c.TransactionDate), Convert.ToString(c.IsPendingForBill), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

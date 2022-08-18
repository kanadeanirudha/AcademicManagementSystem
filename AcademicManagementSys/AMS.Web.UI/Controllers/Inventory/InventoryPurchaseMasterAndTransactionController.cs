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
    public class InventoryPurchaseMasterAndTransactionController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryPurchaseMasterAndTransactionServiceAccess _InventoryPurchaseMasterAndTransactionServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        IAccountSessionMasterServiceAccess _accountSessionMasterServiceAccess = null;
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
        public InventoryPurchaseMasterAndTransactionController()
        {
            _InventoryPurchaseMasterAndTransactionServiceAccess = new InventoryPurchaseMasterAndTransactionServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
            _accountSessionMasterServiceAccess = new AccountSessionMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryPurchaseMasterAndTransaction/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) )
                {
                    InventoryPurchaseMasterAndTransactionViewModel model = new InventoryPurchaseMasterAndTransactionViewModel();

                    model.LocationList = GetLocationList(selectedBalsheet);


                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Inventory/InventoryPurchaseMasterAndTransaction/List.cshtml", model);
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

        [HttpPost]
        
        public ActionResult Create(InventoryPurchaseMasterAndTransactionViewModel model)
        {
            try
            {
                if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
                {
                    // For Center
                    AccountBalancesheetMasterViewModel model1 = new AccountBalancesheetMasterViewModel();
                    model1.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
                    model1.AccBalsheetMasterDTO.ID = Convert.ToInt16(Session["BalancesheetID"]);
                    model1.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<AccountBalancesheetMaster> response1 = _accountBalancesheetMasterServiceAccess.SelectByID(model1.AccBalsheetMasterDTO);
                    model1.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                    if (response1 != null && response1.Entity != null)
                    {
                        model.InventoryPurchaseMasterAndTransactionDTO.CentreCode = response1.Entity.CentreCode;
                    }
                    ///////////////////////////////////
                    //For Current Account Session

                    AccountSessionMasterViewModel model2 = new AccountSessionMasterViewModel();
                    model2.AccountSessionMasterDTO = new AccountSessionMaster();
                    model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<AccountSessionMaster> response2 = _accountSessionMasterServiceAccess.GetCurrentAccountSession(model2.AccountSessionMasterDTO);
                    model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                    if (response2 != null && response2.Entity != null)
                    {
                        model.InventoryPurchaseMasterAndTransactionDTO.AccountSessionID = response2.Entity.ID;
                    }
                    //////////////////////////////////
                    model.InventoryPurchaseMasterAndTransactionDTO.ConnectionString = _connectioString;
                    model.InventoryPurchaseMasterAndTransactionDTO.SelectedBalanceSheet = Convert.ToString(Session["BalancesheetID"]);
                    model.InventoryPurchaseMasterAndTransactionDTO.TransactionDate = Convert.ToString(DateTime.Now);
                    model.InventoryPurchaseMasterAndTransactionDTO.BillAmount = model.BillAmount;
                    model.InventoryPurchaseMasterAndTransactionDTO.LocationID = model.LocationID;
                    model.InventoryPurchaseMasterAndTransactionDTO.BillNumber = model.BillNumber;
                    model.InventoryPurchaseMasterAndTransactionDTO.SupplierName = model.SupplierName;
                    model.InventoryPurchaseMasterAndTransactionDTO.Hamali = model.Hamali;
                    model.InventoryPurchaseMasterAndTransactionDTO.OtherExpenses = model.OtherExpenses;
                    model.InventoryPurchaseMasterAndTransactionDTO.TotalBillAmountincludingTax = model.TotalBillAmountincludingTax;

                    model.InventoryPurchaseMasterAndTransactionDTO.ParameterXml = model.ParameterXml;
                    model.InventoryPurchaseMasterAndTransactionDTO.BatchID = model.BatchID;
                    model.InventoryPurchaseMasterAndTransactionDTO.RoundUpAmount = model.RoundUpAmount;
                    model.InventoryPurchaseMasterAndTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = _InventoryPurchaseMasterAndTransactionServiceAccess.InsertInventoryPurchaseMasterAndTransaction(model.InventoryPurchaseMasterAndTransactionDTO);
                    model.InventoryPurchaseMasterAndTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryPurchaseMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
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
                InventoryPurchaseMasterAndTransactionViewModel model = new InventoryPurchaseMasterAndTransactionViewModel();

                model.InventoryPurchaseMasterAndTransactionList = GetInventoryEstimationMasterAndDetails(id,Convert.ToInt16(balancesheetId));
                if (model.InventoryPurchaseMasterAndTransactionList.Count > 0 && model.InventoryPurchaseMasterAndTransactionList != null)
                {
                    model.SupplierName = model.InventoryPurchaseMasterAndTransactionList[0].SupplierName;
                    model.BillNumber = model.InventoryPurchaseMasterAndTransactionList[0].BillNumber;
                    //model.CustomerAddress = model.InventoryPurchaseMasterAndTransactionList[0].CustomerAddress;
                    // model.EstimationAmount =Math.Round((from a in model.InventoryEstimationMasterAndDetailsList select (a.Rate * a.Quantity)).Sum(),2);
                    model.BillAmount = model.InventoryPurchaseMasterAndTransactionList[0].BillAmount;
                    model.TransactionDate = model.InventoryPurchaseMasterAndTransactionList[0].TransactionDate;
                }

                return PartialView("/Views/Inventory/InventoryPurchaseMasterAndTransaction/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        ////Non-Action method to fetch list of location
        protected List<InventoryLocationMaster> GetLocationList(string balancesheet)
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
        //view Purchase
        [NonAction]
        protected List<InventoryPurchaseMasterAndTransaction> GetInventoryEstimationMasterAndDetails(int id,int selectedBalsheet)
        {
            InventoryPurchaseMasterAndTransactionSearchRequest searchRequest = new InventoryPurchaseMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            searchRequest.AccBalsheetMstID = Convert.ToInt16(selectedBalsheet);
            List<InventoryPurchaseMasterAndTransaction> listDumpAndShrinkDetails = new List<InventoryPurchaseMasterAndTransaction>();
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> baseEntityCollectionResponse = _InventoryPurchaseMasterAndTransactionServiceAccess.GetPurchaseMasterAndTransaction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDumpAndShrinkDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listDumpAndShrinkDetails;
        }
        ////Non-Action method to fetch list of batch
        [HttpPost]
        public JsonResult GetBatchNumberOfItem(string term, int itemID)
        {
            var data = GetBatchList(term, itemID);
            var result = (from r in data
                          select new
                          {
                              id = r.BatchID,
                              name = r.BatchNumber,
                              batchQuantity = r.BatchQuantity,
                              expiryDate = r.ExpiryDate, 
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryItemMaster> GetBatchList(string term, int itemID)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemID = itemID;
            searchRequest.SearchWord = term;
            List<InventoryItemMaster> listFeeSubType = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetBatchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }


        ////Non-Action method to fetch list of items
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string locationID)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(locationID) ? locationID : null);
            searchRequest.SearchWord = term;
            List<InventoryItemMaster> listFeeSubType = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
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
                              IsExpiry = r.IsExpiry,
                              IsTaxInclusive = r.IsTaxInclusive,
                              GenTaxGroupMasterID = r.GenTaxGroupMasterID,
                              TaxRatePercentage = r.TaxRatePercentage

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CheckFocusOnAction(string actionOn, string data)
        {
            InventoryPurchaseMasterAndTransactionViewModel model = new InventoryPurchaseMasterAndTransactionViewModel();
            model.InventoryPurchaseMasterAndTransactionDTO = new InventoryPurchaseMasterAndTransaction();
            model.InventoryPurchaseMasterAndTransactionDTO.ActionOn = actionOn;
            var splitedData = data.Split('~');
            model.InventoryPurchaseMasterAndTransactionDTO.ActionName = splitedData[0];
            model.InventoryPurchaseMasterAndTransactionDTO.ItemID = Convert.ToInt32(splitedData[1]);
            model.InventoryPurchaseMasterAndTransactionDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = _InventoryPurchaseMasterAndTransactionServiceAccess.CheckFocusOnAction(model.InventoryPurchaseMasterAndTransactionDTO);
            if (response != null && response.Entity != null)
            {
                model.InventoryPurchaseMasterAndTransactionDTO.ActionID = response.Entity.ActionID;
                model.InventoryPurchaseMasterAndTransactionDTO.ExpiryDate = response.Entity.ExpiryDate;
            }
            return Json(model.InventoryPurchaseMasterAndTransactionDTO.ActionID + "~" + model.InventoryPurchaseMasterAndTransactionDTO.ExpiryDate, JsonRequestBehavior.AllowGet);
        }
       
        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventoryPurchaseMasterAndTransaction> GetListInventoryPurchaseMasterAndTransaction(string SelectedBalanceSheet, out int TotalRecords)
        {
            List<InventoryPurchaseMasterAndTransaction> listInventoryPurchaseMasterAndTransaction = new List<InventoryPurchaseMasterAndTransaction>();
            InventoryPurchaseMasterAndTransactionSearchRequest searchRequest = new InventoryPurchaseMasterAndTransactionSearchRequest();
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
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);
            }
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> baseEntityCollectionResponse = _InventoryPurchaseMasterAndTransactionServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryPurchaseMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryPurchaseMasterAndTransaction;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryPurchaseMasterAndTransaction> filteredInventoryPurchaseMasterAndTransaction;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or BillAmount Like '%" + param.sSearch + "%'  or SupplierName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BillNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or BillAmount Like '%" + param.sSearch + "%'  or SupplierName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "BillAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or BillAmount Like '%" + param.sSearch + "%'  or SupplierName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "SupplierName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or BillAmount Like '%" + param.sSearch + "%'  or SupplierName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet) )
            {
                filteredInventoryPurchaseMasterAndTransaction = GetListInventoryPurchaseMasterAndTransaction(SelectedBalanceSheet, out TotalRecords);
            }
            else
            {
                filteredInventoryPurchaseMasterAndTransaction = new List<InventoryPurchaseMasterAndTransaction>();
                TotalRecords = 0;
            }
            var records = filteredInventoryPurchaseMasterAndTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TransactionDate), Convert.ToString(c.BillNumber), Convert.ToString(c.BillAmount), Convert.ToString(c.SupplierName), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

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
    public class InventoryItemSaleReturnMasterAndTransactionController : BaseController
    {

        #region ------------CONTROLLER CLASS VARIABLE------------
        IInventoryItemSaleReturnMasterServiceAccess _inventoryItemSaleReturnMasterServiceAccess = null;
        private readonly ILogger _logException;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventoryItemSaleReturnMasterAndTransactionController()
        {
            _inventoryItemSaleReturnMasterServiceAccess = new InventoryItemSaleReturnMasterServiceAccess();
        }

        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryItemSaleReturnMasterAndTransaction/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpGet]
        public ActionResult List(string actionMode, string invBufferSalesMasterID, string selectedBalsheet)
        {
            try
            {
                InventoryItemSaleReturnMasterViewModel model = new InventoryItemSaleReturnMasterViewModel();
                if (Convert.ToInt32(invBufferSalesMasterID) > 0 && Convert.ToInt32(selectedBalsheet) > 0)
                {
                    int InvBufferSalesMasterID = Convert.ToInt32(invBufferSalesMasterID);
                    int BalanceSheetID = Convert.ToInt32(selectedBalsheet);
                    model.InventoryReturnItemDetailList = GetInventoryItemReturnDetailList(InvBufferSalesMasterID, BalanceSheetID);

                    return PartialView("/Views/Inventory/InventoryItemSaleReturnMasterAndTransaction/List.cshtml", model);
                }
                else if (Convert.ToInt32(Session["BalancesheetID"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
                {
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    model.BalanceSheetID = Convert.ToInt32(Session["BalancesheetID"]); ;
                    return PartialView("/Views/Inventory/InventoryItemSaleReturnMasterAndTransaction/List.cshtml", model);
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


        public ActionResult Create(InventoryItemSaleReturnMasterViewModel model)
        {
            try
            {
                if (model != null && model.InventoryItemSaleReturnMasterDTO != null)
                {
                    model.InventoryItemSaleReturnMasterDTO.ConnectionString = _connectioString;

                    model.InventoryItemSaleReturnMasterDTO.BillNumber = model.BillNumber;
                    model.InventoryItemSaleReturnMasterDTO.LocationID = model.LocationID;
                    model.InventoryItemSaleReturnMasterDTO.AccountSessionID = 0;                //AccountSessionID calculate in procedure.
                    model.InventoryItemSaleReturnMasterDTO.NetAmount = model.NetAmount;
                    model.InventoryItemSaleReturnMasterDTO.DeliveryCharge = model.DeliveryCharge;
                    model.InventoryItemSaleReturnMasterDTO.BalanceSheetID = model.BalanceSheetID;
                    model.InventoryItemSaleReturnMasterDTO.CounterLogID = model.CounterLogID;
                    model.InventoryItemSaleReturnMasterDTO.SalesReturnAmount = model.SalesReturnAmount;
                    model.InventoryItemSaleReturnMasterDTO.TaxAmount = model.TotalTaxAmount;
                    model.InventoryItemSaleReturnMasterDTO.RoundUpAmount = model.RoundUpAmount;
                    model.InventoryItemSaleReturnMasterDTO.TotalDiscountAmount = model.TotalDiscountAmount;
                    model.InventoryItemSaleReturnMasterDTO.CustomerID = model.CustomerID;
                    model.InventoryItemSaleReturnMasterDTO.CustomerName = model.CustomerName != null ? model.CustomerName : "";
                    model.InventoryItemSaleReturnMasterDTO.CustomerType = model.CustomerType;
                    model.InventoryItemSaleReturnMasterDTO.ReturnItemDetailxml = model.ReturnItemDetailxml;

                    model.InventoryItemSaleReturnMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<InventoryItemSaleReturnMaster> response = _inventoryItemSaleReturnMasterServiceAccess.InsertInventoryItemSaleReturnMaster(model.InventoryItemSaleReturnMasterDTO);
                    model.InventoryItemSaleReturnMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryItemSaleReturnMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }


        }



        #endregion

        // AjaxHandler Method
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string selectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            //string sortDirection = "desc";

            IEnumerable<InventoryItemSaleReturnMasterViewModel> itemSaleReturnMasterVM;
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
                        //this "if" block is added for search functionality
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.BillNumber Like '%" + param.sSearch + "%' or A.BillAmount Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";
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
                        //this "if" block is added for search functionality
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.BillNumber Like '%" + param.sSearch + "%' or A.BillAmount Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";
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
                        //this "if" block is added for search functionality
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.BillNumber Like '%" + param.sSearch + "%' or A.BillAmount Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";
                    }
                    break;

                case 3:
                    _sortBy = "CustomerName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        //this "if" block is added for search functionality
                        _searchBy = "A.TransactionDate Like '%" + param.sSearch + "%' or A.BillNumber Like '%" + param.sSearch + "%' or A.BillAmount Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(selectedBalanceSheet))
            {
                itemSaleReturnMasterVM = GetInventoryItemSaleReturnMasterDetails(selectedBalanceSheet, out TotalRecords);
            }
            else
            {
                itemSaleReturnMasterVM = new List<InventoryItemSaleReturnMasterViewModel>();
                TotalRecords = 0;
            }
            if ((itemSaleReturnMasterVM.Count()) == 0)
            {
                itemSaleReturnMasterVM = new List<InventoryItemSaleReturnMasterViewModel>();
                TotalRecords = 0;
            }
            var displayedPosts = itemSaleReturnMasterVM.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.TransactionDate.ToString(), c.BillNumber.ToString(), c.SalesReturnAmount.ToString(), c.CustomerName != null ? c.CustomerName.ToString() : "", (c.InvBufferSalesMasterID).ToString(), (c.BalanceSheetID).ToString() };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //Non Action Method
        #region
        public IEnumerable<InventoryItemSaleReturnMasterViewModel> GetInventoryItemSaleReturnMasterDetails(string selectedBalanceSheet, out int TotalRecords)
        {
            InventoryItemSaleReturnMasterSearchRequest itemSaleReturnMasterSR = new InventoryItemSaleReturnMasterSearchRequest();
            itemSaleReturnMasterSR.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            itemSaleReturnMasterSR.BalanceSheetID = !string.IsNullOrEmpty(selectedBalanceSheet) ? Convert.ToInt32(selectedBalanceSheet) : 0;
            // checks actionMode i.e. Insert or Update //
            if (Enum.TryParse(_actionMode, out actionModeEnum))
            {
                if (actionModeEnum == ActionModeEnum.Insert)
                {
                    // parameters for SelectAll procedures under Insert or Update mode condition
                    itemSaleReturnMasterSR.SortBy = "A.CreatedDate";
                    itemSaleReturnMasterSR.StartRow = 0;
                    itemSaleReturnMasterSR.EndRow = 10;
                    itemSaleReturnMasterSR.SearchBy = string.Empty;
                    itemSaleReturnMasterSR.SortDirection = "Desc";
                }
            }
            else
            {
                itemSaleReturnMasterSR.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                itemSaleReturnMasterSR.StartRow = _startRow;
                itemSaleReturnMasterSR.EndRow = _startRow + _rowLength;
                itemSaleReturnMasterSR.SearchBy = _searchBy;
                itemSaleReturnMasterSR.SortDirection = _sortDirection;
            }
            List<InventoryItemSaleReturnMasterViewModel> listItemSaleReturnMasterVM = new List<InventoryItemSaleReturnMasterViewModel>();
            List<InventoryItemSaleReturnMaster> listItemSaleReturnMaster = new List<InventoryItemSaleReturnMaster>();
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityItemSaleReturnMaster = _inventoryItemSaleReturnMasterServiceAccess.GetInventoryItemSaleReturnMasterBySearch(itemSaleReturnMasterSR);

            if (baseEntityItemSaleReturnMaster != null)
            {
                if (baseEntityItemSaleReturnMaster.CollectionResponse != null && baseEntityItemSaleReturnMaster.CollectionResponse.Count > 0)
                {
                    listItemSaleReturnMaster = baseEntityItemSaleReturnMaster.CollectionResponse.ToList();
                    foreach (InventoryItemSaleReturnMaster item in listItemSaleReturnMaster)
                    {
                        InventoryItemSaleReturnMasterViewModel itemVM = new InventoryItemSaleReturnMasterViewModel();
                        itemVM.InventoryItemSaleReturnMasterDTO = item;
                        listItemSaleReturnMasterVM.Add(itemVM);
                    }
                }
            }
            TotalRecords = baseEntityItemSaleReturnMaster.TotalRecords;
            return listItemSaleReturnMasterVM;
        }

        public List<InventoryItemSaleReturnMaster> GetInventoryItemReturnDetailList(int InvBufferSalesMasterID, int BalanceSheetID)
        {
            InventoryItemSaleReturnMasterSearchRequest searchRequest = new InventoryItemSaleReturnMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.InvBufferSalesMasterID = InvBufferSalesMasterID;
            searchRequest.BalanceSheetID = BalanceSheetID;
            List<InventoryItemSaleReturnMaster> listSaleReturnItem = new List<InventoryItemSaleReturnMaster>();
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollectionResponse = _inventoryItemSaleReturnMasterServiceAccess.GetInventoryItemSaleReturnMasterByID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleReturnItem = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleReturnItem;
        }
        #endregion
    }
}

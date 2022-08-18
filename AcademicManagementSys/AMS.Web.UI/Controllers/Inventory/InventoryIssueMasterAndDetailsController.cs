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
    public class InventoryIssueMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryIssueMasterAndDetailsServiceAccess _InventoryIssueMasterAndDetailsServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
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
        public InventoryIssueMasterAndDetailsController()
        {
            _InventoryIssueMasterAndDetailsServiceAccess = new InventoryIssueMasterAndDetailsServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
            _accountSessionMasterServiceAccess = new AccountSessionMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryIssueMasterAndDetails/Index.cshtml");
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
                if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
                {
                    InventoryIssueMasterAndDetailsViewModel model = new InventoryIssueMasterAndDetailsViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    model.InventoryLocationMasterFromList = GetInventoryLocationMasterDetails(0);
                    model.InventoryLocationMasterToList = GetInventoryLocationMasterDetails(0); ;// GetInventoryLocationMasterDetails(Convert.ToInt16(Session["BalancesheetID"]));

                    return PartialView("/Views/Inventory/InventoryIssueMasterAndDetails/List.cshtml", model);
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
        public ActionResult Create(InventoryIssueMasterAndDetailsViewModel model)
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
                        model.InventoryIssueMasterAndDetailsDTO.CentreCode = response1.Entity.CentreCode;
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
                        model.InventoryIssueMasterAndDetailsDTO.AccountSessionID = response2.Entity.ID;
                    }
                    //////////////////////////////////
                    model.InventoryIssueMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.InventoryIssueMasterAndDetailsDTO.SelectedBalanceSheet = Convert.ToString(Session["BalancesheetID"]);
                    model.InventoryIssueMasterAndDetailsDTO.TransactionDate = Convert.ToString(DateTime.Now);
                    model.InventoryIssueMasterAndDetailsDTO.IssueFromLocationID = model.IssueFromLocationID;
                    model.InventoryIssueMasterAndDetailsDTO.IssueToLocationID = model.IssueToLocationID;
                    model.InventoryIssueMasterAndDetailsDTO.ParameterXml = model.ParameterXml;
                    model.InventoryIssueMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryIssueMasterAndDetails> response = _InventoryIssueMasterAndDetailsServiceAccess.InsertInventoryIssueMasterAndDetails(model.InventoryIssueMasterAndDetailsDTO);
                    model.InventoryIssueMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryIssueMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int issueMasterID)
        {
            try
            {
                InventoryIssueMasterAndDetailsViewModel model = new InventoryIssueMasterAndDetailsViewModel();
                model.InventoryIssueMasterAndDetailsDTO = new InventoryIssueMasterAndDetails();
                model.InventoryIssueMasterAndDetailsDTO.IssueMasterID = issueMasterID;
                return PartialView("/Views/Inventory/InventoryIssueMasterAndDetails/Delete.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult DeleteFeeType(InventoryIssueMasterAndDetailsViewModel model)
        {
            try
            {
                if (model.IssueMasterID > 0)
                {
                    InventoryIssueMasterAndDetails InventoryIssueMasterAndDetailsDTO = new InventoryIssueMasterAndDetails();
                    InventoryIssueMasterAndDetailsDTO.ConnectionString = _connectioString;
                    //InventoryIssueMasterAndDetailsDTO.ID = model.ID;
                    //InventoryIssueMasterAndDetailsDTO.IsFeeTypeTransaction = true;
                    InventoryIssueMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryIssueMasterAndDetails> response = _InventoryIssueMasterAndDetailsServiceAccess.DeleteInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetailsDTO);
                    model.InventoryIssueMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                    return Json(model.InventoryIssueMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region ------------CONTROLLER NON ACTION METHODS------------

        protected List<InventoryLocationMaster> GetInventoryLocationMasterDetails(Int16 accBalanceSheetID)
        {

            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryLocationMaster> listInventoryLocationMaster = new List<InventoryLocationMaster>();
            searchRequest.AccBalanceSheetID = accBalanceSheetID;
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryLocationMasterServiceAccess.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listInventoryLocationMaster;
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
                              unitCode = r.UnitCode
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventoryIssueMasterAndDetails> GetListInventoryIssueMasterAndDetails(out int TotalRecords)
        {
            List<InventoryIssueMasterAndDetails> listInventoryIssueMasterAndDetails = new List<InventoryIssueMasterAndDetails>();
            InventoryIssueMasterAndDetailsSearchRequest searchRequest = new InventoryIssueMasterAndDetailsSearchRequest();
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
            IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> baseEntityCollectionResponse = _InventoryIssueMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryIssueMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryIssueMasterAndDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryIssueMasterAndDetails> filteredInventoryIssueMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.TransactionDate Like '%" + param.sSearch + "%' or A.IssueNumber Like '%" + param.sSearch + "%'  or B.IssueFromLocationName Like '%" + param.sSearch + "%'  or C.IssueToLocationName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.IssueNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.TransactionDate Like '%" + param.sSearch + "%' or A.IssueNumber Like '%" + param.sSearch + "%'  or B.IssueFromLocationName Like '%" + param.sSearch + "%'  or C.IssueToLocationName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.IssueFromLocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.TransactionDate Like '%" + param.sSearch + "%' or A.IssueNumber Like '%" + param.sSearch + "%'  or B.IssueFromLocationName Like '%" + param.sSearch + "%'  or C.IssueToLocationName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "C.IssueToLocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(A.TransactionDate Like '%" + param.sSearch + "%' or A.IssueNumber Like '%" + param.sSearch + "%'  or B.IssueFromLocationName Like '%" + param.sSearch + "%'  or C.IssueToLocationName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredInventoryIssueMasterAndDetails = GetListInventoryIssueMasterAndDetails(out TotalRecords);

            if ((filteredInventoryIssueMasterAndDetails.Count()) == 0)
            {
                filteredInventoryIssueMasterAndDetails = new List<InventoryIssueMasterAndDetails>();
                TotalRecords = 0;
            }

            var records = filteredInventoryIssueMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TransactionDate), Convert.ToString(c.IssueNumber), Convert.ToString(c.IssueFromLocationName), Convert.ToString(c.IssueToLocationName), Convert.ToString(c.IssueMasterID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

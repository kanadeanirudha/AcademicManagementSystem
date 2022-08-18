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
    public class InventoryIssueMasterAndIssueDetailsController : BaseController
    {

        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryIssueMasterAndIssueDetailsServiceAccess _inventoryIssueMasterAndIssueDetailsServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
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

        public InventoryIssueMasterAndIssueDetailsController()
        {
            _inventoryIssueMasterAndIssueDetailsServiceAccess = new InventoryIssueMasterAndIssueDetailsServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
        }

        #endregion

        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            return View("/Views/Inventory/InventoryIssueMasterAndIssueDetails/Index.cshtml");
        }

        [HttpGet]
        public ActionResult List(string selectedBalsheet, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    IInventoryIssueMasterAndIssueDetailsViewModel model = new InventoryIssueMasterAndIssueDetailsViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Inventory/InventoryIssueMasterAndIssueDetails/List.cshtml", model);
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
            IInventoryIssueMasterAndIssueDetailsViewModel model = new InventoryIssueMasterAndIssueDetailsViewModel();
            model.InventoryIssueMasterAndIssueDetailsDTO.ConnectionString = _connectioString;
            // IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = _

            //List For Location.
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
            model.InventoryIssueMasterAndIssueDetailsDTO.TransactionDate = DateTime.UtcNow.ToString("dd-MMM-yyyy");

            return PartialView("/Views/Inventory/InventoryIssueMasterAndIssueDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryIssueMasterAndIssueDetailsViewModel model)
        {
            try
            {
                if (model.InventoryIssueMasterAndIssueDetailsDTO != null)
                {
                    model.InventoryIssueMasterAndIssueDetailsDTO.ConnectionString = _connectioString;
                    model.InventoryIssueMasterAndIssueDetailsDTO.InventoryIssueMasterID = 0;
                    model.InventoryIssueMasterAndIssueDetailsDTO.TransactionDate = model.TransactionDate;
                    model.InventoryIssueMasterAndIssueDetailsDTO.IssueFromLocationID = model.IssueFromLocationID;
                    model.InventoryIssueMasterAndIssueDetailsDTO.IssueToLocationID = model.IssueToLocationID;
                    model.InventoryIssueMasterAndIssueDetailsDTO.CentreCode = DBNull.Value.ToString();
                    model.InventoryIssueMasterAndIssueDetailsDTO.AccountSessionID = 0;
                    model.InventoryIssueMasterAndIssueDetailsDTO.BalanceSheetID = model.BalanceSheetID;
                    model.InventoryIssueMasterAndIssueDetailsDTO.IssueDetails = model.IssueDetails;
                    model.InventoryIssueMasterAndIssueDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = _inventoryIssueMasterAndIssueDetailsServiceAccess.InsertInventoryIssueMaster(model.InventoryIssueMasterAndIssueDetailsDTO);
                    model.InventoryIssueMasterAndIssueDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryIssueMasterAndIssueDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult View(int ID, int BalanceSheetID)
        {
            InventoryIssueMasterAndIssueDetailsViewModel model = new InventoryIssueMasterAndIssueDetailsViewModel();
            if (ID > 0 && BalanceSheetID > 0)
            {                
                model.InventoryIssueItemAndDetailsList = GetIssueItemAndDetailList(ID, BalanceSheetID);
               
            }
            return PartialView("/Views/Inventory/InventoryIssueMasterAndIssueDetails/ItemView.cshtml", model);
        }


        #endregion



        #region ------------CONTROLLER NON ACTION METHODS------------

        [NonAction]
        protected List<InventoryIssueMasterAndIssueDetails> GetIssueItemAndDetailList(int ID, int BalanceSheetID)
        {
            InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest = new InventoryIssueMasterAndIssueDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.InventoryIssueMasterID = ID;
            searchRequest.BalanceSheetID = Convert.ToInt16(BalanceSheetID);
            List<InventoryIssueMasterAndIssueDetails> listLocationMaster = new List<InventoryIssueMasterAndIssueDetails>();
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollectionResponse = _inventoryIssueMasterAndIssueDetailsServiceAccess.GetInventoryIssueMasterByID(searchRequest);
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
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int balancesheet)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryIssueMasterAndIssueDetailsServiceAccess.GetInventoryIssueLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        //Non-Action method to fetch list of items
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string locationID)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(locationID) ? locationID : null);
            searchRequest.SearchWord = term;
            List<InventoryItemMaster> listInventoryItemMaster = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemSearchList(searchRequest);
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
                              currentStockQty = r.CurrentStockQty
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventoryIssueMasterAndIssueDetails> GetListInventoryIssueMasterAndIssueDetails(string SelectedBalanceSheet, out int TotalRecords)
        {
            List<InventoryIssueMasterAndIssueDetails> listInventoryIssueMasterAndIssueDetails = new List<InventoryIssueMasterAndIssueDetails>();
            InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest = new InventoryIssueMasterAndIssueDetailsSearchRequest();
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
                    searchRequest.BalanceSheetID = Convert.ToInt16(SelectedBalanceSheet);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.BalanceSheetID = Convert.ToInt16(SelectedBalanceSheet);
            }
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollectionResponse = _inventoryIssueMasterAndIssueDetailsServiceAccess.GetInventoryIssueDetailsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryIssueMasterAndIssueDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryIssueMasterAndIssueDetails;
        }

        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string selectedBalanceSheetID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryIssueMasterAndIssueDetails> filteredInventoryIssueMasterAndIssueDetails;
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
                        _searchBy = "(B.LocationName Like '%" + param.sSearch + "%' or C.LocationName Like '%" + param.sSearch + "%' or A.TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "C.LocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(B.LocationName Like '%" + param.sSearch + "%' or C.LocationName Like '%" + param.sSearch + "%' or A.TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.LocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(B.LocationName Like '%" + param.sSearch + "%' or C.LocationName Like '%" + param.sSearch + "%' or A.TransactionDate Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if ((!string.IsNullOrEmpty(selectedBalanceSheetID) || Convert.ToString(Session["UserType"]) == "A"))
            {
                filteredInventoryIssueMasterAndIssueDetails = GetListInventoryIssueMasterAndIssueDetails(selectedBalanceSheetID, out TotalRecords);
            }
            else
            {
                filteredInventoryIssueMasterAndIssueDetails = new List<InventoryIssueMasterAndIssueDetails>();
                TotalRecords = 0;
            }
            if ((filteredInventoryIssueMasterAndIssueDetails.Count()) == 0)
            {
                filteredInventoryIssueMasterAndIssueDetails = new List<InventoryIssueMasterAndIssueDetails>();
                TotalRecords = 0;
            }
            var records = filteredInventoryIssueMasterAndIssueDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.IssueFromLocationName), Convert.ToString(c.IssueToLocationName), Convert.ToString(c.TransactionDate), Convert.ToString(c.InventoryIssueMasterID), Convert.ToString(c.BalanceSheetID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}

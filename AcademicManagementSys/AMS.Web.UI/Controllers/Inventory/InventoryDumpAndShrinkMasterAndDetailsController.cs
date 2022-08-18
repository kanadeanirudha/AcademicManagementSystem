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
    public class InventoryDumpAndShrinkMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryDumpAndShrinkMasterAndDetailsServiceAccess _InventoryDumpAndShrinkMasterAndDetailsServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
       // IAccountSessionMasterServiceAccess _accountSessionMasterServiceAccess = null;
        //IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
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
        public InventoryDumpAndShrinkMasterAndDetailsController()
        {
            _InventoryDumpAndShrinkMasterAndDetailsServiceAccess = new InventoryDumpAndShrinkMasterAndDetailsServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            //_accountSessionMasterServiceAccess = new AccountSessionMasterServiceAccess();
            //_accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryDumpAndShrinkMasterAndDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        [HttpGet]
        public ActionResult List(string selectedBalsheet,string locationId, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    IInventoryDumpAndShrinkMasterAndDetailsViewModel model = new InventoryDumpAndShrinkMasterAndDetailsViewModel();
                    model.LocationList = GetLocationList(selectedBalsheet);
                    model.LocationID =!string.IsNullOrEmpty(locationId) ? Convert.ToInt32(locationId):0;
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                    return PartialView("/Views/Inventory/InventoryDumpAndShrinkMasterAndDetails/List.cshtml", model);
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
            IInventoryDumpAndShrinkMasterAndDetailsViewModel model = new InventoryDumpAndShrinkMasterAndDetailsViewModel();
            return PartialView("/Views/Inventory/InventoryDumpAndShrinkMasterAndDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryDumpAndShrinkMasterAndDetailsViewModel model)
        {
            try
            {
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.BalanceSheetID = model.BalanceSheetID;
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.LocationID = model.LocationID;
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.DumpAndShrinkAmount = model.DumpAndShrinkAmount;
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.XMLstring = model.XMLstring;
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = _InventoryDumpAndShrinkMasterAndDetailsServiceAccess.InsertInventoryDumpAndShrinkMasterAndDetails(model.InventoryDumpAndShrinkMasterAndDetailsDTO);
                model.InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult View(int id)
        {
            try
            {
                IInventoryDumpAndShrinkMasterAndDetailsViewModel model = new InventoryDumpAndShrinkMasterAndDetailsViewModel();
                model.DumpAndShrinkDetailList = GetDumpAndShrinkDetails(id);
                return PartialView("/Views/Inventory/InventoryDumpAndShrinkMasterAndDetails/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult RequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
             IInventoryDumpAndShrinkMasterAndDetailsViewModel model = new InventoryDumpAndShrinkMasterAndDetailsViewModel();
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);
            model.DumpAndShrinkDetailList = GetDumpAndShrinkRecord(PersonID,Convert.ToInt32(TNMID));
            model.ID = model.DumpAndShrinkDetailList.Count > 0 ? model.DumpAndShrinkDetailList[0].ID : 0;
            model.BalanceSheetID = model.DumpAndShrinkDetailList.Count > 0 ? model.DumpAndShrinkDetailList[0].BalanceSheetID : 0;
            model.LocationID= model.DumpAndShrinkDetailList.Count > 0 ? model.DumpAndShrinkDetailList[0].LocationID: 0;


            return View("/Views/Inventory/InventoryDumpAndShrinkMasterAndDetails/RequestApproval.cshtml", model);
        }

        [HttpPost]
        public ActionResult RequestApproval(InventoryDumpAndShrinkMasterAndDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.InventoryDumpAndShrinkMasterAndDetailsDTO != null)
                    {
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.ConnectionString = _connectioString;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.PersonID = model.PersonID;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.LeaveApplicationID = model.LeaveApplicationID;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.ApprovalStatus = model.ApprovalStatus;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.CentreCode = model.CentreCode;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.LeaveMasterID = model.LeaveMasterID;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.StageSequenceNumber = model.StageSequenceNumber;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.Remark = model.Remark;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.SelectedIDs = model.SelectedIDs;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.TotalDays = model.TotalDays;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.TotalApprovedFullDay = model.TotalApprovedFullDay;
                        //model.InventoryDumpAndShrinkMasterAndDetailsDTO.TotalApprovedHalfDay = model.TotalApprovedHalfDay;
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = _InventoryDumpAndShrinkMasterAndDetailsServiceAccess.InsertApprovedDumpAndShrinkRecord(model.InventoryDumpAndShrinkMasterAndDetailsDTO);
                        model.InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.InventoryDumpAndShrinkMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

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

        [NonAction]
        protected List<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRecord(int personId, int taskNotificationMasterID)
        {
            InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest = new InventoryDumpAndShrinkMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<InventoryDumpAndShrinkMasterAndDetails> listDumpAndShrinkDetails = new List<InventoryDumpAndShrinkMasterAndDetails>();
            IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollectionResponse = _InventoryDumpAndShrinkMasterAndDetailsServiceAccess.GetDumpAndShrinkRequestForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDumpAndShrinkDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listDumpAndShrinkDetails;
        }



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

        [NonAction]
        protected List<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(int id)
        {
            InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest = new InventoryDumpAndShrinkMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<InventoryDumpAndShrinkMasterAndDetails> listDumpAndShrinkDetails = new List<InventoryDumpAndShrinkMasterAndDetails>();
            IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollectionResponse = _InventoryDumpAndShrinkMasterAndDetailsServiceAccess.GetDumpAndShrinkDetails(searchRequest);
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
        public List<InventoryDumpAndShrinkMasterAndDetails> GetListInventoryDumpAndShrinkMasterAndDetails(string SelectedBalanceSheet,string locationId, out int TotalRecords)
        {
            List<InventoryDumpAndShrinkMasterAndDetails> listInventoryDumpAndShrinkMasterAndDetails = new List<InventoryDumpAndShrinkMasterAndDetails>();
            InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest = new InventoryDumpAndShrinkMasterAndDetailsSearchRequest();
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
                    searchRequest.BalancesheetID =Convert.ToInt16( SelectedBalanceSheet);
                    searchRequest.LocationID = Convert.ToInt16(locationId);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.BalancesheetID = Convert.ToInt16(SelectedBalanceSheet);
                    searchRequest.LocationID = Convert.ToInt16(locationId);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.BalancesheetID = Convert.ToInt16(SelectedBalanceSheet);
                searchRequest.LocationID = Convert.ToInt16(locationId);
            }
            IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollectionResponse = _InventoryDumpAndShrinkMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryDumpAndShrinkMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryDumpAndShrinkMasterAndDetails;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet ,string locationId)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryDumpAndShrinkMasterAndDetails> filteredInventoryDumpAndShrinkMasterAndDetails;
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
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or DumpAndShrinkAmount Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DumpAndShrinkAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or DumpAndShrinkAmount Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if ((!string.IsNullOrEmpty(SelectedBalanceSheet) || Convert.ToString(Session["UserType"]) == "A") && !string.IsNullOrEmpty(locationId))
            {
                filteredInventoryDumpAndShrinkMasterAndDetails = GetListInventoryDumpAndShrinkMasterAndDetails( SelectedBalanceSheet,locationId,out TotalRecords);    
            }
            else
            {
                filteredInventoryDumpAndShrinkMasterAndDetails = new List<InventoryDumpAndShrinkMasterAndDetails>();
                TotalRecords = 0;
            }
            if ((filteredInventoryDumpAndShrinkMasterAndDetails.Count()) == 0)
            {
                filteredInventoryDumpAndShrinkMasterAndDetails = new List<InventoryDumpAndShrinkMasterAndDetails>();
                TotalRecords = 0;
            }

            var records = filteredInventoryDumpAndShrinkMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TransactionDate), Convert.ToString(Math.Round(c.DumpAndShrinkAmount,2)), Convert.ToString(c.ID), Convert.ToString(c.LocationID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

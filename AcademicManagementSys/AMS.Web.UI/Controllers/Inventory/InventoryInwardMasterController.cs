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
    public class InventoryInwardMasterController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IInventoryInWardMasterAndInWardDetailsServiceAccess _InventoryInWardMasterAndInWardDetailsServiceAccess = null;
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
        public InventoryInwardMasterController()
        {
            _InventoryInWardMasterAndInWardDetailsServiceAccess = new InventoryInWardMasterAndInWardDetailsServiceAccess();
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
                return View("/Views/Inventory/InventoryInWardMasterAndInWardDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }

        }

        [HttpGet]
        public ActionResult InwardRequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            IInventoryInWardMasterAndInWardDetailsViewModel model = new InventoryInWardMasterAndInWardDetailsViewModel();
            
            model.PersonID = Convert.ToInt32(PersonID);
            model.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            model.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            model.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            model.TaskCode = TaskCode;
            model.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            model.IsLastRecord = Convert.ToBoolean(IsLast);
            model.BalanceSheetID= Convert.ToInt32(Session["BalancesheetID"]);
            if (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IsOffLineApp"]) == 1)
            {
                model.TotalrowCount = GetInvSyncHistoryCount();                
            }
            else
            {
                model.TotalrowCount = 1;
            }

            if (model.TotalrowCount >= 1)
            {
                model.InWardMasterList = GetInWardRecord(PersonID, Convert.ToInt32(TNMID));
            }
            else
            {
                model.InWardMasterList = new List<InventoryInWardMasterAndInWardDetails>();
            }
            model.systemseeting = Getsystemseeting(model.BalanceSheetID);
            model.InventoryInWardMasterID = model.InWardMasterList.Count > 0 ? model.InWardMasterList[0].InventoryInWardMasterID : 0;
            model.IssueToLocationID = model.InWardMasterList.Count > 0 ? model.InWardMasterList[0].IssueToLocationID : 0;
            model.FieldName = model.systemseeting.Count > 0 ? model.systemseeting[0].FieldName : null;
            model.FieldValue = model.systemseeting.Count > 0 ? model.systemseeting[0].FieldValue : 0;
           
           

            return View("/Views/Inventory/InventoryInWardMasterAndInWardDetails/InwardRequestApproval.cshtml", model);
        }
        [HttpPost]
        public ActionResult InwardRequestApproval(InventoryInWardMasterAndInWardDetailsViewModel model)
        {
            try
            {
                
                    if (model != null && model.InventoryInWardMasterAndInWardDetailsDTO != null)
                    {
                        model.InventoryInWardMasterAndInWardDetailsDTO.ConnectionString = _connectioString;
                        model.InventoryInWardMasterAndInWardDetailsDTO.PersonID = model.PersonID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.CentreCode = null;
                        model.InventoryInWardMasterAndInWardDetailsDTO.IsLastRecord = Convert.ToBoolean(model.IsLastRecord);
                        model.InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.GeneralTaskReportingDetailsID = model.GeneralTaskReportingDetailsID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.StageSequenceNumber = model.StageSequenceNumber;
                        model.InventoryInWardMasterAndInWardDetailsDTO.FieldName = model.FieldName;
                        model.InventoryInWardMasterAndInWardDetailsDTO.FieldValue = model.FieldValue;
                        model.InventoryInWardMasterAndInWardDetailsDTO.XMLstring = model.XMLstring;
                        model.InventoryInWardMasterAndInWardDetailsDTO.IssueToLocationID = model.IssueToLocationID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.InventoryInWardMasterID = model.InventoryInWardMasterID;

                        ///////////////////////////////////
                        //For Current Account Session

                        AccountSessionMasterViewModel model2 = new AccountSessionMasterViewModel();
                        model2.AccountSessionMasterDTO = new AccountSessionMaster();
                        model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                        IBaseEntityResponse<AccountSessionMaster> response2 = _accountSessionMasterServiceAccess.GetCurrentAccountSession(model2.AccountSessionMasterDTO);
                        model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                        if (response2 != null && response2.Entity != null)
                        {
                            model.InventoryInWardMasterAndInWardDetailsDTO.AccountSessionID = response2.Entity.ID;
                        }
                        //////////////////////////////////


                        model.InventoryInWardMasterAndInWardDetailsDTO.IsOnlineOfflineFlag = Convert.ToBoolean(model.IsOnlineOfflineFlag);
                        model.InventoryInWardMasterAndInWardDetailsDTO.BalanceSheetID = model.BalanceSheetID;
                        model.InventoryInWardMasterAndInWardDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = _InventoryInWardMasterAndInWardDetailsServiceAccess.InsertInventoryInWardMaster(model.InventoryInWardMasterAndInWardDetailsDTO);
                        model.InventoryInWardMasterAndInWardDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.InventoryInWardMasterAndInWardDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        #region ------------CONTROLLER NON ACTION METHODS------------

        [NonAction]
        protected List<InventoryInWardMasterAndInWardDetails> GetInWardRecord(int personId, int taskNotificationMasterID)
        {
            InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest = new InventoryInWardMasterAndInWardDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Onlinedb.ConnectionString"]);
            searchRequest.PersonID = personId;
            searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
            List<InventoryInWardMasterAndInWardDetails> listInWardMasterAndInWardDetails = new List<InventoryInWardMasterAndInWardDetails>();
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollectionResponse = _InventoryInWardMasterAndInWardDetailsServiceAccess.GetInWardRequestForApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInWardMasterAndInWardDetails;
        }
        protected List<InventoryInWardMasterAndInWardDetails> Getsystemseeting(int BalancesheetID)
        {
            InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest = new InventoryInWardMasterAndInWardDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
             searchRequest.BalanceSheetID =BalancesheetID;
            List<InventoryInWardMasterAndInWardDetails> listInWardMasterAndInWardDetails = new List<InventoryInWardMasterAndInWardDetails>();
          
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollectionResponse = _InventoryInWardMasterAndInWardDetailsServiceAccess.GetInvSystemSetting(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInWardMasterAndInWardDetails;
        }
        [HttpPost]
        public int GetInvSyncHistoryCount()
        {
            InventoryInWardMasterAndInWardDetailsViewModel model = new InventoryInWardMasterAndInWardDetailsViewModel();
            model.InventoryInWardMasterAndInWardDetailsDTO = new InventoryInWardMasterAndInWardDetails();
            model.InventoryInWardMasterAndInWardDetailsDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = _InventoryInWardMasterAndInWardDetailsServiceAccess.GetInvSyncHistoryCount(model.InventoryInWardMasterAndInWardDetailsDTO);
            return(response != null && response.Entity != null) ?  response.Entity.TotalrowCount : 0;
        }

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

        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventoryInWardMasterAndInWardDetails> GetListInventoryInWardMasterAndInWardDetails(out int TotalRecords)
        {
            List<InventoryInWardMasterAndInWardDetails> ListInventoryInWardMasterAndInWardDetails = new List<InventoryInWardMasterAndInWardDetails>();
            InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest = new InventoryInWardMasterAndInWardDetailsSearchRequest();
            InventoryInWardMasterAndInWardDetailsViewModel model = new InventoryInWardMasterAndInWardDetailsViewModel();
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
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollectionResponse = _InventoryInWardMasterAndInWardDetailsServiceAccess.GetInventoryInWardMasterBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
          //  model.InventoryInwardDetailsList = ListInventoryInWardMasterAndInWardDetails;
            return ListInventoryInWardMasterAndInWardDetails;
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

            IEnumerable<InventoryInWardMasterAndInWardDetails> filteredInventoryIssueMasterAndDetails;
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

           
            filteredInventoryIssueMasterAndDetails = GetListInventoryInWardMasterAndInWardDetails(out TotalRecords);
            //filteredInventoryIssueMasterAndDetails.Count();
            if ((filteredInventoryIssueMasterAndDetails.Count()) == 0)
            {
                filteredInventoryIssueMasterAndDetails = new List<InventoryInWardMasterAndInWardDetails>();
                TotalRecords = 0;
            }
            

            var records = filteredInventoryIssueMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.InventoryInWardMasterID)};
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
        #endregion
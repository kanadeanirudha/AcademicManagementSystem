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
    public class InventoryOpeningBalanceController : BaseController
    {
        IInventoryOpeningBalanceServiceAccess _InventoryOpeningBalanceServiceAccess = null;
        IInventoryIssueMasterAndIssueDetailsServiceAccess _inventoryIssueMasterAndIssueDetailsServiceAccess = null;
        IInventoryItemCategoryMasterServiceAccess _InventoryItemCategoryMasterServiceAccess = null;
        IGeneralUnitMasterServiceAccess _generalUnitMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryOpeningBalanceController()
        {
            _InventoryOpeningBalanceServiceAccess = new InventoryOpeningBalanceServiceAccess();
            _InventoryItemCategoryMasterServiceAccess = new InventoryItemCategoryMasterServiceAccess();
            _generalUnitMasterServiceAcess = new GeneralUnitMasterServiceAccess();
            _inventoryIssueMasterAndIssueDetailsServiceAccess = new InventoryIssueMasterAndIssueDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryOpeningBalance/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }

        }

        public ActionResult List(string centerCode, string selectedBalsheet, string CategoryCode)
        {
            try
            {
                InventoryOpeningBalanceViewModel model = new InventoryOpeningBalanceViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //List For Location.
                    List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                    List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                    foreach (InventoryLocationMaster item in locationMasterList)
                    {
                        listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
                    model.ListGetCategoryCode = GetListGetCategoryCode();
                    model.CategoryCode = CategoryCode;
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }
                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    //List For Location.
                    List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(Convert.ToInt32(Session["BalancesheetID"]));
                    List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                    foreach (InventoryLocationMaster item in locationMasterList)
                    {
                        listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                    }

                    ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
                    model.SelectedCentreCode = centerCode;
                    model.ListGetCategoryCode = GetListGetCategoryCode();
                    model.CategoryCode = CategoryCode;
                }
               
                if (!string.IsNullOrEmpty(selectedBalsheet))
                {
                   
                    model.AccountSessionMasterDTO = GetCurrentAccountSession();
                    if (model.AccountSessionMasterDTO != null)
                    {
                        var from = model.AccountSessionMasterDTO.SessionStartDatetime.Split(' ');
                        var to = model.AccountSessionMasterDTO.SessionEndDatetime.Split(' ');
                        model.SessionName = from[2] + " - " + to[2];
                        model.SessionID = model.AccountSessionMasterDTO.ID;
                    }
                    else
                    {
                        model.SessionName = "Session not defined !";
                    }
                    

                }
                return PartialView("/Views/Inventory/InventoryOpeningBalance/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult List(InventoryOpeningBalanceViewModel model)
        {
            try
            {
                if (model != null && model.InventoryOpeningBalanceDTO != null)
                {
                    model.InventoryOpeningBalanceDTO.ConnectionString = _connectioString;
                    model.InventoryOpeningBalanceDTO.SelectedXml = model.SelectedXml;
                    model.InventoryOpeningBalanceDTO.SessionID = model.SessionID;
                    model.InventoryOpeningBalanceDTO.SelectedCentreCode = model.SelectedCentreCode;
                    model.InventoryOpeningBalanceDTO.BalanceSheetID = model.BalanceSheetID;
                    model.InventoryOpeningBalanceDTO.CategoryCode = model.CategoryCode;
                    model.InventoryOpeningBalanceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    string aa = model.SelectedCentreCode;

                    string[] Centre_code = model.SelectedCentreCode.Split(':');
                    //searchRequest.CentreCode = Centre_code[0];


                    model.InventoryOpeningBalanceDTO.CentreCode = Centre_code[0];

                    model.SelectedCentreCode = aa;

                    IBaseEntityResponse<InventoryOpeningBalance> response = _InventoryOpeningBalanceServiceAccess.InsertInventoryOpeningBalance(model.InventoryOpeningBalanceDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model, JsonRequestBehavior.AllowGet);
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


        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryOpeningBalance> GetInventoryOpeningBalance(string centerCode, string SelectedSessionID, string SelectedBalanceSheet, string CategoryCode, out int TotalRecords)
        {
            List<InventoryOpeningBalance> listInventoryOpeningBalance = new List<InventoryOpeningBalance>();
            InventoryOpeningBalanceSearchRequest searchRequest = new InventoryOpeningBalanceSearchRequest();
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
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    searchRequest.BalanceSheetID = Convert.ToInt16(SelectedBalanceSheet);
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.SessionID = Convert.ToInt32(SelectedSessionID);

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.BalanceSheetID = Convert.ToInt16(SelectedBalanceSheet);
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.SessionID = Convert.ToInt32(SelectedSessionID);

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                searchRequest.BalanceSheetID = Convert.ToInt16(SelectedBalanceSheet);
                string[] Centre_code = centerCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                searchRequest.CategoryCode = CategoryCode;
                searchRequest.SessionID = Convert.ToInt32(SelectedSessionID);


            }
            IBaseEntityCollectionResponse<InventoryOpeningBalance> baseEntityCollectionResponse = _InventoryOpeningBalanceServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryOpeningBalance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryOpeningBalance;
        }

        protected List<InventoryItemCategoryMaster> GetListGetCategoryCode()
        {

            InventoryItemCategoryMasterSearchRequest searchRequest = new InventoryItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryItemCategoryMaster> listCategoryCodeMaster = new List<InventoryItemCategoryMaster>();
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> baseEntityCollectionResponse = _InventoryItemCategoryMasterServiceAccess.GetInventoryItemCategoryMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCategoryCodeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listCategoryCodeMaster;
        }


        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedBalanceSheet, string CategoryCode, string SelectedSessionID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryOpeningBalance> filteredInventoryOpeningBalance;
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
                        _searchBy = "A.ItemName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredInventoryOpeningBalance = GetInventoryOpeningBalance(SelectedCentreCode, SelectedSessionID, SelectedBalanceSheet, CategoryCode, out TotalRecords);
            }
            else
            {
                filteredInventoryOpeningBalance = new List<InventoryOpeningBalance>();
                TotalRecords = 0;
            }
            if ((filteredInventoryOpeningBalance.Count()) == 0)
            {
                filteredInventoryOpeningBalance = new List<InventoryOpeningBalance>();
                TotalRecords = 0;
            }

            var records = filteredInventoryOpeningBalance.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ItemName.ToString(), c.OpeningAmount.ToString(),c.StatusFlag.ToString(),c.ItemID.ToString(),c.StockMasterID.ToString()};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}



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
    public class AccountBalancesheetMasterController : BaseController
    {
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        IAccountBalancesheetTypeMasterServiceAccess _accountBalancesheetTypeMasterServiceAccess = null;

        string _centreCode = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountBalancesheetMasterController()
        {
            _accountBalancesheetTypeMasterServiceAccess = new AccountBalancesheetTypeMasterServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();

        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult List(string centerCode, string actionMode)
        {
            try
            {

                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByFinanceManager(AdminRoleMasterID);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                model.SelectedCentreCode = centerCode;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("List", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create new balance sheet according to centre code
        /// </summary>
        /// <param name="Centre Code"></param>
        /// <returns>Account Balance Sheet View Model</returns>
        [HttpGet]
        public ActionResult Create(string CentreCode, string BalsheetTypeDetails)
        {
            try
            {
                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
                string[] splitBalsheetTypeDetails = BalsheetTypeDetails.Split(':');

                model.CentreCode = CentreCode;
                model.AccBalsheetTypeID = Convert.ToByte(splitBalsheetTypeDetails[0]);
                model.AccBalsheetTypeDesc = splitBalsheetTypeDetails[1].Replace('~', ' '); ;
                model.CentreName = splitBalsheetTypeDetails[2].Replace('~', ' ');

                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccBalsheetMasterDTO != null)
                    {
                        model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                        model.AccBalsheetMasterDTO.AccBalsheetCode = model.AccBalsheetCode;
                        model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = model.AccBalsheetHeadDesc;
                        model.AccBalsheetMasterDTO.AccBalsheetTypeID = model.AccBalsheetTypeID;
                        model.AccBalsheetMasterDTO.CentreCode = model.CentreCode;
                        model.AccBalsheetMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterServiceAccess.InsertAccBalsheetMaster(model.AccBalsheetMasterDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        [HttpGet]
        public ActionResult Edit(Int16 id, string CentreCode)
        {
            try
            {
                AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
                model.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
                model.AccBalsheetMasterDTO.ID = id;
                model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterServiceAccess.SelectByID(model.AccBalsheetMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.AccBalsheetMasterDTO.ID = response.Entity.ID;
                    model.AccBalsheetMasterDTO.AccBalsheetCode = response.Entity.AccBalsheetCode;
                    model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = response.Entity.AccBalsheetHeadDesc;
                    model.AccBalsheetMasterDTO.AccBalsheetTypeDesc = response.Entity.AccBalsheetTypeDesc;
                    model.AccBalsheetMasterDTO.AccBalsheetTypeID = response.Entity.AccBalsheetTypeID;
                    model.AccBalsheetMasterDTO.CreatedBy = response.Entity.CreatedBy;
                    model.AccBalsheetMasterDTO.CreatedDate = response.Entity.CreatedDate;
                    model.AccBalsheetMasterDTO.IsActive = response.Entity.IsActive;
                    model.AccBalsheetMasterDTO.CentreCode = CentreCode;
                    model.AccBalsheetMasterDTO.CentreName = response.Entity.CentreName;
                }

                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AccBalsheetMasterDTO != null)
                    {
                        model.AccBalsheetMasterDTO.ConnectionString = _connectioString;
                        model.AccBalsheetMasterDTO.AccBalsheetCode = model.AccBalsheetCode;
                        model.AccBalsheetMasterDTO.AccBalsheetHeadDesc = model.AccBalsheetHeadDesc;
                        model.AccBalsheetMasterDTO.AccBalsheetTypeID = model.AccBalsheetTypeID;
                        model.AccBalsheetMasterDTO.CentreCode = model.CentreCode;
                        model.AccBalsheetMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterServiceAccess.UpdateAccBalsheetMaster(model.AccBalsheetMasterDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        [HttpGet]
        public ActionResult Delete(Int16 ID)
        {
            AccountBalancesheetMasterViewModel model = new AccountBalancesheetMasterViewModel();
            model.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
            model.AccBalsheetMasterDTO.ID = ID;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(AccountBalancesheetMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    AccountBalancesheetMaster accountBalancesheetMasterDTO = new AccountBalancesheetMaster();
                    accountBalancesheetMasterDTO.ConnectionString = _connectioString;
                    accountBalancesheetMasterDTO.ID = model.ID;
                    IBaseEntityResponse<AccountBalancesheetMaster> response = _accountBalancesheetMasterServiceAccess.DeleteAccBalsheetMaster(accountBalancesheetMasterDTO);
                    model.AccBalsheetMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.AccBalsheetMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region Methods
        [NonAction]
        public List<AccountBalancesheetMaster> GetListAccountBalancesheetMaster(string centerCode, out int TotalRecords)
        {
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
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
                    searchRequest.CentreCode = centerCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centerCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centerCode;
            }
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountBalancesheetMaster;
        }

        [NonAction]
        public List<AccountBalancesheetTypeMaster> GetListAccountBalancesheetTypeMaster()
        {
            AccountBalancesheetTypeMasterSearchRequest searchRequest = new AccountBalancesheetTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<AccountBalancesheetTypeMaster> listAccountBalancesheetTypeMaster = new List<AccountBalancesheetTypeMaster>();
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> baseEntityCollectionResponse = _accountBalancesheetTypeMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetTypeMaster;
        }

        [NonAction]
        public AccountBalancesheetMasterViewModel GetAccountBalancesheetMaster()
        {
            AccountBalancesheetMasterViewModel accountBalancesheetMasterViewModel = new AccountBalancesheetMasterViewModel();
            List<AccountBalancesheetTypeMaster> listAccountBalancesheetTypeMaster = new List<AccountBalancesheetTypeMaster>();
            AccountBalancesheetTypeMasterSearchRequest searchRequest = new AccountBalancesheetTypeMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); // Set parameter
            IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> baseEntityCollectionResponse = _accountBalancesheetTypeMasterServiceAccess.GetBySearch(searchRequest); //Get Result From Database
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    accountBalancesheetMasterViewModel.AccountBalancesheetTypeMasterDTO = listAccountBalancesheetTypeMaster;
                }
            }
            return accountBalancesheetMasterViewModel;
        }
        #endregion

        #region Ajax Handler
        /// <summary>
        /// AJAX Method for binding List Account Balance Sheet master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<AccountBalancesheetMaster> filteredAccountBalanceSheetMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "AccBalsheetTypeDesc";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccBalsheetTypeDesc Like '%" + param.sSearch + "%' or AccBalsheetHeadDesc Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredAccountBalanceSheetMaster = GetListAccountBalancesheetMaster(SelectedCentreCode, out TotalRecords);
            }
            else
            {
                filteredAccountBalanceSheetMaster = new List<AccountBalancesheetMaster>();
                TotalRecords = 0;
            }
            var records = filteredAccountBalanceSheetMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.AccBalsheetTypeDesc), Convert.ToString(c.ID), Convert.ToString(c.StatusFlag), Convert.ToString(c.AccBalsheetHeadDesc), Convert.ToString(c.AccBalsheetTypeID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

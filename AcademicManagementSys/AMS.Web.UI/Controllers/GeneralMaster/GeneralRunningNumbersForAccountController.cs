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

namespace AMS.Web.UI.Controllers
{
    public class GeneralRunningNumbersForAccountController : BaseController
    {
        IGeneralRunningNumbersForAccountServiceAccess _GeneralRunningNumbersForAccountServiceAccess = null;
        IGeneralTaskModelServiceAccess _GeneralTaskModelServiceAccess = null;
        IGeneralRunningNumbersForAccountViewModel _GeneralRunningNumbersForAccountViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralRunningNumbersForAccountController()
        {
            _GeneralRunningNumbersForAccountServiceAccess = new GeneralRunningNumbersForAccountServiceAccess();
            _GeneralRunningNumbersForAccountViewModel = new GeneralRunningNumbersForAccountViewModel();
            _GeneralTaskModelServiceAccess = new GeneralTaskModelServiceAccess(); 
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                GeneralRunningNumbersForAccountViewModel model = new GeneralRunningNumbersForAccountViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    model.EntityLevel = "Centre";

                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }
                return PartialView("/Views/GeneralMaster/GeneralRunningNumbersForAccount/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centreCode)
        {
            try
            {
                GeneralRunningNumbersForAccountViewModel model = new GeneralRunningNumbersForAccountViewModel();
                model.CentreCode = centreCode;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralRunningNumbersForAccount/List.cshtml", model);
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

            GeneralRunningNumbersForAccountViewModel model = new GeneralRunningNumbersForAccountViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Centre Code", Value = "CentreCode" });
            li.Add(new SelectListItem { Text = "Prefix", Value = "Prefix" });
            li.Add(new SelectListItem { Text = "Year", Value = "Year" });
            li.Add(new SelectListItem { Text = "Month", Value = "Month" });
            li.Add(new SelectListItem { Text = "Counter Number", Value = "Counter" });
            ViewData["FormatList"] = li;

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "/", Value = "/" });
            li1.Add(new SelectListItem { Text = "-", Value = "-" });
            ViewData["SeperatorList"] = li1;

            AccountSessionMaster obj = new AccountSessionMaster();
            obj = GetCurrentAccountSession();
            model.FinancialYear = string.Concat(!string.IsNullOrEmpty(obj.SessionStartDatetime) ? obj.SessionStartDatetime.Split(' ')[2] : string.Empty, '-', !string.IsNullOrEmpty(obj.SessionEndDatetime) ? obj.SessionEndDatetime.Split(' ')[2] : string.Empty);
            model.FinancialYearID = obj.ID;

            model.MenuCodeList = GetMenuCodeAndMenuLink(1);

            return PartialView("/Views/GeneralMaster/GeneralRunningNumbersForAccount/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralRunningNumbersForAccountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.GeneralRunningNumbersForAccountDTO.ConnectionString = _connectioString;
                    model.GeneralRunningNumbersForAccountDTO.CentreCode = model.CentreCode;
                    model.GeneralRunningNumbersForAccountDTO.Description = model.Description;
                    model.GeneralRunningNumbersForAccountDTO.KeyField = model.KeyField;
                    model.GeneralRunningNumbersForAccountDTO.FinancialYearID = model.FinancialYearID;
                    model.GeneralRunningNumbersForAccountDTO.StartNumber = model.StartNumber;
                    model.GeneralRunningNumbersForAccountDTO.DisplayFormat = model.DisplayFormat;
                    model.GeneralRunningNumbersForAccountDTO.Seperator = model.Seperator;
                    model.GeneralRunningNumbersForAccountDTO.Prefix1 = model.Prefix1;
                    model.GeneralRunningNumbersForAccountDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralRunningNumbersForAccount> response = _GeneralRunningNumbersForAccountServiceAccess.InsertGeneralRunningNumbersForAccount(model.GeneralRunningNumbersForAccountDTO);
                    model.GeneralRunningNumbersForAccountDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralRunningNumbersForAccountDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        protected List<GeneralTaskModel> GetMenuCodeAndMenuLink(int flag)
        {
            GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StatusFlag = flag;
            List<GeneralTaskModel> list = new List<GeneralTaskModel>();
            IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _GeneralTaskModelServiceAccess.GetMenuCodeAndMenuLink(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    list = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return list;
        }
        public IEnumerable<GeneralRunningNumbersForAccountViewModel> GetGeneralRunningNumbersForAccountRecords(string centreCode ,out int TotalRecords)
        {
            GeneralRunningNumbersForAccountSearchRequest searchRequest = new GeneralRunningNumbersForAccountSearchRequest();
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
                    searchRequest.CentreCode = centreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centreCode;
            }
            List<GeneralRunningNumbersForAccountViewModel> listGeneralRunningNumbersForAccountViewModel = new List<GeneralRunningNumbersForAccountViewModel>();
            List<GeneralRunningNumbersForAccount> listGeneralRunningNumbersForAccount = new List<GeneralRunningNumbersForAccount>();
            IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> baseEntityCollectionResponse = _GeneralRunningNumbersForAccountServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRunningNumbersForAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralRunningNumbersForAccount item in listGeneralRunningNumbersForAccount)
                    {
                        GeneralRunningNumbersForAccountViewModel _GeneralRunningNumbersForAccountViewModel = new GeneralRunningNumbersForAccountViewModel();
                        _GeneralRunningNumbersForAccountViewModel.GeneralRunningNumbersForAccountDTO = item;
                        listGeneralRunningNumbersForAccountViewModel.Add(_GeneralRunningNumbersForAccountViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRunningNumbersForAccountViewModel;
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords = 0;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GeneralRunningNumbersForAccountViewModel> filteredGeneralRunningNumbersForAccount;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.SessionStartDatetime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.SessionStartDatetime Like '%" + param.sSearch + "%' or A.DisplayFormat Like '%" + param.sSearch + "%' or A.Description Like '%" + param.sSearch + "%' or A.StartNumber Like '%" + param.sSearch + "%' or A.CurrentCounter Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "A.DisplayFormat";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                         _searchBy = "B.SessionStartDatetime Like '%" + param.sSearch + "%' or A.DisplayFormat Like '%" + param.sSearch + "%' or A.Description Like '%" + param.sSearch + "%' or A.StartNumber Like '%" + param.sSearch + "%' or A.CurrentCounter Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "A.StartNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                         _searchBy = "B.SessionStartDatetime Like '%" + param.sSearch + "%' or A.DisplayFormat Like '%" + param.sSearch + "%' or A.Description Like '%" + param.sSearch + "%' or A.StartNumber Like '%" + param.sSearch + "%' or A.CurrentCounter Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality       //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.CurrentCounter";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                         _searchBy = "B.SessionStartDatetime Like '%" + param.sSearch + "%' or A.DisplayFormat Like '%" + param.sSearch + "%' or A.Description Like '%" + param.sSearch + "%' or A.StartNumber Like '%" + param.sSearch + "%' or A.CurrentCounter Like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality       //this "if" block is added for search functionality
                    }
                    break;               
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(CentreCode))
            {
                var centreCode = CentreCode;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                filteredGeneralRunningNumbersForAccount = GetGeneralRunningNumbersForAccountRecords(centreCode , out TotalRecords);
            }
            else
            {
                filteredGeneralRunningNumbersForAccount = new List<GeneralRunningNumbersForAccountViewModel>();
                TotalRecords = 0;
            }
            var records = filteredGeneralRunningNumbersForAccount.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FinancialYear), Convert.ToString(c.DisplayFormat), Convert.ToString(c.StartNumber), Convert.ToString(c.CurrentCounter), Convert.ToString(c.KeyField) };            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
       
    }
}



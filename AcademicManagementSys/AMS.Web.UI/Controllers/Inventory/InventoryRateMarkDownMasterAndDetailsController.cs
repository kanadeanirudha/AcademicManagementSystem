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
    public class InventoryRateMarkDownMasterAndDetailsController : BaseController
    {
        IInventoryRateMarkDownMasterAndDetailsServiceAccess _InventoryRateMarkDownMasterAndDetailsServiceAccess = null;
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

        public InventoryRateMarkDownMasterAndDetailsController()
        {
            _InventoryRateMarkDownMasterAndDetailsServiceAccess = new InventoryRateMarkDownMasterAndDetailsServiceAccess();
            _InventoryItemCategoryMasterServiceAccess = new InventoryItemCategoryMasterServiceAccess();
            _generalUnitMasterServiceAcess = new GeneralUnitMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryRateMarkDownMasterAndDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }

        }

        public ActionResult List(string centerCode, string actionMode,string CategoryCode)
        {
            try
            {
                InventoryRateMarkDownMasterAndDetailsViewModel model = new InventoryRateMarkDownMasterAndDetailsViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                    
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByFinanceManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                    model.ListGetCategoryCode = GetListGetCategoryCode();
                    //}
                    //model.SelectedCentreCode = centerCode;
                    model.CategoryCode = CategoryCode;
                }
                model.SelectedCentreCode= centerCode;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryRateMarkDownMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult List(InventoryRateMarkDownMasterAndDetailsViewModel model)
        {
            try
            {
                if (model != null && model.InventoryRateMarkDownMasterAndDetailsDTO != null)
                {
                    model.InventoryRateMarkDownMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.InventoryRateMarkDownMasterAndDetailsDTO.SelectedXml = model.SelectedXml;
                    model.InventoryRateMarkDownMasterAndDetailsDTO.CategoryCode = model.CategoryCode;
                  //  model.InventoryRateMarkDownMasterAndDetailsDTO.TransactionDate = Convert.ToString(DateTime.Today).Split(' ')[0];
                    model.InventoryRateMarkDownMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    string aa = model.SelectedCentreCode;

                    string[] Centre_code =  model.SelectedCentreCode.Split(':');
                    //searchRequest.CentreCode = Centre_code[0];


                    model.InventoryRateMarkDownMasterAndDetailsDTO.CentreCode = Centre_code[0];

                    model.SelectedCentreCode = aa;
                  
                    IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> response = _InventoryRateMarkDownMasterAndDetailsServiceAccess.InsertInventoryRateMarkDownMasterAndDetails(model.InventoryRateMarkDownMasterAndDetailsDTO);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetails(string centerCode,string CategoryCode, out int TotalRecords)
        {
            List<InventoryRateMarkDownMasterAndDetails> listInventoryRateMarkDownMasterAndDetails = new List<InventoryRateMarkDownMasterAndDetails>();
            InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest = new InventoryRateMarkDownMasterAndDetailsSearchRequest();
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
                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.CategoryCode = CategoryCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";                    
                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.CategoryCode = CategoryCode;

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;               
                string[] Centre_code = centerCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                searchRequest.CategoryCode = CategoryCode;


            }
            IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> baseEntityCollectionResponse = _InventoryRateMarkDownMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryRateMarkDownMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryRateMarkDownMasterAndDetails;
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
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode,string CategoryCode)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventoryRateMarkDownMasterAndDetails> filteredInventoryRateMarkDownMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CTE1.ItemName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = "A.ItemName Like '%%'"; 
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
            //filteredInventoryRateMarkDownMasterAndDetails = GetInventoryRateMarkDownMasterAndDetails(out TotalRecords);

            //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            //{
            //    filteredOrganisationSubjectGroupDetails = GetOrganisationSubjectGroupDetails(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            //}
            //else
            //{
            //    filteredOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetailsViewModel>();
            //    TotalRecords = 0;
            //}



            

            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {
                filteredInventoryRateMarkDownMasterAndDetails = GetInventoryRateMarkDownMasterAndDetails(SelectedCentreCode,CategoryCode, out TotalRecords);
            }
            else
            {
                filteredInventoryRateMarkDownMasterAndDetails = new List<InventoryRateMarkDownMasterAndDetails>();
                TotalRecords = 0;
            }
            if ((filteredInventoryRateMarkDownMasterAndDetails.Count()) == 0)
            {
                filteredInventoryRateMarkDownMasterAndDetails = new List<InventoryRateMarkDownMasterAndDetails>();
                TotalRecords = 0;
            }
            
            var records = filteredInventoryRateMarkDownMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.ItemName.ToString(), c.RateDecreaseByPercentage.ToString(), Convert.ToString(c.ItemID + "~" + c.RateMarkDownDetailID + "~" + c.RateDecreaseByPercentage) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}



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
    public class InventoryLocationMaster_1Controller : BaseController
    {
        IInventoryLocationMaster_1ServiceAccess _InventoryLocationMaster_1ServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryLocationMaster_1Controller()
        {
            _InventoryLocationMaster_1ServiceAcess = new InventoryLocationMaster_1ServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory_1/InventoryLocationMaster_1/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            
            
        }

        public ActionResult List(string actionMode, string centerCode)
        {
            try
            {
                InventoryLocationMaster_1ViewModel model = new InventoryLocationMaster_1ViewModel();
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
                }
                model.SelectedCentreCode = centerCode;
               
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory_1/InventoryLocationMaster_1/List.cshtml", model);
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
            InventoryLocationMaster_1ViewModel model = new InventoryLocationMaster_1ViewModel();
            return PartialView("/Views/Inventory_1/InventoryLocationMaster_1/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryLocationMaster_1ViewModel model)
        {
            try
            {
                
                
                    if (model != null && model.InventoryLocationMaster_1DTO != null)
                    {
                        model.InventoryLocationMaster_1DTO.ConnectionString = _connectioString;
                        model.InventoryLocationMaster_1DTO.LocationName = model.LocationName;
                        
                        string[] SplitedcenterCode = model.SelectedCentreCode.Split(':');
                        model.InventoryLocationMaster_1DTO.CentreCode = SplitedcenterCode[0] ;
                       
                       // model.InventoryLocationMaster_1DTO.AccBalanceSheetID = model.AccBalanceSheetID;
                        model.InventoryLocationMaster_1DTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryLocationMaster_1> response = _InventoryLocationMaster_1ServiceAcess.InsertInventoryLocationMaster_1(model.InventoryLocationMaster_1DTO);
                       model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);

                    }
                    
                    return Json("Please review your form");
                
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;     
            }
          
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            InventoryLocationMaster_1ViewModel model = new InventoryLocationMaster_1ViewModel();
            try
            {                
                model.InventoryLocationMaster_1DTO = new InventoryLocationMaster_1();
                model.InventoryLocationMaster_1DTO.ID = id;
                model.InventoryLocationMaster_1DTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryLocationMaster_1> response = _InventoryLocationMaster_1ServiceAcess.SelectByID(model.InventoryLocationMaster_1DTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryLocationMaster_1DTO.ID = response.Entity.ID;
                    model.InventoryLocationMaster_1DTO.LocationName = response.Entity.LocationName;
                   // model.InventoryLocationMaster_1DTO.SeqNo = response.Entity.SeqNo;
                   // model.InventoryLocationMaster_1DTO.AccBalanceSheetID = response.Entity.AccBalanceSheetID;
                   // model.InventoryLocationMaster_1DTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.InventoryLocationMaster_1DTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory_1/InventoryLocationMaster_1/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryLocationMaster_1ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryLocationMaster_1DTO != null)
                {
                    if (model != null && model.InventoryLocationMaster_1DTO != null)
                    {
                        model.InventoryLocationMaster_1DTO.ConnectionString = _connectioString;
                        model.InventoryLocationMaster_1DTO.ID = model.ID;
                        model.InventoryLocationMaster_1DTO.LocationName = model.LocationName;
                        model.InventoryLocationMaster_1DTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryLocationMaster_1> response = _InventoryLocationMaster_1ServiceAcess.UpdateInventoryLocationMaster_1(model.InventoryLocationMaster_1DTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            InventoryLocationMaster_1ViewModel model = new InventoryLocationMaster_1ViewModel();
            model.InventoryLocationMaster_1DTO = new InventoryLocationMaster_1();
            model.InventoryLocationMaster_1DTO.ID = ID;
            return PartialView("/Views/Inventory/InventoryLocationMaster_1/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(InventoryLocationMaster_1ViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    InventoryLocationMaster_1 InventoryLocationMaster_1DTO = new InventoryLocationMaster_1();
                    InventoryLocationMaster_1DTO.ConnectionString = _connectioString;
                    InventoryLocationMaster_1DTO.ID = model.ID;
                    InventoryLocationMaster_1DTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryLocationMaster_1> response = _InventoryLocationMaster_1ServiceAcess.DeleteInventoryLocationMaster_1(InventoryLocationMaster_1DTO);
                    model.InventoryLocationMaster_1DTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.InventoryLocationMaster_1DTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryLocationMaster_1> GetInventoryLocationMaster_1(string centreCode, out int TotalRecords)
        {
            InventoryLocationMaster_1SearchRequest searchRequest = new InventoryLocationMaster_1SearchRequest();
            List<InventoryLocationMaster_1> listInventoryLocationMaster_1 = new List<InventoryLocationMaster_1>();
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
                    //searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                  //  searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
               // searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
            }
            
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> baseEntityCollectionResponse = _InventoryLocationMaster_1ServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryLocationMaster_1 = baseEntityCollectionResponse.CollectionResponse.ToList();
                    
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryLocationMaster_1;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryLocationMaster_1> filteredLocationMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "LocationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "LocationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    //case 1:
                    //    _sortBy = "CategoryCode";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "LocationName Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    //    }
                    //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(SelectedCentreCode))
                {
                    filteredLocationMaster = GetInventoryLocationMaster_1(SelectedCentreCode, out TotalRecords);
                }
                else
                {
                    filteredLocationMaster = new List<InventoryLocationMaster_1>();
                    TotalRecords = 0;
                }

                if ((filteredLocationMaster.Count()) == 0)
                {
                    filteredLocationMaster = new List<InventoryLocationMaster_1>();
                    TotalRecords = 0;
                }
               
                var records = filteredLocationMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.LocationName.ToString(), c.AccBalanceSheetID.ToString(), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
               //return RedirectToAction("Login", "Account");
                var result = 0;
               return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}
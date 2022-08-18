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
    public class InventoryCounterApplicableDetailsController : BaseController
    {
        IInventoryCounterApplicableDetailsServiceAccess _InventoryCounterApplicableDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IInventoryCounterApplicableDetailsServiceAccess _inventoryCounterApplicableDetailsServiceAccess = null;
        IInventoryMachineMasterServiceAccess _inventoryMachineMasterServiceAccess = null;


        public InventoryCounterApplicableDetailsController()
        {
            _InventoryCounterApplicableDetailsServiceAcess = new InventoryCounterApplicableDetailsServiceAccess();
            _inventoryMachineMasterServiceAccess = new InventoryMachineMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryCounterApplicableDetails/Index.cshtml");
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
                InventoryCounterApplicableDetailsViewModel model = new InventoryCounterApplicableDetailsViewModel();

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
                //string aa = model.SelectedCentreCode;

                //string[] Centre_code = model.SelectedCentreCode.Split(':');
                //searchRequest.CentreCode = Centre_code[0];


                //model.InventoryCounterApplicableDetailsDTO.CentreCode = Centre_code[0];

                //model.SelectedCentreCode = aa;




                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryCounterApplicableDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }







        [HttpGet]
        public ActionResult Create(string CounterDetails, string CentreCode)
        {


            InventoryCounterApplicableDetailsViewModel model = new InventoryCounterApplicableDetailsViewModel();

            if (CounterDetails != null)
            {
                string[] counter = CounterDetails.Split('~');

                model.CounterName = counter[1].Replace('`', ' ');
                model.InvCounterMasterID = Convert.ToInt32(counter[0]);
                //string[] SplitedcenterCode = CentreCode.Split(':');
                //model.SelectedCentreCode = SplitedcenterCode[0];
            }
            model.SelectedCentreCode = CentreCode;
            model.GetInventoryMachineCounterApplicableList = GetInventoryMachineCounterApplicableList();
            return PartialView("/Views/Inventory/InventoryCounterApplicableDetails/Create.cshtml", model);

        }

        [HttpPost]
        public ActionResult Create(InventoryCounterApplicableDetailsViewModel model)
        {
            try
            {
                if (model != null && model.InventoryCounterApplicableDetailsDTO != null)
                {
                    model.InventoryCounterApplicableDetailsDTO.ConnectionString = _connectioString;
                    model.InventoryCounterApplicableDetailsDTO.InvCounterMasterID = model.InvCounterMasterID;
                    model.InventoryCounterApplicableDetailsDTO.InvMachineMasterID = model.InvMachineMasterID;
                    model.InventoryCounterApplicableDetailsDTO.MachineCode = model.MachineCode;
                    if (model.SelectedCentreCode != null)
                    {
                        string[] SplitedcenterCode = model.SelectedCentreCode.Split(':');
                        model.InventoryCounterApplicableDetailsDTO.CentreCode = SplitedcenterCode[0];
                    }
                   
                  //  model.InventoryCounterApplicableDetailsDTO.AccBalsheetMstID = model.AccBalsheetMstID;
                    model.InventoryCounterApplicableDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryCounterApplicableDetails> response = _InventoryCounterApplicableDetailsServiceAcess.InsertInventoryCounterApplicableDetails(model.InventoryCounterApplicableDetailsDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model, JsonRequestBehavior.AllowGet);


                }

                return Json("Please review your form");


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        // [HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    InventoryCounterApplicableDetailsViewModel model = new InventoryCounterApplicableDetailsViewModel();
        //    try
        //    {                
        //        model.InventoryCounterApplicableDetailsDTO = new InventoryCounterApplicableDetails();
        //        model.InventoryCounterApplicableDetailsDTO.ID = id;
        //        model.InventoryCounterApplicableDetailsDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryCounterApplicableDetails> response = _InventoryCounterApplicableDetailsServiceAcess.SelectByID(model.InventoryCounterApplicableDetailsDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryCounterApplicableDetailsDTO.ID = response.Entity.ID;
        //            model.InventoryCounterApplicableDetailsDTO.CategoryDescription = response.Entity.CategoryDescription;
        //           // model.InventoryCounterApplicableDetailsDTO.SeqNo = response.Entity.SeqNo;
        //            model.InventoryCounterApplicableDetailsDTO.CategoryCode = response.Entity.CategoryCode;
        //           // model.InventoryCounterApplicableDetailsDTO.IsUserDefined = response.Entity.IsUserDefined;
        //            model.InventoryCounterApplicableDetailsDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView("/Views/Inventory/InventoryCounterApplicableDetails/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // [HttpPost]
        //public ActionResult Edit(InventoryCounterApplicableDetailsViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.InventoryCounterApplicableDetailsDTO != null)
        //        {
        //            if (model != null && model.InventoryCounterApplicableDetailsDTO != null)
        //            {
        //                model.InventoryCounterApplicableDetailsDTO.ConnectionString = _connectioString;
        //                model.InventoryCounterApplicableDetailsDTO.CategoryDescription = model.CategoryDescription;
        //               // model.InventoryCounterApplicableDetailsDTO.SeqNo = model.SeqNo;
        //                model.InventoryCounterApplicableDetailsDTO.CategoryCode = model.CategoryCode;
        //                model.InventoryCounterApplicableDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<InventoryCounterApplicableDetails> response = _InventoryCounterApplicableDetailsServiceAcess.UpdateInventoryCounterApplicableDetails(model.InventoryCounterApplicableDetailsDTO);
        //                model.InventoryCounterApplicableDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.InventoryCounterApplicableDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            InventoryCounterApplicableDetailsViewModel model = new InventoryCounterApplicableDetailsViewModel();
            model.InventoryCounterApplicableDetailsDTO = new InventoryCounterApplicableDetails();
            model.InventoryCounterApplicableDetailsDTO.ID = ID;
            return PartialView("/Views/Inventory/InventoryCounterApplicableDetails/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(InventoryCounterApplicableDetailsViewModel model)
        {
           
                if (model.ID > 0)
                {
                    InventoryCounterApplicableDetails InventoryCounterApplicableDetailsDTO = new InventoryCounterApplicableDetails();
                    InventoryCounterApplicableDetailsDTO.ConnectionString = _connectioString;
                    InventoryCounterApplicableDetailsDTO.ID = model.ID;
                    model.InventoryCounterApplicableDetailsDTO.CentreCode = model.SelectedCentreCode;
                    InventoryCounterApplicableDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryCounterApplicableDetails> response = _InventoryCounterApplicableDetailsServiceAcess.DeleteInventoryCounterApplicableDetails(InventoryCounterApplicableDetailsDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                
            
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetails(out int TotalRecords, string centerCode)
        {
            InventoryCounterApplicableDetailsSearchRequest searchRequest = new InventoryCounterApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                    string[] Centre_code = centerCode.Split(':');
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
                searchRequest.CentreCode = Convert.ToString(Session["CenterCode"]);
                string[] Centre_code = centerCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];


            }
            List<InventoryCounterApplicableDetailsViewModel> listInventoryCounterApplicableDetailsViewModel = new List<InventoryCounterApplicableDetailsViewModel>();
            List<InventoryCounterApplicableDetails> listInventoryCounterApplicableDetails = new List<InventoryCounterApplicableDetails>();
            IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> baseEntityCollectionResponse = _InventoryCounterApplicableDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCounterApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryCounterApplicableDetails item in listInventoryCounterApplicableDetails)
                    {
                        InventoryCounterApplicableDetailsViewModel InventoryCounterApplicableDetailsViewModel = new InventoryCounterApplicableDetailsViewModel();
                        InventoryCounterApplicableDetailsViewModel.InventoryCounterApplicableDetailsDTO = item;
                        listInventoryCounterApplicableDetailsViewModel.Add(InventoryCounterApplicableDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryCounterApplicableDetails;
        }


        //protected List<InventoryCounterApplicableDetails> GetInventoryCounterApplicableMachine()
        //{
        //    InventoryCounterApplicableDetailsSearchRequest searchRequest = new InventoryCounterApplicableDetailsSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<InventoryCounterApplicableDetails> listCounterApplicableMachine = new List<InventoryCounterApplicableDetails>();
        //    IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> baseEntityCollectionResponse = _inventoryCounterApplicableDetailsServiceAccess(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listCounterApplicableMachine = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listCounterApplicableMachine;
        //}

        protected List<InventoryMachineMaster> GetInventoryMachineCounterApplicableList()
        {
            InventoryMachineMasterSearchRequest searchRequest = new InventoryMachineMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryMachineMaster> GetInventoryMachineCounterApplicableList = new List<InventoryMachineMaster>();
            IBaseEntityCollectionResponse<InventoryMachineMaster> baseEntityCollectionResponse = _inventoryMachineMasterServiceAccess.GetInventoryMachineCounterApplicableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    GetInventoryMachineCounterApplicableList = baseEntityCollectionResponse.CollectionResponse.OrderBy(x=>x.MachineCode).ToList();
                }
            }
            return GetInventoryMachineCounterApplicableList;
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

                IEnumerable<InventoryCounterApplicableDetails> filteredCounterApplicableDetails;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CounterName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CounterName Like '%" + param.sSearch + "%' or MachineCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "MachineCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CounterName Like '%" + param.sSearch + "%' or CounterName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                // filteredCounterApplicableDetails = GetInventoryCounterApplicableDetails(out TotalRecords);
                if (!string.IsNullOrEmpty(SelectedCentreCode))
                {
                    filteredCounterApplicableDetails = GetInventoryCounterApplicableDetails(out TotalRecords, SelectedCentreCode);

                }
                else
                {
                    filteredCounterApplicableDetails = new List<InventoryCounterApplicableDetails>();
                    TotalRecords = 0;
                }
                if ((filteredCounterApplicableDetails.Count()) == 0)
                {
                    filteredCounterApplicableDetails = new List<InventoryCounterApplicableDetails>();
                    TotalRecords = 0;
                }

                var records = filteredCounterApplicableDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CounterName.ToString(), c.MachineCode.ToString(), c.InvCounterMasterID.ToString(), Convert.ToString(c.ID), Convert.ToString(c.StatusFlag) };

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
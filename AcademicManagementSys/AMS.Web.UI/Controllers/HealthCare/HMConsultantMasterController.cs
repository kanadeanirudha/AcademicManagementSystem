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
    public class HMConsultantMasterController : BaseController
    {
        IHMConsultantMasterServiceAccess _HMConsultantMasterServiceAcess = null;
        IHMConsultantMasterViewModel _HMConsultantMasterViewModel = null;
        IOrganisationDepartmentMasterServiceAccess _OrganisationDepartmentMasterServiceAccess = null;
        IHMConsultantTypeMasterServiceAccess _HMConsultantTypeMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMConsultantMasterController()
        {
            _HMConsultantMasterServiceAcess = new HMConsultantMasterServiceAccess();
            _OrganisationDepartmentMasterServiceAccess = new OrganisationDepartmentMasterServiceAccess();
            _HMConsultantMasterViewModel = new HMConsultantMasterViewModel();
            _HMConsultantTypeMasterServiceAccess = new HMConsultantTypeMasterServiceAccess();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/HealthCare/HMConsultantMaster/Index.cshtml");
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
                    if (listAdminRoleApplicableDetails.Count > 0)
                    {
                        return View("/Views/HealthCare/HMConsultantMaster/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("UnauthorizedAccess", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult List(string centreCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(centreCode))
                {
                    string[] splitCentreCode = centreCode.Split(':');
                   _HMConsultantMasterViewModel.CentreCode = splitCentreCode[0];
                    //_HMConsultantMasterViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _HMConsultantMasterViewModel.CentreCode = centreCode;
                    //_LeaveSessionViewModel.EntityLevel = null;
                }
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
                       _HMConsultantMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                   _HMConsultantMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _HMConsultantMasterViewModel.ListGetAdminRoleApplicableCentre)
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
                       _HMConsultantMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _HMConsultantMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                //_HMConsultantMasterViewModel.CentreCode = centreCode;
               //_HMConsultantMasterViewModel.CentreName = centreName;
               
                return PartialView("/Views/HealthCare/HMConsultantMaster/List.cshtml", _HMConsultantMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Create(string CenterCode)
        {

            HMConsultantMasterViewModel model = new HMConsultantMasterViewModel();
            {
                model.CentreCode = CenterCode;
                List<HMConsultantTypeMaster> HMConsultantTypeMaster = GetHMConsultantTypeList();
                List<SelectListItem> HMConsultantTypeMasterList = new List<SelectListItem>();

                foreach (HMConsultantTypeMaster item in HMConsultantTypeMaster)
                {
                    HMConsultantTypeMasterList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.ID) });
                }
                ViewBag.ListHMConsultantTypeMaster = new SelectList(HMConsultantTypeMasterList, "Value", "Text");
            }
         
            return PartialView("/Views/HealthCare/HMConsultantMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMConsultantMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.HMConsultantMasterDTO != null)
                {
                    model.HMConsultantMasterDTO.ConnectionString = _connectioString;
                   
                   
                    model.HMConsultantMasterDTO.ConsultantTypeMasterID = model.ConsultantTypeMasterID;
                    model.HMConsultantMasterDTO.Name = model.Name;
                    model.HMConsultantMasterDTO.EmployeeID = model.EmployeeID;
                    model.HMConsultantMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMConsultantMaster> response = _HMConsultantMasterServiceAcess.InsertHMConsultantMaster(model.HMConsultantMasterDTO);

                    model.HMConsultantMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.HMConsultantMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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

        //[HttpGet]
        //public ActionResult Edit(Int16 id)
        //{
        //    HMConsultantMasterViewModel model = new HMConsultantMasterViewModel();
        //    try
        //    {

               
        //        model.HMConsultantMasterDTO = new HMConsultantMaster();
        //        model.HMConsultantMasterDTO.ID = id;
        //        model.HMConsultantMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMConsultantMaster> response = _HMConsultantMasterServiceAcess.SelectByID(model.HMConsultantMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMConsultantMasterDTO.ID = response.Entity.ID;
        //          //  model.HMConsultantMasterDTO.Name = response.Entity.Name;
        //            // model.HMConsultantMasterDTO.DepartmentID = response.Entity.DepartmentID;
        //            model.HMConsultantMasterDTO.CreatedBy = response.Entity.CreatedBy;

        //            //******************Dropdownlist********************
        //           // model.CentreCode = CenterCode;
        //            List<HMConsultantTypeMaster> HMConsultantTypeMaster = GetHMConsultantTypeList();
        //            List<SelectListItem> HMConsultantTypeMasterList = new List<SelectListItem>();

        //            foreach (HMConsultantTypeMaster item in HMConsultantTypeMaster)
        //            {
        //                HMConsultantTypeMasterList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.ID) });
        //            }
        //            ViewBag.ListHMConsultantTypeMaster = new SelectList(HMConsultantTypeMasterList, "Value", "Text", (model.HMConsultantMasterDTO.Name).ToString().Trim());

        //            //********************End Dropdown*******************


        //        }
        //        return PartialView("/Views/HealthCare/HMConsultantMaster/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //[HttpPost]
        //public ActionResult Edit(HMConsultantMasterViewModel model)
        //{
        //    try
        //    {
        //        List<HMConsultantTypeMaster> HMConsultantTypeMaster = GetHMConsultantTypeList();
        //        List<SelectListItem> HMConsultantTypeMasterList = new List<SelectListItem>();

        //        foreach (HMConsultantTypeMaster item in HMConsultantTypeMaster)
        //        {
        //            HMConsultantTypeMasterList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.ID) });
        //        }
        //        ViewBag.ListHMConsultantTypeMaster = new SelectList(HMConsultantTypeMasterList, "Value", "Text");
        //        //*********End Dropdown**************
        //        if (model != null && model.HMConsultantMasterDTO != null)
        //        {
        //            model.HMConsultantMasterDTO.ConnectionString = _connectioString;
        //            model.HMConsultantMasterDTO.ID = model.ID;
        //            //model.HMConsultantMasterDTO.Name = model.Name;


        //            model.HMConsultantMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMConsultantMaster> response = _HMConsultantMasterServiceAcess.UpdateHMConsultantMaster(model.HMConsultantMasterDTO);
        //            model.HMConsultantMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMConsultantMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}


        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        HMConsultantMasterViewModel model = new HMConsultantMasterViewModel();
        //        model.HMConsultantMasterDTO = new HMConsultantMaster();
        //        model.HMConsultantMasterDTO.ID = Convert.ToInt16(ID);
        //        model.HMConsultantMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMConsultantMaster> response = _HMConsultantMasterServiceAcess.SelectByID(model.HMConsultantMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMConsultantMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.HMConsultantMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.HMConsultantMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.HMConsultantMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/HMConsultantMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<HMConsultantMaster> response = null;
                HMConsultantMaster HMConsultantMasterDTO = new HMConsultantMaster();
                HMConsultantMasterDTO.ConnectionString = _connectioString;
                HMConsultantMasterDTO.ID = Convert.ToInt16(ID);
                HMConsultantMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMConsultantMasterServiceAcess.DeleteHMConsultantMaster(HMConsultantMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        //Dropdown list For Consultatnt type
        protected List<HMConsultantTypeMaster> GetHMConsultantTypeList()
        {
            HMConsultantTypeMasterSearchRequest searchRequest = new HMConsultantTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<HMConsultantTypeMaster> listHMConsultantTypeMaster = new List<HMConsultantTypeMaster>();
            IBaseEntityCollectionResponse<HMConsultantTypeMaster> baseEntityCollectionResponse = _HMConsultantTypeMasterServiceAccess.GetConsultantTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMConsultantTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listHMConsultantTypeMaster;
        }

        #region Methods
        //*****For GetEmployeeCentreWise Search List*************
        public JsonResult GetEmployeeName(string term, string CentreCode)
        {
            var data = GetEmployeeCentrewiseSearchList(term, CentreCode);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<HMConsultantMasterViewModel> GetHMConsultantMaster(out int TotalRecords, string CentreCode)
        {
            HMConsultantMasterSearchRequest searchRequest = new HMConsultantMasterSearchRequest();
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
                    string[] Centre_code = CentreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];

                  //  searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    //searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                string[] Centre_code = CentreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];

              //  searchRequest.DepartmentID = Convert.ToInt32(!string.IsNullOrEmpty(DepartmentID) ? DepartmentID : null);

            }
            List<HMConsultantMasterViewModel> listHMConsultantMasterViewModel = new List<HMConsultantMasterViewModel>();
            List<HMConsultantMaster> listHMConsultantMaster = new List<HMConsultantMaster>();
            IBaseEntityCollectionResponse<HMConsultantMaster> baseEntityCollectionResponse = _HMConsultantMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMConsultantMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMConsultantMaster item in listHMConsultantMaster)
                    {
                        HMConsultantMasterViewModel HMConsultantMasterViewModel = new HMConsultantMasterViewModel();
                        HMConsultantMasterViewModel.HMConsultantMasterDTO = item;
                        listHMConsultantMasterViewModel.Add(HMConsultantMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMConsultantMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<HMConsultantMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "C.Name";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           // _searchBy = " C.Name like '%'"; 
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                            _searchBy = "C.Name Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like'%" + param.sSearch + "%' or B.EmployeeLastName Like'%" + param.sSearch + "%'";

                        }
                        break;
                    case 1:
                        _sortBy = "B.EmployeeFirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                            //_searchBy = "EmployeeName like '%'";
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                            _searchBy = "C.Name Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like'% " + param.sSearch + "%' or B.EmployeeLastName Like'%" + param.sSearch + "%'";

                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(CentreCode))
                //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    filteredGroupDescription = GetHMConsultantMaster(out TotalRecords, CentreCode);
                    // filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                }
                else
                {
                    filteredGroupDescription = new List<HMConsultantMasterViewModel>();
                    TotalRecords = 0;
                }
                if ((filteredGroupDescription.Count()) == 0)
                {
                    filteredGroupDescription = new List<HMConsultantMasterViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ConsultantTypeMasterID),Convert.ToString(c.EmployeeName),Convert.ToString(c.Name),Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

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
        #endregion
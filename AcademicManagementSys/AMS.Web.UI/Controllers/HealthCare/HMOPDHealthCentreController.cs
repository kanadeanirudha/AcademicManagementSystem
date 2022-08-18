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
    public class HMOPDHealthCentreController : BaseController
    {
        IHMOPDHealthCentreServiceAccess _HMOPDHealthCentreServiceAcess = null;
        IHMOPDHealthCentreViewModel _HMOPDHealthCentreViewModel = null;
       
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMOPDHealthCentreController()
        {
            _HMOPDHealthCentreServiceAcess = new HMOPDHealthCentreServiceAccess();
            _HMOPDHealthCentreViewModel = new HMOPDHealthCentreViewModel();
          
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
                    return View("/Views/HealthCare/HMOPDHealthCentre/Index.cshtml");
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
                        return View("/Views/HealthCare/HMOPDHealthCentre/Index.cshtml");
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
         public ActionResult List(string centerCode, string departmentID)
         {
             try
             {
                 if (!string.IsNullOrEmpty(centerCode))
                 {
                     string[] splitCentreCode = centerCode.Split(':');
                     _HMOPDHealthCentreViewModel.CentreCode = splitCentreCode[0];
                    
                 }
                 else
                 {
                     _HMOPDHealthCentreViewModel.CentreCode = centerCode;
                    
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
                         _HMOPDHealthCentreViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                     } 
                     _HMOPDHealthCentreViewModel.EntityLevel = "Centre";

                     foreach (var b in _HMOPDHealthCentreViewModel.ListGetAdminRoleApplicableCentre)
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
                         _HMOPDHealthCentreViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                     }
                     foreach (var b in _HMOPDHealthCentreViewModel.ListGetAdminRoleApplicableCentre)
                     {
                         b.CentreCode = b.CentreCode;
                     }
                 }
                 if (!string.IsNullOrEmpty(centerCode))
                 {
                     string[] splitCentreCode = centerCode.Split(':');
                     _HMOPDHealthCentreViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                 }
                 _HMOPDHealthCentreViewModel.SelectedCentreCode = centerCode;
                 _HMOPDHealthCentreViewModel.SelectedDepartmentID = departmentID;
                 foreach (var b in _HMOPDHealthCentreViewModel.ListOrganisationDepartmentMaster)
                 {
                     b.DeptID = b.ID + ":" + b.DepartmentName;
                 }



                 if (departmentID != null)
                 {
                     string[] ArrDept = departmentID.Split(':');
                     _HMOPDHealthCentreViewModel.DepartmentID = Convert.ToInt32(ArrDept[0]);
                 }
                
               
                 return PartialView("/Views/HealthCare/HMOPDHealthCentre/List.cshtml", _HMOPDHealthCentreViewModel);
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
         }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
            try
            {
               
                if (String.IsNullOrEmpty(SelectedCentreCode))
                {
                    throw new ArgumentNullException("SelectedCentreCode");
                }
                int id = 0;
                bool isValid = Int32.TryParse(SelectedCentreCode, out id);
                var departments = GetListOrganisationDepartmentMaster(SelectedCentreCode);
                var result = (from s in departments
                              select new
                              {
                                  id = s.ID + ":" + s.DepartmentName,
                                  name = s.DepartmentName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string centerCode, string DepartmentID)
        {

              HMOPDHealthCentreViewModel model = new HMOPDHealthCentreViewModel();
                model.CentreCode = centerCode;
                model.DepartmentID = Convert.ToInt32(DepartmentID);

            return PartialView("/Views/HealthCare/HMOPDHealthCentre/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMOPDHealthCentreViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.HMOPDHealthCentreDTO != null)
                {
                    model.HMOPDHealthCentreDTO.ConnectionString = _connectioString;
                    model.HMOPDHealthCentreDTO.CentreCode = model.CentreCode;
                    model.HMOPDHealthCentreDTO.DepartmentID = model.DepartmentID;
                    model.HMOPDHealthCentreDTO.OPDName = model.OPDName;
                    model.HMOPDHealthCentreDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMOPDHealthCentre> response = _HMOPDHealthCentreServiceAcess.InsertHMOPDHealthCentre(model.HMOPDHealthCentreDTO);

                    model.HMOPDHealthCentreDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.HMOPDHealthCentreDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Edit(int id)
        //{
        //    HMOPDHealthCentreViewModel model = new HMOPDHealthCentreViewModel();
        //    try
        //    {
        //        model.HMOPDHealthCentreDTO = new HMOPDHealthCentre();
        //        model.HMOPDHealthCentreDTO.ID = id;
        //        model.HMOPDHealthCentreDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMOPDHealthCentre> response = _HMOPDHealthCentreServiceAcess.SelectByID(model.HMOPDHealthCentreDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMOPDHealthCentreDTO.ID = response.Entity.ID;
        //            model.HMOPDHealthCentreDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.HMOPDHealthCentreDTO.GroupCode = response.Entity.GroupCode;
        //            model.HMOPDHealthCentreDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        //[HttpGet]
        //public ActionResult Edit(Int16 id)
        //{
        //    HMOPDHealthCentreViewModel model = new HMOPDHealthCentreViewModel();
        //    try
        //    {
        //        model.HMOPDHealthCentreDTO = new HMOPDHealthCentre();
        //        model.HMOPDHealthCentreDTO.ID = id;
        //        model.HMOPDHealthCentreDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMOPDHealthCentre> response = _HMOPDHealthCentreServiceAcess.SelectByID(model.HMOPDHealthCentreDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMOPDHealthCentreDTO.ID = response.Entity.ID;
        //            model.HMOPDHealthCentreDTO.OPDName = response.Entity.OPDName;
        //            model.HMOPDHealthCentreDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView("/Views/HealthCare/HMOPDHealthCentre/Edit.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(HMOPDHealthCentreViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMOPDHealthCentreDTO != null)
        //        {
        //            model.HMOPDHealthCentreDTO.ConnectionString = _connectioString;
        //            model.HMOPDHealthCentreDTO.ID = model.ID;
        //            model.HMOPDHealthCentreDTO.OPDName = model.OPDName;
                   

        //            model.HMOPDHealthCentreDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMOPDHealthCentre> response = _HMOPDHealthCentreServiceAcess.UpdateHMOPDHealthCentre(model.HMOPDHealthCentreDTO);
        //            model.HMOPDHealthCentreDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMOPDHealthCentreDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //        HMOPDHealthCentreViewModel model = new HMOPDHealthCentreViewModel();
        //        model.HMOPDHealthCentreDTO = new HMOPDHealthCentre();
        //        model.HMOPDHealthCentreDTO.ID = Convert.ToInt16(ID);
        //        model.HMOPDHealthCentreDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMOPDHealthCentre> response = _HMOPDHealthCentreServiceAcess.SelectByID(model.HMOPDHealthCentreDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMOPDHealthCentreDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.HMOPDHealthCentreDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.HMOPDHealthCentreDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.HMOPDHealthCentreDTO.GenServiceRequiredID);

        //        return PartialView("/Views/HMOPDHealthCentre/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<HMOPDHealthCentre> response = null;
                HMOPDHealthCentre HMOPDHealthCentreDTO = new HMOPDHealthCentre();
                HMOPDHealthCentreDTO.ConnectionString = _connectioString;
                HMOPDHealthCentreDTO.ID = Convert.ToInt16(ID);
                HMOPDHealthCentreDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMOPDHealthCentreServiceAcess.DeleteHMOPDHealthCentre(HMOPDHealthCentreDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMOPDHealthCentreViewModel> GetHMOPDHealthCentre(out int TotalRecords, string CentreCode, string DepartmentID)
        {
            HMOPDHealthCentreSearchRequest searchRequest = new HMOPDHealthCentreSearchRequest();
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
                    string[] dept = DepartmentID.Split(':');
                    searchRequest.DepartmentID = Convert.ToInt32(dept[0]);
                  
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
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
                string[] Centre_code = CentreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                string[] dept = DepartmentID.Split(':');
                searchRequest.DepartmentID = Convert.ToInt32(dept[0]);
              
            }
            List<HMOPDHealthCentreViewModel> listHMOPDHealthCentreViewModel = new List<HMOPDHealthCentreViewModel>();
            List<HMOPDHealthCentre> listHMOPDHealthCentre = new List<HMOPDHealthCentre>();
            IBaseEntityCollectionResponse<HMOPDHealthCentre> baseEntityCollectionResponse = _HMOPDHealthCentreServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMOPDHealthCentre = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMOPDHealthCentre item in listHMOPDHealthCentre)
                    {
                        HMOPDHealthCentreViewModel HMOPDHealthCentreViewModel = new HMOPDHealthCentreViewModel();
                        HMOPDHealthCentreViewModel.HMOPDHealthCentreDTO = item;
                        listHMOPDHealthCentreViewModel.Add(HMOPDHealthCentreViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMOPDHealthCentreViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<HMOPDHealthCentreViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.OPDName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.OPDName like '%'";
                            //_searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.OPDName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    //case 1:
                    //    _sortBy = "A.AttributeName";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        // _searchBy = "A.MarchandiseGroupCode like '%'";
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //        _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                //if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedDepartmentID))
                {
                    filteredGroupDescription = GetHMOPDHealthCentre(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                    // filteredCountryMaster = GetGeneralUnits(out TotalRecords, SelectedCentreCode, SelectedDepartmentID);
                }
                else
                {
                    filteredGroupDescription = new List<HMOPDHealthCentreViewModel>();
                    TotalRecords = 0;
                }
                if ((filteredGroupDescription.Count()) == 0)
                {
                    filteredGroupDescription = new List<HMOPDHealthCentreViewModel>();
                    TotalRecords = 0;
                }


               
                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.OPDName), Convert.ToString(c.ID) };

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
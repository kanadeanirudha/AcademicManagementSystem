using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;

namespace AMS.Web.UI.Controllers.Fisheries
{
    public class FishFishermenMasterController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IFishFishermenMasterServiceAccess _fishFishermenMasterServiceAccess;
        private readonly ILogger _logException;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString);

        #endregion


        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public FishFishermenMasterController()
        {
            _fishFishermenMasterServiceAccess = new FishFishermenMasterServiceAccess();
        }

        #endregion



        #region ------------CONTROLLER ACTION METHODS------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
            {
                return View("/Views/Fisheries/FishFishermen/Index.cshtml");
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
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID,0);

                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View("/Views/Fisheries/FishFishermen/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }


        public ActionResult List(string actionMode, string centerCode)
        {
            try
            {
                FishFishermenMasterViewModel _fishFishermenMasterViewModel = new FishFishermenMasterViewModel();
                if (!string.IsNullOrEmpty(centerCode))
                {
                    _fishFishermenMasterViewModel.CentreCode = centerCode;
                }
                //_fishFishermenMasterViewModel.CentreName = centreName;
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails adminRole = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        adminRole = new AdminRoleApplicableDetails();
                        adminRole.CentreCode = item.CentreCode;
                        adminRole.CentreName = item.CentreName;
                        //adminRole.ScopeIdentity = item.ScopeIdentity;
                        _fishFishermenMasterViewModel.ListGetAdminRoleApplicableCentre.Add(adminRole);
                    }

                    // _fishFishermenMasterViewModel.EntityLevel = "Centre";

                    //foreach (var applicableCentre in _fishFishermenMasterViewModel.ListGetAdminRoleApplicableCentre)
                    //{
                    //    applicableCentre.CentreCode = applicableCentre.CentreCode + ":" + "Centre";
                    //}
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID,0);
                    AdminRoleApplicableDetails adminRoleApplicableDetails = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        adminRoleApplicableDetails = new AdminRoleApplicableDetails();
                        adminRoleApplicableDetails.CentreCode = item.CentreCode;
                        adminRoleApplicableDetails.CentreName = item.CentreName;
                        //adminRoleApplicableDetails.ScopeIdentity = item.ScopeIdentity;
                        _fishFishermenMasterViewModel.ListGetAdminRoleApplicableCentre.Add(adminRoleApplicableDetails);
                    }
                    //foreach (var applicableCentre in _fishFishermenMasterViewModel.ListGetAdminRoleApplicableCentre)
                    //{
                    //    applicableCentre.CentreCode = applicableCentre.CentreCode + ":" + applicableCentre.ScopeIdentity;
                    //}
                }

                //_fishFishermenMasterViewModel.CentreCode = centerCode;
                //_fishFishermenMasterViewModel.CentreName = centreName;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Fisheries/FishFishermen/List.cshtml", _fishFishermenMasterViewModel);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        // Create Call of type HttpGet.
        public ActionResult Create(string CentreCode)
        {
            try
            {
                FishFishermenMasterViewModel fishFishermenMasterModel = new FishFishermenMasterViewModel();
                //CentreCode = "1:Centre";
                //string[] splitedCentreCode = CentreCode.Split(':');
                fishFishermenMasterModel.CentreCode = CentreCode;

                //List For Name Title
                List<GeneralTitleMaster> generalTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> listGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in generalTitleMasterList)
                {
                    listGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(listGeneralTitleMaster, "Value", "Text");

                //List For Nationality
                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> listGeneralNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    listGeneralNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralNationalityMasterList = new SelectList(listGeneralNationalityMaster, "Value", "Text");

                return PartialView("/Views/Fisheries/FishFishermen/Create.cshtml", fishFishermenMasterModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(FishFishermenMasterViewModel model)
        {
            try
            {
                if (model.FishFishermenMasterDTO != null)
                {
                    model.FishFishermenMasterDTO.ConnectionString = _connectioString;

                    model.FishFishermenMasterDTO.NameTitleID = model.NameTitleID;
                    model.FishFishermenMasterDTO.FirstName = model.FirstName;
                    model.FishFishermenMasterDTO.MiddleName = model.MiddleName;
                    model.FishFishermenMasterDTO.LastName = model.LastName;
                    model.FishFishermenMasterDTO.Gender = model.Gender;
                    model.FishFishermenMasterDTO.BirthDate = model.BirthDate;
                    model.FishFishermenMasterDTO.EmailID = model.EmailID;
                    model.FishFishermenMasterDTO.MobileNumber = model.MobileNumber;
                    model.FishFishermenMasterDTO.PanNumber = model.PanNumber;
                    model.FishFishermenMasterDTO.AdharCardNumber = model.AdharCardNumber;
                    model.FishFishermenMasterDTO.BankName = model.BankName;
                    model.FishFishermenMasterDTO.BankNumber = model.BankNumber;
                    model.FishFishermenMasterDTO.JoiningDate = model.JoiningDate;
                    model.FishFishermenMasterDTO.NationalityID = model.NationalityID;
                    model.FishFishermenMasterDTO.Address = model.Address;
                    model.FishFishermenMasterDTO.PostalAddress = model.PostalAddress;
                    model.FishFishermenMasterDTO.IsFederationMember = model.IsFederationMember;
                    model.FishFishermenMasterDTO.FederationMemberId = model.FederationMemberId;
                    model.FishFishermenMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<FishFishermenMaster> response = _fishFishermenMasterServiceAccess.InsertFishFishermenMaster(model.FishFishermenMasterDTO);
                    model.FishFishermenMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.FishFishermenMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        //Edit Call
        public ActionResult Edit(int ID)
        {
            FishFishermenMasterViewModel model = new FishFishermenMasterViewModel();
            model.FishFishermenMasterDTO = new FishFishermenMaster();
            model.FishFishermenMasterDTO.ID = ID;
            model.FishFishermenMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<FishFishermenMaster> response = _fishFishermenMasterServiceAccess.SelectByID(model.FishFishermenMasterDTO);
            if (response.Entity != null)
            {
                model.FishFishermenMasterDTO.ID = response.Entity.ID;
                //model.FishFishermenMasterDTO.FishermenCode = response.Entity.FishermenCode;
                model.FishFishermenMasterDTO.CentreCode = response.Entity.CentreCode;
                model.FishFishermenMasterDTO.NameTitleID = response.Entity.NameTitleID;
                model.FishFishermenMasterDTO.FirstName = response.Entity.FirstName;
                model.FishFishermenMasterDTO.MiddleName = response.Entity.MiddleName;
                model.FishFishermenMasterDTO.LastName = response.Entity.LastName;
                model.FishFishermenMasterDTO.Gender = response.Entity.Gender;
                model.FishFishermenMasterDTO.BirthDate = response.Entity.BirthDate;
                model.FishFishermenMasterDTO.EmailID = response.Entity.EmailID;
                model.FishFishermenMasterDTO.MobileNumber = response.Entity.MobileNumber;
                model.FishFishermenMasterDTO.PanNumber = response.Entity.PanNumber;
                model.FishFishermenMasterDTO.AdharCardNumber = response.Entity.AdharCardNumber;
                model.FishFishermenMasterDTO.BankName = response.Entity.BankName;
                model.FishFishermenMasterDTO.BankNumber = response.Entity.BankNumber;
                model.FishFishermenMasterDTO.JoiningDate = response.Entity.JoiningDate;
                model.FishFishermenMasterDTO.NationalityID = response.Entity.NationalityID;
                model.FishFishermenMasterDTO.Address = response.Entity.Address;
                model.FishFishermenMasterDTO.PostalAddress = response.Entity.PostalAddress;
                model.FishFishermenMasterDTO.IsFederationMember = response.Entity.IsFederationMember;
                model.FishFishermenMasterDTO.FederationMemberId = response.Entity.FederationMemberId;

                //List For Name Title
                List<GeneralTitleMaster> generalTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> listGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in generalTitleMasterList)
                {
                    listGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(listGeneralTitleMaster, "Value", "Text", response.Entity.NameTitleID);

                //List For Nationality
                List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
                List<SelectListItem> listGeneralNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in generalNationalityMasterList)
                {
                    listGeneralNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralNationalityMasterList = new SelectList(listGeneralNationalityMaster, "Value", "Text", response.Entity.NationalityID);

            }
            return PartialView("/Views/Fisheries/FishFishermen/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(FishFishermenMasterViewModel model)
        {
            try
            {
                if (model.FishFishermenMasterDTO != null)
                {
                    model.FishFishermenMasterDTO.ConnectionString = _connectioString;
                    model.FishFishermenMasterDTO.ID = model.ID;                    
                    model.FishFishermenMasterDTO.CentreCode = model.CentreCode;
                    model.FishFishermenMasterDTO.NameTitleID = model.NameTitleID;
                    model.FishFishermenMasterDTO.FirstName = model.FirstName;
                    model.FishFishermenMasterDTO.MiddleName = model.MiddleName;
                    model.FishFishermenMasterDTO.LastName = model.LastName;
                    model.FishFishermenMasterDTO.Gender = model.Gender;
                    model.FishFishermenMasterDTO.BirthDate = model.BirthDate;
                    model.FishFishermenMasterDTO.EmailID = model.EmailID;
                    model.FishFishermenMasterDTO.MobileNumber = model.MobileNumber;
                    model.FishFishermenMasterDTO.PanNumber = model.PanNumber;
                    model.FishFishermenMasterDTO.AdharCardNumber = model.AdharCardNumber;
                    model.FishFishermenMasterDTO.BankNumber = model.BankNumber;
                    model.FishFishermenMasterDTO.JoiningDate = model.JoiningDate;
                    model.FishFishermenMasterDTO.NationalityID = model.NationalityID;
                    model.FishFishermenMasterDTO.Address = model.Address;
                    model.FishFishermenMasterDTO.PostalAddress = model.PostalAddress;
                    model.FishFishermenMasterDTO.IsFederationMember = model.IsFederationMember;
                    model.FishFishermenMasterDTO.FederationMemberId = model.FederationMemberId;
                    model.FishFishermenMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FishFishermenMaster> response = _fishFishermenMasterServiceAccess.UpdateFishFishermenMaster(model.FishFishermenMasterDTO);
                    model.FishFishermenMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.FishFishermenMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //Delete fishermen
        public ActionResult Delete(int id)
        {
            FishFishermenMasterViewModel model = new FishFishermenMasterViewModel();
            model.FishFishermenMasterDTO = new FishFishermenMaster();
            model.FishFishermenMasterDTO.ID = id;
            return PartialView("/Views/Fisheries/FishFishermen/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(FishFishermenMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    FishFishermenMaster FishFishermenMasterDTO = new FishFishermenMaster();
                    FishFishermenMasterDTO.ConnectionString = _connectioString;
                    FishFishermenMasterDTO.ID = model.ID;
                    FishFishermenMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FishFishermenMaster> response = _fishFishermenMasterServiceAccess.DeleteFishFishermenMaster(FishFishermenMasterDTO);
                    model.FishFishermenMasterDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.FishFishermenMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
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
        public IEnumerable<FishFishermenMasterViewModel> GetFishFishermenMaster(out int TotalRecords, string CentreCode)
        {
            FishFishermenMasterSearchRequest searchRequest = new FishFishermenMasterSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                    //searchRequest.EntityLevel = EntityLevel;
                    //searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                }

                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    //searchRequest.EntityLevel = EntityLevel;
                    //searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
                //searchRequest.EntityLevel = EntityLevel;
                //searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            }

            List<FishFishermenMasterViewModel> listFishFishermenMasterViewModel = new List<FishFishermenMasterViewModel>();
            List<FishFishermenMaster> listFishermenMaster = new List<FishFishermenMaster>();
            IBaseEntityCollectionResponse<FishFishermenMaster> baseEntityCollectionResponse = _fishFishermenMasterServiceAccess.GetBySearch(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFishermenMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FishFishermenMaster item in listFishermenMaster)
                    {
                        FishFishermenMasterViewModel fishFishermenMasterViewModel = new FishFishermenMasterViewModel();
                        fishFishermenMasterViewModel.FishFishermenMasterDTO = item;
                        listFishFishermenMasterViewModel.Add(fishFishermenMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFishFishermenMasterViewModel;
        }

        #endregion



        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string centreCode)
        {

            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<FishFishermenMasterViewModel> filteredFishermenMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or FishermenCode Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%' ";        //this "if" block is added for search functionality
                        }
                        break;

                    case 1:
                        _sortBy = "FishermenCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or FishermenCode Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 2:
                        _sortBy = "Department";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or FishermenCode Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 3:
                        _sortBy = "Gender";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or FishermenCode Like '%" + param.sSearch + "%' or Gender Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(centreCode))
                {
                    //var centreCode = centreCode;
                    //var scopeIdentity = splitCentreCode[1];
                    //var RoleID = "";
                    //if (Session["UserType"].ToString() == "A")
                    //{
                    //    RoleID = Convert.ToString(0);
                    //}
                    //else
                    //{
                    //    RoleID = Session["RoleID"].ToString();
                    //}
                    filteredFishermenMaster = GetFishFishermenMaster(out TotalRecords, centreCode);
                }
                else
                {
                    filteredFishermenMaster = new List<FishFishermenMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredFishermenMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FirstName) + " " + Convert.ToString(c.MiddleName) + " " + Convert.ToString(c.LastName), Convert.ToString(c.FishermenCode), Convert.ToString(c.Gender), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }


        }


        #endregion

    }
}

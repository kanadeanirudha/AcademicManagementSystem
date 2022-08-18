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
using System.Web;
namespace AMS.Web.UI.Controllers
{
    public class OrganisationMemberMasterController : BaseController
    {
        IOrganisationMemberMasterServiceAccess _organisationMemberMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationMemberMasterController()
        {
            _organisationMemberMasterServiceAcess = new OrganisationMemberMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                return View("/Views/Organisation/OrganisationMemberMaster/Index.cshtml");
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
                    return View("/Views/Organisation/OrganisationMemberMaster/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                OrganisationMemberMasterViewModel _organisationMemberMasterViewModel = new OrganisationMemberMasterViewModel();
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _organisationMemberMasterViewModel.CentreCode = splitCentreCode[0];
                    _organisationMemberMasterViewModel.EntityLevel = splitCentreCode[1];
                }
                else
                {
                    _organisationMemberMasterViewModel.CentreCode = centerCode;
                    _organisationMemberMasterViewModel.EntityLevel = null;
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
                        _organisationMemberMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _organisationMemberMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _organisationMemberMasterViewModel.ListGetAdminRoleApplicableCentre)
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
                        a.ScopeIdentity = item.ScopeIdentity;
                        _organisationMemberMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _organisationMemberMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                }

                _organisationMemberMasterViewModel.CentreCode = centerCode;
                _organisationMemberMasterViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationMemberMaster/List.cshtml", _organisationMemberMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string CentreCode, string CentreName)
        {
            try
            {
                OrganisationMemberMasterViewModel model = new OrganisationMemberMasterViewModel();
                string[] splitData = CentreCode.Split(':');

                model.CentreCode = splitData[0];
                model.CentreName = CentreName; 

                return PartialView("/Views/Organisation/OrganisationMemberMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationMemberMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationMemberMasterDTO != null)
                    {
                        model.OrganisationMemberMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationMemberMasterDTO.CentreCode =!string.IsNullOrEmpty(model.CentreCode) ? model.CentreCode.Split(':')[0]:string.Empty;
                        model.OrganisationMemberMasterDTO.PersonID = model.PersonID;
                        model.OrganisationMemberMasterDTO.PersonType = model.PersonType;
                        model.OrganisationMemberMasterDTO.FirstName= model.FirstName;
                        model.OrganisationMemberMasterDTO.MiddleName= model.MiddleName;
                        model.OrganisationMemberMasterDTO.LastName = model.LastName;
                        model.OrganisationMemberMasterDTO.JoiningDate = model.JoiningDate;
                        model.OrganisationMemberMasterDTO.ShareQuantity= model.ShareQuantity;
                        model.OrganisationMemberMasterDTO.EachSharePrice = model.EachSharePrice;                        
                        model.OrganisationMemberMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationMemberMaster> response = _organisationMemberMasterServiceAcess.InsertOrganisationMemberMaster(model.OrganisationMemberMasterDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCode = model.CentreCode;
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

        //[HttpGet]
        //public ActionResult Delete(int ID, int PersonID)
        //{
        //    OrganisationMemberMasterViewModel model = new OrganisationMemberMasterViewModel();
        //    model.OrganisationMemberMasterDTO = new OrganisationMemberMaster();
        //    model.OrganisationMemberMasterDTO.ID = ID;
        //    model.OrganisationMemberMasterDTO.PersonID = PersonID;
        //    return PartialView("/Views/Organisation/OrganisationMemberMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationMemberMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationMemberMaster OrganisationMemberMasterDTO = new OrganisationMemberMaster();
        //            OrganisationMemberMasterDTO.ConnectionString = _connectioString;
        //            OrganisationMemberMasterDTO.ID = model.ID;
        //            OrganisationMemberMasterDTO.PersonID = model.PersonID;
        //            IBaseEntityResponse<OrganisationMemberMaster> response = _organisationMemberMasterServiceAcess.DeleteOrganisationMemberMaster(OrganisationMemberMasterDTO);
        //            model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int ID)
        {
            OrganisationMemberMasterViewModel model = new OrganisationMemberMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    OrganisationMemberMaster OrganisationMemberMasterDTO = new OrganisationMemberMaster();
                    OrganisationMemberMasterDTO.ConnectionString = _connectioString;
                    OrganisationMemberMasterDTO.ID = ID;
                    OrganisationMemberMasterDTO.PersonID = model.PersonID;
                    IBaseEntityResponse<OrganisationMemberMaster> response = _organisationMemberMasterServiceAcess.DeleteOrganisationMemberMaster(OrganisationMemberMasterDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
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
        public IEnumerable<OrganisationMemberMasterViewModel> GetOrganisationMemberMaster(out int TotalRecords, string CentreCode, string EntityLevel, string AdminRoleMasterID)
        {
            OrganisationMemberMasterSearchRequest searchRequest = new OrganisationMemberMasterSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
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
            }
            List<OrganisationMemberMasterViewModel> listOrganisationMemberMasterViewModel = new List<OrganisationMemberMasterViewModel>();
            List<OrganisationMemberMaster> listOrganisationMemberMaster = new List<OrganisationMemberMaster>();
            IBaseEntityCollectionResponse<OrganisationMemberMaster> baseEntityCollectionResponse = _organisationMemberMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMemberMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationMemberMaster item in listOrganisationMemberMaster)
                    {
                        OrganisationMemberMasterViewModel OrganisationMemberMasterViewModel = new OrganisationMemberMasterViewModel();
                        OrganisationMemberMasterViewModel.OrganisationMemberMasterDTO = item;
                        listOrganisationMemberMasterViewModel.Add(OrganisationMemberMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationMemberMasterViewModel;
        }

        [HttpPost]
        public JsonResult GetUserEntity(string term , string centreCode)
        {
            var data = GetUserEntityList(term,!string.IsNullOrEmpty(centreCode)? centreCode.Split(':')[0]:string.Empty);
            var result = (from r in data select new {
                                                      id = r.ID,
                                                      name = r.FirstName + " " + r.LastName,
                                                      fistName = r.FirstName,
                                                      middleName = r.MiddleName,
                                                      lastName = r.LastName,
                                                      personType = r.PersonType,
                                                      personId = r.PersonID,
                                                    }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<OrganisationMemberMaster> GetUserEntityList(string SearchKeyWord, string centreCode)
        {
            OrganisationMemberMasterSearchRequest searchRequest = new OrganisationMemberMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.CentreCode = centreCode;
            List<OrganisationMemberMaster> listEmployees = new List<OrganisationMemberMaster>();
            IBaseEntityCollectionResponse<OrganisationMemberMaster> baseEntityCollectionResponse = _organisationMemberMasterServiceAcess.GetUserEntityCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployees = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployees;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string EntityLevel)
        {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<OrganisationMemberMasterViewModel> filteredOrganisationMemberMaster;
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
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%' or ShareQuantity Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "JoiningDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%' or ShareQuantity Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "ShareQuantity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%' or ShareQuantity Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    var centreCode = splitCentreCode[0];
                    var scopeIdentity = splitCentreCode[1];
                    var RoleID = "";
                    if (Session["UserType"].ToString() == "A")
                    {
                        RoleID = Convert.ToString(0);
                    }
                    else
                    {
                        RoleID = Session["RoleID"].ToString();
                    }
                    filteredOrganisationMemberMaster = GetOrganisationMemberMaster(out TotalRecords, centreCode, EntityLevel, RoleID);
                }
                else
                {
                    filteredOrganisationMemberMaster = new List<OrganisationMemberMasterViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredOrganisationMemberMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FirstName) + " " + Convert.ToString(c.LastName), Convert.ToString(c.JoiningDate), Convert.ToString(Math.Round(c.ShareQuantity,2)), Convert.ToString(c.PersonType), Convert.ToString(c.PersonID), Convert.ToString(c.ID) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
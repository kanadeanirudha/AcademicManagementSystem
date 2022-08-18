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

namespace AMS.Web.UI.Controllers.Organisation
{
    public class OrganisationDirectorMasterController : BaseController
    {
        #region------------CONTROLLER CLASS VARIABLE------------

        IOrganisationDirectorMasterServiceAccess _organisationDirectorMasterServiceAccess = null;
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
        public OrganisationDirectorMasterController()
        {
            _organisationDirectorMasterServiceAccess = new OrganisationDirectorMasterServiceAccess();

        }

        #endregion


        #region ------------CONTROLLER CLASS ACTION METHOD------------

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                return View("/Views/Organisation/OrganisationDirectorMaster/Index.cshtml");
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
                    return View("/Views/Organisation/OrganisationDirectorMaster/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        //GetAdminRoleApplicableCentreList
        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                OrganisationDirectorMasterViewModel _organisationDirectorMasterViewModel = new OrganisationDirectorMasterViewModel();
                if(!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _organisationDirectorMasterViewModel.CentreCode = splitCentreCode[0];
                    _organisationDirectorMasterViewModel.EntityLevel = splitCentreCode[1];
                }
                else
                {
                    _organisationDirectorMasterViewModel.CentreCode = centerCode;
                    _organisationDirectorMasterViewModel.EntityLevel = null;
                }

                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//

                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails adminRoleApplicableDetail = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        adminRoleApplicableDetail = new AdminRoleApplicableDetails();
                        adminRoleApplicableDetail.CentreCode = item.CentreCode;
                        adminRoleApplicableDetail.CentreName = item.CentreName;
                        adminRoleApplicableDetail.ScopeIdentity = item.ScopeIdentity;
                        _organisationDirectorMasterViewModel.ListGetAdminRoleApplicableCentre.Add(adminRoleApplicableDetail);
                    }
                    _organisationDirectorMasterViewModel.EntityLevel = "Centre";
                    foreach (var item in _organisationDirectorMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        item.CentreCode = item.CentreCode + ":" + "Centre";
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
                    AdminRoleApplicableDetails adminRoleApplicableDetails = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        adminRoleApplicableDetails = new AdminRoleApplicableDetails();
                        adminRoleApplicableDetails.CentreCode = item.CentreCode;
                        adminRoleApplicableDetails.CentreName = item.CentreName;
                        adminRoleApplicableDetails.ScopeIdentity = item.ScopeIdentity;
                        _organisationDirectorMasterViewModel.ListGetAdminRoleApplicableCentre.Add(adminRoleApplicableDetails);
                    }
                    foreach (var item in _organisationDirectorMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        item.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    }
                }
                _organisationDirectorMasterViewModel.CentreCode = centerCode;
                _organisationDirectorMasterViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationDirectorMaster/List.cshtml", _organisationDirectorMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult Create(string CentreCode, string CentreName)
        {
             try
            {
                OrganisationDirectorMasterViewModel model = new OrganisationDirectorMasterViewModel();
                string[] splitData = CentreCode.Split(':');

                model.CentreCode = splitData[0];
                model.CentreName = CentreName;

                //List For Designation Name
                List<EmpDesignationMaster> generalDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> listGeneralDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in generalDesignationMasterList)
                {
                    listGeneralDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralDesignationList = new SelectList(listGeneralDesignationMaster, "Value", "Text");

                return PartialView("/Views/Organisation/OrganisationDirectorMaster/Create.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationDirectorMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (model != null && model.OrganisationDirectorMasterDTO != null)
                    {
                        string[] splitCentreCode = model.CentreCode.Split(':');

                        model.OrganisationDirectorMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationDirectorMasterDTO.OrganisationMembersMasterID = model.OrganisationMembersMasterID;
                        model.OrganisationDirectorMasterDTO.CentreCode = splitCentreCode[0];
                        model.OrganisationDirectorMasterDTO.PersonID = model.PersonID;
                        model.OrganisationDirectorMasterDTO.PersonType = model.PersonType;
                        model.OrganisationDirectorMasterDTO.FirstName = model.FirstName;
                        model.OrganisationDirectorMasterDTO.MiddleName = model.MiddleName;
                        model.OrganisationDirectorMasterDTO.LastName = model.LastName;
                        model.OrganisationDirectorMasterDTO.JoiningDate = model.JoiningDate;
                        model.OrganisationDirectorMasterDTO.PrintingSeqOrder = model.PrintingSeqOrder;
                        model.OrganisationDirectorMasterDTO.IsCurrentDirector = model.IsCurrentDirector;
                        model.OrganisationDirectorMasterDTO.IsLifeTimeDirector = model.IsLifeTimeDirector;
                        model.OrganisationDirectorMasterDTO.DesignationID = model.DesignationID;
                        model.OrganisationDirectorMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<OrganisationDirectorMaster> response = _organisationDirectorMasterServiceAccess.InsertOrganisationDirectorMaster(model.OrganisationDirectorMasterDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                        return Json(model, JsonRequestBehavior.AllowGet);
                    }                   
                    else
                    {
                        return Json("Please review your form");
                    }
                //}
                
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Edit(int ID)
        {
            OrganisationDirectorMasterViewModel model = new OrganisationDirectorMasterViewModel();
            model.OrganisationDirectorMasterDTO = new OrganisationDirectorMaster();
            model.OrganisationDirectorMasterDTO.ConnectionString = _connectioString;
            model.OrganisationDirectorMasterDTO.ID = ID;

            IBaseEntityResponse<OrganisationDirectorMaster> response = _organisationDirectorMasterServiceAccess.SelectByID(model.OrganisationDirectorMasterDTO);
            if (response.Entity != null)
            {
                model.OrganisationDirectorMasterDTO.ID = response.Entity.ID;
                model.OrganisationDirectorMasterDTO.PersonID = response.Entity.PersonID;
                model.OrganisationDirectorMasterDTO.PersonType = response.Entity.PersonType;
                model.OrganisationDirectorMasterDTO.FirstName = response.Entity.FirstName + " " + response.Entity.LastName;
                model.OrganisationDirectorMasterDTO.MiddleName = response.Entity.MiddleName;
                model.OrganisationDirectorMasterDTO.LastName = response.Entity.LastName;
                model.OrganisationDirectorMasterDTO.DesignationID = response.Entity.DesignationID;
                model.OrganisationDirectorMasterDTO.CentreCode = response.Entity.CentreCode;
                model.OrganisationDirectorMasterDTO.IsCurrentDirector = response.Entity.IsCurrentDirector;
                model.OrganisationDirectorMasterDTO.IsLifeTimeDirector = response.Entity.IsLifeTimeDirector;
                model.OrganisationDirectorMasterDTO.JoiningDate = response.Entity.JoiningDate;
                model.OrganisationDirectorMasterDTO.OrganisationMembersMasterID = response.Entity.OrganisationMembersMasterID;
                model.OrganisationDirectorMasterDTO.PrintingSeqOrder = response.Entity.PrintingSeqOrder;
                model.OrganisationDirectorMasterDTO.LeavingDate = response.Entity.LeavingDate;

                //List For Designation Name
                List<EmpDesignationMaster> generalDesignationMasterList = GetListEmpDesignationMaster();
                List<SelectListItem> listGeneralDesignationMaster = new List<SelectListItem>();
                foreach (EmpDesignationMaster item in generalDesignationMasterList)
                {
                    listGeneralDesignationMaster.Add(new SelectListItem { Text = item.Description, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralDesignationList = new SelectList(listGeneralDesignationMaster, "Value", "Text", response.Entity.DesignationID);
            }
            return PartialView("/Views/Organisation/OrganisationDirectorMaster/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(OrganisationDirectorMasterViewModel model)
        {
            try
            {
                if (model.OrganisationDirectorMasterDTO != null)
                {
                    string[] splitCentreCode = model.CentreCode.Split(':');

                    model.OrganisationDirectorMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationDirectorMasterDTO.ID = model.ID;
                    model.OrganisationDirectorMasterDTO.CentreCode = splitCentreCode[0];
                    model.OrganisationDirectorMasterDTO.IsCurrentDirector = model.IsCurrentDirector;
                    model.OrganisationDirectorMasterDTO.IsLifeTimeDirector = model.IsLifeTimeDirector;
                    model.OrganisationDirectorMasterDTO.LeavingDate = model.LeavingDate;
                    model.OrganisationDirectorMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<OrganisationDirectorMaster> response = _organisationDirectorMasterServiceAccess.UpdateOrganisationDirectorMaster(model.OrganisationDirectorMasterDTO);
                    model.OrganisationDirectorMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }



        //Delete Call.
        //public ActionResult Delete(int ID, int PersonID)
        //{
        //    OrganisationDirectorMasterViewModel model = new OrganisationDirectorMasterViewModel();
        //    model.OrganisationDirectorMasterDTO = new OrganisationDirectorMaster();
        //    model.OrganisationDirectorMasterDTO.ID = ID;
        //    model.OrganisationDirectorMasterDTO.PersonID = PersonID;
        //    return PartialView("/Views/Organisation/OrganisationDirectorMaster/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationDirectorMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationDirectorMaster OrganisationDirectorMasterDTO = new OrganisationDirectorMaster();
        //            OrganisationDirectorMasterDTO.ConnectionString = _connectioString;
        //            OrganisationDirectorMasterDTO.ID = model.ID;
        //            OrganisationDirectorMasterDTO.PersonID = model.PersonID;
        //            IBaseEntityResponse<OrganisationDirectorMaster> response = _organisationDirectorMasterServiceAccess.DeleteOrganisationDirectorMaster(OrganisationDirectorMasterDTO);
        //            model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}


        public ActionResult Delete(int ID)
        {
            OrganisationDirectorMasterViewModel model = new OrganisationDirectorMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    OrganisationDirectorMaster OrganisationDirectorMasterDTO = new OrganisationDirectorMaster();
                    OrganisationDirectorMasterDTO.ConnectionString = _connectioString;
                    OrganisationDirectorMasterDTO.ID = ID;
                    OrganisationDirectorMasterDTO.PersonID = model.PersonID;
                    IBaseEntityResponse<OrganisationDirectorMaster> response = _organisationDirectorMasterServiceAccess.DeleteOrganisationDirectorMaster(OrganisationDirectorMasterDTO);
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
        #region Non-Action Method

        public IEnumerable<OrganisationDirectorMasterViewModel> GetOrganisationDirectorMaster(out int TotalRecords, string CentreCode, string EntityLevel, string AdminRoleMasterID)
        {
            OrganisationDirectorMasterSearchRequest searchRequest = new OrganisationDirectorMasterSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<OrganisationDirectorMasterViewModel> listOrganisationDirectorMasterViewModel = new List<OrganisationDirectorMasterViewModel>();
            List<OrganisationDirectorMaster> listOrganisationDirectorMaster = new List<OrganisationDirectorMaster>();
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> baseEntityCollectionResponse = _organisationDirectorMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDirectorMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationDirectorMaster item in listOrganisationDirectorMaster)
                    {
                        OrganisationDirectorMasterViewModel organisationDirectMasterViewModel = new OrganisationDirectorMasterViewModel();
                        organisationDirectMasterViewModel.OrganisationDirectorMasterDTO = item;
                        listOrganisationDirectorMasterViewModel.Add(organisationDirectMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationDirectorMasterViewModel;
        }

        [HttpPost]
        public JsonResult GetUserEntity(string term, string centreCode)
        {
            var data = GetUserEntityList(term, !string.IsNullOrEmpty(centreCode) ? centreCode.Split(':')[0] : string.Empty);
            var result = (from r in data
                          select new
                          {
                              id = r.OrganisationMembersMasterID,
                              name = r.FirstName + " " + r.LastName,
                              fistName = r.FirstName,
                              middleName = r.MiddleName,
                              lastName = r.LastName,
                              personType = r.PersonType,
                              personId = r.PersonID                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected List<OrganisationDirectorMaster> GetUserEntityList(string SearchKeyWord, string centreCode)
        {
            OrganisationDirectorMasterSearchRequest searchRequest = new OrganisationDirectorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.CentreCode = centreCode;
            List<OrganisationDirectorMaster> listEmployees = new List<OrganisationDirectorMaster>();
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> baseEntityCollectionResponse = _organisationDirectorMasterServiceAccess.GetUserEntityCentrewiseSearchList(searchRequest);
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

            IEnumerable<OrganisationDirectorMasterViewModel> filteredOrganisationDirectorMaster;

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
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "Designation";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "JoiningDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or LastName Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%' or JoiningDate Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
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
                filteredOrganisationDirectorMaster = GetOrganisationDirectorMaster(out TotalRecords, centreCode, EntityLevel, RoleID);
            }
            else
            {
                filteredOrganisationDirectorMaster = new List<OrganisationDirectorMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOrganisationDirectorMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FirstName) + " " + Convert.ToString(c.LastName), Convert.ToString(c.Designation), Convert.ToString(c.JoiningDate), Convert.ToString(c.IsCurrentDirector), Convert.ToString(c.ID), Convert.ToString(c.PersonType), Convert.ToString(c.PersonID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        #endregion

    }
}

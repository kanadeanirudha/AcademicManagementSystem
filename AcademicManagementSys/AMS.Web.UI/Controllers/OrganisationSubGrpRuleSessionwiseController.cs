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
    public class OrganisationSubGrpRuleSessionwiseController : BaseController
    {
        IOrganisationSubGrpRuleSessionwiseServiceAccess _organisationSubGrpRuleSessionwiseServiceAccess = null;
        OrganisationSubGrpRuleSessionwiseBaseViewModel _organisationSubGrpRuleSessionwiseBaseViewModel = null;
        IOrganisationSubjectGrpRuleServiceAccess _organisationSubjectGrpRuleServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        string _centreCode = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSubGrpRuleSessionwiseController()
        {
            _organisationSubjectGrpRuleServiceAccess = new OrganisationSubjectGrpRuleServiceAccess();
            _organisationSubGrpRuleSessionwiseServiceAccess = new OrganisationSubGrpRuleSessionwiseServiceAccess();
            _organisationSubGrpRuleSessionwiseBaseViewModel = new OrganisationSubGrpRuleSessionwiseBaseViewModel();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0)
            {
                return View();
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

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);

                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
        }

        public ActionResult List(string centerCode, string universityID, string actionMode)
        {
            try
            {
                OrganisationSubGrpRuleSessionwiseBaseViewModel model = new OrganisationSubGrpRuleSessionwiseBaseViewModel();
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(splitCentreCode[0]);
                    List<OrganisationCentrewiseSession> list = GetCurrentSession(centerCode);
                    model.SessionName = list.Count > 0 ? list[0].SessionName : "Session not defined !";
                    model.SessionID = list.Count > 0 ? list[0].SessionID : 0;
                }
                else
                {
                    // List<OrganisationCentrewiseSession> list = GetCurrentSession(model.ListGetAdminRoleApplicableCentre[0].CentreCode);
                    model.SessionName = "Session not defined !";
                    model.SessionID = 0;
                }
                model.SelectedCentreCode = centerCode;
                model.SelectedUniversityID = universityID;
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

        [HttpGet]
        public ActionResult Create(int ID, int CourseYearSemesterID, string RuleName, int SessionID, string SessionName, int OrgSessionCryAllocationID)
        {
            try
            {
                OrganisationSubGrpRuleSessionwiseViewModel model = new OrganisationSubGrpRuleSessionwiseViewModel();

                model.OrganisationSubGrpRuleSessionwiseDTO = new OrganisationSubGrpRuleSessionwise();
                model.OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber = ID;
                model.OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID = CourseYearSemesterID;
                model.OrganisationSubGrpRuleSessionwiseDTO.OrgSessionCryAllocationID = OrgSessionCryAllocationID;
                model.OrganisationSubGrpRuleSessionwiseDTO.SessionID = SessionID;
                model.OrganisationSubGrpRuleSessionwiseDTO.RuleName = RuleName.Replace('$', ' ');
                model.OrganisationSubGrpRuleSessionwiseDTO.SessionName = SessionName.Replace('$', ' ');
                
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(OrganisationSubGrpRuleSessionwiseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationSubGrpRuleSessionwiseDTO != null)
                    {
                        model.OrganisationSubGrpRuleSessionwiseDTO.ConnectionString = _connectioString;

                        model.OrganisationSubGrpRuleSessionwiseDTO.SessionID = model.SessionID;
                        model.OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber = model.SubjectRuleGrpNumber;
                        model.OrganisationSubGrpRuleSessionwiseDTO.OrgSessionCryAllocationID = model.OrgSessionCryAllocationID;
                        model.OrganisationSubGrpRuleSessionwiseDTO.IsActive = true;
                        model.OrganisationSubGrpRuleSessionwiseDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> response = _organisationSubGrpRuleSessionwiseServiceAccess.InsertOrganisationSubGrpRuleSessionwise(model.OrganisationSubGrpRuleSessionwiseDTO);
                        model.OrganisationSubGrpRuleSessionwiseDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationSubGrpRuleSessionwiseDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int OrgSubGrpSessionwiseID, string RuleName, string SessionName)
        {
            try
            {
                OrganisationSubGrpRuleSessionwiseViewModel model = new OrganisationSubGrpRuleSessionwiseViewModel();
                model.OrganisationSubGrpRuleSessionwiseDTO = new OrganisationSubGrpRuleSessionwise();
                model.OrganisationSubGrpRuleSessionwiseDTO.ID = OrgSubGrpSessionwiseID;
                model.OrganisationSubGrpRuleSessionwiseDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> response = _organisationSubGrpRuleSessionwiseServiceAccess.SelectByID(model.OrganisationSubGrpRuleSessionwiseDTO);

                if (response != null && response.Entity != null)
                {
                    model.OrganisationSubGrpRuleSessionwiseDTO.ID = response.Entity.ID;
                    model.OrganisationSubGrpRuleSessionwiseDTO.IsActive = response.Entity.IsActive;
                    model.OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID = response.Entity.CourseYearSemesterID;
                    model.OrganisationSubGrpRuleSessionwiseDTO.SessionID = response.Entity.SessionID;
                    model.OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber = response.Entity.SubjectRuleGrpNumber;
                    model.OrganisationSubGrpRuleSessionwiseDTO.RuleName = RuleName.Replace('$', ' ');
                    model.OrganisationSubGrpRuleSessionwiseDTO.SessionName = SessionName.Replace('$', ' ');
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
        public ActionResult Edit(OrganisationSubGrpRuleSessionwiseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSubGrpRuleSessionwiseDTO != null)
                    {
                        if (model != null && model.OrganisationSubGrpRuleSessionwiseDTO != null)
                        {
                            model.OrganisationSubGrpRuleSessionwiseDTO.ConnectionString = _connectioString;
                            model.OrganisationSubGrpRuleSessionwiseDTO.ID = model.ID;
                            model.OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                            model.OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber = model.SubjectRuleGrpNumber;
                            model.OrganisationSubGrpRuleSessionwiseDTO.SessionID = model.SessionID;
                            model.OrganisationSubGrpRuleSessionwiseDTO.IsActive = false;
                            model.OrganisationSubGrpRuleSessionwiseDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> response = _organisationSubGrpRuleSessionwiseServiceAccess.UpdateOrganisationSubGrpRuleSessionwise(model.OrganisationSubGrpRuleSessionwiseDTO);
                            model.OrganisationSubGrpRuleSessionwiseDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.OrganisationSubGrpRuleSessionwiseDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _organisationSubGrpRuleSessionwiseBaseViewModel.SelectedCentreName = splited[1];
            SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region Methods

        [NonAction]
        protected IEnumerable<OrganisationSubjectGrpRuleViewModel> GetOrganisationSubGrpRule(string centreCode, int universityID, string CurrentSessionID, out int TotalRecords)
        {

            OrganisationSubjectGrpRuleSearchRequest searchRequest = new OrganisationSubjectGrpRuleSearchRequest();
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

                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.ScopeIdentity = Centre_code[1];

                    searchRequest.UniversityID = universityID;
                    searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

                    if (Session["RoleID"] == null)
                    {
                        searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";

                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.ScopeIdentity = Centre_code[1];

                    searchRequest.UniversityID = universityID;
                    searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

                    if (Session["RoleID"] == null)
                    {
                        searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;

                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                searchRequest.ScopeIdentity = Centre_code[1];

                searchRequest.UniversityID = universityID;
                searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
            }
            List<OrganisationSubjectGrpRuleViewModel> listOrganisationSubjectGrpRuleViewModel = new List<OrganisationSubjectGrpRuleViewModel>();
            List<OrganisationSubjectGrpRule> listOrganisationSubjectGrpRule = new List<OrganisationSubjectGrpRule>();
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollectionResponse = _organisationSubjectGrpRuleServiceAccess.GetForOrgSubGrpRuleSessionwise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGrpRule = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSubjectGrpRule item in listOrganisationSubjectGrpRule)
                    {
                        OrganisationSubjectGrpRuleViewModel OrganisationSubjectGrpRuleViewModel = new OrganisationSubjectGrpRuleViewModel();
                        OrganisationSubjectGrpRuleViewModel.OrganisationSubjectGrpRuleDTO = item;
                        listOrganisationSubjectGrpRuleViewModel.Add(OrganisationSubjectGrpRuleViewModel);
                    }
                }
            }
             TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSubjectGrpRuleViewModel;
        }
       
        #endregion


        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CurrentSessionID, string SelectedUniversityID, string SelectedCentreCode)
          {
              int TotalRecords;
              var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
              string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

              IEnumerable<OrganisationSubjectGrpRuleViewModel> filteredGetOrganisationSubGrpRule;
              switch (Convert.ToInt32(sortColumnIndex))
              {
                  case 0:
                      _sortBy = "RuleName";
                      if (string.IsNullOrEmpty(param.sSearch))
                      {
                          _searchBy = string.Empty;
                      }
                      else
                      {
                          _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                      }
                      break;
                  case 2:
                      _sortBy = "RuleCode";
                      if (string.IsNullOrEmpty(param.sSearch))
                      {
                          _searchBy = string.Empty;
                      }
                      else
                      {
                          _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                      }
                      break;
                  case 3:
                      _sortBy = "BranchShortCode";
                      if (string.IsNullOrEmpty(param.sSearch))
                      {
                          _searchBy = string.Empty;
                      }
                      else
                      {
                          _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                      }
                      break;
                  case 4:
                      _sortBy = "OrgSemesterName";
                      if (string.IsNullOrEmpty(param.sSearch))
                      {
                          _searchBy = string.Empty;
                      }
                      else
                      {
                          _searchBy = "RuleName Like '%" + param.sSearch + "%' or RuleCode Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                      }
                      break;
              }
              _sortDirection = sortDirection;
              _rowLength = param.iDisplayLength;
              _startRow = param.iDisplayStart;
              if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID) && !string.IsNullOrEmpty(CurrentSessionID))
              {
                  filteredGetOrganisationSubGrpRule = GetOrganisationSubGrpRule(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), CurrentSessionID, out TotalRecords);
              }
              else
              {
                  filteredGetOrganisationSubGrpRule = new List<OrganisationSubjectGrpRuleViewModel>();
                  TotalRecords = 0;
              }
              var records = filteredGetOrganisationSubGrpRule.Skip(0).Take(param.iDisplayLength);
              var result = from c in records select new[] { c.RuleName.ToString(), c.BranchDescription.ToString(), c.RuleCode.ToString(), c.BranchShortCode.ToString(), c.SemesterName.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.ID), Convert.ToString(c.OrgSubGrpRuleSessionwiseID), Convert.ToString(c.CourseYearSemesterID), Convert.ToString(c.SessionCryAllocationStatus), Convert.ToString(c.OrgSessionCryAllocationID) };
            
              return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
          }
          #endregion


    }
}
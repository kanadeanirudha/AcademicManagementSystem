using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;


namespace AMS.Web.UI.Controllers
{
    public class OrganisationSyllabusGroupMasterController : BaseController
    {
        IOrganisationSyllabusGroupMasterServiceAccess _organisationSyllabusGroupMasterServiceAccessServiceAccess = null;
        // OrganisationSyllabusGroupMasterBaseViewModel model = null;
        private readonly ILogger _logException;
        string _centreCode = string.Empty;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSyllabusGroupMasterController()
        {
            _organisationSyllabusGroupMasterServiceAccessServiceAccess = new OrganisationSyllabusGroupMasterServiceAccess();
            //model = new OrganisationSyllabusGroupMasterBaseViewModel();

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
                OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre" ;
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
        public ActionResult CreateSyllabusGroupDetails(string SubjectGroupID, int ID, string _subjectName)
        {

            try
            {
                OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();
                string[] splitSubjectGroupID = (SubjectGroupID.Split(':'));
                string[] splitSubjectName = (_subjectName.Split(':'));
                if (ID <= 0)
                {
                    //Add OrgSyllabusGroupMaster        

                    model.OrganisationSyllabusGroupMasterDTO.ConnectionString = _connectioString;

                    model.OrganisationSyllabusGroupMasterDTO.SubjectGroupID = Convert.ToInt32(splitSubjectGroupID[0]);
                    model.OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber = Convert.ToInt16(splitSubjectGroupID[1]);
                    //model.OrganisationSyllabusGroupMasterDTO.SubjectGroupDesc = (splitSubjectGroupID[3]);
                    model.OrganisationSyllabusGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationSyllabusGroupMaster> response = _organisationSyllabusGroupMasterServiceAccessServiceAccess.InsertOrganisationSyllabusGroupMaster(model.OrganisationSyllabusGroupMasterDTO);
                    model.SyllabusGroupID = response.Entity.ID;
                    for (int i = 0; i < splitSubjectName.Length; i++)
                    {
                        model.SubjectGroupDesc += splitSubjectName[i] + ' ';
                    }
                    model.SubjectGroupDesc.TrimEnd(' ');
                }

                else if (ID > 0)
                {
                    //Update OrgSyllabusGroupMaster
                    model.SyllabusGroupID = ID;
                    for (int i = 0; i < splitSubjectName.Length; i++)
                    {
                        model.SubjectGroupDesc += splitSubjectName[i] + ' ';
                    }
                    model.SubjectGroupDesc.TrimEnd(' ');
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
        public ActionResult CreateSyllabusGroupDetails(OrganisationSyllabusGroupMasterViewModel model)
        {
            try
            {
                if (model.SyllabusGrpDetailsID <= 0)
                {
                    // Add 
                    model.OrganisationSyllabusGroupMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationSyllabusGroupMasterDTO.SyllabusGroupID = model.SyllabusGroupID;
                    model.OrganisationSyllabusGroupMasterDTO.UnitDescription = model.UnitDescription;
                    model.OrganisationSyllabusGroupMasterDTO.NoOfLecturesForUnit = model.NoOfLecturesForUnit;
                    model.OrganisationSyllabusGroupMasterDTO.UnitWeightage = model.UnitWeightage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitPercentage = model.UnitPercentage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitStatus = model.UnitStatus;
                    model.OrganisationSyllabusGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<OrganisationSyllabusGroupMaster> response = _organisationSyllabusGroupMasterServiceAccessServiceAccess.InsertOrganisationSyllabusDetails(model.OrganisationSyllabusGroupMasterDTO);
                    model.OrganisationSyllabusGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                else if (model.SyllabusGrpDetailsID >= 0)
                {
                    //Update

                    model.OrganisationSyllabusGroupMasterDTO.ConnectionString = _connectioString;

                    model.OrganisationSyllabusGroupMasterDTO.SyllabusGroupID = model.SyllabusGroupID;
                    model.OrganisationSyllabusGroupMasterDTO.UnitDescription = model.UnitDescription;
                    model.OrganisationSyllabusGroupMasterDTO.NoOfLecturesForUnit = model.NoOfLecturesForUnit;
                    model.OrganisationSyllabusGroupMasterDTO.UnitWeightage = model.UnitWeightage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitPercentage = model.UnitPercentage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitStatus = model.UnitStatus;
                    model.OrganisationSyllabusGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationSyllabusGroupMaster> response = _organisationSyllabusGroupMasterServiceAccessServiceAccess.UpdateOrganisationSyllabusDetails(model.OrganisationSyllabusGroupMasterDTO);
                    model.OrganisationSyllabusGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.OrganisationSyllabusGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateSyllabusGroupTopics(int ID, string IDs, string _unitName, int SyllabusGroupID, string _subjectName)
        {
            try
            {
                OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();
                string[] splitIDs = IDs.Split(':');
                string[] splitSubjectName = (_subjectName.Split(':'));
                model.SyllabusGroupID = SyllabusGroupID;
                model.SyllabusGroupDetID = ID;
                model.SubjectGroupID = Convert.ToInt32(splitIDs[0]);
                model.SubjectTypeNumber = Convert.ToInt16(splitIDs[1]);
                model.OrgSemesterMstID = Convert.ToInt32(splitIDs[2]);
                string[] splitUnitName = (_unitName.Split(':'));
                for (int i = 0; i < splitUnitName.Length; i++)
                {
                    model.UnitDescription += splitUnitName[i] + ' ';
                }
                model.UnitDescription.TrimEnd(' ');
                for (int i = 0; i < splitSubjectName.Length; i++)
                {
                    model.SubjectGroupDesc += splitSubjectName[i] + ' ';
                }
                model.SubjectGroupDesc.TrimEnd(' ');
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult CreateSyllabusGroupTopics(OrganisationSyllabusGroupMasterViewModel model)
        {
            try
            {
                if (model.SyllabusGrpTopicsID <= 0)
                {
                    //Add
                    model.OrganisationSyllabusGroupMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationSyllabusGroupMasterDTO.SyllabusGroupDetID = model.SyllabusGroupDetID;
                    model.OrganisationSyllabusGroupMasterDTO.SubjectGroupID = model.SubjectGroupID;
                    model.OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber = model.SubjectTypeNumber;
                    model.OrganisationSyllabusGroupMasterDTO.OrgSemesterMstID = model.OrgSemesterMstID;
                    model.OrganisationSyllabusGroupMasterDTO.TopicName = model.TopicName;
                    model.OrganisationSyllabusGroupMasterDTO.TopicDescription = model.TopicDescription;
                    model.OrganisationSyllabusGroupMasterDTO.NoOfLecturesForTopic = model.NoOfLecturesForTopic;
                    model.OrganisationSyllabusGroupMasterDTO.TopicWeightage = model.TopicWeightage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitPercentage = model.UnitPercentage;
                    model.OrganisationSyllabusGroupMasterDTO.TopicStatus = model.TopicStatus;
                    model.OrganisationSyllabusGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<OrganisationSyllabusGroupMaster> response = _organisationSyllabusGroupMasterServiceAccessServiceAccess.InsertOrganisationSyllabusTopics(model.OrganisationSyllabusGroupMasterDTO);
                    model.OrganisationSyllabusGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                else if (model.SyllabusGrpTopicsID >= 0)
                {
                    //Update

                    model.OrganisationSyllabusGroupMasterDTO.ConnectionString = _connectioString;

                    model.OrganisationSyllabusGroupMasterDTO.SyllabusGroupDetID = model.SyllabusGroupDetID;
                    model.OrganisationSyllabusGroupMasterDTO.SubjectGroupID = model.SubjectGroupID;
                    model.OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber = model.SubjectTypeNumber;
                    model.OrganisationSyllabusGroupMasterDTO.OrgSemesterMstID = model.OrgSemesterMstID;
                    model.OrganisationSyllabusGroupMasterDTO.TopicName = model.TopicName;
                    model.OrganisationSyllabusGroupMasterDTO.TopicDescription = model.TopicDescription;
                    model.OrganisationSyllabusGroupMasterDTO.NoOfLecturesForTopic = model.NoOfLecturesForTopic;
                    model.OrganisationSyllabusGroupMasterDTO.TopicWeightage = model.TopicWeightage;
                    model.OrganisationSyllabusGroupMasterDTO.UnitPercentage = model.UnitPercentage;
                    model.OrganisationSyllabusGroupMasterDTO.TopicStatus = model.TopicStatus;
                    model.OrganisationSyllabusGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<OrganisationSyllabusGroupMaster> response = _organisationSyllabusGroupMasterServiceAccessServiceAccess.UpdateOrganisationSyllabusTopics(model.OrganisationSyllabusGroupMasterDTO);
                    model.OrganisationSyllabusGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }

                return Json(model.OrganisationSyllabusGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #region Non-Action Methods
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            model.SelectedCentreName = splited[1];
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSessionDetails(string SelectedCentreCode)
        {
            string[] vcentreCode = SelectedCentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 0);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.SessionName,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        protected IEnumerable<OrganisationSyllabusGroupMasterViewModel> GetOrganisationSyllabusGroupMaster(string centreCode, int universityID, string CurrentSessionID, out int TotalRecords)
        {

            OrganisationSyllabusGroupMasterSearchRequest searchRequest = new OrganisationSyllabusGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
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
            List<OrganisationSyllabusGroupMasterViewModel> listOrganisationSyllabusGroupMasterViewModel = new List<OrganisationSyllabusGroupMasterViewModel>();
            List<OrganisationSyllabusGroupMaster> listOrganisationSyllabusGroupMaster = new List<OrganisationSyllabusGroupMaster>();
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollectionResponse = _organisationSyllabusGroupMasterServiceAccessServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSyllabusGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSyllabusGroupMaster item in listOrganisationSyllabusGroupMaster)
                    {
                        OrganisationSyllabusGroupMasterViewModel OrganisationSyllabusGroupMasterViewModel = new OrganisationSyllabusGroupMasterViewModel();
                        OrganisationSyllabusGroupMasterViewModel.OrganisationSyllabusGroupMasterDTO = item;
                        listOrganisationSyllabusGroupMasterViewModel.Add(OrganisationSyllabusGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSyllabusGroupMasterViewModel;
        }

        [NonAction]
        protected IEnumerable<OrganisationSyllabusGroupMasterViewModel> GetOrganisationSyllabusGroupDetails(int SyllabusGroupID, out int TotalRecords)
        {

            OrganisationSyllabusGroupMasterSearchRequest searchRequest = new OrganisationSyllabusGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.SyllabusGroupID = SyllabusGroupID;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            List<OrganisationSyllabusGroupMasterViewModel> listOrganisationSyllabusGroupMasterViewModel = new List<OrganisationSyllabusGroupMasterViewModel>();
            List<OrganisationSyllabusGroupMaster> listOrganisationSyllabusGroupMaster = new List<OrganisationSyllabusGroupMaster>();
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollectionResponse = _organisationSyllabusGroupMasterServiceAccessServiceAccess.GetOrganisationSyllabusDetailsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSyllabusGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSyllabusGroupMaster item in listOrganisationSyllabusGroupMaster)
                    {
                        OrganisationSyllabusGroupMasterViewModel OrganisationSyllabusGroupMasterViewModel = new OrganisationSyllabusGroupMasterViewModel();
                        OrganisationSyllabusGroupMasterViewModel.OrganisationSyllabusGroupMasterDTO = item;
                        listOrganisationSyllabusGroupMasterViewModel.Add(OrganisationSyllabusGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSyllabusGroupMasterViewModel;
        }

        [NonAction]
        protected IEnumerable<OrganisationSyllabusGroupMasterViewModel> GetOrganisationSyllabusGroupTopics(int SyllabusGroupDetID, out int TotalRecords)
        {

            OrganisationSyllabusGroupMasterSearchRequest searchRequest = new OrganisationSyllabusGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.SyllabusGroupDetID = SyllabusGroupDetID;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            List<OrganisationSyllabusGroupMasterViewModel> listOrganisationSyllabusGroupMasterViewModel = new List<OrganisationSyllabusGroupMasterViewModel>();
            List<OrganisationSyllabusGroupMaster> listOrganisationSyllabusGroupMaster = new List<OrganisationSyllabusGroupMaster>();
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollectionResponse = _organisationSyllabusGroupMasterServiceAccessServiceAccess.GetOrganisationSyllabusTopicsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSyllabusGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSyllabusGroupMaster item in listOrganisationSyllabusGroupMaster)
                    {
                        OrganisationSyllabusGroupMasterViewModel OrganisationSyllabusGroupMasterViewModel = new OrganisationSyllabusGroupMasterViewModel();
                        OrganisationSyllabusGroupMasterViewModel.OrganisationSyllabusGroupMasterDTO = item;
                        listOrganisationSyllabusGroupMasterViewModel.Add(OrganisationSyllabusGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSyllabusGroupMasterViewModel;
        }
        #endregion



        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CurrentSessionID, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSyllabusGroupMasterViewModel> filteredGetSyllabusGroupMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SubjectGroupDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%' or SubjectGroupShortDescription Like '%" + param.sSearch + "%' or TypeName Like '%" + param.sSearch + "%'  or RuleName Like '%" + param.sSearch + "%'   or CourseYearCode Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "SubjectGroupShortDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%' or SubjectGroupShortDescription Like '%" + param.sSearch + "%' or TypeName Like '%" + param.sSearch + "%'  or RuleName Like '%" + param.sSearch + "%'   or CourseYearCode Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "TypeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SubjectGroupDescription Like '%" + param.sSearch + "%' or SubjectGroupShortDescription Like '%" + param.sSearch + "%' or TypeName Like '%" + param.sSearch + "%'  or RuleName Like '%" + param.sSearch + "%'   or CourseYearCode Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID)&& !string.IsNullOrEmpty(CurrentSessionID))
            {
                filteredGetSyllabusGroupMaster = GetOrganisationSyllabusGroupMaster(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), CurrentSessionID, out TotalRecords);
            }
            else
            {
                filteredGetSyllabusGroupMaster = new List<OrganisationSyllabusGroupMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredGetSyllabusGroupMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SubjectGroupDesc.ToString() + c.RuleName.ToString(), c.GroupingColumn.ToString(), c.SubjectGroupShortDesc.ToString(), c.SubjectTypeName, c.StatusFlag.ToString(), c.SubjectGroupID.ToString() + ":" + c.SubjectTypeNumber.ToString() + ":" + c.OrgSemesterMstID.ToString(), c.ID.ToString(), c.SubjectName.ToString() };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxHandlerOrgSyllabusGroupDetails(JQueryDataTableParamModel param, int SyllabusGroupID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<OrganisationSyllabusGroupMasterViewModel> filteredGetOrganisationSyllabusGroupDetails;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    break;
                case 1:
                    _sortBy = "NoOfLectures";
                    break;
                case 2:
                    _sortBy = "Weightage";
                    break;
                case 3:
                    _sortBy = "Description";
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered             
                var BranchDescriptionFilter = Convert.ToString(Request["sSearch_0"]);
                var StatusFlagFilter = Convert.ToString(Request["sSearch_1"]);


                //Optionally check whether the columns are searchable at all                
                var isBranchDescriptionSearchable = Convert.ToBoolean(Request["bSearchable_0"]);
                var isStatusFlagSearchable = Convert.ToBoolean(Request["bSearchable_1"]);


                filteredGetOrganisationSyllabusGroupDetails = GetOrganisationSyllabusGroupDetails(SyllabusGroupID, out TotalRecords)
                .Where(c => isBranchDescriptionSearchable && c.CourseYearCode.ToLower().Contains(param.sSearch.ToLower())
                            ||
                            isStatusFlagSearchable && c.OrgSemesterName.ToString().Contains(param.sSearch.ToLower()));
            }
            else
            {

                filteredGetOrganisationSyllabusGroupDetails = GetOrganisationSyllabusGroupDetails(SyllabusGroupID, out TotalRecords);
            }

            var isBranchDescriptionSortable = Convert.ToBoolean(Request["bSortable_0"]);
            var isStatusFlagSortable = Convert.ToBoolean(Request["bSortable_1"]);




            if (sortColumnIndex == 0)
            {
                if (sortDirection == "asc")
                {
                    filteredGetOrganisationSyllabusGroupDetails = filteredGetOrganisationSyllabusGroupDetails.OrderBy(x => x.UnitDescription);
                }
                else if (sortDirection == "desc")
                {
                    filteredGetOrganisationSyllabusGroupDetails = filteredGetOrganisationSyllabusGroupDetails.OrderByDescending(x => x.UnitDescription);
                }
            }
            else if (sortColumnIndex == 1)
            {
                if (sortDirection == "asc")
                {
                    filteredGetOrganisationSyllabusGroupDetails = filteredGetOrganisationSyllabusGroupDetails.OrderBy(x => x.UnitDescription);
                }
                else if (sortDirection == "desc")
                {
                    filteredGetOrganisationSyllabusGroupDetails = filteredGetOrganisationSyllabusGroupDetails.OrderByDescending(x => x.UnitDescription);
                }
            }

            var SyllabusGroupDetails = filteredGetOrganisationSyllabusGroupDetails.Skip(0).Take(param.iDisplayLength);



            var result = from c in SyllabusGroupDetails select new[] { c.SyllabusGrpDetailsID.ToString(), c.UnitDescription.ToString(), c.NoOfLecturesForUnit.ToString(), c.UnitWeightage, c.UnitStatus.ToString(), c.SyllabusGrpDetailsID.ToString(), c.UnitName };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
            JsonRequestBehavior.AllowGet);


        }

        public ActionResult AjaxHandlerOrgSyllabusGroupTopics(JQueryDataTableParamModel param, int SyllabusGroupDetID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<OrganisationSyllabusGroupMasterViewModel> filteredGetOrganisationSyllabusGroupTopics;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TopicName";
                    break;
                case 1:
                    _sortBy = "NoOfLectures";
                    break;
                case 2:
                    _sortBy = "Weightage";
                    break;
                case 3:
                    _sortBy = "Description";
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered             
                var BranchDescriptionFilter = Convert.ToString(Request["sSearch_0"]);
                var StatusFlagFilter = Convert.ToString(Request["sSearch_1"]);


                //Optionally check whether the columns are searchable at all                
                var isBranchDescriptionSearchable = Convert.ToBoolean(Request["bSearchable_0"]);
                var isStatusFlagSearchable = Convert.ToBoolean(Request["bSearchable_1"]);


                filteredGetOrganisationSyllabusGroupTopics = GetOrganisationSyllabusGroupTopics(SyllabusGroupDetID, out TotalRecords)
                .Where(c => isBranchDescriptionSearchable && c.TopicName.ToLower().Contains(param.sSearch.ToLower())
                            ||
                            isStatusFlagSearchable && c.TopicName.ToString().Contains(param.sSearch.ToLower()));
            }
            else
            {

                filteredGetOrganisationSyllabusGroupTopics = GetOrganisationSyllabusGroupTopics(SyllabusGroupDetID, out TotalRecords);
            }

            var isBranchDescriptionSortable = Convert.ToBoolean(Request["bSortable_0"]);
            var isStatusFlagSortable = Convert.ToBoolean(Request["bSortable_1"]);




            if (sortColumnIndex == 0)
            {
                if (sortDirection == "asc")
                {
                    filteredGetOrganisationSyllabusGroupTopics = filteredGetOrganisationSyllabusGroupTopics.OrderBy(x => x.TopicName);
                }
                else if (sortDirection == "desc")
                {
                    filteredGetOrganisationSyllabusGroupTopics = filteredGetOrganisationSyllabusGroupTopics.OrderByDescending(x => x.TopicName);
                }
            }
            else if (sortColumnIndex == 1)
            {
                if (sortDirection == "asc")
                {
                    filteredGetOrganisationSyllabusGroupTopics = filteredGetOrganisationSyllabusGroupTopics.OrderBy(x => x.TopicName);
                }
                else if (sortDirection == "desc")
                {
                    filteredGetOrganisationSyllabusGroupTopics = filteredGetOrganisationSyllabusGroupTopics.OrderByDescending(x => x.TopicName);
                }
            }

            var SyllabusGroupTopics = filteredGetOrganisationSyllabusGroupTopics.Skip(0).Take(param.iDisplayLength);



            var result = from c in SyllabusGroupTopics select new[] { c.SyllabusGrpTopicsID.ToString(), c.TopicName.ToString(), c.TopicDescription.ToString(), c.NoOfLecturesForTopic.ToString(), c.TopicWeightage, c.TopicStatus.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
            JsonRequestBehavior.AllowGet);


        }

        #endregion


    }
}
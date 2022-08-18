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
    public class OrganisationSubjectGroupDetailsController : BaseController
    {
        IOrganisationSubjectGroupDetailsServiceAccess _OrganisationSubjectGroupDetailsServiceAccess = null;
        OrganisationSubjectGroupDetailsViewModel _OrganisationSubjectGroupDetailsViewModel = null;
        string _centreCode = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSubjectGroupDetailsController()
        {
            _OrganisationSubjectGroupDetailsServiceAccess = new OrganisationSubjectGroupDetailsServiceAccess();
            _OrganisationSubjectGroupDetailsViewModel = new OrganisationSubjectGroupDetailsViewModel();
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
                OrganisationSubjectGroupDetailsViewModel model = new OrganisationSubjectGroupDetailsViewModel();
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
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(splitCentreCode[0]);
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
        public ActionResult Create(string IDs, int universityID, string CentreCode)
        {
            string[] Arrays = IDs.Split('~');
            OrganisationSubjectGroupDetailsViewModel model = new OrganisationSubjectGroupDetailsViewModel();

            try
            {
                model.OrganisationSubjectGroupDetailsDTO.UniversityID = universityID;
                model.OrganisationSubjectGroupDetailsDTO.CentreCode = CentreCode;

                int SubjectGrpID = Convert.ToInt32(Arrays[3]);
                model.OrganisationSubjectGroupDetailsDTO.ConnectionString = _connectioString;
                model.OrganisationSubjectGroupDetailsDTO.OrgSemesterMstID = Convert.ToInt32(Arrays[0]);
                model.OrganisationSubjectGroupDetailsDTO.CourseYearDetailID = Convert.ToInt32(Arrays[1]);
                model.OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber = Convert.ToInt32(Arrays[2]);
                model.OrganisationSubjectGroupDetailsDTO.ID = SubjectGrpID;


                List<OrganisationSubjectGroupDetails> OrganisationElectiveGroupList = GetListOrganisationElectiveGroup(model.OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber);
                List<SelectListItem> OrganisationElectiveGroupMaster = new List<SelectListItem>();
                foreach (OrganisationSubjectGroupDetails item in OrganisationElectiveGroupList)
                {
                    OrganisationElectiveGroupMaster.Add(new SelectListItem { Text = item.ElectiveGroupName.ToString(), Value = item.OrgElectiveGrpID.ToString() });
                }

                ViewBag.OrganisationElectiveGroupMaster = new SelectList(OrganisationElectiveGroupMaster, "Value", "Text");

                int CurrentSessionID = 0;
                model.OrganisationSubjectTypeMasterList = GetListOrganisationSubjectTypeMaster(SubjectGrpID, CurrentSessionID);

                IBaseEntityResponse<OrganisationSubjectGroupDetails> response = _OrganisationSubjectGroupDetailsServiceAccess.SelectByID(model.OrganisationSubjectGroupDetailsDTO);

                model.OrganisationSubjectGroupDetailsDTO.SessionID = 0;
                if (response != null && response.Entity != null)
                {
                    model.OrganisationSubjectGroupDetailsDTO.ID = response.Entity.ID;
                    model.OrganisationSubjectGroupDetailsDTO.SubjectID = response.Entity.SubjectID;
                    model.OrganisationSubjectGroupDetailsDTO.Description = response.Entity.Description;
                    model.OrganisationSubjectGroupDetailsDTO.ShortDescription = response.Entity.ShortDescription;
                    model.OrganisationSubjectGroupDetailsDTO.UniversityCode = response.Entity.UniversityCode;

                    model.OrganisationSubjectGroupDetailsDTO.IsCompulsory = response.Entity.IsCompulsory;
                    model.OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID = response.Entity.OrgElectiveGrpID;

                    model.OrganisationSubjectGroupDetailsDTO.OrgSubElectiveGrpID = response.Entity.OrgSubElectiveGrpID;
                    model.OrganisationSubjectGroupDetailsDTO.IsElectiveSubjectCompFlag = response.Entity.IsElectiveSubjectCompFlag;
                    model.OrganisationSubjectGroupDetailsDTO.IsActive = response.Entity.IsActive;
                    model.OrganisationSubjectGroupDetailsDTO.SessionID = 0;


                }
                //For Subject
                List<OrganisationSubjectMaster> organisationSubjectMasterList = GetListOrganisationSubjectMaster(model.OrganisationSubjectGroupDetailsDTO.OrgSemesterMstID, model.OrganisationSubjectGroupDetailsDTO.CourseYearDetailID, model.OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber, model.OrganisationSubjectGroupDetailsDTO.UniversityID, model.OrganisationSubjectGroupDetailsDTO.SubjectID);
                List<SelectListItem> organisationSubjectMaster = new List<SelectListItem>();
                foreach (OrganisationSubjectMaster item in organisationSubjectMasterList)
                {
                    organisationSubjectMaster.Add(new SelectListItem { Text = item.Descriptions, Value = item.ID.ToString() });
                }

                ViewBag.OrganisationSubjectMaster = new SelectList(organisationSubjectMaster, "Value", "Text");
                // For Sub Elective Group
                List<OrganisationSubjectGroupDetails> OrganisationSubElectiveGroupList = GetListOrganisationSubElectivegroupList(Convert.ToString(model.OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID));
                List<SelectListItem> OrganisationSubElectiveGroupMaster = new List<SelectListItem>();
                foreach (OrganisationSubjectGroupDetails item in OrganisationSubElectiveGroupList)
                {
                    OrganisationSubElectiveGroupMaster.Add(new SelectListItem { Text = item.OrgSubElectiveGrpDescription.ToString(), Value = item.OrgSubElectiveGrpID.ToString() });
                }
                ViewBag.OrganisationSubElectiveGroupMaster = new SelectList(OrganisationSubElectiveGroupMaster, "Value", "Text");


                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(OrganisationSubjectGroupDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationSubjectGroupDetailsDTO != null)
                    {

                        model.OrganisationSubjectGroupDetailsDTO.ConnectionString = _connectioString;
                        model.OrganisationSubjectGroupDetailsDTO.ID = model.ID;
                        model.OrganisationSubjectGroupDetailsDTO.SubjectID = model.SubjectID;
                        model.OrganisationSubjectGroupDetailsDTO.Description = model.Description;
                        model.OrganisationSubjectGroupDetailsDTO.ShortDescription = model.ShortDescription;
                        model.OrganisationSubjectGroupDetailsDTO.OrgSemesterMstID = model.OrgSemesterMstID;
                        model.OrganisationSubjectGroupDetailsDTO.CourseYearDetailID = model.CourseYearDetailID;
                        model.OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber = model.SubjectRuleGrpNumber;
                        model.OrganisationSubjectGroupDetailsDTO.UniversityCode = model.UniversityCode;
                        model.OrganisationSubjectGroupDetailsDTO.Pattern = "";
                        model.OrganisationSubjectGroupDetailsDTO.IsCompulsory = model.IsCompulsory;
                        if (model.IsCompulsory == true)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.CompulsoryOptionalFlag = "COMPULSORY";
                            model.OrganisationSubjectGroupDetailsDTO.ElectiveGroupFlag = "N";
                            model.OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID = 0;
                            model.OrganisationSubjectGroupDetailsDTO.ElectiveSubGroupFlag = "N";
                            model.OrganisationSubjectGroupDetailsDTO.OrgSubElectiveGrpID = 0;
                            model.OrganisationSubjectGroupDetailsDTO.ElectiveSubjectCompFlag = "NONE";

                        }

                        else if (model.IsCompulsory == false)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.CompulsoryOptionalFlag = "OPTIONAL";
                            model.OrganisationSubjectGroupDetailsDTO.ElectiveGroupFlag = "Y";
                            model.OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID = model.OrgElectiveGrpID;
                            model.OrganisationSubjectGroupDetailsDTO.ElectiveSubGroupFlag = "Y";
                            model.OrganisationSubjectGroupDetailsDTO.OrgSubElectiveGrpID = model.OrgSubElectiveGrpID;
                            if (model.IsElectiveSubjectCompFlag == true)
                                model.OrganisationSubjectGroupDetailsDTO.ElectiveSubjectCompFlag = "COMPULSORY";
                            else if (model.IsElectiveSubjectCompFlag == false)
                                model.OrganisationSubjectGroupDetailsDTO.ElectiveSubjectCompFlag = "OPTIONAL";

                        }
                        if (model.SubjectGrpCombinationIDs.Length > 17)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubjectGrpCombinationIDs = model.SubjectGrpCombinationIDs;
                        }
                        else
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubjectGrpCombinationIDs = "";
                        }
                        if (model.SubHoursGrpAllocationIDs.Length > 17)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubHoursGrpAllocationIDs = model.SubHoursGrpAllocationIDs;
                        }
                        else
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubHoursGrpAllocationIDs = "";
                        }
                        if (model.SubjectGrpMarksIDs.Length > 17)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubjectGrpMarksIDs = model.SubjectGrpMarksIDs;
                        }
                        else
                        {
                            model.OrganisationSubjectGroupDetailsDTO.SubjectGrpMarksIDs = "";
                        }
                        model.OrganisationSubjectGroupDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        if (model.ID == 0)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.IsActive = true;
                        }
                        else if (model.ID > 0)
                        {
                            model.OrganisationSubjectGroupDetailsDTO.IsActive = model.IsActive;
                        }
                        model.OrganisationSubjectGroupDetailsDTO.SessionID = model.SessionID;

                        IBaseEntityResponse<OrganisationSubjectGroupDetails> response = _OrganisationSubjectGroupDetailsServiceAccess.InsertOrganisationSubjectGroupDetails(model.OrganisationSubjectGroupDetailsDTO);
                        if (model.ID == 0)
                        {
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }
                        else if (model.ID > 0)
                        {
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    model.CentreCodeWithName = model.CentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.UniversityID);
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }
                // return Json(Boolean.TrueString);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

            //return RedirectToAction("List", "OrganisationSubjectGroupDetails");

        }


        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _OrganisationSubjectGroupDetailsViewModel.SelectedCentreName = splited[1];
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

        public ActionResult GetSubElectiveGroupByElectiveGrpID(string OrgElectiveGrpID)
        {
            //string[] splited;
            //splited = SelectedCentreCode.Split(':');
            //_OrganisationSubjectGroupDetailsBaseViewModel.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
            if (String.IsNullOrEmpty(OrgElectiveGrpID))
            {
                throw new ArgumentNullException("OrgElectiveGrpID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(OrgElectiveGrpID, out id);
            var SubElectiveGrp = GetListOrganisationSubElectivegroupList(OrgElectiveGrpID);
            var result = (from s in SubElectiveGrp
                          select new
                          {
                              id = s.OrgSubElectiveGrpID,
                              name = s.OrgSubElectiveGrpDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #region Methods

        protected List<OrganisationSubjectGroupDetails> GetListOrganisationSubElectivegroupList(string OrgElectiveGrpID)
        {
            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OrgElectiveGrpID = Convert.ToInt32(OrgElectiveGrpID);
            // searchRequest.CurrentSessionID = CurrentSessionID;
            List<OrganisationSubjectGroupDetails> OrganisationSubElectivegroupList = new List<OrganisationSubjectGroupDetails>();
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetBySubElectiveGroupSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubElectivegroupList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubElectivegroupList;
        }


        [NonAction]
        public List<OrganisationSubjectGroupDetails> GetListOrganisationSubjectGroupDetails(string centerCode, out int TotalRecords)
        {
            List<OrganisationSubjectGroupDetails> listOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetails>();

            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
            //_CentreCode = "1";
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            searchRequest.CentreCode = centerCode;
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSubjectGroupDetails;
        }


        [NonAction]
        public List<OrganisationSubjectGroupDetails> GetListOrganisationSubjectGroupDetails()
        {
            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<OrganisationSubjectGroupDetails> listOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetails>();
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectGroupDetails;
        }

        [NonAction]
        public IEnumerable<OrganisationSubjectGroupDetailsViewModel> GetOrganisationSubjectGroupDetails(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
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
                    searchRequest.ScopeIdentity = Centre_code[1];
                    searchRequest.UniversityID = universityId;
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

                    string[] Centre_code = centerCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.ScopeIdentity = Centre_code[1];
                    searchRequest.UniversityID = universityId;
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

                string[] Centre_code = centerCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
                searchRequest.ScopeIdentity = Centre_code[1];
                searchRequest.UniversityID = universityId;
                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
            }

            List<OrganisationSubjectGroupDetailsViewModel> listOrganisationSubjectGroupDetailsViewModel = new List<OrganisationSubjectGroupDetailsViewModel>();
            List<OrganisationSubjectGroupDetails> listOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetails>();
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSubjectGroupDetails item in listOrganisationSubjectGroupDetails)
                    {
                        OrganisationSubjectGroupDetailsViewModel OrganisationSubjectGroupDetailsViewModel = new OrganisationSubjectGroupDetailsViewModel();
                        OrganisationSubjectGroupDetailsViewModel.OrganisationSubjectGroupDetailsDTO = item;
                        listOrganisationSubjectGroupDetailsViewModel.Add(OrganisationSubjectGroupDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationSubjectGroupDetailsViewModel;
        }

        protected List<OrganisationSubjectGroupDetails> GetListOrganisationSubjectTypeMaster(int SubjectGrpID, int CurrentSessionID)
        {
            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = SubjectGrpID;
            searchRequest.CurrentSessionID = CurrentSessionID;
            List<OrganisationSubjectGroupDetails> OrganisationSubjectTypeList = new List<OrganisationSubjectGroupDetails>();
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetBySubjectTypeMaterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubjectTypeList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubjectTypeList;
        }

        protected List<OrganisationSubjectGroupDetails> GetListOrganisationElectiveGroup(int ElectiveGroupId)
        {
            OrganisationSubjectGroupDetailsSearchRequest searchRequest = new OrganisationSubjectGroupDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectRuleGrpNumber = ElectiveGroupId;
            List<OrganisationSubjectGroupDetails> listOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetails>();
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> baseEntityCollectionResponse = _OrganisationSubjectGroupDetailsServiceAccess.GetByElectiveGroupSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGroupDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectGroupDetails;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSubjectGroupDetailsViewModel> filteredOrganisationSubjectGroupDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "BranchDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or Description Like '%" + param.sSearch + "%' or OrgSemesterName Like '%" + param.sSearch + "%' or CourseYearCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationSubjectGroupDetails = GetOrganisationSubjectGroupDetails(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredOrganisationSubjectGroupDetails = new List<OrganisationSubjectGroupDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOrganisationSubjectGroupDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.ConcateField.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.OrgSemesterMstID + "~" + c.CourseYearDetailID + "~" + c.SubjectRuleGrpNumber + "~" + 0), Convert.ToString(c.OrgSemesterMstID + "~" + c.CourseYearDetailID + "~" + c.SubjectRuleGrpNumber + "~" + c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
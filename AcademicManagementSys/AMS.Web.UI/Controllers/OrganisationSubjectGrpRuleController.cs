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
    public class OrganisationSubjectGrpRuleController : BaseController
    {
        IOrganisationSubjectGrpRuleServiceAccess _organisationSubjectGrpRuleServiceAccess = null;
        OrganisationSubjectGrpRuleBaseViewModel _organisationSubjectGrpRuleBaseViewModel = null;
        IOrganisationElectiveGrpMasterServiceAccess _organisationElectiveGrpMasterServiceAccess = null; 

        string _centreCode = string.Empty;
        string _sortOrder = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSubjectGrpRuleController()
        {
            _organisationSubjectGrpRuleServiceAccess = new OrganisationSubjectGrpRuleServiceAccess();
            _organisationSubjectGrpRuleBaseViewModel = new OrganisationSubjectGrpRuleBaseViewModel();
            _organisationElectiveGrpMasterServiceAccess = new OrganisationElectiveGrpMasterServiceAccess();
        }


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
                OrganisationSubjectGrpRuleBaseViewModel model = new OrganisationSubjectGrpRuleBaseViewModel();
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
        public ActionResult Create(int CourseYearSemID, int ID)
        {
            OrganisationSubjectGrpRuleViewModel model = new OrganisationSubjectGrpRuleViewModel();
            try
            {
                if (CourseYearSemID > 0)
                {

                    model.OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = CourseYearSemID;

                    int SelectedSelectedSubjectGrpRuleID = 0;
                    model.ListOrganisationSubjectGrpRule = GetOrganisationElectiveGrpRule(SelectedSelectedSubjectGrpRuleID);

                    int SelectedGroupRuleID = 0;
                    model.ListOrganisationSubElectiveGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);

                    int SubjectGrpRuleID = 0;
                    List<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleList = GetListOfOrgSubjectGroupRule(SubjectGrpRuleID);
                    List<SelectListItem> OrganisationSubjectGrpRule = new List<SelectListItem>();
                    foreach (OrganisationSubjectGrpRule item in OrganisationSubjectGrpRuleList)
                    {
                        OrganisationSubjectGrpRule.Add(new SelectListItem { Text = item.GroupName, Value = item.OrgElectiveGrpMasterID.ToString() });
                    }
                    ViewBag.OrganisationSubjectGrpRule = new SelectList(OrganisationSubjectGrpRule, "Value", "Text");
                   
                }
                else if (ID > 0)
                {
                    int SelectedSelectedSubjectGrpRuleID = ID;
                    model.ListOrganisationSubjectGrpRule = GetOrganisationElectiveGrpRule(SelectedSelectedSubjectGrpRuleID);

                    int SubjectGrpRuleID = ID;                 
                    List<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleList = GetListOfOrgSubjectGroupRule(SubjectGrpRuleID);
                    List<SelectListItem> OrganisationSubjectGrpRule = new List<SelectListItem>();
                    foreach (OrganisationSubjectGrpRule item in OrganisationSubjectGrpRuleList)
                    {
                        OrganisationSubjectGrpRule.Add(new SelectListItem { Text = item.GroupName, Value = item.OrgElectiveGrpMasterID.ToString() });
                    }
                    ViewBag.OrganisationSubjectGrpRule = new SelectList(OrganisationSubjectGrpRule, "Value", "Text");

                    

                    if (OrganisationSubjectGrpRuleList.Count() > 0)
	                {
                        int SelectedGroupRuleID = OrganisationSubjectGrpRuleList[0].OrgElectiveGrpMasterID;
                        model.ListOrganisationSubElectiveGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
	                }
                    else
                    {
                        int SelectedGroupRuleID = 0;
                        model.ListOrganisationSubElectiveGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
                    }
                    


                    

                    model.OrganisationSubjectGrpRuleDTO = new OrganisationSubjectGrpRule();
                    model.OrganisationSubjectGrpRuleDTO.ID = ID;
                    model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                    IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.SelectByID(model.OrganisationSubjectGrpRuleDTO);
                    if (response != null && response.Entity != null)
                    {
                        model.OrganisationSubjectGrpRuleDTO.ID = response.Entity.ID;
                        model.OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = response.Entity.CourseYearSemesterID;
                        model.OrganisationSubjectGrpRuleDTO.RuleName = response.Entity.RuleName;
                        model.OrganisationSubjectGrpRuleDTO.RuleCode = response.Entity.RuleCode;
                        model.OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects = response.Entity.MaxCompulsorySubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxGroups = response.Entity.MaxGroups;
                        model.OrganisationSubjectGrpRuleDTO.MaxOptSubjects = response.Entity.MaxOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.NoOfOptSubjects = response.Entity.NoOfOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.TotalSubjects = response.Entity.TotalSubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups = response.Entity.MaxNoOfCompulsoryGroups;
                        model.OrganisationSubjectGrpRuleDTO.IsActive = response.Entity.IsActive;
                       
                    }
                
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
        public ActionResult Create(OrganisationSubjectGrpRuleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                    {
                        model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                        model.OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSubjectGrpRuleDTO.RuleName = model.RuleName;
                        model.OrganisationSubjectGrpRuleDTO.RuleCode = model.RuleCode;
                        model.OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects = model.MaxCompulsorySubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxOptSubjects = model.MaxOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.TotalSubjects = model.TotalSubjects;
                        model.OrganisationSubjectGrpRuleDTO.NoOfOptSubjects = model.NoOfOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxGroups = model.MaxGroups;
                        model.OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups = model.MaxNoOfCompulsoryGroups;
                        model.OrganisationSubjectGrpRuleDTO.IsActive = model.IsActive;
                        model.OrganisationSubjectGrpRuleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.InsertOrganisationSubjectGrpRule(model.OrganisationSubjectGrpRuleDTO);
                        
                    }
                    return Json(Boolean.TrueString);
                }
                else
                {
                    return Json(Boolean.FalseString);
                }
            }
            catch (Exception)
            {


            }
            return Json(Boolean.TrueString);
        }

        [HttpGet]
        public ActionResult CreateSubjectGroupRule()
        {

            OrganisationSubjectGrpRuleViewModel model = new OrganisationSubjectGrpRuleViewModel();
            return PartialView(model);

        }

         [HttpPost]
        public ActionResult CreateSubjectGroupRule(OrganisationSubjectGrpRuleViewModel model)
        {
            try
            {
                if (model.ID <= 0)
                {
                    if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                    {
                        model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                        model.OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSubjectGrpRuleDTO.RuleName = model.RuleName;
                        model.OrganisationSubjectGrpRuleDTO.RuleCode = model.RuleCode;
                        model.OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects = model.MaxCompulsorySubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxOptSubjects = model.MaxOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.TotalSubjects = model.TotalSubjects;
                        model.OrganisationSubjectGrpRuleDTO.NoOfOptSubjects = model.NoOfOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxGroups = model.MaxGroups;
                        model.OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups = model.MaxNoOfCompulsoryGroups;
                        model.OrganisationSubjectGrpRuleDTO.IsActive = model.IsActive;
                        model.OrganisationSubjectGrpRuleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.InsertOrganisationSubjectGrpRule(model.OrganisationSubjectGrpRuleDTO);
                        model.OrganisationSubjectGrpRuleDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        model.ID = response.Entity.ID;
                    }
                }
                else if (model.ID > 0)
                {
                    if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                    {
                        model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                        model.OrganisationSubjectGrpRuleDTO.ID = model.ID;
                        model.OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSubjectGrpRuleDTO.RuleName = model.RuleName;
                        model.OrganisationSubjectGrpRuleDTO.RuleCode = model.RuleCode;
                        model.OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects = model.MaxCompulsorySubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxOptSubjects = model.MaxOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.TotalSubjects = model.TotalSubjects;
                        model.OrganisationSubjectGrpRuleDTO.NoOfOptSubjects = model.NoOfOptSubjects;
                        model.OrganisationSubjectGrpRuleDTO.MaxGroups = model.MaxGroups;
                        model.OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups = model.MaxNoOfCompulsoryGroups;
                        model.OrganisationSubjectGrpRuleDTO.IsActive = model.IsActive;
                        model.OrganisationSubjectGrpRuleDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.UpdateOrganisationSubjectGrpRule(model.OrganisationSubjectGrpRuleDTO);
                        model.OrganisationSubjectGrpRuleDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.OrganisationSubjectGrpRuleDTO.errorMessage + "~" + model.ID, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);   
                throw;
            }

          
        }

        public ActionResult CreateElectiveGroup(OrganisationSubjectGrpRuleViewModel model, string TotalNumberOfMaxGroups )
        {
            try
            {
                if (model.OrgElectiveGrpMasterID <= 0)
                {
                    int Selectedval = model.SubjectRuleGrpNumber;
                    model.ListOrganisationSubjectGrpRule = GetOrganisationElectiveGrpRule(Selectedval);

                    if (model.ListOrganisationSubjectGrpRule.Count() >= Convert.ToInt32(TotalNumberOfMaxGroups))
                    {
                        model.ListOrganisationSubjectGrpRule[0].OrgElectiveGrpMasterID = 0;
                        model.errorMessage = "Group limit exceeds,#F5CCCC";
                    }
                    else
                    {
                        List<OrganisationSubjectGrpRuleViewModel> listOrganisationSubjectGrpRuleViewModel = new List<OrganisationSubjectGrpRuleViewModel>();
                        if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                        {
                            model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                            model.OrganisationSubjectGrpRuleDTO.GroupName = model.GroupName;
                            model.OrganisationSubjectGrpRuleDTO.GroupShortCode = model.GroupShortCode;
                            model.OrganisationSubjectGrpRuleDTO.SubjectRuleGrpNumber = model.SubjectRuleGrpNumber;
                            model.OrganisationSubjectGrpRuleDTO.NoOfSubGroups = model.NoOfSubGroups;
                            model.OrganisationSubjectGrpRuleDTO.NoOfCompulsorySubGrp = model.NoOfCompulsorySubGrp;
                            model.OrganisationSubjectGrpRuleDTO.NoOfSubGrpSubjectSelect = model.NoOfSubGrpSubjectSelect;
                            model.OrganisationSubjectGrpRuleDTO.GroupCompulsoryFlag = model.GroupCompulsoryFlag;
                            model.OrganisationSubjectGrpRuleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                            IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.InsertOrgElectiveGrpMaster(model.OrganisationSubjectGrpRuleDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                            model.ID = response.Entity.ID;
                            int SelectedSubjectGrpRuleID = model.SubjectRuleGrpNumber;
                            model.ListOrganisationSubjectGrpRule = GetOrganisationElectiveGrpRule(SelectedSubjectGrpRuleID);
                        }
                    }

                }
                else if (model.OrgElectiveGrpMasterID > 0)
                {
                    if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                    {
                        model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;
                        model.OrganisationSubjectGrpRuleDTO.OrgElectiveGrpMasterID = model.OrgElectiveGrpMasterID;
                        model.OrganisationSubjectGrpRuleDTO.GroupName = model.GroupName;
                        model.OrganisationSubjectGrpRuleDTO.GroupShortCode = model.GroupShortCode;
                        model.OrganisationSubjectGrpRuleDTO.NoOfSubGroups = model.NoOfSubGroups;
                        model.OrganisationSubjectGrpRuleDTO.NoOfCompulsorySubGrp = model.NoOfCompulsorySubGrp;
                        model.OrganisationSubjectGrpRuleDTO.NoOfSubGrpSubjectSelect = model.NoOfSubGrpSubjectSelect;
                        model.OrganisationSubjectGrpRuleDTO.GroupCompulsoryFlag = model.GroupCompulsoryFlag;
                        model.OrganisationSubjectGrpRuleDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.UpdateOrgElectiveGrpMaster(model.OrganisationSubjectGrpRuleDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        int SelectedSubjectGrpRuleID = model.SubjectRuleGrpNumber;
                        model.ListOrganisationSubjectGrpRule = GetOrganisationElectiveGrpRule(SelectedSubjectGrpRuleID);
                    }
                }

                return Json( model , JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message); 
                throw;
            }
            
        }

        [HttpGet]
        public ActionResult CreateElectiveSubGroup(string SelectedSubjectGrpRuleID)
        {
            try
            {
                OrganisationSubjectGrpRuleViewModel model = new OrganisationSubjectGrpRuleViewModel();
                int SubjectGrpRuleID = Convert.ToInt32(SelectedSubjectGrpRuleID);
                model.ListOrganisationElectiveGroup = GetListOfOrgSubjectGroupRule(SubjectGrpRuleID);
                //List<SelectListItem> OrganisationSubjectGrpRule = new List<SelectListItem>();
                //foreach (OrganisationSubjectGrpRule item in OrganisationSubjectGrpRuleList)
                //{
                //    OrganisationSubjectGrpRule.Add(new SelectListItem { Text = item.GroupName, Value = item.OrgElectiveGrpMasterID.ToString() });
                //}
                //ViewBag.OrganisationSubjectGrpRule = new SelectList(OrganisationSubjectGrpRule, "Value", "Text", OrganisationSubjectGrpRuleList[0].OrgElectiveGrpMasterID);
                //int SelectedGroupRuleID = OrganisationSubjectGrpRuleList[0].OrgElectiveGrpMasterID;
                //model.ListOrganisationSubElectiveGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message); 
                throw;
            }

        }

        [HttpPost]
        public ActionResult CreateElectiveSubGroup(OrganisationSubjectGrpRuleViewModel model, string GroupRuleID)
        {
            try
            {
                int NumberOfSubGroups;

                if (Convert.ToInt32(GroupRuleID) <= 0)
                {

                        if (model.OrgSubElectiveGrpMasterID <= 0)
                        {
                            if (model != null && model.OrganisationSubjectGrpRuleDTO != null)
                            {
                             model.OrganisationSubjectGrpRuleDTO.OrgElectiveGrpMasterID = model.OrgElectiveGrpID;
                             model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;
                             IBaseEntityResponse<OrganisationSubjectGrpRule> GroupRuleResponse = _organisationSubjectGrpRuleServiceAccess.SelectOrgElectiveGrpMasterByID(model.OrganisationSubjectGrpRuleDTO);
                             NumberOfSubGroups = GroupRuleResponse.Entity.NoOfSubGroups;
                             int Selectedval = model.OrgElectiveGrpID;
                             model.ListOrganisationSubjectGrpRule = GetOrganisationSubElectiveGrpRule(Selectedval);

                             if (model.ListOrganisationSubjectGrpRule.Count() >= GroupRuleResponse.Entity.NoOfSubGroups)
                             {
                                 model.ListOrganisationSubjectGrpRule[0].OrgSubElectiveGrpMasterID = 0;
                                 model.errorMessage = "Sub-Group limit exceeds,#F5CCCC";
                             }
                             else
                             {

                                 model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                                 model.OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpDescription = model.OrgSubElectiveGrpDescription;
                                 model.OrganisationSubjectGrpRuleDTO.ShortDescription = model.ShortDescription;
                                 model.OrganisationSubjectGrpRuleDTO.OrgElectiveGrpID = model.OrgElectiveGrpID;
                                 model.OrganisationSubjectGrpRuleDTO.TotalNoOfSubjects = model.TotalNoOfSubjects;
                                 model.OrganisationSubjectGrpRuleDTO.AllowToSelect = model.AllowToSelect;
                                 model.OrganisationSubjectGrpRuleDTO.SubGroupCompulsoryFlag = model.SubGroupCompulsoryFlag;
                                 model.OrganisationSubjectGrpRuleDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                                 IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.InsertOrgSubElectiveGrpMaster(model.OrganisationSubjectGrpRuleDTO);
                                 model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                                 int SelectedGroupRuleID = model.OrgElectiveGrpID;
                                 model.ListOrganisationSubjectGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
                             }
                            }
                        }
                        else if (model.OrgSubElectiveGrpMasterID > 0)
                        {
                            model.OrganisationSubjectGrpRuleDTO.ConnectionString = _connectioString;

                            model.OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpDescription = model.OrgSubElectiveGrpDescription;
                            model.OrganisationSubjectGrpRuleDTO.ShortDescription = model.ShortDescription;
                            model.OrganisationSubjectGrpRuleDTO.OrgElectiveGrpID = model.OrgElectiveGrpID;
                            model.OrganisationSubjectGrpRuleDTO.TotalNoOfSubjects = model.TotalNoOfSubjects;
                            model.OrganisationSubjectGrpRuleDTO.AllowToSelect = model.AllowToSelect;
                            model.OrganisationSubjectGrpRuleDTO.SubGroupCompulsoryFlag = model.SubGroupCompulsoryFlag;
                            model.OrganisationSubjectGrpRuleDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                            IBaseEntityResponse<OrganisationSubjectGrpRule> response = _organisationSubjectGrpRuleServiceAccess.UpdateOrgSubElectiveGrpMaster(model.OrganisationSubjectGrpRuleDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                            int SelectedGroupRuleID = model.OrgElectiveGrpID;
                            model.ListOrganisationSubjectGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
                        }
                    


                }
                else if (Convert.ToInt32(GroupRuleID) > 0)
                {
                    int SelectedGroupRuleID = Convert.ToInt32(GroupRuleID);
                    model.ListOrganisationSubjectGrpRule = GetOrganisationSubElectiveGrpRule(SelectedGroupRuleID);
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);       
                throw;
            }
             
        }



      [HttpGet]
        public ActionResult LoadElectiveGroupList(string SelectedSubjectGrpRuleID)
      {
          OrganisationSubjectGrpRuleViewModel model = new OrganisationSubjectGrpRuleViewModel();
          int SubjectGrpRuleID = Convert.ToInt32(SelectedSubjectGrpRuleID);
          var ElectiveGroup = GetListOfOrgSubjectGroupRule(SubjectGrpRuleID);
          var result = (from s in ElectiveGroup
                        select new
                        {
                            id = s.OrgElectiveGrpMasterID ,
                            name = s.GroupName,
                        }).ToList();
          return Json(result, JsonRequestBehavior.AllowGet);
         
      }




        #region Non-Action Methods

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _organisationSubjectGrpRuleBaseViewModel.SelectedCentreName = splited[1];
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

        [NonAction]
        protected IEnumerable<OrganisationSubjectGrpRuleViewModel> GetOrganisationSubGrpRule(string centreCode , int universityID ,out int TotalRecords)
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
                    searchRequest.SortDirection = "Desc"; ;

                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                    searchRequest.ScopeIdentity = Centre_code[1];
                    searchRequest.UniversityID = universityID;
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
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollectionResponse = _organisationSubjectGrpRuleServiceAccess.GetBySearch(searchRequest);
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

        [NonAction]
        protected List<OrganisationSubjectGrpRule> GetOrganisationElectiveGrpRule(int SelectedSubjectGrpRuleID)
        {

            OrganisationSubjectGrpRuleSearchRequest searchRequest = new OrganisationSubjectGrpRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectRuleGrpNumber = SelectedSubjectGrpRuleID;
            List<OrganisationSubjectGrpRule> listOrganisationSubjectGrpRule = new List<OrganisationSubjectGrpRule>();
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollectionResponse = _organisationSubjectGrpRuleServiceAccess.GetOrgElectiveGrpMasterBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGrpRule = baseEntityCollectionResponse.CollectionResponse.ToList();
                   
                }
            }

            return listOrganisationSubjectGrpRule;
        }

        [NonAction]
        protected List<OrganisationSubjectGrpRule> GetOrganisationSubElectiveGrpRule(int SelectedGroupRuleID)
        {

            OrganisationSubjectGrpRuleSearchRequest searchRequest = new OrganisationSubjectGrpRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GroupRuleID = SelectedGroupRuleID;
            List<OrganisationSubjectGrpRule> listOrganisationSubjectGrpRule = new List<OrganisationSubjectGrpRule>();
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollectionResponse = _organisationSubjectGrpRuleServiceAccess.GetOrgSubElectiveGrpMasterBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGrpRule = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationSubjectGrpRule;
        }
       
        #endregion



        #region AjaxHandler

        public ActionResult AjaxHandler(JQueryDataTableParamModel param ,string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSubjectGrpRuleViewModel> filteredGetOrganisationSubGrpRule;

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
                        _searchBy = "(CourseYearCode Like '%" + param.sSearch + "%' or RuleName Like '%" + param.sSearch + "%' or OrgSemesterName Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "AA.OrgSemesterName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(CourseYearCode Like '%" + param.sSearch + "%' or RuleName Like '%" + param.sSearch + "%' or OrgSemesterName Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredGetOrganisationSubGrpRule = GetOrganisationSubGrpRule(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredGetOrganisationSubGrpRule = new List<OrganisationSubjectGrpRuleViewModel>();
                TotalRecords = 0;
            }
           
            var records = filteredGetOrganisationSubGrpRule.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CourseYearCode.ToString() + c.RuleName.ToString(), c.BranchDescription.ToString(), c.OrgSemesterName.ToString(), c.StatusFlag.ToString(), c.CourseYearSemesterID.ToString(), c.ID.ToString() };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AjaxHandlerElectiveGroup(JQueryDataTableParamModel param,int GrpRuleID)
        {
            IEnumerable<OrganisationSubjectGrpRule> filteredGetOrganisationSubGrpRule;
            if (GrpRuleID > 0)
            {
                filteredGetOrganisationSubGrpRule = GetOrganisationElectiveGrpRule(GrpRuleID);    
            }
            else
            {
                filteredGetOrganisationSubGrpRule = new List<OrganisationSubjectGrpRule>();
            }
            
            var records = filteredGetOrganisationSubGrpRule.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.GroupName), Convert.ToString(c.GroupShortCode), Convert.ToString(c.NoOfSubGroups), Convert.ToString(c.NoOfCompulsorySubGrp), Convert.ToString(c.OrgElectiveGrpMasterID), Convert.ToString(c.NoOfSubGrpSubjectSelect), Convert.ToString(c.GroupCompulsoryFlag) };

            return Json(new { sEcho = param.sEcho,  aaData = result }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AjaxHandlerElectiveSubGroup(JQueryDataTableParamModel param, int OrgElectiveGrpID)
        {
            IEnumerable<OrganisationSubjectGrpRule> filteredGetOrganisationSubGrpRule;
            if (OrgElectiveGrpID > 0)
            {
                filteredGetOrganisationSubGrpRule = GetOrganisationSubElectiveGrpRule(OrgElectiveGrpID);    
            }
            else
            {
                filteredGetOrganisationSubGrpRule = new List<OrganisationSubjectGrpRule>();
            }
            
            var records = filteredGetOrganisationSubGrpRule.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.OrgSubElectiveGrpDescription), Convert.ToString(c.ShortDescription), Convert.ToString(c.TotalNoOfSubjects), Convert.ToString(c.AllowToSelect), Convert.ToString(c.OrgSubElectiveGrpMasterID), Convert.ToString(c.SubGroupCompulsoryFlag) };

            return Json(new { sEcho = param.sEcho,  aaData = result }, JsonRequestBehavior.AllowGet);
        }  
        
        
        
        
        #endregion


    }
}
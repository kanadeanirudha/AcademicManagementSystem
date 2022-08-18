using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.ExceptionManager;


namespace AMS.Web.UI.Controllers
{
    public class ToolTemplateApplicableController : BaseController
    {
        IToolTemplateApplicableServiceAccess _ToolTemplateApplicableServiceAccess = null;
        ToolTemplateApplicableViewModel _ToolTemplateApplicableViewModel = null;
        IStudentRegistrationFormServiceAccess _StudentRegistrationFormServiceAccess = null;

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

        public ToolTemplateApplicableController()
        {

            // _ToolTemplateApplicableServiceAccess = new AccountBalancesheetTypeMasterServiceAccess();
            _ToolTemplateApplicableServiceAccess = new ToolTemplateApplicableServiceAccess();
            _ToolTemplateApplicableViewModel = new ToolTemplateApplicableViewModel();
            _StudentRegistrationFormServiceAccess = new StudentRegistrationFormServiceAccess();
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
                ToolTemplateApplicableViewModel model = new ToolTemplateApplicableViewModel();
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
        public ActionResult Create(string TemplateString, string universityID, string CentreCode)
        {


            ToolTemplateApplicableViewModel model = new ToolTemplateApplicableViewModel();
            model.ToolTemplateApplicableDTO = new ToolTemplateApplicable();

            try
            {
                string[] TemplateStringArrays = TemplateString.Split('~');
                string[] CentreCodeArrays = CentreCode.Split('~');
                string[] universityArrays = universityID.Split('~');
                string[] CentreArray = CentreCodeArrays[0].Split(':');
                model.ToolTemplateApplicableDTO.CenterName = CentreCodeArrays[1].Replace('$', ' ');
                model.ToolTemplateApplicableDTO.UniversityName = universityArrays[1].Replace('$', ' '); ;

                model.ToolTemplateApplicableDTO.TemplateID = Convert.ToInt32(TemplateStringArrays[0]);
                model.ToolTemplateApplicableDTO.TemplateName = TemplateStringArrays[1].Replace('$', ' ');
                model.ToolTemplateApplicableDTO.ConnectionString = _connectioString;

                //For Baranch
                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(Convert.ToInt32(universityArrays[0]), CentreArray[0]);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                {
                    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription + "(" + item.DivisionDescription + ")", Value = item.BranchDetailID.ToString() });
                }
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");
                // List for Standard
                List<OrganisationStandardMaster> organisationStandardMasterList = GetListOrganisationStandardMaster();
                List<SelectListItem> organisationStandardMaster = new List<SelectListItem>();
                foreach (OrganisationStandardMaster item in organisationStandardMasterList)
                {
                    organisationStandardMaster.Add(new SelectListItem { Text = item.Description, Value = item.StandardNumber.ToString() });
                }
                ViewBag.OrganisationStandardMaster = new SelectList(organisationStandardMaster, "Value", "Text");

                // List for OrganisationCentrewiseSession
                List<OrganisationCentrewiseSession> organisationCentrewiseSessionList = GetCurrentSession(CentreCodeArrays[0]);
                List<SelectListItem> organisationCentrewiseSession = new List<SelectListItem>();
                foreach (OrganisationCentrewiseSession item in organisationCentrewiseSessionList)
                {
                    organisationCentrewiseSession.Add(new SelectListItem { Text = item.SessionName, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationCentrewiseSession = new SelectList(organisationCentrewiseSession, "Value", "Text");

            }
            catch (Exception)
            {

            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolTemplateApplicableViewModel model)
        {
            try
            {

                if (model != null && model.ToolTemplateApplicableDTO != null)
                {
                    model.ToolTemplateApplicableDTO.ConnectionString = _connectioString;
                    model.ToolTemplateApplicableDTO.TemplateID = model.TemplateID;
                    model.ToolTemplateApplicableDTO.BranchDetailID = model.BranchDetailID;
                    model.ToolTemplateApplicableDTO.StandardNumber = model.StandardNumber;
                    model.ToolTemplateApplicableDTO.CentreWiseSessionID = model.CentreWiseSessionID;
                    model.ToolTemplateApplicableDTO.IsApplicableForEntranceExam = model.IsApplicableForEntranceExam;
                    model.ToolTemplateApplicableDTO.FromDate = model.FromDate;
                    model.ToolTemplateApplicableDTO.ToDate = model.ToDate;
                    model.ToolTemplateApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<ToolTemplateApplicable> response = _ToolTemplateApplicableServiceAccess.InsertToolTemplateApplicable(model.ToolTemplateApplicableDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    model.CentreCodeWithName = model.SelectedCentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.SelectedUniversityID);
                    return Json(model, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult View(string TemplateName, string universityID, string CentreCode, string BranchDetailID, string StandardNumber) 
        //{
        //    StudentRegistrationFormViewModel model = new StudentRegistrationFormViewModel();
        //    string[] CentreCodeArrays = CentreCode.Split('~');
        //    string[] universityArrays = universityID.Split('~');
        //    string[] CentreArray = CentreCodeArrays[0].Split(':');

        //    model.StudentRegistrationFormDTO.CenterCode = CentreArray[0];
        //    model.StudentRegistrationFormDTO.UniversityID =Convert.ToInt32(universityArrays[0]);
        //    model.StudentRegistrationFormDTO.TemplateName = TemplateName.Replace('$', ' ');
        //    model.StudentRegistrationFormDTO.BranchDetailID = Convert.ToInt32(BranchDetailID);
        //    model.StudentRegistrationFormDTO.StandardNumber = Convert.ToInt32(StandardNumber);
        //    model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationFormDTO.CenterCode, model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);
        //    return PartialView(model);
        //}


        [HttpGet]
        public ActionResult ViewV2(string TemplateName, string universityID, string CentreCode, string BranchDetailID, string StandardNumber)
        {
            StudentRegistrationFormViewModel model = new StudentRegistrationFormViewModel();
            string[] CentreCodeArrays = CentreCode.Split('~');
            string[] universityArrays = universityID.Split('~');
            string[] CentreArray = CentreCodeArrays[0].Split(':');

            model.StudentRegistrationFormDTO.CenterCode = CentreArray[0];
            model.StudentRegistrationFormDTO.UniversityID = Convert.ToInt32(universityArrays[0]);
            model.StudentRegistrationFormDTO.TemplateName = TemplateName.Replace('$', ' ');
            model.StudentRegistrationFormDTO.BranchDetailID = Convert.ToInt32(BranchDetailID);
            model.StudentRegistrationFormDTO.StandardNumber = Convert.ToInt32(StandardNumber);
            model.StudentRegistrationFormList = GetListStudentRegistrationForm(model.StudentRegistrationFormDTO.CenterCode, model.StudentRegistrationFormDTO.UniversityID, model.StudentRegistrationFormDTO.BranchDetailID, model.StudentRegistrationFormDTO.StandardNumber);
            return PartialView(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _ToolTemplateApplicableViewModel.SelectedCentreName = splited[1];
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

        protected List<StudentRegistrationForm> GetListStudentRegistrationForm(string CenterCode, int UniversityID, int BranchDetailsID, int StandardNumber)
        {
            StudentRegistrationFormSearchRequest searchRequest = new StudentRegistrationFormSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CenterCode = CenterCode;
            searchRequest.UniversityID = UniversityID;
            searchRequest.BranchDetailsID = BranchDetailsID;
            searchRequest.StandardNumber = StandardNumber;
            List<StudentRegistrationForm> ToolRegistrationFieldList = new List<StudentRegistrationForm>();
            IBaseEntityCollectionResponse<StudentRegistrationForm> baseEntityCollectionResponse = _StudentRegistrationFormServiceAccess.GetByToolRegistrationFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ToolRegistrationFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ToolRegistrationFieldList;
        }
        #region Methods

   
        public IEnumerable<ToolTemplateApplicableViewModel> GetListToolTemplateApplicable(string centerCode, int universityId, out int TotalRecords)
        {
            ToolTemplateApplicableSearchRequest searchRequest = new ToolTemplateApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "BB.CreatedDate";
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
                    searchRequest.SortBy = "BB.ModifiedDate";
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

            List<ToolTemplateApplicableViewModel> listToolTemplateApplicableViewModel = new List<ToolTemplateApplicableViewModel>();
            List<ToolTemplateApplicable> listToolTemplateApplicable = new List<ToolTemplateApplicable>();
            IBaseEntityCollectionResponse<ToolTemplateApplicable> baseEntityCollectionResponse = _ToolTemplateApplicableServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolTemplateApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolTemplateApplicable item in listToolTemplateApplicable)
                    {
                        ToolTemplateApplicableViewModel ToolTemplateApplicableViewModel = new ToolTemplateApplicableViewModel();
                        ToolTemplateApplicableViewModel.ToolTemplateApplicableDTO = item;
                        listToolTemplateApplicableViewModel.Add(ToolTemplateApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listToolTemplateApplicableViewModel;
        }


       


        #endregion

        #region AjaxHandler

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<ToolTemplateApplicableViewModel> filteredToolTemplateApplicable;
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

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or TemplateName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TemplateName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or TemplateName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredToolTemplateApplicable = GetListToolTemplateApplicable(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredToolTemplateApplicable = new List<ToolTemplateApplicableViewModel>();
                TotalRecords = 0;
            }
            var records = filteredToolTemplateApplicable.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.TemplateName.ToString(), c.BranchDescription.ToString(), Convert.ToString(c.StandardNumber), Convert.ToString(c.StatusFlag), Convert.ToString(c.TemplateID + "~" + c.TemplateName), Convert.ToString(c.ID),Convert.ToString(c.BranchDetailID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
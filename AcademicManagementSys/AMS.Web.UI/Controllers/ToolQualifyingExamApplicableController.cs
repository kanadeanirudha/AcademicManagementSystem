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
    public class ToolQualifyingExamApplicableController : BaseController
    {
        IToolQualifyingExamApplicableServiceAccess _ToolQualifyingExamApplicableServiceAccess = null;
        //IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        // IToolQualifyingExamApplicableServiceAccess _ToolQualifyingExamApplicableServiceAccess = null;
        ToolQualifyingExamApplicableBaseViewModel _ToolQualifyingExamApplicableBaseViewModel = null;


        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        string _centreCode = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;


        public ToolQualifyingExamApplicableController()
        {

            // _ToolQualifyingExamApplicableServiceAccess = new AccountBalancesheetTypeMasterServiceAccess();
            _ToolQualifyingExamApplicableServiceAccess = new ToolQualifyingExamApplicableServiceAccess();
            _ToolQualifyingExamApplicableBaseViewModel = new ToolQualifyingExamApplicableBaseViewModel();
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
                ToolQualifyingExamApplicableBaseViewModel model = new ToolQualifyingExamApplicableBaseViewModel();
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
        public ActionResult Create(string QualifyingExamString, string universityID, string CentreCode)
        {


            ToolQualifyingExamApplicableBaseViewModel model = new ToolQualifyingExamApplicableBaseViewModel();
            model.ToolQualifyingExamApplicableDTO = new ToolQualifyingExamApplicable();
            //model.ToolQualifyingExamApplicableDTO.ID = id;

            try
            {
                string[] TemplateStringArrays = QualifyingExamString.Split('~');
                string[] CentreCodeArrays = CentreCode.Split('~');
                string[] universityArrays = universityID.Split('~');
                string[] CentreArray = CentreCodeArrays[0].Split(':');
                model.ToolQualifyingExamApplicableDTO.CenterName = CentreCodeArrays[1].Replace('$', ' ');
                model.ToolQualifyingExamApplicableDTO.UniversityName = universityArrays[1].Replace('$', ' '); ;

                model.ToolQualifyingExamApplicableDTO.QualifyingExamMstID = Convert.ToInt32(TemplateStringArrays[0]);
                model.ToolQualifyingExamApplicableDTO.QualifyingExamName = TemplateStringArrays[1].Replace('$', ' ');
                model.ToolQualifyingExamApplicableDTO.ConnectionString = _connectioString;

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

            }
            catch (Exception)
            {

            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolQualifyingExamApplicableBaseViewModel model)
        {
            try
            {
                if (model != null && model.ToolQualifyingExamApplicableDTO != null)
                {
                    model.ToolQualifyingExamApplicableDTO.ConnectionString = _connectioString;
                    model.ToolQualifyingExamApplicableDTO.QualifyingExamMstID = model.QualifyingExamMstID;
                    model.ToolQualifyingExamApplicableDTO.BranchDetailID = model.BranchDetailID;
                    model.ToolQualifyingExamApplicableDTO.StandardNumber = model.StandardNumber;
                    // model.ToolQualifyingExamApplicableDTO.FromDate = model.FromDate;
                    model.ToolQualifyingExamApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<ToolQualifyingExamApplicable> response = _ToolQualifyingExamApplicableServiceAccess.InsertToolQualifyingExamApplicable(model.ToolQualifyingExamApplicableDTO);
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

        //public ActionResult Edit(int BranchDetailID)
        //{
        //    ToolQualifyingExamApplicableViewModel model = new ToolQualifyingExamApplicableViewModel();

        //    model.ToolQualifyingExamApplicableDTO = new ToolQualifyingExamApplicable();
        //    model.ToolQualifyingExamApplicableDTO.ID = BranchDetailID;
        //    model.ToolQualifyingExamApplicableDTO.ConnectionString = _connectioString;
        //    //IBaseEntityResponse<ToolQualifyingExamApplicable> response = _ToolQualifyingExamApplicableServiceAccess.SelectByID_For_CourseDescription(model.ToolQualifyingExamApplicableDTO);
        //    //if (response != null && response.Entity != null)
        //    //{
        //    //    model.ToolQualifyingExamApplicableDTO.ID = response.Entity.ID;
        //    //    model.ToolQualifyingExamApplicableDTO.BranchDescription = response.Entity.BranchDescription;
        //    //}


        //    List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
        //    List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
        //    foreach (OrganisationStreamMaster item in organisationStreamMasterList)
        //    {
        //        organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
        //    }


        //    ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");

        //    IBaseEntityResponse<ToolQualifyingExamApplicable> response = _ToolQualifyingExamApplicableServiceAccess.SelectByID(model.ToolQualifyingExamApplicableDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.ToolQualifyingExamApplicableDTO.BranchID = response.Entity.ID;

        //        string splitCentreCode = Session["centerCode"].ToString();
        //        string[] C_code = splitCentreCode.Split(':');
        //        model.ToolQualifyingExamApplicableDTO.CentreCode = C_code[0];
        //        model.ToolQualifyingExamApplicableDTO.CentreName = C_code[1];
        //        model.ToolQualifyingExamApplicableDTO.BranchDescription = response.Entity.BranchDescription;
        //        model.ToolQualifyingExamApplicableDTO.StreamID = response.Entity.StreamID;
        //        //  ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text", response.Entity.SelectedStreamID.ToString());
        //        model.ToolQualifyingExamApplicableDTO.IntroductionYear = response.Entity.IntroductionYear;
        //        model.ToolQualifyingExamApplicableDTO.PresentIntake = response.Entity.PresentIntake;
        //        model.ToolQualifyingExamApplicableDTO.DteCode = response.Entity.DteCode;
        //        model.ToolQualifyingExamApplicableDTO.BranchPrintingSequence = response.Entity.BranchPrintingSequence;
        //        //model.CentreCodeWithName = SelectedCentreCode;
        //        //model.UniversityIDWithName = SelectedUniversityID;

        //    }

        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(ToolQualifyingExamApplicableViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.ToolQualifyingExamApplicableDTO != null)
        //        {
        //            if (model != null && model.ToolQualifyingExamApplicableDTO != null)
        //            {
        //                model.ToolQualifyingExamApplicableDTO.ConnectionString = _connectioString;
        //                model.ToolQualifyingExamApplicableDTO.BranchDetailID = model.ID;

        //                string splitCentreCode = Session["centerCode"].ToString();
        //                string[] C_code = splitCentreCode.Split(':');

        //                model.ToolQualifyingExamApplicableDTO.CentreCode = C_code[0];
        //                model.ToolQualifyingExamApplicableDTO.PresentIntake = model.PresentIntake;
        //                model.ToolQualifyingExamApplicableDTO.IntroductionYear = model.IntroductionYear;
        //                model.ToolQualifyingExamApplicableDTO.StreamID = model.StreamID;
        //                model.ToolQualifyingExamApplicableDTO.DteCode = model.DteCode;
        //                model.ToolQualifyingExamApplicableDTO.BranchPrintingSequence = model.BranchPrintingSequence;
        //                model.ToolQualifyingExamApplicableDTO.ModifiedBy = 1;
        //                model.ToolQualifyingExamApplicableDTO.ModifiedDate = DateTime.Now;
        //                model.ToolQualifyingExamApplicableDTO.DeletedBy = null;
        //                model.ToolQualifyingExamApplicableDTO.DeletedDate = null;

        //                model.ToolQualifyingExamApplicableDTO.IsDeleted = false;
        //                IBaseEntityResponse<ToolQualifyingExamApplicable> response = _ToolQualifyingExamApplicableServiceAccess.UpdateToolQualifyingExamApplicable(model.ToolQualifyingExamApplicableDTO);
        //            }
        //        }
        //        model.CentreCodeWithName = Session["centerCode"].ToString();
        //        model.UniversityIDWithName = Session["universityId"].ToString() + ":" + Session["universityName"].ToString();
        //        return Json(Boolean.TrueString + "::" + model.CentreCodeWithName + "::" + model.UniversityIDWithName);
        //        // "::" + model.DepartmentIdWithName);
        //    }
        //    else
        //    {
        //        return Json(Boolean.TrueString);
        //    }
        //}


        protected List<ToolQualifyingExamApplicable> GetListBranchDetails(int UniversityID)
        {
            ToolQualifyingExamApplicableSearchRequest searchRequest = new ToolQualifyingExamApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.UniversityID = UniversityID;
            //searchRequest.SearchType = 1;
            List<ToolQualifyingExamApplicable> listBranchDetails = new List<ToolQualifyingExamApplicable>();
            IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> baseEntityCollectionResponse = _ToolQualifyingExamApplicableServiceAccess.GetBySearchListBranchDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBranchDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listBranchDetails;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _ToolQualifyingExamApplicableBaseViewModel.SelectedCentreName = splited[1];
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
        public IEnumerable<ToolQualifyingExamApplicableBaseViewModel> GetListToolQualifyingExamApplicable(string centerCode, int universityId, out int TotalRecords)
        {
            ToolQualifyingExamApplicableSearchRequest searchRequest = new ToolQualifyingExamApplicableSearchRequest();
            //_CentreCode = "1";
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

            List<ToolQualifyingExamApplicableBaseViewModel> listToolQualifyingExamApplicableViewModel = new List<ToolQualifyingExamApplicableBaseViewModel>();
            List<ToolQualifyingExamApplicable> listToolQualifyingExamApplicable = new List<ToolQualifyingExamApplicable>();
            IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> baseEntityCollectionResponse = _ToolQualifyingExamApplicableServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualifyingExamApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualifyingExamApplicable item in listToolQualifyingExamApplicable)
                    {
                        ToolQualifyingExamApplicableBaseViewModel ToolQualifyingExamApplicableViewModel = new ToolQualifyingExamApplicableBaseViewModel();
                        ToolQualifyingExamApplicableViewModel.ToolQualifyingExamApplicableDTO = item;
                        listToolQualifyingExamApplicableViewModel.Add(ToolQualifyingExamApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listToolQualifyingExamApplicableViewModel;
        }


        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<ToolQualifyingExamApplicableBaseViewModel> filteredToolQualifyingExamApplicable;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ExamName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or ExamName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BranchDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or ExamName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredToolQualifyingExamApplicable = GetListToolQualifyingExamApplicable(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredToolQualifyingExamApplicable = new List<ToolQualifyingExamApplicableBaseViewModel>();
                TotalRecords = 0;
            }
            var records = filteredToolQualifyingExamApplicable.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.QualifyingExamName.ToString(), c.BranchDescription.ToString(), Convert.ToString(c.StandardNumber), Convert.ToString(c.StatusFlag), Convert.ToString(c.QualifyingExamMstID + "~" + c.QualifyingExamName), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
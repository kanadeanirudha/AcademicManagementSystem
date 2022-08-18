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
    public class ToolQualificationApplicableController : BaseController
    {
        IToolQualificationApplicableServiceAccess _ToolQualificationApplicableServiceAccess = null;
        //IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        // IToolQualificationApplicableServiceAccess _ToolQualificationApplicableServiceAccess = null;
        ToolQualificationApplicableBaseViewModel _ToolQualificationApplicableBaseViewModel = null;


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

        public ToolQualificationApplicableController()
        {

            // _ToolQualificationApplicableServiceAccess = new AccountBalancesheetTypeMasterServiceAccess();
            _ToolQualificationApplicableServiceAccess = new ToolQualificationApplicableServiceAccess();
            _ToolQualificationApplicableBaseViewModel = new ToolQualificationApplicableBaseViewModel();
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
                ToolQualificationApplicableBaseViewModel model = new ToolQualificationApplicableBaseViewModel();
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
        public ActionResult Create(string QualificationExamString, string universityID, string CentreCode)
        {


            ToolQualificationApplicableBaseViewModel model = new ToolQualificationApplicableBaseViewModel();
            model.ToolQualificationApplicableDTO = new ToolQualificationApplicable();
            //model.ToolQualificationApplicableDTO.ID = id;

            try
            {
                string[] TemplateStringArrays = QualificationExamString.Split('~');
                string[] CentreCodeArrays = CentreCode.Split('~');
                string[] universityArrays = universityID.Split('~');
                string[] CentreArray = CentreCodeArrays[0].Split(':');
                model.ToolQualificationApplicableDTO.CenterName = CentreCodeArrays[1].Replace('$', ' ');
                model.ToolQualificationApplicableDTO.UniversityName = universityArrays[1].Replace('$', ' '); ;

                model.ToolQualificationApplicableDTO.QualificationExamMstID = Convert.ToInt32(TemplateStringArrays[0]);
                model.ToolQualificationApplicableDTO.QualificationExamName = TemplateStringArrays[1].Replace('$', ' ');
                model.ToolQualificationApplicableDTO.ConnectionString = _connectioString;

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
        public ActionResult Create(ToolQualificationApplicableBaseViewModel model)
        {
            try
            {
               
                    if (model != null && model.ToolQualificationApplicableDTO != null)
                    {
                        model.ToolQualificationApplicableDTO.ConnectionString = _connectioString;
                        model.ToolQualificationApplicableDTO.QualificationExamMstID = model.QualificationExamMstID;
                        model.ToolQualificationApplicableDTO.BranchDetailID = model.BranchDetailID;
                        model.ToolQualificationApplicableDTO.StandardNumber = model.StandardNumber;
                         model.ToolQualificationApplicableDTO.FromDate = model.FromDate;
                        model.ToolQualificationApplicableDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<ToolQualificationApplicable> response = _ToolQualificationApplicableServiceAccess.InsertToolQualificationApplicable(model.ToolQualificationApplicableDTO);
                    
                    //model.CentreCodeWithName = Session["centerCode"].ToString();
                    //model.UniversityIDWithName = Session["universityId"].ToString() + ":" + Session["universityName"].ToString();
                    //return Json(Boolean.TrueString + "::" + model.CentreCodeWithName + "::" + model.UniversityIDWithName);

                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    model.CentreCodeWithName = model.SelectedCentreCode;
                    model.UniversityIDWithName = Convert.ToString(model.SelectedUniversityID);
                    return Json(model, JsonRequestBehavior.AllowGet);

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
            //return RedirectToAction("List", "ToolQualificationApplicable");

        }

        //public ActionResult Edit(int BranchDetailID)
        //{
        //    ToolQualificationApplicableViewModel model = new ToolQualificationApplicableViewModel();

        //    model.ToolQualificationApplicableDTO = new ToolQualificationApplicable();
        //    model.ToolQualificationApplicableDTO.ID = BranchDetailID;
        //    model.ToolQualificationApplicableDTO.ConnectionString = _connectioString;
        //    //IBaseEntityResponse<ToolQualificationApplicable> response = _ToolQualificationApplicableServiceAccess.SelectByID_For_CourseDescription(model.ToolQualificationApplicableDTO);
        //    //if (response != null && response.Entity != null)
        //    //{
        //    //    model.ToolQualificationApplicableDTO.ID = response.Entity.ID;
        //    //    model.ToolQualificationApplicableDTO.BranchDescription = response.Entity.BranchDescription;
        //    //}


        //    List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
        //    List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
        //    foreach (OrganisationStreamMaster item in organisationStreamMasterList)
        //    {
        //        organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
        //    }


        //    ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");

        //    IBaseEntityResponse<ToolQualificationApplicable> response = _ToolQualificationApplicableServiceAccess.SelectByID(model.ToolQualificationApplicableDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.ToolQualificationApplicableDTO.BranchID = response.Entity.ID;

        //        string splitCentreCode = Session["centerCode"].ToString();
        //        string[] C_code = splitCentreCode.Split(':');
        //        model.ToolQualificationApplicableDTO.CentreCode = C_code[0];
        //        model.ToolQualificationApplicableDTO.CentreName = C_code[1];
        //        model.ToolQualificationApplicableDTO.BranchDescription = response.Entity.BranchDescription;
        //        model.ToolQualificationApplicableDTO.StreamID = response.Entity.StreamID;
        //        //  ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text", response.Entity.SelectedStreamID.ToString());
        //        model.ToolQualificationApplicableDTO.IntroductionYear = response.Entity.IntroductionYear;
        //        model.ToolQualificationApplicableDTO.PresentIntake = response.Entity.PresentIntake;
        //        model.ToolQualificationApplicableDTO.DteCode = response.Entity.DteCode;
        //        model.ToolQualificationApplicableDTO.BranchPrintingSequence = response.Entity.BranchPrintingSequence;
        //        //model.CentreCodeWithName = SelectedCentreCode;
        //        //model.UniversityIDWithName = SelectedUniversityID;

        //    }

        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(ToolQualificationApplicableViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.ToolQualificationApplicableDTO != null)
        //        {
        //            if (model != null && model.ToolQualificationApplicableDTO != null)
        //            {
        //                model.ToolQualificationApplicableDTO.ConnectionString = _connectioString;
        //                model.ToolQualificationApplicableDTO.BranchDetailID = model.ID;

        //                string splitCentreCode = Session["centerCode"].ToString();
        //                string[] C_code = splitCentreCode.Split(':');

        //                model.ToolQualificationApplicableDTO.CentreCode = C_code[0];
        //                model.ToolQualificationApplicableDTO.PresentIntake = model.PresentIntake;
        //                model.ToolQualificationApplicableDTO.IntroductionYear = model.IntroductionYear;
        //                model.ToolQualificationApplicableDTO.StreamID = model.StreamID;
        //                model.ToolQualificationApplicableDTO.DteCode = model.DteCode;
        //                model.ToolQualificationApplicableDTO.BranchPrintingSequence = model.BranchPrintingSequence;
        //                model.ToolQualificationApplicableDTO.ModifiedBy = 1;
        //                model.ToolQualificationApplicableDTO.ModifiedDate = DateTime.Now;
        //                model.ToolQualificationApplicableDTO.DeletedBy = null;
        //                model.ToolQualificationApplicableDTO.DeletedDate = null;

        //                model.ToolQualificationApplicableDTO.IsDeleted = false;
        //                IBaseEntityResponse<ToolQualificationApplicable> response = _ToolQualificationApplicableServiceAccess.UpdateToolQualificationApplicable(model.ToolQualificationApplicableDTO);
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


        protected List<ToolQualificationApplicable> GetListBranchDetails(int UniversityID)
        {
            ToolQualificationApplicableSearchRequest searchRequest = new ToolQualificationApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.UniversityID = UniversityID;
            //searchRequest.SearchType = 1;
            List<ToolQualificationApplicable> listBranchDetails = new List<ToolQualificationApplicable>();
            IBaseEntityCollectionResponse<ToolQualificationApplicable> baseEntityCollectionResponse = _ToolQualificationApplicableServiceAccess.GetBySearchListBranchDetails(searchRequest);
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
            //string[] splited;
            //splited = SelectedCentreCode.Split(':');
            //_ToolQualificationApplicableBaseViewModel.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
            //if (String.IsNullOrEmpty(SelectedCentreCode))
            //{
            //    throw new ArgumentNullException("SelectedCentreCode");
            //}
            //int id = 0;
            //bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            //var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            //var result = (from s in university
            //              select new
            //              {
            //                  id = s.ID + ":" + s.UniversityName,
            //                  name = s.UniversityName,
            //              }).ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);





            string[] splited;
            splited = SelectedCentreCode.Split(':');
            _ToolQualificationApplicableBaseViewModel.SelectedCentreName = splited[1];
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
        public IEnumerable<ToolQualificationApplicableBaseViewModel> GetListToolQualificationApplicable(string centerCode, int universityId, out int TotalRecords)
        {
            ToolQualificationApplicableSearchRequest searchRequest = new ToolQualificationApplicableSearchRequest();
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

            List<ToolQualificationApplicableBaseViewModel> listToolQualificationApplicableViewModel = new List<ToolQualificationApplicableBaseViewModel>();
            List<ToolQualificationApplicable> listToolQualificationApplicable = new List<ToolQualificationApplicable>();
            IBaseEntityCollectionResponse<ToolQualificationApplicable> baseEntityCollectionResponse = _ToolQualificationApplicableServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolQualificationApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolQualificationApplicable item in listToolQualificationApplicable)
                    {
                        ToolQualificationApplicableBaseViewModel ToolQualificationApplicableViewModel = new ToolQualificationApplicableBaseViewModel();
                        ToolQualificationApplicableViewModel.ToolQualificationApplicableDTO = item;
                        listToolQualificationApplicableViewModel.Add(ToolQualificationApplicableViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listToolQualificationApplicableViewModel;
        }


       



        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<ToolQualificationApplicableBaseViewModel> filteredToolQualificationApplicable;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "QualificationName,BranchDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or QualificationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "QualificationName,BranchDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {

                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or QualificationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredToolQualificationApplicable = GetListToolQualificationApplicable(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredToolQualificationApplicable = new List<ToolQualificationApplicableBaseViewModel>();
                TotalRecords = 0;
            }
            var records = filteredToolQualificationApplicable.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.QualificationExamName.ToString(), c.BranchDescription.ToString(), Convert.ToString(c.StandardNumber), Convert.ToString(c.StatusFlag), Convert.ToString(c.QualificationExamMstID + "~" + c.QualificationExamName), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
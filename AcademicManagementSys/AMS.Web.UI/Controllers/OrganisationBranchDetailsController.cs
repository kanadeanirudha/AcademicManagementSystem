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
    public class OrganisationBranchDetailsController : BaseController
    {
        IOrganisationBranchDetailsServiceAccess _organisationBranchDetailsServiceAccess = null;
        OrganisationBranchDetailsBaseViewModel _organisationBranchDetailsBaseViewModel = null;

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

        public OrganisationBranchDetailsController()
        {
            _organisationBranchDetailsServiceAccess = new OrganisationBranchDetailsServiceAccess();
            _organisationBranchDetailsBaseViewModel = new OrganisationBranchDetailsBaseViewModel();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 )
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string centerCode, string universityID, string actionMode)
        {
            try
            {
                OrganisationBranchDetailsBaseViewModel model = new OrganisationBranchDetailsBaseViewModel();
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
                            model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                else
                {
                    if (Session["RoleID"] == null)
                    {
                        int AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                        List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                        AdminRoleApplicableDetails a = null;
                        foreach (var item in listAdminRoleApplicableDetails)
                        {
                            if ( item.IsSuperUser == 1 || item.IsAcadMgr == 1)
                            {
                                a = new AdminRoleApplicableDetails();
                                a.CentreCode = item.CentreCode;
                                a.CentreName = item.CentreName;
                                model.ListGetAdminRoleApplicableCentre.Add(a);
                            }
                        }
                    }
                    else
                    {
                        int AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                        List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByAcademicManager(AdminRoleMasterID);
                        AdminRoleApplicableDetails a = null;
                        foreach (var item in listAdminRoleApplicableDetails)
                        {
                            if (item.IsSuperUser == 1 || item.IsAcadMgr == 1)
                            {
                                a = new AdminRoleApplicableDetails();
                                a.CentreCode = item.CentreCode;
                                a.CentreName = item.CentreName;
                                model.ListGetAdminRoleApplicableCentre.Add(a);
                            }
                        }
                    }

                }
                if (!string.IsNullOrEmpty(centerCode))
                {
                    model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(centerCode);
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
        public ActionResult Create(string CentreCode,string centreName, int id)
        {
            try
            {
                OrganisationBranchDetailsViewModel model = new OrganisationBranchDetailsViewModel();
                model.OrganisationBranchDetailsDTO = new OrganisationBranchDetails();
                model.OrganisationBranchDetailsDTO.ID = id;
                model.OrganisationBranchDetailsDTO.CentreName =  centreName.Replace('~',' ');
                model.OrganisationBranchDetailsDTO.CentreCode = CentreCode;
                model.OrganisationBranchDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationBranchDetails> response = _organisationBranchDetailsServiceAccess.SelectByID_For_CourseDescription(model.OrganisationBranchDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationBranchDetailsDTO.ID = response.Entity.ID;
                    model.OrganisationBranchDetailsDTO.BranchDescription = response.Entity.BranchDescription;
                }
                List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in organisationStreamMasterList)
                {
                    organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");
                var CurrentDate = DateTime.Now.ToString("yyyy");
                model.OrganisationBranchDetailsDTO.IntroductionYear = Convert.ToInt32(CurrentDate);

                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
           
        }

        [HttpPost]
        public ActionResult Create(OrganisationBranchDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationBranchDetailsDTO != null)
                    {
                        model.OrganisationBranchDetailsDTO.ConnectionString = _connectioString;
                        model.OrganisationBranchDetailsDTO.BranchID = model.ID;
                        model.OrganisationBranchDetailsDTO.CentreCode = model.CentreCode;
                        model.OrganisationBranchDetailsDTO.PresentIntake = model.PresentIntake;
                        model.OrganisationBranchDetailsDTO.IntroductionYear = model.IntroductionYear;
                        model.OrganisationBranchDetailsDTO.StreamID = Convert.ToInt32(model.StreamID);
                        model.OrganisationBranchDetailsDTO.DteCode = model.DteCode;
                        model.OrganisationBranchDetailsDTO.BranchPrintingSequence = model.BranchPrintingSequence;
                        model.OrganisationBranchDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<OrganisationBranchDetails> response = _organisationBranchDetailsServiceAccess.InsertOrganisationBranchDetails(model.OrganisationBranchDetailsDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        public ActionResult Edit(int BranchDetailID, string centreName, string CentreCode)
        {
            try
            {
                OrganisationBranchDetailsViewModel model = new OrganisationBranchDetailsViewModel();

                model.OrganisationBranchDetailsDTO = new OrganisationBranchDetails();
                model.OrganisationBranchDetailsDTO.ID = BranchDetailID;
                model.OrganisationBranchDetailsDTO.ConnectionString = _connectioString;

                List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in organisationStreamMasterList)
                {
                    organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }


                ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");

                IBaseEntityResponse<OrganisationBranchDetails> response = _organisationBranchDetailsServiceAccess.SelectByID(model.OrganisationBranchDetailsDTO);

                if (response != null && response.Entity != null)
                {
                    model.OrganisationBranchDetailsDTO.BranchID = response.Entity.ID;

                
                    model.OrganisationBranchDetailsDTO.CentreCode = CentreCode;
                    model.OrganisationBranchDetailsDTO.CentreName = centreName.Replace('~',' ');
                    model.OrganisationBranchDetailsDTO.BranchDescription = response.Entity.BranchDescription;
                    model.OrganisationBranchDetailsDTO.StreamID = response.Entity.StreamID;
                    //  ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text", response.Entity.SelectedStreamID.ToString());
                    model.OrganisationBranchDetailsDTO.IntroductionYear = response.Entity.IntroductionYear;
                    model.OrganisationBranchDetailsDTO.PresentIntake = response.Entity.PresentIntake;
                    model.OrganisationBranchDetailsDTO.DteCode = response.Entity.DteCode;
                    model.OrganisationBranchDetailsDTO.BranchPrintingSequence = response.Entity.BranchPrintingSequence;
                    //model.CentreCodeWithName = SelectedCentreCode;
                    //model.UniversityIDWithName = SelectedUniversityID;

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
        public ActionResult Edit(OrganisationBranchDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationBranchDetailsDTO != null)
                    {
                        if (model != null && model.OrganisationBranchDetailsDTO != null)
                        {
                            model.OrganisationBranchDetailsDTO.ConnectionString = _connectioString;
                            model.OrganisationBranchDetailsDTO.BranchDetailID = model.ID;
                            model.OrganisationBranchDetailsDTO.CentreCode = model.CentreCode;
                            model.OrganisationBranchDetailsDTO.PresentIntake = model.PresentIntake;
                            model.OrganisationBranchDetailsDTO.IntroductionYear = model.IntroductionYear;
                            model.OrganisationBranchDetailsDTO.StreamID = model.StreamID;
                            model.OrganisationBranchDetailsDTO.DteCode = model.DteCode;
                            model.OrganisationBranchDetailsDTO.BranchPrintingSequence = model.BranchPrintingSequence;
                            model.OrganisationBranchDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                            model.OrganisationBranchDetailsDTO.ModifiedDate = DateTime.Now;
                            model.OrganisationBranchDetailsDTO.DeletedBy = null;
                            model.OrganisationBranchDetailsDTO.DeletedDate = null;

                            model.OrganisationBranchDetailsDTO.IsDeleted = false;
                            IBaseEntityResponse<OrganisationBranchDetails> response = _organisationBranchDetailsServiceAccess.UpdateOrganisationBranchDetails(model.OrganisationBranchDetailsDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    model.CentreCodeWithName = model.CentreCode;
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            //string[] splited;
           // splited = SelectedCentreCode.Split(':');
            //_organisationBranchDetailsBaseViewModel.SelectedCentreName = splited[1];
           // SelectedCentreCode = splited[0];
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
        public List<OrganisationBranchDetails> GetListOrganisationBranchDetails(string centerCode, out int TotalRecords)
        {
            List<OrganisationBranchDetails> listOrganisationBranchDetails = new List<OrganisationBranchDetails>();
            OrganisationBranchDetailsSearchRequest searchRequest = new OrganisationBranchDetailsSearchRequest();
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
                    searchRequest.CentreCode = centerCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = centerCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centerCode;
            }
            IBaseEntityCollectionResponse<OrganisationBranchDetails> baseEntityCollectionResponse = _organisationBranchDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationBranchDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationBranchDetails;
        }


        [NonAction]
        public List<OrganisationBranchDetails> GetListOrganisationBranchDetails()
        {
            OrganisationBranchDetailsSearchRequest searchRequest = new OrganisationBranchDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<OrganisationBranchDetails> listOrganisationBranchDetails = new List<OrganisationBranchDetails>();
            IBaseEntityCollectionResponse<OrganisationBranchDetails> baseEntityCollectionResponse = _organisationBranchDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationBranchDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationBranchDetails;
        }

        [NonAction]
        public IEnumerable<OrganisationBranchDetailsViewModel> GetOrganisationBranchDetails(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationBranchDetailsSearchRequest searchRequest = new OrganisationBranchDetailsSearchRequest();
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
                    searchRequest.UniversityID = universityId;
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
                    searchRequest.UniversityID = universityId;
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
                searchRequest.UniversityID = universityId;
            }

            List<OrganisationBranchDetailsViewModel> listOrganisationBranchDetailsViewModel = new List<OrganisationBranchDetailsViewModel>();
            List<OrganisationBranchDetails> listOrganisationBranchDetails = new List<OrganisationBranchDetails>();
            IBaseEntityCollectionResponse<OrganisationBranchDetails> baseEntityCollectionResponse = _organisationBranchDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationBranchDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationBranchDetails item in listOrganisationBranchDetails)
                    {
                        OrganisationBranchDetailsViewModel OrganisationBranchDetailsViewModel = new OrganisationBranchDetailsViewModel();
                        OrganisationBranchDetailsViewModel.OrganisationBranchDetailsDTO = item;
                        listOrganisationBranchDetailsViewModel.Add(OrganisationBranchDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationBranchDetailsViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedUniversityID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationBranchDetailsViewModel> filteredOrganisationBranchDetails;
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
                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationBranchDetails = GetOrganisationBranchDetails(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);    
            }
            else
            {
                filteredOrganisationBranchDetails =new List<OrganisationBranchDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOrganisationBranchDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.BranchDescription.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.BranchDetailID), Convert.ToString(c.ID) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
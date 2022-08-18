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
    public class OrganisationSectionDetailsController : BaseController
    {
        IOrganisationSectionDetailsServiceAccess _OrganisationSectionDetailsServiceAccess = null;
        OrganisationSectionDetailsBaseViewModel _OrganisationSectionDetailsBaseViewModel = null;
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

        public OrganisationSectionDetailsController()
        {
            _OrganisationSectionDetailsServiceAccess = new OrganisationSectionDetailsServiceAccess();
            _OrganisationSectionDetailsBaseViewModel = new OrganisationSectionDetailsBaseViewModel();
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
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        

        public ActionResult List(string centerCode, string universityID, string actionMode)
        {
            try
            {
                OrganisationSectionDetailsBaseViewModel model = new OrganisationSectionDetailsBaseViewModel();
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
                if (Session["RoleID"] == null)
                {
                    int AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
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
        public ActionResult Create(string SectionID)
        {

            try
            {
                OrganisationSectionDetailsViewModel model = new OrganisationSectionDetailsViewModel();
                model.OrganisationSectionDetailsDTO = new OrganisationSectionDetails();
                model.OrganisationSectionDetailsDTO.ID = Convert.ToInt32(SectionID);

                model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationSectionDetails> response = _OrganisationSectionDetailsServiceAccess.SelectByID(model.OrganisationSectionDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationSectionDetailsDTO.StandardNumber = response.Entity.StandardNumber;
                    model.OrganisationSectionDetailsDTO.BranchDetID = response.Entity.BranchDetID;
                   
                }
                model.ListOrgSectionDetails = GetListOrgSectionDetails(model.OrganisationSectionDetailsDTO.StandardNumber, model.OrganisationSectionDetailsDTO.BranchDetID);
                foreach (var b in model.ListOrgSectionDetails)
                {
                    b.CourseYearDescriptions = b.CourseYearDescriptions;
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
        public ActionResult Create(OrganisationSectionDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationSectionDetailsDTO != null)
                    {
                        model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;
                        model.OrganisationSectionDetailsDTO.ID = model.ID;
                        if (model.OrganisationSectionDetailsDTO.NextSectionDetailID == "" || model.OrganisationSectionDetailsDTO.NextSectionDetailID == null)
                        {
                            model.OrganisationSectionDetailsDTO.NextSectionDetailID = "";
                            if (model.OrganisationSectionDetailsDTO.IsFinalCourseYear == true)
                            {
                                model.OrganisationSectionDetailsDTO.IsFinalCourseYear = true;
                            }
                            else 
                                model.OrganisationSectionDetailsDTO.IsFinalCourseYear = false;

                        }
                        else if (model.OrganisationSectionDetailsDTO.NextSectionDetailID != "" || model.OrganisationSectionDetailsDTO.NextSectionDetailID != null)
                        {
                            model.OrganisationSectionDetailsDTO.NextSectionDetailID = model.NextSectionDetailID;
                        }

                        model.OrganisationSectionDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]); ;
                        model.OrganisationSectionDetailsDTO.ModifiedDate = DateTime.Now;
                        model.OrganisationSectionDetailsDTO.DeletedBy = null;
                        model.OrganisationSectionDetailsDTO.DeletedDate = null;
                       IBaseEntityResponse<OrganisationSectionDetails> response = _OrganisationSectionDetailsServiceAccess.UpdateOrganisationSectionDetails(model.OrganisationSectionDetailsDTO);
                       model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    model.CentreCodeWithName = Session["centerCode"].ToString();
                    model.UniversityIDWithName = Session["universityId"].ToString() + ":" + Session["universityName"].ToString();
                   // return Json(Boolean.TrueString + "::" + model.CentreCodeWithName + "::" + model.UniversityIDWithName);
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
        public List<OrganisationSectionDetails> GetListOrganisationSectionDetails(string centerCode, out int TotalRecords)
        {
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();

            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            //_CentreCode = "1";
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = _sortBy;
            searchRequest.StartRow = _startRow;
            searchRequest.EndRow = _startRow + _rowLength;
            searchRequest.CentreCode = centerCode;
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _OrganisationSectionDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSectionDetails;
        }


        [NonAction]
        public List<OrganisationSectionDetails> GetListOrganisationSectionDetails()
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _OrganisationSectionDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSectionDetails;
        }

        [NonAction]
        public IEnumerable<OrganisationSectionDetailsViewModel> GetOrganisationSectionDetails(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
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

                searchRequest.CentreCode = centerCode;
                searchRequest.UniversityID = universityId;
            }
            List<OrganisationSectionDetailsViewModel> listOrganisationSectionDetailsViewModel = new List<OrganisationSectionDetailsViewModel>();
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _OrganisationSectionDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSectionDetails item in listOrganisationSectionDetails)
                    {
                        OrganisationSectionDetailsViewModel OrganisationSectionDetailsViewModel = new OrganisationSectionDetailsViewModel();
                        OrganisationSectionDetailsViewModel.OrganisationSectionDetailsDTO = item;
                        listOrganisationSectionDetailsViewModel.Add(OrganisationSectionDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationSectionDetailsViewModel;
        }



        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedUniversityID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSectionDetailsViewModel> filteredOrganisationSectionDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Descriptions";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%' or STANDARDDESCRIPTION Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "STANDARDDESCRIPTION";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%' or STANDARDDESCRIPTION Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationSectionDetails = GetOrganisationSectionDetails(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredOrganisationSectionDetails = new List<OrganisationSectionDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredOrganisationSectionDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CourseYearDescriptions.ToString(), c.BranchDescriptions.ToString(), c.StandardDescriptions.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.ID), Convert.ToString(c.BranchDetID), Convert.ToString(c.StandardNumber) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
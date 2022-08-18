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
    public class OrganisationSectionDetailsAddController : BaseController
    {
        IOrganisationSectionDetailsServiceAccess _OrganisationSectionDetailsServiceAccess = null;
        IOrganisationSectionMasterServiceAccess _OrganisationSectionMasterServiceAccess = null;
        OrganisationSectionDetailsBaseViewModel _OrganisationSectionDetailsBaseViewModel = null;
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

        public OrganisationSectionDetailsAddController()
        {

            _OrganisationSectionMasterServiceAccess = new OrganisationSectionMasterServiceAccess();
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
        public ActionResult Create(string IDs,int universityID, string CentreCode)
        {
            try
            {
                OrganisationSectionDetailsViewModel model = new OrganisationSectionDetailsViewModel();
                model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;
                string[] Array = IDs.Split('~');
                int CourseYearDelID = Convert.ToInt32(Array[1]);
                List<SelectListItem> li = new List<SelectListItem>();
                //li.Add(new SelectListItem { Text = "Select Applicable Type", Value = "0" });
                li.Add(new SelectListItem { Text = "Type A", Value = "TypeA" });
                li.Add(new SelectListItem { Text = "Type B", Value = "TypeB" });
               
            //    ViewData["OrgShiftCode"] = li;
                model.OrganisationSectionDetailsDTO.UniversityID = universityID;
                model.OrganisationSectionDetailsDTO.CentreCode = CentreCode;

                model.OrganisationSectionDetailsDTO = new OrganisationSectionDetails();
                model.OrganisationSectionDetailsDTO.ID = Convert.ToInt32(Array[4]);

                model.OrganisationSectionDetailsDTO.CourseYearDetailID = Convert.ToInt32(Array[1]);
               
                model.OrganisationSectionDetailsDTO.CentreCode = CentreCode;

                model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationSectionDetails> response = _OrganisationSectionDetailsServiceAccess.SelectByID_OR_CourseYearID(model.OrganisationSectionDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    if (model.OrganisationSectionDetailsDTO.ID == 0)
                    {
                        model.OrganisationSectionDetailsDTO.CourseYearDescriptions = response.Entity.CourseYearDescriptions;
                        model.OrganisationSectionDetailsDTO.CourseYearDetailID = response.Entity.CourseYearDetailID;
                        model.OrganisationSectionDetailsDTO.StreamDescriptions = response.Entity.StreamDescriptions;
                        model.OrganisationSectionDetailsDTO.StreamID = response.Entity.StreamID;
                        model.OrganisationSectionDetailsDTO.StandardDescriptions = response.Entity.StandardDescriptions;
                        model.OrganisationSectionDetailsDTO.StandardID = response.Entity.StandardID;
                        model.OrganisationSectionDetailsDTO.MediumDescription = response.Entity.MediumDescription;
                        model.OrganisationSectionDetailsDTO.MediumID = response.Entity.MediumID;
                        model.OrganisationSectionDetailsDTO.BranchDescriptions = response.Entity.BranchDescriptions;
                        model.OrganisationSectionDetailsDTO.BranchID = response.Entity.BranchID;
                        model.OrganisationSectionDetailsDTO.ExamApplicable = response.Entity.ExamApplicable;
                        model.OrganisationSectionDetailsDTO.ExamPattern = response.Entity.ExamPattern;
                        model.OrganisationSectionDetailsDTO.DegreeName = response.Entity.DegreeName;
                        model.OrganisationSectionDetailsDTO.BranchDetID = response.Entity.BranchDetID;
                        model.OrganisationSectionDetailsDTO.Duration = response.Entity.Duration;
                        model.OrganisationSectionDetailsDTO.NumberOfSemester = response.Entity.NumberOfSemester;
                    }
                    else if (model.OrganisationSectionDetailsDTO.ID >0)
                        {
                            model.OrganisationSectionDetailsDTO.CourseYearDescriptions = response.Entity.CourseYearDescriptions;
                            model.OrganisationSectionDetailsDTO.CourseYearDetailID = response.Entity.CourseYearDetailID;
                            model.OrganisationSectionDetailsDTO.StreamDescriptions = response.Entity.StreamDescriptions;
                            model.OrganisationSectionDetailsDTO.StreamID = response.Entity.StreamID;
                            model.OrganisationSectionDetailsDTO.StandardDescriptions = response.Entity.StandardDescriptions;
                            model.OrganisationSectionDetailsDTO.StandardID = response.Entity.StandardID;
                            model.OrganisationSectionDetailsDTO.MediumDescription = response.Entity.MediumDescription;
                            model.OrganisationSectionDetailsDTO.MediumID = response.Entity.MediumID;
                            model.OrganisationSectionDetailsDTO.BranchDescriptions = response.Entity.BranchDescriptions;
                            model.OrganisationSectionDetailsDTO.BranchID = response.Entity.BranchID;
                            model.OrganisationSectionDetailsDTO.ExamApplicable = response.Entity.ExamApplicable;
                            model.OrganisationSectionDetailsDTO.ExamPattern = response.Entity.ExamPattern;
                            model.OrganisationSectionDetailsDTO.DegreeName = response.Entity.DegreeName;
                            model.OrganisationSectionDetailsDTO.BranchDetID = response.Entity.BranchDetID;
                            model.OrganisationSectionDetailsDTO.Duration = response.Entity.Duration;
                            model.OrganisationSectionDetailsDTO.NumberOfSemester = response.Entity.NumberOfSemester;

                            model.OrganisationSectionDetailsDTO.Descriptions = response.Entity.Descriptions;
                            model.OrganisationSectionDetailsDTO.SectionDetailCode = response.Entity.SectionDetailCode;
                            model.OrganisationSectionDetailsDTO.SectionActive = response.Entity.SectionActive;
                            model.OrganisationSectionDetailsDTO.OrgShiftCode = response.Entity.OrgShiftCode;
                            model.OrganisationSectionDetailsDTO.SectionCapacity = response.Entity.SectionCapacity;
                            model.OrganisationSectionDetailsDTO.SectionID = response.Entity.SectionID;

                        }
                }
                ViewData["OrgShiftCode"] = new SelectList(li, "Value", "Text", model.OrgShiftCode);
                //For Section Master
                List<OrganisationSectionMaster> organisationSectionMasterList = GetListOrganisationSectionMaster(CourseYearDelID, model.OrganisationSectionDetailsDTO.SectionID);
                List<SelectListItem> organisationSectionMaster = new List<SelectListItem>();
                foreach (OrganisationSectionMaster item in organisationSectionMasterList)
                {
                    organisationSectionMaster.Add(new SelectListItem { Text = item.CourseYearDescription + "-" + item.SectionName, Value = item.ID.ToString() + "~" + item.CourseYearDescription + "-" + item.SectionName });
                }
             
                ViewBag.organisationSectionMaster = new SelectList(organisationSectionMaster, "Value", "Text");
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
                        if (model.OrganisationSectionDetailsDTO.ID == 0)
                        {
                            model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;
                            model.OrganisationSectionDetailsDTO.StreamID = model.StreamID;
                            model.OrganisationSectionDetailsDTO.BranchID = model.BranchID;
                            model.OrganisationSectionDetailsDTO.StandardID = model.StandardID;
                            model.OrganisationSectionDetailsDTO.MediumID = model.MediumID;
                            model.OrganisationSectionDetailsDTO.Duration = model.Duration;

                            string[] aaa = model.SelectedDescriptions.Split('~');
                            model.OrganisationSectionDetailsDTO.Descriptions = aaa[1];
                            model.OrganisationSectionDetailsDTO.SectionID = Convert.ToInt32(aaa[0]);
                            model.OrganisationSectionDetailsDTO.SectionActive = model.SectionActive;
                            model.OrganisationSectionDetailsDTO.SectionCapacity = model.SectionCapacity;

                            if (model.ExamApplicable == "Internal & External")
                            {
                                model.OrganisationSectionDetailsDTO.ExamApplicable = "B";
                            }
                            else if (model.ExamApplicable == "Internal")
                            {
                                model.OrganisationSectionDetailsDTO.ExamApplicable = "I";
                            }
                            else if (model.ExamApplicable == "External")
                            {
                                model.OrganisationSectionDetailsDTO.ExamApplicable = "E";
                            }
                            else if (model.ExamApplicable == "None")
                            {
                                model.OrganisationSectionDetailsDTO.ExamApplicable = "N";
                            }

                            if (model.ExamPattern == "Semester")
                            {
                                model.OrganisationSectionDetailsDTO.ExamPattern = "S";
                            }
                            if (model.ExamPattern == "Yearly")
                            {
                                model.OrganisationSectionDetailsDTO.ExamPattern = "Y";
                            }
                            model.OrganisationSectionDetailsDTO.SectionDetailCode = model.SectionDetailCode;
                            model.OrganisationSectionDetailsDTO.DegreeName = model.DegreeName;
                            model.OrganisationSectionDetailsDTO.CourseYearDetailID = model.CourseYearDetailID;
                            model.OrganisationSectionDetailsDTO.BranchDetID = model.BranchDetID;
                            model.OrganisationSectionDetailsDTO.NumberOfSemester = model.NumberOfSemester;

                            model.OrganisationSectionDetailsDTO.CentreCode = model.CentreCode;
                            model.OrganisationSectionDetailsDTO.OrgShiftCode = model.OrgShiftCode;
                            model.OrganisationSectionDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<OrganisationSectionDetails> response = _OrganisationSectionDetailsServiceAccess.InsertOrganisationSectionDetails(model.OrganisationSectionDetailsDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }

                        else if (model.OrganisationSectionDetailsDTO.ID >0)
                        {
                            model.OrganisationSectionDetailsDTO.ConnectionString = _connectioString;


                            string[] aaa = model.SelectedDescriptions.Split('~');
                            model.OrganisationSectionDetailsDTO.Descriptions = aaa[1];
                            model.OrganisationSectionDetailsDTO.SectionID = Convert.ToInt32(aaa[0]);
                            model.OrganisationSectionDetailsDTO.SectionActive = model.SectionActive;
                            model.OrganisationSectionDetailsDTO.SectionCapacity = model.SectionCapacity;
                            model.OrganisationSectionDetailsDTO.SectionDetailCode = model.SectionDetailCode;
                            model.OrganisationSectionDetailsDTO.OrgShiftCode = model.OrgShiftCode;
                            model.OrganisationSectionDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            model.OrganisationSectionDetailsDTO.ModifiedDate = DateTime.Now;
                            model.OrganisationSectionDetailsDTO.DeletedBy = null;
                            model.OrganisationSectionDetailsDTO.DeletedDate = null;
                            model.OrganisationSectionDetailsDTO.IsDeleted = false;

                            IBaseEntityResponse<OrganisationSectionDetails> response = _OrganisationSectionDetailsServiceAccess.UpdateOrganisationSectionDetailsAdd(model.OrganisationSectionDetailsDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    model.CentreCodeWithName = model.CentreCode;
                    model.UniversityIDWithName = Convert.ToString( model.UniversityID);
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
            //splited = SelectedCentreCode.Split(':');
            //_OrganisationSectionDetailsBaseViewModel.SelectedCentreName = splited[1];
            //SelectedCentreCode = splited[0];
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

        protected List<OrganisationSectionMaster> GetListOrganisationSectionMaster(int CourseYearID,int SectionMasterID)
        {
            OrganisationSectionMasterSearchRequest searchRequest = new OrganisationSectionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //int SelectedCountryID = 0;
            //bool isValid = Int32.TryParse(CountryID, out SelectedCountryID);
            searchRequest.ID = SectionMasterID;
            searchRequest.CourseYearID = CourseYearID;
            List<OrganisationSectionMaster> listOrganisationStreamMaster = new List<OrganisationSectionMaster>();
            IBaseEntityCollectionResponse<OrganisationSectionMaster> baseEntityCollectionResponse = _OrganisationSectionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStreamMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStreamMaster;
        }
        //[NonAction]
        //public List<OrganisationSectionDetails> GetListOrganisationSectionDetails(string centerCode, out int TotalRecords)
        //{
        //    List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();

        //    OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
        //    //_CentreCode = "1";
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SortBy = _sortBy;
        //    searchRequest.StartRow = _startRow;
        //    searchRequest.EndRow = _startRow + _rowLength;
        //    searchRequest.CentreCode = centerCode;
        //    IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _OrganisationSectionDetailsServiceAccess.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    TotalRecords = baseEntityCollectionResponse.TotalRecords;
        //    return listOrganisationSectionDetails;
        //}


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
        public IEnumerable<OrganisationSectionDetailsViewModel> GetOrganisationSectionDetailsAdd(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
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
            List<OrganisationSectionDetailsViewModel> listOrganisationSectionDetailsViewModel = new List<OrganisationSectionDetailsViewModel>();
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _OrganisationSectionDetailsServiceAccess.GetBySearchForSectionDetailsAdd(searchRequest);
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
                        _searchBy = "Descriptions Like '%" + param.sSearch + "%' or BranchDescription Like '%" + param.sSearch + "%' or CourseYearCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationSectionDetails = GetOrganisationSectionDetailsAdd(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);
            }
            else
            {
                filteredOrganisationSectionDetails = new List<OrganisationSectionDetailsViewModel>();
                TotalRecords = 0;
            }
            var displayedPosts = filteredOrganisationSectionDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.Descriptions.ToString(), c.BranchDescriptions.ToString() + "  ( " + c.CourseYearDescriptions + " )", c.StatusFlag.ToString(), Convert.ToString(c.BranchID + "~" + c.CourseYearDetailID + "~" + c.StreamID + "~" + c.StandardID + "~" + 0), Convert.ToString(c.BranchID + "~" + c.CourseYearDetailID + "~" + c.StreamID + "~" + c.StandardID + "~" + c.ID) };
            
            return Json(new {  sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result },  JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
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
    public class OrganisationCourseYearDetailsController : BaseController
    {
        IOrganisationCourseYearDetailsServiceAccess _OrganisationCourseYearDetailsServiceAccess = null;
        OrganisationCourseYearDetailsBaseViewModel _OrganisationCourseYearDetailsBaseViewModel = null;
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

        public OrganisationCourseYearDetailsController()
        {
            _OrganisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
            _OrganisationCourseYearDetailsBaseViewModel = new OrganisationCourseYearDetailsBaseViewModel();
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
               OrganisationCourseYearDetailsBaseViewModel model = new OrganisationCourseYearDetailsBaseViewModel();
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
        public ActionResult Create(string CentreDetails, string ID)
        {
            try
            {
                var splitData = ID.Split('~');
                var splitCentreCode = CentreDetails.Split(':');
                OrganisationCourseYearDetailsViewModel model = new OrganisationCourseYearDetailsViewModel();
                model.OrganisationCourseYearDetailsDTO = new OrganisationCourseYearDetails();
                model.OrganisationCourseYearDetailsDTO.BranchID =Convert.ToInt32(splitData[0]);
                model.OrganisationCourseYearDetailsDTO.CentreName = splitCentreCode[1].Replace('$', ' ');
                model.OrganisationCourseYearDetailsDTO.CentreCode = splitCentreCode[0].Replace('$', ' ');;
                model.StreamDescription = splitData[2].Replace('$', ' ');
                model.StreamID = Convert.ToInt32(splitData[1]);
                List<SelectListItem> li = new List<SelectListItem>();
                //li.Add(new SelectListItem { Text = "Select Applicable Type", Value = "0" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_None, Value = "N" });
                li.Add(new SelectListItem { Text = Resources.TableHeaders_Internal, Value = "I" });
                li.Add(new SelectListItem { Text = Resources.TableHeaders_External, Value = "E" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Both_Internal_External, Value = "B" });
                ViewData["ApplicableType"] = li;

                model.OrganisationCourseYearDetailsDTO.ConnectionString = _connectioString;

                // List for Stream
                List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
                List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
                foreach (OrganisationStreamMaster item in organisationStreamMasterList)
                {
                    organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                }

                ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");
                // List for Standard
                List<OrganisationStandardMaster> organisationStandardMasterList = GetListOrganisationStandardMaster();
                List<SelectListItem> organisationStandardMaster = new List<SelectListItem>();
                foreach (OrganisationStandardMaster item in organisationStandardMasterList)
                {
                    organisationStandardMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationStandardMaster = new SelectList(organisationStandardMaster, "Value", "Text");

                // List for Medium
                List<OrganisationMediumMaster> organisationMediumMasterList = GetListOrganisationMediumMaster();
                List<SelectListItem> organisationMediumMaster = new List<SelectListItem>();
                foreach (OrganisationMediumMaster item in organisationMediumMasterList)
                {
                    organisationMediumMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationMediumMaster = new SelectList(organisationMediumMaster, "Value", "Text");
                model.OrganisationSemesterMasterList = GetListOrganisationSemesterApplicable(0);
                foreach (var b in model.OrganisationSemesterMasterList)
                {
                    if (b.SemesterStatusFlag == true)
                    {
                        model.semesterSelected = "selected";
                    }
                    else
                    {
                        model.semesterSelected = "";
                    }
                }
                var CurrentDate = DateTime.Now.ToString("yyyy");
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationCourseYearDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (model != null && model.OrganisationCourseYearDetailsDTO != null)
                    {

                        model.OrganisationCourseYearDetailsDTO.ConnectionString = _connectioString;
                        model.OrganisationCourseYearDetailsDTO.BranchID = model.BranchID;
                        model.OrganisationCourseYearDetailsDTO.CentreCode = model.CentreCode;
                        model.OrganisationCourseYearDetailsDTO.StreamID = model.StreamID;
                        model.OrganisationCourseYearDetailsDTO.StandardID = model.StandardID;
                        model.OrganisationCourseYearDetailsDTO.MediumID = model.MediumID;
                        model.OrganisationCourseYearDetailsDTO.CourseYearCode = model.CourseYearCode;
                        model.OrganisationCourseYearDetailsDTO.DegreeName = model.DegreeName;
                        model.OrganisationCourseYearDetailsDTO.SectionCapacity = model.SectionCapacity;
                        model.OrganisationCourseYearDetailsDTO.Description = model.Description;
                        model.OrganisationCourseYearDetailsDTO.ExamPattern = model.ExamPattern;
                        model.OrganisationCourseYearDetailsDTO.ExamApplicable = model.ExamApplicable;
                        model.OrganisationCourseYearDetailsDTO.BranchActive = true;
                        model.OrganisationCourseYearDetailsDTO.Duration = model.Duration;
                        //model.OrganisationCourseYearDetailsDTO.NextCourseYearDetailID ="null";
                        model.OrganisationCourseYearDetailsDTO.selectItemSemesterIDs = model.selectItemSemesterIDs;
                        model.OrganisationCourseYearDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        int Number_of_semester = 0;
                        if (!string.IsNullOrEmpty(model.selectItemSemesterIDs) && model.ExamPattern == "S")
                        {
                            string selectItemSemesterid = model.selectItemSemesterIDs;
                            string Semister_Ids = null;
                            string[] OrgSemester_MstID_Type = selectItemSemesterid.Split(',');
                            foreach (char a in selectItemSemesterid)
                            {
                                if (a == ',')
                                {
                                    Number_of_semester = Number_of_semester + 1;
                                }
                            }

                            for (int i = 0; i < Number_of_semester; i++)
                            {
                                string a = OrgSemester_MstID_Type[i];
                                string[] OrgSemester_MstID = a.Split('~');
                                Semister_Ids = Semister_Ids + "<row><ID>0</ID><OrgSemesterMstID>";
                                Semister_Ids = Semister_Ids + OrgSemester_MstID[0] + "</OrgSemesterMstID><SemesterActiveFlag>1</SemesterActiveFlag><SemesterType>";
                                Semister_Ids = Semister_Ids + OrgSemester_MstID[1] + "</SemesterType></row>";

                            }

                            model.OrganisationCourseYearDetailsDTO.NumberOfSemester = Number_of_semester;
                            Semister_Ids = "<rows>" + Semister_Ids + "</rows>";
                            model.OrganisationCourseYearDetailsDTO.SemesterIDs = Semister_Ids;                            
                        }
                        else
                        {
                            model.OrganisationCourseYearDetailsDTO.SemesterIDs = string.Empty;
                        }


                        IBaseEntityResponse<OrganisationCourseYearDetails> response = _OrganisationCourseYearDetailsServiceAccess.InsertOrganisationCourseYearDetails(model.OrganisationCourseYearDetailsDTO);
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
        public ActionResult Edit(int CourseYearID, string CentreDetails)
        {
            try
            {
                OrganisationCourseYearDetailsViewModel model = new OrganisationCourseYearDetailsViewModel();

                model.OrganisationCourseYearDetailsDTO = new OrganisationCourseYearDetails();
                model.OrganisationCourseYearDetailsDTO.ID = CourseYearID;
                model.OrganisationCourseYearDetailsDTO.ConnectionString = _connectioString;
                var splitCentreDetails = CentreDetails.Split(':');

                List<SelectListItem> li = new List<SelectListItem>();
                //li.Add(new SelectListItem { Text = "Select Applicable Type", Value = "0" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_None, Value = "N" });
                li.Add(new SelectListItem { Text = Resources.TableHeaders_Internal, Value = "I" });
                li.Add(new SelectListItem { Text = Resources.TableHeaders_External, Value = "E" });
                li.Add(new SelectListItem { Text = Resources.DisplayName_Both_Internal_External, Value = "B" });
                ViewData["ApplicableType"] = li;

                //// List for Stream
                //List<OrganisationStreamMaster> organisationStreamMasterList = GetListOrganisationStreamMaster();
                //List<SelectListItem> organisationStreamMaster = new List<SelectListItem>();
                //foreach (OrganisationStreamMaster item in organisationStreamMasterList)
                //{
                //    organisationStreamMaster.Add(new SelectListItem { Text = item.StreamDescription, Value = item.ID.ToString() });
                //}

                //ViewBag.OrganisationStreamMaster = new SelectList(organisationStreamMaster, "Value", "Text");
                // List for Standard
                List<OrganisationStandardMaster> organisationStandardMasterList = GetListOrganisationStandardMaster();
                List<SelectListItem> organisationStandardMaster = new List<SelectListItem>();
                foreach (OrganisationStandardMaster item in organisationStandardMasterList)
                {
                    organisationStandardMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationStandardMaster = new SelectList(organisationStandardMaster, "Value", "Text");

                // List for Medium
                List<OrganisationMediumMaster> organisationMediumMasterList = GetListOrganisationMediumMaster();
                List<SelectListItem> organisationMediumMaster = new List<SelectListItem>();
                foreach (OrganisationMediumMaster item in organisationMediumMasterList)
                {
                    organisationMediumMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationMediumMaster = new SelectList(organisationMediumMaster, "Value", "Text");

                model.OrganisationSemesterMasterList = GetListOrganisationSemesterApplicable(CourseYearID);
                foreach (var b in model.OrganisationSemesterMasterList)
                {
                    if (b.SemesterStatusFlag == true)
                    {
                        model.semesterSelected = "selected";
                    }
                    else
                    {
                        model.semesterSelected = "";
                    }
                }

                List<SelectListItem> organisationSemesterMaster = new List<SelectListItem>();

                IBaseEntityResponse<OrganisationCourseYearDetails> response = _OrganisationCourseYearDetailsServiceAccess.SelectByID(model.OrganisationCourseYearDetailsDTO);

                if (response != null && response.Entity != null)
                {
                    model.OrganisationCourseYearDetailsDTO.BranchID = response.Entity.ID;
                    model.OrganisationCourseYearDetailsDTO.ConnectionString = _connectioString;
                    model.OrganisationCourseYearDetailsDTO.BranchID = model.BranchID;
                    model.OrganisationCourseYearDetailsDTO.CentreCode = splitCentreDetails[0].Replace('$',' ');
                    model.OrganisationCourseYearDetailsDTO.CentreName = splitCentreDetails[1].Replace('$', ' ');
                    model.OrganisationCourseYearDetailsDTO.BranchDescription = response.Entity.BranchDescription;
                    model.OrganisationCourseYearDetailsDTO.StreamID = response.Entity.StreamID;
                    model.OrganisationCourseYearDetailsDTO.StreamDescription = response.Entity.StreamDescription;
                    model.OrganisationCourseYearDetailsDTO.StandardID = response.Entity.StandardID;
                    model.OrganisationCourseYearDetailsDTO.MediumID = response.Entity.MediumID;
                    model.OrganisationCourseYearDetailsDTO.CourseYearCode = response.Entity.CourseYearCode;
                    model.OrganisationCourseYearDetailsDTO.DegreeName = response.Entity.DegreeName;
                    model.OrganisationCourseYearDetailsDTO.SectionCapacity = response.Entity.SectionCapacity;
                    model.OrganisationCourseYearDetailsDTO.Description = response.Entity.Description;
                    model.OrganisationCourseYearDetailsDTO.ExamPattern = response.Entity.ExamPattern;
                    model.OrganisationCourseYearDetailsDTO.ExamApplicable = response.Entity.ExamApplicable;
                    model.OrganisationCourseYearDetailsDTO.BranchActive = true;
                    model.OrganisationCourseYearDetailsDTO.Duration = response.Entity.Duration;
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
        public ActionResult Edit(OrganisationCourseYearDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationCourseYearDetailsDTO != null)
                    {
                        if (model != null && model.OrganisationCourseYearDetailsDTO != null)
                        {
                            model.OrganisationCourseYearDetailsDTO.ConnectionString = _connectioString;
                            model.OrganisationCourseYearDetailsDTO.CourseYearID = model.ID;
                            model.OrganisationCourseYearDetailsDTO.CentreCode = model.CentreCode;
                            model.OrganisationCourseYearDetailsDTO.StreamID = model.StreamID;
                            model.OrganisationCourseYearDetailsDTO.StandardID = model.StandardID;
                            model.OrganisationCourseYearDetailsDTO.MediumID = model.MediumID;
                            model.OrganisationCourseYearDetailsDTO.CourseYearCode = model.CourseYearCode;
                            model.OrganisationCourseYearDetailsDTO.DegreeName = model.DegreeName;
                            model.OrganisationCourseYearDetailsDTO.SectionCapacity = model.SectionCapacity;
                            model.OrganisationCourseYearDetailsDTO.Description = model.Description;
                            model.OrganisationCourseYearDetailsDTO.ExamPattern = model.ExamPattern;
                            model.OrganisationCourseYearDetailsDTO.ExamApplicable = model.ExamApplicable;
                            model.OrganisationCourseYearDetailsDTO.BranchActive = true;
                            model.OrganisationCourseYearDetailsDTO.Duration = model.Duration;
                            //model.OrganisationCourseYearDetailsDTO.NextCourseYearDetailID ="null";
                            model.OrganisationCourseYearDetailsDTO.SemesterIDs = model.selectItemSemesterIDs;
                            model.OrganisationCourseYearDetailsDTO.NumberOfSemester = model.NumberOfSemester;
                            model.OrganisationCourseYearDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                            model.OrganisationCourseYearDetailsDTO.ModifiedBy = 1;
                            model.OrganisationCourseYearDetailsDTO.ModifiedDate = DateTime.Now;
                            model.OrganisationCourseYearDetailsDTO.DeletedBy = null;
                            model.OrganisationCourseYearDetailsDTO.DeletedDate = null;
                            model.OrganisationCourseYearDetailsDTO.IsDeleted = false;
                            IBaseEntityResponse<OrganisationCourseYearDetails> response = _OrganisationCourseYearDetailsServiceAccess.UpdateOrganisationCourseYearDetails(model.OrganisationCourseYearDetailsDTO);
                            model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    model.CentreCodeWithName = model.CentreCode;
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Boolean.TrueString);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #region Methods
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            var result = (from s in university select new { id = s.ID , name = s.UniversityName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<OrganisationCourseYearDetails> GetListOrganisationSemesterApplicable(int CourseYearID)
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = Convert.ToString(CourseYearID);
            //searchRequest.SearchType = 1;
            List<OrganisationCourseYearDetails> OrganisationSemesterMasterList = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _OrganisationCourseYearDetailsServiceAccess.GetByApplicableSemester(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSemesterMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSemesterMasterList;
        }
        [NonAction]
        public List<OrganisationCourseYearDetails> GetListOrganisationCourseYearDetails()
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsDeleted = false;
            searchRequest.SearchType = "SearchAll";
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _OrganisationCourseYearDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }

        [NonAction]
        public IEnumerable<OrganisationCourseYearDetailsViewModel> GetOrganisationCourseYearDetails(string centerCode, int universityId, out int TotalRecords)
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
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
                    searchRequest.SortBy = "B.ModifiedDate";
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

            List<OrganisationCourseYearDetailsViewModel> listOrganisationCourseYearDetailsViewModel = new List<OrganisationCourseYearDetailsViewModel>();
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _OrganisationCourseYearDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationCourseYearDetails item in listOrganisationCourseYearDetails)
                    {
                        OrganisationCourseYearDetailsViewModel OrganisationCourseYearDetailsViewModel = new OrganisationCourseYearDetailsViewModel();
                        OrganisationCourseYearDetailsViewModel.OrganisationCourseYearDetailsDTO = item;
                        listOrganisationCourseYearDetailsViewModel.Add(OrganisationCourseYearDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationCourseYearDetailsViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedUniversityID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationCourseYearDetailsViewModel> filteredOrganisationCourseYearDetails;
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
                        _searchBy = "(BranchDescription Like '%" + param.sSearch + "%' or CourseYearCode Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID))
            {
                filteredOrganisationCourseYearDetails = GetOrganisationCourseYearDetails(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), out TotalRecords);    
            }
            else
            {
                filteredOrganisationCourseYearDetails = new List<OrganisationCourseYearDetailsViewModel>();
                TotalRecords = 0;
            }
            
            var records = filteredOrganisationCourseYearDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CourseDescription.ToString(), c.BranchDescription.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.ID +"~"+c.StreamID +"~"+Convert.ToString(c.StreamDescription)), Convert.ToString(c.CourseYearID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }

}
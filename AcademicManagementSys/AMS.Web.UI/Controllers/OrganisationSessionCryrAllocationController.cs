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
using System.Globalization;
namespace AMS.Web.UI.Controllers
{
    public class OrganisationSessionCryrAllocationController : BaseController
    {
        IOrganisationSessionCryrAllocationServiceAccess _OrganisationSessionCryrAllocationServiceAccess = null;
        OrganisationSessionCryrAllocationBaseViewModel _OrganisationSessionCryrAllocationBaseViewModel = null;
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

        public OrganisationSessionCryrAllocationController()
        {
            _OrganisationSessionCryrAllocationServiceAccess = new OrganisationSessionCryrAllocationServiceAccess();
            _OrganisationSessionCryrAllocationBaseViewModel = new OrganisationSessionCryrAllocationBaseViewModel();
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
                OrganisationSessionCryrAllocationBaseViewModel model = new OrganisationSessionCryrAllocationBaseViewModel();
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
        public ActionResult Create(string IDs, string CentreCode, string UniversityID)
        {
            try
            {
                OrganisationSessionCryrAllocationViewModel model = new OrganisationSessionCryrAllocationViewModel();
                string[] Ids = IDs.Split('~');
                int SemesterMstID = Convert.ToInt32(Ids[0]);
                string SemesterType = Ids[1].ToString();
                int CourseYearSemesterID = Convert.ToInt32(Ids[2]);
                model.OrganisationSessionCryrAllocationDTO.ConnectionString = _connectioString;
                string[] Centre_code = CentreCode.Split(':');
                model.OrganisationSessionCryrAllocationDTO.CentreCode = Centre_code[0];
                IBaseEntityResponse<OrganisationSessionCryrAllocation> response = _OrganisationSessionCryrAllocationServiceAccess.GetCurrentSession(model.OrganisationSessionCryrAllocationDTO);

                model.OrganisationSessionCryrAllocationDTO = new OrganisationSessionCryrAllocation();
                model.OrganisationSessionCryrAllocationDTO.SemesterMasterID = SemesterMstID;
                model.OrganisationSessionCryrAllocationDTO.SemesterType = SemesterType;
                model.OrganisationSessionCryrAllocationDTO.CourseYearSemesterID = CourseYearSemesterID;
                model.OrganisationSessionCryrAllocationDTO.SessionID = response.Entity.SessionID;
                model.SessionName = response.Entity.SessionName;
                model.CentreCode = CentreCode;
                model.UniversityIDWithName = UniversityID;

                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(OrganisationSessionCryrAllocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSessionCryrAllocationDTO != null)
                    {
                        model.OrganisationSessionCryrAllocationDTO.ConnectionString = _connectioString;
                        model.OrganisationSessionCryrAllocationDTO.SessionID = model.SessionID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterMasterID = model.SemesterMasterID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterType = model.SemesterType;
                        model.OrganisationSessionCryrAllocationDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterFromDate = model.SemesterFromDate;
                        model.OrganisationSessionCryrAllocationDTO.SemesterUptoDate = model.SemesterUptoDate;
                        model.OrganisationSessionCryrAllocationDTO.CurrentActiveSemesterFlag = true;
                        model.OrganisationSessionCryrAllocationDTO.TotalExpectedWeeks = model.TotalExpectedWeeks;
                        model.OrganisationSessionCryrAllocationDTO.PeriodStartDate = model.PeriodStartDate;
                        model.OrganisationSessionCryrAllocationDTO.PeriodEndDate = model.PeriodEndDate;
                        model.OrganisationSessionCryrAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<OrganisationSessionCryrAllocation> response = _OrganisationSessionCryrAllocationServiceAccess.InsertOrganisationSessionCryrAllocation(model.OrganisationSessionCryrAllocationDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
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

        public ActionResult Edit(int ID, bool OrgSessionCryrAllotStatus, string SessionName, string CentreCode, string UniversityID)
        {
            try
            {
                OrganisationSessionCryrAllocationViewModel model = new OrganisationSessionCryrAllocationViewModel();
                model.OrganisationSessionCryrAllocationDTO = new OrganisationSessionCryrAllocation();
                model.OrganisationSessionCryrAllocationDTO.ID = ID;
                model.OrganisationSessionCryrAllocationDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationSessionCryrAllocation> response = _OrganisationSessionCryrAllocationServiceAccess.SelectByID(model.OrganisationSessionCryrAllocationDTO);

                if (response != null && response.Entity != null)
                {
                    model.OrganisationSessionCryrAllocationDTO.OrgSessionCourseYearAllocationID = response.Entity.ID;
                    model.OrganisationSessionCryrAllocationDTO.SessionID = response.Entity.SessionID;
                    model.SessionName = SessionName;
                    model.OrganisationSessionCryrAllocationDTO.SemesterMasterID = response.Entity.SemesterMasterID;
                    model.OrganisationSessionCryrAllocationDTO.CourseYearSemesterID = response.Entity.CourseYearSemesterID;
                    model.OrganisationSessionCryrAllocationDTO.SemesterType = response.Entity.SemesterType;

                    //model.OrganisationSessionCryrAllocationDTO.SemesterFromDate = response.Entity.SemesterFromDate;
                    //model.OrganisationSessionCryrAllocationDTO.SemesterUptoDate = response.Entity.SemesterUptoDate;
                    //model.OrganisationSessionCryrAllocationDTO.PeriodStartDate = response.Entity.PeriodStartDate;
                    //model.OrganisationSessionCryrAllocationDTO.PeriodEndDate = response.Entity.PeriodEndDate;

                    //model.OrganisationSessionCryrAllocationDTO.SemesterFromDate = Convert.ToDateTime(response.Entity.SemesterFromDate).ToString("dd MMMM yyyy");
                    

                    string spFromDate = response.Entity.SemesterFromDate.Replace("/", " ");
                    string spUptoDate = response.Entity.SemesterUptoDate.Replace("/", " ");
                    string spStartDate = response.Entity.PeriodStartDate.Replace("/", " ");
                    string spEndDate = response.Entity.PeriodEndDate.Replace("/", " ");

                    string[] month = new string[13] {" ", "January", "February", "March", "April", "May", "June",
               "July", "August", "September", "October", "November", "December" };

                    var splFromDate = spFromDate.Split(' ');
                    var splUptoDate = spUptoDate.Split(' ');
                    var splStartDate = spStartDate.Split(' ');
                    var splEndDate = spEndDate.Split(' ');

                    string FromDate = splFromDate[0] + " " + month[int.Parse(splFromDate[1])] + " " + splFromDate[2];
                    string UptoDate = splUptoDate[0] + " " + month[int.Parse(splUptoDate[1])] + " " + splUptoDate[2];
                    string StartDate = splStartDate[0] + " " + month[int.Parse(splStartDate[1])] + " " + splStartDate[2];
                    string EndDate = splEndDate[0] + " " + month[int.Parse(splEndDate[1])] + " " + splEndDate[2];

                    model.OrganisationSessionCryrAllocationDTO.SemesterFromDate=FromDate;
                    model.OrganisationSessionCryrAllocationDTO.SemesterUptoDate=UptoDate;
                    model.OrganisationSessionCryrAllocationDTO.PeriodStartDate = StartDate;
                    model.OrganisationSessionCryrAllocationDTO.PeriodEndDate = EndDate;
                    
                    
                    
                    //DateTime dateTime;
                    //var dt=DateTime.TryParseExact(
                    //                       response.Entity.SemesterUptoDate,
                    //                       "MM/dd/yyyy hh:mm:ss tt",
                    //                       CultureInfo.InvariantCulture,
                    //                       DateTimeStyles.None,
                    //                       out dateTime
                    //                      );
                   
                    //model.OrganisationSessionCryrAllocationDTO.PeriodEndDate = Convert.ToDateTime(response.Entity.PeriodEndDate.Replace("/", "")).ToString("dd MM yyyy");
                    
                    //model.OrganisationSessionCryrAllocationDTO.SemesterUptoDate = response.Entity.SemesterUptoDate.Replace("/", "");
                   
                    //DateTime dtm = DateTime.ParseExact(Convert.ToString(response.Entity.SemesterUptoDate), "dd MM yyyy", CultureInfo.InvariantCulture);
                    //string s = dtm.ToString("dd MM yyyy", CultureInfo.InvariantCulture);



                    model.OrganisationSessionCryrAllocationDTO.TotalExpectedWeeks = response.Entity.TotalExpectedWeeks;
                    model.OrganisationSessionCryrAllocationDTO.CurrentActiveSemesterFlag = response.Entity.CurrentActiveSemesterFlag;
                    model.OrganisationSessionCryrAllocationDTO.OrgSessionCryrAllotStatus = OrgSessionCryrAllotStatus;
                    model.CentreCode = CentreCode;
                    model.UniversityIDWithName = UniversityID;
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
        public ActionResult Edit(OrganisationSessionCryrAllocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSessionCryrAllocationDTO != null)
                    {


                        model.OrganisationSessionCryrAllocationDTO.ConnectionString = _connectioString;
                        model.OrganisationSessionCryrAllocationDTO.SessionID = model.SessionID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterMasterID = model.SemesterMasterID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterType = model.SemesterType;
                        model.OrganisationSessionCryrAllocationDTO.CourseYearSemesterID = model.CourseYearSemesterID;
                        model.OrganisationSessionCryrAllocationDTO.SemesterFromDate = model.SemesterFromDate;
                        model.OrganisationSessionCryrAllocationDTO.SemesterUptoDate = model.SemesterUptoDate;
                        model.OrganisationSessionCryrAllocationDTO.CurrentActiveSemesterFlag = model.CurrentActiveSemesterFlag;
                        model.OrganisationSessionCryrAllocationDTO.TotalExpectedWeeks = model.TotalExpectedWeeks;
                        model.OrganisationSessionCryrAllocationDTO.PeriodStartDate = model.PeriodStartDate;
                        model.OrganisationSessionCryrAllocationDTO.PeriodEndDate = model.PeriodEndDate;
                        model.OrganisationSessionCryrAllocationDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);


                        IBaseEntityResponse<OrganisationSessionCryrAllocation> response = _OrganisationSessionCryrAllocationServiceAccess.UpdateOrganisationSessionCryrAllocation(model.OrganisationSessionCryrAllocationDTO);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
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

        #region Methods


        [NonAction]
        public IEnumerable<OrganisationSessionCryrAllocationViewModel> GetOrganisationSessionCryrAllocation(string centreCode, int universityID, string CurrentSessionID, out int TotalRecords)
        {
            OrganisationSessionCryrAllocationSearchRequest searchRequest = new OrganisationSessionCryrAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "bb.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";

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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "bb.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";

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
                searchRequest.SessionID = Convert.ToInt32(CurrentSessionID);

                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
            }
            List<OrganisationSessionCryrAllocationViewModel> listOrganisationSessionCryrAllocationViewModel = new List<OrganisationSessionCryrAllocationViewModel>();
            List<OrganisationSessionCryrAllocation> listOrganisationSessionCryrAllocation = new List<OrganisationSessionCryrAllocation>();
            IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> baseEntityCollectionResponse = _OrganisationSessionCryrAllocationServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSessionCryrAllocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSessionCryrAllocation item in listOrganisationSessionCryrAllocation)
                    {
                        OrganisationSessionCryrAllocationViewModel OrganisationSessionCryrAllocationViewModel = new OrganisationSessionCryrAllocationViewModel();
                        OrganisationSessionCryrAllocationViewModel.OrganisationSessionCryrAllocationDTO = item;
                        listOrganisationSessionCryrAllocationViewModel.Add(OrganisationSessionCryrAllocationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationSessionCryrAllocationViewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            try
            {
                string[] splited;
                splited = SelectedCentreCode.Split(':');
                _OrganisationSessionCryrAllocationBaseViewModel.SelectedCentreName = splited[1];
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
                                  id = s.ID ,
                                  name = s.UniversityName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CurrentSessionID, string SelectedUniversityID, string SelectedCentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSessionCryrAllocationViewModel> filteredOrganisationSessionCryrAllocation;
           
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
                        _searchBy = "BranchDescription Like '%" + param.sSearch + "%' or CourseYearCode Like '%" + param.sSearch + "%'  or OrgSemesterName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(SelectedUniversityID) && !string.IsNullOrEmpty(CurrentSessionID))
            {
                filteredOrganisationSessionCryrAllocation = GetOrganisationSessionCryrAllocation(SelectedCentreCode, Convert.ToInt32(SelectedUniversityID), CurrentSessionID, out TotalRecords);
            }
            else
            {
                filteredOrganisationSessionCryrAllocation = new List<OrganisationSessionCryrAllocationViewModel>();
                TotalRecords = 0;
            }
            
            var records = filteredOrganisationSessionCryrAllocation.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.CourseYearCode.ToString() + "( " + c.SemesterName.ToString() + " )", c.BranchDescription.ToString(), c.StatusFlag.ToString(), Convert.ToString(c.OrgSemesterMstID.ToString() + "~" + c.SemesterType.ToString() + "~" + c.CourseYearSemesterID), Convert.ToString(c.OrgSessionCourseYearAllocationID), Convert.ToString(c.OrgSessionCryrAllotStatus) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }

}
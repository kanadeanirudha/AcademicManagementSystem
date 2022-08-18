using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class CRMCallMasterAndDetailsController : BaseController
    {
        ICRMCallMasterAndDetailsServiceAccess _CRMCallMasterAndDetailsServiceAccess = null;
        ICRMJobCreationMasterAndAllocationServiceAccess _CRMJobCreationMasterAndAllocationServiceAccess = null;
        IStudentSelfRegistrationServiceAccess _StudentSelfRegistrationServiceAccess = null;
        IOrganisationUniversityMasterServiceAccess _organisationUniversityMasterServiceAccess = null;
        IOrganisationStandardMasterServiceAccess _organisationStandardMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMCallMasterAndDetailsController()
        {
            _CRMCallMasterAndDetailsServiceAccess = new CRMCallMasterAndDetailsServiceAccess();
            _CRMJobCreationMasterAndAllocationServiceAccess = new CRMJobCreationMasterAndAllocationServiceAccess();
            _StudentSelfRegistrationServiceAccess = new StudentSelfRegistrationServiceAccess();
            _organisationUniversityMasterServiceAccess = new OrganisationUniversityMasterServiceAccess();
            _organisationStandardMasterServiceAccess = new OrganisationStandardMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string jobID, string callerJobStatus, string actionMode)
        {
            try
            {

                CRMCallMasterAndDetailsViewModel _CRMCallMasterAndDetailsViewModel = new CRMCallMasterAndDetailsViewModel();
                _CRMCallMasterAndDetailsViewModel.SelectedJobID = jobID;
                _CRMCallMasterAndDetailsViewModel.SelectedCallerJobStatus = callerJobStatus;
                // for Caller
                List<CRMJobCreationMasterAndAllocation> CRMJobCreationMasterAndAllocationList = GetListCRMJobCreationMasterAndAllocation(Convert.ToInt32(Session["PersonId"]));
                List<SelectListItem> CRMJobCreationMasterAndAllocation = new List<SelectListItem>();
                foreach (CRMJobCreationMasterAndAllocation item in CRMJobCreationMasterAndAllocationList)
                {
                    CRMJobCreationMasterAndAllocation.Add(new SelectListItem { Text = item.JobName, Value = item.JobCreationMasterID.ToString() });
                }
                ViewBag.CRMJobCreationMasterAndAllocation = new SelectList(CRMJobCreationMasterAndAllocation, "Value", "Text");

                // for CallerJobStatus
                List<SelectListItem> CallerJobStatus = new List<SelectListItem>();
                ViewBag.CallerJobStatus = new SelectList(CallerJobStatus, "Value", "Text");
                List<SelectListItem> li_CallerJobStatus = new List<SelectListItem>();
                li_CallerJobStatus.Add(new SelectListItem { Text = "All", Value = "0" });
                li_CallerJobStatus.Add(new SelectListItem { Text = "Pending", Value = "3" });
                li_CallerJobStatus.Add(new SelectListItem { Text = "Completed", Value = "1" });
                li_CallerJobStatus.Add(new SelectListItem { Text = "In Progress", Value = "2" });
                //   li_CallerJobStatus.Add(new SelectListItem { Text = "Forward", Value = "4" });
                ViewData["CallerJobStatus"] = li_CallerJobStatus;
                // ViewData["CallerJobStatus"] = new SelectList(li_CallerJobStatus, _CRMCallMasterAndDetailsViewModel.JobStatus);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                if (TempData["_errorMsg"] != null)
                {
                    _CRMCallMasterAndDetailsViewModel.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    _CRMCallMasterAndDetailsViewModel.errorMessage = "NoMessage";
                }
                return View("/Views/CRM/CRMCallMasterAndDetails/Index.cshtml", _CRMCallMasterAndDetailsViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                CRMCallMasterAndDetailsViewModel _CRMCallMasterAndDetailsViewModel = new CRMCallMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRM/CRMCallMasterAndDetails/List.cshtml", _CRMCallMasterAndDetailsViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult CreateNewAdmission(string MenuLink, string JobAllocationID, string jobID, string callerJobStatus)
        {


            CRMCallMasterAndDetailsViewModel _CRMCallMasterAndDetailsViewModel = new CRMCallMasterAndDetailsViewModel();

            _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO = new CRMCallMasterAndDetails();

            _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.JobID = Convert.ToInt32(jobID);
            _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.SelectedJobCallerStatus = Convert.ToInt16(callerJobStatus);
            _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.JobAllocationID = Convert.ToInt64(JobAllocationID);
            _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<CRMCallMasterAndDetails> response = _CRMCallMasterAndDetailsServiceAccess.SelectByJobAllocationID(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO);
            if (response != null && response.Entity != null)
            {
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.JobAllocationID = response.Entity.JobAllocationID;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeTitle = response.Entity.CalleeTitle;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeFirstName = response.Entity.CalleeFirstName;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeMiddelName = response.Entity.CalleeMiddelName;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeLastName = response.Entity.CalleeLastName;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeMobileNo = response.Entity.CalleeMobileNo;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeEmailID = response.Entity.CalleeEmailID;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.Source = response.Entity.Source;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeLocation = response.Entity.CalleeLocation;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeDesignation = response.Entity.CalleeDesignation;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeDepartment = response.Entity.CalleeDepartment;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeOccupation = response.Entity.CalleeOccupation;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeExperience = response.Entity.CalleeExperience;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeInterestedProgram = response.Entity.CalleeInterestedProgram;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeQualification = response.Entity.CalleeQualification;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.EnglishFluency = response.Entity.EnglishFluency;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeNationalityID = response.Entity.CalleeNationalityID;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.UniversityID = response.Entity.UniversityID;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.BranchDetailID = response.Entity.BranchDetailID;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.StandardNumber = response.Entity.StandardNumber;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.AdmissionPattern = response.Entity.AdmissionPattern;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeInterestedProgram = response.Entity.CalleeInterestedProgram;
                _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CenterCode = response.Entity.CenterCode;
            }

            //For Name Title
            List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
            List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
            foreach (GeneralTitleMaster item in GeneralTitleMasterList)
            {
                ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
            }
            ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");

            //For Nationality

            List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
            List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
            foreach (GeneralNationalityMaster item in generalNationalityMasterList)
            {
                generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");

            // for CalleeQualification
            List<SelectListItem> CalleeQualification = new List<SelectListItem>();
            ViewBag.CalleeQualification = new SelectList(CalleeQualification, "Value", "Text");
            List<SelectListItem> li_CalleeQualification = new List<SelectListItem>();
            li_CalleeQualification.Add(new SelectListItem { Text = "--Select Qualification--", Value = "" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Unqualified", Value = "0" });
            li_CalleeQualification.Add(new SelectListItem { Text = "HSc", Value = "1" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Diploma", Value = "2" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Bachelor", Value = "3" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Master", Value = "4" });
            li_CalleeQualification.Add(new SelectListItem { Text = "PhD", Value = "5" });
            ViewData["CalleeQualification"] = li_CalleeQualification;

            if (_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeQualification != null)
            {
                ViewData["CalleeQualification"] = new SelectList(li_CalleeQualification, "Value", "Text", (_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CalleeQualification).ToString().Trim());
            }

            // for EnglishFluency
            List<SelectListItem> EnglishFluency = new List<SelectListItem>();
            ViewBag.EnglishFluency = new SelectList(EnglishFluency, "Value", "Text");
            List<SelectListItem> li_EnglishFluency = new List<SelectListItem>();
            li_EnglishFluency.Add(new SelectListItem { Text = "Fluent", Value = "0" });
            li_EnglishFluency.Add(new SelectListItem { Text = "Good", Value = "1" });
            li_EnglishFluency.Add(new SelectListItem { Text = "Not", Value = "2" });
            ViewData["EnglishFluency"] = li_EnglishFluency;

            if (_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.EnglishFluency != null)
            {
                ViewData["EnglishFluency"] = new SelectList(li_EnglishFluency, "Value", "Text", (_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.EnglishFluency).ToString().Trim());
            }

            // for Interestlevel
            List<SelectListItem> Interestlevel = new List<SelectListItem>();
            ViewBag.Interestlevel = new SelectList(Interestlevel, "Value", "Text");
            List<SelectListItem> li_Interestlevel = new List<SelectListItem>();
            li_Interestlevel.Add(new SelectListItem { Text = "--Select Interest Level--", Value = "0" });
            li_Interestlevel.Add(new SelectListItem { Text = "Cold", Value = "1" });
            li_Interestlevel.Add(new SelectListItem { Text = "Neutral", Value = "2" });
            li_Interestlevel.Add(new SelectListItem { Text = "Warm", Value = "3" });
            li_Interestlevel.Add(new SelectListItem { Text = "Not interested", Value = "4" });
            ViewData["Interestlevel"] = li_Interestlevel;


            // for ConcernArea
            List<SelectListItem> ConcernArea = new List<SelectListItem>();
            ViewBag.ConcernArea = new SelectList(ConcernArea, "Value", "Text");
            List<SelectListItem> li_ConcernArea = new List<SelectListItem>();
            li_ConcernArea.Add(new SelectListItem { Text = "NONE", Value = "7" });
            li_ConcernArea.Add(new SelectListItem { Text = "Financial", Value = "1" });
            li_ConcernArea.Add(new SelectListItem { Text = "Accreditation", Value = "2" });
            li_ConcernArea.Add(new SelectListItem { Text = "Recognition", Value = "3" });
            li_ConcernArea.Add(new SelectListItem { Text = "Time", Value = "4" });
            li_ConcernArea.Add(new SelectListItem { Text = "Location", Value = "5" });
            li_ConcernArea.Add(new SelectListItem { Text = "Other", Value = "6" });
            ViewData["ConcernArea"] = li_ConcernArea;

            // for CallerJobStatus
            List<SelectListItem> CallerJobStatus = new List<SelectListItem>();
            ViewBag.CallerJobStatus = new SelectList(CallerJobStatus, "Value", "Text");
            List<SelectListItem> li_CallerJobStatus = new List<SelectListItem>();
            li_CallerJobStatus.Add(new SelectListItem { Text = "--Select Call Job Status--", Value = "0" });
            //  li_CallerJobStatus.Add(new SelectListItem { Text = "Pending", Value = "3" });
            li_CallerJobStatus.Add(new SelectListItem { Text = "Completed", Value = "1" });
            li_CallerJobStatus.Add(new SelectListItem { Text = "In Progress", Value = "2" });
            //  li_CallerJobStatus.Add(new SelectListItem { Text = "Forward", Value = "4" });
            ViewData["CallerJobStatus"] = li_CallerJobStatus;

            //// for CallStatus
            //List<SelectListItem> CallStatus = new List<SelectListItem>();
            //ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            //List<SelectListItem> li_CallStatus = new List<SelectListItem>();
            //li_CallStatus.Add(new SelectListItem { Text = "Faliled", Value = "3" });
            //li_CallStatus.Add(new SelectListItem { Text = "Callback", Value = "2" });
            //li_CallStatus.Add(new SelectListItem { Text = "Convert", Value = "1" });
            //ViewData["CallStatus"] = li_CallStatus;

            //For study Center
            _CRMCallMasterAndDetailsViewModel.ListOrgStudyCentreMaster = GetListOrgStudyCentreMaster();
            List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
            foreach (OrganisationStudyCentreMaster item in _CRMCallMasterAndDetailsViewModel.ListOrgStudyCentreMaster)
            {
                OrganisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName.ToString(), Value = item.CentreCode.ToString() });
            }
            ViewBag.StudyCentreList = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");

            ////for University
            //List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
            //ViewBag.UniversityList = new SelectList(OrganisationUniversityMaster, "Value", "Text");

            //for University
            if (!string.IsNullOrEmpty(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CenterCode))
            {
                _CRMCallMasterAndDetailsViewModel.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CenterCode);
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in _CRMCallMasterAndDetailsViewModel.ListOrganisationUniversityMaster)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName.ToString(), Value = item.ID.ToString() });
                }
                ViewBag.UniversityList = new SelectList(OrganisationUniversityMaster, "Value", "Text");
            }
            else
            {
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                ViewBag.UniversityList = new SelectList(OrganisationUniversityMaster, "Value", "Text");
            }
        


            ////For Baranch
            if (!string.IsNullOrEmpty(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CenterCode) && _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.UniversityID != 0)
            {
                List<ToolTemplateApplicable> organisationBranchDetailList = GetListBranchDetails(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.UniversityID, _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CenterCode);
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                foreach (ToolTemplateApplicable item in organisationBranchDetailList)
                {
                    organisationBranchDetail.Add(new SelectListItem { Text = item.BranchDescription, Value = item.BranchDetailID.ToString() });
                }
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");
            }
            else
            {
                List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
                ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");
            }


            // List for Standard
            List<OrganisationStandardMaster> organisationStandardMasterList = GetListOrganisationStandardMaster();
            List<SelectListItem> organisationStandardMaster = new List<SelectListItem>();
            foreach (OrganisationStandardMaster item in organisationStandardMasterList)
            {
                organisationStandardMaster.Add(new SelectListItem { Text = item.Description, Value = item.StandardNumber.ToString() });
            }
            ViewBag.OrganisationStandardMaster = new SelectList(organisationStandardMaster, "Value", "Text");

            // for Admission Pattern

            List<SelectListItem> AdmissionPattern = new List<SelectListItem>();
            ViewBag.AdmissionPattern = new SelectList(AdmissionPattern, "Value", "Text");
            List<SelectListItem> li_AdmissionPattern = new List<SelectListItem>();
            li_AdmissionPattern.Add(new SelectListItem { Text = "New", Value = "1" });
            li_AdmissionPattern.Add(new SelectListItem { Text = "Tranfary", Value = "2" });
            li_AdmissionPattern.Add(new SelectListItem { Text = "Direct", Value = "3" });
            ViewData["AdmissionPattern"] = li_AdmissionPattern;

            _CRMCallMasterAndDetailsViewModel.ListGeneralTimeSlot = GetListGeneralTimeSlot();
            return PartialView("/Views/CRM/CRMCallMasterAndDetails/CreateNewAdmission.cshtml", _CRMCallMasterAndDetailsViewModel);

        }

        [HttpPost]
        public ActionResult CreateNewAdmission(CRMCallMasterAndDetailsViewModel _CRMCallMasterAndDetailsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_CRMCallMasterAndDetailsViewModel != null && _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO != null)
                    {
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ConnectionString = _connectioString;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CallerJobStatus = _CRMCallMasterAndDetailsViewModel.CallerJobStatus;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CallStatus = _CRMCallMasterAndDetailsViewModel.CallStatus;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CallerRemark = _CRMCallMasterAndDetailsViewModel.CallerRemark;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.NextCallDate = _CRMCallMasterAndDetailsViewModel.NextCallDate;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ConcernArea = _CRMCallMasterAndDetailsViewModel.ConcernArea;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.Interestlevel = _CRMCallMasterAndDetailsViewModel.Interestlevel;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.OtherConcernArea = _CRMCallMasterAndDetailsViewModel.OtherConcernArea;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CallTimeID = _CRMCallMasterAndDetailsViewModel.CallTimeID;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CallAnswerXML = _CRMCallMasterAndDetailsViewModel.CallAnswerXML;
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CRMCallMasterAndDetails> response = _CRMCallMasterAndDetailsServiceAccess.InsertCRMCallMasterAndDetails(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO);
                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                        _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ErrorMessage = _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ErrorMessage + ',' + _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.JobID + ',' + _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.SelectedJobCallerStatus;


                        if (response.Entity != null)
                        {
                            string body = "<Html><Body><div>"
                                + "<div><span>Hello " + _CRMCallMasterAndDetailsViewModel.CalleeFirstName + ",</span><br /><br />"
                                + "<span>We are pleased to inform you that you have been offered a program.</span><br />"
                                + "<span>After reviewing your application and all the supporting documents, we have determined that you are exactly the kind of student that we are looking for to carry on the organisation.</span><br />"
                                + "<span>Your self registration link is:</span><br />"
                                + "<span><b>Link :  " + System.Configuration.ConfigurationManager.AppSettings["ClientURL"] + "/StudentLogin" + "</b></span><br />"
                                + "<span> Once again, congratulations. We hope to hear from you soon!</span><br />"
                                + "</div>"
                                + "</div></Body></Html>";
                            //  bool aaaa = SendEmail(_CRMCallMasterAndDetailsViewModel.CalleeEmailID, "Self Registration Link", body, System.Configuration.ConfigurationManager.AppSettings["SendEmailID"], System.Configuration.ConfigurationManager.AppSettings["SendPassword"]);
                        }
                    }
                    TempData["_errorMsg"] = _CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ErrorMessage;
                    return Json(_CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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


        #endregion

        // Non-Action Method
        #region Methods



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {

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

        public ActionResult GetBranchDetailByUniversityIDAndCentreCode(string SelectedUniversityId, string SelectedCentreCode)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedUniversityId, out id);
            var BranchDetails = GetListBranchDetails(Convert.ToInt32(SelectedUniversityId), SelectedCentreCode);
            var result = (from s in BranchDetails
                          select new
                          {
                              id = s.BranchDetailID,
                              name = s.BranchDescription + " (" + s.DivisionDescription + ")",
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        protected List<CRMJobCreationMasterAndAllocation> GetListCRMJobCreationMasterAndAllocation(int EmployeeID)
        {
            CRMJobCreationMasterAndAllocationSearchRequest searchRequest = new CRMJobCreationMasterAndAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.EmployeeID = EmployeeID;
            List<CRMJobCreationMasterAndAllocation> listJobDetails = new List<CRMJobCreationMasterAndAllocation>();
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollectionResponse = _CRMJobCreationMasterAndAllocationServiceAccess.GetByCRMJobListByEmployeeID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobDetails;
        }
        public IEnumerable<CRMCallMasterAndDetailsViewModel> GetCRMCallMasterAndDetails(int jobID, Int16 callerJobStatus, out int TotalRecords)
        {
            CRMCallMasterAndDetailsSearchRequest searchRequest = new CRMCallMasterAndDetailsSearchRequest();
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
                    searchRequest.JobCreationMasterID = jobID;
                    searchRequest.CallerJobStatus = callerJobStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonId"]);


                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.JobCreationMasterID = jobID;
                    searchRequest.CallerJobStatus = callerJobStatus;
                    searchRequest.EmployeeID = Convert.ToInt32(Session["PersonId"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.JobCreationMasterID = jobID;
                searchRequest.CallerJobStatus = callerJobStatus;
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonId"]);
            }

            List<CRMCallMasterAndDetailsViewModel> listCRMCallMasterAndDetailsViewModel = new List<CRMCallMasterAndDetailsViewModel>();
            List<CRMCallMasterAndDetails> listCRMCallMasterAndDetails = new List<CRMCallMasterAndDetails>();
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollectionResponse = _CRMCallMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMCallMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMCallMasterAndDetails item in listCRMCallMasterAndDetails)
                    {
                        CRMCallMasterAndDetailsViewModel CRMCallMasterAndDetailsViewModel = new CRMCallMasterAndDetailsViewModel();
                        CRMCallMasterAndDetailsViewModel.CRMCallMasterAndDetailsDTO = item;
                        listCRMCallMasterAndDetailsViewModel.Add(CRMCallMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listCRMCallMasterAndDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string jobID, string callerJobStatus, JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMCallMasterAndDetailsViewModel> filteredCRMCallMasterAndDetails;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CalleeFirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CalleeFirstName Like '%" + param.sSearch + "%' or CalleeLastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "CalleeMobileNo";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CalleeFirstName Like '%" + param.sSearch + "%' or CalleeLastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "NextCallDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CalleeFirstName Like '%" + param.sSearch + "%' or CalleeLastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break; 
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(jobID) && !string.IsNullOrEmpty(callerJobStatus))
                {
                    filteredCRMCallMasterAndDetails = GetCRMCallMasterAndDetails(Convert.ToInt32(jobID), Convert.ToInt16(callerJobStatus), out TotalRecords);
                }
                else
                {
                    filteredCRMCallMasterAndDetails = new List<CRMCallMasterAndDetailsViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCRMCallMasterAndDetails.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CalleeFirstName.ToString() + " " + c.CalleeMiddelName.ToString() + " " + c.CalleeLastName.ToString(), c.CalleeMobileNo.ToString(), c.CalleeEmailID.ToString(), Convert.ToString(c.CallerJobStatus), Convert.ToString(c.JobAllocationID), c.MenuLink.ToString(), Convert.ToString(c.NextCallDate), Convert.ToString(c.TimeSlot), Convert.ToString(c.CallStatus) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}
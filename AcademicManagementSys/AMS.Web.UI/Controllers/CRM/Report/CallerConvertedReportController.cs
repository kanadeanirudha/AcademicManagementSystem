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
using System.Data;
using System.Data.SqlClient;
namespace AMS.Web.UI.Controllers
{
    public class CallerConvertedReportController : BaseController
    {
        ICRMCallMasterAndDetailsServiceAccess _CRMCallMasterAndDetailsServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CallerConvertedReportController()
        {
            _CRMCallMasterAndDetailsServiceAccess = new CRMCallMasterAndDetailsServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/CRM/CallerConvertedReport/Index.cshtml");
        }
        public ActionResult CallerConvertedTable(string FromDate, string UptoDate)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
            if (FromDate != null && UptoDate != null)
            {
                model.ListCRMCalleeCallDetails = CRMCallerCallDetailsList(FromDate, UptoDate,0,0,0);
            }
            else
            {
                model.ListCRMCalleeCallDetails = null;
            }
            return PartialView("/Views/CRM/CallerConvertedReport/CallerConvertedTable.cshtml", model);
        }
        public ActionResult CallerJobStatusEmployeewiseTable(string FromDate, string UptoDate, string employeeID, Int16 callerJobStatus, string callerName, Int16 callStatus)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
            model.CallerFullName = callerName;
            if (FromDate != null && UptoDate != null)
            {
                model.ListCRMCalleeCallDetails = CRMCallerCallDetailsList(FromDate, UptoDate, Convert.ToInt32(employeeID), callerJobStatus, callStatus);
            }
            else
            {
                model.ListCRMCalleeCallDetails = null;
            }
            return PartialView("/Views/CRM/CallerConvertedReport/CallerCallDetails.cshtml", model);
        }
        public ActionResult CallerConvertedPieChart(string FromDate, string UptoDate)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
            return PartialView("/Views/CRM/CallerConvertedReport/CallerConvertedPieChart.cshtml", model);
        }

        public ActionResult CallerConvertedBarChart(string FromDate, string UptoDate)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
            return PartialView("/Views/CRM/CallerConvertedReport/CallerConvertedBarChart.cshtml", model);
        }
        public ActionResult NewAdmission(int CallMasterID)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
           
            //For Name Title
            List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
            List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
            foreach (GeneralTitleMaster item in GeneralTitleMasterList)
            {
                ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
            }
            ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");
            //Code for Name Title Ends
            //For Nationality

            List<GeneralNationalityMaster> generalNationalityMasterList = GetListGeneralNationalityMaster();
            List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
            foreach (GeneralNationalityMaster item in generalNationalityMasterList)
            {
                generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");
            //For Nationality
            // for CalleeQualification
            List<SelectListItem> CalleeQualification = new List<SelectListItem>();
            ViewBag.CalleeQualification = new SelectList(CalleeQualification, "Value", "Text");
            List<SelectListItem> li_CalleeQualification = new List<SelectListItem>();
            li_CalleeQualification.Add(new SelectListItem { Text = "Unqualified", Value = "0" });
            li_CalleeQualification.Add(new SelectListItem { Text = "HSc", Value = "1" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Diploma", Value = "2" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Bachelor", Value = "3" });
            li_CalleeQualification.Add(new SelectListItem { Text = "Master", Value = "4" });
            li_CalleeQualification.Add(new SelectListItem { Text = "PhD", Value = "5" });
            ViewData["CalleeQualification"] = li_CalleeQualification;

            // for EnglishFluency
            List<SelectListItem> EnglishFluency = new List<SelectListItem>();
            ViewBag.EnglishFluency = new SelectList(EnglishFluency, "Value", "Text");
            List<SelectListItem> li_EnglishFluency = new List<SelectListItem>();
            li_EnglishFluency.Add(new SelectListItem { Text = "Fluent", Value = "0" });
            li_EnglishFluency.Add(new SelectListItem { Text = "Good", Value = "1" });
            li_EnglishFluency.Add(new SelectListItem { Text = "Not", Value = "2" });
            ViewData["EnglishFluency"] = li_EnglishFluency;

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

            //For study Center
            model.ListOrgStudyCentreMaster = GetListOrgStudyCentreMaster();
            List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
            foreach (OrganisationStudyCentreMaster item in model.ListOrgStudyCentreMaster)
            {
                OrganisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName.ToString(), Value = item.CentreCode.ToString() });
            }
            ViewBag.StudyCentreList = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");

            //for University
            List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
            ViewBag.UniversityList = new SelectList(OrganisationUniversityMaster, "Value", "Text");


            //For Baranch
            List<SelectListItem> organisationBranchDetail = new List<SelectListItem>();
            ViewBag.organisationBranchDetail = new SelectList(organisationBranchDetail, "Value", "Text");

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
         //   ViewData["AdmissionPattern"] = li_AdmissionPattern;

            // for CallStatus
            List<SelectListItem> CallStatus = new List<SelectListItem>();
            ViewBag.CallStatus = new SelectList(CallStatus, "Value", "Text");
            List<SelectListItem> li_CallStatus = new List<SelectListItem>();
            li_CallStatus.Add(new SelectListItem { Text = "Failed", Value = "3" });
            li_CallStatus.Add(new SelectListItem { Text = "Callback", Value = "2" });
            li_CallStatus.Add(new SelectListItem { Text = "Convert", Value = "1" });
         //   ViewData["CallStatus"] = li_CallStatus;

            model.ListGeneralTimeSlot = GetListGeneralTimeSlot();
            model.CRMCallMasterAndDetailsDTO.CallMasterID = CallMasterID;

            model.CRMCallMasterAndDetailsDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<CRMCallMasterAndDetails> response = _CRMCallMasterAndDetailsServiceAccess.GetStudentStatusDetailsByCalleeMasterID(model.CRMCallMasterAndDetailsDTO);
            if (response != null && response.Entity != null)
            {
                model.CRMCallMasterAndDetailsDTO.ID = response.Entity.ID;
                model.CRMCallMasterAndDetailsDTO.CalleeTitle =          response.Entity.CalleeTitle;
                model.CRMCallMasterAndDetailsDTO.CalleeFirstName =      response.Entity.CalleeFirstName;
                model.CRMCallMasterAndDetailsDTO.CalleeMiddelName =     response.Entity.CalleeMiddelName;
                model.CRMCallMasterAndDetailsDTO.CalleeLastName =       response.Entity.CalleeLastName;
                model.CRMCallMasterAndDetailsDTO.CalleeMobileNo =       response.Entity.CalleeMobileNo;
                model.CRMCallMasterAndDetailsDTO.CalleeEmailID =        response.Entity.CalleeEmailID;
                model.CRMCallMasterAndDetailsDTO.CalleeGender =         response.Entity.CalleeGender;
                model.CRMCallMasterAndDetailsDTO.Source =               response.Entity.Source;
                model.CRMCallMasterAndDetailsDTO.CalleeLocation =       response.Entity.CalleeLocation;
                model.CRMCallMasterAndDetailsDTO.CalleeLocationID =     response.Entity.CalleeLocationID;
                model.CRMCallMasterAndDetailsDTO.CalleeNationality =    response.Entity.CalleeNationality;
                model.CRMCallMasterAndDetailsDTO.CalleeNationalityID =  response.Entity.CalleeNationalityID;
                model.CRMCallMasterAndDetailsDTO.CalleeOccupation =     response.Entity.CalleeOccupation;
                model.CRMCallMasterAndDetailsDTO.CalleeDesignation =    response.Entity.CalleeDesignation;
                model.CRMCallMasterAndDetailsDTO.CalleeDepartment =     response.Entity.CalleeDepartment;
                model.CRMCallMasterAndDetailsDTO.CalleeExperience =     response.Entity.CalleeExperience;
                model.CRMCallMasterAndDetailsDTO.CalleeQualification =  response.Entity.CalleeQualification;
                model.CRMCallMasterAndDetailsDTO.CenterCode =           response.Entity.CenterCode;
                model.CRMCallMasterAndDetailsDTO.StandardNumber =       response.Entity.StandardNumber;
                model.CRMCallMasterAndDetailsDTO.CallerRemark =         response.Entity.CallerRemark;
                model.CRMCallMasterAndDetailsDTO.Interestlevel =        response.Entity.Interestlevel;
                model.CRMCallMasterAndDetailsDTO.UniversityName =       response.Entity.UniversityName;
                model.CRMCallMasterAndDetailsDTO.BranchShortCode =      response.Entity.BranchShortCode;
                model.CRMCallMasterAndDetailsDTO.BranchDescription =    response.Entity.BranchDescription;
                model.CRMCallMasterAndDetailsDTO.AdmissionPattern =     response.Entity.AdmissionPattern;
                model.CRMCallMasterAndDetailsDTO.CallerJobStatus =      response.Entity.CallerJobStatus;
                model.CRMCallMasterAndDetailsDTO.CallStatus =           response.Entity.CallStatus;
                model.CRMCallMasterAndDetailsDTO.EnglishFluency =       response.Entity.EnglishFluency;
                model.CRMCallMasterAndDetailsDTO.CalleeInterestedProgram = response.Entity.CalleeInterestedProgram;
                model.CRMCallMasterAndDetailsDTO.ConcernArea =          response.Entity.ConcernArea;
                model.CRMCallMasterAndDetailsDTO.OtherConcernArea = response.Entity.OtherConcernArea;
                model.CRMCallMasterAndDetailsDTO.NextCallDate =         response.Entity.NextCallDate;
                model.CRMCallMasterAndDetailsDTO.CallTimeID =           response.Entity.CallTimeID;
                model.CRMCallMasterAndDetailsDTO.CreatedBy =            response.Entity.CreatedBy;
            }
           

            ViewData["AdmissionPattern"] = new SelectList(li_AdmissionPattern, "Value", "Text", (model.AdmissionPattern).ToString().Trim());
            ViewData["Interestlevel"] = new SelectList(li_Interestlevel, "Value", "Text", (model.Interestlevel).ToString().Trim());
            ViewData["CallerJobStatus"] = new SelectList(li_CallerJobStatus, "Value", "Text", (model.CallerJobStatus).ToString().Trim());
            ViewData["ConcernArea"] = new SelectList(li_ConcernArea, "Value", "Text", (model.ConcernArea).ToString().Trim());
            ViewData["CallStatus"] = new SelectList(li_CallStatus, "Value", "Text", model.CallStatus);
            ViewData["EnglishFluency"] = new SelectList(li_EnglishFluency, "Value", "Text", (model.EnglishFluency).ToString().Trim());
            ViewData["CalleeQualification"] =new SelectList(li_CalleeQualification, "Value", "Text", (model.CalleeQualification).ToString().Trim());
            ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text", (model.CalleeTitle).ToString().Trim());
            return PartialView("/Views/CRM/CallerConvertedReport/NewAdmission.cshtml", model);


        }


        [HttpGet]
        public JsonResult CallerData(string FromDate, string UptoDate)
        {

            var crmCallerCallDetails = CRMCallerCallDetailsList(FromDate, UptoDate,0,0,0);
            var result = (from s in crmCallerCallDetails
                          select new
                          {
                              callerFullName = s.CallerFullName,
                              convertedCount = s.ConvertedCount,
                              totalCallCount = s.TotalCallCount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }  
        #endregion

        // Non-Action Method
        #region Methods


        protected List<CRMCallMasterAndDetails> CRMCallerCallDetailsList(string fromDate, string uptoDate, int employeeID, Int16 callerJobStatus, Int16 callStatus)
        {
            CRMCallMasterAndDetailsSearchRequest searchRequest = new CRMCallMasterAndDetailsSearchRequest();
            searchRequest.FromDate = fromDate;
            searchRequest.UptoDate = uptoDate;
            searchRequest.EmployeeID = employeeID;
            searchRequest.CallerJobStatus = callerJobStatus;
            searchRequest.CallStatus = callStatus;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMCallMasterAndDetails> CRMCallerCallDetailsList = new List<CRMCallMasterAndDetails>();

            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollectionResponse = _CRMCallMasterAndDetailsServiceAccess.CallerConvertedReportForTable(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallerCallDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallerCallDetailsList;
        }


        #endregion

    }
}
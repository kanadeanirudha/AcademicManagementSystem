using AMS.DTO.Enum;
using AMS.DTO;
using AMS.Common;
using AMS.Base.DTO;
using AMS.ServiceAccess;
using System.Threading;
using AMS.ViewModel;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Web.UI;
using AMS.Web.UI.HtmlHelperExtensions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Net;
using System.Net.Mail;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
namespace AMS.Web.UI.Controllers
{
    [Authorize]
    //[SessionExpire]
    public class BaseController : Controller
    {
        IGeneralQuestionTypeMasterServiceAccess _generalQuestionTypeMasterServiceAccess = null;
        IEmpEmployeeMasterServiceAccess _empEmployeeMasterServiceAccess = null;
        IStudentReportServiceAccess _StudentReportServiceAccess = null;
        IStudentSectionChangeRequestServiceAccess _studentSectionChangeRequestServiceAcess = null;
        IStudentMasterServiceAccess _studentMasterServiceAccess = null;
        IAccountSessionMasterServiceAccess _accountSessionMasterServiceAccess = null;
        IAccountMasterServiceAccess _accountMasterServiceAccess = null;
        IOrganisationCentrewiseSessionServiceAccess _organisationCentrewiseSessionServiceAccess = null;
        IGeneralCasteMasterServiceAccess _generalCasteMasterServiceAccess = null;
        IAccountTransactionTypeMasterServiceAccess _accountTransactionTypeMasterServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        IOrganisationSubjectGrpRuleServiceAccess _organisationSubjectGrpRuleServiceAccess = null;
        IGeneralSessionMasterServiceAccess _generalSessionMasterServiceAccess = null;
        IOrganisationBranchMasterServiceAccess _organisationBranchMasterServiceAccess = null;
        IGeneralLanguageMasterServiceAccess _generalLanguageMasterServiceAccess = null;
        IGeneralCategoryMasterServiceAccess _generalCategoryMasterServiceAccess = null;
        IGeneralEducationTypeMasterServiceAccess _generalEducationTypeMasterServiceAccess = null;
        IGeneralRegionMasterServiceAccess _generalRegionMasterServiceAccess = null;
        IOrganisationStreamMasterServiceAccess _organisationStreamMasterServiceAccess = null;
        IOrganisationSubjectMasterServiceAccess _organisationSubjectMasterServiceAccess = null;
        IOrganisationSubjectTypeMasterServiceAccess _organisationSubjectTypeMasterServiceAccess = null;
        IGeneralCityMasterServiceAccess _generalCityMasterServiceAccess = null;
        IOrganisationStudyCentreMasterServiceAccess _organisationStudyCentreMasterServiceAccess = null;
        IEmpDesignationMasterServiceAccess _empDesignationMasterServiceAccess = null;
        IOrganisationDivisionMasterServiceAccess _orgDivisionMasterServiceAccess = null;
        IAdminSnPostsServiceAccess _adminSnPostsServiceAccess = null;
        IAdminRoleMasterServiceAccess _adminRoleMasterServiceAccess = null;
        IGeneralCountryMasterServiceAccess _generalCountryMasterServiceAccess = null;
        IOrganisationDepartmentMasterServiceAccess _organisationDepartmentMasterServiceAccess = null;
        IGeneralLocationMasterServiceAccess _generalLocationMasterServiceAccess = null;
        IOrganisationMasterServiceAccess _organisationMasterServiceAccess = null;
        IOrganisationUniversityMasterServiceAccess _organisationUniversityMasterServiceAccess = null;
        IOrganisationStandardMasterServiceAccess _organisationStandardMasterServiceAccess = null;
        IGeneralNationalityMasterServiceAccess _generalNationalityMasterServiceAccess = null;
        IGeneralReligionMasterServiceAccess _generalReligionMasterServiceAccess = null;
        IOrganisationMediumMasterServiceAccess _organisationMediumMasterServiceAccess = null;
        IOrganisationSemesterMasterServiceAccess _organisationSemesterMasterServiceAccess = null;
        IOrganisationSectionDetailsServiceAccess _organisationSectionDetailsServiceAccess = null;
        IUserMainMenuMasterServiceAccess _userMainMenuMasterServiceAccess = null;
        IToolQualifyingExamSubjectServiceAccess _ToolQualifyingExamSubjectServiceAcess = null;
        IGeneralUnitMasterServiceAccess _generalUnitMasterServiceAccess = null;
        IToolQualificationMasterSubjectServiceAccess _ToolQualificationMasterSubjectServiceAcess = null;
        IToolTemplateApplicableServiceAccess _ToolTemplateApplicableServiceAccess = null;
        IOrganisationAdmissionTypeMasterServiceAccess _organisationAdmissionTypeMasterServiceAccess = null;
        IOrganisationAllotAdmissionMasterServiceAccess _organisationAllotAdmissionMasterServiceAccess = null;
        IOrganisationCourseYearDetailsServiceAccess _organisationCourseYearDetailsServiceAccess = null;
        OrganisationBranchDetailsServiceAccess _organisationBranchDetailsServiceAccess = null;
        IGeneralTitleMasterServiceAccess _generalTitleMasterServiceAccess = null;
        IGeneralJobProfileServiceAccess _generalJobProfileServiceAccess = null;
        IGeneralJobStatusServiceAccess _generalJobStatusServiceAccess = null;
        IEmployeeShiftMasterServiceAccess _employeeShiftMasterServiceAccess = null;
        IGeneralBoardUniversityMasterServiceAccess _generalBoardUniversityMasterServiceAccess = null;
        IStudentRegistrationAcademicApprovalServiceAccess _studentRegistrationAcademicApprovalServiceAcess = null;
        IAdminRoleApplicableDetailsServiceAccess _adminRoleApplicableDetailsServiceAccess = null;
        IGeneralLeaveDocumentServiceAccess _generalLeaveDocumentServiceAccess = null;
        ILeaveMasterServiceAccess _leaveMasterServiceAccess = null;
        ILeaveRuleMasterServiceAccess _leaveRuleMasterServiceAccess = null;
        ILeaveAttendanceSpanLockServiceAccess _leaveAttendanceSpanLockServiceAccess = null;
        IGeneralHolidaysServiceAccess _generalHolidaysServiceAccess = null;
        ILeaveSessionServiceAccess _leaveSessionServiceAccess = null;
        IOnlineExaminationMasterServiceAccess _OnlineExaminationMasterServiceAccess = null;
        IGeneralCurrencyMasterServiceAccess _generalCurrencyMasterServiceAccess = null;
        IGeneralTaxGroupMasterServiceAccess _generalTaxGroupMasterServiceAccess = null;
        IUserMasterServiceAccess _userMasterServiceAccess = null;
        IGeneralTaskModelServiceAccess _generalTaskModelServiceAccess = null;
        IFishLicenseTypeServiceAccess _fishLicenseTypeServiceAccess = null;
        IUserModuleMasterServiceAccess _userModuleMasterServiceAccess = null;
        IGeneralTaskReportingDetailsServiceAccess _generalTaskReportingDetailsServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
        ICRMCallTypeServiceAccess _CRMCallTypeServiceAcess = null;
        IGeneralTimeSlotMasterServiceAccess _generalTimeSlotMasterServiceAccess = null;
        IUserModuleMasterServiceAccess _userModuleMasterServiceAcess = null;
        IOrganisationDepartmentMasterServiceAccess _OrganisationDepartmentMasterServiceAccess = null;
        // IOnlineEntranceExamQuestionBankMasterServiceAccess _OnlineEntranceExamQuestionBankMasterServiceAccess = null;
        ICRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess = null;
        ICRMSaleTargetDetailsServiceAccess _CRMSaleTargetDetailsServiceAcess = null;
        ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess _CRMSaleEnquiryMasterAndAccountDetailsServiceAccess = null;
        IGeneralPeriodTypeMasterServiceAccess _GeneralPeriodTypeMasterServiceAccess = null;
        ICRMCallerRoleAllocationServiceAccess _CRMCallerRoleAllocationServiceAcess = null;
        ICRMSaleReportServiceAccess _CRMSaleReportServiceAccess = null;
        IOnlineExamExaminationMasterServiceAccess _OnlineExamExaminationMasterServiceAccess = null;

        private readonly RoleEnum[] _acceptedRoles;

        public BaseController()
        {
            _generalTaskModelServiceAccess = new GeneralTaskModelServiceAccess();
            _generalQuestionTypeMasterServiceAccess = new GeneralQuestionTypeMasterServiceAccess();
            _empEmployeeMasterServiceAccess = new EmpEmployeeMasterServiceAccess();
            _organisationBranchMasterServiceAccess = new OrganisationBranchMasterServiceAccess();
            _studentSectionChangeRequestServiceAcess = new StudentSectionChangeRequestServiceAccess();
            _studentMasterServiceAccess = new StudentMasterServiceAccess();
            _accountSessionMasterServiceAccess = new AccountSessionMasterServiceAccess();
            _accountMasterServiceAccess = new AccountMasterServiceAccess();
            _organisationCentrewiseSessionServiceAccess = new OrganisationCentrewiseSessionServiceAccess();
            _generalCasteMasterServiceAccess = new GeneralCasteMasterServiceAccess();
            _accountTransactionTypeMasterServiceAccess = new AccountTransactionTypeMasterServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
            _organisationSubjectGrpRuleServiceAccess = new OrganisationSubjectGrpRuleServiceAccess();
            _generalSessionMasterServiceAccess = new GeneralSessionMasterServiceAccess();
            _generalLanguageMasterServiceAccess = new GeneralLanguageMasterServiceAccess();
            _generalCategoryMasterServiceAccess = new GeneralCategoryMasterServiceAccess();
            _adminSnPostsServiceAccess = new AdminSnPostsServiceAccess();
            _adminRoleMasterServiceAccess = new AdminRoleMasterServiceAccess();
            _generalUnitMasterServiceAccess = new GeneralUnitMasterServiceAccess();
            _generalEducationTypeMasterServiceAccess = new GeneralEducationTypeMasterServiceAccess();
            _generalRegionMasterServiceAccess = new GeneralRegionMasterServiceAccess();
            _organisationStreamMasterServiceAccess = new OrganisationStreamMasterServiceAccess();
            _organisationSubjectMasterServiceAccess = new OrganisationSubjectMasterServiceAccess();
            _organisationSubjectTypeMasterServiceAccess = new OrganisationSubjectTypeMasterServiceAccess();
            _generalCityMasterServiceAccess = new GeneralCityMasterServiceAccess();
            _generalCountryMasterServiceAccess = new GeneralCountryMasterServiceAccess();
            _orgDivisionMasterServiceAccess = new OrganisationDivisionMasterServiceAccess();
            _organisationStudyCentreMasterServiceAccess = new OrganisationStudyCentreMasterServiceAccess();
            _empDesignationMasterServiceAccess = new EmpDesignationMasterServiceAccess();
            _organisationDepartmentMasterServiceAccess = new OrganisationDepartmentMasterServiceAccess();
            _generalLocationMasterServiceAccess = new GeneralLocationMasterServiceAccess();
            _organisationMasterServiceAccess = new OrganisationMasterServiceAccess();
            _organisationUniversityMasterServiceAccess = new OrganisationUniversityMasterServiceAccess();
            _organisationStandardMasterServiceAccess = new OrganisationStandardMasterServiceAccess();
            _organisationMediumMasterServiceAccess = new OrganisationMediumMasterServiceAccess();
            _organisationSemesterMasterServiceAccess = new OrganisationSemesterMasterServiceAccess();
            _organisationSectionDetailsServiceAccess = new OrganisationSectionDetailsServiceAccess();
            _generalNationalityMasterServiceAccess = new GeneralNationalityMasterServiceAccess();
            _userMainMenuMasterServiceAccess = new UserMainMenuMasterServiceAccess();
            _generalReligionMasterServiceAccess = new GeneralReligionMasterServiceAccess();
            _studentRegistrationAcademicApprovalServiceAcess = new StudentRegistrationAcademicApprovalServiceAccess();
            _ToolQualifyingExamSubjectServiceAcess = new ToolQualifyingExamSubjectServiceAccess();
            _ToolQualificationMasterSubjectServiceAcess = new ToolQualificationMasterSubjectServiceAccess();
            _ToolTemplateApplicableServiceAccess = new ToolTemplateApplicableServiceAccess();
            _organisationAdmissionTypeMasterServiceAccess = new OrganisationAdmissionTypeMasterServiceAccess();
            _organisationAllotAdmissionMasterServiceAccess = new OrganisationAllotAdmissionMasterServiceAccess();
            _organisationCourseYearDetailsServiceAccess = new OrganisationCourseYearDetailsServiceAccess();
            _organisationBranchDetailsServiceAccess = new OrganisationBranchDetailsServiceAccess();
            _generalTitleMasterServiceAccess = new GeneralTitleMasterServiceAccess();
            _generalJobProfileServiceAccess = new GeneralJobProfileServiceAccess();
            _generalJobStatusServiceAccess = new GeneralJobStatusServiceAccess();
            _employeeShiftMasterServiceAccess = new EmployeeShiftMasterServiceAccess();
            _generalBoardUniversityMasterServiceAccess = new GeneralBoardUniversityMasterServiceAccess();
            _adminRoleApplicableDetailsServiceAccess = new AdminRoleApplicableDetailsServiceAccess();
            _generalLeaveDocumentServiceAccess = new GeneralLeaveDocumentServiceAccess();
            _leaveMasterServiceAccess = new LeaveMasterServiceAccess();
            _leaveRuleMasterServiceAccess = new LeaveRuleMasterServiceAccess();
            _generalCurrencyMasterServiceAccess = new GeneralCurrencyMasterServiceAccess();
            _generalTaxGroupMasterServiceAccess = new GeneralTaxGroupMasterServiceAccess();
            _leaveAttendanceSpanLockServiceAccess = new LeaveAttendanceSpanLockServiceAccess();
            _generalHolidaysServiceAccess = new GeneralHolidaysServiceAccess();
            _userMasterServiceAccess = new UserMasterServiceAccess();
            _leaveSessionServiceAccess = new LeaveSessionServiceAccess();
            _OnlineExaminationMasterServiceAccess = new OnlineExaminationMasterServiceAccess();
            _StudentReportServiceAccess = new StudentReportServiceAccess();
            _fishLicenseTypeServiceAccess = new FishLicenseTypeServiceAccess();
            _userModuleMasterServiceAccess = new UserModuleMasterServiceAccess();
            _generalTaskReportingDetailsServiceAccess = new GeneralTaskReportingDetailsServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            _CRMCallTypeServiceAcess = new CRMCallTypeServiceAccess();
            _generalTimeSlotMasterServiceAccess = new GeneralTimeSlotMasterServiceAccess();
            _userModuleMasterServiceAcess = new UserModuleMasterServiceAccess();
            _OrganisationDepartmentMasterServiceAccess = new OrganisationDepartmentMasterServiceAccess();
            //  _OnlineEntranceExamQuestionBankMasterServiceAccess = new OnlineEntranceExamQuestionBankMasterServiceAccess();
            _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess = new CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAccess();
            _CRMSaleTargetDetailsServiceAcess = new CRMSaleTargetDetailsServiceAccess();
            _CRMSaleEnquiryMasterAndAccountDetailsServiceAccess = new CRMSaleEnquiryMasterAndAccountDetailsServiceAccess();
            _GeneralPeriodTypeMasterServiceAccess = new GeneralPeriodTypeMasterServiceAccess();
            _CRMCallerRoleAllocationServiceAcess = new CRMCallerRoleAllocationServiceAccess();
            _CRMSaleReportServiceAccess = new CRMSaleReportServiceAccess();
            _OnlineExamExaminationMasterServiceAccess = new OnlineExamExaminationMasterServiceAccess ();
        }

        public String RedirectController
        {
            get;
            set;
        }
        public String RedirectAction
        {
            get;
            set;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //UrlHelper helper = new UrlHelper(filterContext.RequestContext);
            //RedirectController = filterContext.RouteData.Values["controller"].ToString();
            //RedirectAction = filterContext.RouteData.Values["action"].ToString();
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    RedirectController = "Account";
            //    RedirectAction = "Login";
            //    filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //}
            //else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (_acceptedRoles != null)
            //    {
            //        string roleID = ((System.Web.Security.FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData.Trim();
            //        if (!String.IsNullOrEmpty(roleID) && Convert.ToInt32(roleID) > 0)
            //        {
            //            RoleEnum roleEnum = (RoleEnum)Convert.ToInt32(roleID);
            //            if (!_acceptedRoles.Contains(roleEnum))
            //            {
            //                RedirectController = "Account";
            //                RedirectAction = "UnAuthorizeAccess";
            //                filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //            }
            //        }
            //        else
            //        {
            //            RedirectController = "Account";
            //            RedirectAction = "Login";
            //            filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //        }
            //    }
            //    else
            //    {
            //        RedirectController = "Account";
            //        RedirectAction = "UnAuthorizeAccess";
            //        filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //    }
            //}
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null)
            {
                base.OnException(filterContext);
                if (filterContext.Exception == null)
                {
                    ExceptionManager.ExceptionManager exceptionManager = new ExceptionManager.ExceptionManager();
                    string controller = filterContext.RouteData.Values["controller"].ToString();
                    string action = filterContext.RouteData.Values["action"].ToString();
                    string loggerName = string.Format("{0}Controller.{1}", controller, action);
                    exceptionManager.Error(loggerName, filterContext.Exception);
                }
                else
                {
                    filterContext.Exception.Data.Add("IsViewable", true);
                    filterContext.ExceptionHandled = true;
                    HandleErrorInfo handleErrorInfo = new HandleErrorInfo(filterContext.Exception, "Error", "Index");
                    Session["Source"] = filterContext.Exception.Source;
                    Session["TargetSite"] = filterContext.Exception.TargetSite;
                    Session["ErrorInfoMessage"] = filterContext.Exception.Message;
                    Session["StackTrace"] = filterContext.Exception.StackTrace;
                    this.View("Error", handleErrorInfo).ExecuteResult(this.ControllerContext);
                }
            }
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            return base.BeginExecuteCore(callback, state);
        }

        protected string CheckErrorV2(int errorCode, ActionModeEnum actionMode)
        {

            string errorMessage = string.Empty;
            string colorCode = string.Empty;
            string mode = string.Empty;
            if (actionMode == ActionModeEnum.Insert)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists;// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.LimitExceeds:
                        errorMessage = "Cannot create record as limit exceeds!";// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordCreatedSuccessfully;// "Record created successfully";
                        colorCode = "success";
                        mode = "0";
                        break;
                    case (Int32)ErrorEnum.WorkFlowNotDefined:
                        errorMessage = Resources.Message_WorkFlowNotDefined;// "Work Flow Not Defined ";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotCreatedSuccessfully;// "Record not created successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Update)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists; ;//"Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordUpdatedSuccessfully;// "Record updated successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotUpdatedSuccessfully;// "Record not updated successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Delete)
            {
                mode = string.Empty;
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordDeletedSuccessfully;// "Record deleted successfully";
                        colorCode = "success";
                        break;
                    case (Int32)ErrorEnum.DependantEntry:
                        errorMessage = Resources.Message_RecordDependantEntry;// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotDeletedSuccessfully;// "Record not deleted successfully";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Sync)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_SyncProcessDoneSuccessfully;// "Sync process completed successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = Resources.Message_SyncProcessAborted;// "Sync process aborted due to unexpected error";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.FiredJob)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_JobFiredSuccessfully;// "Job Fired successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = Resources.Message_UnexpectedErrorOccured;// "unexpected error Occured.";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.InActive)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordInaciveDependantEntry;// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordInactiveSuccessfully;// "Record inactive successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotInactiveSuccessfully;// "Record not deleted successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            string[] arrayList = { errorMessage, colorCode, mode };
            return string.Join(",", arrayList);
        }

        protected string CheckError(int errorCode, ActionModeEnum actionMode)
        {

            string errorMessage = string.Empty;
            string colorCode = string.Empty;
            string mode = string.Empty;
            if (actionMode == ActionModeEnum.Insert)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists;// "Record already exists";
                        colorCode = "#FFCC80";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.LimitExceeds:
                        errorMessage = "Cannot create record as limit exceeds!";// "Record already exists";
                        colorCode = "#FFCC80";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordCreatedSuccessfully;// "Record created successfully";
                        colorCode = "#9FEA7A";
                        mode = "0";
                        break;
                    case (Int32)ErrorEnum.WorkFlowNotDefined:
                        errorMessage = Resources.Message_WorkFlowNotDefined;// "Work Flow Not Defined ";
                        colorCode = "#FFCC80";
                        mode = string.Empty;
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotCreatedSuccessfully;// "Record not created successfully";
                        colorCode = "#F5CCCC";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Update)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists; ;//"Record already exists";
                        colorCode = "#FFCC80";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordUpdatedSuccessfully;// "Record updated successfully";
                        colorCode = "#9FEA7A";
                        mode = "1";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotUpdatedSuccessfully;// "Record not updated successfully";
                        colorCode = "#F5CCCC";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Delete)
            {
                mode = string.Empty;
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordDeletedSuccessfully;// "Record deleted successfully";
                        colorCode = "#9FEA7A";
                        break;
                    case (Int32)ErrorEnum.DependantEntry:
                        errorMessage = Resources.Message_RecordDependantEntry;// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "#FFCC80";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotDeletedSuccessfully;// "Record not deleted successfully";
                        colorCode = "#F5CCCC";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Sync)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_SyncProcessDoneSuccessfully;// "Sync process completed successfully";
                        colorCode = "#9FEA7A";
                        break;
                    default:
                        errorMessage = Resources.Message_SyncProcessAborted;// "Sync process aborted due to unexpected error";
                        colorCode = "#F5CCCC";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.FiredJob)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_JobFiredSuccessfully;// "Job Fired successfully";
                        colorCode = "#9FEA7A";
                        break;
                    default:
                        errorMessage = Resources.Message_UnexpectedErrorOccured;// "unexpected error Occured.";
                        colorCode = "#F5CCCC";
                        break;
                }
            }
            string[] arrayList = { errorMessage, colorCode, mode };
            return string.Join(",", arrayList);
        }



        [HttpGet]
        public ActionResult ErrorMessageForJS(string keyName)
        {
            try
            {
                string message = Resources.ResourceManager.GetString(keyName);
                string errorMessageWithCode = message;
                return Json(errorMessageWithCode, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public ActionResult GeneralMessageForJS(string keyName)
        {
            try
            {
                string message = Resources.ResourceManager.GetString(keyName);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected static DateTime ConvertFromMiliSecondsToDate(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        // Encode function
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decode function
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [HttpGet]
        public int CheckSessionStatus()
        {
            int _sessionStatus;
            if (Session["UserType"] != null)
            {
                _sessionStatus = 1;
            }
            else
            {
                _sessionStatus = 0;
            }
            return _sessionStatus; //return _sessionStatus;
        }

        protected List<GeneralTaskModel> GetMenuCodeAndMenuLink(int flag)
        {
            GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StatusFlag = flag;
            List<GeneralTaskModel> list = new List<GeneralTaskModel>();
            IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _generalTaskModelServiceAccess.GetMenuCodeAndMenuLink(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    list = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return list;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList()
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> taskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalBasedTableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalBasedTableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalBasedTableList;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalParamPrimaryKeyList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        protected List<OrganisationCentrewiseSession> GetCurrentSession(string centreCode)
        {
            OrganisationCentrewiseSessionSearchRequest searchRequest = new OrganisationCentrewiseSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            var splitData = centreCode.Split(':');
            searchRequest.CentreCode = splitData[0];
            List<OrganisationCentrewiseSession> listOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> baseEntityCollectionResponse = _organisationCentrewiseSessionServiceAccess.GetCurrentSession(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCentrewiseSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCentrewiseSession;
        }

        protected List<OrganisationCentrewiseSession> GetCentreWiseSessionListRoleWise(string centreCode, int AllSession)
        {
            OrganisationCentrewiseSessionSearchRequest searchRequest = new OrganisationCentrewiseSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            searchRequest.AllSession = AllSession;
            List<OrganisationCentrewiseSession> listOrganisationCentrewiseSession = new List<OrganisationCentrewiseSession>();
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> baseEntityCollectionResponse = _organisationCentrewiseSessionServiceAccess.GetCentreWiseSessionListRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCentrewiseSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCentrewiseSession;
        }

        protected List<OrganisationStudyCentreMaster> GetListOrgStudyCentreMaster()
        {

            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterServiceAccess.GetStudyCentreList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }
        protected List<GeneralUnitMaster> GetListGeneralUnitMaster()
        {
            GeneralUnitMasterSearchRequest searchRequest = new GeneralUnitMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralUnitMaster> listGeneralUnitMaster = new List<GeneralUnitMaster>();
            IBaseEntityCollectionResponse<GeneralUnitMaster> baseEntityCollectionResponse = _generalUnitMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnitMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralUnitMaster;
        }


        public List<OrganisationStudyCentreMaster> GetCentreListRoleWise(int roleID)
        {

            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = roleID;
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterServiceAccess.GetStudyCentreListRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<EmpDesignationMaster> GetListEmpDesignationMaster()
        {
            EmpDesignationMasterSearchRequest searchRequest = new EmpDesignationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmpDesignationMaster> listEmpDesignationMaster = new List<EmpDesignationMaster>();
            IBaseEntityCollectionResponse<EmpDesignationMaster> baseEntityCollectionResponse = _empDesignationMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpDesignationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpDesignationMaster;
        }
        //searchlist Of ExaminationName
        protected List<OnlineExaminationMaster> GetExaminationNameByCourseID(string SearchKeyWord)
        {
            OnlineExaminationMasterSearchRequest searchRequest = new OnlineExaminationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.MaxResults = 10;

            List<OnlineExaminationMaster> listExamminationName = new List<OnlineExaminationMaster>();
            IBaseEntityCollectionResponse<OnlineExaminationMaster> baseEntityCollectionResponse = _OnlineExaminationMasterServiceAccess.GetExaminationNameByCourseID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamminationName = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamminationName;
        }
        //end of SearchList of ExaminationName



        protected List<OrganisationDepartmentMaster> GetListOrganisationDepartmentMaster(string CentreCode)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterServiceAccess.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<OrganisationDepartmentMaster> GetDepartmentListRoleWise(string CentreCode)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterServiceAccess.GetDepartmentListRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }
        protected List<OrganisationUniversityMaster> GetListOrganisationUniversityMaster(string CentreCode)
        {
            OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAccess.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationUniversityMaster;
        }
        protected List<OrganisationUniversityMaster> GetListOrganisationUniversityMasterWithoutCenterCode()
        {
            OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAccess.GetBySearchListWithoutCenterCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationUniversityMaster;
        }
        protected List<OrganisationSectionDetails> GetListOrgSectionDetails(int StandardNumber, int BranchDetID)
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StandardNumber = StandardNumber;
            searchRequest.BranchDetID = BranchDetID;
            //searchRequest.SearchType = 1;
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _organisationSectionDetailsServiceAccess.SelectByBranchDetID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSectionDetails;
        }

        protected List<OrganisationDepartmentMaster> GetOrganisationDepartmentList()
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<AdminSnPosts> GetListAdminSnPosts(string SelectedCentreCodeforRoleMaster, string SelectedDepartmentIDforRoleMaster)
        {
            AdminSnPostsSearchRequest searchRequest = new AdminSnPostsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = SelectedCentreCodeforRoleMaster;
            string[] splitedDepartmentID = SelectedDepartmentIDforRoleMaster.Split(':');
            searchRequest.DepartmentID = Convert.ToInt32(splitedDepartmentID[0]);

            List<AdminSnPosts> listAdminSnPosts = new List<AdminSnPosts>();
            IBaseEntityCollectionResponse<AdminSnPosts> baseEntityCollectionResponse = _adminSnPostsServiceAccess.GetBySearchCentreCodeAndDepartmentIDForSPD(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminSnPosts = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdminSnPosts;
        }

        protected List<OrganisationDivisionMaster> GetListOrganisationDivisionMaster()
        {
            OrganisationDivisionMasterSearchRequest searchRequest = new OrganisationDivisionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationDivisionMaster> listOrganisationDivisionMaster = new List<OrganisationDivisionMaster>();
            IBaseEntityCollectionResponse<OrganisationDivisionMaster> baseEntityCollectionResponse = _orgDivisionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDivisionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDivisionMaster;
        }

        protected List<GeneralCountryMaster> GetListGeneralCountryMaster()
        {
            GeneralCountryMasterSearchRequest searchRequest = new GeneralCountryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralCountryMaster> listGeneralCountryMaster = new List<GeneralCountryMaster>();
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollectionResponse = _generalCountryMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCountryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCountryMaster;
        }


        protected List<GeneralCasteMaster> GetListGeneralCasteMaster(int SelectedCategoryID)
        {
            GeneralCasteMasterSearchRequest searchRequest = new GeneralCasteMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //int SelectedCategoryID = 0;
            searchRequest.CategoryID = Convert.ToString(SelectedCategoryID);
            List<GeneralCasteMaster> listGeneralCasteMaster = new List<GeneralCasteMaster>();
            IBaseEntityCollectionResponse<GeneralCasteMaster> baseEntityCollectionResponse = _generalCasteMasterServiceAccess.GetGeneralCasteMasterGetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCasteMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCasteMaster;
        }


        protected List<GeneralRegionMaster> GetListGeneralRegionMaster(string SelectedCountryID)
        {
            GeneralRegionMasterSearchRequest searchRequest = new GeneralRegionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CountryID = !string.IsNullOrEmpty(SelectedCountryID) ? Convert.ToInt32(SelectedCountryID) : 0;
            List<GeneralRegionMaster> listGeneralRegionMaster = new List<GeneralRegionMaster>();
            IBaseEntityCollectionResponse<GeneralRegionMaster> baseEntityCollectionResponse = _generalRegionMasterServiceAccess.GetByCountryID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRegionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralRegionMaster;
        }

        protected List<OrganisationStreamMaster> GetListOrganisationStreamMaster()
        {
            OrganisationStreamMasterSearchRequest searchRequest = new OrganisationStreamMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //int SelectedCountryID = 0;
            //bool isValid = Int32.TryParse(CountryID, out SelectedCountryID);
            //searchRequest.CountryID = SelectedCountryID;
            //searchRequest.SearchType = 1;
            List<OrganisationStreamMaster> listOrganisationStreamMaster = new List<OrganisationStreamMaster>();
            IBaseEntityCollectionResponse<OrganisationStreamMaster> baseEntityCollectionResponse = _organisationStreamMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStreamMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStreamMaster;
        }

        protected List<GeneralCityMaster> GetListGeneralCityMaster(string RegionID)
        {
            GeneralCityMasterSearchRequest searchRequest = new GeneralCityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            int SelectedRegionID = 0;
            bool isValid = Int32.TryParse(RegionID, out SelectedRegionID);
            searchRequest.RegionID = SelectedRegionID;
            //searchRequest.SearchType = 1;
            List<GeneralCityMaster> listGeneralCityMaster = new List<GeneralCityMaster>();
            IBaseEntityCollectionResponse<GeneralCityMaster> baseEntityCollectionResponse = _generalCityMasterServiceAccess.GetByRegionID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCityMaster;
        }


        protected List<GeneralEducationTypeMaster> GetListGeneralEducationTypeMaster()
        {
            GeneralEducationTypeMasterSearchRequest searchRequest = new GeneralEducationTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralEducationTypeMaster> listGeneralEducationTypeMaster = new List<GeneralEducationTypeMaster>();
            IBaseEntityCollectionResponse<GeneralEducationTypeMaster> baseEntityCollectionResponse = _generalEducationTypeMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralEducationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralEducationTypeMaster;
        }


        protected List<GeneralCategoryMaster> GetListGeneralCategoryMaster()
        {
            GeneralCategoryMasterSearchRequest searchRequest = new GeneralCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCategoryMaster> listGeneralCategoryMaster = new List<GeneralCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralCategoryMaster> baseEntityCollectionResponse = _generalCategoryMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCategoryMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.CategoryName).ToList();
                }
            }
            return listGeneralCategoryMaster;
        }

        protected List<GeneralLocationMaster> GetListGeneralLocationMaster()
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralLocationMaster> listGeneralLocationMaster = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLocationMaster;
        }


        protected List<OrganisationMaster> GetListOrganisationMaster()
        {
            OrganisationMasterSearchRequest searchRequest = new OrganisationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationMaster> listOrganisationMaster = new List<OrganisationMaster>();
            IBaseEntityCollectionResponse<OrganisationMaster> baseEntityCollectionResponse = _organisationMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationMaster;
        }

        protected List<OrganisationUniversityMaster> GetListOrganisationUniversityMaster()
        {
            OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAccess.GetBySearchListWithoutCenterCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationUniversityMaster;
        }

        protected List<OrganisationStandardMaster> GetListOrganisationStandardMaster()
        {
            OrganisationStandardMasterSearchRequest searchRequest = new OrganisationStandardMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationStandardMaster> listOrganisationStandardMaster = new List<OrganisationStandardMaster>();
            IBaseEntityCollectionResponse<OrganisationStandardMaster> baseEntityCollectionResponse = _organisationStandardMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStandardMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStandardMaster;
        }
        protected List<GeneralNationalityMaster> GetListGeneralNationalityMaster()
        {
            GeneralNationalityMasterSearchRequest searchRequest = new GeneralNationalityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralNationalityMaster> listGeneralNationalityMaster = new List<GeneralNationalityMaster>();
            IBaseEntityCollectionResponse<GeneralNationalityMaster> baseEntityCollectionResponse = _generalNationalityMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralNationalityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralNationalityMaster;
        }
        protected List<OrganisationMediumMaster> GetListOrganisationMediumMaster()
        {
            OrganisationMediumMasterSearchRequest searchRequest = new OrganisationMediumMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationMediumMaster> listOrganisationMediumMaster = new List<OrganisationMediumMaster>();
            IBaseEntityCollectionResponse<OrganisationMediumMaster> baseEntityCollectionResponse = _organisationMediumMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMediumMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationMediumMaster;
        }

        protected List<OrganisationSemesterMaster> GetListOrganisationSemesterMaster()
        {
            OrganisationSemesterMasterSearchRequest searchRequest = new OrganisationSemesterMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationSemesterMaster> listOrganisationSemesterMaster = new List<OrganisationSemesterMaster>();
            IBaseEntityCollectionResponse<OrganisationSemesterMaster> baseEntityCollectionResponse = _organisationSemesterMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSemesterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSemesterMaster;
        }
        //**********used in Course Applicable
        protected List<OrganisationSemesterMaster> GetSemesterListOrganisationSemesterMaster(String CourseYearID)
        {
            OrganisationSemesterMasterSearchRequest searchRequest = new OrganisationSemesterMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = CourseYearID;

            List<OrganisationSemesterMaster> listOrganisationSemesterMaster = new List<OrganisationSemesterMaster>();
            IBaseEntityCollectionResponse<OrganisationSemesterMaster> baseEntityCollectionResponse = _organisationSemesterMasterServiceAccess.GetSemester(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSemesterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSemesterMaster;
        }

        //**********used in Course Applicable for Department************************************************
        protected List<OrganisationDepartmentMaster> GetDepartmentListOrganisationDepartmentMaster(String CourseYearID)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CourseYearID = CourseYearID;

            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _OrganisationDepartmentMasterServiceAccess.GetDepartment(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }
        //******************************************************************************************************

        //**********used in Allocate Staff for Seesion************************************************
        protected List<GeneralSessionMaster> GetSessionListGeneralSessionMaster(String SubjectGroupId)
        {
            GeneralSessionMasterSearchRequest searchRequest = new GeneralSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectGroupId = SubjectGroupId;

            List<GeneralSessionMaster> listGeneralSessionMaster = new List<GeneralSessionMaster>();
            IBaseEntityCollectionResponse<GeneralSessionMaster> baseEntityCollectionResponse = _generalSessionMasterServiceAccess.GetSession(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralSessionMaster;
        }
        //******************************************************************************************************


        protected List<OrganisationStudyCentreMaster> GetListStudyCentreHORO()
        {
            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterServiceAccess.GetListHORO(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<GeneralLanguageMaster> GetListGeneralLanguageMaster()
        {
            GeneralLanguageMasterSearchRequest searchRequest = new GeneralLanguageMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralLanguageMaster> listGeneralLanguageMaster = new List<GeneralLanguageMaster>();
            IBaseEntityCollectionResponse<GeneralLanguageMaster> baseEntityCollectionResponse = _generalLanguageMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLanguageMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLanguageMaster;
        }
        protected List<ToolTemplateApplicable> GetListBranchDetails(int UniversityID, string CentreCode)
        {
            ToolTemplateApplicableSearchRequest searchRequest = new ToolTemplateApplicableSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.UniversityID = UniversityID;
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<ToolTemplateApplicable> listBranchDetails = new List<ToolTemplateApplicable>();
            IBaseEntityCollectionResponse<ToolTemplateApplicable> baseEntityCollectionResponse = _ToolTemplateApplicableServiceAccess.GetBySearchListBranchDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBranchDetails = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.BranchDescription).ToList();
                }
            }
            return listBranchDetails;
        }
        protected List<OrganisationSubjectMaster> GetListOrganisationSubjectMaster(int OrgSemesterMstID, int CourseYearDetailID, int SubjectRuleGrpNumber, int UniversityID, int SubjectID)
        {
            OrganisationSubjectMasterSearchRequest searchRequest = new OrganisationSubjectMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.OrgSemesterMstID = OrgSemesterMstID;
            searchRequest.CourseYearDetailID = CourseYearDetailID;
            searchRequest.SubjectRuleGrpNumber = SubjectRuleGrpNumber;
            searchRequest.UniversityID = UniversityID;
            searchRequest.ID = SubjectID;
            List<OrganisationSubjectMaster> listOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> baseEntityCollectionResponse = _organisationSubjectMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectMaster;
        }


        protected List<OrganisationSubjectTypeMaster> GetListOrganisationSubjectTypeMaster()
        {
            OrganisationSubjectTypeMasterSearchRequest searchRequest = new OrganisationSubjectTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationSubjectTypeMaster> OrganisationSubjectTypeMasterList = new List<OrganisationSubjectTypeMaster>();
            IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> baseEntityCollectionResponse = _organisationSubjectTypeMasterServiceAccess.GetBySubjectTypeMaterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubjectTypeMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubjectTypeMasterList;
        }
        protected List<ToolQualifyingExamSubject> GetListToolQualifyingExamSubject(int QualifyingExamMstID)
        {
            ToolQualifyingExamSubjectSearchRequest searchRequest = new ToolQualifyingExamSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.QualifyingExamMstID = QualifyingExamMstID;
            List<ToolQualifyingExamSubject> ToolQualifyingExamSubjectList = new List<ToolQualifyingExamSubject>();
            IBaseEntityCollectionResponse<ToolQualifyingExamSubject> baseEntityCollectionResponse = _ToolQualifyingExamSubjectServiceAcess.GetByQualifyingExamSubjectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ToolQualifyingExamSubjectList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ToolQualifyingExamSubjectList;
        }
        protected List<StudentRegistrationAcademicApproval> GetListQualifyingExamSubject(int RegistrationID)
        {
            StudentRegistrationAcademicApprovalSearchRequest searchRequest = new StudentRegistrationAcademicApprovalSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RegistrationID = RegistrationID;
            List<StudentRegistrationAcademicApproval> StudentRegistrationAcademicApprovalList = new List<StudentRegistrationAcademicApproval>();
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> baseEntityCollectionResponse = _studentRegistrationAcademicApprovalServiceAcess.GetByQualifyingExamSubjectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    StudentRegistrationAcademicApprovalList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return StudentRegistrationAcademicApprovalList;
        }
        protected List<GeneralSessionMaster> GetListGeneralSessionMaster()
        {
            GeneralSessionMasterSearchRequest searchRequest = new GeneralSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralSessionMaster> listGeneralSessionMaster = new List<GeneralSessionMaster>();
            IBaseEntityCollectionResponse<GeneralSessionMaster> baseEntityCollectionResponse = _generalSessionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralSessionMaster;
        }

        protected List<GeneralQuestionTypeMaster> GetQuestionTypeList()
        {
            GeneralQuestionTypeMasterSearchRequest searchRequest = new GeneralQuestionTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralQuestionTypeMaster> listGeneralQuestionTypeMaster = new List<GeneralQuestionTypeMaster>();
            IBaseEntityCollectionResponse<GeneralQuestionTypeMaster> baseEntityCollectionResponse = _generalQuestionTypeMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralQuestionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralQuestionTypeMaster;
        }

        //protected List<OrganisationSubjectMaster> GetSubjectsList()
        //{

        //    OrganisationSubjectMasterSearchRequest searchRequest = new OrganisationSubjectMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<OrganisationSubjectMaster> listOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
        //    IBaseEntityCollectionResponse<OrganisationSubjectMaster> baseEntityCollectionResponse = _organisationSubjectMasterServiceAccess.GetSubjectList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listOrganisationSubjectMaster;

        //}

        protected List<OrganisationSubjectMaster> GetSubjectSearchList(string searchBy)
        {
            OrganisationSubjectMasterSearchRequest searchRequest = new OrganisationSubjectMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchBy = searchBy;
            List<OrganisationSubjectMaster> listOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> baseEntityCollectionResponse = _organisationSubjectMasterServiceAccess.GetSubjectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectMaster;
        }

        protected List<OrganisationSubjectGrpRule> GetListOfOrgSubjectGroupRule(int SubjectGrpRuleID)
        {
            OrganisationSubjectGrpRuleSearchRequest searchRequest = new OrganisationSubjectGrpRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SubjectRuleGrpNumber = SubjectGrpRuleID;
            List<OrganisationSubjectGrpRule> listOrganisationSubjectGrpRule = new List<OrganisationSubjectGrpRule>();
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> baseEntityCollectionResponse = _organisationSubjectGrpRuleServiceAccess.GetOrgSubjectGroupRuleSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectGrpRule = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectGrpRule;
        }

        protected List<GeneralReligionMaster> GetListGeneralReligionMaster()
        {
            GeneralReligionMasterSearchRequest searchRequest = new GeneralReligionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralReligionMaster> listGeneralReligionMaster = new List<GeneralReligionMaster>();
            IBaseEntityCollectionResponse<GeneralReligionMaster> baseEntityCollectionResponse = _generalReligionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralReligionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralReligionMaster;
        }
        protected List<OrganisationAdmissionTypeMaster> GetListOrganisationAdmissionTypeMaster()
        {
            OrganisationAdmissionTypeMasterSearchRequest searchRequest = new OrganisationAdmissionTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationAdmissionTypeMaster> listOrganisationAdmissionTypeMaster = new List<OrganisationAdmissionTypeMaster>();
            IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> baseEntityCollectionResponse = _organisationAdmissionTypeMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationAdmissionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationAdmissionTypeMaster;
        }

        protected List<OrganisationAllotAdmissionMaster> GetListOrganisationAllotAdmissionMaster()
        {
            OrganisationAllotAdmissionMasterSearchRequest searchRequest = new OrganisationAllotAdmissionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationAllotAdmissionMaster> listOrganisationAllotAdmissionMaster = new List<OrganisationAllotAdmissionMaster>();
            IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> baseEntityCollectionResponse = _organisationAllotAdmissionMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationAllotAdmissionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationAllotAdmissionMaster;
        }

        protected List<ToolQualificationMasterSubject> GetListToolQualificationMasterSubject(int QualificationMstID)
        {
            ToolQualificationMasterSubjectSearchRequest searchRequest = new ToolQualificationMasterSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.QualificationMstID = QualificationMstID;
            List<ToolQualificationMasterSubject> OrganisationSubjectTypeList = new List<ToolQualificationMasterSubject>();
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> baseEntityCollectionResponse = _ToolQualificationMasterSubjectServiceAcess.GetByQualificationMasterSubjectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubjectTypeList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubjectTypeList;
        }

        protected List<ToolQualificationMasterSubject> GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(int BranchDetailID, int StandardNumber, string EducationType)
        {
            ToolQualificationMasterSubjectSearchRequest searchRequest = new ToolQualificationMasterSubjectSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.BranchDetailID = BranchDetailID;
            searchRequest.StandardNumber = StandardNumber;
            searchRequest.EducationType = EducationType;
            List<ToolQualificationMasterSubject> OrganisationSubjectTypeList = new List<ToolQualificationMasterSubject>();
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> baseEntityCollectionResponse = _ToolQualificationMasterSubjectServiceAcess.GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationSubjectTypeList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationSubjectTypeList;
        }

        protected List<OrganisationBranchMaster> GetBranchListRoleWise(string centreCode, string scopeIdentity, int roleID, int universityID, string isFirstYearPromotion)
        {
            OrganisationBranchMasterSearchRequest searchRequest = new OrganisationBranchMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.RoleId = roleID;
            searchRequest.ScopeIdentity = scopeIdentity;
            searchRequest.CentreCode = centreCode;
            searchRequest.UniversityID = universityID;
            searchRequest.isFirstYearPromotion = isFirstYearPromotion;
            List<OrganisationBranchMaster> OrganisationBranchMasterList = new List<OrganisationBranchMaster>();
            IBaseEntityCollectionResponse<OrganisationBranchMaster> baseEntityCollectionResponse = _organisationBranchMasterServiceAccess.GetBranchListRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    OrganisationBranchMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return OrganisationBranchMasterList;
        }


        protected OrganisationCourseYearDetails GetCourseYearByBranchDetIDAndStandardNumber(int BranchDetailID, int StandardNumber)
        {

            OrganisationCourseYearDetailsViewModel model = new OrganisationCourseYearDetailsViewModel();
            model.BranchDetailID = BranchDetailID;
            model.StandardNumber = StandardNumber;
            model.OrganisationCourseYearDetailsDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); ;
            IBaseEntityResponse<OrganisationCourseYearDetails> response = _organisationCourseYearDetailsServiceAccess.SelectByBranchDetIDAndStandardNumber(model.OrganisationCourseYearDetailsDTO);
            return response.Entity;
        }

        protected OrganisationBranchDetails GetOrganisationBranchDetailsSelectByID(int BranchDetailID)
        {

            OrganisationBranchDetailsViewModel model = new OrganisationBranchDetailsViewModel();
            model.ID = BranchDetailID;

            model.OrganisationBranchDetailsDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); ;
            IBaseEntityResponse<OrganisationBranchDetails> response = _organisationBranchDetailsServiceAccess.SelectByID_For_CourseDescription(model.OrganisationBranchDetailsDTO);
            return response.Entity;
        }

        //[HttpGet]
        //public List<UserMainMenuMasterViewModel> BuildMenu(int ModuleID, string AdminRoleMasterID)
        //{
        //    UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();

        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.ID = 0;
        //    searchRequest.ModuleID = ModuleID;
        //    searchRequest.RoleId = Convert.ToInt32(AdminRoleMasterID);
        //    // ViewData["path"] = path;


        //    List<UserMainMenuMasterViewModel> mmList = new List<UserMainMenuMasterViewModel>();
        //    List<UserMainMenuMaster> listM = new List<UserMainMenuMaster>();
        //    IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterServiceAccess.GetByModuleID(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listM = baseEntityCollectionResponse.CollectionResponse.ToList();
        //            foreach (UserMainMenuMaster item in listM)
        //            {
        //                UserMainMenuMasterViewModel UserMainMenuMasterViewModel = new UserMainMenuMasterViewModel();
        //                UserMainMenuMasterViewModel.UserMainMenuMasterDTO = item;

        //                mmList.Add(UserMainMenuMasterViewModel);
        //            }
        //        }
        //        else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
        //        {
        //            IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
        //        }
        //    }

        //    return mmList;
        //}

        [HttpGet]
        public List<UserMainMenuMasterViewModel> BuildMenu(string ModuleCode, string AdminRoleMasterID)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = 0;
            searchRequest.ModuleCode = ModuleCode;
            searchRequest.RoleId = Convert.ToInt32(AdminRoleMasterID);
            // ViewData["path"] = path;


            List<UserMainMenuMasterViewModel> mmList = new List<UserMainMenuMasterViewModel>();
            List<UserMainMenuMaster> listM = new List<UserMainMenuMaster>();
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterServiceAccess.GetByModuleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listM = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (UserMainMenuMaster item in listM)
                    {
                        UserMainMenuMasterViewModel UserMainMenuMasterViewModel = new UserMainMenuMasterViewModel();
                        UserMainMenuMasterViewModel.UserMainMenuMasterDTO = item;

                        mmList.Add(UserMainMenuMasterViewModel);
                    }
                }
                else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                {
                    IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                }
            }

            return mmList;
        }


        protected List<OrganisationCourseYearDetails> GetCourseYearListRoleWise()
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.CentreCode = CentreCode;
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetCourseYearListRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }
        protected List<OrganisationCourseYearDetails> GetCourseYearListRole_CentreCode_UniversityWise(int RoleId, string CentreCode, string ScopeIdentity, int UniversityID)
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = RoleId;
            searchRequest.CentreCode = CentreCode;
            searchRequest.ScopeIdentity = ScopeIdentity;
            searchRequest.UniversityID = UniversityID;
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetCourseYearListRole_CentreCode_UniversityWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }


        protected List<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(int RoleId, string CentreCode, string ScopeIdentity, int UniversityID)
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = RoleId;
            searchRequest.CentreCode = CentreCode;
            searchRequest.ScopeIdentity = ScopeIdentity;
            searchRequest.UniversityID = UniversityID;

            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _organisationSectionDetailsServiceAccess.GetSectionDetailsRole_CentreCode_UniversityWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSectionDetails;
        }

        protected List<OrganisationCourseYearDetails> GetNextCourseYearForPromotion()
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.CentreCode = CentreCode;
            List<OrganisationCourseYearDetails> listOrganisationCourseYearDetails = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetNextCourseYearForPromotion(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationCourseYearDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationCourseYearDetails;
        }

        protected List<OrganisationSectionDetails> GetSectionDetailsRoleWise(int branchID, string centreCode, string universityID, string isFirstYearPromotion)
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.BranchID = branchID;
            searchRequest.CentreCode = centreCode;
            if (isFirstYearPromotion == "true")
            {
                searchRequest.StandardNumber = 2;
                searchRequest.UniversityID = Convert.ToInt32(universityID);
            }

            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _organisationSectionDetailsServiceAccess.GetSectionDetailsRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSectionDetails;
        }

        protected List<OrganisationSectionDetails> GetSectionDetailsForPromotion()
        {
            OrganisationSectionDetailsSearchRequest searchRequest = new OrganisationSectionDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.StandardNumber = StandardNumber;
            //searchRequest.BranchDetID = BranchDetID;
            //searchRequest.SearchType = 1;
            List<OrganisationSectionDetails> listOrganisationSectionDetails = new List<OrganisationSectionDetails>();
            IBaseEntityCollectionResponse<OrganisationSectionDetails> baseEntityCollectionResponse = _organisationSectionDetailsServiceAccess.GetSectionDetailsForPromotion(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSectionDetails;
        }

        protected List<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(string centreCode, int accBalsheetMstID)
        {
            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            searchRequest.AccBalsheetMstID = accBalsheetMstID;
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterServiceAccess.GetStudyCentreDetailsForReports(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStudyCentreMaster;
        }

        ///  -------------------------------------------------------   Methods required for Account Module -----------------------------------------------------
        ///
        /// </summary>
        /// <returns></returns>


        protected List<AccountBalancesheetMaster> GetListOfAccountBalancesheetMasterRoleWise(int RoleID)
        {
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = RoleID;
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterServiceAccess.GetBalancesheetForAccountMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetMaster;
        }

        protected List<AccountTransactionTypeMaster> GetListOfAccountTransactionType()
        {
            AccountTransactionTypeMasterSearchRequest searchRequest = new AccountTransactionTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountTransactionTypeMaster> listAccountTransactionTypeMaster = new List<AccountTransactionTypeMaster>();
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> baseEntityCollectionResponse = _accountTransactionTypeMasterServiceAccess.GetTransactionTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountTransactionTypeMaster;
        }

        // Following method fetches only current account session 
        protected AccountSessionMaster GetCurrentAccountSession()
        {
            AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
            model.AccountSessionMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); ;
            IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterServiceAccess.GetCurrentAccountSession(model.AccountSessionMasterDTO);
            return response.Entity;
        }

        // Following method fetches all account session list
        protected List<AccountSessionMaster> GetAllAccountSession()
        {
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountSessionMaster> listAccountSessionMaster = new List<AccountSessionMaster>();
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _accountSessionMasterServiceAccess.GetAccountSessionList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountSessionMaster;
        }

        protected List<AccountMaster> GetAccountList(string CashBankFalg, string PersonType)
        {
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CashBankFlag = CashBankFalg;
            searchRequest.PersonType = PersonType;
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterServiceAccess.GetAccountListForReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountMaster;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        protected List<GeneralTitleMaster> GetListGeneralTitleMaster()
        {
            GeneralTitleMasterSearchRequest searchRequest = new GeneralTitleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralTitleMaster> listGeneralTitleMaster = new List<GeneralTitleMaster>();
            IBaseEntityCollectionResponse<GeneralTitleMaster> baseEntityCollectionResponse = _generalTitleMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTitleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTitleMaster;
        }

        protected List<GeneralJobProfile> GetListGeneralJobProfile()
        {
            GeneralJobProfileSearchRequest searchRequest = new GeneralJobProfileSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralJobProfile> listGeneralJobProfile = new List<GeneralJobProfile>();
            IBaseEntityCollectionResponse<GeneralJobProfile> baseEntityCollectionResponse = _generalJobProfileServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobProfile = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralJobProfile;
        }

        protected List<GeneralJobStatus> GetListGeneralJobStatus()
        {
            GeneralJobStatusSearchRequest searchRequest = new GeneralJobStatusSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralJobStatus> listGeneralJobStatus = new List<GeneralJobStatus>();
            IBaseEntityCollectionResponse<GeneralJobStatus> baseEntityCollectionResponse = _generalJobStatusServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobStatus = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralJobStatus;
        }

        protected List<EmployeeShiftMaster> GetListEmployeeShiftMaster(string CentreCode)
        {
            EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<EmployeeShiftMaster> listEmployeeShiftMaster = new List<EmployeeShiftMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _employeeShiftMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeShiftMaster;
        }
        //-------------Online
        protected List<EmpEmployeeMaster> GetListEmpEmployeeMaster(string SearchWord)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchWord;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetEmployeeNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;

        }

        protected List<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(string SearchWord, string CentreCode)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.SearchWord = SearchWord;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetEmployeeCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }
        protected List<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(string SearchWord, string CentreCode)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.SearchWord = SearchWord;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetEmployeeRoleCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }
        protected List<GeneralBoardUniversityMaster> GetListGeneralBoardUniversityMaster()
        {
            GeneralBoardUniversityMasterSearchRequest searchRequest = new GeneralBoardUniversityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralBoardUniversityMaster> listGeneralBoardUniversityMaster = new List<GeneralBoardUniversityMaster>();
            IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> baseEntityCollectionResponse = _generalBoardUniversityMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralBoardUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralBoardUniversityMaster;
        }

        public ActionResult UpdateBalancesheetSession(string selectedBalsheetID, string selectedBalsheetName)
        {
            Session["BalancesheetName"] = selectedBalsheetName;
            Session["BalancesheetID"] = selectedBalsheetID;
            return null;
        }

        ///  -------------------------------------------------------   Methods required for Student Module -----------------------------------------------------
        ///
        /// </summary>
        /// <returns></returns>
        /// 

        protected StudentMaster GetStudentDetails(int studentID, string centreCode)
        {
            StudentMasterViewModel model = new StudentMasterViewModel();
            model.StudentMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            model.ID = studentID;
            model.CentreCode = centreCode;
            model.StudentMasterDTO.searchType = "CurrentYearStudent";
            IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.GetStudentDetails(model.StudentMasterDTO);
            return response.Entity;
        }
        protected List<StudentSectionChangeRequest> GetListOrganisationSectionMaster(int courseYearID, int sectionDetailID, string centreCode)
        {
            StudentSectionChangeRequestSearchRequest searchRequest = new StudentSectionChangeRequestSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            searchRequest.CourseYearID = courseYearID;
            searchRequest.SectionDetailID = sectionDetailID;
            List<StudentSectionChangeRequest> listStudentSectionChangeRequest = new List<StudentSectionChangeRequest>();
            IBaseEntityCollectionResponse<StudentSectionChangeRequest> baseEntityCollectionResponse = _studentSectionChangeRequestServiceAcess.GetSectionList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentSectionChangeRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listStudentSectionChangeRequest;
        }

        protected List<StudentMaster> GetStudentSearchList(string searchWord, string maxResults, string centreCode, string searchType, string ActiveSessionFlag)
        {
            StudentMasterSearchRequest searchRequest = new StudentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            searchRequest.maxResult = Convert.ToInt32(maxResults);
            searchRequest.SearchWord = searchWord;
            searchRequest.SearchType = searchType;
            searchRequest.ActiveSessionFlag = ActiveSessionFlag;
            List<StudentMaster> listStudentMaster = new List<StudentMaster>();
            IBaseEntityCollectionResponse<StudentMaster> baseEntityCollectionResponse = _studentMasterServiceAccess.GetStudentSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listStudentMaster;
        }


 


        protected StudentMaster GetStudentCentreByID(int studentID, string StudentType)
        {
            StudentMasterViewModel model = new StudentMasterViewModel();
            model.StudentMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            model.StudentMasterDTO.ID = studentID;
            model.StudentMasterDTO.searchType = StudentType;
            IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.GetStudentCentreByID(model.StudentMasterDTO);
            return response.Entity;
        }

        protected StudentMaster GetCentreFromStudentMasterByStudentID(int studentID)
        {
            StudentMasterViewModel model = new StudentMasterViewModel();
            model.StudentMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            model.StudentMasterDTO.ID = studentID;
            IBaseEntityResponse<StudentMaster> response = _studentMasterServiceAccess.GetCentreFromStudentMasterByStudentID(model.StudentMasterDTO);
            return response.Entity;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentre(int AdminRoleMasterID, int EmployeeID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            searchRequest.EmployeeID = EmployeeID; // Convert.ToInt32(Session["PersonID"]);
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsServiceAccess.GetStudyCentreListByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByAcademicManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsServiceAccess.GetStudyCentreListForAcademicManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByFinanceManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsServiceAccess.GetStudyCentreListForFinanceManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<GeneralLeaveDocument> GetListGeneralLeaveDocument()
        {
            GeneralLeaveDocumentSearchRequest searchRequest = new GeneralLeaveDocumentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralLeaveDocument> listGeneralLeaveDocument = new List<GeneralLeaveDocument>();
            IBaseEntityCollectionResponse<GeneralLeaveDocument> baseEntityCollectionResponse = _generalLeaveDocumentServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLeaveDocument = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLeaveDocument;
        }

        protected List<LeaveMaster> GetListLeaveMaster()
        {
            LeaveMasterSearchRequest searchRequest = new LeaveMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollectionResponse = _leaveMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveMaster;
        }

        // Following method fetches leave details of particular en 
        protected LeaveRuleMaster GetLeaveDetailsByLeaveMasterID(int LeaveMasterID, int EmployeeID, int LeaveSessionID)
        {
            ILeaveRuleMasterViewModel model = new LeaveRuleMasterViewModel();
            model.LeaveRuleMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            model.LeaveRuleMasterDTO.LeaveMasterID = LeaveMasterID;
            model.LeaveRuleMasterDTO.EmployeeID = EmployeeID;
            model.LeaveRuleMasterDTO.LeaveSessionID = LeaveSessionID;
            IBaseEntityResponse<LeaveRuleMaster> response = _leaveRuleMasterServiceAccess.GetLeaveDetails(model.LeaveRuleMasterDTO);
            return response.Entity;
        }


        protected List<GeneralCurrencyMaster> GetGeneralCurrencyMaster()
        {
            GeneralCurrencyMasterSearchRequest searchRequest = new GeneralCurrencyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCurrencyMaster> listGeneralCurrencyMaster = new List<GeneralCurrencyMaster>();
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> baseEntityCollectionResponse = _generalCurrencyMasterServiceAccess.GetGeneralCurrencyMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCurrencyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCurrencyMaster;
        }

        protected List<GeneralTaxGroupMaster> GetGeneralTaxGroupMaster()
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaxGroupMaster> listGeneralTaxGroupMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _generalTaxGroupMasterServiceAccess.GetGeneralTaxGroupMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTaxGroupMaster;
        }

        protected List<LeaveAttendanceSpanLock> GetListLeaveAttendanceSpanLock(string CentreCode)
        {
            LeaveAttendanceSpanLockSearchRequest searchRequest = new LeaveAttendanceSpanLockSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<LeaveAttendanceSpanLock> listLeaveAttendanceSpanLock = new List<LeaveAttendanceSpanLock>();
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> baseEntityCollectionResponse = _leaveAttendanceSpanLockServiceAccess.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAttendanceSpanLock = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveAttendanceSpanLock;
        }


        protected List<UserMaster> GetUserTypeMaster()
        {
            UserMasterSearchRequest searchRequest = new UserMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<UserMaster> listUserMaster = new List<UserMaster>();
            IBaseEntityCollectionResponse<UserMaster> baseEntityCollectionResponse = _userMasterServiceAccess.GetUserType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserMaster;
        }


        protected List<GeneralHolidays> GetListGeneralWeeklyOffAndHoliday(int EmployeeID)
        {
            GeneralHolidaysSearchRequest searchRequest = new GeneralHolidaysSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
            List<GeneralHolidays> listGeneralHolidays = new List<GeneralHolidays>();
            IBaseEntityCollectionResponse<GeneralHolidays> baseEntityCollectionResponse = _generalHolidaysServiceAccess.GetHolidayAndWeeklyOffDayByEmployeeID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralHolidays = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralHolidays;
        }

        protected List<LeaveSession> GetListLeaveSession(string CentreCode)
        {
            LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = "LeaveSessionName";                        // parameters for SelectAll procedures under normal condition
            searchRequest.StartRow = 0;
            searchRequest.EndRow = 100;
            searchRequest.SearchBy = string.Empty;
            searchRequest.SortDirection = "asc";
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<LeaveSession> listLeaveSession = new List<LeaveSession>();
            IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _leaveSessionServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveSession;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLeaveSessionByCentreCode(string CentreCode)
        {
            LeaveRuleApplicableDetailsViewModel model = new LeaveRuleApplicableDetailsViewModel();
            string[] splited;
            splited = CentreCode.Split(':');
            //model.SelectedCentreName = splited[1];
            CentreCode = splited[0];
            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var session = GetListLeaveSession(CentreCode);
            var result = (from s in session
                          select new
                          {
                              id = s.LeaveSessionID,
                              name = s.LeaveSessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<FishLicenseType> GetListFishLicenseType()
        {
            FishLicenseTypeSearchRequest searchRequest = new FishLicenseTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FishLicenseType> listEmpDesignationMaster = new List<FishLicenseType>();
            IBaseEntityCollectionResponse<FishLicenseType> baseEntityCollectionResponse = _fishLicenseTypeServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpDesignationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpDesignationMaster;
        }

        //Get User Module Master List.
        protected List<UserModuleMaster> GetUserModuleMasterList()
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<UserModuleMaster> listUserModuleMaster = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterServiceAccess.GetUserModuleList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserModuleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserModuleMaster;
        }

        //Get User Menu Master List.
        protected List<UserMainMenuMaster> GetUserMainMenuMasterList(string moduleCode)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<UserMainMenuMaster> listUserMainMenuMaster = new List<UserMainMenuMaster>();
            searchRequest.ModuleCode = moduleCode;
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterServiceAccess.GetByModuleCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMainMenuMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserMainMenuMaster;
        }

        //Method to get Database table name list.
        protected List<GeneralTaskReportingDetails> GetAMSDatabaseTableNameList()
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> taskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalBasedTableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalBasedTableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalBasedTableList;
        }

        //Get Primary Key from Table Name.
        protected List<GeneralTaskReportingDetails> GetDatabaseTablePrimaryKeyList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalParamPrimaryKeyList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        //Get Cloumn name form table name
        protected List<GeneralTaskReportingDetails> GetTableDisplayFieldList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        //Get Record from TableName, Primary Key and table fields.
        protected List<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(string tableName, string primaryKey, string displayField)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = !string.IsNullOrEmpty(tableName) ? tableName : string.Empty;
            searchRequest.PrimaryKey = !string.IsNullOrEmpty(primaryKey) ? primaryKey : string.Empty;
            searchRequest.DisplayField = !string.IsNullOrEmpty(displayField) ? displayField : string.Empty;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsServiceAccess.GetTaskApprovalKeyValueList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        [HttpPost]
        public JsonResult GetSubjectList(string term)
        {
            var data = GetSubjectSearchList(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.Descriptions,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //Method to get Database Item Name list.
        protected List<InventoryItemMaster> GetInventoryItemMasterList()
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryItemMaster> itemMasterTableList = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    itemMasterTableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return itemMasterTableList;
        }


        //Get Location by Balance Sheet ID.
        protected List<InventoryLocationMaster> GetInventoryLocationMasterByBalanceSheetID(int balanceSheetID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = balanceSheetID;
            List<InventoryLocationMaster> inventoryMasterList = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryLocationMasterServiceAccess.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    inventoryMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return inventoryMasterList;
        }
        //dropDown For Call Type
        protected List<CRMCallType> GetListCallType()
        {
            CRMCallTypeSearchRequest searchRequest = new CRMCallTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMCallType> listCallType = new List<CRMCallType>();
            IBaseEntityCollectionResponse<CRMCallType> baseEntityCollectionResponse = _CRMCallTypeServiceAcess.GetCRMCallTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCallType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCallType;
        }

        [NonAction]
        protected List<EmpEmployeeMaster> GetEmployeeList(string SearchKeyWord)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;

            List<EmpEmployeeMaster> listEmployees = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetCallerEmployeeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployees = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployees;
        }


        //dropDown For Call Type
        protected List<GeneralTimeSlotMaster> GetListGeneralTimeSlot()
        {
            GeneralTimeSlotMasterSearchRequest searchRequest = new GeneralTimeSlotMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTimeSlotMaster> listGeneralTimeSlot = new List<GeneralTimeSlotMaster>();
            IBaseEntityCollectionResponse<GeneralTimeSlotMaster> baseEntityCollectionResponse = _generalTimeSlotMasterServiceAccess.GeneralTimeSlotMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTimeSlot = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTimeSlot;
        }

        protected List<UserModuleMaster> GetModuleListByUserID(int AdminRoleMasterID)
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            List<UserModuleMaster> ModuleList = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterServiceAcess.GetModuleListForLoginUserIDByRoleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            //  TempData["ModuleList"] = ModuleList;
            return ModuleList;
        }
        protected List<UserModuleMaster> GetModuleListForAdmin()
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<UserModuleMaster> ModuleList = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterServiceAcess.GetModuleListForAdmin(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            // TempData["ModuleList"] = ModuleList;
            return ModuleList;
        }
        protected List<OrganisationDepartmentMaster> GetListOrganisationMasterCentreAndRoleWise(string CentreCode, string EntityLevel, int AdminRoleID)
        {

            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.EntityLevel = EntityLevel;
            searchRequest.AdminRoleMasterID = AdminRoleID;
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);

            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _OrganisationDepartmentMasterServiceAccess.GetDepartmentListCentreAndRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        //public class SessionExpireAttribute : ActionFilterAttribute
        //{
        //    public override void OnActionExecuting(ActionExecutingContext filterContext)
        //    {
        //        HttpContext ctx = HttpContext.Current;

        //        // check  sessions here
        //        if (HttpContext.Current.Session["UserId"] == null)
        //        {
        //            filterContext.Result = new RedirectResult("~/Account/Login");
        //            return;
        //        }

        //        base.OnActionExecuting(filterContext);
        //    }
        //}
        public bool SendEmail(string To, string Subject, string Body, string FromUserID, string FromUserPassword)
        {
            try
            {
                using (MailMessage mm = new MailMessage(FromUserID, To))
                {
                    mm.Subject = Subject;
                    mm.Body = Body;
                    //if (fuAttachment.HasFile)
                    //{
                    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                    //}
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(FromUserID, FromUserPassword);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
        protected List<AdminRoleApplicableDetails> GetRoleListByUserID()
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonId = Convert.ToInt32(Session["PersonId"]);
            List<AdminRoleApplicableDetails> RoleList = new List<AdminRoleApplicableDetails>();
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsServiceAccess.GetRoleListForLoginUserIDBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    RoleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return RoleList;
        }
        //protected List<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(string centreCode, string universityID)
        //{
        //    OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SelectedCentreCode = centreCode;
        //    searchRequest.SelectedUniversityID = universityID;
        //    //searchRequest.SearchType = 1;
        //    List<OnlineEntranceExamQuestionBankMaster> courseList = new List<OnlineEntranceExamQuestionBankMaster>();
        //    IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = _OnlineEntranceExamQuestionBankMasterServiceAccess.GetCourseByCentreCodeAndUniversity(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            courseList = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return courseList;
        //}

        //protected List<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(int branchMasterID)
        //{
        //    OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SelectedCourseID = Convert.ToString(branchMasterID);           

        //    List<OnlineEntranceExamQuestionBankMaster> courseYearList = new List<OnlineEntranceExamQuestionBankMaster>();
        //    IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = _OnlineEntranceExamQuestionBankMasterServiceAccess.GetCourseYearFromBranchMasterID(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            courseYearList = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return courseYearList;
        //}


        protected List<OrganisationCourseYearDetails> GetCourseYearDetailSearchList(string searchBy)
        {
            OrganisationCourseYearDetailsSearchRequest searchRequest = new OrganisationCourseYearDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchBy = searchBy;
            List<OrganisationCourseYearDetails> listOrganisationSubjectMaster = new List<OrganisationCourseYearDetails>();
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> baseEntityCollectionResponse = _organisationCourseYearDetailsServiceAccess.GetCourseYearDetailSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationSubjectMaster;
        }

        //protected List<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(int courseYearID)
        //{
        //    OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest = new OnlineEntranceExamQuestionBankMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.CourseYearID = courseYearID;           

        //    List<OnlineEntranceExamQuestionBankMaster> subjectGroupList = new List<OnlineEntranceExamQuestionBankMaster>();
        //    IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollectionResponse = _OnlineEntranceExamQuestionBankMasterServiceAccess.GetSubjectGroupFromCourseYearDetail(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            subjectGroupList = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return subjectGroupList;
        //}

        protected List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetListCRMSaleGroupMaster()
        {
            CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest = new CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            List<CRMSaleGroupMasterAndAllocateEmployeeInGroup> listAdmin = new List<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> baseEntityCollectionResponse = _CRMSaleGroupMasterAndAllocateEmployeeInGroupServiceAcess.GetCRMSaleGroupMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }

        protected List<EmpEmployeeMaster> GetListEmpEmployeeMasterInCRMSales(int SelectedParamerterID, string CRMSaleRecordFor)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SelectedParamerterID = SelectedParamerterID;
            searchRequest.CRMSaleRecordFor = CRMSaleRecordFor;
            //searchRequest.SearchType = 1;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetByEmployeeInCRMSales(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        protected List<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(int SelectedParamerterID)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SelectedParamerterID = SelectedParamerterID;
            //searchRequest.SearchType = 1;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetListEmpEmployeeMasterForCRMSalesGroup(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        protected List<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(int SelectedParamerterID)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SelectedParamerterID = SelectedParamerterID;
            searchRequest.ID = Convert.ToInt32(Session["PersonID"]);
            //searchRequest.SearchType = 1;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterServiceAccess.GetListEmpEmployeeMasterForTargetException(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        protected List<CRMSaleTargetDetails> GetListCRMSaleTargetType()
        {
            CRMSaleTargetDetailsSearchRequest searchRequest = new CRMSaleTargetDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleTargetDetails> listCRMSaleTargetType = new List<CRMSaleTargetDetails>();
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> baseEntityCollectionResponse = _CRMSaleTargetDetailsServiceAcess.GetCRMSaleTargetTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleTargetType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCRMSaleTargetType;
        }

        public List<CRMSaleEnquiryMasterAndAccountDetails> GetAccountDetails(string SearchKeyWord, Int16 AccountProgressTypeID, Int16 AccountType, Int32 CRMSaleEnquiryAccountMasterID, Int32 employeeID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest = new CRMSaleEnquiryMasterAndAccountDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccountName = SearchKeyWord;
            searchRequest.AccountProgressTypeID = AccountProgressTypeID;
            searchRequest.CRMSaleEnquiryAccountMasterID = CRMSaleEnquiryAccountMasterID;
            searchRequest.EmployeeID = employeeID;
            searchRequest.EnquiryAccountType = AccountType;

            List<CRMSaleEnquiryMasterAndAccountDetails> listAccount = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAccess.GetCRMSaleEnquiryAccountMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }

        protected List<GeneralPeriodTypeMaster> GetListGeneralPeriodTypeMaster()
        {
            GeneralPeriodTypeMasterSearchRequest searchRequest = new GeneralPeriodTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPeriodTypeMaster> listCRMSaleTargetType = new List<GeneralPeriodTypeMaster>();
            IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> baseEntityCollectionResponse = _GeneralPeriodTypeMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleTargetType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCRMSaleTargetType;
        }

        //dropDown For Call Type
        protected List<CRMCallerRoleAllocation> GetListCallerRoleAllocation()
        {
            CRMCallerRoleAllocationSearchRequest searchRequest = new CRMCallerRoleAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMCallerRoleAllocation> listAdmin = new List<CRMCallerRoleAllocation>();
            IBaseEntityCollectionResponse<CRMCallerRoleAllocation> baseEntityCollectionResponse = _CRMCallerRoleAllocationServiceAcess.GetCRMCallerRoleAllocationList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }

        protected List<CRMSaleReport> LoadAllWicklyStatusDetailsInDateRange(DateTime fromDate, DateTime toDate, int employee)
        {
            //try
            //{
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = employee;
            searchRequest.FromDate = fromDate;
            searchRequest.UptoDate = toDate;
            List<CRMSaleReport> listCRMSaleReport = new List<CRMSaleReport>();
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetCRMSaleWicklyStatusDetailsInDateRangeReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCRMSaleReport;
            //}
            //catch (Exception ex)
            //{
            //    _logException.Error(ex.Message);
            //    throw;
            //}
        }

        protected List<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(string CentreCode, int SessionMaster, int EmployeeID, int RoleMasterID)
        {
            //try
            //{
            OnlineExamExaminationMasterSearchRequest searchRequest = new OnlineExamExaminationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
            searchRequest.RoleMasterID = RoleMasterID;
            searchRequest.SessionMaster = SessionMaster;
            searchRequest.CentreCode = CentreCode;
            List<OnlineExamExaminationMaster> listExamination = new List<OnlineExamExaminationMaster>();
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> baseEntityCollectionResponse = _OnlineExamExaminationMasterServiceAccess.OnlineExamGetExaminationListCentreWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listExamination = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listExamination;
            //}
            //catch (Exception ex)
            //{
            //    _logException.Error(ex.Message);
            //    throw;
            //}
        }

        protected static WorksheetPart InsertWorksheet(WorkbookPart workbookPart)
        {
            // Add a new worksheet part to the workbook.
            WorksheetPart newWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            newWorksheetPart.Worksheet = new Worksheet(new SheetData());
            newWorksheetPart.Worksheet.Save();

            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = workbookPart.GetIdOfPart(newWorksheetPart);

            // Get a unique ID for the new sheet.
            uint sheetId = 1;
            if (sheets.Elements<Sheet>().Count() > 0)
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }

            string sheetName = "Sheet" + sheetId;

            // Append the new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = sheetName };
            sheets.Append(sheet);
            workbookPart.Workbook.Save();

            return newWorksheetPart;
        }

        protected static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                //row.InsertBefore(newCell, refCell);

                row.Append(newCell);
                worksheet.Save();
                return newCell;
            }
        }

        protected static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }
    }
}

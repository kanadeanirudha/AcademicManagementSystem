using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;
using AMS.Web.UI;
using AMS.Web.UI.HtmlHelperExtensions;
using AMS.Web.UI.Models;

namespace AMS.Web.UI.Controllers
{
    [SessionExpire]
    public class HomeController : BaseController
    {
        IDashboardServiceAccess _dashboardServiceAccess = null;
        IGeneralTaskReportingDetailsServiceAccess _generalTaskReportingDetailsServiceAccess = null;
        AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HomeController()
        {
            _dashboardServiceAccess = new DashboardServiceAccess();
            _generalTaskReportingDetailsServiceAccess = new GeneralTaskReportingDetailsServiceAccess();
            _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();
        }

        #region ------------------Controller Methods------------------

        public ActionResult GetNotificationCount()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            return Json(_messageRepository.GetAllMessages(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "E")
                {
                    _adminRoleApplicableDetailsBaseViewModel.RoleList = GetRoleListByUserID();
                    if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count > 0)
                    {

                        //Create selectlistitem list 
                        List<SelectListItem> items = new List<SelectListItem>();
                        SelectListItem s = null;

                        //add the empty selection
                        s = new SelectListItem();
                        //s.Value = "";
                        //s.Text = "";
                        //items.Add(s);
                        foreach (var t in _adminRoleApplicableDetailsBaseViewModel.RoleList)
                        {
                            s = new SelectListItem();
                            s.Text = t.AdminRoleMasterID.ToString();
                            s.Value = t.AdminRoleCode.ToString();
                            items.Add(s);

                            if (t.RoleType == "Regular")
                            {
                                //DefaultRoleCode = t.AdminRoleCode;
                                Session["DefaultRoleID"] = t.AdminRoleMasterID;
                            }

                        }

                        //bind seleclistitems list to to viewBag 

                        //ViewData["RoleList"] = items;
                        //if (Session["DefaultModuleCode"] == null)
                        //{
                        //    ViewData["DefaultRoleCode"] = DefaultRoleCode.ToString();
                        //}
                        //else
                        //{
                        //    ViewData["DefaultRoleCode"] = Session["RoleCode"];
                        //}

                        //Session["DefaultRoleID"] = DefaultRoleID.ToString();
                        ViewData["UserType"] = "E";

                    }

                    _dashboardViewModel.DashboardContentList = GetDashboardContentListByAdminRoleID(Convert.ToInt32(Session["DefaultRoleID"]));
                    if (_dashboardViewModel.DashboardContentList.Count > 0)
                    {
                        return View("/Views/Dashboard/DashboardIndex.cshtml", _dashboardViewModel);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }

                //if (Convert.ToInt32(Session["PersonID"]) == 19 || Convert.ToInt32(Session["PersonID"]) == 20 || Convert.ToInt32(Session["PersonID"]) == 21 || Convert.ToInt32(Session["PersonID"]) == 22)
                //{
                //    return RedirectToAction("Index", "CRMSalePersonDashboard");
                //}
                //else
                //{
                //    return View();
                //}
            }
            else
            {

                //return View("Login","Account");
                return RedirectToAction("Login", "Account");
                // return PartialView("Login");
            }
        }

        public ActionResult NotificationList(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _dashboardViewModel.ModuleList.Count()/4;
                }



                return PartialView("NotificationList", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult NotificationListV2(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _dashboardViewModel.ModuleList.Count()/4;
                }



                return PartialView("NotificationListV2", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult NotificationListCount()
        {
            GeneralTaskReportingDetailsViewModel _generalTaskReportingDetailsViewModel = new GeneralTaskReportingDetailsViewModel();
            _generalTaskReportingDetailsViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            _generalTaskReportingDetailsViewModel.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsServiceAccess.GetTotalPendingCountTaskEmployeewise(_generalTaskReportingDetailsViewModel.GeneralTaskReportingDetailsDTO);
            int result = 0;
            if (response != null && response.Entity != null)
            {
                result = Convert.ToInt32(response.Entity.TotalPendingRequest);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _dashboardViewModel.ModuleList.Count()/4;
                }

                //return PartialView("List", _dashboardViewModel);
                return PartialView("/Views/Home/List.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ListV2(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _dashboardViewModel.ModuleList.Count()/4;
                }

                //return PartialView("List", _dashboardViewModel);
                return PartialView("/Views/Home/ListV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult PendingRequestList(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("RequestOnDashboard", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AccountHome()
        {
            if (Session["UserType"] != null)
            {
                return PartialView();
            }
            else
            {

                //return View("Login","Account");
                return RedirectToAction("Login", "Account");
                // return PartialView("Login");
            }
        }

        public ActionResult AccountHomeV2()
        {
            if (Session["UserType"] != null)
            {
                return PartialView();
            }
            else
            {

                //return View("Login","Account");
                return RedirectToAction("Login", "Account");
                // return PartialView("Login");
            }
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }

        public ActionResult BalancesheetError()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StudentIndex()
        {
            IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "S")
                {

                    //_dashboardViewModel.DashboardContentList = GetDashboardContentListByStudentID(Convert.ToInt32(Session["DefaultRoleID"]));
                    //if (_dashboardViewModel.DashboardContentList.Count > 0)
                    int DashboardCount = 1;
                    if (DashboardCount > 0)
                    {
                        return View("/Views/Dashboard/DashboardStudentIndex.cshtml", _dashboardViewModel);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult UnauthorizedAccess()
        {
            return PartialView();
        }

        public ActionResult PendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingRequests.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingManualAttendanceRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingManualAttendanceRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingManualAttendanceRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingManualAttendanceRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingLeaveRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);              
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingLeaveRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingLeaveRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);              
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingLeaveRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult SPAttendancePendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/SPAttendancePendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult SPAttendancePendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/SPAttendancePendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CODAPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/CODAPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CODAPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/CODAPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult DASTPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/DASTPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult FSAAPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/FSAAPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult FSAAPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/FSAAPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult INWARDPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/INWARDPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingRequestOfStudentRegistrationAcademicApproval(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingRequestOfStudentRegistrationAcademicApproval.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PurchaseRequirementPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PurchaseRequirementPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PurchaseRequirementPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PurchaseRequirementPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PurchaseRequsitionPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PurchaseRequisitionPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PurchaseOrderPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PurchaseOrderPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult SSAPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/SSAPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult SSAPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/SSAPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AVARPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/AVARPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AVARPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/AVARPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ATRAPendingRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/ATRAPendingRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult GeneralRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                return PartialView("/Views/Home/GeneralRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult InformativeNotifications(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                return PartialView("/Views/Home/InformativeNotifications.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult RequestApproval(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            IDashboardViewModel _dashboradViewModel = new DashboardViewModel();

            _dashboradViewModel.PersonID = Convert.ToInt32(PersonID);
            _dashboradViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _dashboradViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _dashboradViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _dashboradViewModel.TaskCode = TaskCode;
            _dashboradViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _dashboradViewModel.IsLastRecord = Convert.ToBoolean(IsLast);

            _dashboradViewModel.RequestApprovalFieldMasterList = GetListRequestApprovalField(Convert.ToInt32(TNMID));

            return View("/Views/Home/RequestApproval.cshtml", _dashboradViewModel);
        }


        [HttpGet]
        public ActionResult RequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            IDashboardViewModel _dashboradViewModel = new DashboardViewModel();

            _dashboradViewModel.PersonID = Convert.ToInt32(PersonID);
            _dashboradViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _dashboradViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _dashboradViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _dashboradViewModel.TaskCode = TaskCode;
            _dashboradViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _dashboradViewModel.IsLastRecord = Convert.ToBoolean(IsLast);

            _dashboradViewModel.RequestApprovalFieldMasterList = GetListRequestApprovalField(Convert.ToInt32(TNMID));

            return View("/Views/Home/RequestApprovalV2.cshtml", _dashboradViewModel);
        }

        [HttpGet]
        public ActionResult GeneralRequestApproval(string GRTID, string RequestCode)
        {
            IDashboardViewModel _dashboradViewModel = new DashboardViewModel();

            _dashboradViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
            _dashboradViewModel.GeneralRequestTransactionID = Convert.ToInt32(GRTID);
            _dashboradViewModel.RequestCode = RequestCode;

            _dashboradViewModel.GeneralRequestApprovalFieldMasterList = GetListGeneralRequestApprovalField(Convert.ToInt32(GRTID));

            return View("/Views/Home/GeneralRequestApproval.cshtml", _dashboradViewModel);
        }

        [HttpPost]
        public ActionResult RequestApproval(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.IsLastRecord = model.IsLastRecord;
                    model.DashboardDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                    model.DashboardDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                    model.DashboardDTO.ApprovalStatus = model.ApprovalStatus;
                    model.DashboardDTO.Remark = model.Remark;
                    model.DashboardDTO.PersonID = model.PersonID;
                    model.DashboardDTO.StageSequenceNumber = model.StageSequenceNumber;
                    model.DashboardDTO.TaskCode = model.TaskCode;
                    model.DashboardDTO.ApprovedByUserID = Convert.ToInt32(Session["UserID"]);
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.InsertDashboard(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult RequestApprovalV2(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.IsLastRecord = model.IsLastRecord;
                    model.DashboardDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                    model.DashboardDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                    model.DashboardDTO.ApprovalStatus = model.ApprovalStatus;
                    model.DashboardDTO.Remark = model.Remark;
                    model.DashboardDTO.PersonID = model.PersonID;
                    model.DashboardDTO.StageSequenceNumber = model.StageSequenceNumber;
                    model.DashboardDTO.TaskCode = model.TaskCode;
                    model.DashboardDTO.ApprovedByUserID = Convert.ToInt32(Session["UserID"]);
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.InsertDashboard(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult GeneralRequestApproval(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.Remark = model.Remark;
                    model.DashboardDTO.RequestCode = model.RequestCode;
                    model.DashboardDTO.ApprovalStatus = model.ApprovalStatus;
                    model.DashboardDTO.GeneralRequestTransactionID = model.GeneralRequestTransactionID;
                    model.DashboardDTO.ApprovedByUserID = Convert.ToInt32(Session["UserID"]);
                    model.DashboardDTO.PersonID = Convert.ToInt32(Session["PersonID"]);
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.GeneralRequestApprovalInsert(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult InformativeNotifications(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.NotificationTransactionID = model.NotificationTransactionID;
                    model.DashboardDTO.PersonID = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.InformativeNotificationsReadInsert(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ApproveAll(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "LA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult ApproveAllV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "LA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //Code for Approve All or Reject All Compensatory off day LeaveApplication
        [HttpPost]
        public ActionResult ApproveAllCODARequest(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "CODA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllCompensatoryLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //Code for Approve All or Reject All Compensatory off day LeaveApplication
        [HttpPost]
        public ActionResult ApproveAllCODARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "CODA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllCompensatoryLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //Code for Approve All or Reject All Manual LeaveApplication
        [HttpPost]
        public ActionResult ApproveAllMARequest(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "MA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllManualAttendanceApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //Code for Approve All or Reject All Manual LeaveApplication
        [HttpPost]
        public ActionResult ApproveAllMARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "MA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllManualAttendanceApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //Code for Approve All or Reject All Attendance Special Request LeaveApplication
        [HttpPost]
        public ActionResult ApproveAllSPARequest(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "ASA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllAttendanceSpecialRequestApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        [HttpPost]
        public ActionResult ApproveAllSPARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "ASA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _dashboardServiceAccess.ApproveAllAttendanceSpecialRequestApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region ---------------------Methods-ddd----------------------
        protected List<Dashboard> GetDashboardContentListByAdminRoleID(int AdminRoleMasterID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            List<Dashboard> ModuleList = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetDashboardContentListByAdminRoleID(searchRequest);
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

        protected List<Dashboard> GetListRequestApprovalField(int TaskNotificationMasterID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TaskNotificationMasterID = TaskNotificationMasterID;
            List<Dashboard> RequestApprovalFieldList = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetByRequestApprovalField(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    RequestApprovalFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return RequestApprovalFieldList;
        }

        protected List<Dashboard> GetListGeneralRequestApprovalField(int GeneralRequestTransactionID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralRequestTransactionID = GeneralRequestTransactionID;
            List<Dashboard> GeneralRequestApprovalFieldList = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetByGeneralRequestApprovalField(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    GeneralRequestApprovalFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return GeneralRequestApprovalFieldList;
        }

        public IEnumerable<DashboardViewModel> GetPendingLeaveRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.ApplicationDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ApplicationDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPendingLeaveRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPendingLeaveRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPendingLeaveRequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingInwardRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Onlinedb.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPendingLeaveRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPendingLeaveRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPendingLeaveRequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingFSAARequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listFSAARequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listFSAARequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFSAARequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingSAARequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listFSAARequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listFSAARequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFSAARequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingAVARRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "FirstName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listAVARRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listAVARRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAVARRequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetATRAPendingRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "AccountName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "AccountName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listATRARequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listATRARequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listATRARequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetGeneralPendingRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listGeneralRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingGeneralRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetGeneralRequestBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingGeneralRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingGeneralRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listGeneralRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetInformativeNotificationList(out int TotalRecords, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
            }
            List<DashboardViewModel> listInformativeNotificationViewModel = new List<DashboardViewModel>();
            List<Dashboard> listInformativeNotificationRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetInformativeNotificationListBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInformativeNotificationRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listInformativeNotificationRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listInformativeNotificationViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInformativeNotificationViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPendingLeaveRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPendingLeaveRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPendingLeaveRequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingPRRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "PurchaseRequirementNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "PurchaseRequirementNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listFSAARequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listFSAARequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFSAARequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingPORequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPORequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingPORequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingPORequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingPORequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPORequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPORequestViewModel;
        }

        public IEnumerable<DashboardViewModel> GetPendingPRQRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listFSAARequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listFSAARequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFSAARequestViewModel;
        }

        protected List<Dashboard> GetTaskCodeList(int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            if (Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IsOffLineApp"]) == 0)
            {
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            }
            else
            {
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Onlinedb.ConnectionString"]);
            }
            searchRequest.PersonID = PersonID;
            List<Dashboard> listTaskCode = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardServiceAccess.GetGeneralTaskModelListByPersonID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listTaskCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listTaskCode;
        }
        #endregion


        #region ----------------------AjaxHandler---------------------
        public ActionResult AjaxHandlerMyDataTablePendingLeaveRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingLeaveRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records
                         select new[] { Convert.ToString(c.Description)
                                       ,Convert.ToString(c.ApprovalStatus)
                                       ,Convert.ToString(c.MenuCodeLink)
                                       ,Convert.ToString(c.TaskNotificationDetailsID)
                                       ,Convert.ToString(c.TaskNotificationMasterID)
                                       ,Convert.ToString(c.GeneralTaskReportingDetailsID)
                                       ,Convert.ToString(c.StageSequenceNumber)
                                       ,Convert.ToString(c.IsLastRecordFlag)
                                       ,Convert.ToString(c.ApplicationDate)
                                       ,Convert.ToString(c.IsEngaged)
                                       ,(Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false))
                                       ,Convert.ToString(c.FromDate) + " - " + Convert.ToString(c.UptoDate)
                                       ,Convert.ToString(c.TotalfullDaysLeave)
                                       ,Convert.ToString(c.TotalHalfDayLeave)
                                       ,Convert.ToString(Convert.ToInt32(c.TotalDays) <= 1 ? c.TotalDays+ " Day" : c.TotalDays + " Days")
                                       ,Convert.ToString(c.CentreCode)
                                       ,Convert.ToString(c.EntityPKValue)
                                       ,Convert.ToString(c.LeaveMasterID)
                                       ,Convert.ToString(c.IsActiveMember)
                                       ,Convert.ToString(c.LeaveDescription)
                                       ,Convert.ToString(c.ApplicationStatus)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingManualAttendanceRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AttendanceDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AttendanceDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AttendanceDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AttendanceDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.AttendanceDate), Convert.ToString(c.CheckInTime), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingCompensatoryWorkDayRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.WorkingDate), Convert.ToString(c.CheckInTime), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason), Convert.ToString(c.EntityPKValue), Convert.ToString(c.CentreCode) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingLeaveAttendanceSpecialRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.RequestedDate), Convert.ToString(c.LeaveAttendanceSpecialDesctiption), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.CentreCode) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingInwardRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingInwardRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingInwardRequest = GetPendingInwardRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingInwardRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingInwardRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.IssueFromLocation), Convert.ToString(c.IssueToLocation), Convert.ToString(c.TransactionDate), Convert.ToString(c.IssueOrPurchaseID), Convert.ToString(c.InvInwardMasterID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingFSAARequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingFSAARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "FirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or SessionName Like '%" + param.sSearch + "%' or Descriptions Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SessionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or SessionName Like '%" + param.sSearch + "%' or Descriptions Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "Descriptions";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or SessionName Like '%" + param.sSearch + "%' or Descriptions Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "TotalFeeAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or SessionName Like '%" + param.sSearch + "%' or Descriptions Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingFSAARequest = GetPendingFSAARequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingFSAARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingFSAARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PendingRequestOfStudentRegistrationAcademicApproval(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePurchaseRequirementRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingFSAARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "PurchaseRequirementNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "Status";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingFSAARequest = GetPendingPRRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingFSAARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingFSAARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequirementNumber), Convert.ToString(c.TransDate) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePurchaseOrderRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingPORequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "F.PurchaseRequisitionNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "F.TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "H.Vender";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingPORequest = GetPendingPORequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingPORequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingPORequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.TransDate), Convert.ToString(c.Vendor) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePurchaseRequsitionRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingFSAARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "PurchaseRequisitionNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequsitionNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "Status";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingFSAARequest = GetPendingPRQRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingFSAARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingFSAARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.TransDate) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingSSARequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "FirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or SectionDescription Like '%" + param.sSearch + "%' or ScholarShipDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or SectionDescription Like '%" + param.sSearch + "%' or ScholarShipDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "SectionDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or SectionDescription Like '%" + param.sSearch + "%' or ScholarShipDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ScholarShipDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "FirstName Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or SectionDescription Like '%" + param.sSearch + "%' or ScholarShipDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingSSARequest = GetPendingSAARequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingSSARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApproveStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TransDate), Convert.ToString(c.ScholarShipDescription), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingAVARRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TransactionDate Like '%" + param.sSearch + "%' or VoucherNumber Like '%" + param.sSearch + "%' or NarrationDescription Like '%" + param.sSearch + "%' or IsPosted Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "VoucherNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TransactionDate Like '%" + param.sSearch + "%' or VoucherNumber Like '%" + param.sSearch + "%' or NarrationDescription Like '%" + param.sSearch + "%' or IsPosted Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "NarrationDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TransactionDate Like '%" + param.sSearch + "%' or VoucherNumber Like '%" + param.sSearch + "%' or NarrationDescription Like '%" + param.sSearch + "%' or IsPosted Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "IsPosted";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TransactionDate Like '%" + param.sSearch + "%' or VoucherNumber Like '%" + param.sSearch + "%' or NarrationDescription Like '%" + param.sSearch + "%' or IsPosted Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingSSARequest = GetPendingAVARRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingSSARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApproveStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.TransDate), Convert.ToString(c.VoucherNumber), Convert.ToString(c.Narration), Convert.ToString(c.AccTransactionMainID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTableATRAPendingRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "AccountName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%' or OldSalesManName Like '%" + param.sSearch + "%' or RequestedSalesManName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "OldSalesManName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%' or OldSalesManName Like '%" + param.sSearch + "%' or RequestedSalesManName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "RequestedSalesManName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AccountName Like '%" + param.sSearch + "%' or OldSalesManName Like '%" + param.sSearch + "%' or RequestedSalesManName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingSSARequest = GetATRAPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingSSARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.AccountTransferRequestID), Convert.ToString(c.AccountTransferRequestReason), Convert.ToString(c.AccountName), Convert.ToString(c.AccountTransferRequestStatus), Convert.ToString(c.AccountType), Convert.ToString(c.OldSalesManName), Convert.ToString(c.RequestedSalesManName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTableGeneralRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "G.RequestDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "G.RequestDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingSSARequest = GetGeneralPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingSSARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.RequestDescription), Convert.ToString(c.RequestsStatus), Convert.ToString(c.RequestsLinkMenuCode), Convert.ToString(c.GeneralRequestTransactionID), Convert.ToString(c.FromUserName), Convert.ToString(c.PrimaryKeyValue), Convert.ToString(c.RequestCode) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerInformativeNotificationsList(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            int PersonID = Convert.ToInt32(Session["PersonID"]);

            filteredPendingSSARequest = GetInformativeNotificationList(out TotalRecords, PersonID);

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.NotificationTransactionID), Convert.ToString(c.TransactionDate), Convert.ToString(c.SubjectDescription), Convert.ToString(c.BodyDescription), Convert.ToString(c.NotificationStatus) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            // check  sessions here
            if (HttpContext.Current.Session["UserId"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
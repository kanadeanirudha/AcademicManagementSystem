﻿using AMS.Base.DTO;
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
    public class LeaveEmployeeApplicationStatusReportController : BaseController
    {
        ILeaveEmployeeApplicationStatusReportServiceAccess _LeaveEmployeeApplicationStatusReportServiceAccess = null;
        IOrganisationDepartmentMasterServiceAccess _OrganisationDepartmentMasterServiceAccess = null;
        ILeaveEmployeeApplicationStatusReportViewModel _LeaveEmployeeApplicationStatusReportViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveEmployeeApplicationStatusReportController()
        {
            _LeaveEmployeeApplicationStatusReportServiceAccess = new LeaveEmployeeApplicationStatusReportServiceAccess();
            _OrganisationDepartmentMasterServiceAccess = new OrganisationDepartmentMasterServiceAccess();
            _LeaveEmployeeApplicationStatusReportViewModel = new LeaveEmployeeApplicationStatusReportViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                return View("/Views/Leave/LeaveEmployeeApplicationStatusReport/Index.cshtml");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centreCode, string departmentIDs, string approvalStatus, string fromDate, string uptoDate)
        {
            try
            {
                LeaveEmployeeApplicationStatusReportViewModel model = new LeaveEmployeeApplicationStatusReportViewModel();
                int AdminRoleMasterID = 0;

                List<SelectListItem> ApprovalStatusList = new List<SelectListItem>();
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_ALL, Value = "All" });
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_Pending, Value = "Pending" });
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_Approved, Value = "Approved" });
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_Reject, Value = "Reject" });
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_InProcess, Value = "In-Process" });
                ApprovalStatusList.Add(new SelectListItem { Text = Resources.DropdownMessage_Canceled, Value = "Cancelled" });
                ViewData["ApprovalStatus"] = new SelectList(ApprovalStatusList, "Value", "Text", approvalStatus);
                if (!string.IsNullOrEmpty(centreCode))
                {
                    string[] splitCentreCode = centreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                }
                else
                {
                    model.CentreCode = centreCode;
                    //_LeaveEmployeeApplicationStatusReportViewModel.EntityLevel = null;
                }
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
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    model.EntityLevel = "Centre";

                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
                }
                else
                {

                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in model.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                }
                if (!string.IsNullOrEmpty(centreCode))
                {
                    string[] splitCentreCode = centreCode.Split(':');
                    model.ListGetOrganisationDepartmentCentreAndRoleWise = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);
                }
                model.SelectedCentreCode = centreCode;

                if (departmentIDs != null )
                    model.SelectedDepartmentIDs = departmentIDs.Substring(1);

                model.SelectedDepartmentID = model.SelectedDepartmentIDs;
                model.ApprovalStatus = approvalStatus;
                model.FromDate = fromDate;
                model.UptoDate = uptoDate;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveEmployeeApplicationStatusReport/List.cshtml", model);
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

        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = SelectedCentreCode.Split(':');
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public IEnumerable<LeaveEmployeeApplicationStatusReportViewModel> GetLeaveEmployeeApplicationStatusReportRecords(out int TotalRecords, string CentreCode, string DepartmentIds, string ApprovalStatus, string FromDate, string UptoDate, int EmployeeID)
        {
            LeaveEmployeeApplicationStatusReportSearchRequest searchRequest = new LeaveEmployeeApplicationStatusReportSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
                searchRequest.DepartmentIds = DepartmentIds;
                searchRequest.ApprovalStatus = ApprovalStatus;
                searchRequest.FromDate = FromDate;
                searchRequest.UptoDate = UptoDate;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<LeaveEmployeeApplicationStatusReportViewModel> listLeaveEmployeeApplicationStatusReportViewModel = new List<LeaveEmployeeApplicationStatusReportViewModel>();
            List<LeaveEmployeeApplicationStatusReport> listLeaveEmployeeApplicationStatusReport = new List<LeaveEmployeeApplicationStatusReport>();
            IBaseEntityCollectionResponse<LeaveEmployeeApplicationStatusReport> baseEntityCollectionResponse = _LeaveEmployeeApplicationStatusReportServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveEmployeeApplicationStatusReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveEmployeeApplicationStatusReport item in listLeaveEmployeeApplicationStatusReport)
                    {
                        LeaveEmployeeApplicationStatusReportViewModel _LeaveEmployeeApplicationStatusReportViewModel = new LeaveEmployeeApplicationStatusReportViewModel();
                        _LeaveEmployeeApplicationStatusReportViewModel.LeaveEmployeeApplicationStatusReportDTO = item;
                        listLeaveEmployeeApplicationStatusReportViewModel.Add(_LeaveEmployeeApplicationStatusReportViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveEmployeeApplicationStatusReportViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode, string SelectedDepartmentIDs, string ApprovalStatus, string FromDate, string UptoDate)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveEmployeeApplicationStatusReportViewModel> filteredLeaveEmployeeApplicationStatusReport;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "DepartmentName ,EmployeeFullName,Dates";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or EmployeeFullName Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "LeaveDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or EmployeeFullName Like '%" + param.sSearch + "%'";

                    }
                    break;

                case 2:
                    _sortBy = "ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or EmployeeFullName Like '%" + param.sSearch + "%'";

                    }
                    break;
                case 3:
                    _sortBy = "Dates";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or EmployeeFullName Like '%" + param.sSearch + "%'";
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //if (SelectedDepartmentIDs == "")
            //    SelectedDepartmentIDs = "";

            if (!string.IsNullOrEmpty(SelectedCentreCode))
            {

                string[] splitCentreCode = SelectedCentreCode.Split(':');
                var centreCode = splitCentreCode[0];
                var EmployeeID = 0;
                if (splitCentreCode[1].ToString() == "SELF")
                {
                    EmployeeID = Convert.ToInt32(Session["PersonID"]);
                }
                filteredLeaveEmployeeApplicationStatusReport = GetLeaveEmployeeApplicationStatusReportRecords(out TotalRecords, centreCode, SelectedDepartmentIDs, ApprovalStatus, FromDate, UptoDate, EmployeeID);
            }
            else
            {
                filteredLeaveEmployeeApplicationStatusReport = new List<LeaveEmployeeApplicationStatusReportViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveEmployeeApplicationStatusReport.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeFullName + " (" + c.DepartmentName + ")"), Convert.ToString(c.LeaveType), Convert.ToString(c.ApplicationDate), Convert.ToString(c.Dates), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.FullDayHalfDayStatus) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
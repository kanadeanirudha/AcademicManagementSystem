﻿using System;
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

namespace AMS.Web.UI.Controllers
{
    public class LeaveApplicationReportController : BaseController
    {
        IEmpEmployeeMasterServiceAccess _empEmployeeMasterServiceAccess = null;
        ILeaveSessionServiceAccess _leaveSessionServiceAccess = null;
        ILeaveApplicationServiceAccess _LeaveApplicationServiceAccess = null;
        ILeaveSummaryServiceAccess _LeaveSummaryServiceAccess = null;
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

        public LeaveApplicationReportController()
        {
            _empEmployeeMasterServiceAccess = new EmpEmployeeMasterServiceAccess();
            _leaveSessionServiceAccess = new LeaveSessionServiceAccess();
            _LeaveApplicationServiceAccess = new LeaveApplicationServiceAccess();
            _LeaveSummaryServiceAccess = new LeaveSummaryServiceAccess();
        }
        // GET: /LeaveApplicationSelf/

        //  Controller Methods
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            LeaveApplicationViewModel _leaveApplicationViewModel = new LeaveApplicationViewModel();

            //For getting centreCode
            EmpEmployeeMasterViewModel empEmployeeMastermodel = new EmpEmployeeMasterViewModel();
            empEmployeeMastermodel.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
            empEmployeeMastermodel.EmpEmployeeMasterDTO.ID = Convert.ToInt32(Session["PersonID"]);
            IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterServiceAccess.SelectByID(empEmployeeMastermodel.EmpEmployeeMasterDTO);
            if (response.Entity != null)
            {
                _leaveApplicationViewModel.CentreCode = response.Entity.CentreCode;
                _leaveApplicationViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);

                LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.EmployeeID = _leaveApplicationViewModel.EmployeeID;
                searchRequest.CentreCode = _leaveApplicationViewModel.CentreCode;
                IBaseEntityResponse<LeaveSession> response1 = _leaveSessionServiceAccess.SelectByEmployeeIDAndCentreCode(searchRequest);
                _leaveApplicationViewModel.LeaveSessionID = response1.Entity.LeaveSessionID;
                _leaveApplicationViewModel.LeaveSession = response1.Entity.LeaveSessionName;

                List<LeaveMaster> LeaveMasterList = GetListLeaveMaster();
                List<SelectListItem> leaveMaster = new List<SelectListItem>();
                foreach (LeaveMaster item in LeaveMasterList)
                {
                    // leaveMaster.Add(new SelectListItem { Text = item.LeaveDescription, Value = (item.ID + "~" + item.LeaveCode).ToString().Trim() });
                    leaveMaster.Add(new SelectListItem { Text = item.LeaveDescription, Value = (item.ID).ToString().Trim() });
                }
                ViewBag.LeaveMaster = new SelectList(leaveMaster, "Value", "Text");
            }
            return View("/Views/Leave/LeaveApplicationReport/Index.cshtml", _leaveApplicationViewModel);
        }

        public ActionResult List(string actionMode, string EmployeeID, string LeaveSessionID)
        {
            try
            {
                ILeaveApplicationViewModel _leaveApplicationViewModel = new LeaveApplicationViewModel();
                _leaveApplicationViewModel.EmployeeID = Convert.ToInt32(EmployeeID);
                _leaveApplicationViewModel.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveApplicationReport/List.cshtml", _leaveApplicationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LeaveApplicationViewModel _LeaveApplicationViewModel)
        {
            try
            {
                _LeaveApplicationViewModel.LeaveApplicationDTO.EmployeeID = _LeaveApplicationViewModel.EmployeeID;
                _LeaveApplicationViewModel.LeaveApplicationDTO.LeaveMasterID = _LeaveApplicationViewModel.LeaveMasterID;
                _LeaveApplicationViewModel.LeaveApplicationDTO.FromDate = _LeaveApplicationViewModel.FromDate;
                _LeaveApplicationViewModel.LeaveApplicationDTO.UptoDate = _LeaveApplicationViewModel.UptoDate;
                _LeaveApplicationViewModel.LeaveApplicationDTO.TotalfullDaysLeave = _LeaveApplicationViewModel.TotalfullDaysLeave;
                _LeaveApplicationViewModel.LeaveApplicationDTO.TotalHalfDayLeave = _LeaveApplicationViewModel.TotalHalfDayLeave;
                _LeaveApplicationViewModel.LeaveApplicationDTO.IsFirstHalf = _LeaveApplicationViewModel.IsFirstHalf;
                _LeaveApplicationViewModel.LeaveApplicationDTO.IsSecondHalf = _LeaveApplicationViewModel.IsSecondHalf;
                //_LeaveApplicationViewModel.LeaveApplicationDTO.HalfLeaveStatus = _LeaveApplicationViewModel.HalfLeaveStatus;
                _LeaveApplicationViewModel.LeaveApplicationDTO.LeaveReason = _LeaveApplicationViewModel.LeaveReason;
                _LeaveApplicationViewModel.LeaveApplicationDTO.LeaveSessionID = _LeaveApplicationViewModel.LeaveSessionID;
                _LeaveApplicationViewModel.LeaveApplicationDTO.CentreCode = _LeaveApplicationViewModel.CentreCode;
                _LeaveApplicationViewModel.LeaveApplicationDTO.LeaveRuleMasterID = _LeaveApplicationViewModel.LeaveRuleMasterID;
                _LeaveApplicationViewModel.LeaveApplicationDTO.IsActive = true;
                _LeaveApplicationViewModel.LeaveApplicationDTO.ApplicationStatus = "PENDING";
                _LeaveApplicationViewModel.LeaveApplicationDTO.PendingAtApprovalLevel = 1;
                _LeaveApplicationViewModel.LeaveApplicationDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                _LeaveApplicationViewModel.LeaveApplicationDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<LeaveApplication> response = _LeaveApplicationServiceAccess.InsertLeaveApplication(_LeaveApplicationViewModel.LeaveApplicationDTO);
                _LeaveApplicationViewModel.LeaveApplicationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(_LeaveApplicationViewModel.LeaveApplicationDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + _LeaveApplicationViewModel);
        }

        #endregion

        // Non-Action Method
        #region ---------------------Methods-ddd----------------------

        public IEnumerable<LeaveApplicationViewModel> GetLeaveApplicationStatus(out int TotalRecords, int EmployeeID, int LeaveSessionID)
        {
            LeaveApplicationSearchRequest searchRequest = new LeaveApplicationSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                    searchRequest.LeaveSessionID = LeaveSessionID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                    searchRequest.LeaveSessionID = LeaveSessionID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
                searchRequest.LeaveSessionID = LeaveSessionID;
            }
            List<LeaveApplicationViewModel> listLeaveApplicationViewModel = new List<LeaveApplicationViewModel>();
            List<LeaveApplication> listLeaveApplication = new List<LeaveApplication>();
            IBaseEntityCollectionResponse<LeaveApplication> baseEntityCollectionResponse = _LeaveApplicationServiceAccess.GetLeaveApplicationStatusByEmployeeID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveApplication = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveApplication item in listLeaveApplication)
                    {
                        LeaveApplicationViewModel LeaveApplicationViewModel = new LeaveApplicationViewModel();
                        LeaveApplicationViewModel.LeaveApplicationDTO = item;
                        listLeaveApplicationViewModel.Add(LeaveApplicationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveApplicationViewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLeaveDetailsByLeaveMaster_Employee_LeaveSessionID(int LeaveMasterID, int EmployeeID, int LeaveSessionID)
        {
            ILeaveApplicationViewModel leaveApplicationViewModel = new LeaveApplicationViewModel();
            leaveApplicationViewModel.LeaveMasterID = LeaveMasterID;
            leaveApplicationViewModel.EmployeeID = EmployeeID;
            leaveApplicationViewModel.LeaveSessionID = LeaveSessionID;

            var leaveDetails = GetLeaveDetailsByLeaveMasterID(leaveApplicationViewModel.LeaveMasterID, leaveApplicationViewModel.EmployeeID, leaveApplicationViewModel.LeaveSessionID);
            double[] result = new double[3];
            if (leaveDetails != null)
            {
                result = new double[4] { leaveDetails.NumberOfLeaves, leaveDetails.MaxLeaveAtTime, leaveDetails.BalanceLeave, leaveDetails.ID };
            } //  = from c in leaveDetails select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.LeaveCode), Convert.ToString(c.NumberOfLeaves), Convert.ToString(c.TotalFullDayUtilized), Convert.ToString(c.TotalHalfDayUtilized), Convert.ToString(c.BalanceLeave) };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AjaxHandler Method
        #region ----------------------AjaxHandler---------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string EmployeeID, string LeaveSessionID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveApplicationViewModel> filteredLeaveApplication;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveDescription,ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveDescription,ApplicationDate Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or TotalFullDayUtilized Like '%" + param.sSearch + "%' or TotalHalfDayUtilized Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveDescription,ApplicationDate Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or TotalFullDayUtilized Like '%" + param.sSearch + "%' or TotalHalfDayUtilized Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "NumberOfLeaves";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveDescription,ApplicationDate Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or TotalFullDayUtilized Like '%" + param.sSearch + "%' or TotalHalfDayUtilized Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "TotalFullDayUtilized";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveDescription,ApplicationDate Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or TotalFullDayUtilized Like '%" + param.sSearch + "%' or TotalHalfDayUtilized Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "TotalHalfDayUtilized";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveDescription,ApplicationDate Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or TotalFullDayUtilized Like '%" + param.sSearch + "%' or TotalHalfDayUtilized Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredLeaveApplication = GetLeaveApplicationStatus(out TotalRecords, Convert.ToInt32(EmployeeID), Convert.ToInt32(LeaveSessionID));
            var records = filteredLeaveApplication.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.ApplicationDate), Convert.ToString(c.NumberOfLeaves), Convert.ToString(c.ApplicationStatus), Convert.ToString(c.NumberOfApprovalStages), Convert.ToString(c.PendingAtApprovalLevel), Convert.ToString(c.FromDate), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.FullDayHalfDayFlag), Convert.ToString(c.ApprovalStatusList) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}

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
    public class CRMJobCreationMasterAndAllocationController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        ICRMJobCreationMasterAndAllocationServiceAccess _cRMJobCreationMasterAndAllocationServiceAccess = null;
        ICRMCallEnquiryDetailsServiceAccess _cRMCallEnquiryDetailsServiceAccess = null;
        IEmpEmployeeMasterServiceAccess _empEmployeeMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CRMJobCreationMasterAndAllocationController()
        {
            _cRMJobCreationMasterAndAllocationServiceAccess = new CRMJobCreationMasterAndAllocationServiceAccess();
            _cRMCallEnquiryDetailsServiceAccess = new CRMCallEnquiryDetailsServiceAccess();
            _empEmployeeMasterServiceAcess = new EmpEmployeeMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(string ID)
        {
            ICRMJobCreationMasterAndAllocationViewModel _cRMJobCreationMasterAndAllocationmodel = new CRMJobCreationMasterAndAllocationViewModel();
            _cRMJobCreationMasterAndAllocationmodel.ListCallType = GetListCallType();
            ViewData["ViewMode"] = "Index";
            return PartialView("/Views/CRM/CRMJobCreationMasterAndAllocation/Index.cshtml", _cRMJobCreationMasterAndAllocationmodel);
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                ICRMJobCreationMasterAndAllocationViewModel _cRMJobCreationMasterAndAllocationmodel = new CRMJobCreationMasterAndAllocationViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRM/CRMJobCreationMasterAndAllocation/List.cshtml", _cRMJobCreationMasterAndAllocationmodel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(CRMJobCreationMasterAndAllocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CRMJobCreationMasterAndAllocationDTO != null)
                    {
                        model.CRMJobCreationMasterAndAllocationDTO.ConnectionString = _connectioString;
                        model.CRMJobCreationMasterAndAllocationDTO.JobStartDate = model.JobStartDate;
                        model.CRMJobCreationMasterAndAllocationDTO.JobEndDate = model.JobEndDate;
                        model.CRMJobCreationMasterAndAllocationDTO.CallTypeID = model.CallTypeID;
                        model.CRMJobCreationMasterAndAllocationDTO.JobName = model.JobName;
                        model.CRMJobCreationMasterAndAllocationDTO.JobAllocationDetailsXMLstring = model.JobAllocationDetailsXMLstring;
                        model.CRMJobCreationMasterAndAllocationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = _cRMJobCreationMasterAndAllocationServiceAccess.InsertCRMJobCreationMasterAndAllocation(model.CRMJobCreationMasterAndAllocationDTO);
                        model.CRMJobCreationMasterAndAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.CRMJobCreationMasterAndAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int ID, string Mode)
        {
            try
            {
                ICRMJobCreationMasterAndAllocationViewModel _cRMJobCreationMasterAndAllocationViewModel = new CRMJobCreationMasterAndAllocationViewModel();
                _cRMJobCreationMasterAndAllocationViewModel.JobCreationMasterID = ID;
                _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = _cRMJobCreationMasterAndAllocationServiceAccess.SelectByID(_cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO);

                if (response != null && response.Entity != null)
                {
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.JobCreationMasterID = response.Entity.JobCreationMasterID;
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.JobName = response.Entity.JobName;
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.JobCode = response.Entity.JobCode;
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.JobStartDate = response.Entity.JobStartDate;
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.JobEndDate = response.Entity.JobEndDate;
                    _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.CallTypeID = response.Entity.CallTypeID;

                    //----------------------------------Get Pending Call Enquiry count----------------------
                    CRMCallEnquiryDetails _cRMCallEnquiryDetails = new CRMCallEnquiryDetails();
                    _cRMCallEnquiryDetails.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                    _cRMCallEnquiryDetails.CallTypeID = Convert.ToInt16(response.Entity.CallTypeID);
                    IBaseEntityResponse<CRMCallEnquiryDetails> response1 = _cRMCallEnquiryDetailsServiceAccess.SelectPendingCallEnquiryCount(_cRMCallEnquiryDetails);
                    if (response1 != null && response1.Entity != null)
                    {
                        _cRMJobCreationMasterAndAllocationViewModel.CRMJobCreationMasterAndAllocationDTO.PendingCalls = response1.Entity.PendingCallEnquiryCount;
                    }
                }
                _cRMJobCreationMasterAndAllocationViewModel.ListCallType = GetListCallType();
                _cRMJobCreationMasterAndAllocationViewModel.CRMJobAllocationList = GetCRMJobAllocationList(_cRMJobCreationMasterAndAllocationViewModel.JobCreationMasterID);

                if (Mode == "Edit")
                {
                    return PartialView("/Views/CRM/CRMJobCreationMasterAndAllocation/Edit.cshtml", _cRMJobCreationMasterAndAllocationViewModel);
                }
                else
                {
                    return PartialView("/Views/CRM/CRMJobCreationMasterAndAllocation/ViewDetails.cshtml", _cRMJobCreationMasterAndAllocationViewModel);
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CRMJobCreationMasterAndAllocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CRMJobCreationMasterAndAllocationDTO != null)
                    {
                        if (model != null && model.CRMJobCreationMasterAndAllocationDTO != null)
                        {
                            model.CRMJobCreationMasterAndAllocationDTO.ConnectionString = _connectioString;
                            model.CRMJobCreationMasterAndAllocationDTO.JobCreationMasterID = model.JobCreationMasterID;
                            model.CRMJobCreationMasterAndAllocationDTO.JobCode = model.JobCode;
                            model.CRMJobCreationMasterAndAllocationDTO.JobEndDate = model.JobEndDate;
                            model.CRMJobCreationMasterAndAllocationDTO.JobAllocationDetailsXMLstring = model.JobAllocationDetailsXMLstring;
                            model.CRMJobCreationMasterAndAllocationDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = _cRMJobCreationMasterAndAllocationServiceAccess.UpdateCRMJobCreationMasterAndAllocation(model.CRMJobCreationMasterAndAllocationDTO);
                            model.CRMJobCreationMasterAndAllocationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CRMJobCreationMasterAndAllocationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region ------------CONTROLLER NON ACTION METHODS------------

        [NonAction]
        public List<CRMJobCreationMasterAndAllocation> GetListCRMJobCreationMasterAndAllocation(out int _totalRecords)
        {
            List<CRMJobCreationMasterAndAllocation> listCRMJobCreationMasterAndAllocation = new List<CRMJobCreationMasterAndAllocation>();
            CRMJobCreationMasterAndAllocationSearchRequest searchRequest = new CRMJobCreationMasterAndAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollectionResponse = _cRMJobCreationMasterAndAllocationServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMJobCreationMasterAndAllocation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            _totalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMJobCreationMasterAndAllocation;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CheckForDuplicateJobName(string selectedjobName)
        {
            bool _ExistsFlag = false;
            if (selectedjobName != string.Empty)
            {
                CRMJobCreationMasterAndAllocation _cRMJobCreationMasterAndAllocation = new CRMJobCreationMasterAndAllocation();
                _cRMJobCreationMasterAndAllocation.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _cRMJobCreationMasterAndAllocation.JobName = selectedjobName;
                IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = _cRMJobCreationMasterAndAllocationServiceAccess.SearchForDuplicateJobName(_cRMJobCreationMasterAndAllocation);
                if (response != null && response.Entity != null)
                {
                    _ExistsFlag = response.Entity.IsExists;
                }

            }
            return Json(Convert.ToString(_ExistsFlag), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEmployees(string term)
        {
            //var AdminRoleMasterID = Session["RoleID"].ToString();
            var data = GetEmployeeList(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                              roleId = r.AdminRoleMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetPendingCallEnquiry(string selectedCallTypeID)
        {
            int PendingCallEnquiryCount = 0;
            if (selectedCallTypeID != string.Empty)
            {
                CRMCallEnquiryDetails _cRMCallEnquiryDetails = new CRMCallEnquiryDetails();
                _cRMCallEnquiryDetails.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _cRMCallEnquiryDetails.CallTypeID = Convert.ToInt16(selectedCallTypeID);
                IBaseEntityResponse<CRMCallEnquiryDetails> response = _cRMCallEnquiryDetailsServiceAccess.SelectPendingCallEnquiryCount(_cRMCallEnquiryDetails);
                if (response != null && response.Entity != null)
                {
                    PendingCallEnquiryCount = response.Entity.PendingCallEnquiryCount;
                }

            }
            return Json(Convert.ToString(PendingCallEnquiryCount), JsonRequestBehavior.AllowGet);
        }

        protected List<CRMJobCreationMasterAndAllocation> GetCRMJobAllocationList(int jobCreationMasterID)
        {
            CRMJobCreationMasterAndAllocationSearchRequest searchRequest = new CRMJobCreationMasterAndAllocationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMJobCreationMasterAndAllocation> CRMJobAllocationList = new List<CRMJobCreationMasterAndAllocation>();
            searchRequest.JobCreationMasterID = jobCreationMasterID;

            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollectionResponse = _cRMJobCreationMasterAndAllocationServiceAccess.CRMJobAllocationList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMJobAllocationList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMJobAllocationList;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<CRMJobCreationMasterAndAllocation> filteredCRMJobCreationMasterAndAllocation;
            switch (Convert.ToInt32(sortColumnIndex))
            {

                case 0:
                    _sortBy = "JobName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobName Like '%" + param.sSearch + "%' or JobStartDate Like '%" + param.sSearch + "%' or CallTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.CreatedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                        sortDirection = "desc";
                    }
                    else
                    {
                        _searchBy = "JobName Like '%" + param.sSearch + "%' or JobStartDate Like '%" + param.sSearch + "%' or CallTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "JobCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobName Like '%" + param.sSearch + "%' or JobStartDate Like '%" + param.sSearch + "%' or CallTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "JobStartDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobName Like '%" + param.sSearch + "%' or JobStartDate Like '%" + param.sSearch + "%' or CallTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "JobEndDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobName Like '%" + param.sSearch + "%' or JobStartDate Like '%" + param.sSearch + "%' or CallTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCRMJobCreationMasterAndAllocation = GetListCRMJobCreationMasterAndAllocation(out TotalRecords);
            var records = filteredCRMJobCreationMasterAndAllocation.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.JobName), Convert.ToString(c.CallTypeDescription), Convert.ToString(c.JobCode), Convert.ToString(c.JobStartDate), Convert.ToString(c.JobEndDate), Convert.ToString(c.CallTypeID), Convert.ToString(c.JobCreationMasterID), Convert.ToString(false) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

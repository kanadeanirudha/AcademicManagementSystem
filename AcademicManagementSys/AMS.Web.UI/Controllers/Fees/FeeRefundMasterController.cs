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
    public class FeeRefundMasterController : BaseController
    {
        IFeeRefundMasterServiceAccess _FeeRefundMasterServiceAcess = null;
        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
        IFeeStructureMasterAndDetailsServiceAccess _feeStructureMasterAndDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        const int _recordsPerPage = 5;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public FeeRefundMasterController()
        {
            _FeeRefundMasterServiceAcess = new FeeRefundMasterServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
            _feeStructureMasterAndDetailsServiceAccess = new FeeStructureMasterAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            FeeRefundMasterViewModel model = new FeeRefundMasterViewModel();          
            return PartialView("/Views/Fees/FeeRefundMaster/Index.cshtml", model);
        }

        public ActionResult List(string actionMode, string centreCode)
        {
            try
            {
                FeeRefundMasterViewModel model = new FeeRefundMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.CentreCode = centreCode;
                return PartialView("/Views/Fees/FeeRefundMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int feeRefundID , Int16 balancesheetID)
        {
            FeeRefundMasterViewModel model = new FeeRefundMasterViewModel();
            model.AccountList = GetAccountList(balancesheetID);
            model.StudentPaymentDetails = GetStudentDetailsForRefund(feeRefundID);
            model.AccBalsheetID = balancesheetID;
            model.ID = feeRefundID;
            if (model.StudentPaymentDetails.Count > 0)
            {
                model.AccSessionID = model.StudentPaymentDetails[0].AccSessionID;
                model.AccountIDForStudentOutStanding = model.StudentPaymentDetails[0].AccountIDForStudentOutStanding;
                model.CentreCode = model.StudentPaymentDetails[0].CentreCode;
                model.AcademicYearID = model.StudentPaymentDetails[0].AcademicYearID;
                model.StudentName = model.StudentPaymentDetails[0].StudentName;
                model.EmailID = model.StudentPaymentDetails[0].EmailID;
                model.StudentPhoto = model.StudentPaymentDetails[0].StudentPhoto;
                model.AcademicYear = model.StudentPaymentDetails[0].SessionName;
                model.Course = model.StudentPaymentDetails[0].Course ;
                model.RefundAmount = model.StudentPaymentDetails[0].RefundAmount;
                model.Section = model.StudentPaymentDetails[0].SectionDetailsDesc;
                model.AdmissionPattern = model.StudentPaymentDetails[0].AdmissionPattern;
                model.StandardNumber = model.StudentPaymentDetails[0].StandardNumber;
                model.EnrollmentNumber = model.StudentPaymentDetails[0].EnrollmentNumber;
                model.Gender = model.StudentPaymentDetails[0].Gender ;
                model.AdmitAcademicYear = model.StudentPaymentDetails[0].AdmitAcademicYear;
                model.StudentID = model.StudentPaymentDetails[0].StudentID;   
            }
            return PartialView("~/Views/Fees/FeeRefundMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(FeeRefundMasterViewModel model)
        {
            try
            {
                model.FeeRefundMasterDTO.ConnectionString = _connectioString;
                model.FeeRefundMasterDTO.ID = model.ID;
                model.FeeRefundMasterDTO.StudentID = model.StudentID;
                model.FeeRefundMasterDTO.AccBalsheetID = model.AccBalsheetID;
                model.FeeRefundMasterDTO.AccSessionID = model.AccSessionID;
                model.FeeRefundMasterDTO.XmlString = model.XmlString;
                model.FeeRefundMasterDTO.IsRefundByCashOrBank = model.IsRefundByCashOrBank;
                model.FeeRefundMasterDTO.ChequeNumber = model.ChequeNumber;
                model.FeeRefundMasterDTO.ChequeDate = model.ChequeDate;
                model.FeeRefundMasterDTO.Remark = model.Remark;
                model.FeeRefundMasterDTO.RefundAmount = model.RefundAmount;
                model.FeeRefundMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeRefundMaster> response = _FeeRefundMasterServiceAcess.InsertFeeRefundMaster(model.FeeRefundMasterDTO);
                model.FeeRefundMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.FeeRefundMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult GetAccountListForFeeRefund(int balancesheetID, Int16 isCashOrBankFlag)
        {
            try
            {
                FeeRefundMasterSearchRequest SearchRequest = new FeeRefundMasterSearchRequest();
                SearchRequest.ConnectionString = _connectioString;
                SearchRequest.AccBalanceSheetID = balancesheetID;
                SearchRequest.IsChashOrBankFlag = isCashOrBankFlag; // 1 for cash & 2 for Bank
                List<FeeRefundMaster> accountList = new List<FeeRefundMaster>();
                IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollectionResponse = _FeeRefundMasterServiceAcess.GetAccountListForFeeRefund(SearchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        accountList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                var data = accountList;
                var result = (from s in data
                              select new
                              {
                                  id = s.AccountID,
                                  name = s.AccountName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        protected List<FeeRefundMaster> GetStudentDetailsForRefund(int feeRefundMasterID)
        {
            FeeRefundMasterSearchRequest searchRequest = new FeeRefundMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeRefundMaster> studentPaymentDetailsList = new List<FeeRefundMaster>();
            searchRequest.ID = feeRefundMasterID;
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollectionResponse = _FeeRefundMasterServiceAcess.GetStudentPaymentDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    studentPaymentDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return studentPaymentDetailsList;
        }

        [NonAction]
        protected List<FeeRefundMaster> GetAccountList(int balancesheetID)
        {

            FeeRefundMasterSearchRequest searchRequest = new FeeRefundMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeRefundMaster> accountList = new List<FeeRefundMaster>();
            searchRequest.AccBalanceSheetID = balancesheetID;
            searchRequest.IsChashOrBankFlag = 1; // 1 for cash & 2 for Bank
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollectionResponse = _FeeRefundMasterServiceAcess.GetAccountListForFeeRefund(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    accountList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return accountList;
        }


        [NonAction]
        public IEnumerable<FeeRefundMasterViewModel> GetFeeRefundMaster(string balanceSheetID, out int TotalRecords)
        {
            FeeRefundMasterSearchRequest searchRequest = new FeeRefundMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID =Convert.ToInt32(balanceSheetID);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "desc";
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
            List<FeeRefundMasterViewModel> listFeeRefundMasterViewModel = new List<FeeRefundMasterViewModel>();
            List<FeeRefundMaster> listFeeRefundMaster = new List<FeeRefundMaster>();
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollectionResponse = _FeeRefundMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeRefundMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeRefundMaster item in listFeeRefundMaster)
                    {
                        FeeRefundMasterViewModel FeeRefundMasterViewModel = new FeeRefundMasterViewModel();
                        FeeRefundMasterViewModel.FeeRefundMasterDTO = item;
                        listFeeRefundMasterViewModel.Add(FeeRefundMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeRefundMasterViewModel;
        }



        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string balanceSheetID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeRefundMasterViewModel> filteredFeeRefundMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "b.FirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "e.SessionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";  
                    }
                    break;

                case 2:
                    _sortBy = "a.RefundAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";  
                    }
                    break;
                case 3:
                    _sortBy = "a.RefundDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";  
                    }
                    break;
                case 4:
                    _sortBy = "a.IsRefundGiven";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";  
                    }
                    break;
                case 5:
                    _sortBy = "a.Remark";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "b.FirstName  Like '%" + param.sSearch + "%' or b.LastName  Like '%" + param.sSearch + "%' or e.SessionName Like '%" + param.sSearch + "%' or a.RefundAmount Like '%" + param.sSearch + "%' or a.RefundDate Like '%" + param.sSearch + "%' or a.IsRefundGiven Like '%" + param.sSearch + "%' or a.Remark Like '%" + param.sSearch + "%'   ";  
                    }                     
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(balanceSheetID))
            {
                var centreCode = balanceSheetID;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                filteredFeeRefundMaster = GetFeeRefundMaster(balanceSheetID, out TotalRecords);
            }
            else
            {
                filteredFeeRefundMaster = new List<FeeRefundMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredFeeRefundMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.RefundAmount), Convert.ToString(c.RefundDate), Convert.ToString(c.IsRefundGiven), Convert.ToString(c.Remark), Convert.ToString(c.CentreName), Convert.ToString(c.BranchDescription), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
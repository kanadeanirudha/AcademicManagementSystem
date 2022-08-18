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
    public class FeeReceiptMasterController : BaseController
    {
        IFeeReceiptMasterServiceAccess _FeeReceiptMasterServiceAcess = null;
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

        public FeeReceiptMasterController()
        {
            _FeeReceiptMasterServiceAcess = new FeeReceiptMasterServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
            _feeStructureMasterAndDetailsServiceAccess = new FeeStructureMasterAndDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            FeeReceiptMasterViewModel model = new FeeReceiptMasterViewModel();
            return View("/Views/Fees/FeeReceiptMaster/index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(FeeReceiptMasterViewModel model)
        {
            try
            {
                model.FeeReceiptMasterDTO.ConnectionString = _connectioString;
                model.FeeReceiptMasterDTO.CentreCode = model.CentreCode;
                model.FeeReceiptMasterDTO.AccBalanceSheetID = model.AccBalanceSheetID;
                model.FeeReceiptMasterDTO.FeeStructureMasterID= model.FeeStructureMasterID;
                model.FeeReceiptMasterDTO.AccountID = model.AccountID;    
                model.FeeReceiptMasterDTO.IsLumpsum = model.IsLumpsum;
                model.FeeReceiptMasterDTO.NextFeeReceivableDueListDetailsID = model.NextFeeReceivableDueListDetailsID;
                model.FeeReceiptMasterDTO.AccSessionId = model.AccSessionId;
                model.FeeReceiptMasterDTO.StudentID = model.StudentID;
                model.FeeReceiptMasterDTO.ReceiptAmount = model.ReceiptAmount;
                model.FeeReceiptMasterDTO.ReceiptType = model.ReceiptType;
                model.FeeReceiptMasterDTO.FeeBankName = model.FeeBankName;
                model.FeeReceiptMasterDTO.BranchName = model.BranchName;
                model.FeeReceiptMasterDTO.BranchCity = model.BranchCity;
                model.FeeReceiptMasterDTO.FeeChequeOrDDNumber = model.FeeChequeOrDDNumber;
                model.FeeReceiptMasterDTO.FeeChequeOrDDDate = model.FeeChequeOrDDDate;
                model.FeeReceiptMasterDTO.IschequeORDD = model.IschequeORDD;
                model.FeeReceiptMasterDTO.LateFeeAmount = model.LateFeeAmount;
                model.FeeReceiptMasterDTO.XMLstring = model.XMLstring;
                model.FeeReceiptMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<FeeReceiptMaster> response = _FeeReceiptMasterServiceAcess.InsertFeeReceiptMaster(model.FeeReceiptMasterDTO);
                model.FeeReceiptMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string feeCriteriaMasterID)
        {
            try
            {
                FeeReceiptMasterViewModel model = new FeeReceiptMasterViewModel();
                //if (!string.IsNullOrEmpty(actionMode))
                //{
                //    TempData["ActionMode"] = actionMode;

                //}
                //model.SelectedFeeCriteriaMasterID = feeCriteriaMasterID;
                //model.ListGetFeeCriteria = GetFeeCriteriaMasterAndDetails(Convert.ToInt16(Session["BalancesheetID"]));
                return PartialView("/Views/Fees/FeeReceiptMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

     


        public ActionResult GetStudentPaymentDetails(int studentID)
        {
            FeeReceiptMasterViewModel model = new FeeReceiptMasterViewModel();
            model.StudentPaymentDetails = GetStudentPaymentDetailsList(studentID);
            if (model.StudentPaymentDetails.Count >0)
            {
                model.FeeStructureMasterID = model.StudentPaymentDetails[0].FeeStructureMasterID;
                model.FeeCriteriaValueCombinationDescription = model.StudentPaymentDetails[0].FeeCriteriaValueCombinationDescription;
                model.IsLumpsum= model.StudentPaymentDetails[0].IsLumpsum;
                model.ScholarSheepDocumentNumber= model.StudentPaymentDetails[0].ScholarSheepDocumentNumber;
                model.ScholarShipOrDiscountAmount = model.StudentPaymentDetails[0].ScholarShipOrDiscountAmount;
                model.ScholarShipDescription = model.StudentPaymentDetails[0].ScholarShipDescription;
                model.IsScholarShipApplicable = model.StudentPaymentDetails[0].IsScholarShipApplicable;
                model.FeeReceivableStatus = model.StudentPaymentDetails[0].FeeReceivableStatus;
                model.CentreCode = model.StudentPaymentDetails[0].CentreCode;
                model.AccSessionId = model.StudentPaymentDetails[0].AccSessionId;
            }
            return PartialView("~/Views/Fees/FeeReceiptMaster/StudentPaymentDetails.cshtml", model);
        }

      


        #endregion

        // Non-Action Method
        #region Methods
        [HttpPost]
        public JsonResult GetStudentDetailsForFeeReceipt(string term, string balanceSheetID)
        {
            FeeReceiptMasterSearchRequest searchRequest = new FeeReceiptMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.AccBalanceSheetID = !string.IsNullOrEmpty(balanceSheetID) ? Convert.ToInt32(balanceSheetID) : 0;
            List<FeeReceiptMaster> listStudentDetails = new List<FeeReceiptMaster>();
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollectionResponse = _FeeReceiptMasterServiceAcess.GetStudentDetailsForFeeReceipt(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listStudentDetails
                          select new
                          {
                              studentId = r.StudentID,
                              studentName = r.StudentName,
                              gender = r.Gender,
                              enrollmentNumber = r.EnrollmentNumber,
                              standardNumber = r.StandardNumber,
                              admitAcademicYear = r.AdmitAcademicYear,
                              studentEmailID = r.StudentEmailID,
                              studentPhoto = r.StudentPhoto != null ? Convert.ToBase64String(r.StudentPhoto) : string.Empty,
                              studentPhotoFileHeight = r.StudentPhotoFileHeight,
                              studentPhotoFilename = r.StudentPhotoFilename,
                              studentPhotoFileWidth = r.StudentPhotoFileWidth,
                              studentPhotoType = r.StudentPhotoType,
                              branchDescription = r.BranchDescription,
                              branchShortCode = r.BranchShortCode,
                              admissionPattern = r.AdmissionPattern,
                              courseYearDesc = r.CourseYearDesc,
                              courseYearCode = r.CourseYearCode,
                              sectionDetailsDesc = r.SectionDetailsDesc,
                              sessionName = r.SessionName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAccountListForFeeReceipt(int balancesheetID, Int16 isCashOrBankFlag)
        {
            try
            {
                FeeReceiptMasterSearchRequest SearchRequest = new FeeReceiptMasterSearchRequest();
                SearchRequest.ConnectionString = _connectioString;
                SearchRequest.AccBalanceSheetID = balancesheetID;
                SearchRequest.IsChashOrBankFlag = isCashOrBankFlag; // 1 for cash & 2 for Bank
                List<FeeReceiptMaster> accountList = new List<FeeReceiptMaster>();
                IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollectionResponse = _FeeReceiptMasterServiceAcess.GetAccountListForFeeReceipt(SearchRequest);
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

        [NonAction]
        protected List<FeeReceiptMaster> GetStudentPaymentDetailsList(int studentID)
        {

            FeeReceiptMasterSearchRequest searchRequest = new FeeReceiptMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeReceiptMaster> listStudentPaymetDetails = new List<FeeReceiptMaster>();
            searchRequest.StudentID  = studentID;
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollectionResponse = _FeeReceiptMasterServiceAcess.GetStudentPaymentDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentPaymetDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listStudentPaymetDetails;
        }

        [NonAction]
        public IEnumerable<FeeReceiptMasterViewModel> GetFeeReceiptMaster(int feeCriteriaMasterId, int selectedBalsheetID, out int TotalRecords)
        {
            FeeReceiptMasterSearchRequest searchRequest = new FeeReceiptMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = selectedBalsheetID;
            searchRequest.FeeCriteriaMasterID = feeCriteriaMasterId;
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
            List<FeeReceiptMasterViewModel> listFeeReceiptMasterViewModel = new List<FeeReceiptMasterViewModel>();
            List<FeeReceiptMaster> listFeeReceiptMaster = new List<FeeReceiptMaster>();
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollectionResponse = _FeeReceiptMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeReceiptMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (FeeReceiptMaster item in listFeeReceiptMaster)
                    {
                        FeeReceiptMasterViewModel FeeReceiptMasterViewModel = new FeeReceiptMasterViewModel();
                        FeeReceiptMasterViewModel.FeeReceiptMasterDTO = item;
                        listFeeReceiptMasterViewModel.Add(FeeReceiptMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeReceiptMasterViewModel;
        }

        //[NonAction]
        //protected List<FeeReceiptMaster> GetFeeStructureCriteriaApprovalList(int personId, int taskNotificationMasterID)
        //{
        //    FeeReceiptMasterSearchRequest searchRequest = new FeeReceiptMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.PersonID = personId;
        //    searchRequest.TaskNotificationMasterID = taskNotificationMasterID;
        //    List<FeeReceiptMaster> listFeeApproval = new List<FeeReceiptMaster>();
        //    IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollectionResponse = _FeeReceiptMasterServiceAcess.GetFeeStructureCriteriaApprovalList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listFeeApproval = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listFeeApproval;
        //}

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string selectedFeeCriteriaMasterID, string selectedBalsheetID)
        {

            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeReceiptMasterViewModel> filteredFeeReceiptMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.FeeCriteriaValueCombinationDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like  '%" + param.sSearch + "%' ";
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(selectedBalsheetID) && !string.IsNullOrEmpty(selectedFeeCriteriaMasterID))
            {
                filteredFeeReceiptMaster = GetFeeReceiptMaster(Convert.ToInt32(selectedFeeCriteriaMasterID), Convert.ToInt32(selectedBalsheetID), out TotalRecords);
            }
            else
            {
                filteredFeeReceiptMaster = new List<FeeReceiptMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredFeeReceiptMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaValueCombinationDescription), Convert.ToString(Math.Round(c.TotalFeeAmount, 2)), Convert.ToString(c.IsInstallmentApplicable), Convert.ToString(c.StatusFlag), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureSessionMasterID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);


        }
        #endregion
    }
}
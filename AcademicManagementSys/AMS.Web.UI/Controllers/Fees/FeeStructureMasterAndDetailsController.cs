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
    public class FeeStructureMasterAndDetailsController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IFeeStructureMasterAndDetailsServiceAccess _feeStructureMasterAndDetailsServiceAccess = null;
        IFeeTypeAndSubTypeServiceAccess _feeTypeAndSubTypeServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        IFeeCriteriaMasterAndDetailsServiceAccess _feeCriteriaMasterAndDetailsServiceAccess = null;
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
        public FeeStructureMasterAndDetailsController()
        {
            _feeStructureMasterAndDetailsServiceAccess = new FeeStructureMasterAndDetailsServiceAccess();
            _feeTypeAndSubTypeServiceAccess = new FeeTypeAndSubTypeServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
            _feeCriteriaMasterAndDetailsServiceAccess = new FeeCriteriaMasterAndDetailsServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Fees/FeeStructureMasterAndDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string feeCriteriaMasterID)
        {
            try
            {

                FeeStructureMasterAndDetailsViewModel model = new FeeStructureMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;

                }
                model.SelectedFeeCriteriaMasterID = feeCriteriaMasterID;
                model.ListGetFeeCriteria = GetFeeCriteriaMasterAndDetails(Convert.ToInt16(Session["BalancesheetID"]));
                return PartialView("/Views/Fees/FeeStructureMasterAndDetails/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string FeeCriteriaCombinationDetails)
        {
            try
            {
                FeeStructureMasterAndDetailsViewModel model = new FeeStructureMasterAndDetailsViewModel();
                string[] criteriaDetails = FeeCriteriaCombinationDetails.Split('~');
                model.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(criteriaDetails[0]);
                model.FeeCriteriaCombinationName = (criteriaDetails[1].Replace('`', '&')).Replace('_',' ');

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "Lumpsum", Value = "0" });
                li1.Add(new SelectListItem { Text = "Installment", Value = "1" });
                ViewData["PaymentMode"] = li1;

                List<SelectListItem> li_NumberOfInstallment = new List<SelectListItem>();
                li_NumberOfInstallment.Add(new SelectListItem { Text = Resources.TableHeaders_NumberOfInstallment, Value = "0" });
                for (int i = 2; i <= 12; i++)
                {
                    li_NumberOfInstallment.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["NumberOfInstallment"] = li_NumberOfInstallment;

                return PartialView("/Views/Fees/FeeStructureMasterAndDetails/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Create(FeeStructureMasterAndDetailsViewModel model)
        {
            try
            {
                model.FeeStructureMasterAndDetailsDTO.ConnectionString = _connectioString;
                model.FeeStructureMasterAndDetailsDTO.FeeCriteriaValueCombinationMasterID = model.FeeCriteriaValueCombinationMasterID;
                model.FeeStructureMasterAndDetailsDTO.TotalFeeAmount = model.TotalFeeAmount;
                if (model.PaymentMode == "1")
                {
                    model.FeeStructureMasterAndDetailsDTO.IsInstallmentApplicable = true;
                }
                else
                {
                    model.FeeStructureMasterAndDetailsDTO.IsInstallmentApplicable = false;
                }
                model.FeeStructureMasterAndDetailsDTO.NumberOfInstallment = model.NumberOfInstallment;
                model.FeeStructureMasterAndDetailsDTO.IsLateFeeApplicable = model.IsLateFeeApplicable;
                model.FeeStructureMasterAndDetailsDTO.LateFeeID = model.LateFeeID;
                model.FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsIDs = model.XMLFeeStructureDetailsIDs;
                model.FeeStructureMasterAndDetailsDTO.XMLFeeStructureInstallmentMasterIDs = model.XMLFeeStructureInstallmentMasterIDs;
                model.FeeStructureMasterAndDetailsDTO.XMLFeeStructureDetailsInstallmentWiseIDs = model.XMLFeeStructureDetailsInstallmentWiseIDs;
                model.FeeStructureMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                model.FeeStructureMasterAndDetailsDTO.IsActive = true;

                model.FeeStructureMasterAndDetailsDTO.FeeAccountSubTypeMasterID = model.FeeAccountSubTypeMasterID;
                model.FeeStructureMasterAndDetailsDTO.AccountType = model.AccountType;
                model.FeeStructureMasterAndDetailsDTO.CrDrStatus = model.CrDrStatus;
                model.FeeStructureMasterAndDetailsDTO.AccountIDForFeeAccountSubTypeMaster = model.AccountIDForFeeAccountSubTypeMaster;

                //model.FeeStructureMasterAndDetailsDTO.SelectedFeeCriteriaMasterID = Convert.ToString(model.SelectedFeeCriteriaMasterID);                

                IBaseEntityResponse<FeeStructureMasterAndDetails> response = _feeStructureMasterAndDetailsServiceAccess.InsertFeeStructureMasterAndDetails(model.FeeStructureMasterAndDetailsDTO);
                model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult ViewStructureDetails(string StructureMasterIDAndDetails)
        {
            try
            {
                FeeStructureMasterAndDetailsViewModel model = new FeeStructureMasterAndDetailsViewModel();

                string[] criteriaDetails = StructureMasterIDAndDetails.Split('~');
                model.FeeCriteriaCombinationName = (criteriaDetails[1].Replace('`', '&')).Replace('_', ' ');
                model.FeeStructureMasterID = Convert.ToInt32(criteriaDetails[0]);

                model.FeeStructureMasterAndDetailsList = GetFeeStructureMasterAndDetailsByFeeStructureMasterID(model.FeeStructureMasterID);

                model.TotalFeeAmount = model.FeeStructureMasterAndDetailsList[0].TotalFeeAmount;
                if (model.FeeStructureMasterAndDetailsList[0].IsInstallmentApplicable == true)
                {
                    model.PaymentMode = "1";
                }
                else
                {
                    model.PaymentMode = "0";
                }
                model.NumberOfInstallment = model.FeeStructureMasterAndDetailsList[0].NumberOfInstallment;

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "Lumpsum", Value = "0" });
                li1.Add(new SelectListItem { Text = "Installment", Value = "1" });
                ViewData["PaymentMode"] = new SelectList(li1, "Value", "Text", model.PaymentMode);

                List<SelectListItem> li_NumberOfInstallment = new List<SelectListItem>();
                li_NumberOfInstallment.Add(new SelectListItem { Text = Resources.TableHeaders_NumberOfInstallment, Value = "0" });
                for (int i = 2; i <= 12; i++)
                {
                    li_NumberOfInstallment.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["NumberOfInstallment"] = new SelectList(li_NumberOfInstallment, "Value", "Text", model.NumberOfInstallment);

                return PartialView("/Views/Fees/FeeStructureMasterAndDetails/View.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //[HttpGet]
        //public ActionResult Delete(string StructureMasterIDAndDetails)
        //{
        //    try
        //    {
        //        FeeStructureMasterAndDetailsViewModel model = new FeeStructureMasterAndDetailsViewModel();
        //        model.FeeStructureMasterAndDetailsDTO = new FeeStructureMasterAndDetails();

        //        string[] criteriaDetails = StructureMasterIDAndDetails.Split('~');
        //        model.FeeStructureMasterID = Convert.ToInt32(criteriaDetails[0]);
        //        model.FeeCriteriaCombinationName = (criteriaDetails[1].Replace('`', '&')).Replace('_', ' '); ;
        //        return PartialView("/Views/Fees/FeeStructureMasterAndDetails/Delete.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}
        //[HttpPost]
        public ActionResult Delete(int structureMasterID, int feeCriteriaId)
        {
            try
            {
                    FeeStructureMasterAndDetailsViewModel model = new FeeStructureMasterAndDetailsViewModel();
                    FeeStructureMasterAndDetails FeeStructureMasterAndDetailsDTO = new FeeStructureMasterAndDetails();
                    model.FeeStructureMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.FeeStructureMasterAndDetailsDTO.FeeStructureMasterID = structureMasterID;
                    FeeStructureMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<FeeStructureMasterAndDetails> response = _feeStructureMasterAndDetailsServiceAccess.DeleteFeeStructureMasterAndDetails(model.FeeStructureMasterAndDetailsDTO);
                    model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    model.errorMessage = string.Concat(model.errorMessage, ",", feeCriteriaId);
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        //Non-Action method to fetch list of Balancesheet
        protected List<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByFeeStructureMasterID(int feeStructureMasterID)
        {

            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeStructureMasterAndDetails> listFeeStructureMasterAndDetails = new List<FeeStructureMasterAndDetails>();
            searchRequest.FeeStructureMasterID = feeStructureMasterID;
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetFeeStructureMasterAndDetailsByFeeStructureMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeStructureMasterAndDetails;
        }

        protected List<FeeCriteriaMasterAndDetails> GetFeeCriteriaMasterAndDetails(Int16 accBalanceSheetID)
        {

            FeeCriteriaMasterAndDetailsSearchRequest searchRequest = new FeeCriteriaMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeCriteriaMasterAndDetails> listFeeCriteriaMasterAndDetails = new List<FeeCriteriaMasterAndDetails>();
            searchRequest.AccBalanceSheetID = accBalanceSheetID;
            IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> baseEntityCollectionResponse = _feeCriteriaMasterAndDetailsServiceAccess.GetCriteriaMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeCriteriaMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listFeeCriteriaMasterAndDetails;
        }
        protected List<FeeStructureMasterAndDetails> GetFeeSubTypeList()
        {
            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<FeeStructureMasterAndDetails> listFeeSubType = new List<FeeStructureMasterAndDetails>();
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetFeeSubTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }
        public JsonResult GetFeeSubTypeSearchList(string term)
        {
            FeeTypeAndSubTypeSearchRequest searchRequest = new FeeTypeAndSubTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<FeeTypeAndSubType> listFeeTypeAndSubType = new List<FeeTypeAndSubType>();
            IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollectionResponse = _feeTypeAndSubTypeServiceAccess.GetFeeSubTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeTypeAndSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeTypeAndSubType
                          select new
                          {
                              feeSubTypeID = r.FeeSubTypeID + "~" + r.AccountID,
                              feeSubTypeDesc = r.FeeSubTypeDesc,                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<FeeStructureMasterAndDetails> GetListFeeStructureMasterAndDetails(int feeCriteriaMasterId, out int TotalRecords)
        {
            List<FeeStructureMasterAndDetails> listFeeStructureMasterAndDetails = new List<FeeStructureMasterAndDetails>();
            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            searchRequest.FeeCriteriaMasterID = feeCriteriaMasterId;
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
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeStructureMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFeeStructureMasterAndDetails;
        }

        public JsonResult GetFeeAccountTypeAndSubTypeList(string term, int feeAccountTypeCode)
        {
            FeeStructureMasterAndDetailsSearchRequest searchRequest = new FeeStructureMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.FeeAccountTypeCode = feeAccountTypeCode;
            List<FeeStructureMasterAndDetails> listFeeAccountTypeAndSubType = new List<FeeStructureMasterAndDetails>();
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollectionResponse = _feeStructureMasterAndDetailsServiceAccess.GetFeeAccountTypeAndSubTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeAccountTypeAndSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeAccountTypeAndSubType
                          select new
                          {
                              feeAccountSubTypeMasterID = r.FeeAccountSubTypeMasterID + "~" + r.AccountID + "~" + r.FeeAccountTypeMasterID,
                              feeAccountSubTypeDesc = r.FeeAccountSubTypeDesc                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedFeeCriteriaMasterID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<FeeStructureMasterAndDetails> filteredFeeStructureMasterAndDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "cte1.FeeCriteriaValueCombinationDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(cte1.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like '%" + param.sSearch + "%'  or A.NumberOfInstallment Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.TotalFeeAmount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(cte1.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like '%" + param.sSearch + "%'  or A.NumberOfInstallment Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.NumberOfInstallment";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(cte1.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like '%" + param.sSearch + "%'  or A.NumberOfInstallment Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.IsRevised";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(cte1.FeeCriteriaValueCombinationDescription Like '%" + param.sSearch + "%' or A.TotalFeeAmount Like '%" + param.sSearch + "%'  or A.NumberOfInstallment Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            _startRow = param.iDisplayStart;
            if (Convert.ToInt32(Session["BalancesheetID"]) > 0 && !string.IsNullOrEmpty(SelectedFeeCriteriaMasterID))
            {
                filteredFeeStructureMasterAndDetails = GetListFeeStructureMasterAndDetails(Convert.ToInt32(SelectedFeeCriteriaMasterID), out TotalRecords);
            }
            else
            {
                filteredFeeStructureMasterAndDetails = new List<FeeStructureMasterAndDetails>();
                TotalRecords = 0;
            }
            var records = filteredFeeStructureMasterAndDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.FeeCriteriaCombinationName), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.NumberOfInstallment), Convert.ToString(c.IsRevised), Convert.ToString(c.StatusFlag), Convert.ToString(c.FeeCriteriaValueCombinationMasterID), Convert.ToString(c.FeeStructureMasterID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

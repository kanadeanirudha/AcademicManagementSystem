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
    public class CRMSaleBillingTransactionController : BaseController
    {
        ICRMSaleBillingTransactionServiceAccess _CRMSaleBillingTransactionServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);


        public CRMSaleBillingTransactionController()
        {
            _CRMSaleBillingTransactionServiceAcess = new CRMSaleBillingTransactionServiceAccess();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/CRMSales/CRMSaleBillingTransaction/Index.cshtml");
        }

        public ActionResult List(string actionMode, int cRMSaleEnquiryAccountMasterID = 0)
        {
            try
            {
                CRMSaleBillingTransactionViewModel model = new CRMSaleBillingTransactionViewModel();

                //Int16 AccountProgressTypeID = 0;
                //Int32 CRMSaleEnquiryAccountMasterID = 0;
                //string term = "";
                int employeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleEnquiryAccountMasterID = cRMSaleEnquiryAccountMasterID;
                model.GetCRMSaleEnquiryAccountMasterList = GetAccountDetails("", 0,2, 0, employeID);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRMSales/CRMSaleBillingTransaction/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string enquriyDetails, string accountDetails)
        {
            CRMSaleBillingTransactionViewModel model = new CRMSaleBillingTransactionViewModel();

            string[] EnquriyDetails = enquriyDetails.Split('~');
            string[] AccountDetails = accountDetails.Split('~');

            model.CallEnquiryMasterID = Convert.ToInt32(EnquriyDetails[0]);
            model.EnquiryDesription = (EnquriyDetails[1]).Replace('_', ' ');

            model.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(AccountDetails[0]);
            model.AccountName = (AccountDetails[1]).Replace('_', ' ');

            List<GeneralCurrencyMaster> currency = GetGeneralCurrencyMaster();
            List<SelectListItem> CRMSaleCurrencyList = new List<SelectListItem>();
            foreach (GeneralCurrencyMaster item in currency)
            {
                CRMSaleCurrencyList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
            }

            ViewBag.GetGeneralCurrencyMasterList = new SelectList(CRMSaleCurrencyList, "Value", "Text");

            return PartialView("/Views/CRMSales/CRMSaleBillingTransaction/Create.cshtml", model);

        }

        [HttpPost]
        public ActionResult Create(CRMSaleBillingTransactionViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleBillingTransactionDTO != null)
                {
                    model.CRMSaleBillingTransactionDTO.ConnectionString = _connectioString;
                    model.CRMSaleBillingTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.CRMSaleBillingTransactionDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    model.CRMSaleBillingTransactionDTO.CallEnquiryMasterID = model.CallEnquiryMasterID;
                    model.CRMSaleBillingTransactionDTO.InvoiceDate = model.InvoiceDate;
                    model.CRMSaleBillingTransactionDTO.InvoiceNumber = model.InvoiceNumber;
                    model.CRMSaleBillingTransactionDTO.InvoiceAmount = model.InvoiceAmount;
                    model.CRMSaleBillingTransactionDTO.CurrencyCode = model.CurrencyCode;

                    IBaseEntityResponse<CRMSaleBillingTransaction> response = _CRMSaleBillingTransactionServiceAcess.InsertCRMSaleBillingTransaction(model.CRMSaleBillingTransactionDTO);
                    model.CRMSaleBillingTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleBillingTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CRMSaleBillingTransactionViewModel model = new CRMSaleBillingTransactionViewModel();

            try
            {
                model.CRMSaleBillingTransactionDTO = new CRMSaleBillingTransaction();
                model.CRMSaleBillingTransactionDTO.ConnectionString = _connectioString;
                model.CRMSaleBillingTransactionDTO.ID = ID;

                IBaseEntityResponse<CRMSaleBillingTransaction> response = _CRMSaleBillingTransactionServiceAcess.SelectByCRMSaleBillingTransactionID(model.CRMSaleBillingTransactionDTO);
                if (response != null && response.Entity != null)
                {
                    model.CallEnquiryMasterID = response.Entity.CallEnquiryMasterID;
                    model.EnquiryDesription = response.Entity.EnquiryDesription;
                    model.CRMSaleEnquiryAccountMasterID = response.Entity.CRMSaleEnquiryAccountMasterID;
                    model.AccountName = response.Entity.AccountName;
                    model.ID = response.Entity.ID;

                    model.InvoiceDate = response.Entity.InvoiceDate;
                    model.InvoiceNumber = response.Entity.InvoiceNumber;
                    model.InvoiceAmount = response.Entity.InvoiceAmount;
                    model.CurrencyCode = response.Entity.CurrencyCode;

                    List<GeneralCurrencyMaster> currency = GetGeneralCurrencyMaster();
                    List<SelectListItem> CRMSaleCurrencyList = new List<SelectListItem>();
                    foreach (GeneralCurrencyMaster item in currency)
                    {
                        CRMSaleCurrencyList.Add(new SelectListItem { Text = item.CurrencyCode, Value = Convert.ToString(item.ID) });
                    }

                    ViewBag.GetGeneralCurrencyMasterList = new SelectList(CRMSaleCurrencyList, "Value", "Text");
                }
                return PartialView("/Views/CRMSales/CRMSaleBillingTransaction/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CRMSaleBillingTransactionViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleBillingTransactionDTO != null)
                {
                    model.CRMSaleBillingTransactionDTO.ConnectionString = _connectioString;
                    model.CRMSaleBillingTransactionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);

                    model.CRMSaleBillingTransactionDTO.ID = model.ID;
                    model.CRMSaleBillingTransactionDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    model.CRMSaleBillingTransactionDTO.CallEnquiryMasterID = model.CallEnquiryMasterID;
                    model.CRMSaleBillingTransactionDTO.InvoiceDate = model.InvoiceDate;
                    model.CRMSaleBillingTransactionDTO.InvoiceNumber = model.InvoiceNumber;
                    model.CRMSaleBillingTransactionDTO.InvoiceAmount = model.InvoiceAmount;
                    model.CRMSaleBillingTransactionDTO.CurrencyCode = model.CurrencyCode;

                    IBaseEntityResponse<CRMSaleBillingTransaction> response = _CRMSaleBillingTransactionServiceAcess.UpdateCRMSaleBillingTransaction(model.CRMSaleBillingTransactionDTO);
                    model.CRMSaleBillingTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleBillingTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            CRMSaleBillingTransactionViewModel model = new CRMSaleBillingTransactionViewModel();
            if (Convert.ToInt64(ID) > 0)
            {
                IBaseEntityResponse<CRMSaleBillingTransaction> response = null;
                CRMSaleBillingTransaction CRMSaleBillingTransactionDTO = new CRMSaleBillingTransaction();
                CRMSaleBillingTransactionDTO.ConnectionString = _connectioString;
                CRMSaleBillingTransactionDTO.ID = Convert.ToInt32(ID);
                CRMSaleBillingTransactionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleBillingTransactionServiceAcess.DeleteCRMSaleBillingTransaction(CRMSaleBillingTransactionDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion



        //Non Action Method
        #region Methods



        public IEnumerable<CRMSaleBillingTransactionViewModel> GetCRMSaleBillingTransaction(int cRMSaleEnquiryAccountMasterID, out int TotalRecords)
        {
            CRMSaleBillingTransactionSearchRequest searchRequest = new CRMSaleBillingTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CRMSaleEnquiryAccountMasterID = cRMSaleEnquiryAccountMasterID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CRMSaleEnquiryAccountMasterID = cRMSaleEnquiryAccountMasterID;
            }
            List<CRMSaleBillingTransactionViewModel> listCRMSaleBillingTransactionVM = new List<CRMSaleBillingTransactionViewModel>();
            List<CRMSaleBillingTransaction> listCRMSaleBillingTransaction = new List<CRMSaleBillingTransaction>();
            IBaseEntityCollectionResponse<CRMSaleBillingTransaction> baseEntityCollectionResponse = _CRMSaleBillingTransactionServiceAcess.GetCRMSaleBillingTransactionSelectAll(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleBillingTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleBillingTransaction item in listCRMSaleBillingTransaction)
                    {
                        CRMSaleBillingTransactionViewModel CRMSaleBillingTransactionViewModel = new CRMSaleBillingTransactionViewModel();
                        CRMSaleBillingTransactionViewModel.CRMSaleBillingTransactionDTO = item;
                        listCRMSaleBillingTransactionVM.Add(CRMSaleBillingTransactionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCRMSaleBillingTransactionVM;
        }

        #endregion



        // AjaxHandler Method
        #region AjaxHandler

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int cRMSaleEnquiryAccountMasterID = 0)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleBillingTransactionViewModel> filteredCRMSaleBillingTransaction;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.EnquiryDesription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.InvoiceNumber Like '%" + param.sSearch + "%' or B.InvoiceDate Like '%" + param.sSearch + "%' or B.InvoiceAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.InvoiceNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.InvoiceNumber Like '%" + param.sSearch + "%' or B.InvoiceDate Like '%" + param.sSearch + "%' or B.InvoiceAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.InvoiceDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.InvoiceNumber Like '%" + param.sSearch + "%' or B.InvoiceDate Like '%" + param.sSearch + "%' or B.InvoiceAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.InvoiceAmount";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.InvoiceNumber Like '%" + param.sSearch + "%' or B.InvoiceDate Like '%" + param.sSearch + "%' or B.InvoiceAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;


                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (cRMSaleEnquiryAccountMasterID > 0)
                {
                    filteredCRMSaleBillingTransaction = GetCRMSaleBillingTransaction(cRMSaleEnquiryAccountMasterID, out TotalRecords);
                }
                else
                {
                    filteredCRMSaleBillingTransaction = new List<CRMSaleBillingTransactionViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCRMSaleBillingTransaction.Skip(0).Take(param.iDisplayLength);
                var result = from c in records
                             select new[] { 
                                                             Convert.ToString(c.ID), 
                                                             Convert.ToString(c.CallEnquiryMasterID), 
                                                             Convert.ToString(c.EnquiryDesription), 
                                                             Convert.ToString(c.CRMSaleEnquiryAccountMasterID), 
                                                             Convert.ToString(c.InvoiceNumber), 
                                                             Convert.ToString(c.InvoiceDate), 
                                                             Convert.ToString(c.InvoiceAmount),
                                                             Convert.ToString(c.AccountName)};
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion
    }
}

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

using System.IO;
using System.Net;
using System.Text;
using System.Data;

namespace AMS.Web.UI.Controllers
{
    public class CRMSaleEnquiryAccountMasterController : BaseController
    {
        ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = null;
        IGeneralIndustryMasterServiceAccess _GeneralIndustryMasterServiceAccess = null;
        ICRMSaleAccountProgressTypeMasterAndRuleServiceAccess _CRMSaleAccountProgressTypeMasterAndRuleServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleEnquiryAccountMasterController()
        {
            _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = new CRMSaleEnquiryMasterAndAccountDetailsServiceAccess();
            _GeneralIndustryMasterServiceAccess = new GeneralIndustryMasterServiceAccess();
            _CRMSaleAccountProgressTypeMasterAndRuleServiceAccess = new CRMSaleAccountProgressTypeMasterAndRuleServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string SearchQuery)
        {
            try
            {
                CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();

                if (!string.IsNullOrEmpty(SearchQuery))
                {
                    model.ProgressType = SearchQuery;
                }

                return View("/Views/CRMSales/CRMSaleEnquiryAccountMaster/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult ListAllAccounts(string SearchQuery)
        {
            try
            {
                CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();

                if (!string.IsNullOrEmpty(SearchQuery))
                {
                    //TempData["SearchQuery"] = SearchQuery;
                    model.ProgressType = SearchQuery;
                }

                return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountMaster/ListAllAccounts.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Create()
        {
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();

            List<GeneralIndustryMaster> GeneralIndustryMaster = GetListGeneralIndustryMaster();
            List<SelectListItem> GeneralIndustryMasterList = new List<SelectListItem>();
            foreach (GeneralIndustryMaster item in GeneralIndustryMaster)
            {
                GeneralIndustryMasterList.Add(new SelectListItem { Text = item.IndustryName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralIndustryMasterList = new SelectList(GeneralIndustryMasterList, "Value", "Text");


            List<CRMSaleAccountProgressTypeMasterAndRule> CRMSaleAccountProgressTypeMaster = GetListCRMSaleAccountProgressTypeMaster();
            List<SelectListItem> CRMSaleAccountProgressTypeMasterList = new List<SelectListItem>();
            foreach (CRMSaleAccountProgressTypeMasterAndRule item in CRMSaleAccountProgressTypeMaster)
            {
                CRMSaleAccountProgressTypeMasterList.Add(new SelectListItem { Text = item.ProgressType, Value = Convert.ToString(item.CRMSaleAccountProgressTypeID) });
            }
            ViewBag.CRMSaleAccountProgressTypeMasterList = new SelectList(CRMSaleAccountProgressTypeMasterList, "Value", "Text");

            return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CRMSaleEnquiryMasterAndAccountDetailsViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (model != null && model.CRMSaleEnquiryMasterAndAccountDetailsDTO != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountType = model.AccountType;

                    if (model.AccountType == 1)
                    {
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName = model.AccountName;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterAddress = model.EnquiryAccountMasterAddress;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCity = model.EnquiryAccountMasterCity;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCountry = model.EnquiryAccountMasterCountry;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMAccountProgressTypeID = model.CRMAccountProgressTypeID;
                    }
                    else if (model.AccountType == 2)
                    {
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName = string.Concat(model.FirstName, " ", model.LastName);
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterAddress = model.EnquiryAccountContactPersonAddress;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCity = model.EnquiryAccountContactPersonCity;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCountry = model.EnquiryAccountContactPersonCountry;
                        model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMAccountProgressTypeID = 1;
                    }

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ApproxAnnualAmount = model.ApproxAnnualAmount;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.GeneralIndustryMasterID = model.GeneralIndustryMasterID;


                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName = model.FirstName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName = model.LastName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation = model.Designation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber = model.MobileNumber;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId = model.EmailId;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress = model.EnquiryAccountContactPersonAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin = model.Pin;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLocation = model.EnquiryAccountContactPersonLocation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity = model.EnquiryAccountContactPersonCity;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry = model.EnquiryAccountContactPersonCountry;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.VisitingCardName = model.VisitingCardName;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                    IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.InsertCRMSaleEnquiryAccountMaster(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateContactPerson(string accountDetails)
        {
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
            string[] AccountDetails = accountDetails.Split('~');
            model.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(AccountDetails[0]);
            model.AccountName = AccountDetails[1].ToString();

            return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountContactPerson/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateContactPerson(CRMSaleEnquiryMasterAndAccountDetailsViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleEnquiryMasterAndAccountDetailsDTO != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName = model.FirstName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName = model.LastName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation = model.Designation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber = model.MobileNumber;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId = model.EmailId;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress = model.EnquiryAccountContactPersonAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin = model.Pin;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonLocation = model.EnquiryAccountContactPersonLocation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity = model.EnquiryAccountContactPersonCity;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry = model.EnquiryAccountContactPersonCountry;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.VisitingCardName = model.VisitingCardName;

                    IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.InsertCRMSaleEnquiryAccountContactPerson(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditContactPerson(int ID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
            try
            {
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO = new CRMSaleEnquiryMasterAndAccountDetails();
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID = ID;

                IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.SelectByCRMSaleEnquiryAccountContactPersonID(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID = response.Entity.CRMSaleEnquiryAccountContactPersonID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName = response.Entity.FirstName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName = response.Entity.LastName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId = response.Entity.EmailId;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress = response.Entity.EnquiryAccountContactPersonAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity = response.Entity.EnquiryAccountContactPersonCity;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry = response.Entity.EnquiryAccountContactPersonCountry;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation = response.Entity.Designation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber = response.Entity.MobileNumber;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin = response.Entity.Pin;
                }
                return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountContactPerson/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditContactPerson(CRMSaleEnquiryMasterAndAccountDetailsViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleEnquiryMasterAndAccountDetailsDTO != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID = model.CRMSaleEnquiryAccountContactPersonID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.FirstName = model.FirstName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.LastName = model.LastName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmailId = model.EmailId;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonAddress = model.EnquiryAccountContactPersonAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCity = model.EnquiryAccountContactPersonCity;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountContactPersonCountry = model.EnquiryAccountContactPersonCountry;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Designation = model.Designation;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.MobileNumber = model.MobileNumber;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.Pin = model.Pin;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.UpdateCRMSaleEnquiryAccountContactPerson(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewAccountDetails(int CRMSaleEnquiryAccountMasterID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
            try
            {
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO = new CRMSaleEnquiryMasterAndAccountDetails();
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID = CRMSaleEnquiryAccountMasterID;

                List<GeneralIndustryMaster> GeneralIndustryMaster = GetListGeneralIndustryMaster();
                List<SelectListItem> GeneralIndustryMasterList = new List<SelectListItem>();
                foreach (GeneralIndustryMaster item in GeneralIndustryMaster)
                {
                    GeneralIndustryMasterList.Add(new SelectListItem { Text = item.IndustryName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralIndustryMasterList = new SelectList(GeneralIndustryMasterList, "Value", "Text");

                List<CRMSaleAccountProgressTypeMasterAndRule> CRMSaleAccountProgressTypeMaster = GetListCRMSaleAccountProgressTypeMaster();
                List<SelectListItem> CRMSaleAccountProgressTypeMasterList = new List<SelectListItem>();
                foreach (CRMSaleAccountProgressTypeMasterAndRule item in CRMSaleAccountProgressTypeMaster)
                {
                    CRMSaleAccountProgressTypeMasterList.Add(new SelectListItem { Text = item.ProgressType, Value = Convert.ToString(item.CRMSaleAccountProgressTypeID) });
                }
                ViewBag.CRMSaleAccountProgressTypeMasterList = new SelectList(CRMSaleAccountProgressTypeMasterList, "Value", "Text");


                IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.SelectByCRMSaleEnquiryAccountMasterID(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName = response.Entity.AccountName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ApproxAnnualAmount = response.Entity.ApproxAnnualAmount;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.GeneralIndustryMasterID = response.Entity.GeneralIndustryMasterID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMAccountProgressTypeID = response.Entity.CRMSaleAccountProgressTypeID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterAddress = response.Entity.EnquiryAccountMasterAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCity = response.Entity.EnquiryAccountMasterCity;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountMasterCountry = response.Entity.EnquiryAccountMasterCountry;
                }
                return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountMaster/ViewAccountDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AccountTransferRequest(int CRMSaleEnquiryAccountMasterID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
            model.CRMSaleEnquiryAccountMasterID = CRMSaleEnquiryAccountMasterID;

            return PartialView("/Views/CRMSales/CRMSaleEnquiryAccountMaster/AccountTransferRequest.cshtml", model);
        }

        [HttpPost]
        public ActionResult AccountTransferRequest(CRMSaleEnquiryMasterAndAccountDetailsViewModel model)
        {
            try
            {
                if (model != null && model.CRMSaleEnquiryMasterAndAccountDetailsDTO != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountTransferRequestReason = model.AccountTransferRequestReason;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.RequestedSalesMenId = Convert.ToInt32(Session["PersonID"]);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.InsertCRMSaleEnquiryAccountTransferRequest(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.CRMSaleEnquiryMasterAndAccountDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CheckDownloadVisitingCard(string VisitingCard)
        {
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\CRMSale\\VisitingCard\\", VisitingCard);
            FileInfo file = new FileInfo(filePath);
            if (Directory.Exists(filePath) || file.Exists)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return Json("Visiting card not found.", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownloadVisitingCard(string VisitingCard)
        {
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\CRMSale\\VisitingCard\\", VisitingCard);
            string contentType = "image";
            return File(filePath, contentType, VisitingCard);
        }

        #endregion

        // Non-Action Method
        #region Methods
        protected List<GeneralIndustryMaster> GetListGeneralIndustryMaster()
        {
            GeneralIndustryMasterSearchRequest searchRequest = new GeneralIndustryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralIndustryMaster> listGeneralIndustryMaster = new List<GeneralIndustryMaster>();
            IBaseEntityCollectionResponse<GeneralIndustryMaster> baseEntityCollectionResponse = _GeneralIndustryMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralIndustryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralIndustryMaster;
        }

        protected List<CRMSaleAccountProgressTypeMasterAndRule> GetListCRMSaleAccountProgressTypeMaster()
        {
            CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest = new CRMSaleAccountProgressTypeMasterAndRuleSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleAccountProgressTypeMasterAndRule> listCRMSaleAccountProgressTypeMaster = new List<CRMSaleAccountProgressTypeMasterAndRule>();
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> baseEntityCollectionResponse = _CRMSaleAccountProgressTypeMasterAndRuleServiceAccess.GetCRMSaleAccountProgressTypeMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCRMSaleAccountProgressTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCRMSaleAccountProgressTypeMaster;
        }



        public IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> GetCRMSaleEnquiryAccountMaster(Int32 employeeID, out int TotalRecords)
        {
            CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest = new CRMSaleEnquiryMasterAndAccountDetailsSearchRequest();
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
                    searchRequest.EmployeeID = employeeID;

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = employeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = employeeID;
            }
            List<CRMSaleEnquiryMasterAndAccountDetailsViewModel> listGeneralIndustryMasterViewModel = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
            List<CRMSaleEnquiryMasterAndAccountDetails> listGeneralIndustryMaster = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.GetBySearchCRMSaleEnquiryAccountMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralIndustryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleEnquiryMasterAndAccountDetails item in listGeneralIndustryMaster)
                    {
                        CRMSaleEnquiryMasterAndAccountDetailsViewModel GeneralIndustryMasterViewModel = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
                        GeneralIndustryMasterViewModel.CRMSaleEnquiryMasterAndAccountDetailsDTO = item;
                        listGeneralIndustryMasterViewModel.Add(GeneralIndustryMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralIndustryMasterViewModel;
        }

        public IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> GetCRMSaleEnquiryAllAccountMaster(Int32 employeeID, out int TotalRecords)
        {
            CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest = new CRMSaleEnquiryMasterAndAccountDetailsSearchRequest();
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
                    searchRequest.EmployeeID = employeeID;

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = employeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = employeeID;
            }
            List<CRMSaleEnquiryMasterAndAccountDetailsViewModel> listGeneralIndustryMasterViewModel = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
            List<CRMSaleEnquiryMasterAndAccountDetails> listGeneralIndustryMaster = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.GetBySearchCRMSaleEnquiryAllAccountMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralIndustryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleEnquiryMasterAndAccountDetails item in listGeneralIndustryMaster)
                    {
                        CRMSaleEnquiryMasterAndAccountDetailsViewModel GeneralIndustryMasterViewModel = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
                        GeneralIndustryMasterViewModel.CRMSaleEnquiryMasterAndAccountDetailsDTO = item;
                        listGeneralIndustryMasterViewModel.Add(GeneralIndustryMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralIndustryMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> filteredCRMSaleEnquiryAccountMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.MobileNumber Like '%" + param.sSearch + "%' or B.EmailId Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.MobileNumber Like '%" + param.sSearch + "%' or B.EmailId Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.MobileNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.MobileNumber Like '%" + param.sSearch + "%' or B.EmailId Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.EmailId";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.MobileNumber Like '%" + param.sSearch + "%' or B.EmailId Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "B.City";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.MobileNumber Like '%" + param.sSearch + "%' or B.EmailId Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    //case 5:
                    //    _sortBy = "B.City";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //    }
                    //    break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(Session["PersonID"].ToString()))
                {
                    filteredCRMSaleEnquiryAccountMaster = GetCRMSaleEnquiryAccountMaster(Convert.ToInt32(Session["PersonID"].ToString()), out TotalRecords);
                }
                else
                {
                    filteredCRMSaleEnquiryAccountMaster = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCRMSaleEnquiryAccountMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(String.Concat(c.FirstName, ' ', c.LastName)), Convert.ToString(c.MobileNumber), Convert.ToString(c.EmailId), Convert.ToString(c.EnquiryAccountContactPersonCity), Convert.ToString(c.VisitingCardPath), Convert.ToString(c.CRMSaleEnquiryAccountMasterID), Convert.ToString(c.CRMSaleEnquiryAccountContactPersonID), Convert.ToString(c.AccountType) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }

        public ActionResult AjaxHandlerAllAccounts(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> filteredCRMSaleEnquiryAccountMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.Designation";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.City";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "A.EmployeeFirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "A.ProgressType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.City Like '%" + param.sSearch + "%' or A.EmployeeFirstName Like '%" + param.sSearch + "%' or A.EmployeeLastName Like '%" + param.sSearch + "%' or A.ProgressType Like '%" + param.sSearch + "%' or B.Designation Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    //case 5:
                    //    _sortBy = "B.City";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "A.AccountName Like '%" + param.sSearch + "%' or B.FirstName Like '%" + param.sSearch + "%' or B.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //    }
                    //    break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(Session["PersonID"].ToString()))
                {
                    filteredCRMSaleEnquiryAccountMaster = GetCRMSaleEnquiryAllAccountMaster(Convert.ToInt32(Session["PersonID"].ToString()), out TotalRecords);
                }
                else
                {
                    filteredCRMSaleEnquiryAccountMaster = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCRMSaleEnquiryAccountMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AccountName), Convert.ToString(String.Concat(c.FirstName, ' ', c.LastName)), Convert.ToString(c.EnquiryAccountContactPersonCity), Convert.ToString(c.EmployeeName), Convert.ToString(c.ProgressType), Convert.ToString(c.CRMSaleEnquiryAccountMasterID), Convert.ToString(c.CRMSaleEnquiryAccountContactPersonID), Convert.ToString(c.AccountType), Convert.ToString(c.OwnAccountStatus), Convert.ToString(c.Designation), Convert.ToString(c.CRMSaleAccountProgressTypeID) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}















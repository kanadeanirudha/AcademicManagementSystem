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
    public class CRMSaleEnquiryMasterController : BaseController
    {
        ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = null;
        IGeneralServiceMasterServiceAccess _GeneralServiceMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleEnquiryMasterController()
        {
            _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess = new CRMSaleEnquiryMasterAndAccountDetailsServiceAccess();
            _GeneralServiceMasterServiceAccess = new GeneralServiceMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/CRMSales/CRMSaleEnquiryMaster/Index.cshtml");
        }
        [HttpPost]
        public ActionResult List(string SelectedEnquiryAccountType, string TransactionDate, string actionMode)
        {
            try
            {
                CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                List<SelectListItem> EnquiryAccountType = new List<SelectListItem>();
                ViewBag.EnquiryAccountType = new SelectList(EnquiryAccountType, "Value", "Text");
                List<SelectListItem> EnquiryAccountType_li = new List<SelectListItem>();
                EnquiryAccountType_li.Add(new SelectListItem { Text = "All", Value = "0" });
                EnquiryAccountType_li.Add(new SelectListItem { Text = "Corporate", Value = "1" });
                EnquiryAccountType_li.Add(new SelectListItem { Text = "Personal", Value = "2" });

                model.SelectedEnquiryAccountType = SelectedEnquiryAccountType;
                model.TransactionDate = TransactionDate;
                ViewData["SelectedEnquiryAccountType"] = new SelectList(EnquiryAccountType_li, "Value", "Text", model.SelectedEnquiryAccountType);

                return PartialView("/Views/CRMSales/CRMSaleEnquiryMaster/List.cshtml", model);
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

            List<SelectListItem> EnquiryAccountType = new List<SelectListItem>();
            ViewBag.EnquiryAccountType = new SelectList(EnquiryAccountType, "Value", "Text");
            List<SelectListItem> EnquiryAccountType_li = new List<SelectListItem>();
            EnquiryAccountType_li.Add(new SelectListItem { Text = "Corporate", Value = "1" });
            EnquiryAccountType_li.Add(new SelectListItem { Text = "Personal", Value = "2" });

            ViewData["EnquiryAccountType"] = new SelectList(EnquiryAccountType_li, "Value", "Text", model.SelectedEnquiryAccountType);

            List<SelectListItem> EnquirySource = new List<SelectListItem>();
            ViewBag.EnquirySource = new SelectList(EnquirySource, "Value", "Text");
            List<SelectListItem> EnquirySource_li = new List<SelectListItem>();
            EnquirySource_li.Add(new SelectListItem { Text = "Other", Value = "0" });
            EnquirySource_li.Add(new SelectListItem { Text = "Cold Call", Value = "1" });
            EnquirySource_li.Add(new SelectListItem { Text = "Existing Customer", Value = "2" });
            EnquirySource_li.Add(new SelectListItem { Text = "Website", Value = "3" });
            EnquirySource_li.Add(new SelectListItem { Text = "Linkedin", Value = "4" });
            EnquirySource_li.Add(new SelectListItem { Text = "Referrals", Value = "5" });
            EnquirySource_li.Add(new SelectListItem { Text = "Direct Sales", Value = "6" });
            EnquirySource_li.Add(new SelectListItem { Text = "Employee", Value = "7" });
            ViewData["EnquirySource"] = new SelectList(EnquirySource_li, "Value", "Text", model.EnquirySource);

            List<GeneralServiceMaster> GeneralServiceMaster = GetListGeneralServiceMaster(0);
            List<SelectListItem> GeneralServiceMasterList = new List<SelectListItem>();
            foreach (GeneralServiceMaster item in GeneralServiceMaster)
            {
                GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text");

            return PartialView("/Views/CRMSales/CRMSaleEnquiryMaster/Create.cshtml", model);
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
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountMasterID = model.CRMSaleEnquiryAccountMasterID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryAccountContactPersonID = model.CRMSaleEnquiryAccountContactPersonID;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLatitude = model.EnquiryMasterLatitude;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterLongitude = model.EnquiryMasterLongitude;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountType = model.EnquiryAccountType;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquirySource = model.EnquirySource;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredName = model.GenServiceRequiredName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ExpectedBillingAmount = model.ExpectedBillingAmount;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryDesription = model.EnquiryDesription;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterAddress = model.EnquiryMasterAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterCity = model.EnquiryMasterCity;

                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                    IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.InsertCRMSaleEnquiryMaster(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                    errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    return Json("Please review your form");
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
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO = new CRMSaleEnquiryMasterAndAccountDetails();
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryMasterID = Convert.ToInt64(ID);
                model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.SelectByCRMSaleEnquiryMasterID(model.CRMSaleEnquiryMasterAndAccountDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.AccountName = response.Entity.AccountName;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryContactPerson = response.Entity.EnquiryContactPerson;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountType = response.Entity.EnquiryAccountType;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquirySource = response.Entity.EnquirySource;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredID = response.Entity.GenServiceRequiredID;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.ExpectedBillingAmount = response.Entity.ExpectedBillingAmount;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryDesription = response.Entity.EnquiryDesription;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterAddress = response.Entity.EnquiryMasterAddress;
                    model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryMasterCity = response.Entity.EnquiryMasterCity;

                }

                List<SelectListItem> EnquiryAccountType = new List<SelectListItem>();
                ViewBag.EnquiryAccountType = new SelectList(EnquiryAccountType, "Value", "Text");
                List<SelectListItem> EnquiryAccountType_li = new List<SelectListItem>();
                EnquiryAccountType_li.Add(new SelectListItem { Text = "Corporate", Value = "1" });
                EnquiryAccountType_li.Add(new SelectListItem { Text = "Personal", Value = "2" });

                ViewData["EnquiryAccountType"] = new SelectList(EnquiryAccountType_li, "Value", "Text", model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquiryAccountType);

                List<SelectListItem> EnquirySource = new List<SelectListItem>();
                ViewBag.EnquirySource = new SelectList(EnquirySource, "Value", "Text");
                List<SelectListItem> EnquirySource_li = new List<SelectListItem>();
                EnquirySource_li.Add(new SelectListItem { Text = "others", Value = "0" });
                EnquirySource_li.Add(new SelectListItem { Text = "Cold Call", Value = "1" });
                EnquirySource_li.Add(new SelectListItem { Text = "Existing Customer", Value = "2" });
                EnquirySource_li.Add(new SelectListItem { Text = "Website", Value = "3" });
                EnquirySource_li.Add(new SelectListItem { Text = "Linkedin", Value = "4" });
                EnquirySource_li.Add(new SelectListItem { Text = "Referrals", Value = "5" });
                EnquirySource_li.Add(new SelectListItem { Text = "Direct Sales", Value = "6" });
                EnquirySource_li.Add(new SelectListItem { Text = "Employee", Value = "7" });
                ViewData["EnquirySource"] = new SelectList(EnquirySource_li, "Value", "Text", model.CRMSaleEnquiryMasterAndAccountDetailsDTO.EnquirySource);

                model.GeneralServiceSelected = GetListGeneralServiceMaster(Convert.ToInt64(ID));
                //List<SelectListItem> GeneralServiceMasterList = new List<SelectListItem>();
                //foreach (GeneralServiceMaster item in GeneralServiceMaster)
                //{
                //    GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
                //}
                //ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.CRMSaleEnquiryMasterAndAccountDetailsDTO.GenServiceRequiredID);

                return PartialView("/Views/CRMSales/CRMSaleEnquiryMaster/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult Delete(string ID)
        {
            var errorMessage = string.Empty;
            CRMSaleEnquiryMasterAndAccountDetailsViewModel model = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
            if (Convert.ToInt64(ID) > 0)
            {

                IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = null;
                CRMSaleEnquiryMasterAndAccountDetails CRMSaleEnquiryMasterAndAccountDetailsDTO = new CRMSaleEnquiryMasterAndAccountDetails();
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ConnectionString = _connectioString;
                CRMSaleEnquiryMasterAndAccountDetailsDTO.CRMSaleEnquiryMasterID = Convert.ToInt64(ID);
                CRMSaleEnquiryMasterAndAccountDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                response = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.DeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindCoordinates(string txtLocation)
        {
            string Address = string.Empty, Lat = "", Long = "", aaa = "";
            if (txtLocation != string.Empty && txtLocation.Length > 5)
            {
                string url = "http://maps.google.com/maps/api/geocode/xml?address=" + txtLocation + "&sensor=false";
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        DataSet dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        DataTable dtCoordinates = new DataTable();
                        string GeocodeResponseStatus = "";
                        foreach (DataRow row1 in dsResult.Tables["GeocodeResponse"].Rows)
                        {
                            GeocodeResponseStatus = (string)row1["Status"];
                        }

                        if (GeocodeResponseStatus == "OK")
                        {
                            foreach (DataRow row in dsResult.Tables["result"].Rows)
                            {
                                DataRow location = dsResult.Tables["location"].Select("geometry_id = 0")[0];
                                Lat = (string)location["lat"];
                                Long = (string)location["lng"];
                                Address = (string)row["formatted_address"];
                                aaa = String.Concat(Address, '~', Lat, '~', Long);
                            }
                        }
                    }
                }

            }
            return Json(aaa, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Non-Action Method
        #region Methods
        protected List<GeneralServiceMaster> GetListGeneralServiceMaster(Int64 CRMSaleEnquiryMasterID)
        {
            GeneralServiceMasterSearchRequest searchRequest = new GeneralServiceMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CRMSaleEnquiryMasterID = CRMSaleEnquiryMasterID;
            List<GeneralServiceMaster> listGeneralServiceMaster = new List<GeneralServiceMaster>();
            IBaseEntityCollectionResponse<GeneralServiceMaster> baseEntityCollectionResponse = _GeneralServiceMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralServiceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralServiceMaster;
        }

        [HttpPost]
        public JsonResult GetAccountDetails(string term)
        {
            Int16 AccountProgressTypeID = 0;
            Int32 CRMSaleEnquiryAccountMasterID = 0;
            Int16 AccountType = 1;
            var data = GetAccountDetails(term, AccountProgressTypeID, AccountType, CRMSaleEnquiryAccountMasterID, Convert.ToInt32(Session["PersonID"]));
            var result = (from r in data
                          select new
                          {
                              id = r.CRMSaleEnquiryAccountMasterID,
                              name = r.AccountName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEnquiryContactPersonDetails(string term, string AccountMasterID)
        {
            var data = GetEnquiryContactPersonDetails(term, Convert.ToInt32(AccountMasterID), 0);
            var result = (from r in data
                          select new
                          {
                              id = r.CRMSaleEnquiryAccountContactPersonID,
                              name = String.Concat(r.FirstName, ' ', r.LastName),
                              enquiryId = r.CRMSaleEnquiryAccountMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        protected List<CRMSaleEnquiryMasterAndAccountDetails> GetEnquiryContactPersonDetails(string SearchKeyWord, Int32 AccountMasterID, Int32 EnquiryContactPersonID)
        {
            CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest = new CRMSaleEnquiryMasterAndAccountDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ContactPersonName = SearchKeyWord;
            searchRequest.CRMSaleEnquiryAccountMasterID = AccountMasterID;
            searchRequest.CRMSaleEnquiryAccountContactPersonNameID = EnquiryContactPersonID;
            searchRequest.EnquiryAccountType = 1;

            List<CRMSaleEnquiryMasterAndAccountDetails> listAccount = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.GetCRMSaleEnquiryAccountContactPersonSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }


        public IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> GetCRMSaleEnquiryMaster(Int16 SelectedEnquiryAccountType, string TransactionDate, out int TotalRecords)
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
                    searchRequest.EnquiryAccountType = SelectedEnquiryAccountType;
                    searchRequest.TransactionDate = TransactionDate;
                    searchRequest.EnquiryHandledById = Convert.ToInt32(Session["PersonID"]);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EnquiryAccountType = SelectedEnquiryAccountType;
                    searchRequest.TransactionDate = TransactionDate;
                    searchRequest.EnquiryHandledById = Convert.ToInt32(Session["PersonID"]);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EnquiryAccountType = SelectedEnquiryAccountType;
                searchRequest.TransactionDate = TransactionDate;
                searchRequest.EnquiryHandledById = Convert.ToInt32(Session["PersonID"]);
            }
            List<CRMSaleEnquiryMasterAndAccountDetailsViewModel> listGeneralServiceMasterViewModel = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
            List<CRMSaleEnquiryMasterAndAccountDetails> listGeneralServiceMaster = new List<CRMSaleEnquiryMasterAndAccountDetails>();
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollectionResponse = _CRMSaleEnquiryMasterAndAccountDetailsServiceAcess.GetBySearchCRMSaleEnquiryMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralServiceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CRMSaleEnquiryMasterAndAccountDetails item in listGeneralServiceMaster)
                    {
                        CRMSaleEnquiryMasterAndAccountDetailsViewModel GeneralServiceMasterViewModel = new CRMSaleEnquiryMasterAndAccountDetailsViewModel();
                        GeneralServiceMasterViewModel.CRMSaleEnquiryMasterAndAccountDetailsDTO = item;
                        listGeneralServiceMasterViewModel.Add(GeneralServiceMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralServiceMasterViewModel;
        }


        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedEnquiryAccountType, string TransactionDate)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CRMSaleEnquiryMasterAndAccountDetailsViewModel> filteredCRMSaleEnquiryMaster;
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
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.AccountName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or C.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.EnquiryDesription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.AccountName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or C.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.AccountName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or C.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "A.TransactionDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.EnquiryDesription Like '%" + param.sSearch + "%' or B.AccountName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or C.LastName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(SelectedEnquiryAccountType))
                {
                    filteredCRMSaleEnquiryMaster = GetCRMSaleEnquiryMaster(Convert.ToInt16(SelectedEnquiryAccountType), TransactionDate, out TotalRecords);
                }
                else
                {
                    filteredCRMSaleEnquiryMaster = new List<CRMSaleEnquiryMasterAndAccountDetailsViewModel>();
                    TotalRecords = 0;
                }
                var records = filteredCRMSaleEnquiryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.EnquiryDesription), Convert.ToString(String.Concat(c.AccountName, " - ", c.FirstName, ' ', c.LastName)), Convert.ToString(c.TransactionDate), Convert.ToString(c.CRMSaleEnquiryMasterID) };
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















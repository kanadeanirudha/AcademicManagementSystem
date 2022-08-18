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
    public class InventorySalesMasterAndTransactionController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        IInventorySalesMasterAndTransactionServiceAccess _InventorySalesMasterAndTransactionServiceAccess = null;
        IInventoryItemMasterServiceAccess _inventoryItemMasterServiceAccess = null;
        IInventoryLocationMasterServiceAccess _inventoryLocationMasterServiceAccess = null;
        IAccountSessionMasterServiceAccess _accountSessionMasterServiceAccess = null;
        IAccountBalancesheetMasterServiceAccess _accountBalancesheetMasterServiceAccess = null;
        InventoryCounterMasterServiceAccess _inventoryCounterMasterServiceAccess = null;
        InventoryCounterLogAndLockDetailsServiceAccess _inventoryCounterLogAndLockDetailsServiceAccess = null;
        InventoryCustomerMasterServiceAccess _inventoryCustomerMasterServiceAccess = null;
        IInventoryInWardMasterAndInWardDetailsServiceAccess _InventoryInWardMasterAndInWardDetailsServiceAccess = null;
        IGeneralPolicyRulesServiceAccess _GeneralPolicyRulesServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        public static int invCounterApplicableDetailsID = 0;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public InventorySalesMasterAndTransactionController()
        {
            _InventorySalesMasterAndTransactionServiceAccess = new InventorySalesMasterAndTransactionServiceAccess();
            _inventoryItemMasterServiceAccess = new InventoryItemMasterServiceAccess();
            _inventoryLocationMasterServiceAccess = new InventoryLocationMasterServiceAccess();
            _accountSessionMasterServiceAccess = new AccountSessionMasterServiceAccess();
            _accountBalancesheetMasterServiceAccess = new AccountBalancesheetMasterServiceAccess();
            _inventoryCounterMasterServiceAccess = new InventoryCounterMasterServiceAccess();
            _inventoryCounterLogAndLockDetailsServiceAccess = new InventoryCounterLogAndLockDetailsServiceAccess();
            _inventoryCustomerMasterServiceAccess = new InventoryCustomerMasterServiceAccess();
            _InventoryInWardMasterAndInWardDetailsServiceAccess = new InventoryInWardMasterAndInWardDetailsServiceAccess();
            _GeneralPolicyRulesServiceAcess = new GeneralPolicyRulesServiceAccess();

        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventorySalesMasterAndTransaction/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

         [HttpGet]
        public ActionResult List(string selectedBalsheet, string keyPressNumber, string locationID, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedBalsheet) || Convert.ToString(Session["UserType"]) == "A")
                {
                    InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                        model.LoginUserCount = 1;
                        model.CounterID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Counter1"]);
                    }
                    else
                    {
                        model.CounterID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Counter1"]);

                        List<InventoryCounterLogAndLockDetails> listInventoryCounterLockStatus = GetListInventoryCounterLockStatus(Convert.ToInt32(selectedBalsheet), model.CounterID, Convert.ToInt32(Session["UserID"]), Session["ticket"].ToString());
                        model.LoginUserCount = listInventoryCounterLockStatus[0].LoginUserCount;
                        if (model.LoginUserCount == 0)
                        {
                            model.InventoryCounterMasterList = GetInventoryCounterMaster(Convert.ToInt32(selectedBalsheet), Convert.ToInt32(model.CounterID));
                        }
                    }
                    model.LocationList = GetLocationList(selectedBalsheet);
                  

                    //For CustomerTypeList
                    List<SelectListItem> CustomerTypeList = new List<SelectListItem>();
                    ViewBag.CustomerTypeList = new SelectList(CustomerTypeList, "Value", "Text");
                    List<SelectListItem> li_CustomerTypeList = new List<SelectListItem>();
                    li_CustomerTypeList.Add(new SelectListItem { Text = "Walk-In", Value = "WI" });
                    li_CustomerTypeList.Add(new SelectListItem { Text = "Home Delivery", Value = "HD" });
                    ViewData["CustomerTypeList"] = li_CustomerTypeList;

                    model.PolicyCode = "IsTaxInclusivePrintingTemplateApplicable";
                    model.PolicyApplicableStatus = GetPolicyApplicableStatus(model.PolicyCode);
                    model.InventorySalesMasterAndTransactionDTO.CentreCode = GetCentreCode();
                    model.PolicyAnswerByPolicyStatus = GetPolicyAnswerByPolicyStatus(model.InventorySalesMasterAndTransactionDTO.CentreCode, model.PolicyApplicableStatus, model.PolicyCode);
                    model.PolicyDefaultAnswer = model.PolicyAnswerByPolicyStatus.Where(x => x.PolicyCode == model.PolicyCode).Select(x => x.PolicyDefaultAnswer).FirstOrDefault();


                    if (!string.IsNullOrEmpty(selectedBalsheet) && !string.IsNullOrEmpty(locationID) && !string.IsNullOrEmpty(keyPressNumber))
                    {
                        model.LocationID = Convert.ToInt32(locationID);
                        model.InventorySalesMasterAndTransactionBillPrintList = GetListInventorySalesMasterAndTransactionBillPrintList(locationID, selectedBalsheet, keyPressNumber, model.PolicyDefaultAnswer);
                        if (model.InventorySalesMasterAndTransactionBillPrintList.Count > 0)
                        {
                            model.TotalItem = model.InventorySalesMasterAndTransactionBillPrintList.Count;
                            model.CustomerType = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerType;
                            model.CustomerName = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerName;
                            model.CustomerID = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerID;
                            model.CustomerContactNo = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerContactNo;
                            model.CustomerAddress = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerAddress;
                            model.LocationID = model.InventorySalesMasterAndTransactionBillPrintList[0].LocationID;
                            model.TotalGrossAmount = model.InventorySalesMasterAndTransactionBillPrintList[0].TotalGrossAmount;
                            model.TotalTaxAmount= model.InventorySalesMasterAndTransactionBillPrintList[0].TotalTaxAmount;
                            model.TotalDiscount= model.InventorySalesMasterAndTransactionBillPrintList[0].TotalDiscount;
                            model.TotalBillAmount= model.InventorySalesMasterAndTransactionBillPrintList[0].TotalBillAmount;
                            model.DeliveryCharge = model.InventorySalesMasterAndTransactionBillPrintList[0].DeliveryCharge;                                    
                            model.RoundUpAmount = model.InventorySalesMasterAndTransactionBillPrintList[0].RoundUpAmount;
                            model.DiscountInPercentage = model.InventorySalesMasterAndTransactionBillPrintList[0].DiscountInPercentage;
                            model.TotalBillAmountIncludeTaxTemplate = model.InventorySalesMasterAndTransactionBillPrintList[0].TotalBillAmountIncludeTaxTemplate;
                        }
                    }
                    model.OpenBillCount = GetOpenBillCount(model.LocationList[0].ID, selectedBalsheet, model.CounterID);
                    model.systemseeting = Getsystemseeting(Convert.ToInt16(selectedBalsheet));

                    model.FieldName = model.systemseeting.Where(x => x.FieldName == "IsNegativeBillingAllow").Select(x => x.FieldName).FirstOrDefault();
                    model.FieldValue = model.systemseeting.Where(x => x.FieldName == "IsNegativeBillingAllow").Select(x => x.FieldValue).FirstOrDefault();
                    //model.FieldName = model.systemseeting.Count > 0 ? model.systemseeting[1].FieldName : null;
                    //model.FieldValue = model.systemseeting.Count > 0 ? model.systemseeting[1].FieldValue : 0;
                   
                    if (model.PolicyDefaultAnswer == "1")
                    {
                        return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/List1.cshtml", model);
                    }
                    else
                    {
                        return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/List.cshtml", model);
                    }
                    
                }
                else
                {
                    return RedirectToActionPermanent("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        
        public ActionResult List(InventorySalesMasterAndTransactionViewModel model)
        {
            try
            {
                // For Center
                model.InventorySalesMasterAndTransactionDTO.CentreCode = GetCentreCode();
                ///////////////////////////////////
                //For Current Account Session
                AccountSessionMasterViewModel model2 = new AccountSessionMasterViewModel();
                model2.AccountSessionMasterDTO = new AccountSessionMaster();
                model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<AccountSessionMaster> response2 = _accountSessionMasterServiceAccess.GetCurrentAccountSession(model2.AccountSessionMasterDTO);
                model2.AccountSessionMasterDTO.ConnectionString = _connectioString;
                if (response2 != null && response2.Entity != null)
                {
                    model.InventorySalesMasterAndTransactionDTO.AccountSessionID = response2.Entity.ID;
                }
                //////////////////////////////////
                model.InventorySalesMasterAndTransactionDTO.ConnectionString        =  _connectioString;
                model.InventorySalesMasterAndTransactionDTO.ID                      =  model.ID;
                model.InventorySalesMasterAndTransactionDTO.BalanceSheetID          =  model.BalanceSheetID;
                model.InventorySalesMasterAndTransactionDTO.BillAmount              =  model.BillAmount;
                model.InventorySalesMasterAndTransactionDTO.TotalGrossAmount        =  model.TotalGrossAmount  ;
                model.InventorySalesMasterAndTransactionDTO.TotalTaxAmount          =  model.TotalTaxAmount    ;
                model.InventorySalesMasterAndTransactionDTO.TotalDiscount           =  model.TotalDiscount     ;
                model.InventorySalesMasterAndTransactionDTO.DeliveryCharge          =  model.DeliveryCharge    ;
                model.InventorySalesMasterAndTransactionDTO.PaymentByCustomer       =  model.PaymentByCustomer ;
                model.InventorySalesMasterAndTransactionDTO.ReturnChange            =  model.ReturnChange      ;              
                model.InventorySalesMasterAndTransactionDTO.RoundUpAmount           =  model.RoundUpAmount;
                model.InventorySalesMasterAndTransactionDTO.CustomerID              =  model.CustomerID;
                model.InventorySalesMasterAndTransactionDTO.CustomerName            =  model.CustomerName;
                model.InventorySalesMasterAndTransactionDTO.CustomerContactNo       =  model.CustomerContactNo;
                model.InventorySalesMasterAndTransactionDTO.CustomerAddress         =  model.CustomerAddress;
                model.InventorySalesMasterAndTransactionDTO.CustomerType            =  model.CustomerType;
                model.InventorySalesMasterAndTransactionDTO.LocationID              =  model.LocationID;
                model.InventorySalesMasterAndTransactionDTO.CounterLogID            =  model.CounterLogID;
                model.InventorySalesMasterAndTransactionDTO.CounterID               =  Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Counter1"]);
                model.InventorySalesMasterAndTransactionDTO.XMLstring               =  model.XMLstring;
                model.InventorySalesMasterAndTransactionDTO.CreatedBy               =  Convert.ToInt32(Session["UserID"]);
                model.InventorySalesMasterAndTransactionDTO.PolicyDefaultAnswer     = model.PolicyDefaultAnswer;
                IBaseEntityResponse<InventorySalesMasterAndTransaction> response = _InventorySalesMasterAndTransactionServiceAccess.InsertInventorySalesMasterAndTransaction(model.InventorySalesMasterAndTransactionDTO);
                List<InventorySalesMasterAndTransaction> listInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
                InventorySalesMasterAndTransactionSearchRequest searchRequest = new InventorySalesMasterAndTransactionSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ID = (response != null && response.Entity != null) ? response.Entity.ID : 0;
                searchRequest.AccBalsheetMstID = Convert.ToInt16(model.BalanceSheetID);
                searchRequest.PolicyDefaultAnswer = model.PolicyDefaultAnswer;
                if (searchRequest.ID > 0 && searchRequest.AccBalsheetMstID > 0)
                {
                    IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollectionResponse = _InventorySalesMasterAndTransactionServiceAccess.GetBillDetailsByID(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listInventorySalesMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                //model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(listInventorySalesMasterAndTransaction, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult Edit(string selectedBalsheet, string InvSaleMasterID)
        //{
        //    InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
        //    model.LocationList = GetLocationList(selectedBalsheet);


        //    //For CustomerTypeList
        //    List<SelectListItem> CustomerTypeList = new List<SelectListItem>();
        //    ViewBag.CustomerTypeList = new SelectList(CustomerTypeList, "Value", "Text");
        //    List<SelectListItem> li_CustomerTypeList = new List<SelectListItem>();
        //    li_CustomerTypeList.Add(new SelectListItem { Text = "Walk-In", Value = "WI" });
        //    li_CustomerTypeList.Add(new SelectListItem { Text = "Home Delivery", Value = "HD" });
        //    ViewData["CustomerTypeList"] = li_CustomerTypeList;

        //    if (InvSaleMasterID != "" && InvSaleMasterID != "0" && InvSaleMasterID != null && !string.IsNullOrEmpty(selectedBalsheet))
        //    {
        //        model.InventorySalesMasterAndTransactionBillPrintList = GetListInventorySalesMasterAndTransactionBillPrintList(InvSaleMasterID, selectedBalsheet);
        //        if (model.InventorySalesMasterAndTransactionBillPrintList.Count > 0)
        //        {
        //            model.TotalItem = model.InventorySalesMasterAndTransactionBillPrintList.Count;
        //            model.CustomerType = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerType;
        //            model.CustomerName = model.InventorySalesMasterAndTransactionBillPrintList[0].CustomerName;
        //            model.LocationID = model.InventorySalesMasterAndTransactionBillPrintList[0].LocationID;
        //            model.TotalBillAmount = model.InventorySalesMasterAndTransactionBillPrintList[0].BillAmount;
        //            model.DiscountInPercentage = model.InventorySalesMasterAndTransactionBillPrintList[0].DiscountInPercentage;
        //        }
        //    }
        //    return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/Edit.cshtml", model);
        //}

        [HttpGet]
        public ActionResult CounterLogin()
        {
            try
            {
                InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();

                string CounterID = System.Configuration.ConfigurationManager.AppSettings["Counter1"];

                List<InventoryCounterLogAndLockDetails> listInventoryCounterLockStatus = GetListInventoryCounterLockStatus(Convert.ToInt32(Session["BalancesheetID"]), Convert.ToInt32(CounterID), Convert.ToInt32(Session["UserID"]), Session["ticket"].ToString());
                model.LoginUserCount = listInventoryCounterLockStatus[0].LoginUserCount;
                if (model.LoginUserCount == 0)
                {
                    model.InventoryCounterMasterList = GetInventoryCounterMaster(Convert.ToInt32(Session["BalancesheetID"]), Convert.ToInt32(CounterID));
                }
                return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/CounterLogin.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CounterLogin(InventorySalesMasterAndTransactionViewModel model)
        {
            try
            {
                invCounterApplicableDetailsID = model.InvCounterApplicableDetailsID;


                if (model != null)
                {
                    InventoryCounterLogAndLockDetailsViewModel model1 = new InventoryCounterLogAndLockDetailsViewModel();
                    model1.InventoryCounterLogAndLockDetailsDTO.ConnectionString = _connectioString;
                    model1.InventoryCounterLogAndLockDetailsDTO.CounterID = model.CounterID;
                    model1.InventoryCounterLogAndLockDetailsDTO.InvCounterApplicableDetailsID = model.InvCounterApplicableDetailsID;
                    model1.InventoryCounterLogAndLockDetailsDTO.OpeningCash = Convert.ToDecimal(model.CounterOpeningCash);
                    model1.InventoryCounterLogAndLockDetailsDTO.ClosingCash = Convert.ToDecimal(model.CounterClosingCash);
                    model1.InventoryCounterLogAndLockDetailsDTO.TokenCode = Session["ticket"].ToString();
                    model1.InventoryCounterLogAndLockDetailsDTO.BalanceSheetID = model.BalanceSheetID;
                    model1.InventoryCounterLogAndLockDetailsDTO.UserID = Convert.ToInt32(Session["UserID"]);
                    model1.InventoryCounterLogAndLockDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = _inventoryCounterLogAndLockDetailsServiceAccess.InsertInventoryCounterLogAndLockDetails(model1.InventoryCounterLogAndLockDetailsDTO);
                    if (response.Entity != null && response.Entity.ErrorCode == 0)
                    {
                        model.InventorySalesMasterAndTransactionDTO.errorMessage = "Login Successfully,#9FEA7A,1";
                        model.CounterLogID = response.Entity.CounterLogID;
                    }
                    else
                    {
                        model.InventorySalesMasterAndTransactionDTO.errorMessage = "Login Failed,#F5CCCC,0";
                    }
                    return Json(model, JsonRequestBehavior.AllowGet);
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
        public ActionResult CounterLogOut(InventorySalesMasterAndTransactionViewModel model)
        {
            try
            {

                if (model != null)
                {
                    InventoryCounterLogAndLockDetailsViewModel model1 = new InventoryCounterLogAndLockDetailsViewModel();
                    model1.InventoryCounterLogAndLockDetailsDTO.ConnectionString = _connectioString;
                    model1.InventoryCounterLogAndLockDetailsDTO.TokenCode = Session["ticket"].ToString();
                    model1.InventoryCounterLogAndLockDetailsDTO.UserID = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = _inventoryCounterLogAndLockDetailsServiceAccess.DeleteInventoryCounterLogAndLockDetails(model1.InventoryCounterLogAndLockDetailsDTO);
                    if (response.Entity != null && response.Entity.ErrorCode == 0)
                    {
                        model.InventorySalesMasterAndTransactionDTO.errorMessage = "Sign-Out Successfully,#9FEA7A,1";
                    }
                    else
                    {
                        model.InventorySalesMasterAndTransactionDTO.errorMessage = "Sign-Out Failed,#F5CCCC,0";
                    }
                    return Json(model.InventorySalesMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult PrintBill(string selectedBalsheet, string InvSaleMasterID, string PolicyDefaultAnswer)
        {
            List<InventorySalesMasterAndTransaction> listInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
            InventorySalesMasterAndTransactionSearchRequest searchRequest = new InventorySalesMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = Convert.ToInt32(InvSaleMasterID);
            searchRequest.AccBalsheetMstID = Convert.ToInt16(selectedBalsheet);
            searchRequest.PolicyDefaultAnswer = PolicyDefaultAnswer;
            if (searchRequest.ID > 0 && searchRequest.AccBalsheetMstID > 0)
            {
                IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollectionResponse = _InventorySalesMasterAndTransactionServiceAccess.GetBillDetailsByID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listInventorySalesMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
            }
            return Json(listInventorySalesMasterAndTransaction, JsonRequestBehavior.AllowGet);
        }

         [HttpGet]
        public ActionResult OperatorSaleReport()
        {
            List<InventorySalesMasterAndTransaction> listInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
            InventorySalesMasterAndTransactionSearchRequest searchRequest = new InventorySalesMasterAndTransactionSearchRequest();
            InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);
            searchRequest.CreatedBy = Convert.ToInt32(Session["UserID"]);
            //searchRequest.IsOnline = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsOffLineApp"]);
               if (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IsOffLineApp"]) == 1)
               {
                   searchRequest.IsOnline = false;
               }
               else
               {
                   searchRequest.IsOnline = true;

               }
            //model.InventorySalesMasterAndTransactionDTO.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]); ;
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollectionResponse = _InventorySalesMasterAndTransactionServiceAccess.GetInventorySalesReportToOperator(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventorySalesMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.InventoryOperatorSaleReportList = listInventorySalesMasterAndTransaction;
            model.TodaySale = Math.Round((from a in model.InventoryOperatorSaleReportList select (a.LocationWiseSale)).Sum(), 2);

            //if (model.InventoryOperatorSaleReportList.Count > 0)
            //{
            //    model.TotalItem = model.InventoryOperatorSaleReportList.Count;
            //    model.Location = model.InventoryOperatorSaleReportList[0].Location;
            //   model.TransactionDate=model.InventoryOperatorSaleReportList[0].TransactionDate;
            //   model.TodaySale = model.InventoryOperatorSaleReportList[0].TodaySale;
            //   model.EmployeeName = model.InventoryOperatorSaleReportList[0].EmployeeName;

            //}
            //InventorySalesMasterAndTransaction a = null;
            //foreach (var item in listInventorySalesMasterAndTransaction)
            //{
            //    a = new InventorySalesMasterAndTransaction();
            //    a.Location = item.Location;
            //    a.TransactionDate = item.TransactionDate;
            //    a.TodaySale = item.TodaySale;
            //    a.EmployeeName = item.EmployeeName;
            //    model.InventoryOperatorSaleReportList.Add(a);

            //}


            // return Json(listInventorySalesMasterAndTransaction, JsonRequestBehavior.AllowGet);
            return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/OperatorSaleReport.cshtml", model);


        }
         protected string GetPolicyApplicableStatus(string PolicyCode)
         {
             try
             {
                 IGeneralPolicyRulesViewModel model = new GeneralPolicyRulesViewModel();
                 model.GeneralPolicyRulesDTO = new GeneralPolicyRules();
                 model.GeneralPolicyRulesDTO.ConnectionString = _connectioString;
                 model.GeneralPolicyRulesDTO.PolicyCode = PolicyCode;
                 IBaseEntityResponse<GeneralPolicyRules> response = _GeneralPolicyRulesServiceAcess.GetPolicyApplicableStatus(model.GeneralPolicyRulesDTO);
                 return (response != null && response.Entity != null) ? response.Entity.PolicyApplicableStatus : string.Empty;
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
         }
       
         protected List<InventoryInWardMasterAndInWardDetails> Getsystemseeting(Int16 selectedBalsheet)
         {
             InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest = new InventoryInWardMasterAndInWardDetailsSearchRequest();
             searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
             searchRequest.BalanceSheetID = selectedBalsheet;
             List<InventoryInWardMasterAndInWardDetails> listInWardMasterAndInWardDetails = new List<InventoryInWardMasterAndInWardDetails>();

             IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollectionResponse = _InventoryInWardMasterAndInWardDetailsServiceAccess.GetInvSystemSetting(searchRequest);
             if (baseEntityCollectionResponse != null)
             {
                 if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                 {
                     listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                 }
             }
             return listInWardMasterAndInWardDetails;
         }
         protected List<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(string CentreCode,string PolicyApplicableStatus,string PolicyCode)
         {
             GeneralPolicyRulesSearchRequest searchRequest = new GeneralPolicyRulesSearchRequest();
             searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
             searchRequest.PolicyApplicableStatus = PolicyApplicableStatus;
             searchRequest.centreCode=CentreCode;
             searchRequest.PolicyCode = PolicyCode;
             List<GeneralPolicyRules> listInWardMasterAndInWardDetails = new List<GeneralPolicyRules>();

             IBaseEntityCollectionResponse<GeneralPolicyRules> baseEntityCollectionResponse = _GeneralPolicyRulesServiceAcess.GetPolicyAnswerByPolicyStatus(searchRequest);
             if (baseEntityCollectionResponse != null)
             {
                 if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                 {
                     listInWardMasterAndInWardDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                 }
             }
             return listInWardMasterAndInWardDetails;
         }

         [HttpGet]
        public ActionResult HoldBill()
        {
            //For CustomerTypeList
            //List<SelectListItem> CustomerTypeList = new List<SelectListItem>();
            //ViewBag.CustomerTypeList = new SelectList(CustomerTypeList, "Value", "Text");
            //List<SelectListItem> li_CustomerTypeList = new List<SelectListItem>();
            //li_CustomerTypeList.Add(new SelectListItem { Text = "Walk-In", Value = "WI" });
            //li_CustomerTypeList.Add(new SelectListItem { Text = "Home Delivery", Value = "HD" });
            //ViewData["CustomerTypeList"] = li_CustomerTypeList;

            return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/HoldBill.cshtml");
        }

         [HttpPost]
         public ActionResult HoldBill(InventorySalesMasterAndTransactionViewModel model)
         {
             try
             {
                 model.InventorySalesMasterAndTransactionDTO.ConnectionString = _connectioString;
                 model.InventorySalesMasterAndTransactionDTO.ID = model.ID;
                 model.InventorySalesMasterAndTransactionDTO.BalanceSheetID = model.BalanceSheetID;
                 model.InventorySalesMasterAndTransactionDTO.BillAmount = model.BillAmount;
                 model.InventorySalesMasterAndTransactionDTO.RoundUpAmount = model.RoundUpAmount;
                 model.InventorySalesMasterAndTransactionDTO.DeliveryCharge = model.DeliveryCharge;
                 model.InventorySalesMasterAndTransactionDTO.TotalTaxAmount = model.TotalTaxAmount;
                 model.InventorySalesMasterAndTransactionDTO.TotalGrossAmount = model.TotalGrossAmount;
                 model.InventorySalesMasterAndTransactionDTO.TotalDiscount = model.TotalDiscount;
                 model.InventorySalesMasterAndTransactionDTO.HoldBillReference = model.HoldBillReference;
                 model.InventorySalesMasterAndTransactionDTO.LocationID = model.LocationID;
                 model.InventorySalesMasterAndTransactionDTO.CounterID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Counter1"]);
                 model.InventorySalesMasterAndTransactionDTO.XMLstring = model.XMLstring;
                 model.InventorySalesMasterAndTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                 IBaseEntityResponse<InventorySalesMasterAndTransaction> response = _InventorySalesMasterAndTransactionServiceAccess.InsertInventoryHoldBill(model.InventorySalesMasterAndTransactionDTO);
                 model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                 return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
         }

         [HttpGet]
         public ActionResult Payment()
        {
           // For CustomerTypeList
            List<SelectListItem> CustomerTypeList = new List<SelectListItem>();
            ViewBag.CustomerTypeList = new SelectList(CustomerTypeList, "Value", "Text");
            List<SelectListItem> li_CustomerTypeList = new List<SelectListItem>();
            li_CustomerTypeList.Add(new SelectListItem { Text = "Walk-In", Value = "WI" });
            li_CustomerTypeList.Add(new SelectListItem { Text = "Home Delivery", Value = "HD" });
            ViewData["CustomerTypeList"] = li_CustomerTypeList;

            return PartialView("/Views/Inventory/InventorySalesMasterAndTransaction/Payment.cshtml");
        }
        
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public ActionResult GetInventoryCounterLog_OpeningCash_TotalSaleAmount(string SelectedCounterID)
        {

            if (String.IsNullOrEmpty(SelectedCounterID))
            {
                throw new ArgumentNullException("SelectedCounterID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCounterID, out id);
            var openingCashAndTotalSaleAmount = GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(Convert.ToInt32(SelectedCounterID), Convert.ToInt32(Session["UserID"]));
            var result = string.Empty;
            if (openingCashAndTotalSaleAmount.Count > 0)
            {

                result = Convert.ToString(openingCashAndTotalSaleAmount[0].OpeningCash);
                result = result + '~' + Convert.ToString(openingCashAndTotalSaleAmount[0].ClosingCash);
            }
            else
            {
                result = "0.00" + "~" + "0.00";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(int CounterID, int UserID)
        {
            InventoryCounterLogAndLockDetailsSearchRequest searchRequest = new InventoryCounterLogAndLockDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CounterMasterID = CounterID;
            searchRequest.UserID = UserID;
            List<InventoryCounterLogAndLockDetails> listInventoryCounterLogAndLockDetails = new List<InventoryCounterLogAndLockDetails>();
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollectionResponse = _inventoryCounterLogAndLockDetailsServiceAccess.GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCounterLogAndLockDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInventoryCounterLogAndLockDetails;
        }

        protected List<InventorySalesMasterAndTransaction> GetListInventorySalesMasterAndTransactionBillPrintList(string locationID, string selectedBalsheet, string keyPressNumber, string PolicyDefaultAnswer)
        {
            InventorySalesMasterAndTransactionSearchRequest searchRequest = new InventorySalesMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LocationID = Convert.ToInt32(locationID);
            searchRequest.AccBalsheetMstID = Convert.ToInt16(selectedBalsheet);
            searchRequest.keyPressNumber = Convert.ToInt16(keyPressNumber);
            searchRequest.PolicyDefaultAnswer = PolicyDefaultAnswer;
            searchRequest.CounterMstID = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Counter1"]);
            List<InventorySalesMasterAndTransaction> listInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollectionResponse = _InventorySalesMasterAndTransactionServiceAccess.GetInventorySalesMasterAndTransactionBillPrintList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventorySalesMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInventorySalesMasterAndTransaction;
        }

        protected List<InventoryCounterLogAndLockDetails> GetListInventoryCounterLockStatus(int AccBalanceSheetID, int CounterID, int UserID, string TokenCode)
        {
            InventoryCounterLogAndLockDetailsSearchRequest searchRequest = new InventoryCounterLogAndLockDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalsheetMstID = AccBalanceSheetID;
            searchRequest.CounterMasterID = CounterID;
            searchRequest.UserID = UserID;
            searchRequest.TokenCode = TokenCode;

            List<InventoryCounterLogAndLockDetails> listInventoryCounterLogAndLockDetails = new List<InventoryCounterLogAndLockDetails>();
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollectionResponse = _inventoryCounterLogAndLockDetailsServiceAccess.GetInventoryCounterLockStatus(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCounterLogAndLockDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInventoryCounterLogAndLockDetails;
        }

        protected List<InventoryCounterMaster> GetInventoryCounterMaster(int AccBalanceSheetID, int CounterID)
        {
            InventoryCounterMasterSearchRequest searchRequest = new InventoryCounterMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalsheetMstID = AccBalanceSheetID;
            searchRequest.ID = CounterID;

            List<InventoryCounterMaster> listInventoryCounterMaster = new List<InventoryCounterMaster>();
            IBaseEntityCollectionResponse<InventoryCounterMaster> baseEntityCollectionResponse = _inventoryCounterMasterServiceAccess.GetInventoryCounterMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCounterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listInventoryCounterMaster;
        }

        ////Non-Action method to fetch list of location
        protected List<InventoryLocationMaster> GetLocationList(string balancesheet)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalanceSheetID = Convert.ToInt16(balancesheet);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _inventoryLocationMasterServiceAccess.GetInventoryLocationMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        ////Non-Action method to fetch list of items
        [HttpPost]
        public JsonResult GetItemSearchList(string term, string locationID, string BalanceSheetID, string PolicyDefaultAnswer)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LocationID = Convert.ToInt32(!string.IsNullOrEmpty(locationID) ? locationID : null);
            searchRequest.AccBalsheetMstID = Convert.ToInt16(!string.IsNullOrEmpty(BalanceSheetID) ? BalanceSheetID : null);
            searchRequest.SearchWord = term;
            searchRequest.PolicyDefaultAnswer = PolicyDefaultAnswer;
            List<InventoryItemMaster> listFeeSubType = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetInventoryItemSearchListForSale(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              id = r.ID,
                              name = r.ItemName,
                              itemCode = r.ItemCode,
                              rate = r.SaleRate,
                              picture = r.Picture,
                              currencyCode = r.CurrencyCode,
                              currentStockQty = r.CurrentStockQty,
                              unitID = r.UnitID,
                              unitCode = r.UnitCode,
                              rateDecreaseByPercentage = r.RateDecreaseByPercentage,
                              genTaxGroupMasterID = r.GenTaxGroupMasterID,
                              isExpiry = r.IsExpiry,
                              isTaxInclusive = r.IsTaxInclusive,
                              taxRatePercentage = r.TaxRatePercentage,
                              TaxAmount = r.TaxAmount,
                              SaleRateExcludingtax=r.SaleRateExcludingtax,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        ////Non-Action method to fetch list of batch
        [HttpPost]
        public JsonResult GetBatchNumberOfItem(string term, int itemID)
        {
            var data = GetBatchList(term, itemID);
            var result = (from r in data
                          select new
                          {
                              id = r.BatchID,
                              name = r.BatchNumber,
                              batchQuantity = r.BatchQuantity,
                              expiryDate = r.ExpiryDate, 
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected int GetOpenBillCount(int locationID,string balancesheetID,int counterID)
        {
            InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
            model.InventorySalesMasterAndTransactionDTO = new InventorySalesMasterAndTransaction();
            model.InventorySalesMasterAndTransactionDTO.LocationID = locationID;
            model.InventorySalesMasterAndTransactionDTO.AccBalsheetMstID = Convert.ToInt16(balancesheetID);
            model.InventorySalesMasterAndTransactionDTO.CounterID= counterID;
            model.InventorySalesMasterAndTransactionDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = _InventorySalesMasterAndTransactionServiceAccess.SelectHoldBillCount(model.InventorySalesMasterAndTransactionDTO);
            if (response != null && response.Entity != null)
            {
                model.InventorySalesMasterAndTransactionDTO.OpenBillCount = response.Entity.OpenBillCount;
            }
            return model.InventorySalesMasterAndTransactionDTO.OpenBillCount;
        }

        protected List<InventoryItemMaster> GetBatchList(string term, int itemID)
        {
            InventoryItemMasterSearchRequest searchRequest = new InventoryItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemID = itemID;
            searchRequest.SearchWord = term;
            List<InventoryItemMaster> listFeeSubType = new List<InventoryItemMaster>();
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollectionResponse = _inventoryItemMasterServiceAccess.GetBatchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listFeeSubType;
        }

        ////Non-Action method to fetch list of items
        [HttpPost]
        public JsonResult GetCustomerNameSearchList(string term)
        {
            InventoryCustomerMasterSearchRequest searchRequest = new InventoryCustomerMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<InventoryCustomerMaster> listInventoryCustomerMaster = new List<InventoryCustomerMaster>();
            IBaseEntityCollectionResponse<InventoryCustomerMaster> baseEntityCollectionResponse = _inventoryCustomerMasterServiceAccess.GetInventoryCustomerMasterSelectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listInventoryCustomerMaster
                          select new
                          {
                              id = r.ID,
                              name = r.Name,
                              contactNumber = r.ContactNumber,
                              address = r.Address,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        ////Non-Action method to fetch ITEM QUANTITY
        [HttpPost]
        public JsonResult GetInventoryItemQuantity(string selectedBalsheetID)
        {
            InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
            model.InventorySalesMasterAndTransactionDTO = new InventorySalesMasterAndTransaction();
            model.InventorySalesMasterAndTransactionDTO.ConnectionString = _connectioString;
            model.InventorySalesMasterAndTransactionDTO.InvCounterApplicableDetailsID = invCounterApplicableDetailsID;
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = _InventorySalesMasterAndTransactionServiceAccess.GetInventoryItemQuantity(model.InventorySalesMasterAndTransactionDTO);
            return Json((response != null && response.Entity != null) ? response.Entity.Quantity : 0, JsonRequestBehavior.AllowGet);
        }

        public string GetCentreCode()
        {
            // For Center
            AccountBalancesheetMasterViewModel model1 = new AccountBalancesheetMasterViewModel();
            model1.AccBalsheetMasterDTO = new AccountBalancesheetMaster();
            model1.AccBalsheetMasterDTO.ID = Convert.ToInt16(Session["BalancesheetID"]);
            model1.AccBalsheetMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<AccountBalancesheetMaster> response1 = _accountBalancesheetMasterServiceAccess.SelectByID(model1.AccBalsheetMasterDTO);
            return (response1 != null && response1.Entity != null) ? response1.Entity.CentreCode : string.Empty;
        }
        [HttpPost]
        public JsonResult CheckFocusOnAction(string actionOn, string data)
        {
            InventorySalesMasterAndTransactionViewModel model = new InventorySalesMasterAndTransactionViewModel();
            model.InventorySalesMasterAndTransactionDTO = new InventorySalesMasterAndTransaction();
            model.InventorySalesMasterAndTransactionDTO.ActionOn = actionOn;
            model.InventorySalesMasterAndTransactionDTO.ActionName = data;
            model.InventorySalesMasterAndTransactionDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = _InventorySalesMasterAndTransactionServiceAccess.CheckFocusOnAction(model.InventorySalesMasterAndTransactionDTO);
            if (response != null && response.Entity != null)
            {
                model.InventorySalesMasterAndTransactionDTO.ActionID = response.Entity.ActionID;
                model.InventorySalesMasterAndTransactionDTO.CustomerAddress = response.Entity.CustomerAddress;
                model.InventorySalesMasterAndTransactionDTO.CustomerContactNo = response.Entity.CustomerContactNo;
            }
            return Json(model.InventorySalesMasterAndTransactionDTO.ActionID + "~" + model.InventorySalesMasterAndTransactionDTO.CustomerAddress + "~" + model.InventorySalesMasterAndTransactionDTO.CustomerContactNo, JsonRequestBehavior.AllowGet);
        }



        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<InventorySalesMasterAndTransaction> GetListInventorySalesMasterAndTransaction(string SelectedBalanceSheet, out int TotalRecords)
        {
            List<InventorySalesMasterAndTransaction> listInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
            InventorySalesMasterAndTransactionSearchRequest searchRequest = new InventorySalesMasterAndTransactionSearchRequest();
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
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalanceSheet);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalanceSheet);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AccBalsheetMstID = Convert.ToInt16(SelectedBalanceSheet);
            }
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollectionResponse = _InventorySalesMasterAndTransactionServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventorySalesMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventorySalesMasterAndTransaction;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public JsonResult AjaxHandler(JQueryDataTableParamModel param, string SelectedBalanceSheet)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<InventorySalesMasterAndTransaction> filteredInventorySalesMasterAndTransaction;
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
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or Amount Like '%" + param.sSearch + "%'  or CustomerName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BillNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or Amount Like '%" + param.sSearch + "%'  or CustomerName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "Amount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or Amount Like '%" + param.sSearch + "%'  or CustomerName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "CustomerName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TransactionDate Like '%" + param.sSearch + "%' or BillNumber Like '%" + param.sSearch + "%'  or Amount Like '%" + param.sSearch + "%'  or CustomerName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(SelectedBalanceSheet) || Convert.ToString(Session["UserType"]) == "A")
            {
                filteredInventorySalesMasterAndTransaction = GetListInventorySalesMasterAndTransaction(SelectedBalanceSheet, out TotalRecords);
            }
            else
            {
                filteredInventorySalesMasterAndTransaction = new List<InventorySalesMasterAndTransaction>();
                TotalRecords = 0;
            }
            var records = filteredInventorySalesMasterAndTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TransactionDate), Convert.ToString(c.BillNumber), Convert.ToString(c.BillAmount + " Rs"), Convert.ToString(c.CustomerName), Convert.ToString(c.ID), Convert.ToString(c.BillPrintStatus) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

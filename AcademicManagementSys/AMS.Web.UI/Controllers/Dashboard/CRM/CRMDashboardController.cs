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
    public class CRMDashboardController : BaseController
    {
        ICRMReportServiceAccess _CRMReportServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;

        public CRMDashboardController()
        {
            _CRMReportServiceAccess = new CRMReportServiceAccess();
        }
        public ActionResult Index()
        {
            CRMReportViewModel model = new CRMReportViewModel();
            try
            {
                //model.CRMReportDTO = new CRMReport();
                //model.CRMReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                //model.CRMReportDTO.DataFor = "";
                //model.CRMReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<CRMReport> response = _CRMReportServiceAccess.CRMDashboardSparklineChartsReportByEmployeeID(model.CRMReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    model.CRMReportDTO.TodaysMeetingCount = response.Entity.TodaysMeetingCount;
                //    model.CRMReportDTO.AccountTarget = response.Entity.AccountTarget;
                //    model.CRMReportDTO.BillingTarget = response.Entity.BillingTarget;
                //    model.CRMReportDTO.PeriodType = response.Entity.PeriodType;
                //    model.CRMReportDTO.TotalInvoiceAmount = response.Entity.TotalInvoiceAmount;
                //    model.CRMReportDTO.TotalHotAccount = response.Entity.TotalHotAccount;
                //    model.CRMReportDTO.TotalColdAccount = response.Entity.TotalColdAccount;
                //    model.CRMReportDTO.TotalEnquiries = response.Entity.TotalEnquiries;
                //    model.CRMReportDTO.ConversionRate = response.Entity.ConversionRate;
                //}
                return View("/Views/Dashboard/CRM/Index.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public ActionResult ConvertedCallDetails()
        {
            return PartialView("/Views/Dashboard/CRM/ConvertedCallDetails.cshtml");
        }

        public ActionResult CallAverageDetails()
        {
            return PartialView("/Views/Dashboard/CRM/CallAverageDetails.cshtml");
        }
        public ActionResult ConversionReport()
        {
            return PartialView("/Views/Dashboard/CRM/ConversionReport.cshtml");
        }

        public ActionResult CallbackReport()
        {
            return PartialView("/Views/Dashboard/CRM/CallbackReport.cshtml");
        }

        public ActionResult PendingCalls()
        {
            CRMReportViewModel model = new CRMReportViewModel();
            try
            {
                CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                searchRequest.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMDashboardSparklineChartsReportforPendingCalls(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    model.CRMReportDTO.CallCountList = Convert.ToString(baseEntityCollectionResponse.CollectionResponse[1].CallCountList);
                    string[] CallCountList = model.CRMReportDTO.CallCountList.Split(',');
                    var SumOfArray = 0;
                    foreach (var i in CallCountList)
                    {
                        SumOfArray = Convert.ToInt16(i) + Convert.ToInt16(SumOfArray);
                    }
                    model.CRMReportDTO.PendingCalls = Convert.ToString(SumOfArray);
                    model.MapArray = string.Join(",", CallCountList);
                }
                    return PartialView("/Views/Dashboard/CRM/PendingCalls.cshtml", model);
                }
            
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult CallbackCalls()
        {
            CRMReportViewModel model = new CRMReportViewModel();
            try
            {
                model.CRMReportDTO = new CRMReport();
                CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                searchRequest.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMDashboardSparklineChartsReportforCallbackCalls(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    model.CRMReportDTO.CallCountList = Convert.ToString(baseEntityCollectionResponse.CollectionResponse[0].CallCountList);
                    string[] CallCountList = model.CRMReportDTO.CallCountList.Split(',');
                    var SumOfArray = 0;
                    foreach (var i in CallCountList)
                    {
                        SumOfArray = Convert.ToInt16(i) + Convert.ToInt16(SumOfArray);
                    }
                    model.CRMReportDTO.CallbackCalls = Convert.ToString(SumOfArray);
                    model.MapArray = string.Join(",", CallCountList);
                }
                return PartialView("/Views/Dashboard/CRM/CallbackCalls.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult TotalAllocatedCall()
        {
            CRMReportViewModel model = new CRMReportViewModel();
            try
            {
                CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                searchRequest.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMTotalAllocatedCall(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    model.CRMReportDTO.CallCountList = Convert.ToString(baseEntityCollectionResponse.CollectionResponse[0].CallCountList);
                    string[] CallCountList = model.CRMReportDTO.CallCountList.Split(',');
                    var SumOfArray = 0;
                    foreach (var i in CallCountList)
                    {
                        SumOfArray = Convert.ToInt32(i) + Convert.ToInt32(SumOfArray);
                    }
                    model.CRMReportDTO.TotalAllocatedCall = Convert.ToString(SumOfArray);
                    model.MapArray = string.Join(",", CallCountList);
                }
                return PartialView("/Views/Dashboard/CRM/TotalAllocatedCall.cshtml", model);
                      
            }

            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult TotalCallbackCall()
        {
            CRMReportViewModel model = new CRMReportViewModel();
            try
            {
                CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
                searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                searchRequest.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMTotalCallbackCall(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    model.CRMReportDTO.CallCountList = Convert.ToString(baseEntityCollectionResponse.CollectionResponse[0].CallCountList);
                    string[] CallCountList = model.CRMReportDTO.CallCountList.Split(',');
                    var SumOfArray = 0;
                    foreach (var i in CallCountList)
                    {
                        SumOfArray = Convert.ToInt16(i) + Convert.ToInt16(SumOfArray);
                    }
                    model.CRMReportDTO.TotalCallbackCall = Convert.ToString(SumOfArray);
                     model.MapArray = string.Join(",", CallCountList);
                }
                return PartialView("/Views/Dashboard/CRM/TotalCallbackCall.cshtml", model);
            }

            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public JsonResult GetCRMConvertedCallDetails()
        {

            var data = CRMConvertedCallDetails(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in data
                          select new
                          {
                              callStatus = s.CallStatus,
                              callCountList = s.CallCountList,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCRMCallAverageDetails()
        {

            var data = CRMCallAverageDetails(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in data
                          select new
                          {
                              callStatus = s.CallStatus,
                              callCountList = s.CallCountList,
                              //invoiceMonth = s.InvoiceMonth,
                              //totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCRMConversionReport()
        {

            var data = CRMConversionReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in data
                          select new
                          {
                              callStatus = s.CallStatus,
                              callCountList = s.CallCountList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCRMCallbackReport()
        {

            var data = CRMCallbackReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in data
                          select new
                          {
                              callStatus = s.CallStatus,
                              callCountList = s.CallCountList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
       


        // Non-Action Method
        #region Methods


        protected List<CRMReport> CRMConvertedCallDetails(int employeeID, int adminRoleID)
        {
            CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMReport> ConvertedCallDetails = new List<CRMReport>();
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetConvertedCallDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ConvertedCallDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ConvertedCallDetails;
        }

        protected List<CRMReport> CRMCallAverageDetails(int employeeID, int adminRoleID)
        {
            CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMReport> CallAverageDetails = new List<CRMReport>();

            IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMCallAverageDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CallAverageDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CallAverageDetails;
        }
        protected List<CRMReport> CRMConversionReport(int employeeID, int adminRoleID)
        {
            CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMReport> CRMConversionReport = new List<CRMReport>();

            IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMConversionReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMConversionReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMConversionReport;
        }

        protected List<CRMReport> CRMCallbackReport(int employeeID, int adminRoleID)
        {
            CRMReportSearchRequest searchRequest = new CRMReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMReport> CRMCallbackReport = new List<CRMReport>();

            IBaseEntityCollectionResponse<CRMReport> baseEntityCollectionResponse = _CRMReportServiceAccess.GetCRMCallbackReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallbackReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallbackReport;
        }


        #endregion
    }
}
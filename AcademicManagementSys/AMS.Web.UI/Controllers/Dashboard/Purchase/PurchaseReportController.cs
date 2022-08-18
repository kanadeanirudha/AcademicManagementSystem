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
    public class PurchaseReportController : BaseController
    {
        IPurchaseReportServiceAccess _PurchaseReportServiceAccess = null;
        
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        public PurchaseReportController()
        {
            _PurchaseReportServiceAccess = new PurchaseReportServiceAccess();
           
        }


        public ActionResult MonthlyPurchaseDetails()
        {
            return PartialView("/Views/Dashboard/Purchase/MonthlyPurchaseDetails.cshtml");
        }

        public ActionResult PurchaseOrderConversionReport()
        {
            return PartialView("/Views/Dashboard/Purchase/PurchaseOrderConversionReport.cshtml");
        }


        public ActionResult RequisitionConversionReport()
        {
            return PartialView("/Views/Dashboard/Purchase/RequisitionConversionReport.cshtml");
        }

        public ActionResult TopFiveVendorDetails()
        {
            return PartialView("/Views/Dashboard/Purchase/TopFiveVendorDetails.cshtml");
        }

        public ActionResult MonthlyMarginDetails()
        {
            return PartialView("/Views/Dashboard/Purchase/MonthlyMarginDetails.cshtml");
        }

        public ActionResult MonthlyPurchaseOrderDetails()
        {
            return PartialView("/Views/Dashboard/Purchase/MonthlyPurchaseOrderDetails.cshtml");
        }

        public ActionResult TotalItemBelowReorderPoint()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalItemBelowReorderPoint";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalItemBelowReorderPoint.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult TotalItemBelowSafetyStock()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalItemBelowSafetyStock";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalItemBelowSafetyStock.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalManualRequisition()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalManualRequisition";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalManualRequisition.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalPendingPurchaseOrder()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalPendingPurchaseOrder";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalPendingPurchaseOrder.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult TotalPurchaseOrder()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalPurchaseOrder";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalPurchaseOrder.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalRequisition()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
                // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalRequisition";
                // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

              //  IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
               // if (response != null && response.Entity != null)
               // {
                    // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                    // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
              //  }
                return PartialView("/Views/Dashboard/Purchase/TotalRequisition.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalVendor()
        {
            PurchaseReportViewModel model = new PurchaseReportViewModel();
            try
            {
                model.PurchaseReportDTO = new PurchaseReport();
               // model.PurchaseReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.PurchaseReportDTO.DataFor = "TotalVendor";
               // model.PurchaseReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.PurchaseReportDTO.ConnectionString = _connectioString;

                //IBaseEntityResponse<PurchaseReport> response = _PurchaseReportServiceAccess.PurchaseReportSparkLineChartReportByEmployeeID(model.PurchaseReportDTO);
                //if (response != null && response.Entity != null)
                //{
                //   // model.PurchaseReportDTO.ReportCount = response.Entity.ReportCount;
                //   // model.PurchaseReportDTO.ReportList = response.Entity.ReportList;
                //}
                return PartialView("/Views/Dashboard/Purchase/TotalVendor.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public JsonResult PurchaseReportTopFiveVendorList()
        {

            var VendorDetails = PurchaseReportTopFiveVendorList(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in VendorDetails
                          select new
                          {
                             // accountName = s.AccountName,
                             // totalInvoiceAmountList = s.TotalInvoiceAmountList,
                             // invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPurchaseMonthlyPurchaseDetails()
        {

            var PurchaseDetails = GetPurchaseMonthlyPurchaseDetails(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in PurchaseDetails
                          select new
                          {
                             // totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetRequisitionConversion()
        {

            var ReqConversion = GetRequisitionConversion(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in ReqConversion
                          select new
                          {
                              // totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPurchaseOrderConversion()
        {

            var POConversion = GetPurchaseOrderConversion(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in POConversion
                          select new
                          {
                              // totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMonthlyMarginDetails()
        {

            var POConversion = GetMonthlyMarginDetails(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in POConversion
                          select new
                          {
                              // totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetMonthlyPurchaseOrderDetails()
        {

            var POConversion = GetMonthlyPurchaseOrderDetails(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in POConversion
                          select new
                          {
                              Months = s.Months,
                              ReportList = s.ReportList,
                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        // Non-Action Method
        #region Methods

        protected List<PurchaseReport> PurchaseReportTopFiveVendorList(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
           // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> PurchaseVendorDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetTopFiveVendorReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }

        protected List<PurchaseReport> GetPurchaseMonthlyPurchaseDetails(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
           // searchRequest.EmployeeID = employeeID;
           // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> MonthlyPurchaseDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetMonthlyPurchaseReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    MonthlyPurchaseDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return MonthlyPurchaseDetailsList;
        }

        protected List<PurchaseReport> GetRequisitionConversion(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
            // searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> MonthlyPurchaseDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetRequisitionConversionReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    MonthlyPurchaseDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return MonthlyPurchaseDetailsList;
        }

        protected List<PurchaseReport> GetPurchaseOrderConversion(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
            // searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> MonthlyPurchaseDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetPurchaseOrderConversionReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    MonthlyPurchaseDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return MonthlyPurchaseDetailsList;
        }

        protected List<PurchaseReport> GetMonthlyMarginDetails(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
            // searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> MonthlyPurchaseDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetMonthlyMarginDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    MonthlyPurchaseDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return MonthlyPurchaseDetailsList;
        }

        protected List<PurchaseReport> GetMonthlyPurchaseOrderDetails(int employeeID, int adminRoleID)
        {
            PurchaseReportSearchRequest searchRequest = new PurchaseReportSearchRequest();
            // searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<PurchaseReport> MonthlyPurchaseDetailsList = new List<PurchaseReport>();

            IBaseEntityCollectionResponse<PurchaseReport> baseEntityCollectionResponse = _PurchaseReportServiceAccess.GetMonthlyPurchaseOrderDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    MonthlyPurchaseDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return MonthlyPurchaseDetailsList;
        }
        

       

        #endregion
    }
}

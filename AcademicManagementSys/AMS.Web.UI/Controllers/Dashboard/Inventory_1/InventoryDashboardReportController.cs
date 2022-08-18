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
    public class InventoryDashboardReportController : BaseController
    {
        IInventoryDashboardReportServiceAccess _InventoryDashboardReportServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        public InventoryDashboardReportController()
        {
            _InventoryDashboardReportServiceAccess = new InventoryDashboardReportServiceAccess();

        }


        public ActionResult MonthlySalesDetails()
        {
            return PartialView("/Views/Dashboard/Inventory_1/MonthlySalesDetails.cshtml");
        }

        public ActionResult DailySalesDetails()
        {
            return PartialView("/Views/Dashboard/Inventory_1/DailySalesDetails.cshtml");
        }
        public ActionResult TopFivePromotion()
        {
            return PartialView("/Views/Dashboard/Inventory_1/TopFivePromotion.cshtml");
        }

        public ActionResult TotalSalePromotionPieChart()
        {
            return PartialView("/Views/Dashboard/Inventory_1/TotalSalePromotionPieChart.cshtml");
        }
        public ActionResult TakeAwayFineDinePieChart()
        {
            return PartialView("/Views/Dashboard/Inventory_1/TakeAwayFineDinePieChart.cshtml");
        }
        public ActionResult TotalItemCount()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalItemCount";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardReportSparkLineChartReport(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                     model.InventoryDashboardReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalItemCount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalInventoryAmount()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalInventoryAmount";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardReportSparkLineChartReport(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                     model.InventoryDashboardReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalInventoryAmount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult TotalRestaurantItems()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalRestaurantItems";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardReportSparkLineChartReport(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                     model.InventoryDashboardReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalRestaurantItems.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        } 
        public ActionResult TotalRetailSaleItems()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalRetailSaleItems";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardReportSparkLineChartReport(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                    model.InventoryDashboardReportDTO.SaleAmount = response.Entity.SaleAmount;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalRetailSaleItems.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult TotalRetailStockAmount()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalRetailStockAmount";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);

                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardStockAmountSparkLineChartReportForRetail(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                    model.InventoryDashboardReportDTO.SaleAmount = response.Entity.SaleAmount;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalRetailStockAmount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult TotalCafeStockAmount()
        {
            InventoryDashboardReportViewModel model = new InventoryDashboardReportViewModel();
            try
            {
                model.InventoryDashboardReportDTO = new InventoryDashboardReport();
                // model.InventoryDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.InventoryDashboardReportDTO.DataFor = "TotalCafeStockAmount";
                // model.InventoryDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.InventoryDashboardReportDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
                IBaseEntityResponse<InventoryDashboardReport> response = _InventoryDashboardReportServiceAccess.InventoryDashboardStockAmountSparkLineChartReportForCafe(model.InventoryDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    // model.InventoryDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                    model.InventoryDashboardReportDTO.SaleAmount = response.Entity.SaleAmount;
                }
                return PartialView("/Views/Dashboard/Inventory_1/TotalCafeStockAmount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public JsonResult InventoryGetMonthlySaleReport()
        {

            var Totalsale = InventoryGetMonthlySaleReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in Totalsale
                          select new
                          {
                              Months = s.Months,
                              BillRelevantTo = s.BillRelevantTo,
                              TotalInvoiceAmountList = s.TotalInvoiceAmountList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult InventoryGetDailySaleReport()
        {

            var Totalsale = InventoryGetDailySaleReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in Totalsale
                          select new
                          {
                               Days = s.Days,
                               ReportList = s.ReportList,
                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTopFivePromotionsReport()
        {

            var Totalsale = InventoryTopFivePromotionReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in Totalsale
                          select new
                          {
                              SourceKey = s.SourceKey,
                              PromotionAmount = s.PromotionAmount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTotalSalePromotionReport()
        {

            var Totalsale = GetTotalSalePromotion(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in Totalsale
                          select new
                          {
                              SourceKey = s.SourceKey,
                              SaleAmount = s.SaleAmount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTakeAwayFineDinePieChartReport()
        {

            var Totalsale = GetPieChartForTakeAwayReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in Totalsale
                          select new
                          {
                              SourceKey = s.SourceKey,
                              SaleAmount = s.SaleAmount,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Non-Action Method
        #region Methods

        protected List<InventoryDashboardReport> InventoryGetMonthlySaleReport(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
           // searchRequest.AdminRoleID = adminRoleID;
            
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(adminRoleID, 0);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            searchRequest.CentreListXML = GetCentreListXML;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
            List<InventoryDashboardReport> PurchaseVendorDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportServiceAccess.GetMonthlySaleReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }

        protected List<InventoryDashboardReport> InventoryGetDailySaleReport(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;
            
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(adminRoleID, 0);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            searchRequest.CentreListXML = GetCentreListXML;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
            List<InventoryDashboardReport> PurchaseVendorDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportServiceAccess.GetDailySaleReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }

        protected List<InventoryDashboardReport> InventoryTopFivePromotionReport(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(adminRoleID, 0);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            searchRequest.CentreListXML = GetCentreListXML;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
            List<InventoryDashboardReport> PurchaseVendorDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportServiceAccess.GetTopFivePromotionReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }

        protected List<InventoryDashboardReport> GetTotalSalePromotion(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(adminRoleID, 0);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            searchRequest.CentreListXML = GetCentreListXML;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
            List<InventoryDashboardReport> PurchaseVendorDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportServiceAccess.GetTotalSaleAndPromotionReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }

        protected List<InventoryDashboardReport> GetPieChartForTakeAwayReport(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            //searchRequest.EmployeeID = employeeID;
            // searchRequest.AdminRoleID = adminRoleID;

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(adminRoleID, 0);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            searchRequest.CentreListXML = GetCentreListXML;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WareHouseDb.ConnectionString"]);
            List<InventoryDashboardReport> PurchaseVendorDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportServiceAccess.GetFineDineTakeAwayPieChartReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    PurchaseVendorDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return PurchaseVendorDetailsList;
        }
        #endregion
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class InventoryDashboardReportServiceAccess : IInventoryDashboardReportServiceAccess
    {
        IInventoryDashboardReportBA InventoryDashboardReportBA = null;

        public InventoryDashboardReportServiceAccess()
        {
            InventoryDashboardReportBA = new InventoryDashboardReportBA();
        }

        //InventoryDashboardReport


        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetMonthlySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            return InventoryDashboardReportBA.GetMonthlySaleReport(searchRequest);
        }

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetDailySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            return InventoryDashboardReportBA.GetDailySaleReport(searchRequest);
        }

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardReportSparkLineChartReport(InventoryDashboardReport item)
        {
            return InventoryDashboardReportBA.InventoryDashboardReportSparkLineChartReport(item);
        }
        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTotalSaleAndPromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            return InventoryDashboardReportBA.GetTotalSaleAndPromotionReport(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTopFivePromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            return InventoryDashboardReportBA.GetTopFivePromotionReport(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetFineDineTakeAwayPieChartReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            return InventoryDashboardReportBA.GetFineDineTakeAwayPieChartReport(searchRequest);
        }

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForCafe(InventoryDashboardReport item)
        {
            return InventoryDashboardReportBA.InventoryDashboardStockAmountSparkLineChartReportForCafe(item);
        }
        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForRetail(InventoryDashboardReport item)
        {
            return InventoryDashboardReportBA.InventoryDashboardStockAmountSparkLineChartReportForRetail(item);
        }
    }
}

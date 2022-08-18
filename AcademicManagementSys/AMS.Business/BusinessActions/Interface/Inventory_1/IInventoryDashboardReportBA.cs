using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryDashboardReportBA
    {
        //InventoryDashboardReport
        IBaseEntityCollectionResponse<InventoryDashboardReport> GetMonthlySaleReport(InventoryDashboardReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDashboardReport> GetDailySaleReport(InventoryDashboardReportSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardReportSparkLineChartReport(InventoryDashboardReport item);
        IBaseEntityCollectionResponse<InventoryDashboardReport> GetTotalSaleAndPromotionReport(InventoryDashboardReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDashboardReport> GetTopFivePromotionReport(InventoryDashboardReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDashboardReport> GetFineDineTakeAwayPieChartReport(InventoryDashboardReportSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForCafe(InventoryDashboardReport item);
        IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForRetail(InventoryDashboardReport item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class PurchaseReportServiceAccess : IPurchaseReportServiceAccess
    {
        IPurchaseReportBA PurchaseReportBA = null;

        public PurchaseReportServiceAccess()
        {
            PurchaseReportBA = new PurchaseReportBA();
        }

        //PurchaseReport


        public IBaseEntityCollectionResponse<PurchaseReport> GetTopFiveVendorReport(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetTopFiveVendorReport(searchRequest);
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseReport(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetMonthlyPurchaseReport(searchRequest);
        }
        public IBaseEntityCollectionResponse<PurchaseReport> GetRequisitionConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetRequisitionConversionReport(searchRequest);
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetPurchaseOrderConversionReport(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetPurchaseOrderConversionReport(searchRequest);
        }

        public IBaseEntityResponse<PurchaseReport> PurchaseReportSparkLineChartReportByEmployeeID(PurchaseReport item)
        {
            return PurchaseReportBA.PurchaseReportSparkLineChartReportByEmployeeID(item);
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyPurchaseOrderDetails(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetMonthlyPurchaseOrderDetails(searchRequest);
        }

        public IBaseEntityCollectionResponse<PurchaseReport> GetMonthlyMarginDetails(PurchaseReportSearchRequest searchRequest)
        {
            return PurchaseReportBA.GetMonthlyMarginDetails(searchRequest);
        }
    }
}

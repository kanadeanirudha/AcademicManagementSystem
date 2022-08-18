using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleReportServiceAccess : ICRMSaleReportServiceAccess
    {
        ICRMSaleReportBA CRMSaleReportBA = null;

        public CRMSaleReportServiceAccess()
        {
            CRMSaleReportBA = new CRMSaleReportBA();
        }

        //CRMSaleReport


        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleTopFiveAccountReport(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetCRMSaleTopFiveAccountReport(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleMonthlyRevenueReport(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetCRMSaleMonthlyRevenueReport(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleWicklyStatusDetailsInDateRangeReport(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetCRMSaleWicklyStatusDetailsInDateRangeReport(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleReport> CRMSaleDashboardSparklineChartsReportByEmployeeID(CRMSaleReport item)
        {
            return CRMSaleReportBA.CRMSaleDashboardSparklineChartsReportByEmployeeID(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysMeetingSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetListTodaysMeetingSchedule(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysEnquiryDetails(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetListTodaysEnquiryDetails(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListSalesCallSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetListSalesCallSchedule(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMSaleReport> GetListReminders(CRMSaleReportSearchRequest searchRequest)
        {
            return CRMSaleReportBA.GetListReminders(searchRequest);
        }
    }
}

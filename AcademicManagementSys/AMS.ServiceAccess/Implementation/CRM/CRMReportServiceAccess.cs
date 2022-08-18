using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMReportServiceAccess : ICRMReportServiceAccess
    {
        ICRMReportBA CRMReportBA = null;

        public CRMReportServiceAccess()
        {
            CRMReportBA = new CRMReportBA();
        }

        //CRMReport


        public IBaseEntityCollectionResponse<CRMReport> GetConvertedCallDetails(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetConvertedCallDetails(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMReport> GetCRMCallAverageDetails(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMCallAverageDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMWicklyStatusDetailsInDateRangeReport(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMWicklyStatusDetailsInDateRangeReport(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforPendingCalls(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMDashboardSparklineChartsReportforPendingCalls(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforCallbackCalls(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMDashboardSparklineChartsReportforCallbackCalls(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMReport> GetCRMConversionReport(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMConversionReport(searchRequest);
        }
          public IBaseEntityCollectionResponse<CRMReport> GetCRMCallbackReport(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMCallbackReport(searchRequest);
        }
          public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalAllocatedCall(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMTotalAllocatedCall(searchRequest);
        }
          public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalCallbackCall(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetCRMTotalCallbackCall(searchRequest);
        }
          public IBaseEntityCollectionResponse<CRMReport> GetListTodaysMeetingSchedule(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetListTodaysMeetingSchedule(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMReport> GetListTodaysEnquiryDetails(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetListTodaysEnquiryDetails(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMReport> GetListSalesCallSchedule(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetListSalesCallSchedule(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMReport> GetListReminders(CRMReportSearchRequest searchRequest)
        {
            return CRMReportBA.GetListReminders(searchRequest);
        }
    }
}

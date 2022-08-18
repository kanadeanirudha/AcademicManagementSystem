using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMReportServiceAccess
    {
        //CRMReport

        IBaseEntityCollectionResponse<CRMReport> GetConvertedCallDetails(CRMReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMReport> GetCRMCallAverageDetails(CRMReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMReport> GetCRMWicklyStatusDetailsInDateRangeReport(CRMReportSearchRequest searchRequest);
        //IBaseEntityResponse<CRMReport> CRMDashboardSparklineChartsReportByEmployeeID(CRMReport item);
        IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforPendingCalls(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforCallbackCalls(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetCRMConversionReport(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetCRMCallbackReport(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetCRMTotalAllocatedCall(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetCRMTotalCallbackCall(CRMReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMReport> GetListTodaysMeetingSchedule(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetListTodaysEnquiryDetails(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetListSalesCallSchedule(CRMReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMReport> GetListReminders(CRMReportSearchRequest searchRequest);
        
    }
}

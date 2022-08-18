using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMSaleReportBA
    {
        //CRMSaleReport
        IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleTopFiveAccountReport(CRMSaleReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleMonthlyRevenueReport(CRMSaleReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleWicklyStatusDetailsInDateRangeReport(CRMSaleReportSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleReport> CRMSaleDashboardSparklineChartsReportByEmployeeID(CRMSaleReport item);

        IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysMeetingSchedule(CRMSaleReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysEnquiryDetails(CRMSaleReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMSaleReport> GetListSalesCallSchedule(CRMSaleReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleReport> GetListReminders(CRMSaleReportSearchRequest searchRequest);
    }
}

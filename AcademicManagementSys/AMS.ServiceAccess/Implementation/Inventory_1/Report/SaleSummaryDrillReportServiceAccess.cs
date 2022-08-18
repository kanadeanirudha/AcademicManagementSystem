
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SaleSummaryDrillReportServiceAccess : ISaleSummaryDrillReportServiceAccess
    {
        ISaleSummaryDrillReportBA _SaleSummaryDrillReportBA = null;
        public SaleSummaryDrillReportServiceAccess()
        {
            _SaleSummaryDrillReportBA = new SaleSummaryDrillReportBA();
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_YearList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_YearList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_MonthList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_MonthList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_DayList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_DayList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_BillList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_BillList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemList(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_ItemList(searchRequest);
        }
        public IBaseEntityCollectionResponse<SaleSummaryDrillReport> GetSaleSummaryDrillReport_ItemListSaleReturn(SaleSummaryDrillReportSearchRequest searchRequest)
        {
            return _SaleSummaryDrillReportBA.GetSaleSummaryDrillReport_ItemListSaleReturn(searchRequest);
        }
    }
}

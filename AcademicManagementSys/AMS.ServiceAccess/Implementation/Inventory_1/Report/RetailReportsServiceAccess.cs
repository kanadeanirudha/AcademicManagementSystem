
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class RetailReportsServiceAccess : IRetailReportsServiceAccess
    {
        IRetailReportsBA _RetailReportsBA = null;
        public RetailReportsServiceAccess()
        {
            _RetailReportsBA = new RetailReportsBA();
        }

        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetRetailReportsBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDaysOfCoverReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetInventoryDaysOfCoverReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryBillDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetInventoryBillDetailReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryCounterDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetInventoryCounterDetailReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetRetailSalesAndMarginReportsBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetRetailSalesAndMarginReportsBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetVendorServiceLevelBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetVendorServiceLevelBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryDiscountReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetInventoryDiscountReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetInventoryStockGapAnalysisReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetInventoryStockGapAnalysisReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetRetailReportsBySearch_GetDinningReportList(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetRetailReportsBySearch_GetDinningReportList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetConsumptionDetailReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetConsumptionDetailReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetSaleSummaryReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_DateWise(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetSaleSummaryReportBySearch_DateWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailReports> GetSaleSummaryReportBySearch_OrderNoWise(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetSaleSummaryReportBySearch_OrderNoWise(searchRequest);
        }
        //public IBaseEntityCollectionResponse<RetailReports> GetInventoryCurrentStockAmount(RetailReportsSearchRequest searchRequest)
        //{
        //    return _RetailReportsBA.GetInventoryCurrentStockAmount(searchRequest);
        //}
        public IBaseEntityCollectionResponse<RetailReports> GetVendorWiseSaleAndPurchaseReport(RetailReportsSearchRequest searchRequest)
        {
            return _RetailReportsBA.GetVendorWiseSaleAndPurchaseReport(searchRequest);
        }
    }
}

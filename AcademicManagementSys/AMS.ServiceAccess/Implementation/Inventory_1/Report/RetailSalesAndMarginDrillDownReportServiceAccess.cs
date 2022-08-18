using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class RetailSalesAndMarginDrillDownReportServiceAccess : IRetailSalesAndMarginDrillDownReportServiceAccess
    {
        IRetailSalesAndMarginDrillDownReportBA _RetailSalesAndMarginDrillDownReportBA = null;
        public RetailSalesAndMarginDrillDownReportServiceAccess()
        {
            _RetailSalesAndMarginDrillDownReportBA = new RetailSalesAndMarginDrillDownReportBA();
        }

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> GetRetailSalesAndMarginDrillDownReportBySearch(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.GetRetailSalesAndMarginDrillDownReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_StoreList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            return _RetailSalesAndMarginDrillDownReportBA.RetailSalesAndMarginDrillDownReportBySearch_StoreList(searchRequest);
        }
    }
}

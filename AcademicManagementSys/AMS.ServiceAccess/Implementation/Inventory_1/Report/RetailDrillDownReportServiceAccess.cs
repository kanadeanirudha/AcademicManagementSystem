
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class RetailDrillDownReportServiceAccess : IRetailDrillDownReportServiceAccess
    {
        IRetailDrillDownReportBA _RetailDrillDownReportBA = null;
        public RetailDrillDownReportServiceAccess()
        {
            _RetailDrillDownReportBA = new RetailDrillDownReportBA();
        }

        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetGroupDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetGroupDescriptionReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseDepartmentReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetMerchantiseDepartmentReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetMerchantiseCategoryReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseSubCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetMerchantiseSubCategoryReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseBaseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetMerchantiseBaseCategoryReportBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetItemDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetItemDescriptionReportBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetStoresReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            return _RetailDrillDownReportBA.GetStoresReportBySearch(searchRequest);
        }
    }
}

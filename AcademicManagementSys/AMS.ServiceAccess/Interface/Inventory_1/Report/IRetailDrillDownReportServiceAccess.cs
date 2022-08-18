
using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Base.DTO;
using AMS.DTO;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IRetailDrillDownReportServiceAccess
    {
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetStoresReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetGroupDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseDepartmentReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseSubCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseBaseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RetailDrillDownReport> GetItemDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest);
        

    }
}

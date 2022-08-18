using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
    public interface IInventoryStoreBillingPrintingInfoDataProvider
    {
        IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest);
    }
}

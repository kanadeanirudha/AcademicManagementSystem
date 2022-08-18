using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public interface IInventoryStoreBillingPrintingInfoServiceAccess
    {
        IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest);
    }
}


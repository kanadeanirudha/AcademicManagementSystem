
using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
    public interface IInventoryStoreBillingPrintingInfoBA
    {
        IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest);
    }
}

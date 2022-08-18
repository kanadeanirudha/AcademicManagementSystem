
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryStoreBillingPrintingInfoServiceAccess : IInventoryStoreBillingPrintingInfoServiceAccess
    {
        IInventoryStoreBillingPrintingInfoBA _InventoryStoreBillingPrintingInfoBA = null;
        public InventoryStoreBillingPrintingInfoServiceAccess()
        {
            _InventoryStoreBillingPrintingInfoBA = new InventoryStoreBillingPrintingInfoBA();
        }
        public IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest)
        {
            return _InventoryStoreBillingPrintingInfoBA.GetInventoryStoreBillingPrintingInfo(searchRequest);
        }
    }
}

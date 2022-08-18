using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryRateMarkDownMasterAndDetailsServiceAccess : IInventoryRateMarkDownMasterAndDetailsServiceAccess
    {
        IInventoryRateMarkDownMasterAndDetailsBA _InventoryRateMarkDownMasterAndDetailsBA = null;
        public InventoryRateMarkDownMasterAndDetailsServiceAccess()
        {
            _InventoryRateMarkDownMasterAndDetailsBA = new InventoryRateMarkDownMasterAndDetailsBA();
        }
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> InsertInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.InsertInventoryRateMarkDownMasterAndDetails(item);
        }
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> UpdateInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.UpdateInventoryRateMarkDownMasterAndDetails(item);
        }
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> DeleteInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.DeleteInventoryRateMarkDownMasterAndDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetBySearch(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsList(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.GetInventoryRateMarkDownMasterAndDetailsList(searchRequest);
        }
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> SelectByID(InventoryRateMarkDownMasterAndDetails item)
        {
            return _InventoryRateMarkDownMasterAndDetailsBA.SelectByID(item);
        }
    }
}

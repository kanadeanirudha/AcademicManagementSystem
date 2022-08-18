


using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryCounterLogAndLockDetailsServiceAccess : IInventoryCounterLogAndLockDetailsServiceAccess
    {
        IInventoryCounterLogAndLockDetailsBA _InventoryCounterLogAndLockDetailsBA = null;
        public InventoryCounterLogAndLockDetailsServiceAccess()
        {
            _InventoryCounterLogAndLockDetailsBA = new InventoryCounterLogAndLockDetailsBA();
        }
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> InsertInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            return _InventoryCounterLogAndLockDetailsBA.InsertInventoryCounterLogAndLockDetails(item);
        }
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> UpdateInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            return _InventoryCounterLogAndLockDetailsBA.UpdateInventoryCounterLogAndLockDetails(item);
        }
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> DeleteInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            return _InventoryCounterLogAndLockDetailsBA.DeleteInventoryCounterLogAndLockDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetBySearch(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterLogAndLockDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsList(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterLogAndLockDetailsBA.GetInventoryCounterLogAndLockDetailsList(searchRequest);
        }
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> SelectByID(InventoryCounterLogAndLockDetails item)
        {
            return _InventoryCounterLogAndLockDetailsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLockStatus(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterLogAndLockDetailsBA.GetInventoryCounterLockStatus(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            return _InventoryCounterLogAndLockDetailsBA.GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(searchRequest);
        }
    }
}

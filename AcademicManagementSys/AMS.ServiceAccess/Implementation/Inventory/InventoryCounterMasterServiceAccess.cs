using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryCounterMasterServiceAccess : IInventoryCounterMasterServiceAccess
    {
        IInventoryCounterMasterBA _InventoryCounterMasterBA = null;
        public InventoryCounterMasterServiceAccess()
        {
            _InventoryCounterMasterBA = new InventoryCounterMasterBA();
        }
        public IBaseEntityResponse<InventoryCounterMaster> InsertInventoryCounterMaster(InventoryCounterMaster item)
        {
            return _InventoryCounterMasterBA.InsertInventoryCounterMaster(item);
        }
        public IBaseEntityResponse<InventoryCounterMaster> UpdateInventoryCounterMaster(InventoryCounterMaster item)
        {
            return _InventoryCounterMasterBA.UpdateInventoryCounterMaster(item);
        }
        public IBaseEntityResponse<InventoryCounterMaster> DeleteInventoryCounterMaster(InventoryCounterMaster item)
        {
            return _InventoryCounterMasterBA.DeleteInventoryCounterMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryCounterMaster> GetBySearch(InventoryCounterMasterSearchRequest searchRequest)
        {
            return _InventoryCounterMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCounterMaster> GetInventoryCounterMasterList(InventoryCounterMasterSearchRequest searchRequest)
        {
            return _InventoryCounterMasterBA.GetInventoryCounterMasterList(searchRequest);
        }
        public IBaseEntityResponse<InventoryCounterMaster> SelectByID(InventoryCounterMaster item)
        {
            return _InventoryCounterMasterBA.SelectByID(item);
        }
    }
}

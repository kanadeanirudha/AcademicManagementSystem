using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryLocationMasterServiceAccess : IInventoryLocationMasterServiceAccess
    {
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        public InventoryLocationMasterServiceAccess()
        {
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }
        public IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item)
        {
            return _InventoryLocationMasterBA.InsertInventoryLocationMaster(item);
        }
        public IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item)
        {
            return _InventoryLocationMasterBA.UpdateInventoryLocationMaster(item);
        }
        public IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item)
        {
            return _InventoryLocationMasterBA.DeleteInventoryLocationMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetBySearch(InventoryLocationMasterSearchRequest searchRequest)
        {
            return _InventoryLocationMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest)
        {
            return _InventoryLocationMasterBA.GetInventoryLocationMasterList(searchRequest);
        }
        public IBaseEntityResponse<InventoryLocationMaster> SelectByID(InventoryLocationMaster item)
        {
            return _InventoryLocationMasterBA.SelectByID(item);
        }                
    }
}

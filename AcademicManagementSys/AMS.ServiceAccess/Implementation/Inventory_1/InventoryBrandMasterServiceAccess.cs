using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryBrandMasterServiceAccess : IInventoryBrandMasterServiceAccess
    {
        IInventoryBrandMasterBA _InventoryBrandMasterBA = null;
        public InventoryBrandMasterServiceAccess()
        {
            _InventoryBrandMasterBA = new InventoryBrandMasterBA();
        }
        public IBaseEntityResponse<InventoryBrandMaster> InsertInventoryBrandMaster(InventoryBrandMaster item)
        {
            return _InventoryBrandMasterBA.InsertInventoryBrandMaster(item);
        }
        public IBaseEntityResponse<InventoryBrandMaster> UpdateInventoryBrandMaster(InventoryBrandMaster item)
        {
            return _InventoryBrandMasterBA.UpdateInventoryBrandMaster(item);
        }
        public IBaseEntityResponse<InventoryBrandMaster> DeleteInventoryBrandMaster(InventoryBrandMaster item)
        {
            return _InventoryBrandMasterBA.DeleteInventoryBrandMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryBrandMaster> GetBySearch(InventoryBrandMasterSearchRequest searchRequest)
        {
            return _InventoryBrandMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryBrandMaster> GetInventoryBrandMasterSearchList(InventoryBrandMasterSearchRequest searchRequest)
        {
            return _InventoryBrandMasterBA.GetInventoryBrandMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryBrandMaster> SelectByID(InventoryBrandMaster item)
        {
            return _InventoryBrandMasterBA.SelectByID(item);
        }
    }
}

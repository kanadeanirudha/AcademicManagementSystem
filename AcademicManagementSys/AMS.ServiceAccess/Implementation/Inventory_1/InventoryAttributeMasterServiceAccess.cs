using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryAttributeMasterServiceAccess : IInventoryAttributeMasterServiceAccess
    {
        IInventoryAttributeMasterBA _InventoryAttributeMasterBA = null;
        public InventoryAttributeMasterServiceAccess()
        {
            _InventoryAttributeMasterBA = new InventoryAttributeMasterBA();
        }
        public IBaseEntityResponse<InventoryAttributeMaster> InsertInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            return _InventoryAttributeMasterBA.InsertInventoryAttributeMaster(item);
        }
        public IBaseEntityResponse<InventoryAttributeMaster> UpdateInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            return _InventoryAttributeMasterBA.UpdateInventoryAttributeMaster(item);
        }
        public IBaseEntityResponse<InventoryAttributeMaster> DeleteInventoryAttributeMaster(InventoryAttributeMaster item)
        {
            return _InventoryAttributeMasterBA.DeleteInventoryAttributeMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryAttributeMaster> GetBySearch(InventoryAttributeMasterSearchRequest searchRequest)
        {
            return _InventoryAttributeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryAttributeMaster> GetInventoryAttributeMasterSearchList(InventoryAttributeMasterSearchRequest searchRequest)
        {
            return _InventoryAttributeMasterBA.GetInventoryAttributeMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryAttributeMaster> SelectByID(InventoryAttributeMaster item)
        {
            return _InventoryAttributeMasterBA.SelectByID(item);
        }
    }
}

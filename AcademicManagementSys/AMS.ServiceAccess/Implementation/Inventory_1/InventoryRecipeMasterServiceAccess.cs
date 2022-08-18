using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryRecipeMasterServiceAccess : IInventoryRecipeMasterServiceAccess
    {
        IInventoryRecipeMasterBA _InventoryRecipeMasterBA = null;
        public InventoryRecipeMasterServiceAccess()
        {
            _InventoryRecipeMasterBA = new InventoryRecipeMasterBA();
        }
        public IBaseEntityResponse<InventoryRecipeMaster> InsertInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            return _InventoryRecipeMasterBA.InsertInventoryRecipeMaster(item);
        }
        public IBaseEntityResponse<InventoryRecipeMaster> UpdateInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            return _InventoryRecipeMasterBA.UpdateInventoryRecipeMaster(item);
        }
        public IBaseEntityResponse<InventoryRecipeMaster> DeleteInventoryRecipeMaster(InventoryRecipeMaster item)
        {
            return _InventoryRecipeMasterBA.DeleteInventoryRecipeMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeMaster> GetBySearch(InventoryRecipeMasterSearchRequest searchRequest)
        {
            return _InventoryRecipeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeMaster> GetInventoryRecipeMasterSearchList(InventoryRecipeMasterSearchRequest searchRequest)
        {
            return _InventoryRecipeMasterBA.GetInventoryRecipeMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryRecipeMaster> SelectByID(InventoryRecipeMaster item)
        {
            return _InventoryRecipeMasterBA.SelectByID(item);
        }
    }
}

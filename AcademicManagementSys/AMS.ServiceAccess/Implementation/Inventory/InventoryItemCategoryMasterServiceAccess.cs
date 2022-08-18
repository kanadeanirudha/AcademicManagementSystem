using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryItemCategoryMasterServiceAccess : IInventoryItemCategoryMasterServiceAccess
    {
        IInventoryItemCategoryMasterBA _InventoryItemCategoryMasterBA = null;
        public InventoryItemCategoryMasterServiceAccess()
        {
            _InventoryItemCategoryMasterBA = new InventoryItemCategoryMasterBA();
        }
        public IBaseEntityResponse<InventoryItemCategoryMaster> InsertInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            return _InventoryItemCategoryMasterBA.InsertInventoryItemCategoryMaster(item);
        }
        public IBaseEntityResponse<InventoryItemCategoryMaster> UpdateInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            return _InventoryItemCategoryMasterBA.UpdateInventoryItemCategoryMaster(item);
        }
        public IBaseEntityResponse<InventoryItemCategoryMaster> DeleteInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            return _InventoryItemCategoryMasterBA.DeleteInventoryItemCategoryMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetBySearch(InventoryItemCategoryMasterSearchRequest searchRequest)
        {
            return _InventoryItemCategoryMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterList(InventoryItemCategoryMasterSearchRequest searchRequest)
        {
            return _InventoryItemCategoryMasterBA.GetInventoryItemCategoryMasterList(searchRequest);
        }
        public IBaseEntityResponse<InventoryItemCategoryMaster> SelectByID(InventoryItemCategoryMaster item)
        {
            return _InventoryItemCategoryMasterBA.SelectByID(item);
        }
    }
}

using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryVariationMasterServiceAccess : IInventoryVariationMasterServiceAccess
    {
        IInventoryVariationMasterBA _InventoryVariationMasterBA = null;
        public InventoryVariationMasterServiceAccess()
        {
            _InventoryVariationMasterBA = new InventoryVariationMasterBA();
        }
        public IBaseEntityResponse<InventoryVariationMaster> InsertInventoryVariationMaster(InventoryVariationMaster item)
        {
            return _InventoryVariationMasterBA.InsertInventoryVariationMaster(item);
        }
        public IBaseEntityResponse<InventoryVariationMaster> UpdateInventoryVariationMaster(InventoryVariationMaster item)
        {
            return _InventoryVariationMasterBA.UpdateInventoryVariationMaster(item);
        }
        public IBaseEntityResponse<InventoryVariationMaster> DeleteInventoryVariationMaster(InventoryVariationMaster item)
        {
            return _InventoryVariationMasterBA.DeleteInventoryVariationMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryVariationMaster> GetBySearch(InventoryVariationMasterSearchRequest searchRequest)
        {
            return _InventoryVariationMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryVariationMaster> GetInventoryVariationMasterSearchList(InventoryVariationMasterSearchRequest searchRequest)
        {
            return _InventoryVariationMasterBA.GetInventoryVariationMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryVariationMaster> SelectByID(InventoryVariationMaster item)
        {
            return _InventoryVariationMasterBA.SelectByID(item);
        }
    }
}

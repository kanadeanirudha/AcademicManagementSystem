using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryDimensionUnitMasterServiceAccess : IInventoryDimensionUnitMasterServiceAccess
    {
        IInventoryDimensionUnitMasterBA _InventoryDimensionUnitMasterBA = null;
        public InventoryDimensionUnitMasterServiceAccess()
        {
            _InventoryDimensionUnitMasterBA = new InventoryDimensionUnitMasterBA();
        }
        public IBaseEntityResponse<InventoryDimensionUnitMaster> InsertInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            return _InventoryDimensionUnitMasterBA.InsertInventoryDimensionUnitMaster(item);
        }
        public IBaseEntityResponse<InventoryDimensionUnitMaster> UpdateInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            return _InventoryDimensionUnitMasterBA.UpdateInventoryDimensionUnitMaster(item);
        }
        public IBaseEntityResponse<InventoryDimensionUnitMaster> DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item)
        {
            return _InventoryDimensionUnitMasterBA.DeleteInventoryDimensionUnitMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetBySearch(InventoryDimensionUnitMasterSearchRequest searchRequest)
        {
            return _InventoryDimensionUnitMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterSearchList(InventoryDimensionUnitMasterSearchRequest searchRequest)
        {
            return _InventoryDimensionUnitMasterBA.GetInventoryDimensionUnitMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryDimensionUnitMaster> SelectByID(InventoryDimensionUnitMaster item)
        {
            return _InventoryDimensionUnitMasterBA.SelectByID(item);
        }
    }
}

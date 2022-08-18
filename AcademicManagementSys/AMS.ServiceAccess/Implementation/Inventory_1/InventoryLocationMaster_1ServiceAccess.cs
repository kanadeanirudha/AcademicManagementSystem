using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryLocationMaster_1ServiceAccess : IInventoryLocationMaster_1ServiceAccess
    {
        IInventoryLocationMaster_1BA _InventoryLocationMaster_1BA = null;
        public InventoryLocationMaster_1ServiceAccess()
        {
            _InventoryLocationMaster_1BA = new InventoryLocationMaster_1BA();
        }
        public IBaseEntityResponse<InventoryLocationMaster_1> InsertInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            return _InventoryLocationMaster_1BA.InsertInventoryLocationMaster_1(item);
        }
        public IBaseEntityResponse<InventoryLocationMaster_1> UpdateInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            return _InventoryLocationMaster_1BA.UpdateInventoryLocationMaster_1(item);
        }
        public IBaseEntityResponse<InventoryLocationMaster_1> DeleteInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            return _InventoryLocationMaster_1BA.DeleteInventoryLocationMaster_1(item);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetBySearch(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            return _InventoryLocationMaster_1BA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1List(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            return _InventoryLocationMaster_1BA.GetInventoryLocationMaster_1List(searchRequest);
        }
        public IBaseEntityResponse<InventoryLocationMaster_1> SelectByID(InventoryLocationMaster_1 item)
        {
            return _InventoryLocationMaster_1BA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterSearchList(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            return _InventoryLocationMaster_1BA.GetInventoryLocationMasterSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            return _InventoryLocationMaster_1BA.GetInventoryLocationMasterlistCenterCodeWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            return _InventoryLocationMaster_1BA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
        }
    }
}

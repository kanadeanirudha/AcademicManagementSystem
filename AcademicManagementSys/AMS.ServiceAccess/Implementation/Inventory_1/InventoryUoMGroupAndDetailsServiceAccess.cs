using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryUoMGroupAndDetailsServiceAccess : IInventoryUoMGroupAndDetailsServiceAccess
    {
        IInventoryUoMGroupAndDetailsBA _InventoryUoMGroupAndDetailsBA = null;
        public InventoryUoMGroupAndDetailsServiceAccess()
        {
            _InventoryUoMGroupAndDetailsBA = new InventoryUoMGroupAndDetailsBA();
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.InsertInventoryUoMGroupAndDetails(item);
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.UpdateInventoryUoMGroupAndDetails(item);
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.DeleteInventoryUoMGroupAndDetails(item);
        }
        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetBySearch(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            return _InventoryUoMGroupAndDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsSearchList(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            return _InventoryUoMGroupAndDetailsBA.GetInventoryUoMGroupAndDetailsSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> SelectByID(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.SelectByID(item);
        }
        //***************************************************************************************//
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.InsertInventoryUoMGroup(item);
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.UpdateInventoryUoMGroup(item);
        }
        public IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroup(InventoryUoMGroupAndDetails item)
        {
            return _InventoryUoMGroupAndDetailsBA.DeleteInventoryUoMGroup(item);
        }

        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> SelectByInventoryUoMGroupID(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            return _InventoryUoMGroupAndDetailsBA.SelectByInventoryUoMGroupID(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUomCodeByUomGroupCode(InventoryUoMGroupAndDetailsSearchRequest searchRequest)
        {
            return _InventoryUoMGroupAndDetailsBA.GetInventoryUomCodeByUomGroupCode(searchRequest);
        }
    }
}

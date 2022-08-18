using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryUoMMasterServiceAccess : IInventoryUoMMasterServiceAccess
    {
        IInventoryUoMMasterBA _InventoryUoMMasterBA = null;
        public InventoryUoMMasterServiceAccess()
        {
            _InventoryUoMMasterBA = new InventoryUoMMasterBA();
        }
        public IBaseEntityResponse<InventoryUoMMaster> InsertInventoryUoMMaster(InventoryUoMMaster item)
        {
            return _InventoryUoMMasterBA.InsertInventoryUoMMaster(item);
        }
        public IBaseEntityResponse<InventoryUoMMaster> UpdateInventoryUoMMaster(InventoryUoMMaster item)
        {
            return _InventoryUoMMasterBA.UpdateInventoryUoMMaster(item);
        }
        public IBaseEntityResponse<InventoryUoMMaster> DeleteInventoryUoMMaster(InventoryUoMMaster item)
        {
            return _InventoryUoMMasterBA.DeleteInventoryUoMMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearch(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterSearchList(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetInventoryUoMMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<InventoryUoMMaster> SelectByID(InventoryUoMMaster item)
        {
            return _InventoryUoMMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforUomCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforSaleUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforPurchaseUomCode(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforPurchaseUomCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearchList(InventoryUoMMasterSearchRequest searchRequest)
        {
            return _InventoryUoMMasterBA.GetBySearchList(searchRequest);
        }
    }
}

using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryCustomerMasterServiceAccess : IInventoryCustomerMasterServiceAccess
    {
        IInventoryCustomerMasterBA _InventoryCustomerMasterBA = null;
        public InventoryCustomerMasterServiceAccess()
        {
            _InventoryCustomerMasterBA = new InventoryCustomerMasterBA();
        }
        public IBaseEntityResponse<InventoryCustomerMaster> InsertInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            return _InventoryCustomerMasterBA.InsertInventoryCustomerMaster(item);
        }
        public IBaseEntityResponse<InventoryCustomerMaster> UpdateInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            return _InventoryCustomerMasterBA.UpdateInventoryCustomerMaster(item);
        }
        public IBaseEntityResponse<InventoryCustomerMaster> DeleteInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            return _InventoryCustomerMasterBA.DeleteInventoryCustomerMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryCustomerMaster> GetBySearch(InventoryCustomerMasterSearchRequest searchRequest)
        {
            return _InventoryCustomerMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterSelectList(InventoryCustomerMasterSearchRequest searchRequest)
        {
            return _InventoryCustomerMasterBA.GetInventoryCustomerMasterSelectList(searchRequest);
        }

       

        public IBaseEntityResponse<InventoryCustomerMaster> SelectByID(InventoryCustomerMaster item)
        {
            return _InventoryCustomerMasterBA.SelectByID(item);
        }
    }
}


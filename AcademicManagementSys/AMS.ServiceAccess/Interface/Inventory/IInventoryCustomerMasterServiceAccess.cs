using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryCustomerMasterServiceAccess
    {
        IBaseEntityResponse<InventoryCustomerMaster> InsertInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> UpdateInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> DeleteInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetBySearch(InventoryCustomerMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCustomerMaster> SelectByID(InventoryCustomerMaster item);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterSelectList(InventoryCustomerMasterSearchRequest searchRequest);
    }
}

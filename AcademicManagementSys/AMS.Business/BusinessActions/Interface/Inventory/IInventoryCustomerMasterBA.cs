using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryCustomerMasterBA
    {
        IBaseEntityResponse<InventoryCustomerMaster> InsertInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> UpdateInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> DeleteInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetBySearch(InventoryCustomerMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterSelectList(InventoryCustomerMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCustomerMaster> SelectByID(InventoryCustomerMaster item);
    }
}

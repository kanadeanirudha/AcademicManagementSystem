using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryCustomerMasterDataProvider
    {
        IBaseEntityResponse<InventoryCustomerMaster> InsertInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> UpdateInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityResponse<InventoryCustomerMaster> DeleteInventoryCustomerMaster(InventoryCustomerMaster item);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterBySearch(InventoryCustomerMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterSelectList(InventoryCustomerMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCustomerMaster> GetInventoryCustomerMasterByID(InventoryCustomerMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryCounterMasterDataProvider
    {
        IBaseEntityResponse<InventoryCounterMaster> InsertInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityResponse<InventoryCounterMaster> UpdateInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityResponse<InventoryCounterMaster> DeleteInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityCollectionResponse<InventoryCounterMaster> GetInventoryCounterMasterBySearch(InventoryCounterMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCounterMaster> GetInventoryCounterMasterList(InventoryCounterMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterMaster> GetInventoryCounterMasterByID(InventoryCounterMaster item);
    }
}

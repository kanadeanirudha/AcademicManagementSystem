using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryCounterMasterServiceAccess
    {
        IBaseEntityResponse<InventoryCounterMaster> InsertInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityResponse<InventoryCounterMaster> UpdateInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityResponse<InventoryCounterMaster> DeleteInventoryCounterMaster(InventoryCounterMaster item);
        IBaseEntityCollectionResponse<InventoryCounterMaster> GetBySearch(InventoryCounterMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryCounterMaster> SelectByID(InventoryCounterMaster item);
        IBaseEntityCollectionResponse<InventoryCounterMaster> GetInventoryCounterMasterList(InventoryCounterMasterSearchRequest searchRequest);
    }
}

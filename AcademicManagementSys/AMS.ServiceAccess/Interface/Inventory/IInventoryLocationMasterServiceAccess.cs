using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryLocationMasterServiceAccess
    {
        IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetBySearch(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster> SelectByID(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);                
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryAttributeMasterServiceAccess
    {
        IBaseEntityResponse<InventoryAttributeMaster> InsertInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityResponse<InventoryAttributeMaster> UpdateInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityResponse<InventoryAttributeMaster> DeleteInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityCollectionResponse<InventoryAttributeMaster> GetBySearch(InventoryAttributeMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryAttributeMaster> SelectByID(InventoryAttributeMaster item);
        IBaseEntityCollectionResponse<InventoryAttributeMaster> GetInventoryAttributeMasterSearchList(InventoryAttributeMasterSearchRequest searchRequest);
    }
}

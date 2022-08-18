using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryRecipeMasterServiceAccess
    {
        IBaseEntityResponse<InventoryRecipeMaster> InsertInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityResponse<InventoryRecipeMaster> UpdateInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityResponse<InventoryRecipeMaster> DeleteInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityCollectionResponse<InventoryRecipeMaster> GetBySearch(InventoryRecipeMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeMaster> SelectByID(InventoryRecipeMaster item);
        IBaseEntityCollectionResponse<InventoryRecipeMaster> GetInventoryRecipeMasterSearchList(InventoryRecipeMasterSearchRequest searchRequest);
    }
}

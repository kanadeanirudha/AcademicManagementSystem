using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryBrandMasterServiceAccess
    {
        IBaseEntityResponse<InventoryBrandMaster> InsertInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityResponse<InventoryBrandMaster> UpdateInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityResponse<InventoryBrandMaster> DeleteInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityCollectionResponse<InventoryBrandMaster> GetBySearch(InventoryBrandMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryBrandMaster> SelectByID(InventoryBrandMaster item);
        IBaseEntityCollectionResponse<InventoryBrandMaster> GetInventoryBrandMasterSearchList(InventoryBrandMasterSearchRequest searchRequest);
    }
}

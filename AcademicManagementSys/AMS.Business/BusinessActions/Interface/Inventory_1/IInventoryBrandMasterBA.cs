using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryBrandMasterBA
    {
        IBaseEntityResponse<InventoryBrandMaster> InsertInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityResponse<InventoryBrandMaster> UpdateInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityResponse<InventoryBrandMaster> DeleteInventoryBrandMaster(InventoryBrandMaster item);
        IBaseEntityCollectionResponse<InventoryBrandMaster> GetBySearch(InventoryBrandMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryBrandMaster> GetInventoryBrandMasterSearchList(InventoryBrandMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryBrandMaster> SelectByID(InventoryBrandMaster item);
    }
}


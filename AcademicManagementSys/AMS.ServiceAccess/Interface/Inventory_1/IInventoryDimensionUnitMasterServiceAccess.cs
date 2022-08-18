using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IInventoryDimensionUnitMasterServiceAccess
    {
        IBaseEntityResponse<InventoryDimensionUnitMaster> InsertInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> UpdateInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetBySearch(InventoryDimensionUnitMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDimensionUnitMaster> SelectByID(InventoryDimensionUnitMaster item);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterSearchList(InventoryDimensionUnitMasterSearchRequest searchRequest);
    }
}

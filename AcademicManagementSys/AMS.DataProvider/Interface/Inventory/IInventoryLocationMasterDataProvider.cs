using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryLocationMasterDataProvider
    {
        IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterBySearch(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster> GetInventoryLocationMasterByID(InventoryLocationMaster item);
       
    }
}

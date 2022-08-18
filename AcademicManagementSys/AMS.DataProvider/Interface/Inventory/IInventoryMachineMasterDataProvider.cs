using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryMachineMasterDataProvider
    {
        IBaseEntityResponse<InventoryMachineMaster> InsertInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityResponse<InventoryMachineMaster> UpdateInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityResponse<InventoryMachineMaster> DeleteInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineMasterBySearch(InventoryMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineMasterList(InventoryMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineCounterApplicableList(InventoryMachineMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryMachineMaster> GetInventoryMachineMasterByID(InventoryMachineMaster item);
    } 
}



using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryMachineMasterBA
    {
        IBaseEntityResponse<InventoryMachineMaster> InsertInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityResponse<InventoryMachineMaster> UpdateInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityResponse<InventoryMachineMaster> DeleteInventoryMachineMaster(InventoryMachineMaster item);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetBySearch(InventoryMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineMasterList(InventoryMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineCounterApplicableList(InventoryMachineMasterSearchRequest searchRequest); 
        IBaseEntityResponse<InventoryMachineMaster> SelectByID(InventoryMachineMaster item);
    }
}

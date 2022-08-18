using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class InventoryMachineMasterServiceAccess : IInventoryMachineMasterServiceAccess
    {
        IInventoryMachineMasterBA _InventoryMachineMasterBA = null;
        public InventoryMachineMasterServiceAccess()
        {
            _InventoryMachineMasterBA = new InventoryMachineMasterBA();
        }
        public IBaseEntityResponse<InventoryMachineMaster> InsertInventoryMachineMaster(InventoryMachineMaster item)
        {
            return _InventoryMachineMasterBA.InsertInventoryMachineMaster(item);
        }
        public IBaseEntityResponse<InventoryMachineMaster> UpdateInventoryMachineMaster(InventoryMachineMaster item)
        {
            return _InventoryMachineMasterBA.UpdateInventoryMachineMaster(item);
        }
        public IBaseEntityResponse<InventoryMachineMaster> DeleteInventoryMachineMaster(InventoryMachineMaster item)
        {
            return _InventoryMachineMasterBA.DeleteInventoryMachineMaster(item);
        }
        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetBySearch(InventoryMachineMasterSearchRequest searchRequest)
        {
            return _InventoryMachineMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineMasterList(InventoryMachineMasterSearchRequest searchRequest)
        {
            return _InventoryMachineMasterBA.GetInventoryMachineMasterList(searchRequest);
        }

        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineCounterApplicableList(InventoryMachineMasterSearchRequest searchRequest)
        {
            return _InventoryMachineMasterBA.GetInventoryMachineCounterApplicableList(searchRequest);
        }

        public IBaseEntityResponse<InventoryMachineMaster> SelectByID(InventoryMachineMaster item)
        {
            return _InventoryMachineMasterBA.SelectByID(item);
        }
    }
}

  
using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class PhysicalInventoryServiceAccess : IPhysicalInventoryServiceAccess
    {
        IPhysicalInventoryBA _PhysicalInventoryBA = null;

        public PhysicalInventoryServiceAccess()
        {
            _PhysicalInventoryBA = new PhysicalInventoryBA();
        }

        public IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item)
        {
            return _PhysicalInventoryBA.PostPhysicalInventory(item);
        }
        public IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest)
        {
            return _PhysicalInventoryBA.GetPhysicalInventory(searchRequest);
        }
    }
}

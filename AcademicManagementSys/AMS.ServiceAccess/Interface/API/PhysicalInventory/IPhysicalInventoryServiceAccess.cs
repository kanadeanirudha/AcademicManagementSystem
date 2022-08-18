using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface IPhysicalInventoryServiceAccess
    {
        IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item);
        IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest);
    }
}

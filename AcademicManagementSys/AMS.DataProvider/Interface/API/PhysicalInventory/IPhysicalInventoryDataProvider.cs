using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IPhysicalInventoryDataProvider
    {
        IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item);
        IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest);
    }
}

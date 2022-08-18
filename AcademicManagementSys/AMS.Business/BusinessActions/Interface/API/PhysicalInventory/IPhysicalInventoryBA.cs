using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IPhysicalInventoryBA
    {
        IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item);
        IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest);
    }
}

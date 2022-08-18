using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class InventoryRecipeMenuCategoryServiceAccess : IInventoryRecipeMenuCategoryServiceAccess
    {
        IInventoryRecipeMenuCategoryBA _inventoryRecipeMenuCategoryBA = null;
        public InventoryRecipeMenuCategoryServiceAccess()
        {
            _inventoryRecipeMenuCategoryBA = new InventoryRecipeMenuCategoryBA();
        }
        public IBaseEntityResponse<InventoryRecipeMenuCategory> InsertInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            return _inventoryRecipeMenuCategoryBA.InsertInventoryRecipeMenuCategory(item);
        }
        public IBaseEntityResponse<InventoryRecipeMenuCategory> UpdateInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            return _inventoryRecipeMenuCategoryBA.UpdateInventoryRecipeMenuCategory(item);
        }
        public IBaseEntityResponse<InventoryRecipeMenuCategory> DeleteInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            return _inventoryRecipeMenuCategoryBA.DeleteInventoryRecipeMenuCategory(item);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetBySearch(InventoryRecipeMenuCategorySearchRequest searchRequest)
        {
            return _inventoryRecipeMenuCategoryBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<InventoryRecipeMenuCategory> SelectByID(InventoryRecipeMenuCategory item)
        {
            return _inventoryRecipeMenuCategoryBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetRestaurantCategory(InventoryRecipeMenuCategorySearchRequest searchRequest)
        {
            return _inventoryRecipeMenuCategoryBA.GetRestaurantCategory(searchRequest);
        }
    }
}

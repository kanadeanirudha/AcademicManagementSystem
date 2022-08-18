using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IRestaurantCategoryAndMenuBA
    {

        IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantCategory(RestaurantCategoryAndMenuSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantMenu(RestaurantCategoryAndMenuSearchRequest searchRequest);
        IBaseEntityResponse<RestaurantCategoryAndMenu> GetRestaurantMenuSpecification(RestaurantCategoryAndMenu item);
        IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuCategory(RestaurantCategoryAndMenuSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuMaster(RestaurantCategoryAndMenuSearchRequest searchRequest);
    }
}

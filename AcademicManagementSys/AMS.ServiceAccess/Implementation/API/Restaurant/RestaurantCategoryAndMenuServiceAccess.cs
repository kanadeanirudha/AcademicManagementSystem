using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RestaurantCategoryAndMenuServiceAccess : IRestaurantCategoryAndMenuServiceAccess
    {
        IRestaurantCategoryAndMenuBA _RestaurantCategoryAndMenuBA = null;

        public RestaurantCategoryAndMenuServiceAccess()
        {
            _RestaurantCategoryAndMenuBA = new RestaurantCategoryAndMenuBA();
        }

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            return _RestaurantCategoryAndMenuBA.GetRestaurantCategory(searchRequest);
        }
        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantMenu(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            return _RestaurantCategoryAndMenuBA.GetRestaurantMenu(searchRequest);
        }
        public IBaseEntityResponse<RestaurantCategoryAndMenu> GetRestaurantMenuSpecification(RestaurantCategoryAndMenu item)
        {
            return _RestaurantCategoryAndMenuBA.GetRestaurantMenuSpecification(item);
        }
        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            return _RestaurantCategoryAndMenuBA.GetInventoryRecipeMenuCategory(searchRequest);
        }
        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuMaster(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            return _RestaurantCategoryAndMenuBA.GetInventoryRecipeMenuMaster(searchRequest);
        }
    }
   
}


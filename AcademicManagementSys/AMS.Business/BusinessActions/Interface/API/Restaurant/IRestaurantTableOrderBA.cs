using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IRestaurantTableOrderBA
    {
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item);
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item); 
        IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest);
    }
}

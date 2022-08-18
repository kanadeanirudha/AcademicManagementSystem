using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IRestaurantTableOrderDataProvider
    {
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item);
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item); 
        IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest);
    }
}

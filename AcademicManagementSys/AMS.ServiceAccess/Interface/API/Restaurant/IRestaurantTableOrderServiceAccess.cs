using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface IRestaurantTableOrderServiceAccess
    {
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item);
        IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item); 
        IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest);
    }
}

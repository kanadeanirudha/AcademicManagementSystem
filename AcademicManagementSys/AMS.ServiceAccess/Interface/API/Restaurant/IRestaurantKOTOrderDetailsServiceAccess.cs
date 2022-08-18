using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface IRestaurantKOTOrderDetailsServiceAccess
    {
        IBaseEntityResponse<RestaurantKOTOrderDetails> PostRestaurantKOTOrder(RestaurantKOTOrderDetails item);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetRestaurantKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetInCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
    }
}

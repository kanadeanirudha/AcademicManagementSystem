using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface IRestaurantKOTOrderDetailsBA
    {
        IBaseEntityResponse<RestaurantKOTOrderDetails> PostRestaurantKOTOrder(RestaurantKOTOrderDetails item);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetRestaurantKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetInCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest);
    }
}

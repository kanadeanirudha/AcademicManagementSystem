using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RestaurantKOTOrderDetailsServiceAccess : IRestaurantKOTOrderDetailsServiceAccess
    {
        IRestaurantKOTOrderDetailsBA _RestaurantKOTOrderDetailsBA = null;

        public RestaurantKOTOrderDetailsServiceAccess()
        {
            _RestaurantKOTOrderDetailsBA = new RestaurantKOTOrderDetailsBA();
        }

        public IBaseEntityResponse<RestaurantKOTOrderDetails> PostRestaurantKOTOrder(RestaurantKOTOrderDetails item)
        {
            return _RestaurantKOTOrderDetailsBA.PostRestaurantKOTOrder(item);
        }
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetRestaurantKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            return _RestaurantKOTOrderDetailsBA.GetRestaurantKOTOrder(searchRequest);
        }
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            return _RestaurantKOTOrderDetailsBA.GetCompleteKOTOrder(searchRequest);
        }
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetInCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            return _RestaurantKOTOrderDetailsBA.GetInCompleteKOTOrder(searchRequest);
        }

    }
}

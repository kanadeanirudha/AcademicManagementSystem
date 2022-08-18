using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RestaurantTableOrderServiceAccess : IRestaurantTableOrderServiceAccess
    {
        IRestaurantTableOrderBA _RestaurantTableOrderBA = null;

        public RestaurantTableOrderServiceAccess()
        {
            _RestaurantTableOrderBA = new RestaurantTableOrderBA();
        }

        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item)
        {
            return _RestaurantTableOrderBA.PostTableOrder(item);
        }
        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item)
        {
            return _RestaurantTableOrderBA.PostTableOrderStatus(item);
        }

        public IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest)
        {
            return _RestaurantTableOrderBA.GetTableOrder(searchRequest);
        }
    }
}

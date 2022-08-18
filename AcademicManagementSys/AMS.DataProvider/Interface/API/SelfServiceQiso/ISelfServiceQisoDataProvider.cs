using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface ISelfServiceQisoDataProvider
    {
        IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item);
        IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public interface ISelfServiceQisoServiceAccess
    {
        IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item);
        IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item);
    }
}

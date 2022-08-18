using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.Business.BusinessAction
{
    public interface ISelfServiceQisoBA
    {
        IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item);
        IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item);
    }
}

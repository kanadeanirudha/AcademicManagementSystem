using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class SelfServiceQisoServiceAccess : ISelfServiceQisoServiceAccess
    {
        ISelfServiceQisoBA _SelfServiceQisoBA = null;

        public SelfServiceQisoServiceAccess()
        {
            _SelfServiceQisoBA = new SelfServiceQisoBA();
        }

        public IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item)
        {
            return _SelfServiceQisoBA.PostTableOrder(item);
        }
        public IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item)
        {
            return _SelfServiceQisoBA.RestaurantSettleBillPost(item);
        }
    }
}

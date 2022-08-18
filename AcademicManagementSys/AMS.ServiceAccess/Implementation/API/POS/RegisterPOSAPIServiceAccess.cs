using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class RegisterPOSAPIServiceAccess : IRegisterPOSAPIServiceAccess
    {
        IRegisterPOSAPIBA _RegisterPOSAPIBA = null;

        public RegisterPOSAPIServiceAccess()
        {
            _RegisterPOSAPIBA = new RegisterPOSAPIBA();
        }

       
        public IBaseEntityResponse<RegisterPOSAPI> RegisterPOS(RegisterPOSAPI item)
        {
            return _RegisterPOSAPIBA.RegisterPOS(item);
        }
    }
}

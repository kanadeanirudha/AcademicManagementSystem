using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class CheckTabRegistrationServiceAccess : ICheckTabRegistrationServiceAccess
    {
        ICheckTabRegistrationBA _CheckTabRegistrationBA = null;

        public CheckTabRegistrationServiceAccess()
        {
            _CheckTabRegistrationBA = new CheckTabRegistrationBA();
        }

        public IBaseEntityResponse<CheckTabRegistration> CheckTabRegistrationSelfService(CheckTabRegistration item)
        {
            return _CheckTabRegistrationBA.CheckTabRegistrationSelfService(item);
        }

    }
}

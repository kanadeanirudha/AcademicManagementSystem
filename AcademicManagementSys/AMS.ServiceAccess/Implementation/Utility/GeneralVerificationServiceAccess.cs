using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralVerificationServiceAccess : IGeneralVerificationServiceAccess
    {
        IGeneralVerificationBA _GeneralVerificationBA = null;

        public GeneralVerificationServiceAccess()
        {
            _GeneralVerificationBA = new GeneralVerificationBA();
        }


        public IBaseEntityResponse<GeneralVerification> EmailVerification(GeneralVerification item)
        {
            return _GeneralVerificationBA.EmailVerification(item);
        }

    }
}

using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public class GeneralVerificationBA : IGeneralVerificationBA
    {
        IGeneralVerificationDataProvider _GeneralVerificationDataProvider;
        private ILogger _logException;

        public GeneralVerificationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralVerificationDataProvider = new GeneralVerificationDataProvider();
        }


        public IBaseEntityResponse<GeneralVerification> EmailVerification(GeneralVerification item)
        {

            IBaseEntityResponse<GeneralVerification> entityResponse = new BaseEntityResponse<GeneralVerification>();
            try
            {
                entityResponse = _GeneralVerificationDataProvider.EmailVerification(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}

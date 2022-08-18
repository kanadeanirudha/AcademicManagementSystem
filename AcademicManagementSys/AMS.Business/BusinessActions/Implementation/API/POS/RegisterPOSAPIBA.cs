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
    public class RegisterPOSAPIBA : IRegisterPOSAPIBA
    {
        IRegisterPOSAPIDataProvider _RegisterPOSAPIDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public RegisterPOSAPIBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _RegisterPOSAPIDataProvider = new RegisterPOSAPIDataProvider();
        }


        public IBaseEntityResponse<RegisterPOSAPI> RegisterPOS(RegisterPOSAPI item)
        {
            IBaseEntityResponse<RegisterPOSAPI> entityResponse = new BaseEntityResponse<RegisterPOSAPI>();
            try
            {

                if (_RegisterPOSAPIDataProvider != null)
                {
                    entityResponse = _RegisterPOSAPIDataProvider.RegisterPOS(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

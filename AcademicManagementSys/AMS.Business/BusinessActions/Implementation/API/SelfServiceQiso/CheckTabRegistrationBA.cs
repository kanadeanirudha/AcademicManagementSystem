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
    public class CheckTabRegistrationBA : ICheckTabRegistrationBA
    {
        ICheckTabRegistrationDataProvider _CheckTabRegistrationDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public CheckTabRegistrationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _CheckTabRegistrationDataProvider = new CheckTabRegistrationDataProvider();
        }


        public IBaseEntityResponse<CheckTabRegistration> CheckTabRegistrationSelfService(CheckTabRegistration item)
        {
            IBaseEntityResponse<CheckTabRegistration> entityResponse = new BaseEntityResponse<CheckTabRegistration>();
            try
            {

                if (_CheckTabRegistrationDataProvider != null)
                {
                    entityResponse = _CheckTabRegistrationDataProvider.CheckTabRegistrationSelfService(item);
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

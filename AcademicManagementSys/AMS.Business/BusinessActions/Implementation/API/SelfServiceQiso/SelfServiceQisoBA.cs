using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class SelfServiceQisoBA : ISelfServiceQisoBA
    {
        ISelfServiceQisoDataProvider _SelfServiceQisoDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public SelfServiceQisoBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _SelfServiceQisoDataProvider = new SelfServiceQisoDataProvider();
        }

        public IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item)
        {
            IBaseEntityResponse<SelfServiceQiso> entityResponse = new BaseEntityResponse<SelfServiceQiso>();
            try
            {

                if (_SelfServiceQisoDataProvider != null)
                {
                    entityResponse = _SelfServiceQisoDataProvider.PostTableOrder(item);
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
        public IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item)
        {
            IBaseEntityResponse<SelfServiceQiso> entityResponse = new BaseEntityResponse<SelfServiceQiso>();
            try
            {

                if (_SelfServiceQisoDataProvider != null)
                {
                    entityResponse = _SelfServiceQisoDataProvider.RestaurantSettleBillPost(item);
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

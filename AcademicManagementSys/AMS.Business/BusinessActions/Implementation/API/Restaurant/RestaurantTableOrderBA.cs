using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class RestaurantTableOrderBA : IRestaurantTableOrderBA
    {
        IRestaurantTableOrderDataProvider _RestaurantTableOrderDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public RestaurantTableOrderBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _RestaurantTableOrderDataProvider = new RestaurantTableOrderDataProvider();
        }
        
        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item)
        {
            IBaseEntityResponse<RestaurantTableOrder> entityResponse = new BaseEntityResponse<RestaurantTableOrder>();
            try
            {

                if (_RestaurantTableOrderDataProvider != null)
                {
                    entityResponse = _RestaurantTableOrderDataProvider.PostTableOrder(item);
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
        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item)
        {
            IBaseEntityResponse<RestaurantTableOrder> entityResponse = new BaseEntityResponse<RestaurantTableOrder>();
            try
            {

                if (_RestaurantTableOrderDataProvider != null)
                {
                    entityResponse = _RestaurantTableOrderDataProvider.PostTableOrderStatus(item);
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
        
        public IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableOrder> entityResponse = new BaseEntityCollectionResponse<RestaurantTableOrder>();
            try
            {

                if (_RestaurantTableOrderDataProvider != null)
                {
                    entityResponse = _RestaurantTableOrderDataProvider.GetTableOrder(searchRequest);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}

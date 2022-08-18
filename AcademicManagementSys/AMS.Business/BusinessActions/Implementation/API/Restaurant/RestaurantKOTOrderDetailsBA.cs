using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class RestaurantKOTOrderDetailsBA : IRestaurantKOTOrderDetailsBA
    {
        IRestaurantKOTOrderDetailsDataProvider _RestaurantKOTOrderDetailsDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public RestaurantKOTOrderDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _RestaurantKOTOrderDetailsDataProvider = new RestaurantKOTOrderDetailsDataProvider();
        }

        public IBaseEntityResponse<RestaurantKOTOrderDetails> PostRestaurantKOTOrder(RestaurantKOTOrderDetails item)
        {
            IBaseEntityResponse<RestaurantKOTOrderDetails> entityResponse = new BaseEntityResponse<RestaurantKOTOrderDetails>();
            try
            {

                if (_RestaurantKOTOrderDetailsDataProvider != null)
                {
                    entityResponse = _RestaurantKOTOrderDetailsDataProvider.PostRestaurantKOTOrder(item);
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

        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetRestaurantKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> entityResponse = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
            try
            {

                if (_RestaurantKOTOrderDetailsDataProvider != null)
                {
                    entityResponse = _RestaurantKOTOrderDetailsDataProvider.GetRestaurantKOTOrder(searchRequest);
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
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> entityResponse = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
            try
            {

                if (_RestaurantKOTOrderDetailsDataProvider != null)
                {
                    entityResponse = _RestaurantKOTOrderDetailsDataProvider.GetCompleteKOTOrder(searchRequest);
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
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetInCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> entityResponse = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
            try
            {

                if (_RestaurantKOTOrderDetailsDataProvider != null)
                {
                    entityResponse = _RestaurantKOTOrderDetailsDataProvider.GetInCompleteKOTOrder(searchRequest);
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

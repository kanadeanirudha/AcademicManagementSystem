using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class RestaurantCategoryAndMenuBA : IRestaurantCategoryAndMenuBA
    {
        IRestaurantCategoryAndMenuDataProvider _RestaurantCategoryAndMenuDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public RestaurantCategoryAndMenuBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _RestaurantCategoryAndMenuDataProvider = new RestaurantCategoryAndMenuDataProvider();
        }

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> entityResponse = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
            try
            {

                if (_RestaurantCategoryAndMenuDataProvider != null)
                {
                    entityResponse = _RestaurantCategoryAndMenuDataProvider.GetRestaurantCategory(searchRequest);
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
        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantMenu(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> entityResponse = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
            try
            {

                if (_RestaurantCategoryAndMenuDataProvider != null)
                {
                    entityResponse = _RestaurantCategoryAndMenuDataProvider.GetRestaurantMenu(searchRequest);
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

        public IBaseEntityResponse<RestaurantCategoryAndMenu> GetRestaurantMenuSpecification(RestaurantCategoryAndMenu item)
        {
            IBaseEntityResponse<RestaurantCategoryAndMenu> entityResponse = new BaseEntityResponse<RestaurantCategoryAndMenu>();
            try
            {

                if (_RestaurantCategoryAndMenuDataProvider != null)
                {
                    entityResponse = _RestaurantCategoryAndMenuDataProvider.GetRestaurantMenuSpecification(item);
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

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> entityResponse = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
            try
            {

                if (_RestaurantCategoryAndMenuDataProvider != null)
                {
                    entityResponse = _RestaurantCategoryAndMenuDataProvider.GetInventoryRecipeMenuCategory(searchRequest);
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

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuMaster(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> entityResponse = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
            try
            {

                if (_RestaurantCategoryAndMenuDataProvider != null)
                {
                    entityResponse = _RestaurantCategoryAndMenuDataProvider.GetInventoryRecipeMenuMaster(searchRequest);
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


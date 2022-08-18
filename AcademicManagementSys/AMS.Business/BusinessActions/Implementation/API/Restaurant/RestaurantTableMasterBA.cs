
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
    public class RestaurantTableMasterBA : IRestaurantTableMasterBA
    {
        IRestaurantTableMasterDataProvider _RestaurantTableMasterDataProvider;
        IRestaurantTableMasterBR _RestaurantTableMasterBR;
        private ILogger _logException;

        public RestaurantTableMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RestaurantTableMasterDataProvider = new RestaurantTableMasterDataProvider();
            _RestaurantTableMasterBR = new RestaurantTableMasterBR();
        }

        public IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> entityResponse = new BaseEntityCollectionResponse<RestaurantTableMaster>();
            try
            {

                if (_RestaurantTableMasterDataProvider != null)
                {
                    entityResponse = _RestaurantTableMasterDataProvider.RestaurantTableGetOnline(searchRequest);
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

        //Methods for Restaurant Table master form

        public IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> entityResponse = new BaseEntityResponse<RestaurantTableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RestaurantTableMasterBR.InsertRestaurantTableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RestaurantTableMasterDataProvider.InsertRestaurantTableMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Update a specific record  of RestaurantTableMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> entityResponse = new BaseEntityResponse<RestaurantTableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RestaurantTableMasterBR.UpdateRestaurantTableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RestaurantTableMasterDataProvider.UpdateRestaurantTableMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Delete a selected record from RestaurantTableMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> entityResponse = new BaseEntityResponse<RestaurantTableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RestaurantTableMasterBR.DeleteRestaurantTableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RestaurantTableMasterDataProvider.DeleteRestaurantTableMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Select all record from RestaurantTableMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetBySearch(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableMasterCollection = new BaseEntityCollectionResponse<RestaurantTableMaster>();
            try
            {
                if (_RestaurantTableMasterDataProvider != null)
                    RestaurantTableMasterCollection = _RestaurantTableMasterDataProvider.GetRestaurantTableMasterBySearch(searchRequest);
                else
                {
                    RestaurantTableMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RestaurantTableMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RestaurantTableMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RestaurantTableMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RestaurantTableMasterCollection;
        }
        /// <summary>
        /// Select a record from RestaurantTableMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RestaurantTableMaster> SelectByID(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> entityResponse = new BaseEntityResponse<RestaurantTableMaster>();
            try
            {
                entityResponse = _RestaurantTableMasterDataProvider.GetRestaurantTableMasterByID(item);
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

        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableMasterCollection = new BaseEntityCollectionResponse<RestaurantTableMaster>();
            try
            {
                if (_RestaurantTableMasterDataProvider != null)
                    RestaurantTableMasterCollection = _RestaurantTableMasterDataProvider.GetRestaurantCategory(searchRequest);
                else
                {
                    RestaurantTableMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RestaurantTableMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RestaurantTableMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RestaurantTableMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RestaurantTableMasterCollection;
        }
    }
}

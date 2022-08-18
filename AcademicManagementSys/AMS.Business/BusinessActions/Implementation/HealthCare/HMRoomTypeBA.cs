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

namespace AMS.Business.BusinessActions
{
    public class HMRoomTypeBA : IHMRoomTypeBA
    {
        IHMRoomTypeDataProvider _HMRoomTypeDataProvider;
        IHMRoomTypeBR _HMRoomTypeBR;
        private ILogger _logException;
        public HMRoomTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMRoomTypeBR = new HMRoomTypeBR();
            _HMRoomTypeDataProvider = new HMRoomTypeDataProvider();
        }
        /// <summary>
        /// Create new record of HMRoomType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMRoomType> InsertHMRoomType(HMRoomType item)
        {
            IBaseEntityResponse<HMRoomType> entityResponse = new BaseEntityResponse<HMRoomType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMRoomTypeBR.InsertHMRoomTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMRoomTypeDataProvider.InsertHMRoomType(item);
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
        /// Update a specific record  of HMRoomType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMRoomType> UpdateHMRoomType(HMRoomType item)
        {
            IBaseEntityResponse<HMRoomType> entityResponse = new BaseEntityResponse<HMRoomType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMRoomTypeBR.UpdateHMRoomTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMRoomTypeDataProvider.UpdateHMRoomType(item);
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
        /// Delete a selected record from HMRoomType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMRoomType> DeleteHMRoomType(HMRoomType item)
        {
            IBaseEntityResponse<HMRoomType> entityResponse = new BaseEntityResponse<HMRoomType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMRoomTypeBR.DeleteHMRoomTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMRoomTypeDataProvider.DeleteHMRoomType(item);
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
        /// Select all record from HMRoomType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMRoomType> GetBySearch(HMRoomTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMRoomType> HMRoomTypeCollection = new BaseEntityCollectionResponse<HMRoomType>();
            try
            {
                if (_HMRoomTypeDataProvider != null)
                    HMRoomTypeCollection = _HMRoomTypeDataProvider.GetHMRoomTypeBySearch(searchRequest);
                else
                {
                    HMRoomTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMRoomTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMRoomTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMRoomTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMRoomTypeCollection;
        }

        public IBaseEntityCollectionResponse<HMRoomType> GetHMRoomTypeSearchList(HMRoomTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMRoomType> HMRoomTypeCollection = new BaseEntityCollectionResponse<HMRoomType>();
            try
            {
                if (_HMRoomTypeDataProvider != null)
                    HMRoomTypeCollection = _HMRoomTypeDataProvider.GetHMRoomTypeSearchList(searchRequest);
                else
                {
                    HMRoomTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMRoomTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMRoomTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMRoomTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMRoomTypeCollection;
        }
        /// <summary>
        /// Select a record from HMRoomType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMRoomType> SelectByID(HMRoomType item)
        {
            IBaseEntityResponse<HMRoomType> entityResponse = new BaseEntityResponse<HMRoomType>();
            try
            {
                entityResponse = _HMRoomTypeDataProvider.GetHMRoomTypeByID(item);
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

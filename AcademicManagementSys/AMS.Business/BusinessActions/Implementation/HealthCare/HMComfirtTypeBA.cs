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
    public class HMComfirtTypeBA : IHMComfirtTypeBA
    {
        IHMComfirtTypeDataProvider _HMComfirtTypeDataProvider;
        IHMComfirtTypeBR _HMComfirtTypeBR;
        private ILogger _logException;
        public HMComfirtTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMComfirtTypeBR = new HMComfirtTypeBR();
            _HMComfirtTypeDataProvider = new HMComfirtTypeDataProvider();
        }
        /// <summary>
        /// Create new record of HMComfirtType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMComfirtType> InsertHMComfirtType(HMComfirtType item)
        {
            IBaseEntityResponse<HMComfirtType> entityResponse = new BaseEntityResponse<HMComfirtType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMComfirtTypeBR.InsertHMComfirtTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMComfirtTypeDataProvider.InsertHMComfirtType(item);
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
        /// Update a specific record  of HMComfirtType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMComfirtType> UpdateHMComfirtType(HMComfirtType item)
        {
            IBaseEntityResponse<HMComfirtType> entityResponse = new BaseEntityResponse<HMComfirtType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMComfirtTypeBR.UpdateHMComfirtTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMComfirtTypeDataProvider.UpdateHMComfirtType(item);
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
        /// Delete a selected record from HMComfirtType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMComfirtType> DeleteHMComfirtType(HMComfirtType item)
        {
            IBaseEntityResponse<HMComfirtType> entityResponse = new BaseEntityResponse<HMComfirtType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMComfirtTypeBR.DeleteHMComfirtTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMComfirtTypeDataProvider.DeleteHMComfirtType(item);
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
        /// Select all record from HMComfirtType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMComfirtType> GetBySearch(HMComfirtTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMComfirtType> HMComfirtTypeCollection = new BaseEntityCollectionResponse<HMComfirtType>();
            try
            {
                if (_HMComfirtTypeDataProvider != null)
                    HMComfirtTypeCollection = _HMComfirtTypeDataProvider.GetHMComfirtTypeBySearch(searchRequest);
                else
                {
                    HMComfirtTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMComfirtTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMComfirtTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMComfirtTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMComfirtTypeCollection;
        }

        public IBaseEntityCollectionResponse<HMComfirtType> GetHMComfirtTypeSearchList(HMComfirtTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMComfirtType> HMComfirtTypeCollection = new BaseEntityCollectionResponse<HMComfirtType>();
            try
            {
                if (_HMComfirtTypeDataProvider != null)
                    HMComfirtTypeCollection = _HMComfirtTypeDataProvider.GetHMComfirtTypeSearchList(searchRequest);
                else
                {
                    HMComfirtTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMComfirtTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMComfirtTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMComfirtTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMComfirtTypeCollection;
        }
        /// <summary>
        /// Select a record from HMComfirtType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMComfirtType> SelectByID(HMComfirtType item)
        {
            IBaseEntityResponse<HMComfirtType> entityResponse = new BaseEntityResponse<HMComfirtType>();
            try
            {
                entityResponse = _HMComfirtTypeDataProvider.GetHMComfirtTypeByID(item);
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

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
    public class HMIPDTypeBA : IHMIPDTypeBA
    {
        IHMIPDTypeDataProvider _HMIPDTypeDataProvider;
        IHMIPDTypeBR _HMIPDTypeBR;
        private ILogger _logException;
        public HMIPDTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMIPDTypeBR = new HMIPDTypeBR();
            _HMIPDTypeDataProvider = new HMIPDTypeDataProvider();
        }
        /// <summary>
        /// Create new record of HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMIPDType> InsertHMIPDType(HMIPDType item)
        {
            IBaseEntityResponse<HMIPDType> entityResponse = new BaseEntityResponse<HMIPDType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMIPDTypeBR.InsertHMIPDTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMIPDTypeDataProvider.InsertHMIPDType(item);
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
        /// Update a specific record  of HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMIPDType> UpdateHMIPDType(HMIPDType item)
        {
            IBaseEntityResponse<HMIPDType> entityResponse = new BaseEntityResponse<HMIPDType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMIPDTypeBR.UpdateHMIPDTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMIPDTypeDataProvider.UpdateHMIPDType(item);
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
        /// Delete a selected record from HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMIPDType> DeleteHMIPDType(HMIPDType item)
        {
            IBaseEntityResponse<HMIPDType> entityResponse = new BaseEntityResponse<HMIPDType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMIPDTypeBR.DeleteHMIPDTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMIPDTypeDataProvider.DeleteHMIPDType(item);
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
        /// Select all record from HMIPDType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMIPDType> GetBySearch(HMIPDTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMIPDType> HMIPDTypeCollection = new BaseEntityCollectionResponse<HMIPDType>();
            try
            {
                if (_HMIPDTypeDataProvider != null)
                    HMIPDTypeCollection = _HMIPDTypeDataProvider.GetHMIPDTypeBySearch(searchRequest);
                else
                {
                    HMIPDTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMIPDTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMIPDTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMIPDTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMIPDTypeCollection;
        }

        public IBaseEntityCollectionResponse<HMIPDType> GetHMIPDTypeSearchList(HMIPDTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMIPDType> HMIPDTypeCollection = new BaseEntityCollectionResponse<HMIPDType>();
            try
            {
                if (_HMIPDTypeDataProvider != null)
                    HMIPDTypeCollection = _HMIPDTypeDataProvider.GetHMIPDTypeSearchList(searchRequest);
                else
                {
                    HMIPDTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMIPDTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMIPDTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMIPDTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMIPDTypeCollection;
        }
        /// <summary>
        /// Select a record from HMIPDType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMIPDType> SelectByID(HMIPDType item)
        {
            IBaseEntityResponse<HMIPDType> entityResponse = new BaseEntityResponse<HMIPDType>();
            try
            {
                entityResponse = _HMIPDTypeDataProvider.GetHMIPDTypeByID(item);
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
        //For IPD type Dropdown
        public IBaseEntityCollectionResponse<HMIPDType> GetIPDTypeList(HMIPDTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMIPDType> HMIPDTypeCollection = new BaseEntityCollectionResponse<HMIPDType>();
            try
            {
                if (_HMIPDTypeDataProvider != null)
                    HMIPDTypeCollection = _HMIPDTypeDataProvider.GetIPDTypeList(searchRequest);
                else
                {
                    HMIPDTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMIPDTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMIPDTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMIPDTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMIPDTypeCollection;
        }
    }
}

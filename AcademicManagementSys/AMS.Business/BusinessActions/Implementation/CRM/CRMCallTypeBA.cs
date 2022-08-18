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
    public class CRMCallTypeBA : ICRMCallTypeBA
    {
        ICRMCallTypeDataProvider _generalTitleMasterDataProvider;
        ICRMCallTypeBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMCallTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMCallTypeBR();
            _generalTitleMasterDataProvider = new CRMCallTypeDataProvider();
        }
        /// <summary>
        /// Create new record of CRMCallType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> InsertCRMCallType(CRMCallType item)
        {
            IBaseEntityResponse<CRMCallType> entityResponse = new BaseEntityResponse<CRMCallType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMCallTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMCallType(item);
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
        /// Update a specific record  of CRMCallType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> UpdateCRMCallType(CRMCallType item)
        {
            IBaseEntityResponse<CRMCallType> entityResponse = new BaseEntityResponse<CRMCallType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMCallTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMCallType(item);
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
        /// Delete a selected record from CRMCallType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> DeleteCRMCallType(CRMCallType item)
        {
            IBaseEntityResponse<CRMCallType> entityResponse = new BaseEntityResponse<CRMCallType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMCallTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMCallType(item);
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
        /// Select all record from CRMCallType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallType> GetBySearch(CRMCallTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallType> CRMCallTypeCollection = new BaseEntityCollectionResponse<CRMCallType>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMCallTypeCollection = _generalTitleMasterDataProvider.GetCRMCallTypeBySearch(searchRequest);
                else
                {
                    CRMCallTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallTypeCollection;
        }
        /// <summary>
        /// Select a record from CRMCallType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> SelectByID(CRMCallType item)
        {
            IBaseEntityResponse<CRMCallType> entityResponse = new BaseEntityResponse<CRMCallType>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetCRMCallTypeByID(item);
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
        /// Select all record from CRMCallType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallType> GetBySearchList(CRMCallTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallType> CRMCallTypeCollection = new BaseEntityCollectionResponse<CRMCallType>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMCallTypeCollection = _generalTitleMasterDataProvider.GetCRMCallTypeBySearchList(searchRequest);
                else
                {
                    CRMCallTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallTypeCollection;
        }
    }
}

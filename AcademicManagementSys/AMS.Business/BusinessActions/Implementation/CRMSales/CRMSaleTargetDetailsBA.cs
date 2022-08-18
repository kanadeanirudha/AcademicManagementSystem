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
    public class CRMSaleTargetDetailsBA : ICRMSaleTargetDetailsBA
    {
        ICRMSaleTargetDetailsDataProvider _generalTitleMasterDataProvider;
        ICRMSaleTargetDetailsBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMSaleTargetDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMSaleTargetDetailsBR();
            _generalTitleMasterDataProvider = new CRMSaleTargetDetailsDataProvider();
        }
        //CRMSaleTargetGroupWise
        public IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleTargetGroupWiseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleTargetGroupWise(item);
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
        public IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleTargetGroupWiseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleTargetGroupWise(item);
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
        public IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetGroupWise(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleTargetGroupWiseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleTargetGroupWise(item);
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
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetGroupWise(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> CRMSaleTargetDetailsCollection = new BaseEntityCollectionResponse<CRMSaleTargetDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleTargetDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleTargetGroupWise(searchRequest);
                else
                {
                    CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleTargetDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleTargetDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleTargetDetailsCollection;
        }
        public IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetGroupWiseID(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleTargetGroupWiseID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetGroupWiseSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> CRMSaleTargetDetailsCollection = new BaseEntityCollectionResponse<CRMSaleTargetDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleTargetDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleTargetGroupWiseSearchList(searchRequest);
                else
                {
                    CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleTargetDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleTargetDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleTargetDetailsCollection;
        }

        //CRMSaleTargetException
        public IBaseEntityResponse<CRMSaleTargetDetails> InsertCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleTargetExceptionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleTargetException(item);
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
        public IBaseEntityResponse<CRMSaleTargetDetails> UpdateCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleTargetExceptionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleTargetException(item);
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
        public IBaseEntityResponse<CRMSaleTargetDetails> DeleteCRMSaleTargetException(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleTargetExceptionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleTargetException(item);
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
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetBySearchCRMSaleTargetException(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> CRMSaleTargetDetailsCollection = new BaseEntityCollectionResponse<CRMSaleTargetDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleTargetDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleTargetException(searchRequest);
                else
                {
                    CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleTargetDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleTargetDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleTargetDetailsCollection;
        }
        public IBaseEntityResponse<CRMSaleTargetDetails> SelectByCRMSaleTargetExceptionID(CRMSaleTargetDetails item)
        {
            IBaseEntityResponse<CRMSaleTargetDetails> entityResponse = new BaseEntityResponse<CRMSaleTargetDetails>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleTargetExceptionID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetExceptionSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> CRMSaleTargetDetailsCollection = new BaseEntityCollectionResponse<CRMSaleTargetDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleTargetDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleTargetExceptionSearchList(searchRequest);
                else
                {
                    CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleTargetDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleTargetDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleTargetDetailsCollection;
        }

        //CRMSaleTargetType
        public IBaseEntityCollectionResponse<CRMSaleTargetDetails> GetCRMSaleTargetTypeSearchList(CRMSaleTargetDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleTargetDetails> CRMSaleTargetDetailsCollection = new BaseEntityCollectionResponse<CRMSaleTargetDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleTargetDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleTargetTypeSearchList(searchRequest);
                else
                {
                    CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleTargetDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleTargetDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleTargetDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleTargetDetailsCollection;
        }
    }
}

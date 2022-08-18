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
    public class CRMSaleEnquiryMasterAndAccountDetailsBA : ICRMSaleEnquiryMasterAndAccountDetailsBA
    {
        ICRMSaleEnquiryMasterAndAccountDetailsDataProvider _generalTitleMasterDataProvider;
        ICRMSaleEnquiryMasterAndAccountDetailsBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMSaleEnquiryMasterAndAccountDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMSaleEnquiryMasterAndAccountDetailsBR();
            _generalTitleMasterDataProvider = new CRMSaleEnquiryMasterAndAccountDetailsDataProvider();
        }
        //CRMSaleEnquiryMaster
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleEnquiryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleEnquiryMaster(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleEnquiryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleEnquiryMaster(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleEnquiryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleEnquiryMaster(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleEnquiryMaster(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleEnquiryMasterID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleEnquiryMasterSearchList(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }

        //CRMSaleEnquiryAccountMaster
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleEnquiryAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleEnquiryAccountMaster(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleEnquiryAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleEnquiryAccountMaster(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleEnquiryAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleEnquiryAccountMaster(item);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountTransferRequest(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleEnquiryAccountMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleEnquiryAccountTransferRequest(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleEnquiryAccountMaster(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAllAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleEnquiryAllAccountMaster(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleEnquiryAccountMasterID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleEnquiryAccountMasterSearchList(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }

      
        //CRMSaleEnquiryAccountContactPerson
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleEnquiryAccountContactPersonValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleEnquiryAccountContactPerson(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleEnquiryAccountContactPersonValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleEnquiryAccountContactPerson(item);
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
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleEnquiryAccountContactPersonValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleEnquiryAccountContactPerson(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleEnquiryAccountContactPerson(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountContactPersonID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> entityResponse = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleEnquiryAccountContactPersonID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountContactPersonSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> CRMSaleEnquiryMasterAndAccountDetailsCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleEnquiryMasterAndAccountDetailsCollection = _generalTitleMasterDataProvider.GetCRMSaleEnquiryAccountContactPersonSearchList(searchRequest);
                else
                {
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleEnquiryMasterAndAccountDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleEnquiryMasterAndAccountDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleEnquiryMasterAndAccountDetailsCollection;
        }

    }
}

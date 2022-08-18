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
    public class CRMSaleBillingTransactionBA : ICRMSaleBillingTransactionBA
    {
        ICRMSaleBillingTransactionDataProvider cRMSaleBillingTransactionDataProvider;
        ICRMSaleBillingTransactionBR cRMSaleBillingTransactionBR;

        private ILogger _logException;

        public CRMSaleBillingTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            cRMSaleBillingTransactionBR = new CRMSaleBillingTransactionBR();
            cRMSaleBillingTransactionDataProvider = new CRMSaleBillingTransactionDataProvider();
        }

        //CRMSaleBillingTransaction
        public IBaseEntityResponse<CRMSaleBillingTransaction> InsertCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> entityResponse = new BaseEntityResponse<CRMSaleBillingTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleBillingTransactionBR.InsertCRMSaleBillingTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleBillingTransactionDataProvider.InsertCRMSaleBillingTransaction(item);
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
        public IBaseEntityResponse<CRMSaleBillingTransaction> UpdateCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> entityResponse = new BaseEntityResponse<CRMSaleBillingTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleBillingTransactionBR.UpdateCRMSaleBillingTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleBillingTransactionDataProvider.UpdateCRMSaleBillingTransaction(item);
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
        public IBaseEntityResponse<CRMSaleBillingTransaction> DeleteCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> entityResponse = new BaseEntityResponse<CRMSaleBillingTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleBillingTransactionBR.DeleteCRMSaleBillingTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleBillingTransactionDataProvider.DeleteCRMSaleBillingTransaction(item);
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
        public IBaseEntityCollectionResponse<CRMSaleBillingTransaction> GetCRMSaleBillingTransactionSelectAll(CRMSaleBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleBillingTransaction> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<CRMSaleBillingTransaction>();
            try
            {
                if (cRMSaleBillingTransactionDataProvider != null)
                    cRMSaleBillingTransactionCollection = cRMSaleBillingTransactionDataProvider.GetCRMSaleBillingTransactionSelectAll(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }
        public IBaseEntityResponse<CRMSaleBillingTransaction> SelectByCRMSaleBillingTransactionID(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> entityResponse = new BaseEntityResponse<CRMSaleBillingTransaction>();
            try
            {
                entityResponse = cRMSaleBillingTransactionDataProvider.SelectByCRMSaleBillingTransactionID(item);
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

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
    public class CRMSaleAccountProgressTypeMasterAndRuleBA : ICRMSaleAccountProgressTypeMasterAndRuleBA
    {
        ICRMSaleAccountProgressTypeMasterAndRuleDataProvider _generalTitleMasterDataProvider;
        ICRMSaleAccountProgressTypeMasterAndRuleBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMSaleAccountProgressTypeMasterAndRuleBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMSaleAccountProgressTypeMasterAndRuleBR();
            _generalTitleMasterDataProvider = new CRMSaleAccountProgressTypeMasterAndRuleDataProvider();
        }
        //CRMSaleAccountProgressTypeRule
        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> InsertCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> entityResponse = new BaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleAccountProgressTypeRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleAccountProgressTypeRule(item);
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
        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> UpdateCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> entityResponse = new BaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleAccountProgressTypeRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleAccountProgressTypeRule(item);
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
        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> DeleteCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> entityResponse = new BaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleAccountProgressTypeRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleAccountProgressTypeRule(item);
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
        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetBySearchCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> CRMSaleAccountProgressTypeMasterAndRuleCollection = new BaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleAccountProgressTypeMasterAndRuleCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleAccountProgressTypeRule(searchRequest);
                else
                {
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleAccountProgressTypeMasterAndRuleCollection;
        }
        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> SelectByCRMSaleAccountProgressTypeRuleID(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> entityResponse = new BaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleAccountProgressTypeRuleID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeRuleSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> CRMSaleAccountProgressTypeMasterAndRuleCollection = new BaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleAccountProgressTypeMasterAndRuleCollection = _generalTitleMasterDataProvider.GetCRMSaleAccountProgressTypeRuleSearchList(searchRequest);
                else
                {
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleAccountProgressTypeMasterAndRuleCollection;
        }

      
        //CRMSaleAccountProgressTypeMaster
        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeMasterSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> CRMSaleAccountProgressTypeMasterAndRuleCollection = new BaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleAccountProgressTypeMasterAndRuleCollection = _generalTitleMasterDataProvider.GetCRMSaleAccountProgressTypeMasterSearchList(searchRequest);
                else
                {
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleAccountProgressTypeMasterAndRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleAccountProgressTypeMasterAndRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleAccountProgressTypeMasterAndRuleCollection;
        }
    }
}

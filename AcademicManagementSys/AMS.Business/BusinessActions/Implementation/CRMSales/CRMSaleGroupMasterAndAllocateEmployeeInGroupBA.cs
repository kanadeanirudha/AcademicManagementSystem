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
    public class CRMSaleGroupMasterAndAllocateEmployeeInGroupBA : ICRMSaleGroupMasterAndAllocateEmployeeInGroupBA
    {
        ICRMSaleGroupMasterAndAllocateEmployeeInGroupDataProvider _generalTitleMasterDataProvider;
        ICRMSaleGroupMasterAndAllocateEmployeeInGroupBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMSaleGroupMasterAndAllocateEmployeeInGroupBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMSaleGroupMasterAndAllocateEmployeeInGroupBR();
            _generalTitleMasterDataProvider = new CRMSaleGroupMasterAndAllocateEmployeeInGroupDataProvider();
        }
        //CRMSaleGroupMaster
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleGroupMaster(item);
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
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CheckAuthorityToCreateGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.CheckAuthorityToCreateGroup(item);
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
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleGroupMaster(item);
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
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleGroupMaster(item);
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
        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = new BaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleGroupMaster(searchRequest);
                else
                {
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection;
        }
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleGroupMasterID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleGroupMasterID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleGroupMasterSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = new BaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = _generalTitleMasterDataProvider.GetCRMSaleGroupMasterSearchList(searchRequest);
                else
                {
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection;
        }

        //CRMSaleAllocateEmployeeInGroup
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> InsertCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMSaleAllocateEmployeeInGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMSaleAllocateEmployeeInGroup(item);
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
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> UpdateCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMSaleAllocateEmployeeInGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMSaleAllocateEmployeeInGroup(item);
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
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> DeleteCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMSaleAllocateEmployeeInGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMSaleAllocateEmployeeInGroup(item);
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
        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetBySearchCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = new BaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = _generalTitleMasterDataProvider.GetBySearchCRMSaleAllocateEmployeeInGroup(searchRequest);
                else
                {
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection;
        }
        public IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> SelectByCRMSaleAllocateEmployeeInGroupID(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IBaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> entityResponse = new BaseEntityResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.SelectByCRMSaleAllocateEmployeeInGroupID(item);
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
        public IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> GetCRMSaleAllocateEmployeeInGroupSearchList(CRMSaleGroupMasterAndAllocateEmployeeInGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup> CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = new BaseEntityCollectionResponse<CRMSaleGroupMasterAndAllocateEmployeeInGroup>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection = _generalTitleMasterDataProvider.GetCRMSaleAllocateEmployeeInGroupSearchList(searchRequest);
                else
                {
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleGroupMasterAndAllocateEmployeeInGroupCollection;
        }
    }
}

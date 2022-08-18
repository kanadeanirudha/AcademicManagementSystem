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
    public class CRMCallerRoleAllocationBA : ICRMCallerRoleAllocationBA
    {
        ICRMCallerRoleAllocationDataProvider _generalTitleMasterDataProvider;
        ICRMCallerRoleAllocationBR _generalTitleMasterBR;
        private ILogger _logException;
        public CRMCallerRoleAllocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new CRMCallerRoleAllocationBR();
            _generalTitleMasterDataProvider = new CRMCallerRoleAllocationDataProvider();
        }
        /// <summary>
        /// Create new record of CRMCallerRoleAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> InsertCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            IBaseEntityResponse<CRMCallerRoleAllocation> entityResponse = new BaseEntityResponse<CRMCallerRoleAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertCRMCallerRoleAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertCRMCallerRoleAllocation(item);
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
        /// Update a specific record  of CRMCallerRoleAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> UpdateCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            IBaseEntityResponse<CRMCallerRoleAllocation> entityResponse = new BaseEntityResponse<CRMCallerRoleAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateCRMCallerRoleAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateCRMCallerRoleAllocation(item);
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
        /// Delete a selected record from CRMCallerRoleAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> DeleteCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            IBaseEntityResponse<CRMCallerRoleAllocation> entityResponse = new BaseEntityResponse<CRMCallerRoleAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteCRMCallerRoleAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteCRMCallerRoleAllocation(item);
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
        /// Select all record from CRMCallerRoleAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearch(CRMCallerRoleAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallerRoleAllocation> CRMCallerRoleAllocationCollection = new BaseEntityCollectionResponse<CRMCallerRoleAllocation>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMCallerRoleAllocationCollection = _generalTitleMasterDataProvider.GetCRMCallerRoleAllocationBySearch(searchRequest);
                else
                {
                    CRMCallerRoleAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallerRoleAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallerRoleAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallerRoleAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallerRoleAllocationCollection;
        }
        /// <summary>
        /// Select a record from CRMCallerRoleAllocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> SelectByID(CRMCallerRoleAllocation item)
        {
            IBaseEntityResponse<CRMCallerRoleAllocation> entityResponse = new BaseEntityResponse<CRMCallerRoleAllocation>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetCRMCallerRoleAllocationByID(item);
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
        /// Select all record from CRMCallerRoleAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearchList(CRMCallerRoleAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallerRoleAllocation> CRMCallerRoleAllocationCollection = new BaseEntityCollectionResponse<CRMCallerRoleAllocation>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    CRMCallerRoleAllocationCollection = _generalTitleMasterDataProvider.GetCRMCallerRoleAllocationBySearchList(searchRequest);
                else
                {
                    CRMCallerRoleAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallerRoleAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallerRoleAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallerRoleAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallerRoleAllocationCollection;
        }
    }
}

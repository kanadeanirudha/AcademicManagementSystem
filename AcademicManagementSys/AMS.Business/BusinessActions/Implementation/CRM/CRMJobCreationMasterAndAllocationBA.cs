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

namespace AMS.Business.BusinessAction
{
    public class CRMJobCreationMasterAndAllocationBA : ICRMJobCreationMasterAndAllocationBA
    {
        ICRMJobCreationMasterAndAllocationDataProvider _cRMJobCreationMasterAndAllocationDataProvider;
        ICRMJobCreationMasterAndAllocationBR _cRMJobCreationMasterAndAllocationBR;
        private ILogger _logException;

        public CRMJobCreationMasterAndAllocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _cRMJobCreationMasterAndAllocationBR = new CRMJobCreationMasterAndAllocationBR();
            _cRMJobCreationMasterAndAllocationDataProvider = new CRMJobCreationMasterAndAllocationDataProvider();
        }
        /// <summary>
        /// Create new record of CRMJobCreationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> InsertCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> entityResponse = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _cRMJobCreationMasterAndAllocationBR.InsertCRMJobCreationMasterAndAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _cRMJobCreationMasterAndAllocationDataProvider.InsertCRMJobCreationMasterAndAllocation(item);
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
        /// Update a specific record  of CRMJobCreationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> UpdateCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> entityResponse = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _cRMJobCreationMasterAndAllocationBR.UpdateCRMJobCreationMasterAndAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _cRMJobCreationMasterAndAllocationDataProvider.UpdateCRMJobCreationMasterAndAllocation(item);
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
        /// Delete a selected record from CRMJobCreationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> DeleteCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> entityResponse = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _cRMJobCreationMasterAndAllocationBR.DeleteCRMJobCreationMasterAndAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _cRMJobCreationMasterAndAllocationDataProvider.DeleteCRMJobCreationMasterAndAllocation(item);
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
        /// Select all record from CRMJobCreationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetBySearch(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobCreationMasterCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                if (_cRMJobCreationMasterAndAllocationDataProvider != null)
                    CRMJobCreationMasterCollection = _cRMJobCreationMasterAndAllocationDataProvider.GetCRMJobCreationMasterAndAllocationBySearch(searchRequest);
                else
                {
                    CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMJobCreationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMJobCreationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMJobCreationMasterCollection;
        }
        /// <summary>
        /// Select a record from CRMJobCreationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SelectByID(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> entityResponse = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                entityResponse = _cRMJobCreationMasterAndAllocationDataProvider.GetCRMJobCreationMasterAndAllocationByID(item);
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

        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetByCRMJobListByEmployeeID(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobCreationMasterCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                if (_cRMJobCreationMasterAndAllocationDataProvider != null)
                    CRMJobCreationMasterCollection = _cRMJobCreationMasterAndAllocationDataProvider.GetByCRMJobListByEmployeeID(searchRequest);
                else
                {
                    CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMJobCreationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMJobCreationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMJobCreationMasterCollection;
        }

         /// <summary>
        /// Select a record from CRMJobCreationMaster table for checking weather job name is already exists or not
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SearchForDuplicateJobName(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> entityResponse = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                entityResponse = _cRMJobCreationMasterAndAllocationDataProvider.SearchForDuplicateJobName(item);
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
        /// Select all record from CRMJobCreationAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobAllocationList(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobCreationMasterCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
            try
            {
                if (_cRMJobCreationMasterAndAllocationDataProvider != null)
                    CRMJobCreationMasterCollection = _cRMJobCreationMasterAndAllocationDataProvider.CRMJobAllocationList(searchRequest);
                else
                {
                    CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMJobCreationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMJobCreationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMJobCreationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMJobCreationMasterCollection;
        }

        
    }
}

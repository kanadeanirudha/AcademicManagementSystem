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
    public class FeeReceiptMasterBA : IFeeReceiptMasterBA
    {
        IFeeReceiptMasterDataProvider _FeeReceiptMasterDataProvider;
        IFeeReceiptMasterBR _FeeReceiptMasterBR;
        private ILogger _logException;
        public FeeReceiptMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _FeeReceiptMasterBR = new FeeReceiptMasterBR();
            _FeeReceiptMasterDataProvider = new FeeReceiptMasterDataProvider();
        }
        /// <summary>
        /// Create new record of FeeReceiptMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeReceiptMaster> InsertFeeReceiptMaster(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> entityResponse = new BaseEntityResponse<FeeReceiptMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeReceiptMasterBR.InsertFeeReceiptMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeReceiptMasterDataProvider.InsertFeeReceiptMaster(item);
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
        /// Update a specific record  of FeeReceiptMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeReceiptMaster> UpdateFeeReceiptMaster(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> entityResponse = new BaseEntityResponse<FeeReceiptMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeReceiptMasterBR.UpdateFeeReceiptMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeReceiptMasterDataProvider.UpdateFeeReceiptMaster(item);
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
        /// Select all record from FeeReceiptMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetBySearch(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> FeeReceiptMasterCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
            try
            {
                if (_FeeReceiptMasterDataProvider != null)
                    FeeReceiptMasterCollection = _FeeReceiptMasterDataProvider.GetFeeReceiptMasterBySearch(searchRequest);
                else
                {
                    FeeReceiptMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeReceiptMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeReceiptMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeReceiptMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeReceiptMasterCollection;
        }
        /// <summary>
        /// Select all record from FeeReceiptMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetAccountListForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> FeeReceiptMasterCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
            try
            {
                if (_FeeReceiptMasterDataProvider != null)
                    FeeReceiptMasterCollection = _FeeReceiptMasterDataProvider.GetAccountListForFeeReceipt(searchRequest);
                else
                {
                    FeeReceiptMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeReceiptMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeReceiptMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeReceiptMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeReceiptMasterCollection;
        }
        /// <summary>
        /// Select a record from FeeReceiptMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeReceiptMaster> SelectByID(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> entityResponse = new BaseEntityResponse<FeeReceiptMaster>();
            try
            {
                entityResponse = _FeeReceiptMasterDataProvider.GetFeeReceiptMasterByID(item);
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

        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentPaymentDetails(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
            try
            {
                if (_FeeReceiptMasterDataProvider != null)
                    FeeStructureApprovalCollection = _FeeReceiptMasterDataProvider.GetStudentPaymentDetails(searchRequest);
                else
                {
                    FeeStructureApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureApprovalCollection;
        }
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentDetailsForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
            try
            {
                if (_FeeReceiptMasterDataProvider != null)
                    FeeStructureApprovalCollection = _FeeReceiptMasterDataProvider.GetStudentDetailsForFeeReceipt(searchRequest);
                else
                {
                    FeeStructureApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureApprovalCollection;
        }
    }
}

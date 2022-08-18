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
    public class FeeRefundMasterBA : IFeeRefundMasterBA
    {
        IFeeRefundMasterDataProvider _FeeRefundMasterDataProvider;
        IFeeRefundMasterBR _FeeRefundMasterBR;
        private ILogger _logException;
        public FeeRefundMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _FeeRefundMasterBR = new FeeRefundMasterBR();
            _FeeRefundMasterDataProvider = new FeeRefundMasterDataProvider();
        }
        /// <summary>
        /// Create new record of FeeRefundMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeRefundMaster> InsertFeeRefundMaster(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> entityResponse = new BaseEntityResponse<FeeRefundMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeRefundMasterBR.InsertFeeRefundMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeRefundMasterDataProvider.InsertFeeRefundMaster(item);
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
        /// Update a specific record  of FeeRefundMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeRefundMaster> UpdateFeeRefundMaster(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> entityResponse = new BaseEntityResponse<FeeRefundMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeRefundMasterBR.UpdateFeeRefundMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeRefundMasterDataProvider.UpdateFeeRefundMaster(item);
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
        /// Select all record from FeeRefundMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetBySearch(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> FeeRefundMasterCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
            try
            {
                if (_FeeRefundMasterDataProvider != null)
                    FeeRefundMasterCollection = _FeeRefundMasterDataProvider.GetFeeRefundMasterBySearch(searchRequest);
                else
                {
                    FeeRefundMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeRefundMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeRefundMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeRefundMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeRefundMasterCollection;
        }
        /// <summary>
        /// Select all record from FeeRefundMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetAccountListForFeeRefund(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> FeeRefundMasterCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
            try
            {
                if (_FeeRefundMasterDataProvider != null)
                    FeeRefundMasterCollection = _FeeRefundMasterDataProvider.GetAccountListForFeeRefund(searchRequest);
                else
                {
                    FeeRefundMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeRefundMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeRefundMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeRefundMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeRefundMasterCollection;
        }
        /// <summary>
        /// Select a record from FeeRefundMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeRefundMaster> SelectByID(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> entityResponse = new BaseEntityResponse<FeeRefundMaster>();
            try
            {
                entityResponse = _FeeRefundMasterDataProvider.GetFeeRefundMasterByID(item);
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

        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentPaymentDetails(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
            try
            {
                if (_FeeRefundMasterDataProvider != null)
                    FeeStructureApprovalCollection = _FeeRefundMasterDataProvider.GetStudentPaymentDetails(searchRequest);
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
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentDetailsForFeeReceipt(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
            try
            {
                if (_FeeRefundMasterDataProvider != null)
                    FeeStructureApprovalCollection = _FeeRefundMasterDataProvider.GetStudentDetailsForFeeReceipt(searchRequest);
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

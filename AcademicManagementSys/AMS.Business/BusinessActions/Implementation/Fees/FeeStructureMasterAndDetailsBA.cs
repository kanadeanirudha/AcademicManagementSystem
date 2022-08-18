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
    public class FeeStructureMasterAndDetailsBA : IFeeStructureMasterAndDetailsBA
    {
        IFeeStructureMasterAndDetailsDataProvider _FeeStructureMasterAndDetailsDataProvider;
        IFeeStructureMasterAndDetailsBR _FeeStructureMasterAndDetailsBR;
        private ILogger _logException;
        public FeeStructureMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _FeeStructureMasterAndDetailsBR = new FeeStructureMasterAndDetailsBR();
            _FeeStructureMasterAndDetailsDataProvider = new FeeStructureMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of FeeStructureMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> InsertFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> entityResponse = new BaseEntityResponse<FeeStructureMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeStructureMasterAndDetailsBR.InsertFeeStructureMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeStructureMasterAndDetailsDataProvider.InsertFeeStructureMasterAndDetails(item);
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
        /// Update a specific record  of FeeStructureMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> UpdateFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> entityResponse = new BaseEntityResponse<FeeStructureMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeStructureMasterAndDetailsBR.UpdateFeeStructureMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeStructureMasterAndDetailsDataProvider.UpdateFeeStructureMasterAndDetails(item);
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
        /// Delete a selected record from FeeStructureMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> DeleteFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> entityResponse = new BaseEntityResponse<FeeStructureMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeStructureMasterAndDetailsBR.DeleteFeeStructureMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeStructureMasterAndDetailsDataProvider.DeleteFeeStructureMasterAndDetails(item);
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
        /// Select all record from FeeStructureMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetBySearch(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    FeeStructureMasterAndDetailsCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeStructureMasterAndDetailsBySearch(searchRequest);
                else
                {
                    FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select all record from FeeStructureMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    FeeStructureMasterAndDetailsCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeSubTypeList(searchRequest);
                else
                {
                    FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select all record from FeeStructureMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureDetails(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    FeeStructureMasterAndDetailsCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeStructureDetails(searchRequest);
                else
                {
                    FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select all record from FeeStructureMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureInstallmentList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    FeeStructureMasterAndDetailsCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeStructureInstallmentList(searchRequest);
                else
                {
                    FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from FeeStructureMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> SelectByID(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> entityResponse = new BaseEntityResponse<FeeStructureMasterAndDetails>();
            try
            {
                entityResponse = _FeeStructureMasterAndDetailsDataProvider.GetFeeStructureMasterAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByFeeStructureMasterID(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> FeeStructureMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    FeeStructureMasterAndDetailsCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeStructureMasterAndDetailsByFeeStructureMasterID(searchRequest);
                else
                {
                    FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureMasterAndDetailsCollection;
        }












        //GetFeeAccountTypeAndSubTypeList
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeAccountTypeAndSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> feeAccountTypeAndSubTypeCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
            try
            {
                if (_FeeStructureMasterAndDetailsDataProvider != null)
                    feeAccountTypeAndSubTypeCollection = _FeeStructureMasterAndDetailsDataProvider.GetFeeAccountTypeAndSubTypeList(searchRequest);
                else
                {
                    feeAccountTypeAndSubTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    feeAccountTypeAndSubTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                feeAccountTypeAndSubTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                feeAccountTypeAndSubTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return feeAccountTypeAndSubTypeCollection;
        }
    }
}

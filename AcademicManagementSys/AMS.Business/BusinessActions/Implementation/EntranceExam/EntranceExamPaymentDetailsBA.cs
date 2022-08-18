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
    public class EntranceExamPaymentDetailsBA : IEntranceExamPaymentDetailsBA
    {

        IEntranceExamPaymentDetailsDataProvider _entranceExamPaymentDetailsDataProvider;
        IEntranceExamPaymentDetailsBR _entranceExamPaymentDetailsBR;
        private ILogger _logException;

        public EntranceExamPaymentDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _entranceExamPaymentDetailsBR = new EntranceExamPaymentDetailsBR();
            _entranceExamPaymentDetailsDataProvider = new EntranceExamPaymentDetailsDataProvider();
        }

        // EntranceExamPaymentDetails Method
        #region EntranceExamPaymentDetails

        /// Create new record of EntranceExamPaymentDetails.        
        public IBaseEntityResponse<EntranceExamPaymentDetails> InsertEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> entityResponse = new BaseEntityResponse<EntranceExamPaymentDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamPaymentDetailsBR.InsertEntranceExamPaymentDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamPaymentDetailsDataProvider.InsertEntranceExamPaymentDetails(item);
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

        /// Update a specific record  of EntranceExamPaymentDetails.       
        public IBaseEntityResponse<EntranceExamPaymentDetails> UpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> entityResponse = new BaseEntityResponse<EntranceExamPaymentDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamPaymentDetailsBR.UpdateEntranceExamPaymentDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamPaymentDetailsDataProvider.UpdateEntranceExamPaymentDetails(item);
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

        /// Delete a selected record from EntranceExamPaymentDetails.        
        public IBaseEntityResponse<EntranceExamPaymentDetails> DeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> entityResponse = new BaseEntityResponse<EntranceExamPaymentDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _entranceExamPaymentDetailsBR.DeleteEntranceExamPaymentDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _entranceExamPaymentDetailsDataProvider.DeleteEntranceExamPaymentDetails(item);
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

        /// Select all record from EntranceExamPaymentDetails table with search parameters.        
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsBySearch(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamPaymentDetails> EntranceExamPaymentDetailsCollection = new BaseEntityCollectionResponse<EntranceExamPaymentDetails>();
            try
            {
                if (_entranceExamPaymentDetailsDataProvider != null)
                    EntranceExamPaymentDetailsCollection = _entranceExamPaymentDetailsDataProvider.GetEntranceExamPaymentDetailsBySearch(searchRequest);
                else
                {
                    EntranceExamPaymentDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamPaymentDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamPaymentDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamPaymentDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamPaymentDetailsCollection;
        }

        /// Select a record from EntranceExamPaymentDetails table by ID        
        public IBaseEntityResponse<EntranceExamPaymentDetails> SelectEntranceExamPaymentDetailsByID(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> entityResponse = new BaseEntityResponse<EntranceExamPaymentDetails>();
            try
            {
                entityResponse = _entranceExamPaymentDetailsDataProvider.GetEntranceExamPaymentDetailsByID(item);
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

        // Select all record from EntranceExamPaymentDetails table to search list.
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsSearchList(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamPaymentDetails> EntranceExamPaymentDetailsCollection = new BaseEntityCollectionResponse<EntranceExamPaymentDetails>();
            try
            {
                if (_entranceExamPaymentDetailsDataProvider != null)
                    EntranceExamPaymentDetailsCollection = _entranceExamPaymentDetailsDataProvider.GetEntranceExamPaymentDetailsBySearch(searchRequest);
                else
                {
                    EntranceExamPaymentDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamPaymentDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamPaymentDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamPaymentDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamPaymentDetailsCollection;
        }

        #endregion

    }
}

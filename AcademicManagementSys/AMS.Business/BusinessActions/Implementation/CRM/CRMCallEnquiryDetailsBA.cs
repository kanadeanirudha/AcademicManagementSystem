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
    public class CRMCallEnquiryDetailsBA : ICRMCallEnquiryDetailsBA
    {
        ICRMCallEnquiryDetailsDataProvider _CRMCallEnquiryDetailsDataProvider;
        ICRMCallEnquiryDetailsBR _CRMCallEnquiryDetailsBR;
        private ILogger _logException;
        public CRMCallEnquiryDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CRMCallEnquiryDetailsBR = new CRMCallEnquiryDetailsBR();
            _CRMCallEnquiryDetailsDataProvider = new CRMCallEnquiryDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of CRMCallEnquiryDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallEnquiryDetailsBR.InsertCRMCallEnquiryDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallEnquiryDetailsDataProvider.InsertCRMCallEnquiryDetails(item);
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
        /// Update a specific record  of CRMCallEnquiryDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> UpdateCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallEnquiryDetailsBR.UpdateCRMCallEnquiryDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallEnquiryDetailsDataProvider.UpdateCRMCallEnquiryDetails(item);
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
        /// Delete a selected record from CRMCallEnquiryDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallEnquiryDetailsBR.DeleteCRMCallEnquiryDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallEnquiryDetailsDataProvider.DeleteCRMCallEnquiryDetails(item);
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
        /// Select all record from CRMCallEnquiryDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearch(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> CRMCallEnquiryDetailsCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
            try
            {
                if (_CRMCallEnquiryDetailsDataProvider != null)
                    CRMCallEnquiryDetailsCollection = _CRMCallEnquiryDetailsDataProvider.GetCRMCallEnquiryDetailsBySearch(searchRequest);
                else
                {
                    CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallEnquiryDetailsCollection;
        }

        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsList(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> CRMCallEnquiryDetailsCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
            try
            {
                if (_CRMCallEnquiryDetailsDataProvider != null)
                    CRMCallEnquiryDetailsCollection = _CRMCallEnquiryDetailsDataProvider.GetCRMCallEnquiryDetailsList(searchRequest);
                else
                {
                    CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallEnquiryDetailsCollection;
        }
        /// <summary>
        /// Select a record from CRMCallEnquiryDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> SelectByID(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                entityResponse = _CRMCallEnquiryDetailsDataProvider.GetCRMCallEnquiryDetailsByID(item);
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


        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> CRMCallEnquiryDetailsCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
            try
            {
                if (_CRMCallEnquiryDetailsDataProvider != null)
                    CRMCallEnquiryDetailsCollection = _CRMCallEnquiryDetailsDataProvider.GetBySearchCallForward(searchRequest);
                else
                {
                    CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMCallEnquiryDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMCallEnquiryDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMCallEnquiryDetailsCollection;
        }

        //To insert record in call forward
        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallEnquiryDetailsBR.InsertCRMCallEnquiryDetailsCallForward(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallEnquiryDetailsDataProvider.InsertCRMCallEnquiryDetailsCallForward(item);
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
        /// Select a record from CRMCallEnquiryDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> SelectPendingCallEnquiryCount(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> entityResponse = new BaseEntityResponse<CRMCallEnquiryDetails>();
            try
            {
                entityResponse = _CRMCallEnquiryDetailsDataProvider.SelectPendingCallEnquiryCount(item);
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

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
    public class HMAppointmentTransactionBA : IHMAppointmentTransactionBA
    {
        IHMAppointmentTransactionDataProvider _HMAppointmentTransactionDataProvider;
        IHMAppointmentTransactionBR _HMAppointmentTransactionBR;
        private ILogger _logException;
        public HMAppointmentTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMAppointmentTransactionBR = new HMAppointmentTransactionBR();
            _HMAppointmentTransactionDataProvider = new HMAppointmentTransactionDataProvider();
        }
        /// <summary>
        /// Create new record of HMAppointmentTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMAppointmentTransactionBR.InsertHMAppointmentTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMAppointmentTransactionDataProvider.InsertHMAppointmentTransaction(item);
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
        /// Update a specific record  of HMAppointmentTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMAppointmentTransactionBR.UpdateHMAppointmentTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMAppointmentTransactionDataProvider.UpdateHMAppointmentTransaction(item);
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
        /// Delete a selected record from HMAppointmentTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMAppointmentTransactionBR.DeleteHMAppointmentTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMAppointmentTransactionDataProvider.DeleteHMAppointmentTransaction(item);
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
        /// Select all record from HMAppointmentTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetBySearch(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> HMAppointmentTransactionCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
            try
            {
                if (_HMAppointmentTransactionDataProvider != null)
                    HMAppointmentTransactionCollection = _HMAppointmentTransactionDataProvider.GetHMAppointmentTransactionBySearch(searchRequest);
                else
                {
                    HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMAppointmentTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMAppointmentTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMAppointmentTransactionCollection;
        }

        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> HMAppointmentTransactionCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
            try
            {
                if (_HMAppointmentTransactionDataProvider != null)
                    HMAppointmentTransactionCollection = _HMAppointmentTransactionDataProvider.GetHMAppointmentTransactionSearchList(searchRequest);
                else
                {
                    HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMAppointmentTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMAppointmentTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMAppointmentTransactionCollection;
        }
        /// <summary>
        /// Select a record from HMAppointmentTransaction table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> SelectByID(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                entityResponse = _HMAppointmentTransactionDataProvider.GetHMAppointmentTransactionByID(item);
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
        //For general Data
        public IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                entityResponse = _HMAppointmentTransactionDataProvider.GetGeneralDataByGeneralPatientMasterId(item);
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
        //for Last Case History
        public IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                entityResponse = _HMAppointmentTransactionDataProvider.LastcaseHistory(item);
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
        //for last priscription
      
        public IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> entityResponse = new BaseEntityResponse<HMAppointmentTransaction>();
            try
            {
                entityResponse = _HMAppointmentTransactionDataProvider.LastPrescription(item);
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
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> HMAppointmentTransactionCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
            try
            {
                if (_HMAppointmentTransactionDataProvider != null)
                    HMAppointmentTransactionCollection = _HMAppointmentTransactionDataProvider.GetListOfPatient(searchRequest);
                else
                {
                    HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMAppointmentTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMAppointmentTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMAppointmentTransactionCollection;
        }
        //For Appointment Data
        public IBaseEntityCollectionResponse<HMAppointmentTransaction>GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> HMAppointmentTransactionCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
            try
            {
                if (_HMAppointmentTransactionDataProvider != null)
                    HMAppointmentTransactionCollection = _HMAppointmentTransactionDataProvider.GetAppointmentData(searchRequest);
                else
                {
                    HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMAppointmentTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMAppointmentTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMAppointmentTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMAppointmentTransactionCollection;
        }
    }
}

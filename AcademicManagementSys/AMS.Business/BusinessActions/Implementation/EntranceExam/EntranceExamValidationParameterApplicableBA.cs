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
    public class EntranceExamValidationParameterApplicableBA : IEntranceExamValidationParameterApplicableBA
    {
        IEntranceExamValidationParameterApplicableDataProvider _EntranceExamValidationParameterApplicableDataProvider;
        IEntranceExamValidationParameterApplicableBR _EntranceExamValidationParameterApplicableBR;
        private ILogger _logException;
        public EntranceExamValidationParameterApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EntranceExamValidationParameterApplicableBR = new EntranceExamValidationParameterApplicableBR();
            _EntranceExamValidationParameterApplicableDataProvider = new EntranceExamValidationParameterApplicableDataProvider();
        }
        /// <summary>
        /// Create new record of EntranceExamValidationParameterApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> entityResponse = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterApplicableBR.InsertEntranceExamValidationParameterApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterApplicableDataProvider.InsertEntranceExamValidationParameterApplicable(item);
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
        /// Update a specific record  of EntranceExamValidationParameterApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> entityResponse = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterApplicableBR.UpdateEntranceExamValidationParameterApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterApplicableDataProvider.UpdateEntranceExamValidationParameterApplicable(item);
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
        /// Delete a selected record from EntranceExamValidationParameterApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> entityResponse = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterApplicableBR.DeleteEntranceExamValidationParameterApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterApplicableDataProvider.DeleteEntranceExamValidationParameterApplicable(item);
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
        /// Select all record from EntranceExamValidationParameterApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> EntranceExamValidationParameterApplicableCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                if (_EntranceExamValidationParameterApplicableDataProvider != null)
                    EntranceExamValidationParameterApplicableCollection = _EntranceExamValidationParameterApplicableDataProvider.GetEntranceExamValidationParameterApplicableBySearch(searchRequest);
                else
                {
                    EntranceExamValidationParameterApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamValidationParameterApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamValidationParameterApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamValidationParameterApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamValidationParameterApplicableCollection;
        }

        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> EntranceExamValidationParameterApplicableCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                if (_EntranceExamValidationParameterApplicableDataProvider != null)
                    EntranceExamValidationParameterApplicableCollection = _EntranceExamValidationParameterApplicableDataProvider.GetEntranceExamValidationParameterApplicableList(searchRequest);
                else
                {
                    EntranceExamValidationParameterApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamValidationParameterApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamValidationParameterApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamValidationParameterApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamValidationParameterApplicableCollection;
        }
        /// <summary>
        /// Select a record from EntranceExamValidationParameterApplicable table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> SelectByID(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> entityResponse = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
            try
            {
                entityResponse = _EntranceExamValidationParameterApplicableDataProvider.GetEntranceExamValidationParameterApplicableByID(item);
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

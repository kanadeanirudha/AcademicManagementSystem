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
    public class EntranceExamValidationParameterBA : IEntranceExamValidationParameterBA
    {
        IEntranceExamValidationParameterDataProvider _EntranceExamValidationParameterDataProvider;
        IEntranceExamValidationParameterBR _EntranceExamValidationParameterBR;
        private ILogger _logException;
        public EntranceExamValidationParameterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EntranceExamValidationParameterBR = new EntranceExamValidationParameterBR();
            _EntranceExamValidationParameterDataProvider = new EntranceExamValidationParameterDataProvider();
        }
        /// <summary>
        /// Create new record of EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameter> InsertEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            IBaseEntityResponse<EntranceExamValidationParameter> entityResponse = new BaseEntityResponse<EntranceExamValidationParameter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterBR.InsertEntranceExamValidationParameterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterDataProvider.InsertEntranceExamValidationParameter(item);
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
        /// Update a specific record  of EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameter> UpdateEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            IBaseEntityResponse<EntranceExamValidationParameter> entityResponse = new BaseEntityResponse<EntranceExamValidationParameter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterBR.UpdateEntranceExamValidationParameterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterDataProvider.UpdateEntranceExamValidationParameter(item);
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
        /// Delete a selected record from EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameter> DeleteEntranceExamValidationParameter(EntranceExamValidationParameter item)
        {
            IBaseEntityResponse<EntranceExamValidationParameter> entityResponse = new BaseEntityResponse<EntranceExamValidationParameter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamValidationParameterBR.DeleteEntranceExamValidationParameterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamValidationParameterDataProvider.DeleteEntranceExamValidationParameter(item);
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
        /// Select all record from EntranceExamValidationParameter table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetBySearch(EntranceExamValidationParameterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameter> EntranceExamValidationParameterCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameter>();
            try
            {
                if (_EntranceExamValidationParameterDataProvider != null)
                    EntranceExamValidationParameterCollection = _EntranceExamValidationParameterDataProvider.GetEntranceExamValidationParameterBySearch(searchRequest);
                else
                {
                    EntranceExamValidationParameterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamValidationParameterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamValidationParameterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamValidationParameterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamValidationParameterCollection;
        }

        public IBaseEntityCollectionResponse<EntranceExamValidationParameter> GetEntranceExamValidationParameterList(EntranceExamValidationParameterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameter> EntranceExamValidationParameterCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameter>();
            try
            {
                if (_EntranceExamValidationParameterDataProvider != null)
                    EntranceExamValidationParameterCollection = _EntranceExamValidationParameterDataProvider.GetEntranceExamValidationParameterList(searchRequest);
                else
                {
                    EntranceExamValidationParameterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamValidationParameterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamValidationParameterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamValidationParameterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamValidationParameterCollection;
        }
        /// <summary>
        /// Select a record from EntranceExamValidationParameter table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameter> SelectByID(EntranceExamValidationParameter item)
        {
            IBaseEntityResponse<EntranceExamValidationParameter> entityResponse = new BaseEntityResponse<EntranceExamValidationParameter>();
            try
            {
                entityResponse = _EntranceExamValidationParameterDataProvider.GetEntranceExamValidationParameterByID(item);
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

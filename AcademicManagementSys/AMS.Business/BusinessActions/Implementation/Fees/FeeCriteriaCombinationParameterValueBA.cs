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
    public class FeeCriteriaCombinationParameterValueBA : IFeeCriteriaCombinationParameterValueBA
    {
        IFeeCriteriaCombinationParameterValueDataProvider _feeCriteriaCombinationParameterValueDataProvider;
        IFeeCriteriaCombinationParameterValueBR _feeCriteriaCombinationParameterValueBR;
        private ILogger _logException;
        public FeeCriteriaCombinationParameterValueBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _feeCriteriaCombinationParameterValueBR = new FeeCriteriaCombinationParameterValueBR();
            _feeCriteriaCombinationParameterValueDataProvider = new FeeCriteriaCombinationParameterValueDataProvider();
        }
        /// <summary>
        /// Create new record of FeeCriteriaCombinationParameterValue.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> InsertFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            IBaseEntityResponse<FeeCriteriaCombinationParameterValue> entityResponse = new BaseEntityResponse<FeeCriteriaCombinationParameterValue>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaCombinationParameterValueBR.InsertFeeCriteriaCombinationParameterValueValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaCombinationParameterValueDataProvider.InsertFeeCriteriaCombinationParameterValue(item);
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
        /// Update a specific record  of FeeCriteriaCombinationParameterValue.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> UpdateFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            IBaseEntityResponse<FeeCriteriaCombinationParameterValue> entityResponse = new BaseEntityResponse<FeeCriteriaCombinationParameterValue>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaCombinationParameterValueBR.UpdateFeeCriteriaCombinationParameterValueValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaCombinationParameterValueDataProvider.UpdateFeeCriteriaCombinationParameterValue(item);
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
        /// Delete a selected record from FeeCriteriaCombinationParameterValue.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> DeleteFeeCriteriaCombinationParameterValue(FeeCriteriaCombinationParameterValue item)
        {
            IBaseEntityResponse<FeeCriteriaCombinationParameterValue> entityResponse = new BaseEntityResponse<FeeCriteriaCombinationParameterValue>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaCombinationParameterValueBR.DeleteFeeCriteriaCombinationParameterValueValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaCombinationParameterValueDataProvider.DeleteFeeCriteriaCombinationParameterValue(item);
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
        /// Select all record from FeeCriteriaCombinationParameterValue table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> GetBySearch(FeeCriteriaCombinationParameterValueSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue> FeeCriteriaCombinationParameterValueCollection = new BaseEntityCollectionResponse<FeeCriteriaCombinationParameterValue>();
            try
            {
                if (_feeCriteriaCombinationParameterValueDataProvider != null)
                    FeeCriteriaCombinationParameterValueCollection = _feeCriteriaCombinationParameterValueDataProvider.GetFeeCriteriaCombinationParameterValueBySearch(searchRequest);
                else
                {
                    FeeCriteriaCombinationParameterValueCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeCriteriaCombinationParameterValueCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeCriteriaCombinationParameterValueCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeCriteriaCombinationParameterValueCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeCriteriaCombinationParameterValueCollection;
        }
        /// <summary>
        /// Select a record from FeeCriteriaCombinationParameterValue table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaCombinationParameterValue> SelectByID(FeeCriteriaCombinationParameterValue item)
        {
            IBaseEntityResponse<FeeCriteriaCombinationParameterValue> entityResponse = new BaseEntityResponse<FeeCriteriaCombinationParameterValue>();
            try
            {
                entityResponse = _feeCriteriaCombinationParameterValueDataProvider.GetFeeCriteriaCombinationParameterValueByID(item);
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

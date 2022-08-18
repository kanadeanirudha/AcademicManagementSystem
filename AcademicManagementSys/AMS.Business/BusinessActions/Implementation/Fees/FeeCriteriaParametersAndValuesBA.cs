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
    public class FeeCriteriaParametersAndValuesBA : IFeeCriteriaParametersAndValuesBA
    {
        IFeeCriteriaParametersAndValuesDataProvider _feeCriteriaParametersAndValuesDataProvider;
        IFeeCriteriaParametersAndValuesBR _feeCriteriaParametersAndValuesBR;
        private ILogger _logException;
        public FeeCriteriaParametersAndValuesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _feeCriteriaParametersAndValuesBR = new FeeCriteriaParametersAndValuesBR();
            _feeCriteriaParametersAndValuesDataProvider = new FeeCriteriaParametersAndValuesDataProvider();
        }
        /// <summary>
        /// Create new record of FeeCriteriaParametersAndValues.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> InsertFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> entityResponse = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaParametersAndValuesBR.InsertFeeCriteriaParametersAndValuesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaParametersAndValuesDataProvider.InsertFeeCriteriaParametersAndValues(item);
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
        /// Update a specific record  of FeeCriteriaParametersAndValues.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> UpdateFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> entityResponse = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaParametersAndValuesBR.UpdateFeeCriteriaParametersAndValuesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaParametersAndValuesDataProvider.UpdateFeeCriteriaParametersAndValues(item);
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
        /// Delete a selected record from FeeCriteriaParametersAndValues.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> DeleteFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> entityResponse = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _feeCriteriaParametersAndValuesBR.DeleteFeeCriteriaParametersAndValuesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _feeCriteriaParametersAndValuesDataProvider.DeleteFeeCriteriaParametersAndValues(item);
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
        /// Select all record from FeeCriteriaParametersAndValues table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetBySearch(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> FeeCriteriaParametersAndValuesCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
            try
            {
                if (_feeCriteriaParametersAndValuesDataProvider != null)
                    FeeCriteriaParametersAndValuesCollection = _feeCriteriaParametersAndValuesDataProvider.GetFeeCriteriaParametersAndValuesBySearch(searchRequest);
                else
                {
                    FeeCriteriaParametersAndValuesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeCriteriaParametersAndValuesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeCriteriaParametersAndValuesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeCriteriaParametersAndValuesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeCriteriaParametersAndValuesCollection;
        }

        /// <summary>
        /// Select all record from FeeCriteriaParametersAndValues table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> SearchList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> FeeCriteriaParametersAndValuesCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
            try
            {
                if (_feeCriteriaParametersAndValuesDataProvider != null)
                    FeeCriteriaParametersAndValuesCollection = _feeCriteriaParametersAndValuesDataProvider.SearchList(searchRequest);
                else
                {
                    FeeCriteriaParametersAndValuesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeCriteriaParametersAndValuesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeCriteriaParametersAndValuesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeCriteriaParametersAndValuesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeCriteriaParametersAndValuesCollection;
        }
        /// <summary>
        /// Select a record from FeeCriteriaParametersAndValues table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> SelectByID(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> entityResponse = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
            try
            {
                entityResponse = _feeCriteriaParametersAndValuesDataProvider.GetFeeCriteriaParametersAndValuesByID(item);
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

        //List of FeePredefinedCriteriaParameters
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> criteriaCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_feeCriteriaParametersAndValuesDataProvider != null)
                    criteriaCollection = _feeCriteriaParametersAndValuesDataProvider.GetFeePredefinedCriteriaParametersList(searchRequest);
                else
                {
                    criteriaCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    criteriaCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                criteriaCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                criteriaCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return criteriaCollection;
        }

        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetPredefinedCriteriaParametersValueList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> feeCriteriaParametersValuesCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
            try
            {
                if (_feeCriteriaParametersAndValuesDataProvider != null)
                    feeCriteriaParametersValuesCollection = _feeCriteriaParametersAndValuesDataProvider.GetPredefinedCriteriaParametersValueList(searchRequest);
                else
                {
                    feeCriteriaParametersValuesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    feeCriteriaParametersValuesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                feeCriteriaParametersValuesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                feeCriteriaParametersValuesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return feeCriteriaParametersValuesCollection;
        }

    }
}

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
    public class FeePredefinedCriteriaParametersBA : IFeePredefinedCriteriaParametersBA
    {
        IFeePredefinedCriteriaParametersDataProvider _FeePredefinedCriteriaParametersDataProvider;
        IFeePredefinedCriteriaParametersBR _FeePredefinedCriteriaParametersBR;
        private ILogger _logException;
        public FeePredefinedCriteriaParametersBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _FeePredefinedCriteriaParametersBR = new FeePredefinedCriteriaParametersBR();
            _FeePredefinedCriteriaParametersDataProvider = new FeePredefinedCriteriaParametersDataProvider();
        }
        /// <summary>
        /// Create new record of FeePredefinedCriteriaParameters.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> InsertFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            IBaseEntityResponse<FeePredefinedCriteriaParameters> entityResponse = new BaseEntityResponse<FeePredefinedCriteriaParameters>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeePredefinedCriteriaParametersBR.InsertFeePredefinedCriteriaParametersValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeePredefinedCriteriaParametersDataProvider.InsertFeePredefinedCriteriaParameters(item);
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
        /// Update a specific record  of FeePredefinedCriteriaParameters.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> UpdateFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            IBaseEntityResponse<FeePredefinedCriteriaParameters> entityResponse = new BaseEntityResponse<FeePredefinedCriteriaParameters>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeePredefinedCriteriaParametersBR.UpdateFeePredefinedCriteriaParametersValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeePredefinedCriteriaParametersDataProvider.UpdateFeePredefinedCriteriaParameters(item);
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
        /// Delete a selected record from FeePredefinedCriteriaParameters.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeePredefinedCriteriaParameters> DeleteFeePredefinedCriteriaParameters(FeePredefinedCriteriaParameters item)
        {
            IBaseEntityResponse<FeePredefinedCriteriaParameters> entityResponse = new BaseEntityResponse<FeePredefinedCriteriaParameters>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeePredefinedCriteriaParametersBR.DeleteFeePredefinedCriteriaParametersValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeePredefinedCriteriaParametersDataProvider.DeleteFeePredefinedCriteriaParameters(item);
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
        /// Select all record from FeePredefinedCriteriaParameters table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetBySearch(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> FeePredefinedCriteriaParametersCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_FeePredefinedCriteriaParametersDataProvider != null)
                    FeePredefinedCriteriaParametersCollection = _FeePredefinedCriteriaParametersDataProvider.GetFeePredefinedCriteriaParametersBySearch(searchRequest);
                else
                {
                    FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeePredefinedCriteriaParametersCollection;
        }

        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> FeePredefinedCriteriaParametersCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_FeePredefinedCriteriaParametersDataProvider != null)
                    FeePredefinedCriteriaParametersCollection = _FeePredefinedCriteriaParametersDataProvider.GetFeePredefinedCriteriaParametersList(searchRequest);
                else
                {
                    FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeePredefinedCriteriaParametersCollection;
        }
        /// <summary>
        /// Select a record from FeePredefinedCriteriaParameters table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetTableEntityNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> FeePredefinedCriteriaParametersCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_FeePredefinedCriteriaParametersDataProvider != null)
                    FeePredefinedCriteriaParametersCollection = _FeePredefinedCriteriaParametersDataProvider.GetTableEntityNameList(searchRequest);
                else
                {
                    FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeePredefinedCriteriaParametersCollection;
        }

        /// <summary>
        ///  Select all record from FeePredefinedCriteriaParameters table with search parameters.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetPrimaryKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> FeePredefinedCriteriaParametersCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_FeePredefinedCriteriaParametersDataProvider != null)
                    FeePredefinedCriteriaParametersCollection = _FeePredefinedCriteriaParametersDataProvider.GetPrimaryKeyFieldNameList(searchRequest);
                else
                {
                    FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeePredefinedCriteriaParametersCollection;
        }

        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetDisplayKeyFieldNameList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> FeePredefinedCriteriaParametersCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
            try
            {
                if (_FeePredefinedCriteriaParametersDataProvider != null)
                    FeePredefinedCriteriaParametersCollection = _FeePredefinedCriteriaParametersDataProvider.GetDisplayKeyFieldNameList(searchRequest);
                else
                {
                    FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeePredefinedCriteriaParametersCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeePredefinedCriteriaParametersCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeePredefinedCriteriaParametersCollection;
        }





        public IBaseEntityResponse<FeePredefinedCriteriaParameters> SelectByID(FeePredefinedCriteriaParameters item)
        {
            IBaseEntityResponse<FeePredefinedCriteriaParameters> entityResponse = new BaseEntityResponse<FeePredefinedCriteriaParameters>();
            try
            {
                entityResponse = _FeePredefinedCriteriaParametersDataProvider.GetFeePredefinedCriteriaParametersByID(item);
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

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
    public class CRMCallMasterAndDetailsBA : ICRMCallMasterAndDetailsBA
    {
        ICRMCallMasterAndDetailsDataProvider _CRMCallMasterAndDetailsDataProvider;
        ICRMCallMasterAndDetailsBR _CRMCallMasterAndDetailsBR;
        private ILogger _logException;

        public CRMCallMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CRMCallMasterAndDetailsBR = new CRMCallMasterAndDetailsBR();
            _CRMCallMasterAndDetailsDataProvider = new CRMCallMasterAndDetailsDataProvider();
        }

        /// <summary>
        /// Create new record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> InsertCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallMasterAndDetailsBR.InsertCRMCallMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallMasterAndDetailsDataProvider.InsertCRMCallMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> UpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallMasterAndDetailsBR.UpdateCRMCallMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallMasterAndDetailsDataProvider.UpdateCRMCallMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> DeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CRMCallMasterAndDetailsBR.DeleteCRMCallMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CRMCallMasterAndDetailsDataProvider.DeleteCRMCallMasterAndDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from CRMCallMasterAndDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearch(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> categoryMasterCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
            try
            {
                if (_CRMCallMasterAndDetailsDataProvider != null)
                {
                    categoryMasterCollection = _CRMCallMasterAndDetailsDataProvider.GetCRMCallMasterAndDetailsBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from CRMCallMasterAndDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearchList(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> categoryMasterCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
            try
            {
                if (_CRMCallMasterAndDetailsDataProvider != null)
                {
                    categoryMasterCollection = _CRMCallMasterAndDetailsDataProvider.GetCRMCallMasterAndDetailsGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from CRMCallMasterAndDetails table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> SelectByID(CRMCallMasterAndDetails item)
        {

            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                entityResponse = _CRMCallMasterAndDetailsDataProvider.GetCRMCallMasterAndDetailsByID(item);
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

        public IBaseEntityResponse<CRMCallMasterAndDetails> SelectByJobAllocationID(CRMCallMasterAndDetails item)
        {

            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                entityResponse = _CRMCallMasterAndDetailsDataProvider.SelectByJobAllocationID(item);
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

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CallerConvertedReportForTable(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> categoryMasterCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
            try
            {
                if (_CRMCallMasterAndDetailsDataProvider != null)
                {
                    categoryMasterCollection = _CRMCallMasterAndDetailsDataProvider.CallerConvertedReportForTable(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CRMMarketingEffectivenessReport(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> categoryMasterCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
            try
            {
                if (_CRMCallMasterAndDetailsDataProvider != null)
                {
                    categoryMasterCollection = _CRMCallMasterAndDetailsDataProvider.CRMMarketingEffectivenessReport(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        public IBaseEntityResponse<CRMCallMasterAndDetails> GetStudentStatusDetailsByCalleeMasterID(CRMCallMasterAndDetails item)
        {

            IBaseEntityResponse<CRMCallMasterAndDetails> entityResponse = new BaseEntityResponse<CRMCallMasterAndDetails>();
            try
            {
                entityResponse = _CRMCallMasterAndDetailsDataProvider.GetStudentStatusDetailsByCalleeMasterID(item);
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
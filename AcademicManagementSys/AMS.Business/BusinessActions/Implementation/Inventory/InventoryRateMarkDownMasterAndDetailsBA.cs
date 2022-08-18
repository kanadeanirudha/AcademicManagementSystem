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
    public class InventoryRateMarkDownMasterAndDetailsBA : IInventoryRateMarkDownMasterAndDetailsBA
    {
        IInventoryRateMarkDownMasterAndDetailsDataProvider _InventoryRateMarkDownMasterAndDetailsDataProvider;
        IInventoryRateMarkDownMasterAndDetailsBR _InventoryRateMarkDownMasterAndDetailsBR;
        private ILogger _logException;
        public InventoryRateMarkDownMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryRateMarkDownMasterAndDetailsBR = new InventoryRateMarkDownMasterAndDetailsBR();
            _InventoryRateMarkDownMasterAndDetailsDataProvider = new InventoryRateMarkDownMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> InsertInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRateMarkDownMasterAndDetailsBR.InsertInventoryRateMarkDownMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRateMarkDownMasterAndDetailsDataProvider.InsertInventoryRateMarkDownMasterAndDetails(item);
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
        /// Update a specific record  of InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> UpdateInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRateMarkDownMasterAndDetailsBR.UpdateInventoryRateMarkDownMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRateMarkDownMasterAndDetailsDataProvider.UpdateInventoryRateMarkDownMasterAndDetails(item);
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
        /// Delete a selected record from InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> DeleteInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRateMarkDownMasterAndDetailsBR.DeleteInventoryRateMarkDownMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRateMarkDownMasterAndDetailsDataProvider.DeleteInventoryRateMarkDownMasterAndDetails(item);
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
        /// Select all record from InventoryRateMarkDownMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetBySearch(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> InventoryRateMarkDownMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                if (_InventoryRateMarkDownMasterAndDetailsDataProvider != null)
                    InventoryRateMarkDownMasterAndDetailsCollection = _InventoryRateMarkDownMasterAndDetailsDataProvider.GetInventoryRateMarkDownMasterAndDetailsBySearch(searchRequest);
                else
                {
                    InventoryRateMarkDownMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRateMarkDownMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRateMarkDownMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRateMarkDownMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRateMarkDownMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> GetInventoryRateMarkDownMasterAndDetailsList(InventoryRateMarkDownMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails> InventoryRateMarkDownMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                if (_InventoryRateMarkDownMasterAndDetailsDataProvider != null)
                    InventoryRateMarkDownMasterAndDetailsCollection = _InventoryRateMarkDownMasterAndDetailsDataProvider.GetInventoryRateMarkDownMasterAndDetailsList(searchRequest);
                else
                {
                    InventoryRateMarkDownMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRateMarkDownMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRateMarkDownMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRateMarkDownMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRateMarkDownMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryRateMarkDownMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> SelectByID(InventoryRateMarkDownMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryRateMarkDownMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryRateMarkDownMasterAndDetails>();
            try
            {
                entityResponse = _InventoryRateMarkDownMasterAndDetailsDataProvider.GetInventoryRateMarkDownMasterAndDetailsByID(item);
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

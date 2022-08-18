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
    public class InventoryIssueMasterAndDetailsBA : IInventoryIssueMasterAndDetailsBA
    {
        IInventoryIssueMasterAndDetailsDataProvider _InventoryIssueMasterAndDetailsDataProvider;
        IInventoryIssueMasterAndDetailsBR _InventoryIssueMasterAndDetailsBR;
        private ILogger _logException;
        public InventoryIssueMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryIssueMasterAndDetailsBR = new InventoryIssueMasterAndDetailsBR();
            _InventoryIssueMasterAndDetailsDataProvider = new InventoryIssueMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryIssueMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryIssueMasterAndDetails> InsertInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryIssueMasterAndDetailsBR.InsertInventoryIssueMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryIssueMasterAndDetailsDataProvider.InsertInventoryIssueMasterAndDetails(item);
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
        /// Update a specific record  of InventoryIssueMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryIssueMasterAndDetails> UpdateInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryIssueMasterAndDetailsBR.UpdateInventoryIssueMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryIssueMasterAndDetailsDataProvider.UpdateInventoryIssueMasterAndDetails(item);
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
        /// Delete a selected record from InventoryIssueMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryIssueMasterAndDetails> DeleteInventoryIssueMasterAndDetails(InventoryIssueMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryIssueMasterAndDetailsBR.DeleteInventoryIssueMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryIssueMasterAndDetailsDataProvider.DeleteInventoryIssueMasterAndDetails(item);
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
        /// Select all record from InventoryIssueMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> GetBySearch(InventoryIssueMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndDetails> InventoryIssueMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndDetails>();
            try
            {
                if (_InventoryIssueMasterAndDetailsDataProvider != null)
                    InventoryIssueMasterAndDetailsCollection = _InventoryIssueMasterAndDetailsDataProvider.GetInventoryIssueMasterAndDetailsBySearch(searchRequest);
                else
                {
                    InventoryIssueMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryIssueMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryIssueMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryIssueMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryIssueMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryIssueMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryIssueMasterAndDetails> SelectByID(InventoryIssueMasterAndDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndDetails>();
            try
            {
                entityResponse = _InventoryIssueMasterAndDetailsDataProvider.GetInventoryIssueMasterAndDetailsByID(item);
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

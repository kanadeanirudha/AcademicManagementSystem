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
    public class InventoryCounterApplicableDetailsBA : IInventoryCounterApplicableDetailsBA
    {
        IInventoryCounterApplicableDetailsDataProvider _InventoryCounterApplicableDetailsDataProvider;
        IInventoryCounterApplicableDetailsBR _InventoryCounterApplicableDetailsBR;
        private ILogger _logException;
        public InventoryCounterApplicableDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryCounterApplicableDetailsBR = new InventoryCounterApplicableDetailsBR();
            _InventoryCounterApplicableDetailsDataProvider = new InventoryCounterApplicableDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryCounterApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterApplicableDetails> InsertInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            IBaseEntityResponse<InventoryCounterApplicableDetails> entityResponse = new BaseEntityResponse<InventoryCounterApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterApplicableDetailsBR.InsertInventoryCounterApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterApplicableDetailsDataProvider.InsertInventoryCounterApplicableDetails(item);
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
        /// Update a specific record  of InventoryCounterApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterApplicableDetails> UpdateInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            IBaseEntityResponse<InventoryCounterApplicableDetails> entityResponse = new BaseEntityResponse<InventoryCounterApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterApplicableDetailsBR.UpdateInventoryCounterApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterApplicableDetailsDataProvider.UpdateInventoryCounterApplicableDetails(item);
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
        /// Delete a selected record from InventoryCounterApplicableDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterApplicableDetails> DeleteInventoryCounterApplicableDetails(InventoryCounterApplicableDetails item)
        {
            IBaseEntityResponse<InventoryCounterApplicableDetails> entityResponse = new BaseEntityResponse<InventoryCounterApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterApplicableDetailsBR.DeleteInventoryCounterApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterApplicableDetailsDataProvider.DeleteInventoryCounterApplicableDetails(item);
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
        /// Select all record from InventoryCounterApplicableDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetBySearch(InventoryCounterApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> InventoryCounterApplicableDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterApplicableDetails>();
            try
            {
                if (_InventoryCounterApplicableDetailsDataProvider != null)
                    InventoryCounterApplicableDetailsCollection = _InventoryCounterApplicableDetailsDataProvider.GetInventoryCounterApplicableDetailsBySearch(searchRequest);
                else
                {
                    InventoryCounterApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterApplicableDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> GetInventoryCounterApplicableDetailsList(InventoryCounterApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterApplicableDetails> InventoryCounterApplicableDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterApplicableDetails>();
            try
            {
                if (_InventoryCounterApplicableDetailsDataProvider != null)
                    InventoryCounterApplicableDetailsCollection = _InventoryCounterApplicableDetailsDataProvider.GetInventoryCounterApplicableDetailsList(searchRequest);
                else
                {
                    InventoryCounterApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterApplicableDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterApplicableDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryCounterApplicableDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterApplicableDetails> SelectByID(InventoryCounterApplicableDetails item)
        {
            IBaseEntityResponse<InventoryCounterApplicableDetails> entityResponse = new BaseEntityResponse<InventoryCounterApplicableDetails>();
            try
            {
                entityResponse = _InventoryCounterApplicableDetailsDataProvider.GetInventoryCounterApplicableDetailsByID(item);
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

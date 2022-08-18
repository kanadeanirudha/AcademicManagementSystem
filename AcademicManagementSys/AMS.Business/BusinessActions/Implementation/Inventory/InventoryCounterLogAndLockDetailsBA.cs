

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
    public class InventoryCounterLogAndLockDetailsBA : IInventoryCounterLogAndLockDetailsBA
    {
        IInventoryCounterLogAndLockDetailsDataProvider _InventoryCounterLogAndLockDetailsDataProvider;
        IInventoryCounterLogAndLockDetailsBR _InventoryCounterLogAndLockDetailsBR;
        private ILogger _logException;
        public InventoryCounterLogAndLockDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryCounterLogAndLockDetailsBR = new InventoryCounterLogAndLockDetailsBR();
            _InventoryCounterLogAndLockDetailsDataProvider = new InventoryCounterLogAndLockDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryCounterLogAndLockDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> InsertInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> entityResponse = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterLogAndLockDetailsBR.InsertInventoryCounterLogAndLockDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterLogAndLockDetailsDataProvider.InsertInventoryCounterLogAndLockDetails(item);
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
        /// Update a specific record  of InventoryCounterLogAndLockDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> UpdateInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> entityResponse = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterLogAndLockDetailsBR.UpdateInventoryCounterLogAndLockDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterLogAndLockDetailsDataProvider.UpdateInventoryCounterLogAndLockDetails(item);
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
        /// Delete a selected record from InventoryCounterLogAndLockDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> DeleteInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> entityResponse = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterLogAndLockDetailsBR.DeleteInventoryCounterLogAndLockDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterLogAndLockDetailsDataProvider.DeleteInventoryCounterLogAndLockDetails(item);
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
        /// Select all record from InventoryCounterLogAndLockDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetBySearch(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> InventoryCounterLogAndLockDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                if (_InventoryCounterLogAndLockDetailsDataProvider != null)
                    InventoryCounterLogAndLockDetailsCollection = _InventoryCounterLogAndLockDetailsDataProvider.GetInventoryCounterLogAndLockDetailsBySearch(searchRequest);
                else
                {
                    InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterLogAndLockDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsList(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> InventoryCounterLogAndLockDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                if (_InventoryCounterLogAndLockDetailsDataProvider != null)
                    InventoryCounterLogAndLockDetailsCollection = _InventoryCounterLogAndLockDetailsDataProvider.GetInventoryCounterLogAndLockDetailsList(searchRequest);
                else
                {
                    InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterLogAndLockDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryCounterLogAndLockDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> SelectByID(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> entityResponse = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                entityResponse = _InventoryCounterLogAndLockDetailsDataProvider.GetInventoryCounterLogAndLockDetailsByID(item);
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

        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLockStatus(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> InventoryCounterLogAndLockDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                if (_InventoryCounterLogAndLockDetailsDataProvider != null)
                    InventoryCounterLogAndLockDetailsCollection = _InventoryCounterLogAndLockDetailsDataProvider.GetInventoryCounterLockStatus(searchRequest);
                else
                {
                    InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterLogAndLockDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> InventoryCounterLogAndLockDetailsCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
            try
            {
                if (_InventoryCounterLogAndLockDetailsDataProvider != null)
                    InventoryCounterLogAndLockDetailsCollection = _InventoryCounterLogAndLockDetailsDataProvider.GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(searchRequest);
                else
                {
                    InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterLogAndLockDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterLogAndLockDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterLogAndLockDetailsCollection;
        }
      
    }
}

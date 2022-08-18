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
    public class InventoryPurchaseMasterAndTransactionBA : IInventoryPurchaseMasterAndTransactionBA
    {
        IInventoryPurchaseMasterAndTransactionDataProvider _InventoryPurchaseMasterAndTransactionDataProvider;
        IInventoryPurchaseMasterAndTransactionBR _InventoryPurchaseMasterAndTransactionBR;
        private ILogger _logException;
        public InventoryPurchaseMasterAndTransactionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryPurchaseMasterAndTransactionBR = new InventoryPurchaseMasterAndTransactionBR();
            _InventoryPurchaseMasterAndTransactionDataProvider = new InventoryPurchaseMasterAndTransactionDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryPurchaseMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> InsertInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPurchaseMasterAndTransactionBR.InsertInventoryPurchaseMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPurchaseMasterAndTransactionDataProvider.InsertInventoryPurchaseMasterAndTransaction(item);
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
        /// Update a specific record  of InventoryPurchaseMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> UpdateInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPurchaseMasterAndTransactionBR.UpdateInventoryPurchaseMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPurchaseMasterAndTransactionDataProvider.UpdateInventoryPurchaseMasterAndTransaction(item);
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
        /// Delete a selected record from InventoryPurchaseMasterAndTransaction.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> DeleteInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryPurchaseMasterAndTransactionBR.DeleteInventoryPurchaseMasterAndTransactionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryPurchaseMasterAndTransactionDataProvider.DeleteInventoryPurchaseMasterAndTransaction(item);
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
        /// Select all record from InventoryPurchaseMasterAndTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetBySearch(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> InventoryPurchaseMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                if (_InventoryPurchaseMasterAndTransactionDataProvider != null)
                    InventoryPurchaseMasterAndTransactionCollection = _InventoryPurchaseMasterAndTransactionDataProvider.GetInventoryPurchaseMasterAndTransactionBySearch(searchRequest);
                else
                {
                    InventoryPurchaseMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryPurchaseMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryPurchaseMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryPurchaseMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryPurchaseMasterAndTransactionCollection;
        }
        /// <summary>
        /// Select a record from InventoryPurchaseMasterAndTransaction table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> SelectByID(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                entityResponse = _InventoryPurchaseMasterAndTransactionDataProvider.GetInventoryPurchaseMasterAndTransactionByID(item);
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

        public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> InventoryPurchaseMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                if (_InventoryPurchaseMasterAndTransactionDataProvider != null)
                    InventoryPurchaseMasterAndTransactionCollection = _InventoryPurchaseMasterAndTransactionDataProvider.GetPurchaseMasterAndTransaction(searchRequest);
                else
                {
                    InventoryPurchaseMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryPurchaseMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryPurchaseMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryPurchaseMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryPurchaseMasterAndTransactionCollection;
        }

        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> CheckFocusOnAction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> entityResponse = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
            try
            {
                entityResponse = _InventoryPurchaseMasterAndTransactionDataProvider.CheckFocusOnAction(item);
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

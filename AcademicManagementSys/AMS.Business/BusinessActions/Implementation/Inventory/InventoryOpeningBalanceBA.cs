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
    public class InventoryOpeningBalanceBA : IInventoryOpeningBalanceBA
    {
        IInventoryOpeningBalanceDataProvider _InventoryOpeningBalanceDataProvider;
        IInventoryOpeningBalanceBR _InventoryOpeningBalanceBR;
        private ILogger _logException;
        public InventoryOpeningBalanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryOpeningBalanceBR = new InventoryOpeningBalanceBR();
            _InventoryOpeningBalanceDataProvider = new InventoryOpeningBalanceDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryOpeningBalance> InsertInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            IBaseEntityResponse<InventoryOpeningBalance> entityResponse = new BaseEntityResponse<InventoryOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryOpeningBalanceBR.InsertInventoryOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryOpeningBalanceDataProvider.InsertInventoryOpeningBalance(item);
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
        /// Update a specific record  of InventoryOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryOpeningBalance> UpdateInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            IBaseEntityResponse<InventoryOpeningBalance> entityResponse = new BaseEntityResponse<InventoryOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryOpeningBalanceBR.UpdateInventoryOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryOpeningBalanceDataProvider.UpdateInventoryOpeningBalance(item);
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
        /// Delete a selected record from InventoryOpeningBalance.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryOpeningBalance> DeleteInventoryOpeningBalance(InventoryOpeningBalance item)
        {
            IBaseEntityResponse<InventoryOpeningBalance> entityResponse = new BaseEntityResponse<InventoryOpeningBalance>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryOpeningBalanceBR.DeleteInventoryOpeningBalanceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryOpeningBalanceDataProvider.DeleteInventoryOpeningBalance(item);
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
        /// Select all record from InventoryOpeningBalance table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryOpeningBalance> GetBySearch(InventoryOpeningBalanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryOpeningBalance> InventoryOpeningBalanceCollection = new BaseEntityCollectionResponse<InventoryOpeningBalance>();
            try
            {
                if (_InventoryOpeningBalanceDataProvider != null)
                    InventoryOpeningBalanceCollection = _InventoryOpeningBalanceDataProvider.GetInventoryOpeningBalanceBySearch(searchRequest);
                else
                {
                    InventoryOpeningBalanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryOpeningBalanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryOpeningBalanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryOpeningBalanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryOpeningBalanceCollection;
        }

        public IBaseEntityCollectionResponse<InventoryOpeningBalance> GetInventoryOpeningBalanceList(InventoryOpeningBalanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryOpeningBalance> InventoryOpeningBalanceCollection = new BaseEntityCollectionResponse<InventoryOpeningBalance>();
            try
            {
                if (_InventoryOpeningBalanceDataProvider != null)
                    InventoryOpeningBalanceCollection = _InventoryOpeningBalanceDataProvider.GetInventoryOpeningBalanceList(searchRequest);
                else
                {
                    InventoryOpeningBalanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryOpeningBalanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryOpeningBalanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryOpeningBalanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryOpeningBalanceCollection;
        }
        /// <summary>
        /// Select a record from InventoryOpeningBalance table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryOpeningBalance> SelectByID(InventoryOpeningBalance item)
        {
            IBaseEntityResponse<InventoryOpeningBalance> entityResponse = new BaseEntityResponse<InventoryOpeningBalance>();
            try
            {
                entityResponse = _InventoryOpeningBalanceDataProvider.GetInventoryOpeningBalanceByID(item);
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

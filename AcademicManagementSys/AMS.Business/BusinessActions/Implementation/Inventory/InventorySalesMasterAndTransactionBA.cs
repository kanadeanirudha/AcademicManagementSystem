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
    public class InventorySalesMasterAndTransactionBA : IInventorySalesMasterAndTransactionBA
    {
		IInventorySalesMasterAndTransactionDataProvider _InventorySalesMasterAndTransactionDataProvider;
		IInventorySalesMasterAndTransactionBR _InventorySalesMasterAndTransactionBR;
		private ILogger _logException;
		public InventorySalesMasterAndTransactionBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_InventorySalesMasterAndTransactionBR = new InventorySalesMasterAndTransactionBR();
			_InventorySalesMasterAndTransactionDataProvider = new InventorySalesMasterAndTransactionDataProvider();
		}
		/// <summary>
		/// Create new record of InventorySalesMasterAndTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventorySalesMasterAndTransactionBR.InsertInventorySalesMasterAndTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventorySalesMasterAndTransactionDataProvider.InsertInventorySalesMasterAndTransaction(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Create new record of InventorySalesMasterAndTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventoryHoldBill(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventorySalesMasterAndTransactionBR.InsertInventorySalesMasterAndTransactionValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _InventorySalesMasterAndTransactionDataProvider.InsertInventoryHoldBill(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Update a specific record  of InventorySalesMasterAndTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> UpdateInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventorySalesMasterAndTransactionBR.UpdateInventorySalesMasterAndTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventorySalesMasterAndTransactionDataProvider.UpdateInventorySalesMasterAndTransaction(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Delete a selected record from InventorySalesMasterAndTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> DeleteInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventorySalesMasterAndTransactionBR.DeleteInventorySalesMasterAndTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventorySalesMasterAndTransactionDataProvider.DeleteInventorySalesMasterAndTransaction(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Select all record from InventorySalesMasterAndTransaction table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBySearch(InventorySalesMasterAndTransactionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> InventorySalesMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
			try
			{
				if (_InventorySalesMasterAndTransactionDataProvider != null)
				InventorySalesMasterAndTransactionCollection = _InventorySalesMasterAndTransactionDataProvider.GetInventorySalesMasterAndTransactionBySearch(searchRequest);
				else
				{
					InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventorySalesMasterAndTransactionCollection;
		}
		/// <summary>
		/// Select all record from InventorySalesMasterAndTransaction table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBillDetailsByID(InventorySalesMasterAndTransactionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> InventorySalesMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
			try
			{
				if (_InventorySalesMasterAndTransactionDataProvider != null)
                    InventorySalesMasterAndTransactionCollection = _InventorySalesMasterAndTransactionDataProvider.GetBillDetailsByID(searchRequest);
				else
				{
					InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventorySalesMasterAndTransactionCollection;
		}        
		/// <summary>
		/// Select a record from InventorySalesMasterAndTransaction table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectByID(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
				 entityResponse = _InventorySalesMasterAndTransactionDataProvider.GetInventorySalesMasterAndTransactionByID(item);
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
		/// Select a record from InventorySalesMasterAndTransaction table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectHoldBillCount(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
                entityResponse = _InventorySalesMasterAndTransactionDataProvider.SelectHoldBillCount(item);
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
		/// Select a record from InventorySalesMasterAndTransaction table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> GetInventoryItemQuantity(InventorySalesMasterAndTransaction item)
		{
			IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
			try
			{
                entityResponse = _InventorySalesMasterAndTransactionDataProvider.GetInventoryItemQuantity(item);
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

        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionBillPrintList(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> InventorySalesMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
            try
            {
                if (_InventorySalesMasterAndTransactionDataProvider != null)
                    InventorySalesMasterAndTransactionCollection = _InventorySalesMasterAndTransactionDataProvider.GetInventorySalesMasterAndTransactionBillPrintList(searchRequest);
                else
                {
                    InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventorySalesMasterAndTransactionCollection;
        }

        //For Inventory Sale Report To operator

        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesReportToOperator(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> InventorySalesMasterAndTransactionCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
            try
            {
                if (_InventorySalesMasterAndTransactionDataProvider != null)
                    InventorySalesMasterAndTransactionCollection = _InventorySalesMasterAndTransactionDataProvider.GetInventorySalesReportToOperator(searchRequest);
                else
                {
                    InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventorySalesMasterAndTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventorySalesMasterAndTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventorySalesMasterAndTransactionCollection;
        }

        public IBaseEntityResponse<InventorySalesMasterAndTransaction> CheckFocusOnAction(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> entityResponse = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
            try
            {
                entityResponse = _InventorySalesMasterAndTransactionDataProvider.CheckFocusOnAction(item);
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

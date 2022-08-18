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
    public class InventoryDatewiseItemTransactionBA : IInventoryDatewiseItemTransactionBA
    {
		IInventoryDatewiseItemTransactionDataProvider _InventoryDatewiseItemTransactionDataProvider;
		IInventoryDatewiseItemTransactionBR _InventoryDatewiseItemTransactionBR;
		private ILogger _logException;
		public InventoryDatewiseItemTransactionBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_InventoryDatewiseItemTransactionBR = new InventoryDatewiseItemTransactionBR();
			_InventoryDatewiseItemTransactionDataProvider = new InventoryDatewiseItemTransactionDataProvider();
		}
		/// <summary>
		/// Create new record of InventoryDatewiseItemTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> InsertInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			IBaseEntityResponse<InventoryDatewiseItemTransaction> entityResponse = new BaseEntityResponse<InventoryDatewiseItemTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDatewiseItemTransactionBR.InsertInventoryDatewiseItemTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDatewiseItemTransactionDataProvider.InsertInventoryDatewiseItemTransaction(item);
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
		/// Update a specific record  of InventoryDatewiseItemTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> UpdateInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			IBaseEntityResponse<InventoryDatewiseItemTransaction> entityResponse = new BaseEntityResponse<InventoryDatewiseItemTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDatewiseItemTransactionBR.UpdateInventoryDatewiseItemTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDatewiseItemTransactionDataProvider.UpdateInventoryDatewiseItemTransaction(item);
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
		/// Delete a selected record from InventoryDatewiseItemTransaction.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> DeleteInventoryDatewiseItemTransaction(InventoryDatewiseItemTransaction item)
		{
			IBaseEntityResponse<InventoryDatewiseItemTransaction> entityResponse = new BaseEntityResponse<InventoryDatewiseItemTransaction>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDatewiseItemTransactionBR.DeleteInventoryDatewiseItemTransactionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDatewiseItemTransactionDataProvider.DeleteInventoryDatewiseItemTransaction(item);
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
		/// Select all record from InventoryDatewiseItemTransaction table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetBySearch(InventoryDatewiseItemTransactionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> InventoryDatewiseItemTransactionCollection = new BaseEntityCollectionResponse<InventoryDatewiseItemTransaction>();
			try
			{
				if (_InventoryDatewiseItemTransactionDataProvider != null)
				InventoryDatewiseItemTransactionCollection = _InventoryDatewiseItemTransactionDataProvider.GetInventoryDatewiseItemTransactionBySearch(searchRequest);
				else
				{
					InventoryDatewiseItemTransactionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryDatewiseItemTransactionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryDatewiseItemTransactionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryDatewiseItemTransactionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryDatewiseItemTransactionCollection;
		}
        /// <summary>
        /// Select all record from InventoryDatewiseItemTransaction table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> GetInventoryItemSearchList(InventoryDatewiseItemTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDatewiseItemTransaction> InventoryDatewiseItemTransactionCollection = new BaseEntityCollectionResponse<InventoryDatewiseItemTransaction>();
            try
            {
                if (_InventoryDatewiseItemTransactionDataProvider != null)
                    InventoryDatewiseItemTransactionCollection = _InventoryDatewiseItemTransactionDataProvider.GetInventoryItemSearchList(searchRequest);
                else
                {
                    InventoryDatewiseItemTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDatewiseItemTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDatewiseItemTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDatewiseItemTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDatewiseItemTransactionCollection;
        }
		/// <summary>
		/// Select a record from InventoryDatewiseItemTransaction table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDatewiseItemTransaction> SelectByID(InventoryDatewiseItemTransaction item)
		{
			IBaseEntityResponse<InventoryDatewiseItemTransaction> entityResponse = new BaseEntityResponse<InventoryDatewiseItemTransaction>();
			try
			{
				 entityResponse = _InventoryDatewiseItemTransactionDataProvider.GetInventoryDatewiseItemTransactionByID(item);
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

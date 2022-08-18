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
    public class InventoryDumpAndShrinkMasterAndDetailsBA : IInventoryDumpAndShrinkMasterAndDetailsBA
    {
		IInventoryDumpAndShrinkMasterAndDetailsDataProvider _InventoryDumpAndShrinkMasterAndDetailsDataProvider;
		IInventoryDumpAndShrinkMasterAndDetailsBR _InventoryDumpAndShrinkMasterAndDetailsBR;
		private ILogger _logException;
		public InventoryDumpAndShrinkMasterAndDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_InventoryDumpAndShrinkMasterAndDetailsBR = new InventoryDumpAndShrinkMasterAndDetailsBR();
			_InventoryDumpAndShrinkMasterAndDetailsDataProvider = new InventoryDumpAndShrinkMasterAndDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of InventoryDumpAndShrinkMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDumpAndShrinkMasterAndDetailsBR.InsertInventoryDumpAndShrinkMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.InsertInventoryDumpAndShrinkMasterAndDetails(item);
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
		/// Create new record of InventoryDumpAndShrinkMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertApprovedDumpAndShrinkRecord(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDumpAndShrinkMasterAndDetailsBR.InsertInventoryDumpAndShrinkMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.InsertApprovedDumpAndShrinkRecord(item);
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
		/// Update a specific record  of InventoryDumpAndShrinkMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> UpdateInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDumpAndShrinkMasterAndDetailsBR.UpdateInventoryDumpAndShrinkMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.UpdateInventoryDumpAndShrinkMasterAndDetails(item);
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
		/// Delete a selected record from InventoryDumpAndShrinkMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> DeleteInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryDumpAndShrinkMasterAndDetailsBR.DeleteInventoryDumpAndShrinkMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.DeleteInventoryDumpAndShrinkMasterAndDetails(item);
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
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetBySearch(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> InventoryDumpAndShrinkMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				if (_InventoryDumpAndShrinkMasterAndDetailsDataProvider != null)
				InventoryDumpAndShrinkMasterAndDetailsCollection = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.GetInventoryDumpAndShrinkMasterAndDetailsBySearch(searchRequest);
				else
				{
					InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryDumpAndShrinkMasterAndDetailsCollection;
		}
		/// <summary>
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> InventoryDumpAndShrinkMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				if (_InventoryDumpAndShrinkMasterAndDetailsDataProvider != null)
                    InventoryDumpAndShrinkMasterAndDetailsCollection = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.GetDumpAndShrinkDetails(searchRequest);
				else
				{
					InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryDumpAndShrinkMasterAndDetailsCollection;
		}        
		/// <summary>
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRequestForApproval(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> InventoryDumpAndShrinkMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				if (_InventoryDumpAndShrinkMasterAndDetailsDataProvider != null)
                    InventoryDumpAndShrinkMasterAndDetailsCollection = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.GetDumpAndShrinkRequestForApproval(searchRequest);
				else
				{
					InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryDumpAndShrinkMasterAndDetailsCollection;
		}                
		/// <summary>
		/// Select a record from InventoryDumpAndShrinkMasterAndDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> SelectByID(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
			try
			{
				 entityResponse = _InventoryDumpAndShrinkMasterAndDetailsDataProvider.GetInventoryDumpAndShrinkMasterAndDetailsByID(item);
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

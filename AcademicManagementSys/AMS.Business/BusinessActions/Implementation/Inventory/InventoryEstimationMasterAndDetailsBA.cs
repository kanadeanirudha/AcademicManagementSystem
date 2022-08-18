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
    public class InventoryEstimationMasterAndDetailsBA : IInventoryEstimationMasterAndDetailsBA
    {
		IInventoryEstimationMasterAndDetailsDataProvider _InventoryEstimationMasterAndDetailsDataProvider;
		IInventoryEstimationMasterAndDetailsBR _InventoryEstimationMasterAndDetailsBR;
		private ILogger _logException;
		public InventoryEstimationMasterAndDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_InventoryEstimationMasterAndDetailsBR = new InventoryEstimationMasterAndDetailsBR();
			_InventoryEstimationMasterAndDetailsDataProvider = new InventoryEstimationMasterAndDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryEstimationMasterAndDetailsBR.InsertInventoryEstimationMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryEstimationMasterAndDetailsDataProvider.InsertInventoryEstimationMasterAndDetails(item);
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
		/// Create new record of InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationToLocation(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryEstimationMasterAndDetailsBR.InsertInventoryEstimationMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _InventoryEstimationMasterAndDetailsDataProvider.InsertInventoryEstimationToLocation(item);
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
		/// Update a specific record  of InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> UpdateInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryEstimationMasterAndDetailsBR.UpdateInventoryEstimationMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryEstimationMasterAndDetailsDataProvider.UpdateInventoryEstimationMasterAndDetails(item);
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
		/// Delete a selected record from InventoryEstimationMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> DeleteInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> entityResponse = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryEstimationMasterAndDetailsBR.DeleteInventoryEstimationMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryEstimationMasterAndDetailsDataProvider.DeleteInventoryEstimationMasterAndDetails(item);
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
		/// Select all record from InventoryEstimationMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetBySearch(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> InventoryEstimationMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				if (_InventoryEstimationMasterAndDetailsDataProvider != null)
				InventoryEstimationMasterAndDetailsCollection = _InventoryEstimationMasterAndDetailsDataProvider.GetInventoryEstimationMasterAndDetailsBySearch(searchRequest);
				else
				{
					InventoryEstimationMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryEstimationMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryEstimationMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryEstimationMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryEstimationMasterAndDetailsCollection;
		}
		/// <summary>
		/// Select all record from InventoryEstimationMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> InventoryEstimationMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryEstimationMasterAndDetails>();
			try
			{
				if (_InventoryEstimationMasterAndDetailsDataProvider != null)
                    InventoryEstimationMasterAndDetailsCollection = _InventoryEstimationMasterAndDetailsDataProvider.GetInventoryEstimationMasterAndDetails(searchRequest);
				else
				{
					InventoryEstimationMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryEstimationMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryEstimationMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryEstimationMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryEstimationMasterAndDetailsCollection;
		}

    

       
    
    }
}

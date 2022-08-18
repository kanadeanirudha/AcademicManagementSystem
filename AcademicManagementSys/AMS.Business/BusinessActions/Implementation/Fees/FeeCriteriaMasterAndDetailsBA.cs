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
    public class FeeCriteriaMasterAndDetailsBA : IFeeCriteriaMasterAndDetailsBA
    {
		IFeeCriteriaMasterAndDetailsDataProvider _FeeCriteriaMasterAndDetailsDataProvider;
		IFeeCriteriaMasterAndDetailsBR _FeeCriteriaMasterAndDetailsBR;
		private ILogger _logException;
		public FeeCriteriaMasterAndDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_FeeCriteriaMasterAndDetailsBR = new FeeCriteriaMasterAndDetailsBR();
			_FeeCriteriaMasterAndDetailsDataProvider = new FeeCriteriaMasterAndDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> InsertFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			IBaseEntityResponse<FeeCriteriaMasterAndDetails> entityResponse = new BaseEntityResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeCriteriaMasterAndDetailsBR.InsertFeeCriteriaMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeCriteriaMasterAndDetailsDataProvider.InsertFeeCriteriaMasterAndDetails(item);
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
		/// Update a specific record  of FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> UpdateFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			IBaseEntityResponse<FeeCriteriaMasterAndDetails> entityResponse = new BaseEntityResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeCriteriaMasterAndDetailsBR.UpdateFeeCriteriaMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeCriteriaMasterAndDetailsDataProvider.UpdateFeeCriteriaMasterAndDetails(item);
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
		/// Delete a selected record from FeeCriteriaMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> DeleteFeeCriteriaMasterAndDetails(FeeCriteriaMasterAndDetails item)
		{
			IBaseEntityResponse<FeeCriteriaMasterAndDetails> entityResponse = new BaseEntityResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeCriteriaMasterAndDetailsBR.DeleteFeeCriteriaMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeCriteriaMasterAndDetailsDataProvider.DeleteFeeCriteriaMasterAndDetails(item);
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
		/// Select all record from FeeCriteriaMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetBySearch(FeeCriteriaMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> FeeCriteriaMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				if (_FeeCriteriaMasterAndDetailsDataProvider != null)
				FeeCriteriaMasterAndDetailsCollection = _FeeCriteriaMasterAndDetailsDataProvider.GetFeeCriteriaMasterAndDetailsBySearch(searchRequest);
				else
				{
					FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeCriteriaMasterAndDetailsCollection;
		}
		/// <summary>
		/// Select all record from FeeCriteriaMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeTypeList(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
            IBaseEntityCollectionResponse<FeeTypeAndSubType> FeeCriteriaMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
			try
			{
				if (_FeeCriteriaMasterAndDetailsDataProvider != null)
                    FeeCriteriaMasterAndDetailsCollection = _FeeCriteriaMasterAndDetailsDataProvider.GetFeeTypeList(searchRequest);
				else
				{
					FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeCriteriaMasterAndDetailsCollection;
		}        
		/// <summary>
		/// Select all record from FeeCriteriaMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> GetCriteriaMasterList(FeeCriteriaMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeCriteriaMasterAndDetails> FeeCriteriaMasterAndDetailsCollection = new BaseEntityCollectionResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				if (_FeeCriteriaMasterAndDetailsDataProvider != null)
                    FeeCriteriaMasterAndDetailsCollection = _FeeCriteriaMasterAndDetailsDataProvider.GetCriteriaMasterList(searchRequest);
				else
				{
					FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeCriteriaMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeCriteriaMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeCriteriaMasterAndDetailsCollection;
		}        
		/// <summary>
		/// Select a record from FeeCriteriaMasterAndDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeCriteriaMasterAndDetails> SelectByID(FeeCriteriaMasterAndDetails item)
		{
			IBaseEntityResponse<FeeCriteriaMasterAndDetails> entityResponse = new BaseEntityResponse<FeeCriteriaMasterAndDetails>();
			try
			{
				 entityResponse = _FeeCriteriaMasterAndDetailsDataProvider.GetFeeCriteriaMasterAndDetailsByID(item);
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

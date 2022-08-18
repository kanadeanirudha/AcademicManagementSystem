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
    public class FeeTypeAndSubTypeBA : IFeeTypeAndSubTypeBA
    {
		IFeeTypeAndSubTypeDataProvider _FeeTypeAndSubTypeDataProvider;
		IFeeTypeAndSubTypeBR _FeeTypeAndSubTypeBR;
		private ILogger _logException;
		public FeeTypeAndSubTypeBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_FeeTypeAndSubTypeBR = new FeeTypeAndSubTypeBR();
			_FeeTypeAndSubTypeDataProvider = new FeeTypeAndSubTypeDataProvider();
		}
		/// <summary>
		/// Create new record of FeeTypeAndSubType.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> InsertFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> entityResponse = new BaseEntityResponse<FeeTypeAndSubType>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeTypeAndSubTypeBR.InsertFeeTypeAndSubTypeValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeTypeAndSubTypeDataProvider.InsertFeeTypeAndSubType(item);
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
		/// Update a specific record  of FeeTypeAndSubType.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> UpdateFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> entityResponse = new BaseEntityResponse<FeeTypeAndSubType>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeTypeAndSubTypeBR.UpdateFeeTypeAndSubTypeValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeTypeAndSubTypeDataProvider.UpdateFeeTypeAndSubType(item);
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
		/// Delete a selected record from FeeTypeAndSubType.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> DeleteFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> entityResponse = new BaseEntityResponse<FeeTypeAndSubType>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeTypeAndSubTypeBR.DeleteFeeTypeAndSubTypeValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeTypeAndSubTypeDataProvider.DeleteFeeTypeAndSubType(item);
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
		/// Select all record from FeeTypeAndSubType table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetBySearch(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeTypeAndSubType> FeeTypeAndSubTypeCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
			try
			{
				if (_FeeTypeAndSubTypeDataProvider != null)
				FeeTypeAndSubTypeCollection = _FeeTypeAndSubTypeDataProvider.GetFeeTypeAndSubTypeBySearch(searchRequest);
				else
				{
					FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeTypeAndSubTypeCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeTypeAndSubTypeCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeTypeAndSubTypeCollection;
		}
		/// <summary>
		/// Select all record from FeeTypeAndSubType table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeList(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeTypeAndSubType> FeeTypeAndSubTypeCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
			try
			{
				if (_FeeTypeAndSubTypeDataProvider != null)
                    FeeTypeAndSubTypeCollection = _FeeTypeAndSubTypeDataProvider.GetFeeSubTypeList(searchRequest);
				else
				{
					FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeTypeAndSubTypeCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeTypeAndSubTypeCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeTypeAndSubTypeCollection;
		}        
		/// <summary>
		/// Select a record from FeeTypeAndSubType table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> SelectByID(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> entityResponse = new BaseEntityResponse<FeeTypeAndSubType>();
			try
			{
				 entityResponse = _FeeTypeAndSubTypeDataProvider.GetFeeTypeAndSubTypeByID(item);
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

        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeSearchList(FeeTypeAndSubTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeTypeAndSubType> FeeTypeAndSubTypeCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
            try
            {
                if (_FeeTypeAndSubTypeDataProvider != null)
                    FeeTypeAndSubTypeCollection = _FeeTypeAndSubTypeDataProvider.GetFeeSubTypeSearchList(searchRequest);
                else
                {
                    FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeTypeAndSubTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeTypeAndSubTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeTypeAndSubTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeTypeAndSubTypeCollection;
        }        
    }
}

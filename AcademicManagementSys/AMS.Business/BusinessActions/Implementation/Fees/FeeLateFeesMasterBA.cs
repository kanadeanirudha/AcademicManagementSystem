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
	public class FeeLateFeesMasterBA : IFeeLateFeesMasterBA
	{
		IFeeLateFeesMasterDataProvider _feeLateFeesMasterDataProvider;
		IFeeLateFeesMasterBR _feeLateFeesMasterBR;
		private ILogger _logException;
		public FeeLateFeesMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_feeLateFeesMasterBR = new FeeLateFeesMasterBR();
			_feeLateFeesMasterDataProvider = new FeeLateFeesMasterDataProvider();
		}
		/// <summary>
		/// Create new record of FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeLateFeesMaster> InsertFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			IBaseEntityResponse<FeeLateFeesMaster> entityResponse = new BaseEntityResponse<FeeLateFeesMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _feeLateFeesMasterBR.InsertFeeLateFeesMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _feeLateFeesMasterDataProvider.InsertFeeLateFeesMaster(item);
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
		/// Update a specific record  of FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeLateFeesMaster> UpdateFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			IBaseEntityResponse<FeeLateFeesMaster> entityResponse = new BaseEntityResponse<FeeLateFeesMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _feeLateFeesMasterBR.UpdateFeeLateFeesMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _feeLateFeesMasterDataProvider.UpdateFeeLateFeesMaster(item);
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
		/// Delete a selected record from FeeLateFeesMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeLateFeesMaster> DeleteFeeLateFeesMaster(FeeLateFeesMaster item)
		{
			IBaseEntityResponse<FeeLateFeesMaster> entityResponse = new BaseEntityResponse<FeeLateFeesMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _feeLateFeesMasterBR.DeleteFeeLateFeesMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _feeLateFeesMasterDataProvider.DeleteFeeLateFeesMaster(item);
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
		/// Select all record from FeeLateFeesMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<FeeLateFeesMaster> GetBySearch(FeeLateFeesMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeLateFeesMaster> FeeLateFeesMasterCollection = new BaseEntityCollectionResponse<FeeLateFeesMaster>();
			try
			{
				if (_feeLateFeesMasterDataProvider != null)
				FeeLateFeesMasterCollection = _feeLateFeesMasterDataProvider.GetFeeLateFeesMasterBySearch(searchRequest);
				else
				{
					FeeLateFeesMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeLateFeesMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeLateFeesMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeLateFeesMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeLateFeesMasterCollection;
		}
        /// <summary>
        /// Select all record from FeeLateFeesMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeLateFeesMaster> GetPeriodSearchList(FeeLateFeesMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeLateFeesMaster> FeeLateFeesMasterCollection = new BaseEntityCollectionResponse<FeeLateFeesMaster>();
            try
            {
                if (_feeLateFeesMasterDataProvider != null)
                    FeeLateFeesMasterCollection = _feeLateFeesMasterDataProvider.GetPeriodSearchList(searchRequest);
                else
                {
                    FeeLateFeesMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeLateFeesMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeLateFeesMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeLateFeesMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeLateFeesMasterCollection;
        }
		/// <summary>
		/// Select a record from FeeLateFeesMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeLateFeesMaster> SelectByID(FeeLateFeesMaster item)
		{
			IBaseEntityResponse<FeeLateFeesMaster> entityResponse = new BaseEntityResponse<FeeLateFeesMaster>();
			try
			{
				 entityResponse = _feeLateFeesMasterDataProvider.GetFeeLateFeesMasterByID(item);
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

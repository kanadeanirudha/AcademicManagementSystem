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
	public class BranchPromotionBA : IBranchPromotionBA
	{
		IBranchPromotionDataProvider _BranchPromotionDataProvider;
		IBranchPromotionBR _BranchPromotionBR;
		private ILogger _logException;
		public BranchPromotionBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_BranchPromotionBR = new BranchPromotionBR();
			_BranchPromotionDataProvider = new BranchPromotionDataProvider();
		}
		/// <summary>
		/// Create new record of BranchPromotion.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<BranchPromotion> InsertBranchPromotion(BranchPromotion item)
		{
			IBaseEntityResponse<BranchPromotion> entityResponse = new BaseEntityResponse<BranchPromotion>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _BranchPromotionBR.InsertBranchPromotionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _BranchPromotionDataProvider.InsertBranchPromotion(item);
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
		/// Update a specific record  of BranchPromotion.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<BranchPromotion> UpdateBranchPromotion(BranchPromotion item)
		{
			IBaseEntityResponse<BranchPromotion> entityResponse = new BaseEntityResponse<BranchPromotion>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _BranchPromotionBR.UpdateBranchPromotionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _BranchPromotionDataProvider.UpdateBranchPromotion(item);
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
		/// Delete a selected record from BranchPromotion.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<BranchPromotion> DeleteBranchPromotion(BranchPromotion item)
		{
			IBaseEntityResponse<BranchPromotion> entityResponse = new BaseEntityResponse<BranchPromotion>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _BranchPromotionBR.DeleteBranchPromotionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _BranchPromotionDataProvider.DeleteBranchPromotion(item);
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
		/// Select all record from BranchPromotion table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<BranchPromotion> GetBySearch(BranchPromotionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<BranchPromotion> BranchPromotionCollection = new BaseEntityCollectionResponse<BranchPromotion>();
			try
			{
				if (_BranchPromotionDataProvider != null)
				BranchPromotionCollection = _BranchPromotionDataProvider.GetBranchPromotionBySearch(searchRequest);
				else
				{
					BranchPromotionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					BranchPromotionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				BranchPromotionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				BranchPromotionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return BranchPromotionCollection;
		}
        /// <summary>
        /// Select all record from BranchPromotion table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<BranchPromotion> GetBranchPromotionStudentListBySearch(BranchPromotionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BranchPromotion> BranchPromotionCollection = new BaseEntityCollectionResponse<BranchPromotion>();
            try
            {
                if (_BranchPromotionDataProvider != null)
                    BranchPromotionCollection = _BranchPromotionDataProvider.GetBranchPromotionStudentListBySearch(searchRequest);
                else
                {
                    BranchPromotionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BranchPromotionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BranchPromotionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BranchPromotionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BranchPromotionCollection;
        }
		/// <summary>
		/// Select a record from BranchPromotion table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<BranchPromotion> SelectByID(BranchPromotion item)
		{
			IBaseEntityResponse<BranchPromotion> entityResponse = new BaseEntityResponse<BranchPromotion>();
			try
			{
				 entityResponse = _BranchPromotionDataProvider.GetBranchPromotionByID(item);
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

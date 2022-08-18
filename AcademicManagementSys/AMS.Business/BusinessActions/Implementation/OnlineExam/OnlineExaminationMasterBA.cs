using AMS.Base.DTO;
using AMS.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessRules;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
	public class OnlineExaminationMasterBA : IOnlineExaminationMasterBA
	{
		IOnlineExaminationMasterDataProvider _OnlineExaminationMasterDataProvider;
		IOnlineExaminationMasterBR _OnlineExaminationMasterBR;
		private ILogger _logException;
		public OnlineExaminationMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_OnlineExaminationMasterBR = new OnlineExaminationMasterBR();
			_OnlineExaminationMasterDataProvider = new OnlineExaminationMasterDataProvider();
		}
		/// <summary>
		/// Create new record of OnlineExaminationMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationMaster> InsertOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExaminationMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationMasterBR.InsertOnlineExaminationMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationMasterDataProvider.InsertOnlineExaminationMaster(item);
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
		/// Update a specific record  of OnlineExaminationMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationMaster> UpdateOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExaminationMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationMasterBR.UpdateOnlineExaminationMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationMasterDataProvider.UpdateOnlineExaminationMaster(item);
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
		/// Delete a selected record from OnlineExaminationMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationMaster> DeleteOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExaminationMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationMasterBR.DeleteOnlineExaminationMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationMasterDataProvider.DeleteOnlineExaminationMaster(item);
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
		/// Select all record from OnlineExaminationMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OnlineExaminationMaster> GetBySearch(OnlineExaminationMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OnlineExaminationMaster> OnlineExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationMaster>();
			try
			{
				if (_OnlineExaminationMasterDataProvider != null)
				OnlineExaminationMasterCollection = _OnlineExaminationMasterDataProvider.GetOnlineExaminationMasterBySearch(searchRequest);
				else
				{
					OnlineExaminationMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OnlineExaminationMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OnlineExaminationMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OnlineExaminationMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OnlineExaminationMasterCollection;
		}
		/// <summary>
		/// Select a record from OnlineExaminationMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        /// 

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster

        public IBaseEntityCollectionResponse<OnlineExaminationMaster> GetExaminationNameByCourseID(OnlineExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationMaster> OnlineExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationMaster>();
            try
            {
                if (_OnlineExaminationMasterDataProvider != null)
                    OnlineExaminationMasterCollection = _OnlineExaminationMasterDataProvider.GetExaminationNameByCourseID(searchRequest);
                else
                {
                    OnlineExaminationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExaminationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExaminationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExaminationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExaminationMasterCollection;
        }



		public IBaseEntityResponse<OnlineExaminationMaster> SelectByID(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExaminationMaster>();
			try
			{
				 entityResponse = _OnlineExaminationMasterDataProvider.GetOnlineExaminationMasterByID(item);
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

using AMS.Base.DTO;
using AMS.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessRules;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
	public class OnlineExaminationQuestionPaperSetMasterBA : IOnlineExaminationQuestionPaperSetMasterBA
	{
		IOnlineExaminationQuestionPaperSetMasterDataProvider _OnlineExaminationQuestionPaperSetMasterDataProvider;
		IOnlineExaminationQuestionPaperSetMasterBR _OnlineExaminationQuestionPaperSetMasterBR;
		private ILogger _logException;
		public OnlineExaminationQuestionPaperSetMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_OnlineExaminationQuestionPaperSetMasterBR = new OnlineExaminationQuestionPaperSetMasterBR();
			_OnlineExaminationQuestionPaperSetMasterDataProvider = new OnlineExaminationQuestionPaperSetMasterDataProvider();
		}
		/// <summary>
		/// Create new record of OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> InsertOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> entityResponse = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationQuestionPaperSetMasterBR.InsertOnlineExaminationQuestionPaperSetMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationQuestionPaperSetMasterDataProvider.InsertOnlineExaminationQuestionPaperSetMaster(item);
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
		/// Update a specific record  of OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> UpdateOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> entityResponse = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationQuestionPaperSetMasterBR.UpdateOnlineExaminationQuestionPaperSetMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationQuestionPaperSetMasterDataProvider.UpdateOnlineExaminationQuestionPaperSetMaster(item);
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
		/// Delete a selected record from OnlineExaminationQuestionPaperSetMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> DeleteOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
		{
			IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> entityResponse = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExaminationQuestionPaperSetMasterBR.DeleteOnlineExaminationQuestionPaperSetMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExaminationQuestionPaperSetMasterDataProvider.DeleteOnlineExaminationQuestionPaperSetMaster(item);
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
		/// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetBySearch(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> OnlineExaminationQuestionPaperSetMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
			try
			{
				if (_OnlineExaminationQuestionPaperSetMasterDataProvider != null)
				OnlineExaminationQuestionPaperSetMasterCollection = _OnlineExaminationQuestionPaperSetMasterDataProvider.GetOnlineExaminationQuestionPaperSetMasterBySearch(searchRequest);
				else
				{
					OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OnlineExaminationQuestionPaperSetMasterCollection;
		}
        /// <summary>
        /// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterSearchList(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> OnlineExaminationQuestionPaperSetMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
            try
            {
                if (_OnlineExaminationQuestionPaperSetMasterDataProvider != null)
                    OnlineExaminationQuestionPaperSetMasterCollection = _OnlineExaminationQuestionPaperSetMasterDataProvider.GetOnlineExaminationQuestionPaperSetMasterSearchList(searchRequest);
                else
                {
                    OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExaminationQuestionPaperSetMasterCollection;
        }
        /// <summary>
        /// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterBySpin(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> OnlineExaminationQuestionPaperSetMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
            try
            {
                if (_OnlineExaminationQuestionPaperSetMasterDataProvider != null)
                    OnlineExaminationQuestionPaperSetMasterCollection = _OnlineExaminationQuestionPaperSetMasterDataProvider.GetOnlineExaminationQuestionPaperSetMasterBySpin(searchRequest);
                else
                {
                    OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExaminationQuestionPaperSetMasterCollection;
        }
		/// <summary>
		/// Select a record from OnlineExaminationQuestionPaperSetMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> SelectByID(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
		{
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> OnlineExaminationQuestionPaperSetMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
            try
            {
                if (_OnlineExaminationQuestionPaperSetMasterDataProvider != null)
                    OnlineExaminationQuestionPaperSetMasterCollection = _OnlineExaminationQuestionPaperSetMasterDataProvider.GetOnlineExaminationQuestionPaperSetMasterByID(searchRequest);
                else
                {
                    OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExaminationQuestionPaperSetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExaminationQuestionPaperSetMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExaminationQuestionPaperSetMasterCollection;
		}
	}
}

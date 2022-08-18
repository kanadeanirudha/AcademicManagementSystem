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
    public class OnlineExamQuestionBankMasterAndDetailsBA : IOnlineExamQuestionBankMasterAndDetailsBA
	{
		IOnlineExamQuestionBankMasterAndDetailsDataProvider _OnlineExamQuestionBankMasterAndDetailsDataProvider;
		IOnlineExamQuestionBankMasterAndDetailsBR _OnlineExamQuestionBankMasterAndDetailsBR;
		private ILogger _logException;
		public OnlineExamQuestionBankMasterAndDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_OnlineExamQuestionBankMasterAndDetailsBR = new OnlineExamQuestionBankMasterAndDetailsBR();
			_OnlineExamQuestionBankMasterAndDetailsDataProvider = new OnlineExamQuestionBankMasterAndDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of OnlineExamQuestionBankMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExamQuestionBankMasterAndDetailsBR.InsertOnlineExamQuestionBankMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.InsertOnlineExamQuestionBankMasterAndDetails(item);
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
		/// Update a specific record  of OnlineExamQuestionBankMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> UpdateOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExamQuestionBankMasterAndDetailsBR.UpdateOnlineExamQuestionBankMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.UpdateOnlineExamQuestionBankMaster(item);
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
		/// Delete a selected record from OnlineExamQuestionBankMasterAndDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
		{
			IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _OnlineExamQuestionBankMasterAndDetailsBR.DeleteOnlineExamQuestionBankMasterAndDetailsValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.DeleteOnlineExamQuestionBankMaster(item);
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
		/// Select all record from OnlineExamQuestionBankMasterAndDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamQuestionBankMasterAndDetailsCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
			try
			{
				if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
				OnlineExamQuestionBankMasterAndDetailsCollection = _OnlineExamQuestionBankMasterAndDetailsDataProvider.GetOnlineExamQuestionBankMasterBySearch(searchRequest);
				else
				{
					OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OnlineExamQuestionBankMasterAndDetailsCollection;
		}
		/// <summary>
		/// Select a record from OnlineExamQuestionBankMasterAndDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectByID(OnlineExamQuestionBankMasterAndDetails item)
		{
			IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
			try
			{
				 entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.GetOnlineExamQuestionBankMasterByID(item);
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
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.SelectoneOnlineExamQuestionBankMasterAndDetails(item);
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

        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamQuestionBankMasterAndDetailsCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
                    OnlineExamQuestionBankMasterAndDetailsCollection = _OnlineExamQuestionBankMasterAndDetailsDataProvider.GetCourseYearDetailsByCentreCode(searchRequest);
                else
                {
                    OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamQuestionBankMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamQuestionBankMasterAndDetailsCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
                    OnlineExamQuestionBankMasterAndDetailsCollection = _OnlineExamQuestionBankMasterAndDetailsDataProvider.OnlineExamExaminationQuestionsList(searchRequest);
                else
                {
                    OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamQuestionBankMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamQuestionBankMasterAndDetailsCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
                    OnlineExamQuestionBankMasterAndDetailsCollection = _OnlineExamQuestionBankMasterAndDetailsDataProvider.GetListQuestionBankMaster(searchRequest);
                else
                {
                    OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamQuestionBankMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamQuestionBankMasterAndDetailsCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
                    OnlineExamQuestionBankMasterAndDetailsCollection = _OnlineExamQuestionBankMasterAndDetailsDataProvider.GetSubjectDetailsByCourseAndSem(searchRequest);
                else
                {
                    OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamQuestionBankMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamQuestionBankMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamQuestionBankMasterAndDetailsCollection;
        }

        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> entityResponse = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
            try
            {
                if (_OnlineExamQuestionBankMasterAndDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamQuestionBankMasterAndDetailsDataProvider.InsertOnlineExamQuestionBankMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
	}
}

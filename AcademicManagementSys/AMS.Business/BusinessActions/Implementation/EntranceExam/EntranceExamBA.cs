using AMS.Base.DTO;
using AMS.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessRules;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
	public class EntranceExamBA : IEntranceExamBA
	{
		IEntranceExamDataProvider _EntranceExamDataProvider;
		IEntranceExamBR _EntranceExamBR;
		private ILogger _logException;
		public EntranceExamBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_EntranceExamBR = new EntranceExamBR();
			_EntranceExamDataProvider = new EntranceExamDataProvider();
		}
		/// <summary>
		/// Create new record of EntranceExam.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EntranceExam> InsertEntranceExam(EntranceExam item)
		{
			IBaseEntityResponse<EntranceExam> entityResponse = new BaseEntityResponse<EntranceExam>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _EntranceExamBR.InsertEntranceExamValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _EntranceExamDataProvider.InsertEntranceExam(item);
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
		/// Update a specific record  of EntranceExam.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EntranceExam> UpdateEntranceExam(EntranceExam item)
		{
			IBaseEntityResponse<EntranceExam> entityResponse = new BaseEntityResponse<EntranceExam>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _EntranceExamBR.UpdateEntranceExamValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _EntranceExamDataProvider.UpdateEntranceExam(item);
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
		/// Delete a selected record from EntranceExam.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EntranceExam> DeleteEntranceExam(EntranceExam item)
		{
			IBaseEntityResponse<EntranceExam> entityResponse = new BaseEntityResponse<EntranceExam>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _EntranceExamBR.DeleteEntranceExamValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _EntranceExamDataProvider.DeleteEntranceExam(item);
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
		/// Select a record from EntranceExam table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EntranceExam> SelectByID(EntranceExam item)
		{
			IBaseEntityResponse<EntranceExam> entityResponse = new BaseEntityResponse<EntranceExam>();
			try
			{
				 entityResponse = _EntranceExamDataProvider.GetEntranceExamByID(item);
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
        /// Select all record from EntranceExam table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetBySearch(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> EntranceExamCollection = new BaseEntityCollectionResponse<EntranceExam>();
            try
            {
                if (_EntranceExamDataProvider != null)
                    EntranceExamCollection = _EntranceExamDataProvider.GetEntranceExamBySearch(searchRequest);
                else
                {
                    EntranceExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamCollection;
        }
        /// <summary>
        /// Select all record from EntranceExam table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndStudentExamInfo(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> EntranceExamCollection = new BaseEntityCollectionResponse<EntranceExam>();
            try
            {
                if (_EntranceExamDataProvider != null)
                    EntranceExamCollection = _EntranceExamDataProvider.GetEntranceExamIndStudentExamInfo(searchRequest);
                else
                {
                    EntranceExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamCollection;
        }
        /// <summary>
        /// Select all record from EntranceExam table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndExamQuestionType(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> EntranceExamCollection = new BaseEntityCollectionResponse<EntranceExam>();
            try
            {
                if (_EntranceExamDataProvider != null)
                    EntranceExamCollection = _EntranceExamDataProvider.GetEntranceExamIndExamQuestionType(searchRequest);
                else
                {
                    EntranceExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamCollection;
        }
        /// <summary>
        /// Select all record from EntranceExam table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> EntranceExamIndEGetSetQuestion(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> EntranceExamCollection = new BaseEntityCollectionResponse<EntranceExam>();
            try
            {
                if (_EntranceExamDataProvider != null)
                    EntranceExamCollection = _EntranceExamDataProvider.EntranceExamIndEGetSetQuestion(searchRequest);
                else
                {
                    EntranceExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamCollection;
        }
        /// <summary>
        /// Select all record from EntranceExam table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamGetResultofStudent(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> EntranceExamCollection = new BaseEntityCollectionResponse<EntranceExam>();
            try
            {
                if (_EntranceExamDataProvider != null)
                    EntranceExamCollection = _EntranceExamDataProvider.GetEntranceExamGetResultofStudent(searchRequest);
                else
                {
                    EntranceExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamCollection;
        }
	}
}

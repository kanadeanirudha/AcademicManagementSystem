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
	public class GenerateStudentRollNumberBA : IGenerateStudentRollNumberBA
	{
		IGenerateStudentRollNumberDataProvider _GenerateStudentRollNumberDataProvider;
		IGenerateStudentRollNumberBR _GenerateStudentRollNumberBR;
		private ILogger _logException;
		public GenerateStudentRollNumberBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_GenerateStudentRollNumberBR = new GenerateStudentRollNumberBR();
			_GenerateStudentRollNumberDataProvider = new GenerateStudentRollNumberDataProvider();
		}
		/// <summary>
		/// Create new record of GenerateStudentRollNumber.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> InsertGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> entityResponse = new BaseEntityResponse<GenerateStudentRollNumber>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _GenerateStudentRollNumberBR.InsertGenerateStudentRollNumberValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _GenerateStudentRollNumberDataProvider.InsertGenerateStudentRollNumber(item);
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
		/// Update a specific record  of GenerateStudentRollNumber.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> UpdateGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> entityResponse = new BaseEntityResponse<GenerateStudentRollNumber>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _GenerateStudentRollNumberBR.UpdateGenerateStudentRollNumberValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _GenerateStudentRollNumberDataProvider.UpdateGenerateStudentRollNumber(item);
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
		/// Delete a selected record from GenerateStudentRollNumber.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> DeleteGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> entityResponse = new BaseEntityResponse<GenerateStudentRollNumber>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _GenerateStudentRollNumberBR.DeleteGenerateStudentRollNumberValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _GenerateStudentRollNumberDataProvider.DeleteGenerateStudentRollNumber(item);
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
		/// Select all record from GenerateStudentRollNumber table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<GenerateStudentRollNumber> GenerateStudentRollNumberCollection = new BaseEntityCollectionResponse<GenerateStudentRollNumber>();
			try
			{
				if (_GenerateStudentRollNumberDataProvider != null)
				GenerateStudentRollNumberCollection = _GenerateStudentRollNumberDataProvider.GetGenerateStudentRollNumberBySearch(searchRequest);
				else
				{
					GenerateStudentRollNumberCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					GenerateStudentRollNumberCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				GenerateStudentRollNumberCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				GenerateStudentRollNumberCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return GenerateStudentRollNumberCollection;
		}
        /// <summary>
        /// Select all record from GenerateStudentRollNumber table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberStudentListBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GenerateStudentRollNumber> GenerateStudentRollNumberCollection = new BaseEntityCollectionResponse<GenerateStudentRollNumber>();
            try
            {
                if (_GenerateStudentRollNumberDataProvider != null)
                    GenerateStudentRollNumberCollection = _GenerateStudentRollNumberDataProvider.GetGenerateStudentRollNumberStudentListBySearch(searchRequest);
                else
                {
                    GenerateStudentRollNumberCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GenerateStudentRollNumberCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GenerateStudentRollNumberCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GenerateStudentRollNumberCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GenerateStudentRollNumberCollection;
        }
		/// <summary>
		/// Select a record from GenerateStudentRollNumber table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> SelectByID(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> entityResponse = new BaseEntityResponse<GenerateStudentRollNumber>();
			try
			{
				 entityResponse = _GenerateStudentRollNumberDataProvider.GetGenerateStudentRollNumberByID(item);
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

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
    public class StudentReadmissionBA : IStudentReadmissionBA
	{
		IStudentReadmissionDataProvider _StudentReadmissionDataProvider;
		IStudentReadmissionBR _StudentReadmissionBR;
		private ILogger _logException;
		public StudentReadmissionBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_StudentReadmissionBR = new StudentReadmissionBR();
			_StudentReadmissionDataProvider = new StudentReadmissionDataProvider();
		}
		/// <summary>
		/// Create new record of StudentReadmission.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> InsertStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> entityResponse = new BaseEntityResponse<StudentReadmission>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentReadmissionBR.InsertStudentReadmissionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentReadmissionDataProvider.InsertStudentReadmission(item);
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
		/// Update a specific record  of StudentReadmission.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> UpdateStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> entityResponse = new BaseEntityResponse<StudentReadmission>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentReadmissionBR.UpdateStudentReadmissionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentReadmissionDataProvider.UpdateStudentReadmission(item);
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
		/// Delete a selected record from StudentReadmission.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> DeleteStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> entityResponse = new BaseEntityResponse<StudentReadmission>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentReadmissionBR.DeleteStudentReadmissionValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentReadmissionDataProvider.DeleteStudentReadmission(item);
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
		/// Select all record from StudentReadmission table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<StudentReadmission> GetBySearch(StudentReadmissionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentReadmission> StudentReadmissionCollection = new BaseEntityCollectionResponse<StudentReadmission>();
			try
			{
				if (_StudentReadmissionDataProvider != null)
				StudentReadmissionCollection = _StudentReadmissionDataProvider.GetStudentReadmissionBySearch(searchRequest);
				else
				{
					StudentReadmissionCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					StudentReadmissionCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				StudentReadmissionCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				StudentReadmissionCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return StudentReadmissionCollection;
		}
		/// <summary>
		/// Select a record from StudentReadmission table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> SelectByID(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> entityResponse = new BaseEntityResponse<StudentReadmission>();
			try
			{
				 entityResponse = _StudentReadmissionDataProvider.GetStudentReadmissionByID(item);
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
		/// Business Action Method for AuthoriseStudentSectionChangeRequest form
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentReadmission> InsertAuthoriseStudentSectionChangeRequest(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> entityResponse = new BaseEntityResponse<StudentReadmission>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentReadmissionBR.InsertStudentReadmissionValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _StudentReadmissionDataProvider.InsertAuthoriseStudentSectionChangeRequest(item);
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
        
	}
}

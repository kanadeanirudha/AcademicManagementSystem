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
	public class StudentSectionChangeRequestBA : IStudentSectionChangeRequestBA
	{
		IStudentSectionChangeRequestDataProvider _StudentSectionChangeRequestDataProvider;
		IStudentSectionChangeRequestBR _StudentSectionChangeRequestBR;
		private ILogger _logException;
		public StudentSectionChangeRequestBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_StudentSectionChangeRequestBR = new StudentSectionChangeRequestBR();
			_StudentSectionChangeRequestDataProvider = new StudentSectionChangeRequestDataProvider();
		}
		/// <summary>
		/// Create new record of StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> InsertStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> entityResponse = new BaseEntityResponse<StudentSectionChangeRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentSectionChangeRequestBR.InsertStudentSectionChangeRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentSectionChangeRequestDataProvider.InsertStudentSectionChangeRequest(item);
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
		/// Update a specific record  of StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> UpdateStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> entityResponse = new BaseEntityResponse<StudentSectionChangeRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentSectionChangeRequestBR.UpdateStudentSectionChangeRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentSectionChangeRequestDataProvider.UpdateStudentSectionChangeRequest(item);
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
		/// Delete a selected record from StudentSectionChangeRequest.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> DeleteStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> entityResponse = new BaseEntityResponse<StudentSectionChangeRequest>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentSectionChangeRequestBR.DeleteStudentSectionChangeRequestValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentSectionChangeRequestDataProvider.DeleteStudentSectionChangeRequest(item);
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
		/// Select all record from StudentSectionChangeRequest table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetBySearch(StudentSectionChangeRequestSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentSectionChangeRequest> StudentSectionChangeRequestCollection = new BaseEntityCollectionResponse<StudentSectionChangeRequest>();
			try
			{
				if (_StudentSectionChangeRequestDataProvider != null)
				StudentSectionChangeRequestCollection = _StudentSectionChangeRequestDataProvider.GetStudentSectionChangeRequestBySearch(searchRequest);
				else
				{
					StudentSectionChangeRequestCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					StudentSectionChangeRequestCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				StudentSectionChangeRequestCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				StudentSectionChangeRequestCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return StudentSectionChangeRequestCollection;
		}
		/// <summary>
		/// Select a record from StudentSectionChangeRequest table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> SelectByID(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> entityResponse = new BaseEntityResponse<StudentSectionChangeRequest>();
			try
			{
				 entityResponse = _StudentSectionChangeRequestDataProvider.GetStudentSectionChangeRequestByID(item);
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
		/// Select all record from StudentSectionChangeRequest table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetSectionList(StudentSectionChangeRequestSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentSectionChangeRequest> StudentSectionChangeRequestCollection = new BaseEntityCollectionResponse<StudentSectionChangeRequest>();
			try
			{
				if (_StudentSectionChangeRequestDataProvider != null)
                    StudentSectionChangeRequestCollection = _StudentSectionChangeRequestDataProvider.GetSectionList(searchRequest);
				else
				{
					StudentSectionChangeRequestCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					StudentSectionChangeRequestCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				StudentSectionChangeRequestCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				StudentSectionChangeRequestCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return StudentSectionChangeRequestCollection;
		}
	}
}

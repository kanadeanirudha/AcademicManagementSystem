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
namespace AMS.Business
{
	public class StudentMasterBA : IStudentMasterBA
	{
		IStudentMasterDataProvider _StudentMasterDataProvider;
		IStudentMasterBR _StudentMasterBR;
		private ILogger _logException;
		public StudentMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_StudentMasterBR = new StudentMasterBR();
			_StudentMasterDataProvider = new StudentMasterDataProvider();
		}
		/// <summary>
		/// Create new record of StudentMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> InsertStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentMasterBR.InsertStudentMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentMasterDataProvider.InsertStudentMaster(item);
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
		/// Update a specific record  of StudentMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> UpdateStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentMasterBR.UpdateStudentMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentMasterDataProvider.UpdateStudentMaster(item);
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
		/// Delete a selected record from StudentMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> DeleteStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _StudentMasterBR.DeleteStudentMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _StudentMasterDataProvider.DeleteStudentMaster(item);
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
        /// Select all record from StudentMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentMaster> GetStudentSearchList(StudentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentMaster> StudentMasterCollection = new BaseEntityCollectionResponse<StudentMaster>();
            try
            {
                if (_StudentMasterDataProvider != null)
                    StudentMasterCollection = _StudentMasterDataProvider.GetStudentSearchList(searchRequest);
                else
                {
                    StudentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentMasterCollection;
        }
		/// <summary>
		/// Select all record from StudentMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<StudentMaster> GetBySearch(StudentMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentMaster> StudentMasterCollection = new BaseEntityCollectionResponse<StudentMaster>();
			try
			{
				if (_StudentMasterDataProvider != null)
				StudentMasterCollection = _StudentMasterDataProvider.GetStudentMasterBySearch(searchRequest);
				else
				{
					StudentMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					StudentMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				StudentMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				StudentMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return StudentMasterCollection;
		}
		/// <summary>
		/// Select a record from StudentMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> SelectByID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
				 entityResponse = _StudentMasterDataProvider.GetStudentMasterByID(item);
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
		/// Select a record from StudentMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentMaster> GetStudentDetails(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
                entityResponse = _StudentMasterDataProvider.GetStudentDetails(item);
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
		/// Select a record from StudentMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentMaster> GetStudentCentreByID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
                entityResponse = _StudentMasterDataProvider.GetStudentCentreByID(item);
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
		/// Select a record from StudentMaster table by ID for student menu loading
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentMaster> GetCentreFromStudentMasterByStudentID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> entityResponse = new BaseEntityResponse<StudentMaster>();
			try
			{
                entityResponse = _StudentMasterDataProvider.GetCentreFromStudentMasterByStudentID(item);
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

        public IBaseEntityCollectionResponse<StudentMaster> GetStudentAdmissionCancel(StudentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentMaster> StudentMasterCollection = new BaseEntityCollectionResponse<StudentMaster>();
            try
            {
                if (_StudentMasterDataProvider != null)
                    StudentMasterCollection = _StudentMasterDataProvider.GetStudentAdmissionCancel(searchRequest);
                else
                {
                    StudentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentMasterCollection;
        }
	}
}

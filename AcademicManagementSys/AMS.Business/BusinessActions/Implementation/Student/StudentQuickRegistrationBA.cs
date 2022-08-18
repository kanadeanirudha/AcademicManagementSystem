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
    public class StudentQuickRegistrationBA : IStudentQuickRegistrationBA
    {
        IStudentQuickRegistrationDataProvider _studentQuickRegistrationDataProvider;
        IStudentQuickRegistrationBR _studentQuickRegistrationBR;
        private ILogger _logException;
        public StudentQuickRegistrationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _studentQuickRegistrationBR = new StudentQuickRegistrationBR();
            _studentQuickRegistrationDataProvider = new StudentQuickRegistrationDataProvider();
        }
        /// <summary>
        /// Create new record of StudentQuickRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> InsertStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> entityResponse = new BaseEntityResponse<StudentQuickRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentQuickRegistrationBR.InsertStudentQuickRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentQuickRegistrationDataProvider.InsertStudentQuickRegistration(item);
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
        /// <summary>
        /// Update a specific record  of StudentQuickRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> UpdateStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> entityResponse = new BaseEntityResponse<StudentQuickRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentQuickRegistrationBR.UpdateStudentQuickRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentQuickRegistrationDataProvider.UpdateStudentQuickRegistration(item);
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
        /// <summary>
        /// Delete a selected record from StudentQuickRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> DeleteStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> entityResponse = new BaseEntityResponse<StudentQuickRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentQuickRegistrationBR.DeleteStudentQuickRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentQuickRegistrationDataProvider.DeleteStudentQuickRegistration(item);
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
        /// <summary>
        /// Select all record from StudentQuickRegistration table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentQuickRegistration> GetBySearch(StudentQuickRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentQuickRegistration> StudentQuickRegistrationCollection = new BaseEntityCollectionResponse<StudentQuickRegistration>();
            try
            {
                if (_studentQuickRegistrationDataProvider != null)
                    StudentQuickRegistrationCollection = _studentQuickRegistrationDataProvider.GetStudentQuickRegistrationBySearch(searchRequest);
                else
                {
                    StudentQuickRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentQuickRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentQuickRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentQuickRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentQuickRegistrationCollection;
        }
        /// <summary>
        /// Select a record from StudentQuickRegistration table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> SelectByID(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> entityResponse = new BaseEntityResponse<StudentQuickRegistration>();
            try
            {
                entityResponse = _studentQuickRegistrationDataProvider.GetStudentQuickRegistrationByID(item);
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

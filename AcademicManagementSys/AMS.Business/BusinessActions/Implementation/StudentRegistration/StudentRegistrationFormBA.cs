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
    public class StudentRegistrationFormBA : IStudentRegistrationFormBA
    {
        IStudentRegistrationFormDataProvider _StudentRegistrationFormDataProvider;
        IStudentRegistrationFormBR _StudentRegistrationFormBR;
        private ILogger _logException;
        public StudentRegistrationFormBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudentRegistrationFormBR = new StudentRegistrationFormBR();
            _StudentRegistrationFormDataProvider = new StudentRegistrationFormDataProvider();
        }
      
        /// <summary>
        /// Update a specific record  of StudentRegistrationForm.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //public IBaseEntityResponse<StudentRegistrationForm> UpdateStudentRegistrationForm(StudentRegistrationForm item)
        //{
        //    IBaseEntityResponse<StudentRegistrationForm> entityResponse = new BaseEntityResponse<StudentRegistrationForm>();
        //    try
        //    {
        //        IValidateBusinessRuleResponse brResponse = _StudentRegistrationFormBR.UpdateStudentRegistrationFormValidate(item);
        //        if (brResponse.Passed)
        //        {
        //            entityResponse = _StudentRegistrationFormDataProvider.UpdateStudentRegistrationForm(item);
        //        }
        //        else
        //        {
        //            entityResponse.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            entityResponse.Entity = null; ;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        entityResponse.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        entityResponse.Entity = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return entityResponse;
        //}
        /// <summary>
        /// Select all record from StudentRegistrationForm table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentRegistrationForm> GetByToolRegistrationFieldList(StudentRegistrationFormSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationForm> StudentRegistrationFormCollection = new BaseEntityCollectionResponse<StudentRegistrationForm>();
            try
            {
                if (_StudentRegistrationFormDataProvider != null)
                    StudentRegistrationFormCollection = _StudentRegistrationFormDataProvider.GetStudentRegistrationFormFieldBySearchList(searchRequest);
                else
                {
                    StudentRegistrationFormCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationFormCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationFormCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationFormCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationFormCollection;
        }
        public IBaseEntityCollectionResponse<PreviousWorkExperience> GetPreviousWorkExperience(PreviousWorkExperienceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PreviousWorkExperience> StudentRegistrationFormCollection = new BaseEntityCollectionResponse<PreviousWorkExperience>();
            try
            {
                if (_StudentRegistrationFormDataProvider != null)
                    StudentRegistrationFormCollection = _StudentRegistrationFormDataProvider.GetPreviousWorkExperience(searchRequest);
                else
                {
                    StudentRegistrationFormCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationFormCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationFormCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationFormCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationFormCollection;
        }
        
        public IBaseEntityResponse<StudentRegistrationForm> SelectByEmailIDAndPassword(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> entityResponse = new BaseEntityResponse<StudentRegistrationForm>();
            try
            {
                entityResponse = _StudentRegistrationFormDataProvider.SelectByEmailIDAndPassword(item);
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

        public IBaseEntityCollectionResponse<StudentRegistrationForm> GetListQualifyingExamSelectList(StudentRegistrationFormSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationForm> StudentRegistrationFormCollection = new BaseEntityCollectionResponse<StudentRegistrationForm>();
            try
            {
                if (_StudentRegistrationFormDataProvider != null)
                    StudentRegistrationFormCollection = _StudentRegistrationFormDataProvider.GetListQualifyingExamSelectList(searchRequest);
                else
                {
                    StudentRegistrationFormCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationFormCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationFormCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationFormCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationFormCollection;
        }
        /// <summary>
        /// Create new record of StudentRegistrationForm.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationForm> InsertStudentRegistrationForm(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> entityResponse = new BaseEntityResponse<StudentRegistrationForm>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentRegistrationFormBR.InsertStudentRegistrationFormValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentRegistrationFormDataProvider.InsertStudentRegistrationForm(item);
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

        public IBaseEntityResponse<StudentRegistrationForm> SelectByID(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> entityResponse = new BaseEntityResponse<StudentRegistrationForm>();
            try
            {
                entityResponse = _StudentRegistrationFormDataProvider.SelectByID(item);
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
        /// Update record of StudentRegistrationForm.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationForm> UpdateStudentRegistrationForm(StudentRegistrationForm item)
        {
            IBaseEntityResponse<StudentRegistrationForm> entityResponse = new BaseEntityResponse<StudentRegistrationForm>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentRegistrationFormBR.UpdateStudentRegistrationFormValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentRegistrationFormDataProvider.UpdateStudentRegistrationForm(item);
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

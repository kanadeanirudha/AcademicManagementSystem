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
    public class StudentRegistrationAcademicApprovalBA : IStudentRegistrationAcademicApprovalBA
    {
        IStudentRegistrationAcademicApprovalDataProvider _StudentRegistrationAcademicApprovalDataProvider;
        IStudentRegistrationAcademicApprovalBR _StudentRegistrationAcademicApprovalBR;
        private ILogger _logException;
        public StudentRegistrationAcademicApprovalBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudentRegistrationAcademicApprovalBR = new StudentRegistrationAcademicApprovalBR();
            _StudentRegistrationAcademicApprovalDataProvider = new StudentRegistrationAcademicApprovalDataProvider();
        }
        /// <summary>
        /// Create new record of StudentRegistrationAcademicApproval.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> InsertStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> entityResponse = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentRegistrationAcademicApprovalBR.InsertStudentRegistrationAcademicApprovalValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentRegistrationAcademicApprovalDataProvider.InsertStudentRegistrationAcademicApproval(item);
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
        /// Update a specific record  of StudentRegistrationAcademicApproval.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> UpdateStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> entityResponse = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentRegistrationAcademicApprovalBR.UpdateStudentRegistrationAcademicApprovalValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentRegistrationAcademicApprovalDataProvider.UpdateStudentRegistrationAcademicApproval(item);
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
        /// Delete a selected record from StudentRegistrationAcademicApproval.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> DeleteStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> entityResponse = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentRegistrationAcademicApprovalBR.DeleteStudentRegistrationAcademicApprovalValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentRegistrationAcademicApprovalDataProvider.DeleteStudentRegistrationAcademicApproval(item);
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
        /// Select all record from StudentRegistrationAcademicApproval table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetBySearch(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> StudentRegistrationAcademicApprovalCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
            try
            {
                if (_StudentRegistrationAcademicApprovalDataProvider != null)
                    StudentRegistrationAcademicApprovalCollection = _StudentRegistrationAcademicApprovalDataProvider.GetStudentRegistrationAcademicApprovalBySearch(searchRequest);
                else
                {
                    StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationAcademicApprovalCollection;
        }
        /// <summary>
        /// Select a record from StudentRegistrationAcademicApproval table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> SelectByID(StudentRegistrationAcademicApproval item)
        {
            IBaseEntityResponse<StudentRegistrationAcademicApproval> entityResponse = new BaseEntityResponse<StudentRegistrationAcademicApproval>();
            try
            {
                entityResponse = _StudentRegistrationAcademicApprovalDataProvider.GetStudentRegistrationAcademicApprovalByID(item);
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

        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualifyingExamSubjectList(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> StudentRegistrationAcademicApprovalCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
            try
            {
                if (_StudentRegistrationAcademicApprovalDataProvider != null)
                    StudentRegistrationAcademicApprovalCollection = _StudentRegistrationAcademicApprovalDataProvider.GetByQualifyingExamSubjectList(searchRequest);
                else
                {
                    StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationAcademicApprovalCollection;
        }

        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> StudentRegistrationAcademicApprovalCollection = new BaseEntityCollectionResponse<StudentRegistrationAcademicApproval>();
            try
            {
                if (_StudentRegistrationAcademicApprovalDataProvider != null)
                    StudentRegistrationAcademicApprovalCollection = _StudentRegistrationAcademicApprovalDataProvider.GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(searchRequest);
                else
                {
                    StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationAcademicApprovalCollection;
        }
        public IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> GetPreviousWorkExperienceAcademicApproval(PreviousWorkExperienceAcademicApprovalSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> StudentRegistrationAcademicApprovalCollection = new BaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval>();
            try
            {
                if (_StudentRegistrationAcademicApprovalDataProvider != null)
                    StudentRegistrationAcademicApprovalCollection = _StudentRegistrationAcademicApprovalDataProvider.GetPreviousWorkExperienceAcademicApproval(searchRequest);
                else
                {
                    StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentRegistrationAcademicApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentRegistrationAcademicApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentRegistrationAcademicApprovalCollection;
        }
        
    }
}

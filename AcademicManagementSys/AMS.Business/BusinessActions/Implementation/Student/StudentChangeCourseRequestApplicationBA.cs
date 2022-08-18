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
    public class StudentChangeCourseRequestApplicationBA : IStudentChangeCourseRequestApplicationBA
    {
        IStudentChangeCourseRequestApplicationDataProvider _StudentChangeCourseRequestApplicationDataProvider;
        IStudentChangeCourseRequestApplicationBR _StudentChangeCourseRequestApplicationBR;
        private ILogger _logException;
        public StudentChangeCourseRequestApplicationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudentChangeCourseRequestApplicationBR = new StudentChangeCourseRequestApplicationBR();
            _StudentChangeCourseRequestApplicationDataProvider = new StudentChangeCourseRequestApplicationDataProvider();
        }
        /// <summary>
        /// Create new record of StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> InsertStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentChangeCourseRequestApplicationBR.InsertStudentChangeCourseRequestApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentChangeCourseRequestApplicationDataProvider.InsertStudentChangeCourseRequestApplication(item);
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
        /// Update a specific record  of StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> UpdateStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentChangeCourseRequestApplicationBR.UpdateStudentChangeCourseRequestApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentChangeCourseRequestApplicationDataProvider.UpdateStudentChangeCourseRequestApplication(item);
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
        /// Delete a selected record from StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> DeleteStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentChangeCourseRequestApplicationBR.DeleteStudentChangeCourseRequestApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentChangeCourseRequestApplicationDataProvider.DeleteStudentChangeCourseRequestApplication(item);
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
        /// Select all record from StudentChangeCourseRequestApplication table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearch(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> StudentChangeCourseRequestApplicationCollection = new BaseEntityCollectionResponse<StudentChangeCourseRequestApplication>();
            try
            {
                if (_StudentChangeCourseRequestApplicationDataProvider != null)
                    StudentChangeCourseRequestApplicationCollection = _StudentChangeCourseRequestApplicationDataProvider.GetStudentChangeCourseRequestApplicationBySearch(searchRequest);
                else
                {
                    StudentChangeCourseRequestApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentChangeCourseRequestApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentChangeCourseRequestApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentChangeCourseRequestApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentChangeCourseRequestApplicationCollection;
        }
        /// <summary>
        /// Select a record from StudentChangeCourseRequestApplication table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByID(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
            try
            {
                entityResponse = _StudentChangeCourseRequestApplicationDataProvider.GetStudentChangeCourseRequestApplicationByID(item);
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
//for new course
        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearchlist(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityCollectionResponse<StudentChangeCourseRequestApplication>();
            try
            {
                entityResponse = _StudentChangeCourseRequestApplicationDataProvider.GetBySearchlist(searchRequest);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByUserLoginId(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> entityResponse = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
            try
            {
                entityResponse = _StudentChangeCourseRequestApplicationDataProvider.SelectByUserLoginId(item);
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

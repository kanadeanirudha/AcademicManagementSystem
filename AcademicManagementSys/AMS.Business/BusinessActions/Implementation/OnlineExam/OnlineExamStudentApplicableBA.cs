
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
    public class OnlineExamStudentApplicableBA : IOnlineExamStudentApplicableBA
    {
        IOnlineExamStudentApplicableDataProvider _OnlineExamStudentApplicableDataProvider;
        IOnlineExamStudentApplicableBR _OnlineExamStudentApplicableBR;
        private ILogger _logException;
        public OnlineExamStudentApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamStudentApplicableBR = new OnlineExamStudentApplicableBR();
            _OnlineExamStudentApplicableDataProvider = new OnlineExamStudentApplicableDataProvider();
        }

        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> CourseYearListOnlineExaminationMasterWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentApplicableDataProvider.CourseYearListOnlineExaminationMasterWise(searchRequest);
                else
                {
                    OnlineExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SubjectListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentApplicableDataProvider.SubjectListOnlineCourseYearWise(searchRequest);
                else
                {
                    OnlineExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> SectionListOnlineCourseYearWise(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentApplicableDataProvider.SectionListOnlineCourseYearWise(searchRequest);
                else
                {
                    OnlineExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> GetOnlineExamStudentApplicableList(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentApplicableDataProvider.GetOnlineExamStudentApplicableList(searchRequest);
                else
                {
                    OnlineExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamStudentAllotedList(OnlineExamStudentApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentApplicable> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentApplicableDataProvider.OnlineExamStudentAllotedList(searchRequest);
                else
                {
                    OnlineExamCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamCollection;
        }

        public IBaseEntityResponse<OnlineExamStudentApplicable> AddStudentForExam(OnlineExamStudentApplicable item)
        {
            IBaseEntityResponse<OnlineExamStudentApplicable> entityResponse = new BaseEntityResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                {
                    entityResponse = _OnlineExamStudentApplicableDataProvider.AddStudentForExam(item);
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

        public IBaseEntityResponse<OnlineExamStudentApplicable> RemoveStudentFromExam(OnlineExamStudentApplicable item)
        {
            IBaseEntityResponse<OnlineExamStudentApplicable> entityResponse = new BaseEntityResponse<OnlineExamStudentApplicable>();
            try
            {
                if (_OnlineExamStudentApplicableDataProvider != null)
                {
                    entityResponse = _OnlineExamStudentApplicableDataProvider.RemoveStudentFromExam(item);
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

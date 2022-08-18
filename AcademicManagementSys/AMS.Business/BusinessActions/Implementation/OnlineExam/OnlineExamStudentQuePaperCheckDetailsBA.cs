
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
    public class OnlineExamStudentQuePaperCheckDetailsBA : IOnlineExamStudentQuePaperCheckDetailsBA
    {
        IOnlineExamStudentQuePaperCheckDetailsDataProvider _OnlineExamStudentQuePaperCheckDetailsDataProvider;
        IOnlineExamStudentQuePaperCheckDetailsBR _OnlineExamStudentQuePaperCheckDetailsBR;
        private ILogger _logException;
        public OnlineExamStudentQuePaperCheckDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamStudentQuePaperCheckDetailsBR = new OnlineExamStudentQuePaperCheckDetailsBR();
            _OnlineExamStudentQuePaperCheckDetailsDataProvider = new OnlineExamStudentQuePaperCheckDetailsDataProvider();
        }

        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> GetOnlineExamStudentQuePaperCheckDetails(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentQuePaperCheckDetailsDataProvider.GetOnlineExamStudentQuePaperCheckDetails(searchRequest);
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
      
        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationStudentApplicableList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentQuePaperCheckDetailsDataProvider.OnlineExamExaminationStudentApplicableList(searchRequest);
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

        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationViewQuestionsList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamStudentQuePaperCheckDetailsDataProvider.OnlineExamExaminationViewQuestionsList(searchRequest);
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

        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> MarksObtainInExamination(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> entityResponse = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamStudentQuePaperCheckDetailsDataProvider.MarksObtainInExamination(item);
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
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineDescriptiveIsCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> entityResponse = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamStudentQuePaperCheckDetailsDataProvider.OnlineDescriptiveIsCheckedQuestion(item);
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

        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamIsAllCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> entityResponse = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
            try
            {
                if (_OnlineExamStudentQuePaperCheckDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamStudentQuePaperCheckDetailsDataProvider.OnlineExamIsAllCheckedQuestion(item);
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

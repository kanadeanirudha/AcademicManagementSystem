
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
    public class OnlineExamExaminationQuePaperDetailsBA : IOnlineExamExaminationQuePaperDetailsBA
    {
        IOnlineExamExaminationQuePaperDetailsDataProvider _OnlineExamExaminationQuePaperDetailsDataProvider;
        IOnlineExamExaminationQuePaperDetailsBR _OnlineExamExaminationQuePaperDetailsBR;
        private ILogger _logException;
        public OnlineExamExaminationQuePaperDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamExaminationQuePaperDetailsBR = new OnlineExamExaminationQuePaperDetailsBR();
            _OnlineExamExaminationQuePaperDetailsDataProvider = new OnlineExamExaminationQuePaperDetailsDataProvider();
        }

        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetOnlineExamExaminationQuePaperDetails(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamExaminationQuePaperDetailsDataProvider.GetOnlineExamExaminationQuePaperDetails(searchRequest);
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
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetListQuestionBankMaster(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamExaminationQuePaperDetailsDataProvider.GetListQuestionBankMaster(searchRequest);
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
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamExaminationQuePaperDetailsDataProvider.OnlineExamExaminationQuestionsList(searchRequest);
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

        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationViewQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                    OnlineExamCollection = _OnlineExamExaminationQuePaperDetailsDataProvider.OnlineExamExaminationViewQuestionsList(searchRequest);
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
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> AddQuestionToExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> entityResponse = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamExaminationQuePaperDetailsDataProvider.AddQuestionToExamPaper(item);
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
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> RemoveQuestionFromExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> entityResponse = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamExaminationQuePaperDetailsDataProvider.RemoveQuestionFromExamPaper(item);
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
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> QuestionPaperFinalSubmit(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> entityResponse = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
            try
            {
                if (_OnlineExamExaminationQuePaperDetailsDataProvider != null)
                {
                    entityResponse = _OnlineExamExaminationQuePaperDetailsDataProvider.QuestionPaperFinalSubmit(item);
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

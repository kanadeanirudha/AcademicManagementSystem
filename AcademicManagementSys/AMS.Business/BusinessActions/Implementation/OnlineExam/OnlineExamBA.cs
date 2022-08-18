
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
    public class OnlineExamBA : IOnlineExamBA
    {
        IOnlineExamDataProvider _OnlineExamDataProvider;
        IOnlineExamBR _OnlineExamBR;
        private ILogger _logException;
        public OnlineExamBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamBR = new OnlineExamBR();
            _OnlineExamDataProvider = new OnlineExamDataProvider();
        }

        public IBaseEntityCollectionResponse<OnlineExam> GetOnlineExamsPerStudentBySearch(OnlineExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExam> OnlineExamCollection = new BaseEntityCollectionResponse<OnlineExam>();
            try
            {
                if (_OnlineExamDataProvider != null)
                    OnlineExamCollection = _OnlineExamDataProvider.GetOnlineExamsPerStudentBySearch(searchRequest);
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

        public IBaseEntityResponse<OnlineExam> SelectOnlineExamDetails(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> entityResponse = new BaseEntityResponse<OnlineExam>();
            try
            {
                if (_OnlineExamDataProvider != null)
                {
                    entityResponse = _OnlineExamDataProvider.SelectOnlineExamDetails(item);
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

        public IBaseEntityResponse<OnlineExam> SelectOnlineExamQuestion(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> entityResponse = new BaseEntityResponse<OnlineExam>();
            try
            {
                if (_OnlineExamDataProvider != null)
                {
                    entityResponse = _OnlineExamDataProvider.SelectOnlineExamQuestion(item);
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

        public IBaseEntityResponse<OnlineExam> OnlineExamSaveAnswer(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> entityResponse = new BaseEntityResponse<OnlineExam>();
            try
            {
                if (_OnlineExamDataProvider != null)
                {
                    entityResponse = _OnlineExamDataProvider.OnlineExamSaveAnswer(item);
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

        public IBaseEntityResponse<OnlineExam> OnlineExamFinalSubmit(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> entityResponse = new BaseEntityResponse<OnlineExam>();
            try
            {
                if (_OnlineExamDataProvider != null)
                {
                    entityResponse = _OnlineExamDataProvider.OnlineExamFinalSubmit(item);
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

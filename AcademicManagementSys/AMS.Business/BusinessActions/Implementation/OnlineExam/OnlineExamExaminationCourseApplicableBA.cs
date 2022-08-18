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
    public class OnlineExamExaminationCourseApplicableBA : IOnlineExamExaminationCourseApplicableBA
    {
        IOnlineExamExaminationCourseApplicableDataProvider _OnlineExamExaminationCourseApplicableDataProvider;
        IOnlineExamExaminationCourseApplicableBR _OnlineExamExaminationCourseApplicableBR;
        private ILogger _logException;
        public OnlineExamExaminationCourseApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamExaminationCourseApplicableBR = new OnlineExamExaminationCourseApplicableBR();
            _OnlineExamExaminationCourseApplicableDataProvider = new OnlineExamExaminationCourseApplicableDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamExaminationCourseApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationCourseApplicableBR.InsertOnlineExamExaminationCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationCourseApplicableDataProvider.InsertOnlineExamExaminationCourseApplicable(item);
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
        /// Update a specific record  of OnlineExamExaminationCourseApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationCourseApplicableBR.UpdateOnlineExamExaminationCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationCourseApplicableDataProvider.UpdateOnlineExamExaminationCourseApplicable(item);
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
        /// Delete a selected record from OnlineExamExaminationCourseApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationCourseApplicableBR.DeleteOnlineExamExaminationCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationCourseApplicableDataProvider.DeleteOnlineExamExaminationCourseApplicable(item);
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
        /// Select all record from OnlineExamExaminationCourseApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> OnlineExamExaminationCourseApplicableCollection = new BaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                if (_OnlineExamExaminationCourseApplicableDataProvider != null)
                    OnlineExamExaminationCourseApplicableCollection = _OnlineExamExaminationCourseApplicableDataProvider.GetOnlineExamExaminationCourseApplicableBySearch(searchRequest);
                else
                {
                    OnlineExamExaminationCourseApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationCourseApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationCourseApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationCourseApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationCourseApplicableCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> OnlineExamExaminationCourseApplicableCollection = new BaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                if (_OnlineExamExaminationCourseApplicableDataProvider != null)
                    OnlineExamExaminationCourseApplicableCollection = _OnlineExamExaminationCourseApplicableDataProvider.GetOnlineExamExaminationCourseApplicableSearchList(searchRequest);
                else
                {
                    OnlineExamExaminationCourseApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationCourseApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationCourseApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationCourseApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationCourseApplicableCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamExaminationCourseApplicable table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> SelectByID(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                entityResponse = _OnlineExamExaminationCourseApplicableDataProvider.GetOnlineExamExaminationCourseApplicableByID(item);
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

        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationCourseApplicableBR.DeleteOnlineExamExaminationCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationCourseApplicableDataProvider.AnnounceResult(item);
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


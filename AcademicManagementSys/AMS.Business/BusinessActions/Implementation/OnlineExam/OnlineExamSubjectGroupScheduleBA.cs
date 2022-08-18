


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
    public class OnlineExamSubjectGroupScheduleBA : IOnlineExamSubjectGroupScheduleBA
    {
        IOnlineExamSubjectGroupScheduleDataProvider _OnlineExamSubjectGroupScheduleDataProvider;
        IOnlineExamSubjectGroupScheduleBR _OnlineExamSubjectGroupScheduleBR;
        private ILogger _logException;
        public OnlineExamSubjectGroupScheduleBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamSubjectGroupScheduleBR = new OnlineExamSubjectGroupScheduleBR();
            _OnlineExamSubjectGroupScheduleDataProvider = new OnlineExamSubjectGroupScheduleDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamSubjectGroupSchedule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> InsertOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> entityResponse = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamSubjectGroupScheduleBR.InsertOnlineExamSubjectGroupScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamSubjectGroupScheduleDataProvider.InsertOnlineExamSubjectGroupSchedule(item);
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
        /// Update a specific record  of OnlineExamSubjectGroupSchedule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> UpdateOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> entityResponse = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamSubjectGroupScheduleBR.UpdateOnlineExamSubjectGroupScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamSubjectGroupScheduleDataProvider.UpdateOnlineExamSubjectGroupSchedule(item);
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
        /// Delete a selected record from OnlineExamSubjectGroupSchedule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> entityResponse = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamSubjectGroupScheduleBR.DeleteOnlineExamSubjectGroupScheduleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamSubjectGroupScheduleDataProvider.DeleteOnlineExamSubjectGroupSchedule(item);
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
        /// Select all record from OnlineExamSubjectGroupSchedule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetBySearch(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> OnlineExamSubjectGroupScheduleCollection = new BaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                if (_OnlineExamSubjectGroupScheduleDataProvider != null)
                    OnlineExamSubjectGroupScheduleCollection = _OnlineExamSubjectGroupScheduleDataProvider.GetOnlineExamSubjectGroupScheduleBySearch(searchRequest);
                else
                {
                    OnlineExamSubjectGroupScheduleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamSubjectGroupScheduleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamSubjectGroupScheduleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamSubjectGroupScheduleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamSubjectGroupScheduleCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleSearchList(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> OnlineExamSubjectGroupScheduleCollection = new BaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                if (_OnlineExamSubjectGroupScheduleDataProvider != null)
                    OnlineExamSubjectGroupScheduleCollection = _OnlineExamSubjectGroupScheduleDataProvider.GetOnlineExamSubjectGroupScheduleSearchList(searchRequest);
                else
                {
                    OnlineExamSubjectGroupScheduleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamSubjectGroupScheduleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamSubjectGroupScheduleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamSubjectGroupScheduleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamSubjectGroupScheduleCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamSubjectGroupSchedule table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> SelectByID(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> entityResponse = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            try
            {
                entityResponse = _OnlineExamSubjectGroupScheduleDataProvider.GetOnlineExamSubjectGroupScheduleByID(item);
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


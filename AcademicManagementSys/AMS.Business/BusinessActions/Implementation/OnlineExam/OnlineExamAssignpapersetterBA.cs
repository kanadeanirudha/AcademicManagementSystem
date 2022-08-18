
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
    public class OnlineExamAssignpapersetterBA : IOnlineExamAssignpapersetterBA
    {
        IOnlineExamAssignpapersetterDataProvider _OnlineExamAssignpapersetterDataProvider;
        IOnlineExamAssignpapersetterBR _OnlineExamAssignpapersetterBR;
        private ILogger _logException;
        public OnlineExamAssignpapersetterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamAssignpapersetterBR = new OnlineExamAssignpapersetterBR();
            _OnlineExamAssignpapersetterDataProvider = new OnlineExamAssignpapersetterDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamAssignpapersetter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> InsertOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> entityResponse = new BaseEntityResponse<OnlineExamAssignpapersetter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignpapersetterBR.InsertOnlineExamAssignpapersetterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignpapersetterDataProvider.InsertOnlineExamAssignpapersetter(item);
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
        /// Update a specific record  of OnlineExamAssignpapersetter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> UpdateOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> entityResponse = new BaseEntityResponse<OnlineExamAssignpapersetter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignpapersetterBR.UpdateOnlineExamAssignpapersetterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignpapersetterDataProvider.UpdateOnlineExamAssignpapersetter(item);
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
        /// Delete a selected record from OnlineExamAssignpapersetter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> entityResponse = new BaseEntityResponse<OnlineExamAssignpapersetter>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignpapersetterBR.DeleteOnlineExamAssignpapersetterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignpapersetterDataProvider.DeleteOnlineExamAssignpapersetter(item);
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
        /// Select all record from OnlineExamAssignpapersetter table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetBySearch(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> OnlineExamAssignpapersetterCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
            try
            {
                if (_OnlineExamAssignpapersetterDataProvider != null)
                    OnlineExamAssignpapersetterCollection = _OnlineExamAssignpapersetterDataProvider.GetOnlineExamAssignpapersetterBySearch(searchRequest);
                else
                {
                    OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignpapersetterCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamSupportStaffSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> OnlineExamAssignpapersetterCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
            try
            {
                if (_OnlineExamAssignpapersetterDataProvider != null)
                    OnlineExamAssignpapersetterCollection = _OnlineExamAssignpapersetterDataProvider.GetOnlineExamSupportStaffSearchList(searchRequest);
                else
                {
                    OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignpapersetterCollection;
        }


        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> OnlineExamAssignpapersetterCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
            try
            {
                if (_OnlineExamAssignpapersetterDataProvider != null)
                    OnlineExamAssignpapersetterCollection = _OnlineExamAssignpapersetterDataProvider.GetOnlineExamAssignpapersetterSearchList(searchRequest);
                else
                {
                    OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignpapersetterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignpapersetterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignpapersetterCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamAssignpapersetter table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> SelectByID(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> entityResponse = new BaseEntityResponse<OnlineExamAssignpapersetter>();
            try
            {
                entityResponse = _OnlineExamAssignpapersetterDataProvider.GetOnlineExamAssignpapersetterByID(item);
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

        public IBaseEntityResponse<OnlineExamAssignpapersetter> OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> entityResponse = new BaseEntityResponse<OnlineExamAssignpapersetter>();
            try
            {
                if (_OnlineExamAssignpapersetterDataProvider != null)
                {
                    entityResponse = _OnlineExamAssignpapersetterDataProvider.OnlineExamSelectQuestionPaper(item);
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

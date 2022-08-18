
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
    public class OnlineExamAssignPaperCheckerBA : IOnlineExamAssignPaperCheckerBA
    {
        IOnlineExamAssignPaperCheckerDataProvider _OnlineExamAssignPaperCheckerDataProvider;
        IOnlineExamAssignPaperCheckerBR _OnlineExamAssignPaperCheckerBR;
        private ILogger _logException;
        public OnlineExamAssignPaperCheckerBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamAssignPaperCheckerBR = new OnlineExamAssignPaperCheckerBR();
            _OnlineExamAssignPaperCheckerDataProvider = new OnlineExamAssignPaperCheckerDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamAssignPaperChecker.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> InsertOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            IBaseEntityResponse<OnlineExamAssignPaperChecker> entityResponse = new BaseEntityResponse<OnlineExamAssignPaperChecker>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignPaperCheckerBR.InsertOnlineExamAssignPaperCheckerValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignPaperCheckerDataProvider.InsertOnlineExamAssignPaperChecker(item);
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
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> UpdateOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            IBaseEntityResponse<OnlineExamAssignPaperChecker> entityResponse = new BaseEntityResponse<OnlineExamAssignPaperChecker>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignPaperCheckerBR.UpdateOnlineExamAssignPaperCheckerValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignPaperCheckerDataProvider.UpdateOnlineExamAssignPaperChecker(item);
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
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> DeleteOnlineExamAssignPaperChecker(OnlineExamAssignPaperChecker item)
        {
            IBaseEntityResponse<OnlineExamAssignPaperChecker> entityResponse = new BaseEntityResponse<OnlineExamAssignPaperChecker>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAssignPaperCheckerBR.DeleteOnlineExamAssignPaperCheckerValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAssignPaperCheckerDataProvider.DeleteOnlineExamAssignPaperChecker(item);
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
        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetBySearch(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> OnlineExamAssignPaperCheckerCollection = new BaseEntityCollectionResponse<OnlineExamAssignPaperChecker>();
            try
            {
                if (_OnlineExamAssignPaperCheckerDataProvider != null)
                    OnlineExamAssignPaperCheckerCollection = _OnlineExamAssignPaperCheckerDataProvider.GetOnlineExamAssignPaperCheckerBySearch(searchRequest);
                else
                {
                    OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignPaperCheckerCollection;
        }
        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamSupportStaffSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> OnlineExamAssignPaperCheckerCollection = new BaseEntityCollectionResponse<OnlineExamAssignPaperChecker>();
            try
            {
                if (_OnlineExamAssignPaperCheckerDataProvider != null)
                    OnlineExamAssignPaperCheckerCollection = _OnlineExamAssignPaperCheckerDataProvider.GetOnlineExamSupportStaffSearchList(searchRequest);
                else
                {
                    OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignPaperCheckerCollection;
        }


        public IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> GetOnlineExamAssignPaperCheckerSearchList(OnlineExamAssignPaperCheckerSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignPaperChecker> OnlineExamAssignPaperCheckerCollection = new BaseEntityCollectionResponse<OnlineExamAssignPaperChecker>();
            try
            {
                if (_OnlineExamAssignPaperCheckerDataProvider != null)
                    OnlineExamAssignPaperCheckerCollection = _OnlineExamAssignPaperCheckerDataProvider.GetOnlineExamAssignPaperCheckerSearchList(searchRequest);
                else
                {
                    OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAssignPaperCheckerCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAssignPaperCheckerCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAssignPaperCheckerCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamAssignPaperChecker table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignPaperChecker> SelectByID(OnlineExamAssignPaperChecker item)
        {
            IBaseEntityResponse<OnlineExamAssignPaperChecker> entityResponse = new BaseEntityResponse<OnlineExamAssignPaperChecker>();
            try
            {
                entityResponse = _OnlineExamAssignPaperCheckerDataProvider.GetOnlineExamAssignPaperCheckerByID(item);
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

        public IBaseEntityResponse<OnlineExamAssignPaperChecker> OnlineExamSelectQuestionPaper(OnlineExamAssignPaperChecker item)
        {
            IBaseEntityResponse<OnlineExamAssignPaperChecker> entityResponse = new BaseEntityResponse<OnlineExamAssignPaperChecker>();
            try
            {
                if (_OnlineExamAssignPaperCheckerDataProvider != null)
                {
                    entityResponse = _OnlineExamAssignPaperCheckerDataProvider.OnlineExamSelectQuestionPaper(item);
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

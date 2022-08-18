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
    public class OnlineExaminationMasterAndCourseApplicableBA : IOnlineExaminationMasterAndCourseApplicableBA
    {
        IOnlineExaminationMasterAndCourseApplicableDataProvider onlineExaminationMasterAndCourseApplicableDataProvider;
        IOnlineExaminationMasterAndCourseApplicableBR onlineExaminationMasterAndCourseApplicableBR;

        private ILogger _logException;

        public OnlineExaminationMasterAndCourseApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later.
            onlineExaminationMasterAndCourseApplicableDataProvider = new OnlineExaminationMasterAndCourseApplicableDataProvider();
            onlineExaminationMasterAndCourseApplicableBR = new OnlineExaminationMasterAndCourseApplicableBR();
        }

        /// Create new record of OnlineExaminationMasterAndCourseApplicable.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> InsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = onlineExaminationMasterAndCourseApplicableBR.InsertOnlineExaminationMasterAndCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = onlineExaminationMasterAndCourseApplicableDataProvider.InsertOnlineExaminationMasterAndCourseApplicable(item);
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

        /// Update a specific record  of OnlineExaminationMasterAndCourseApplicable.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> UpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = onlineExaminationMasterAndCourseApplicableBR.UpdateOnlineExaminationMasterAndCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = onlineExaminationMasterAndCourseApplicableDataProvider.UpdateOnlineExaminationMasterAndCourseApplicable(item);
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

        /// Delete a selected record from OnlineExaminationMasterAndCourseApplicable.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> DeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = onlineExaminationMasterAndCourseApplicableBR.DeleteOnlineExaminationMasterAndCourseApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = onlineExaminationMasterAndCourseApplicableDataProvider.DeleteOnlineExaminationMasterAndCourseApplicable(item);
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

        /// Select all record from OnlineExaminationMasterAndCourseApplicable table with search parameters.
        public IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> GetOnlineExaminationMasterAndCourseApplicableSelectAll(OnlineExaminationMasterAndCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> OnlineEntranceExamQuestionBankMasterCollection = new BaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable>();
            try
            {
                if (onlineExaminationMasterAndCourseApplicableDataProvider != null)
                    OnlineEntranceExamQuestionBankMasterCollection = onlineExaminationMasterAndCourseApplicableDataProvider.GetOnlineExaminationMasterAndCourseApplicableSelectAll(searchRequest);
                else
                {
                    OnlineEntranceExamQuestionBankMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineEntranceExamQuestionBankMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineEntranceExamQuestionBankMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineEntranceExamQuestionBankMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineEntranceExamQuestionBankMasterCollection;
        }

        /// Select a record from OnlineExaminationMasterAndCourseApplicable table by ID
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> SelectOnlineExaminationMasterAndCourseApplicableByID(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> entityResponse = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
            try
            {
                entityResponse = onlineExaminationMasterAndCourseApplicableDataProvider.SelectOnlineExaminationMasterAndCourseApplicableByID(item);
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

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
    public class OnlineEntranceExamQuestionBankMasterBA : IOnlineEntranceExamQuestionBankMasterBA
    {
        IOnlineEntranceExamQuestionBankMasterDataProvider _OnlineEntranceExamQuestionBankMasterDataProvider;
        IOnlineEntranceExamQuestionBankMasterBR _OnlineEntranceExamQuestionBankMasterBR;
        private ILogger _logException;

        public OnlineEntranceExamQuestionBankMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later.
            _OnlineEntranceExamQuestionBankMasterBR = new OnlineEntranceExamQuestionBankMasterBR();
            _OnlineEntranceExamQuestionBankMasterDataProvider = new OnlineEntranceExamQuestionBankMasterDataProvider();
        }

        /// Create new record of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertSubjectOnlineExamQuestionBank(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> entityResponse = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineEntranceExamQuestionBankMasterBR.InsertSubjectOnlineExamQuestionBankValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineEntranceExamQuestionBankMasterDataProvider.InsertSubjectOnlineExamQuestionBank(item);
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

        /// Create new record of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> entityResponse = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineEntranceExamQuestionBankMasterBR.InsertOnlineEntranceExamQuestionBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineEntranceExamQuestionBankMasterDataProvider.InsertOnlineEntranceExamQuestionBankMaster(item);
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

        /// Update a specific record  of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> UpdateOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> entityResponse = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineEntranceExamQuestionBankMasterBR.UpdateOnlineEntranceExamQuestionBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineEntranceExamQuestionBankMasterDataProvider.UpdateOnlineEntranceExamQuestionBankMaster(item);
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

        /// Delete a selected record from OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> DeleteOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> entityResponse = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineEntranceExamQuestionBankMasterBR.DeleteOnlineEntranceExamQuestionBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineEntranceExamQuestionBankMasterDataProvider.DeleteOnlineEntranceExamQuestionBankMaster(item);
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

        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters.
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetOnlineEntranceExamQuestionBankMasterSelectAll(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> OnlineEntranceExamQuestionBankMasterCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    OnlineEntranceExamQuestionBankMasterCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetOnlineEntranceExamQuestionBankMasterSelectAll(searchRequest);
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

        /// Select a record from OnlineEntranceExamQuestionBankMaster table by ID
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> SelectOnlineEntranceExamQuestionBankMasterByID(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> entityResponse = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                entityResponse = _OnlineEntranceExamQuestionBankMasterDataProvider.SelectOnlineEntranceExamQuestionBankMasterByID(item);
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

        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters.
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> courseCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    courseCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetCourseByCentreCodeAndUniversity(searchRequest);
                else
                {
                    courseCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    courseCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                courseCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                courseCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return courseCollection;
        }


        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters.
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> courseYearCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    courseYearCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetCourseYearFromBranchMasterID(searchRequest);
                else
                {
                    courseYearCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    courseYearCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                courseYearCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                courseYearCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return courseYearCollection;
        }

        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters.
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> courseYearCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    courseYearCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetSubjectGroupFromCourseYearDetail(searchRequest);
                else
                {
                    courseYearCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    courseYearCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                courseYearCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                courseYearCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return courseYearCollection;
        }



        /// Select all record from GeneralQuestionLevelMasterList table with search parameters.
        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterList(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> generalQuestionLevelMasterListCollection = new BaseEntityCollectionResponse<GeneralQuestionLevelMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    generalQuestionLevelMasterListCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetGeneralQuestionLevelMasterList(searchRequest);
                else
                {
                    generalQuestionLevelMasterListCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    generalQuestionLevelMasterListCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                generalQuestionLevelMasterListCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                generalQuestionLevelMasterListCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return generalQuestionLevelMasterListCollection;
        }


        /// Select all record from OrganisationSyllabusGroupMaster table with search parameters.
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupUnitList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> syllabusGroupMasterCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    syllabusGroupMasterCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetSyllabusGroupUnitList(searchRequest);
                else
                {
                    syllabusGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    syllabusGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                syllabusGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                syllabusGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return syllabusGroupMasterCollection;
        }



        /// Select all record from SyllabusGroupTopicMasterList table with search parameters.
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupTopicMasterList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> syllabusGroupTopicCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    syllabusGroupTopicCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetSyllabusGroupTopicMasterList(searchRequest);
                else
                {
                    syllabusGroupTopicCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    syllabusGroupTopicCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                syllabusGroupTopicCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                syllabusGroupTopicCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return syllabusGroupTopicCollection;
        }


        /// Select all record from QuestionBankAndDetailList table with search parameters.
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> questionAnswerCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
            try
            {
                if (_OnlineEntranceExamQuestionBankMasterDataProvider != null)
                    questionAnswerCollection = _OnlineEntranceExamQuestionBankMasterDataProvider.GetQuestionBankAndDetailList(searchRequest);
                else
                {
                    questionAnswerCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    questionAnswerCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                questionAnswerCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                questionAnswerCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return questionAnswerCollection;
        }
    }
}

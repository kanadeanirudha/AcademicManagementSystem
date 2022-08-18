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
using AMS.Business.BusinessActions;

namespace AMS.Business.BusinessActions
{
    public class EntranceExamApplicableExamToCourseBA : IEntranceExamApplicableExamToCourseBA
    {
        IEntranceExamApplicableExamToCourseDataProvider _EntranceExamApplicableExamToCourseDataProvider;
        IEntranceExamApplicableExamToCourseBR _EntranceExamApplicableExamToCourseBR;
        private ILogger _logException;
        public EntranceExamApplicableExamToCourseBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EntranceExamApplicableExamToCourseBR = new EntranceExamApplicableExamToCourseBR();
            _EntranceExamApplicableExamToCourseDataProvider = new EntranceExamApplicableExamToCourseDataProvider();
        }
        /// <summary>
        /// Create new record of EntranceExamApplicableExamToCourse.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> InsertEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> entityResponse = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamApplicableExamToCourseBR.InsertEntranceExamApplicableExamToCourseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamApplicableExamToCourseDataProvider.InsertEntranceExamApplicableExamToCourse(item);
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
        /// Update a specific record  of EntranceExamApplicableExamToCourse.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> UpdateEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> entityResponse = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamApplicableExamToCourseBR.UpdateEntranceExamApplicableExamToCourseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamApplicableExamToCourseDataProvider.UpdateEntranceExamApplicableExamToCourse(item);
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
        /// Delete a selected record from EntranceExamApplicableExamToCourse.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> DeleteEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> entityResponse = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EntranceExamApplicableExamToCourseBR.DeleteEntranceExamApplicableExamToCourseValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EntranceExamApplicableExamToCourseDataProvider.DeleteEntranceExamApplicableExamToCourse(item);
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
        /// Select all record from EntranceExamApplicableExamToCourse table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetBySearch(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> EntranceExamApplicableExamToCourseCollection = new BaseEntityCollectionResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                if (_EntranceExamApplicableExamToCourseDataProvider != null)
                    EntranceExamApplicableExamToCourseCollection = _EntranceExamApplicableExamToCourseDataProvider.GetEntranceExamApplicableExamToCourseBySearch(searchRequest);
                else
                {
                    EntranceExamApplicableExamToCourseCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamApplicableExamToCourseCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamApplicableExamToCourseCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamApplicableExamToCourseCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamApplicableExamToCourseCollection;
        }

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster

        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetExaminationNameByCourseID(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> EntranceExamApplicableExamToCourseCollection = new BaseEntityCollectionResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                if (_EntranceExamApplicableExamToCourseDataProvider != null)
                    EntranceExamApplicableExamToCourseCollection = _EntranceExamApplicableExamToCourseDataProvider.GetExaminationNameByCourseID(searchRequest);
                else
                {
                    EntranceExamApplicableExamToCourseCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EntranceExamApplicableExamToCourseCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EntranceExamApplicableExamToCourseCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EntranceExamApplicableExamToCourseCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EntranceExamApplicableExamToCourseCollection;
        }
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> SelectByID(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> entityResponse = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
            try
            {
                entityResponse = _EntranceExamApplicableExamToCourseDataProvider.GetEntranceExamApplicableExamToCourseByID(item);
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

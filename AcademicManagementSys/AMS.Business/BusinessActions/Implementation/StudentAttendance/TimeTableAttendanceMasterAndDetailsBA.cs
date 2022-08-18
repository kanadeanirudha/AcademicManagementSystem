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
namespace AMS.Business
{
    public class TimeTableAttendanceMasterAndDetailsBA : ITimeTableAttendanceMasterAndDetailsBA
    {
        ITimeTableAttendanceMasterAndDetailsDataProvider _TimeTableAttendanceMasterAndDetailsDataProvider;
        ITimeTableAttendanceMasterAndDetailsBR _TimeTableAttendanceMasterAndDetailsBR;
        private ILogger _logException;
        public TimeTableAttendanceMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _TimeTableAttendanceMasterAndDetailsBR = new TimeTableAttendanceMasterAndDetailsBR();
            _TimeTableAttendanceMasterAndDetailsDataProvider = new TimeTableAttendanceMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of TimeTableAttendanceMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> InsertTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> entityResponse = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TimeTableAttendanceMasterAndDetailsBR.InsertTimeTableAttendanceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TimeTableAttendanceMasterAndDetailsDataProvider.InsertTimeTableAttendanceMasterAndDetails(item);
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
        /// Update a specific record  of TimeTableAttendanceMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> UpdateTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> entityResponse = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TimeTableAttendanceMasterAndDetailsBR.UpdateTimeTableAttendanceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TimeTableAttendanceMasterAndDetailsDataProvider.UpdateTimeTableAttendanceMasterAndDetails(item);
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
        /// Delete a selected record from TimeTableAttendanceMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> DeleteTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> entityResponse = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TimeTableAttendanceMasterAndDetailsBR.DeleteTimeTableAttendanceMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TimeTableAttendanceMasterAndDetailsDataProvider.DeleteTimeTableAttendanceMasterAndDetails(item);
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
        /// Select all record from TimeTableAttendanceMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetStudentSearchList(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> TimeTableAttendanceMasterAndDetailsCollection = new BaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails>();
            try
            {
                if (_TimeTableAttendanceMasterAndDetailsDataProvider != null)
                    TimeTableAttendanceMasterAndDetailsCollection = _TimeTableAttendanceMasterAndDetailsDataProvider.GetStudentSearchList(searchRequest);
                else
                {
                    TimeTableAttendanceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TimeTableAttendanceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TimeTableAttendanceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TimeTableAttendanceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TimeTableAttendanceMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select all record from TimeTableAttendanceMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetBySearch(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> TimeTableAttendanceMasterAndDetailsCollection = new BaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails>();
            try
            {
                if (_TimeTableAttendanceMasterAndDetailsDataProvider != null)
                    TimeTableAttendanceMasterAndDetailsCollection = _TimeTableAttendanceMasterAndDetailsDataProvider.GetTimeTableAttendanceMasterAndDetailsBySearch(searchRequest);
                else
                {
                    TimeTableAttendanceMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TimeTableAttendanceMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TimeTableAttendanceMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                TimeTableAttendanceMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TimeTableAttendanceMasterAndDetailsCollection;
        }
     
    }
}

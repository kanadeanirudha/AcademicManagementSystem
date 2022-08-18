using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using AMS.DataProvider.Implementation.OnlineExam;

namespace AMS.DataProvider
{
    public class OnlineExamSubjectGroupScheduleDataProvider : DBInteractionBase, IOnlineExamSubjectGroupScheduleDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamSubjectGroupScheduleDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamSubjectGroupScheduleDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExamSubjectGroupSchedule table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleBySearch(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectSchedule_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenSessionMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GenSessionMaster));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<OnlineExamSubjectGroupSchedule>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamSubjectGroupSchedule item = new OnlineExamSubjectGroupSchedule();
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Purpose"]) == false)
                        {
                            item.Purpose = Convert.ToString(sqlDataReader["Purpose"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcadSessionID"]) == false)
                        {
                            item.AcadSessionID = Convert.ToInt32(sqlDataReader["AcadSessionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationFor"]) == false)
                        {
                            item.ExaminationFor = Convert.ToString(sqlDataReader["ExaminationFor"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"]) == false)
                        {
                            item.OnlineExamExaminationCourseApplicableID = Convert.ToInt16(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchID"]) == false)
                        {
                            item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SemesterMstID"]) == false)
                        {
                            item.SemesterMstID = Convert.ToInt32(sqlDataReader["SemesterMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"]) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupID"]) == false)
                        {
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDescription"]) == false)
                        {
                            item.SubjectGroupDescription = Convert.ToString(sqlDataReader["SubjectGroupDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectShortDescription"]) == false)
                        {
                            item.SubjectShortDescription = Convert.ToString(sqlDataReader["SubjectShortDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ViewFlag"]) == false)
                        {
                            item.ViewFlag = Convert.ToBoolean(sqlDataReader["ViewFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"]) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearName"]) == false)
                        {
                            item.CourseYearName = Convert.ToString(sqlDataReader["CourseYearName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearCode"]) == false)
                        {
                            item.CourseYearCode = Convert.ToString(sqlDataReader["CourseYearCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgSemesterName"]) == false)
                        {
                            item.OrgSemesterName = Convert.ToString(sqlDataReader["OrgSemesterName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStartDate"]) == false)
                        {
                            item.ExaminationStartDate = Convert.ToString(sqlDataReader["ExaminationStartDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStartTime"]) == false)
                        {
                            item.ExaminationStartTime = Convert.ToString(sqlDataReader["ExaminationStartTime"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamSubjectGroupSchedule_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleByID(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectGroupSchedule_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamSubjectGroupSchedule _item = new OnlineExamSubjectGroupSchedule();
                        _item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"]) == false)
                        {
                            _item.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankMasterID"]) == false)
                        {
                            _item.OnlineExamQuestionBankMasterID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            _item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            _item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupID"]) == false)
                        {
                            _item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStartDate"]) == false)
                        {
                            _item.ExaminationStartDate = sqlDataReader["ExaminationStartDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationEndDate"]) == false)
                        {
                            _item.ExaminationEndDate = sqlDataReader["ExaminationEndDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStartTime"]) == false)
                        {
                            _item.ExaminationStartTime = sqlDataReader["ExaminationStartTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationEndTime"]) == false)
                        {
                            _item.ExaminationEndTime = sqlDataReader["ExaminationEndTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalQuestions"]) == false)
                        {
                            _item.TotalQuestions = Convert.ToByte(sqlDataReader["TotalQuestions"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalMarks"]) == false)
                        {
                            _item.TotalMarks = Convert.ToByte(sqlDataReader["TotalMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PassingMarks"]) == false)
                        {
                            _item.PassingMarks = Convert.ToByte(sqlDataReader["PassingMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarksForEachQues"]) == false)
                        {
                            _item.MarksForEachQues = Convert.ToByte(sqlDataReader["MarksForEachQues"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level1Marks"]) == false)
                        {
                            _item.Level1Marks = Convert.ToByte(sqlDataReader["Level1Marks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level2Marks"]) == false)
                        {
                            _item.Level2Marks = Convert.ToByte(sqlDataReader["Level2Marks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level3Marks"]) == false)
                        {
                            _item.Level3Marks = Convert.ToByte(sqlDataReader["Level3Marks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level1TimeInMinutes"]) == false)
                        {
                            _item.Level1TimeInMinutes = Convert.ToByte(sqlDataReader["Level1TimeInMinutes"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level2TimeInMinutes"]) == false)
                        {
                            _item.Level2TimeInMinutes = Convert.ToByte(sqlDataReader["Level2TimeInMinutes"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level3TimeInMinutes"]) == false)
                        {
                            _item.Level3TimeInMinutes = Convert.ToByte(sqlDataReader["Level3TimeInMinutes"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Level4TimeInMinutes"]) == false)
                        {
                            _item.Level4TimeInMinutes = Convert.ToByte(sqlDataReader["Level4TimeInMinutes"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FixedFlexibleTime"]) == false)
                        {
                            _item.FixedFlexibleTime = Convert.ToByte(sqlDataReader["FixedFlexibleTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExamDuration"]) == false)
                        {
                            _item.ExamDuration = Convert.ToByte(sqlDataReader["ExamDuration"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DayOpenTime"]) == false)
                        {
                            _item.DayOpenTime = Convert.ToByte(sqlDataReader["DayOpenTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DayCloseTime"]) == false)
                        {
                            _item.DayCloseTime = Convert.ToByte(sqlDataReader["DayCloseTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStatus"]) == false)
                        {
                            _item.ExaminationStatus = Convert.ToByte(sqlDataReader["ExaminationStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            _item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalPaperSet"]) == false)
                        {
                            _item.TotalPaperSet = Convert.ToByte(sqlDataReader["TotalPaperSet"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsNegavieMarking"]) == false)
                        {
                            _item.IsNegavieMarking = Convert.ToBoolean(sqlDataReader["IsNegavieMarking"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarksToBeDeducted"]) == false)
                        {
                            _item.MarksToBeDeducted = Convert.ToDecimal(sqlDataReader["MarksToBeDeducted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsScheduleForAllSections"]) == false)
                        {
                            _item.IsScheduleForAllSections = Convert.ToBoolean(sqlDataReader["IsScheduleForAllSections"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsTimeFlexible"]) == false)
                        {
                            _item.IsTimeFlexible = Convert.ToBoolean(sqlDataReader["IsTimeFlexible"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SectionScheduleList"]) == false)
                        {
                            _item.SectionScheduleList = Convert.ToString(sqlDataReader["SectionScheduleList"]);
                        }
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                //_logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> InsertOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectSchedule_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationCourseApplicableID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationCourseApplicableID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubjectGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExaminationStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExaminationEndDate));
                    if (item.ExaminationStartTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ExaminationStartTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExaminationEndTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ExaminationEndTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalQuestions", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.TotalQuestions));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalMarks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.TotalMarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPassingMarks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PassingMarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiMarksForEachQues", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MarksForEachQues));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel1Marks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level1Marks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel2Marks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level2Marks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel3Marks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level3Marks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel1TimeInMinutes", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level1TimeInMinutes));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel2TimeInMinutes", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level2TimeInMinutes));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel3TimeInMinutes", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level3TimeInMinutes));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiLevel4TimeInMinutes", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Level4TimeInMinutes));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFixedFlexibleTime", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FixedFlexibleTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiExamDuration", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExamDuration));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiDayOpenTime", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.DayOpenTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiDayCloseTime", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.DayCloseTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiExaminationStatus", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExaminationStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalPaperSet", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.TotalPaperSet));
                    if (item.ParameterXml != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSectionDetailXml", SqlDbType.Xml, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ParameterXml));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSectionDetailXml", SqlDbType.Xml, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNegavieMarking", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsNegavieMarking));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dMarksToBeDeducted", SqlDbType.Decimal, 10, 
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.MarksToBeDeducted));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsScheduleForAllSections", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsScheduleForAllSections));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTimeFlexible", SqlDbType.Bit, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.IsTimeFlexible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection. 
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iOnlineExamSubjectGroupScheduleID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_OnlineExamSubjectGroupSchedule_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamSubjectGroupSchedule_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Update a specific record of OnlineExamSubjectGroupSchedule
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> UpdateOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectGroupSchedule_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartDate", SqlDbType.DateTime, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.ExaminationStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExaminationEndDate));

                    if (item.ExaminationStartTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ExaminationStartTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ExaminationEndTime != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ExaminationEndTime));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalQuestions", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.TotalQuestions));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalMarks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.TotalMarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPassingMarks", SqlDbType.TinyInt, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PassingMarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTimeFlexible", SqlDbType.Bit, 0,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, item.IsTimeFlexible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection. 
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 25)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamSubjectGroupSchedule_Update' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleBySectionDetails(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectGroupSchedule_GetSectionDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                           ParameterDirection.Output, true, 10, 0, "",
                                           DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection. 
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamSubjectGroupSchedule_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }
        /// <summary>
        /// Delete a specific record of OnlineExamSubjectGroupSchedule
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            IBaseEntityResponse<OnlineExamSubjectGroupSchedule> response = new BaseEntityResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectGroupSchedule_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));

                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamSubjectGroupSchedule_Delete' reported the ErrorCode: " + _errorCode);
                    }

                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }


        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleSearchList(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSubjectGroupSchedule";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<OnlineExamSubjectGroupSchedule>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamSubjectGroupSchedule item = new OnlineExamSubjectGroupSchedule();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                    }



                    //while (sqlDataReader.Read())
                    //{
                    //    OnlineExamSubjectGroupSchedule item = new OnlineExamSubjectGroupSchedule();
                    //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    //    //item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                    //    //item.MarchandiseGroupCode = Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                    //    baseEntityCollection.CollectionResponse.Add(item);
                    //}
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamSubjectGroupSchedule_GetExamNameListForDropDown' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        #endregion
    }
}

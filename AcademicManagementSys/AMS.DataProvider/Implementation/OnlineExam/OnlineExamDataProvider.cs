using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider
{
    public class OnlineExamDataProvider : DBInteractionBase, IOnlineExamDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation

        public IBaseEntityCollectionResponse<OnlineExam> GetOnlineExamsPerStudentBySearch(OnlineExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetOnlineExamsPerStudent_ByStudentID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StudentID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExam>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExam item = new OnlineExam();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamIndStudentExamInfoID"].ToString()) == false)
                        {
                            item.OnlineExamIndStudentExamInfoID = Convert.ToInt32(sqlDataReader["OnlineExamIndStudentExamInfoID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"].ToString()) == false)
                        {
                            item.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"].ToString()) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationID"].ToString()) == false)
                        {
                            item.ExaminationID = Convert.ToInt32(sqlDataReader["ExaminationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationStartTime"].ToString()) == false)
                        {
                            item.ExaminationStartTime = Convert.ToString(sqlDataReader["ExaminationStartTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationEndTime"].ToString()) == false)
                        {
                            item.ExaminationEndTime = Convert.ToString(sqlDataReader["ExaminationEndTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationDate"].ToString()) == false)
                        {
                            item.ExaminationDate = Convert.ToString(sqlDataReader["ExaminationDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationEndDate"].ToString()) == false)
                        {
                            item.ExaminationEndDate = Convert.ToString(sqlDataReader["ExaminationEndDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExaminationOver"].ToString()) == false)
                        {
                            item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"].ToString()) == false)
                        {
                            item.SubjectName = Convert.ToString(sqlDataReader["SubjectName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExamStart"].ToString()) == false)
                        {
                            item.IsExamStart = Convert.ToBoolean(sqlDataReader["IsExamStart"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ResultAnnounceDate"].ToString()) == false)
                        {
                            item.ResultAnnounceDate = Convert.ToString(sqlDataReader["ResultAnnounceDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsResultAnnounce"].ToString()) == false)
                        {
                            item.IsResultAnnounce = Convert.ToBoolean(sqlDataReader["IsResultAnnounce"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralPaperSetMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<OnlineExam> SelectOnlineExamDetails(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> response = new BaseEntityResponse<OnlineExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamIndStudentExamInfoID));
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

                        OnlineExam _item = new OnlineExam();
                        _item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        _item.TotalQuestions = Convert.ToInt16(sqlDataReader["TotalQuestions"]);
                        _item.OnlineExamTimeDuration = Convert.ToString(sqlDataReader["OnlineExamTimeDuration"]);
                        _item.IsDescriptiveQuestionInExam = Convert.ToBoolean(sqlDataReader["IsDescriptiveQuestionInExam"]);
                        _item.IsObjectiveQuestionInExam = Convert.ToBoolean(sqlDataReader["IsObjectiveQuestionInExam"]);
                        _item.DescriptiveStartQuestionOrder = Convert.ToInt16(sqlDataReader["DescriptiveStartQuestionOrder"]);
                        _item.ObjectiveStartQuestionOrder = Convert.ToInt16(sqlDataReader["ObjectiveStartQuestionOrder"]);

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleGroupMasterAndAllocateEmployeeInGroup_SelectAll' reported the ErrorCode: " + _errorCode);
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
            return response;
        }

        public IBaseEntityResponse<OnlineExam> SelectOnlineExamQuestion(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> response = new BaseEntityResponse<OnlineExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestion_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamIndStudentExamInfoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siQuestionOrder", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionOrder));
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

                        OnlineExam _item = new OnlineExam();
                        _item.QuestionLableText = Convert.ToString(sqlDataReader["QuestionLableText"]);
                        _item.ImageType = Convert.ToString(sqlDataReader["ImageType"]);
                        _item.ImageName = Convert.ToString(sqlDataReader["ImageName"]);
                        _item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        _item.QuestionOrder = Convert.ToInt16(sqlDataReader["QuestionOrder"]);
                        _item.AnswerOptionID = Convert.ToInt32(sqlDataReader["AnswerOptionID"]);
                        _item.IsQuestionDescriptive = Convert.ToBoolean(sqlDataReader["IsQuestionDescriptive"]);
                        _item.IsAttachmentCompalsary = Convert.ToInt16(sqlDataReader["IsAttachmentCompalsary"]);
                        _item.OptionImage = Convert.ToString(sqlDataReader["OptionImageList"]);
                        _item.OptionText = Convert.ToString(sqlDataReader["OptionTextList"]);
                        _item.OptionIDsList = Convert.ToString(sqlDataReader["OptionIDsList"]);
                        _item.CurrentStatusList = Convert.ToString(sqlDataReader["CurrentStatusList"]);
                        _item.QuestionOrderList = Convert.ToString(sqlDataReader["QuestionOrderList"]);
                        _item.DescriptiveAnswer = Convert.ToString(sqlDataReader["DescriptiveAnswer"]);
                        _item.AttachedDocument = Convert.ToString(sqlDataReader["AttachedDocument"]);

                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleGroupMasterAndAllocateEmployeeInGroup_SelectAll' reported the ErrorCode: " + _errorCode);
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
            return response;
        }

        public IBaseEntityResponse<OnlineExam> OnlineExamSaveAnswer(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> response = new BaseEntityResponse<OnlineExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSaveAnswer_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamIndStudentExamInfoID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siQuestionOrder", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionOrder));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAnswerOptionID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AnswerOptionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCurrentStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurrentStatus));
                    if (item.DescriptiveAnswer != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDescriptiveAnswer", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DescriptiveAnswer));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDescriptiveAnswer", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AttachedDocument != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAttachedDocument", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AttachedDocument));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsAttachedDocument", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionDescriptive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsQuestionDescriptive));
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

                        OnlineExam _item = new OnlineExam();
                        _item.QuestionOrder = Convert.ToInt16(sqlDataReader["QuestionOrder"]);
                        
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleGroupMasterAndAllocateEmployeeInGroup_SelectAll' reported the ErrorCode: " + _errorCode);
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
            return response;
        }

        public IBaseEntityResponse<OnlineExam> OnlineExamFinalSubmit(OnlineExam item)
        {
            IBaseEntityResponse<OnlineExam> response = new BaseEntityResponse<OnlineExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamFinalSubmit_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamIndStudentExamInfoID));
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

                    //while (sqlDataReader.Read())
                    //{

                    //    OnlineExam _item = new OnlineExam();
                    //    _item.QuestionOrder = Convert.ToInt16(sqlDataReader["QuestionOrder"]);

                    //    response.Entity = _item;
                    //}

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleGroupMasterAndAllocateEmployeeInGroup_SelectAll' reported the ErrorCode: " + _errorCode);
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
            return response;
        }
        #endregion
    }
}

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
    public class OnlineExamStudentQuePaperCheckDetailsDataProvider : DBInteractionBase, IOnlineExamStudentQuePaperCheckDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamStudentQuePaperCheckDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamStudentQuePaperCheckDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation

        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> GetOnlineExamStudentQuePaperCheckDetails(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamStudentQuePaperCheck_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamStudentQuePaperCheckDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamStudentQuePaperCheckDetails item = new OnlineExamStudentQuePaperCheckDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionPaperCheckerID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionPaperCheckerID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionPaperCheckerID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"].ToString()) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"].ToString()) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"].ToString()) == false)
                        {
                            item.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupID"].ToString()) == false)
                        {
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"].ToString()) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectDescription"].ToString()) == false)
                        {
                            item.SubjectDescription = Convert.ToString(sqlDataReader["SubjectDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAllChecked"].ToString()) == false)
                        {
                            item.IsAllChecked = Convert.ToBoolean(sqlDataReader["IsAllChecked"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamStudentQuePaperCheck_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationStudentApplicableList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationStudentApplicableList_SelectByPaperChecker";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionPaperCheckerID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamQuestionPaperCheckerID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamStudentQuePaperCheckDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamStudentQuePaperCheckDetails item = new OnlineExamStudentQuePaperCheckDetails();

                        if (DBNull.Value.Equals(sqlDataReader["StudentName"].ToString()) == false)
                        {
                            item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"].ToString()) == false)
                        {
                            item.MiddleName = Convert.ToString(sqlDataReader["MiddleName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        {
                            item.LastName = Convert.ToString(sqlDataReader["LastName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionPaperCheckerID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionPaperCheckerID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionPaperCheckerID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamIndStudentExamInfoID"].ToString()) == false)
                        {
                            item.OnlineExamIndStudentExamInfoID = Convert.ToInt32(sqlDataReader["OnlineExamIndStudentExamInfoID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsChecked"].ToString()) == false)
                        {
                            item.IsChecked = Convert.ToBoolean(sqlDataReader["IsChecked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentID"].ToString()) == false)
                        {
                            item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExaminationOver"].ToString()) == false)
                        {
                            item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"].ToString()) == false)
                        {
                            item.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"].ToString()) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationStudentApplicableList_SelectByPaperChecker " + _errorCode);
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

        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationViewQuestionsList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionList_SelectByPaperChecker";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamIndStudentExamInfoID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamStudentQuePaperCheckDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamStudentQuePaperCheckDetails item = new OnlineExamStudentQuePaperCheckDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamIndQuestionPaperID"].ToString()) == false)
                        {
                            item.OnlineExamIndQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamIndQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"].ToString()) == false)
                        {
                            item.QuestionLableText = Convert.ToString(sqlDataReader["QuestionLableText"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageType"].ToString()) == false)
                        {
                            item.ImageType = Convert.ToString(sqlDataReader["ImageType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageName"].ToString()) == false)
                        {
                            item.ImageName = Convert.ToString(sqlDataReader["ImageName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankDetailsID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionBankDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DescriptiveAnswer"].ToString()) == false)
                        {
                            item.DescriptiveAnswer = Convert.ToString(sqlDataReader["DescriptiveAnswer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAttachmentCompalsary"].ToString()) == false)
                        {
                            item.IsAttachmentCompalsary = Convert.ToInt32(sqlDataReader["IsAttachmentCompalsary"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AttachedDocument"].ToString()) == false)
                        {
                            item.AttachedDocument = Convert.ToString(sqlDataReader["AttachedDocument"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarksForQuestion"].ToString()) == false)
                        {
                            item.MarksForQuestion = Convert.ToInt32(sqlDataReader["MarksForQuestion"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarkObtained"].ToString()) == false)
                        {
                            item.MarkObtained = Convert.ToDecimal(sqlDataReader["MarkObtained"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationQuestionsList_SelectByQuestionPaper' reported the ErrorCode: " + _errorCode);
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

      
     //-----------------------------------Student Obtain Marks per Descriptive Question------------------------- 
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> MarksObtainInExamination(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMarksObtainPerQuestion_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndQuestionPaperID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamIndQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMarkObtained", SqlDbType.Char, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MarkObtained));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.OnlineExamIndQuestionPaperID = (int)cmdToExecute.Parameters["@iOnlineExamIndQuestionPaperID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 11)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationMarksObtainPerQuestion_Update' reported the ErrorCode: " +
                                        _errorCode);
                    }
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
        //-------------------------------- Is Checked Flag Checkd on Descriptive Question---------------------------------
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineDescriptiveIsCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationIsChecked_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Char, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamIndStudentExamInfoID));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.OnlineExamSubjectGroupScheduleID = (int)cmdToExecute.Parameters["@iOnlineExamSubjectGroupScheduleID"].Value;
                    item.OnlineExamIndStudentExamInfoID = (int)cmdToExecute.Parameters["@iOnlineExamIndStudentExamInfoID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 12)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationIsChecked_Update' reported the ErrorCode: " +
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

        //-----------------------------------------------Is All Checked Question Paper------------------------------------
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamIsAllCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> response = new BaseEntityResponse<OnlineExamStudentQuePaperCheckDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamIsAllCheckedQuestionPaper_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionPaperCheckerID", SqlDbType.Int, 10,
                                      ParameterDirection.Input, false, 0, 0, "",
                                      DataRowVersion.Proposed, item.OnlineExamQuestionPaperCheckerID));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.OnlineExamSubjectGroupScheduleID = (int)cmdToExecute.Parameters["@iOnlineExamSubjectGroupScheduleID"].Value;
                    item.OnlineExamQuestionPaperCheckerID = (int)cmdToExecute.Parameters["@iOnlineExamQuestionPaperCheckerID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 13)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamIsAllCheckedQuestionPaper_Update' reported the ErrorCode: " +
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
        #endregion
    }
}

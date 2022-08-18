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
    public class OnlineExamExaminationQuePaperDetailsDataProvider : DBInteractionBase, IOnlineExamExaminationQuePaperDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamExaminationQuePaperDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamExaminationQuePaperDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation

        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetOnlineExamExaminationQuePaperDetails(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionPaper_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationQuePaperDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationQuePaperDetails item = new OnlineExamExaminationQuePaperDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuestionPaperID"].ToString()) == false)
                        {
                            item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperSet"].ToString()) == false)
                        {
                            item.PaperSet = Convert.ToString(sqlDataReader["PaperSet"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"].ToString()) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt32(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"].ToString()) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
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
                        if (DBNull.Value.Equals(sqlDataReader["IsFinal"].ToString()) == false)
                        {
                            item.IsFinal = Convert.ToBoolean(sqlDataReader["IsFinal"]);
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
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetListQuestionBankMaster(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamBankMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectGroupID));
                    
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationQuePaperDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationQuePaperDetails item = new OnlineExamExaminationQuePaperDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankMasterID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionBankMasterID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionBankMasterDescription"].ToString()) == false)
                        {
                            item.QuestionBankMasterDescription = Convert.ToString(sqlDataReader["QuestionBankMasterDescription"]);
                        }
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                        
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
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionsList_SelectByQuestionBankAndQuestionPaper";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamSubjectGroupScheduleID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationQuePaperDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationQuePaperDetails item = new OnlineExamExaminationQuePaperDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankDetailsID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionBankDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankDetailsID"]);
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
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"].ToString()) == false)
                        {
                            item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionImage"].ToString()) == false)
                        {
                            item.OptionImageList = Convert.ToString(sqlDataReader["OptionImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionText"].ToString()) == false)
                        {
                            item.OptionTextList = Convert.ToString(sqlDataReader["OptionText"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuePaperDetailsID"].ToString()) == false)
                        {
                            item.OnlineExamExaminationQuePaperDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuePaperDetailsID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["OptionIDsList"].ToString()) == false)
                        //{
                        //    item.OptionIDsList = Convert.ToString(sqlDataReader["OptionIDsList"]);
                        //}
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

         public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationViewQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionsList_SelectByQuestionPaper";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationQuestionPaperID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationQuePaperDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationQuePaperDetails item = new OnlineExamExaminationQuePaperDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankDetailsID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionBankDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankDetailsID"]);
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
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"].ToString()) == false)
                        {
                            item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionImage"].ToString()) == false)
                        {
                            item.OptionImageList = Convert.ToString(sqlDataReader["OptionImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionText"].ToString()) == false)
                        {
                            item.OptionTextList = Convert.ToString(sqlDataReader["OptionText"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamStudentApplicableID"].ToString()) == false)
                        {
                            item.OnlineExamStudentApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamStudentApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFinal"].ToString()) == false)
                        {
                            item.IsFinal = Convert.ToBoolean(sqlDataReader["IsFinal"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarksForQuestion"].ToString()) == false)
                        {
                            item.MarksForQuestion = Convert.ToInt16(sqlDataReader["MarksForQuestion"]);
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

        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> AddQuestionToExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuePaperDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankDetailsID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMarksForQuestion", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MarksForQuestion));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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

                    //sqlDataReader = cmdToExecute.ExecuteReader();

                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.OnlineExamQuestionBankDetailsID = (Int32)cmdToExecute.Parameters["@iOnlineExamQuestionBankDetailsID"].Value;
                    }
                    
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 11 && _errorCode != 26 && _errorCode != 30)
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

        // ---Remove Button 
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> RemoveQuestionFromExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuePaperDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankDetailsID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamQuestionBankDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 0,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationQuePaperDetails_Delete' reported the ErrorCode: " + _errorCode);
                    }

            //        if (_rowsAffected > 0)
            //        {
            //            response.Entity = item;
            //        }
            //        else
            //        {
            //            response.Message.Add(new MessageDTO
            //            {
            //                ErrorMessage = "Create failed"
            //            });
            //        }
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

        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> QuestionPaperFinalSubmit(OnlineExamExaminationQuePaperDetails item)
        {
            IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> response = new BaseEntityResponse<OnlineExamExaminationQuePaperDetails>();
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
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;

                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionPaperFinalSubmit_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
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
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.OnlineExamExaminationQuestionPaperID = (int)cmdToExecute.Parameters["@iOnlineExamExaminationQuestionPaperID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 25 && _errorCode != 31)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationQuestionPaperFinalSubmit_Update' reported the ErrorCode: " +
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
        #endregion
    }
}

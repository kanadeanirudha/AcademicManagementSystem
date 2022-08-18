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
    public class OnlineExaminationQuestionPaperSetMasterDataProvider : DBInteractionBase, IOnlineExaminationQuestionPaperSetMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExaminationQuestionPaperSetMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExaminationQuestionPaperSetMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterBySearch(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionPaper_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationQuestionPaperSetMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationQuestionPaperSetMaster item = new OnlineExaminationQuestionPaperSetMaster();
                        item.ID = sqlDataReader["OnlineExamExaminationQuestionPaperID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        item.PaperSetCode = sqlDataReader["PaperSetCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PaperSetCode"]);
                        item.OnlineExamExaminationMasterID = sqlDataReader["OnlineExamExaminationMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        item.ExaminationName = sqlDataReader["ExaminationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExaminationName"]);
                        item.TotalQuestion = sqlDataReader["TotalQuestion"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["TotalQuestion"]);



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
                        throw new Exception("Stored Procedure 'USP_OnlineExaminationQuestionPaperSetMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterSearchList(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationQuestionPaperSetMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationQuestionPaperSetMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationQuestionPaperSetMaster item = new OnlineExaminationQuestionPaperSetMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.PaperSet = sqlDataReader["PaperSet"].ToString();
                        item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);

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
                        throw new Exception("Stored Procedure 'USP_OnlineExaminationQuestionPaperSetMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select all record from OnlineExaminationQuestionPaperSetMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterBySpin(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionNotAplicableToPaperSet_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationQuestionPaperSetMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationQuestionPaperSetMaster item = new OnlineExaminationQuestionPaperSetMaster();
                        item.OnlineExamQuestionBankMasterID = sqlDataReader["OnlineExamQuestionBankMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        item.SubjectName = sqlDataReader["SubjectName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubjectName"]);
                        item.TotalQuestionSubjectWise = sqlDataReader["TotalQuestionSubjectWise"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["TotalQuestionSubjectWise"]);
                        item.TotalQuestion = sqlDataReader["TotalQuestion"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["TotalQuestion"]);
                        item.IsQuestionInImage = sqlDataReader["IsQuestionInImage"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        item.QuestionLableText = sqlDataReader["QuestionLableText"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["QuestionLableText"]);
                        item.ImageName = sqlDataReader["ImageName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ImageName"]);
                        item.SubjectWiseStatus = sqlDataReader["SubjectWiseStatus"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["SubjectWiseStatus"]);
                        item.SubjectWiseCount = sqlDataReader["SubjectWiseCount"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SubjectWiseCount"]);
                        item.SubjectWiseTotalQuestion = sqlDataReader["SubjectWiseTotalQuestion"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SubjectWiseTotalQuestion"]);
                        item.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExaminationQuestionPaperSetMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> GetOnlineExaminationQuestionPaperSetMasterByID(OnlineExaminationQuestionPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionPaper_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationQuestionPaperSetMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationQuestionPaperSetMaster item = new OnlineExaminationQuestionPaperSetMaster();
                        item.SubjectName = sqlDataReader["SubjectName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubjectName"]);
                        item.IsQuestionInImage = sqlDataReader["IsQuestionInImage"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        item.QuestionLableText = sqlDataReader["QuestionLableText"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["QuestionLableText"]);
                        item.ImageName = sqlDataReader["ImageName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ImageName"]);
                        item.SubjectWiseStatus = sqlDataReader["SubjectWiseStatus"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["SubjectWiseStatus"]);
                        item.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                        item.IsViewOnly = true;
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExaminationQuestionPaperSetMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> InsertOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
        {
            IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> response = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionPaper_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPaperSet", SqlDbType.Char, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PaperSetCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xXmlOnlineExamExaminationQuePaperDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationQuestionPaperSetMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of OnlineExaminationQuestionPaperSetMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> UpdateOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
        {
            IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> response = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationQuestionPaperSetMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPaperSet", SqlDbType.Char, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.PaperSet));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));

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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationQuestionPaperSetMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OnlineExaminationQuestionPaperSetMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> DeleteOnlineExaminationQuestionPaperSetMaster(OnlineExaminationQuestionPaperSetMaster item)
        {
            IBaseEntityResponse<OnlineExaminationQuestionPaperSetMaster> response = new BaseEntityResponse<OnlineExaminationQuestionPaperSetMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationQuestionPaperSetMaster_Delete";
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationQuestionPaperSetMaster_Delete' reported the ErrorCode: " +
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
        #endregion
    }
}

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
    public class OnlineExamQuestionBankMasterAndDetailsDataProvider : DBInteractionBase, IOnlineExamQuestionBankMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamQuestionBankMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamQuestionBankMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExamQuestionBankMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetOnlineExamQuestionBankMasterBySearch(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamQuestionBankMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamQuestionBankMasterAndDetails item = new OnlineExamQuestionBankMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenQuestionTypeID"]) == false)
                        {
                            item.GenQuestionTypeID = Convert.ToInt16(sqlDataReader["GenQuestionTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionType"]) == false)
                        {
                            item.GenQuestionType = sqlDataReader["QuestionType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"]) == false)
                        {
                            item.SubjectName = sqlDataReader["SubjectName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"]) == false)
                        {
                            item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionText"]) == false)
                        {
                            item.OptionText = sqlDataReader["OptionText"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageName"]) == false)
                        {
                            item.ImageName = sqlDataReader["ImageName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"]) == false)
                        {
                            item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionImage"]) == false)
                        {
                            item.OptionImage = sqlDataReader["OptionImage"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamQuestionBankMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> GetOnlineExamQuestionBankMasterByID(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        OnlineExamQuestionBankMasterAndDetails _item = new OnlineExamQuestionBankMasterAndDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);

                        _item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        _item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        _item.ImageType = sqlDataReader["ImageType"].ToString();
                        _item.ImageName = sqlDataReader["ImageName"].ToString();
                        _item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        _item.LastAppearedInExamID = Convert.ToInt32(sqlDataReader["LastAppearedInExamID"]);
                        _item.AppearDate = Convert.ToString(sqlDataReader["AppearDate"]);

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
        /// <summary>
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //----------------------------OUTPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //----------------------------INPUT PARAM----------------------------------

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAcademic", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    
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
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamQuestionBankMaster_Insert' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> InsertOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMasterAndDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //----------------------------OUTPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //----------------------------INPUT PARAM----------------------------------

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralQuestionLevelMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralQuestionLevelMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionLableText.Trim()));
                    //datatpe taken at backned nvarchar(max) need to chnge by NJ
                    if (item.ImageType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ImageName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionInImage", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionInImage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGenQuestionTypeID", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenQuestionTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionDescriptive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionDescriptive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsAttachmentCompalsary", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAttachmentCompalsary));
                    if (item.SelectedXml != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SelectedXml));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));


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
                    //    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    //}
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamQuestionBankMasterAndDetails_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of OnlineExamQuestionBankMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails > UpdateOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankDetailsID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OnlineExamQuestionBankDetailsID));
                    if (item.QuestionLableText != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 500,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.QuestionLableText.Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 500,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ImageType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ImageName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionInImage", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsQuestionInImage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiGenQuestionTypeID", SqlDbType.TinyInt, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GenQuestionTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralQuestionLevelMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.GeneralQuestionLevelMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionDescriptive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionDescriptive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsAttachmentCompalsary", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAttachmentCompalsary));
                    if (item.SelectedXml != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SelectedXml));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xSelectedXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, 
                                        ParameterDirection.Output, false, 0, 0, "", 
                                        DataRowVersion.Proposed, item.ID));
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
                    //item.ID = (int)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (int)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode !=11)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamQuestionBankMaster_Delete' reported the ErrorCode: " +
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
        /// <summary>
        /// Delete a specific record of OnlineExamQuestionBankMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> DeleteOnlineExamQuestionBankMaster(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamQuestionBankMaster_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetCourseYearDetailsByCentreCode(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamGetCourseYearList_ByCenter";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamQuestionBankMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamQuestionBankMasterAndDetails item = new OnlineExamQuestionBankMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailID"]) == false)
                        {
                            item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDescription"]) == false)
                        {
                            item.CourseYearDescription = Convert.ToString(sqlDataReader["CourseYearDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgSemesterMstID"]) == false)
                        {
                            item.OrgSemesterMstID = Convert.ToInt32(sqlDataReader["OrgSemesterMstID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamGetCourseYearList_ByCenter' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetListQuestionBankMaster(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamBankMaster_SearchListForBankDetails";
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamQuestionBankMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamQuestionBankMasterAndDetails item = new OnlineExamQuestionBankMasterAndDetails();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankMasterID"].ToString()) == false)
                        {
                            item.OnlineExamQuestionBankMasterID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionBankMasterDescription"].ToString()) == false)
                        {
                            item.QuestionBankMasterDescription = Convert.ToString(sqlDataReader["QuestionBankMasterDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"].ToString()) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
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
        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> OnlineExamExaminationQuestionsList(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionsList_SelectByQuestionBankMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamQuestionBankMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamQuestionBankMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamQuestionBankMasterAndDetails item = new OnlineExamQuestionBankMasterAndDetails();

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
                        if (DBNull.Value.Equals(sqlDataReader["IsAnswer"].ToString()) == false)
                        {
                            item.IsAnswer = Convert.ToBoolean(sqlDataReader["IsAnswer"]);
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


        public IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> GetSubjectDetailsByCourseAndSem(OnlineExamQuestionBankMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamGetSubjectList_ByCourseAndSem";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOrgSemesterMstID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OrgSemesterMstID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamQuestionBankMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamQuestionBankMasterAndDetails item = new OnlineExamQuestionBankMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectDescription"]) == false)
                        {
                            item.SubjectName = Convert.ToString(sqlDataReader["SubjectDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupID"]) == false)
                        {
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamGetCourseYearList_ByCenter' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> SelectoneOnlineExamQuestionBankMasterAndDetails(OnlineExamQuestionBankMasterAndDetails item)
        {
            IBaseEntityResponse<OnlineExamQuestionBankMasterAndDetails> response = new BaseEntityResponse<OnlineExamQuestionBankMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamQuestionBankDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankDetailsID));
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
                        OnlineExamQuestionBankMasterAndDetails _item = new OnlineExamQuestionBankMasterAndDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"]) == false)
                        {
                            _item.QuestionLableText = Convert.ToString(sqlDataReader["QuestionLableText"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageName"]) == false)
                        {
                            _item.ImageName = Convert.ToString(sqlDataReader["ImageName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageType"]) == false)
                        {
                            _item.ImageType = Convert.ToString(sqlDataReader["ImageType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"]) == false)
                        {
                            _item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralQuestionLevelMasterID"]) == false)
                        {
                            _item.GeneralQuestionLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralQuestionLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenQuestionTypeID"]) == false)
                        {
                            _item.GenQuestionTypeID = Convert.ToInt16(sqlDataReader["GenQuestionTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionDescriptive"]) == false)
                        {
                            _item.IsQuestionDescriptive = Convert.ToBoolean(sqlDataReader["IsQuestionDescriptive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAttachmentCompalsary"]) == false)
                        {
                            _item.IsAttachmentCompalsary = Convert.ToInt16(sqlDataReader["IsAttachmentCompalsary"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionList"]) == false)
                        {
                            _item.OptionTextList = Convert.ToString(sqlDataReader["OptionList"]);
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
        #endregion
    }
}

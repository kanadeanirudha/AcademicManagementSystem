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
    public class OnlineExaminationMasterAndCourseApplicableDataProvider : DBInteractionBase, IOnlineExaminationMasterAndCourseApplicableDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor
        public OnlineExaminationMasterAndCourseApplicableDataProvider()
        {
        }

        /// Constructor to initialized data member and member functions
        public OnlineExaminationMasterAndCourseApplicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation
        /// Select all record from OnlineExaminationMasterAndCourseApplicable table with search parameters
        public IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> GetOnlineExaminationMasterAndCourseApplicableSelectAll(OnlineExaminationMasterAndCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationMasterAndCourseApplicable_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectID));

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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationMasterAndCourseApplicable>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationMasterAndCourseApplicable item = new OnlineExaminationMasterAndCourseApplicable();
                        //if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankMasterID"]) == false)
                        //{
                        //    item.OnlineExamQuestionBankMasterID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDesc"]) == false)
                        //{
                        //    item.SubjectGroupDesc = sqlDataReader["SubjectGroupDesc"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDetailsID"]) == false)
                        //{
                        //    item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupDetailsID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        //{
                        //    item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubjectName"]) == false)
                        //{
                        //    item.SubjectName = sqlDataReader["SubjectName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsAcademic"]) == false)
                        //{
                        //    item.IsAcademic = Convert.ToInt16(sqlDataReader["IsAcademic"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        //{
                        //    item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"]) == false)
                        //{
                        //    item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ImageType"]) == false)
                        //{
                        //    item.ImageType = sqlDataReader["ImageType"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ImageName"]) == false)
                        //{
                        //    item.ImageName = sqlDataReader["ImageName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"]) == false)
                        //{
                        //    item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["OptionImage"]) == false)
                        //{
                        //    item.OptionImage = sqlDataReader["OptionImage"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OptionText"]) == false)
                        //{
                        //    item.OptionText = sqlDataReader["OptionText"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GeneralQuestionLevelMasterID"]) == false)
                        //{
                        //    item.GeneralQuestionLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralQuestionLevelMasterID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsAnswer"]) == false)
                        //{
                        //    item.IsAnswer = Convert.ToBoolean(sqlDataReader["IsAnswer"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OnlineQuestionBankDetailsID"]) == false)
                        //{
                        //    item.OnlineQuestionBankDetailsID = Convert.ToInt32(sqlDataReader["OnlineQuestionBankDetailsID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankAnsDetID"]) == false)
                        //{
                        //    item.OnlineExamQuestionBankAnsDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankAnsDetID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExaminationMasterAndCourseApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// Select a record from table by ID.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> SelectOnlineExaminationMasterAndCourseApplicableByID(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> response = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationMasterAndCourseApplicable_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
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
                        OnlineExaminationMasterAndCourseApplicable _item = new OnlineExaminationMasterAndCourseApplicable();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);                       

                        //response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationMasterAndCourseApplicable_SelectOne' reported the ErrorCode: " + _errorCode);
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


        /// Create new subject of the question bank.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> InsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> response = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationMasterAndCourseApplicable_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //----------------------------OUTPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationCourseApplicableID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                  
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectGroupID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CourseYearDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DepartmentID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iIsAcademic", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAcademic));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iOldOnlineExamQuestionBankMasterID", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

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
                        item.OnlineExamExaminationMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationMasterAndCourseApplicable_Insert' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> UpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> response = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExaminationMasterAndCourseApplicable_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenQuestionTypeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionLableText));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageType));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionInImage", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionInImage));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLastAppearedInExamID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LastAppearedInExamID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daAppearDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AppearDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    item.OnlineExamExaminationMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamQuestionBankMaster_Update' reported the ErrorCode: " +
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


        /// Delete a specific record of OnlineExaminationMasterAndCourseApplicable.
        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> DeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> response = new BaseEntityResponse<OnlineExaminationMasterAndCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamSubjectsQuestion_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankAnsDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankAnsDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamSubjectsQuestion_Delete' reported the ErrorCode: " +
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

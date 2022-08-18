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
    public class EntranceExamApplicableExamToCourseDataProvider : DBInteractionBase, IEntranceExamApplicableExamToCourseDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EntranceExamApplicableExamToCourseDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EntranceExamApplicableExamToCourseDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EntranceExamApplicableExamToCourse table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetEntranceExamApplicableExamToCourseBySearch(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamApplicableExamToCourse_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCentreWiseSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionID));
                    
                    
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamApplicableExamToCourse>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamApplicableExamToCourse item = new EntranceExamApplicableExamToCourse();
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamApplicableExamToCourseID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["OnlineExamApplicableExamToCourseID"]);
                        }
                        item.CourseName = sqlDataReader["CourseYearCode"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExaminationName = sqlDataReader["ExaminationName"].ToString();
                        }
                        //item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();
                       
                       
                        item.ExaminationFromDate = sqlDataReader["ExaminationFromDate"].ToString();
                        item.ExaminationUpToDate = sqlDataReader["ExaminationUpToDate"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailId"]) == false)
                        {
                            item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreWiseSessionID"]) == false)
                        {
                            item.SessionID = Convert.ToInt32(sqlDataReader["CentreWiseSessionID"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamApplicableExamToCourse_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetExaminationNameByCourseID(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 10, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResults", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.MaxResults));
                   

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamApplicableExamToCourse>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamApplicableExamToCourse item = new EntranceExamApplicableExamToCourse();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExaminationName = sqlDataReader["ExaminationName"].ToString();
                        }
                        //item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();


                        baseEntityCollection.CollectionResponse.Add(item);
                       // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> GetEntranceExamApplicableExamToCourseByID(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamApplicableExamToCourse_SelectOne";
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
                        EntranceExamApplicableExamToCourse _item = new EntranceExamApplicableExamToCourse();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        _item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        _item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                       // _item.CourseName = Convert.ToString(sqlDataReader["CourseName"]);
                        _item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        _item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        _item.ExaminationFromDate = Convert.ToString(sqlDataReader["ExaminationFromDate"]);
                        _item.ExaminationUpToDate = Convert.ToString(sqlDataReader["ExaminationUpToDate"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamApplicableExamToCourse_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> InsertEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamApplicableExamToCourse_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 0, 
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.CourseYearDetailID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCourseYearCode", SqlDbType.NVarChar, 20,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.CourseName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationFromDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.ExaminationFromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationUpToDate", SqlDbType.DateTime, 0,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, Convert.ToDateTime(item.ExaminationUpToDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                  
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
                  //  item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    if (_rowsAffected > 0)
                    {
                        //  item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry && _errorCode != 18 && _errorCode != (int)ErrorEnum.WorkFlowNotDefined)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamApplicableExamToCourse_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of EntranceExamApplicableExamToCourse
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> UpdateEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamApplicableExamToCourse_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

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
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamApplicableExamToCourse_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EntranceExamApplicableExamToCourse
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> DeleteEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            IBaseEntityResponse<EntranceExamApplicableExamToCourse> response = new BaseEntityResponse<EntranceExamApplicableExamToCourse>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamApplicableExamToCourse_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamApplicableExamToCourse_Delete' reported the ErrorCode: " + _errorCode);
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

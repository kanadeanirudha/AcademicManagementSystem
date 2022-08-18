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
    public class CRMCallEnquiryDetailsDataProvider : DBInteractionBase, ICRMCallEnquiryDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CRMCallEnquiryDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CRMCallEnquiryDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from CRMCallEnquiryDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsBySearch(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UploadDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallTypeID", SqlDbType.SmallInt, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.TinyInt, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Status));

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
                    baseEntityCollection.CollectionResponse = new List<CRMCallEnquiryDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMCallEnquiryDetails item = new CRMCallEnquiryDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["CallEnquiryDetailsID"]);
                        item.CalleeFirstName = sqlDataReader["CalleeFirstName"].ToString();
                        item.CalleeMiddelName = sqlDataReader["CalleeMiddelName"].ToString();
                        item.CalleeLastName = sqlDataReader["CalleeLastName"].ToString();
                        item.CalleeMobileNo = sqlDataReader["CalleeMobileNo"].ToString();
                        item.CalleeEmailID = sqlDataReader["CalleeEmailID"].ToString();
                        item.Status = Convert.ToInt16(sqlDataReader["Status"]);
                        item.Source = sqlDataReader["Source"].ToString();
                        item.SourceContactPerson = sqlDataReader["SourceContactPerson"].ToString();
                        item.UnallocatedCalls = Convert.ToInt32(sqlDataReader["UnallocatedCalls"]);
                        item.AllocatedCalls = Convert.ToInt32(sqlDataReader["AllocatedCalls"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMCallEnquiryDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsList(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_SearchList_BalsheetMstIDWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCounterMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
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
                    baseEntityCollection.CollectionResponse = new List<CRMCallEnquiryDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMCallEnquiryDetails item = new CRMCallEnquiryDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.InvCounterApplicableDetailsID = Convert.ToInt32(sqlDataReader["InvCounterApplicableDetailsID"]);
                        //item.CounterName = sqlDataReader["CounterName"].ToString();
                        //item.CounterCode = Convert.ToString(sqlDataReader["CounterCode"]);
                        //item.CounterIDAndCounterApplicableID = Convert.ToString(sqlDataReader["ID"].ToString() + "~" + sqlDataReader["InvCounterApplicableDetailsID"].ToString());
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallEnquiryDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsByID(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_SelectOne";
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
                        CRMCallEnquiryDetails _item = new CRMCallEnquiryDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.CalleeFirstName = sqlDataReader["CalleeFullName"].ToString();
                        _item.CalleeMobileNo = Convert.ToString(sqlDataReader["CalleeMobileNo"]);
                        _item.CalleeEmailID = Convert.ToString(sqlDataReader["CalleeEmailID"]);
                        _item.Status = Convert.ToInt16(sqlDataReader["Status"]);
                        _item.Source = Convert.ToString(sqlDataReader["Source"]);
                        //if (_item.Status == 1)
                        //{
                        //    _item.Status = "Completed";
                        //}
                        //else if (_item.Status == 2)
                        //{
                        //    _item.Status = "InProgress";
                        //}
                        //else
                        //{
                        //    _item.Status = "Pending";
                        //}

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
        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallTypeID", SqlDbType.SmallInt, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CallTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xUploadExcel", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.XMLstring));

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
                    // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    //}
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of CRMCallEnquiryDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> UpdateCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar, 20,
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
                        throw new Exception("Stored Procedure 'dbo.USP_CRMCallEnquiryDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of CRMCallEnquiryDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_Delete";
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CRMCallEnquiryDetails_Delete' reported the ErrorCode: " +
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



        //public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;
        //    try
        //    {
        //        if (string.IsNullOrEmpty(searchRequest.ConnectionString))
        //        {
        //            baseEntityCollection.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _mainConnection.ConnectionString = searchRequest.ConnectionString;
        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetailsCallForward_SelectAll";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }
        //            sqlDataReader = cmdToExecute.ExecuteReader();
        //            baseEntityCollection.CollectionResponse = new List<CRMCallEnquiryDetails>();
        //            while (sqlDataReader.Read())
        //            {
        //                CRMCallEnquiryDetails item = new CRMCallEnquiryDetails();
        //                item.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //                item.CallEnquiryMasterID = Convert.ToInt32(sqlDataReader["CallEnquiryMasterID"]);
        //                item.CalleeFirstName = sqlDataReader["CalleeFirstName"].ToString();
        //                item.CalleeMiddelName = sqlDataReader["CalleeMiddelName"].ToString();
        //                item.CalleeLastName = sqlDataReader["CalleeLastName"].ToString();
        //                item.CalleeMobileNo = sqlDataReader["CalleeMobileNo"].ToString();
        //                item.CalleeEmailID = sqlDataReader["CalleeEmailID"].ToString();
        //                item.Status = Convert.ToInt16(sqlDataReader["Status"]);


        //                baseEntityCollection.CollectionResponse.Add(item);
        //                baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
        //            }
        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }
        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_CRMCallEnquiryDetails_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseEntityCollection.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return baseEntityCollection;
        //}

        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallEnquiryDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetailsCallForward_GetList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallerJobStatus", SqlDbType.TinyInt, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallStatus", SqlDbType.TinyInt, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallStatus));
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
                    baseEntityCollection.CollectionResponse = new List<CRMCallEnquiryDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMCallEnquiryDetails item = new CRMCallEnquiryDetails();

                        if (DBNull.Value.Equals(sqlDataReader["CalleeFullName"]) == false)
                        {
                            item.CalleeFirstName = Convert.ToString(sqlDataReader["CalleeFullName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMiddelName"]) == false)
                        {
                            item.CalleeMiddelName = Convert.ToString(sqlDataReader["CalleeMiddelName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeLastName"]) == false)
                        {
                            item.CalleeLastName = Convert.ToString(sqlDataReader["CalleeLastName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMobileNo"]) == false)
                        {
                            item.CalleeMobileNo = Convert.ToString(sqlDataReader["CalleeMobileNo"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeEmailID"]) == false)
                        {
                            item.CalleeEmailID = Convert.ToString(sqlDataReader["CalleeEmailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"]) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"]) == false)
                        {
                            item.CallStatus = Convert.ToInt16(sqlDataReader["CallStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobAllocationID"]) == false)
                        {
                            item.JobAllocationID = Convert.ToInt64(sqlDataReader["JobAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CRMCallMasterID"]) == false)
                        {
                            item.CallMasterID = Convert.ToInt64(sqlDataReader["CRMCallMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCreationMasterID"]) == false)
                        {
                            item.JobCreationMasterID = Convert.ToInt32(sqlDataReader["JobCreationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallEnquiryDetailID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["CallEnquiryDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerFullName"]) == false)
                        {
                            item.CallerFullName = Convert.ToString(sqlDataReader["CallerFullName"]);
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
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_BillPrintByInvSaleMstID' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.CRMCallEnquiryDetailsCallForward_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.SmallInt, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.CallStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xCallForward", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.XMLstring));

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CRMCallEnquiryDetails_INSERT' reported the ErrorCode: " +
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallEnquiryDetails> SelectPendingCallEnquiryCount(CRMCallEnquiryDetails item)
        {
            IBaseEntityResponse<CRMCallEnquiryDetails> response = new BaseEntityResponse<CRMCallEnquiryDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallEnquiryDetails_GetPendingCallsCount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCallTypeID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallTypeID));
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
                        CRMCallEnquiryDetails _item = new CRMCallEnquiryDetails();
                        _item.PendingCallEnquiryCount = Convert.ToInt32(sqlDataReader["PendingCallEnquiryCount"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallEnquiryDetails_GetPendingCallsCount' reported the ErrorCode: " + _errorCode);
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

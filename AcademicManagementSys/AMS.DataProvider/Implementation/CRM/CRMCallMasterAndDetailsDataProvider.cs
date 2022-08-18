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
    public class CRMCallMasterAndDetailsDataProvider : DBInteractionBase, ICRMCallMasterAndDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CRMCallMasterAndDetailsDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CRMCallMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsBySearch(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iJobCreationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.JobCreationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMCallMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMCallMasterAndDetails item = new CRMCallMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["JobAllocationID"]) == false)
                        {
                            item.JobAllocationID = Convert.ToInt32(sqlDataReader["JobAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallEnquiryDetailID"]) == false)
                        {
                            item.CallEnquiryDetailID = Convert.ToInt32(sqlDataReader["CallEnquiryDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"]) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeFirstName"]) == false)
                        {
                            item.CalleeFirstName = sqlDataReader["CalleeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMiddelName"]) == false)
                        {
                            item.CalleeMiddelName = sqlDataReader["CalleeMiddelName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeLastName"]) == false)
                        {
                            item.CalleeLastName = sqlDataReader["CalleeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMobileNo"]) == false)
                        {
                            item.CalleeMobileNo = sqlDataReader["CalleeMobileNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeEmailID"]) == false)
                        {
                            item.CalleeEmailID = sqlDataReader["CalleeEmailID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NextCallDate"]) == false)
                        {
                            item.NextCallDate = sqlDataReader["NextCallDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TimeSlot"]) == false)
                        {
                            item.TimeSlot = sqlDataReader["TimeSlot"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"]) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"]) == false)
                        {
                            item.CallStatus = Convert.ToInt16(sqlDataReader["CallStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        {
                            item.MenuLink = sqlDataReader["MenuLink"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsGetBySearchList(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CRMCallMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMCallMasterAndDetails item = new CRMCallMasterAndDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsByID(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_SelectOne";
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

                        CRMCallMasterAndDetails _item = new CRMCallMasterAndDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.CountryName = sqlDataReader["CountryName"].ToString();
                        //_item.ContryCode = sqlDataReader["ContryCode"].ToString();
                        //_item.SeqNo = Convert.ToInt32(sqlDataReader["SeqNo"].ToString());
                        //_item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"].ToString());
                        //_item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> InsertCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@biJobAllocationID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobAllocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xmlCallAnswerXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallAnswerXML));
                    if (item.NextCallDate != null && item.NextCallDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtNextCallDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.NextCallDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtNextCallDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiInterestlevel", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Interestlevel));

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiConcernArea", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ConcernArea));

                    if (item.CallTimeID != null && item.CallTimeID > 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCallTimeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallTimeID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCallTimeID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.OtherConcernArea != null && item.OtherConcernArea != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherConcernArea", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OtherConcernArea));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherConcernArea", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCallerRemark", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerRemark));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biID", SqlDbType.BigInt, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    //if (_rowsAffected > 0)
                    //{
                    //  item.ID = cmdToExecute.Parameters["@biID"].Value;
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
        /// Update a specific record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> UpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCountryName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.CountryName.Trim()));
                    ////  cmdToExecute.Parameters.Add(new SqlParameter("@iSeqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SeqNo));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sContryCode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ContryCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefaultFlag));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Delete a selected record from General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> DeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<CRMCallMasterAndDetails> SelectByJobAllocationID(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_ByJobAllocationID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iJobAllocationID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobAllocationID));
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

                        CRMCallMasterAndDetails _item = new CRMCallMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["JobAllocationID"]) == false)
                        {
                            _item.JobAllocationID = Convert.ToInt64(sqlDataReader["JobAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeTitle"]) == false)
                        {
                            _item.CalleeTitle = sqlDataReader["CalleeTitle"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeFirstName"]) == false)
                        {
                            _item.CalleeFirstName = sqlDataReader["CalleeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMiddelName"]) == false)
                        {
                            _item.CalleeMiddelName = sqlDataReader["CalleeMiddelName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeLastName"]) == false)
                        {
                            _item.CalleeLastName = sqlDataReader["CalleeLastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeMobileNo"]) == false)
                        {
                            _item.CalleeMobileNo = sqlDataReader["CalleeMobileNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeEmailID"]) == false)
                        {
                            _item.CalleeEmailID = sqlDataReader["CalleeEmailID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Source"]) == false)
                        {
                            _item.Source = sqlDataReader["Source"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeLocation"]) == false)
                        {
                            _item.CalleeLocation = sqlDataReader["CalleeLocation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeDesignation"]) == false)
                        {
                            _item.CalleeDesignation = sqlDataReader["CalleeDesignation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeOccupation"]) == false)
                        {
                            _item.CalleeOccupation = sqlDataReader["CalleeOccupation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeDepartment"]) == false)
                        {
                            _item.CalleeDepartment = sqlDataReader["CalleeDepartment"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeExperience"]) == false)
                        {
                            _item.CalleeExperience = sqlDataReader["CalleeExperience"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeQualification"]) == false)
                        {
                            _item.CalleeQualification = sqlDataReader["CalleeQualification"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnglishFluency"]) == false)
                        {
                            _item.EnglishFluency = sqlDataReader["EnglishFluency"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeNationalityID"]) == false)
                        {
                            _item.CalleeNationalityID = Convert.ToInt32(sqlDataReader["CalleeNationalityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UniversityID"]) == false)
                        {
                            _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchDetailID"]) == false)
                        {
                            _item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StandardNumber"]) == false)
                        {
                            _item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdmissionPattern"]) == false)
                        {
                            _item.AdmissionPattern = Convert.ToInt32(sqlDataReader["AdmissionPattern"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CalleeInterestedProgram"]) == false)
                        {
                            _item.CalleeInterestedProgram = sqlDataReader["CalleeInterestedProgram"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CenterCode"]) == false)
                        {
                            _item.CenterCode = sqlDataReader["CenterCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CallerConvertedReportForTable(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CallStatus));
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

                    baseEntityCollection.CollectionResponse = new List<CRMCallMasterAndDetails>();
                    if (searchRequest.EmployeeID == 0)
                    {
                        while (sqlDataReader.Read())
                        {
                            CRMCallMasterAndDetails item = new CRMCallMasterAndDetails();
                            if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                            {
                                item.CallerID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                            {
                                item.CallerFullName = Convert.ToString(sqlDataReader["EmployeeName"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["TotalCallCount"]) == false)
                            {
                                item.TotalCallCount = Convert.ToInt32(sqlDataReader["TotalCallCount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["PendingCount"]) == false)
                            {
                                item.PendingCount = Convert.ToInt32(sqlDataReader["PendingCount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["InprogressCount"]) == false)
                            {
                                item.InprogressCount = Convert.ToInt32(sqlDataReader["InprogressCount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CompletedCount"]) == false)
                            {
                                item.CompletedCount = Convert.ToInt32(sqlDataReader["CompletedCount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ConvertedCount"]) == false)
                            {
                                item.ConvertedCount = Convert.ToInt32(sqlDataReader["ConvertedCount"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ConvertedCallPercentage"]) == false)
                            {
                                item.ConvertedCallPercentage = Convert.ToDouble(sqlDataReader["ConvertedCallPercentage"]);
                            }
                            baseEntityCollection.CollectionResponse.Add(item);
                        }
                    }
                    else
                    {
                        while (sqlDataReader.Read())
                        {
                            CRMCallMasterAndDetails item = new CRMCallMasterAndDetails();
                            if (DBNull.Value.Equals(sqlDataReader["CalleeFullName"]) == false)
                            {
                                item.CalleeFullName = Convert.ToString(sqlDataReader["CalleeFullName"]);
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
                            if (DBNull.Value.Equals(sqlDataReader["Source"]) == false)
                            {
                                item.Source = Convert.ToString(sqlDataReader["Source"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CallMasterID"]) == false)
                            {
                                item.CallMasterID = Convert.ToInt64(sqlDataReader["CallMasterID"]);
                            }
                            baseEntityCollection.CollectionResponse.Add(item);
                        }
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CRMMarketingEffectivenessReport(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMMarketingEffectiveness_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));
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

                    baseEntityCollection.CollectionResponse = new List<CRMCallMasterAndDetails>();

                    while (sqlDataReader.Read())
                    {
                        CRMCallMasterAndDetails item = new CRMCallMasterAndDetails();
                        item.CountSource = Convert.ToInt32(sqlDataReader["CountSource"]);
                        item.Source = Convert.ToString(sqlDataReader["Source"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<CRMCallMasterAndDetails> GetStudentStatusDetailsByCalleeMasterID(CRMCallMasterAndDetails item)
        {
            IBaseEntityResponse<CRMCallMasterAndDetails> response = new BaseEntityResponse<CRMCallMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMCallMasterAndDetails_ByCallMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCallMasterID", SqlDbType.BigInt, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallMasterID));
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

                        CRMCallMasterAndDetails _item = new CRMCallMasterAndDetails();

                        _item.ID =                          Convert.ToInt32(sqlDataReader["CallMasterID"]);
                        _item.CalleeTitle =                 Convert.ToString(sqlDataReader["CalleeTitle"]);
                        _item.CalleeFirstName =             Convert.ToString(sqlDataReader["CalleeFirstName"]);
                        _item.CalleeMiddelName =            Convert.ToString(sqlDataReader["CalleeMiddelName"]);
                        _item.CalleeLastName =              Convert.ToString(sqlDataReader["CalleeLastName"]);
                        _item.CalleeMobileNo =              Convert.ToString(sqlDataReader["CalleeMobileNo"]);
                        _item.CalleeEmailID =               Convert.ToString(sqlDataReader["CalleeEmailID"]);
                        _item.CalleeGender =                Convert.ToString(sqlDataReader["CalleeGender"]);
                        _item.Source =                      Convert.ToString(sqlDataReader["Source"]);
                        _item.CalleeLocation =              Convert.ToString(sqlDataReader["CalleeLocation"]);
                        _item.CalleeLocationID =            Convert.ToInt16(sqlDataReader["CalleeLocationID"]);
                        _item.CalleeNationalityID =         Convert.ToInt16(sqlDataReader["CalleeNationalityID"]);
                        _item.CalleeGender =                Convert.ToString(sqlDataReader["CalleeGender"]);
                        _item.CalleeOccupation =            Convert.ToString(sqlDataReader["CalleeOccupation"]);
                        _item.CalleeDesignation =           Convert.ToString(sqlDataReader["CalleeDesignation"]);
                        _item.CalleeExperience =            Convert.ToString(sqlDataReader["CalleeExperience"]);
                        _item.CalleeDepartment =            Convert.ToString(sqlDataReader["CalleeDepartment"]);
                        _item.CalleeQualification =         Convert.ToString(sqlDataReader["CalleeQualification"]);
                        _item.EnglishFluency =              Convert.ToString(sqlDataReader["EnglishFluency"]);
                        _item.CenterCode =                  Convert.ToString(sqlDataReader["CenterCode"]);
                        _item.UniversityID =                Convert.ToInt16(sqlDataReader["UniversityID"]);
                        _item.BranchDetailID =              Convert.ToInt16(sqlDataReader["BranchDetailID"]);
                        _item.StandardNumber =              Convert.ToInt16(sqlDataReader["StandardNumber"]);
                        _item.AdmissionPattern =            Convert.ToInt16(sqlDataReader["AdmissionPattern"]);
                        _item.CalleeInterestedProgram =     Convert.ToString(sqlDataReader["CalleeInterestedProgram"]);
                        _item.CallerJobStatus =             Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        _item.CallStatus =                  Convert.ToInt16(sqlDataReader["CallStatus"]);
                        _item.CallerRemark =                Convert.ToString(sqlDataReader["CallerRemark"]);
                        _item.NextCallDate =                Convert.ToString(sqlDataReader["NextCallDate"]);
                        _item.Interestlevel =               Convert.ToInt16(sqlDataReader["Interestlevel"]);
                        _item.ConcernArea =                 Convert.ToInt16(sqlDataReader["ConcernArea"]);
                        _item.OtherConcernArea =            Convert.ToString(sqlDataReader["OtherConcernArea"]);
                        _item.CallTimeID =                  Convert.ToInt16(sqlDataReader["CallTimeID"]);
                        _item.CentreName =                  Convert.ToString(sqlDataReader["CentreName"]);
                        _item.UniversityName =              Convert.ToString(sqlDataReader["UniversityName"]);
                        _item.BranchShortCode =             Convert.ToString(sqlDataReader["BranchShortCode"]);
                        _item.BranchDescription =           Convert.ToString(sqlDataReader["BranchDescription"]);
                        _item.CalleeInterestedProgram =     Convert.ToString(sqlDataReader["CalleeInterestedProgram"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMCallMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

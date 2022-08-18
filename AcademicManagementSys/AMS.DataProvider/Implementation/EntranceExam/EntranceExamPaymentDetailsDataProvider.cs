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
    public class EntranceExamPaymentDetailsDataProvider : DBInteractionBase,IEntranceExamPaymentDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        
        /// Constructor to initialized data member and member functions        
        public EntranceExamPaymentDetailsDataProvider()
        {
        }
        
        /// Constructor to initialized data member and member functions        
        public EntranceExamPaymentDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["DeveloperDBEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation



        // EntranceExamPaymentDetails Method
        #region EntranceExamPaymentDetails

        /// Select all record from EntranceExamPaymentDetails table with search parameters        
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsBySearch(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamPaymentDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamPaymentDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamPaymentDetails>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamPaymentDetails item = new EntranceExamPaymentDetails();

                        //Property of EntranceExamAvailableCentres
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        

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
                        throw new Exception("Stored Procedure 'USP_EntranceExamPaymentDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from EntranceExamPaymentDetails table by ID        
        public IBaseEntityResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsByID(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> response = new BaseEntityResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamStudentFeeAmount_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));
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
                        EntranceExamPaymentDetails _item = new EntranceExamPaymentDetails();

                        //Property of EntranceExamPaymentDetails
                        if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        {
                            _item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            _item.StudentName = sqlDataReader["StudentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentAmount"]) == false)
                        {
                            _item.PaymentAmount = Convert.ToDecimal(sqlDataReader["PaymentAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentStatus"]) == false)
                        {
                            _item.Status = Convert.ToBoolean(sqlDataReader["PaymentStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamPaymenDetailsID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["EntranceExamPaymenDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamValidationParameterApplicableID"]) == false)
                        {
                            _item.EntranceExamValidationParameterApplicableID = Convert.ToInt32(sqlDataReader["EntranceExamValidationParameterApplicableID"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamStudentFeeAmount_SelectOne' reported the ErrorCode: " + _errorCode);
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

        /// Create new record of the table        
        public IBaseEntityResponse<EntranceExamPaymentDetails> InsertEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> response = new BaseEntityResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamPaymenDetails_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamValidationParameterApplicableID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamValidationParameterApplicableID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcPaymentAmount", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPaymentMode", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentMode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPaymentThrough", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentThrough));
                    if (item.ChalanNo != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsChalanNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ChalanNo));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsChalanNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));    
                    }
                    if (item.ChalanDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChalanDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ChalanDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChalanDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BankName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.BankAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAddress", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BankAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsBankAddress", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PaymentID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPaymentID", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPaymentID", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.AttachFile != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@vbAttachFile", SqlDbType.VarBinary, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AttachFile));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@vbAttachFile", SqlDbType.VarBinary, 4000, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStatus", SqlDbType.Bit, 1, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Status));

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
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamPaymenDetails_Insert' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of EntranceExamPaymentDetails        
        public IBaseEntityResponse<EntranceExamPaymentDetails> UpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> response = new BaseEntityResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamPaymentDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamPaymentDetails
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

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

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamPaymentDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of EntranceExamPaymentDetails        
        public IBaseEntityResponse<EntranceExamPaymentDetails> DeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails item)
        {
            IBaseEntityResponse<EntranceExamPaymentDetails> response = new BaseEntityResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamPaymentDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamPaymentDetails
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamPaymentDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from EntranceExamPaymentDetails table with search list.
        public IBaseEntityCollectionResponse<EntranceExamPaymentDetails> GetEntranceExamPaymentDetailsSearchList(EntranceExamPaymentDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamPaymentDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamPaymentDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamPaymentDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamPaymentDetailsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamPaymentDetailsSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamPaymentDetails>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamPaymentDetails item = new EntranceExamPaymentDetails();

                        //Property of EntranceExamPaymentDetails
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamValidationParameterApplicableID"]) == false)
                        {
                            item.EntranceExamValidationParameterApplicableID = Convert.ToInt32(sqlDataReader["EntranceExamValidationParameterApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        {
                            item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentAmount"]) == false)
                        {
                            item.PaymentAmount = Convert.ToDecimal(sqlDataReader["PaymentAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PaymentMode"]) == false)
                        {
                            item.PaymentMode = Convert.ToInt32(sqlDataReader["PaymentMode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentThrough"]) == false)
                        {
                            item.PaymentThrough = Convert.ToInt32(sqlDataReader["PaymentThrough"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ChalanNo"]) == false)
                        {
                            item.ChalanNo = sqlDataReader["ChalanNo"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        {
                            item.ChalanDate = sqlDataReader["ChalanDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankName"]) == false)
                        {
                            item.BankName = sqlDataReader["BankName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankAddress"]) == false)
                        {
                            item.BankAddress = sqlDataReader["BankAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaymentID"]) == false)
                        {
                            item.PaymentID = sqlDataReader["PaymentID"].ToString();
                        }
                        
                        //AttachFile dataType not set..
                        //if (DBNull.Value.Equals(sqlDataReader["AttachFile"]) == false)
                        //{
                        //    item.AttachFile = sqlDataReader["AttachFile"];
                        //}


                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamPaymentDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        #endregion
    }
}

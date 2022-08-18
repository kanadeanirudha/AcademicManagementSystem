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
    public class CRMSaleBillingTransactionDataProvider : DBInteractionBase, ICRMSaleBillingTransactionDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion


         #region Constructor

       
        /// Constructor to initialized data member and member functions       
        public CRMSaleBillingTransactionDataProvider()
        {
        }

       
        /// Constructor to initialized data member and member functions       
        public CRMSaleBillingTransactionDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException; 
        }

        #endregion


        #region Method Implementation CRMSaleBillingTransaction

        public IBaseEntityCollectionResponse<CRMSaleBillingTransaction> GetCRMSaleBillingTransactionSelectAll(CRMSaleBillingTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleBillingTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleBillingTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleEnquiryAccountMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleBillingTransaction>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleBillingTransaction item = new CRMSaleBillingTransaction();

                        //if (DBNull.Value.Equals(sqlDataReader["CRMSaleBillingTransactionID"].ToString()) == false)
                        //{
                            item.ID = Convert.ToInt32(sqlDataReader["CRMSaleBillingTransactionID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CallEnquiryMasterID"].ToString()) == false)
                        {
                            item.CallEnquiryMasterID = Convert.ToInt32(sqlDataReader["CallEnquiryMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryDesription"].ToString()) == false)
                        {
                            item.EnquiryDesription = sqlDataReader["EnquiryDesription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleEnquiryAccountMasterID"].ToString()) == false)
                        {
                            item.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountMasterID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["InvoiceNumber"].ToString()) == false)
                        {
                            item.InvoiceNumber = sqlDataReader["InvoiceNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvoiceDate"].ToString()) == false)
                        {
                            item.InvoiceDate = sqlDataReader["InvoiceDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvoiceAmount"].ToString()) == false)
                        {
                            item.InvoiceAmount = Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleBillingTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityResponse<CRMSaleBillingTransaction> SelectByCRMSaleBillingTransactionID(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> response = new BaseEntityResponse<CRMSaleBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleBillingTransaction_SelectOne";
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

                        CRMSaleBillingTransaction _item = new CRMSaleBillingTransaction();

                        _item.ID = Convert.ToInt32(sqlDataReader["CRMSaleBillingTransactionID"]);
                        
                        if (DBNull.Value.Equals(sqlDataReader["CallEnquiryMasterID"].ToString()) == false)
                        {
                            _item.CallEnquiryMasterID = Convert.ToInt32(sqlDataReader["CallEnquiryMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryDesription"].ToString()) == false)
                        {
                            _item.EnquiryDesription = sqlDataReader["EnquiryDesription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleEnquiryAccountMasterID"].ToString()) == false)
                        {
                            _item.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountMasterID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["InvoiceNumber"].ToString()) == false)
                        {
                            _item.InvoiceNumber = sqlDataReader["InvoiceNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvoiceDate"].ToString()) == false)
                        {
                            _item.InvoiceDate = sqlDataReader["InvoiceDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvoiceAmount"].ToString()) == false)
                        {
                            _item.InvoiceAmount = Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            _item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"].ToString()) == false)
                        {
                            _item.CurrencyCode = sqlDataReader["CurrencyCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleBillingTransaction_SelectOne' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleBillingTransaction> InsertCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> response = new BaseEntityResponse<CRMSaleBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleBillingTransaction_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleBillingTransactionID", SqlDbType.Int, 0, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallEnquiryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallEnquiryMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.InvoiceDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsInvoiceNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InvoiceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dInvoiceAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvoiceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrencyCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CurrencyCode));
                    
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
                        item.ID = (Int32)cmdToExecute.Parameters["@iCRMSaleBillingTransactionID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                   
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleBillingTransaction_Insert' reported the ErrorCode: " + _errorCode);
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
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }

        public IBaseEntityResponse<CRMSaleBillingTransaction> UpdateCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> response = new BaseEntityResponse<CRMSaleBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleBillingTransaction_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 0, ParameterDirection.Input,true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleBillingTransactionID", SqlDbType.Int, 0, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCallEnquiryMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallEnquiryMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.InvoiceDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsInvoiceNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InvoiceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dInvoiceAmount", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvoiceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrencyCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CurrencyCode));
                    
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleBillingTransaction_UpDate' reported the ErrorCode: " + _errorCode);
                    }
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

        public IBaseEntityResponse<CRMSaleBillingTransaction> DeleteCRMSaleBillingTransaction(CRMSaleBillingTransaction item)
        {
            IBaseEntityResponse<CRMSaleBillingTransaction> response = new BaseEntityResponse<CRMSaleBillingTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleBillingTransaction_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleBillingTransactionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleBillingTransaction_Delete' reported the ErrorCode: " + _errorCode);
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

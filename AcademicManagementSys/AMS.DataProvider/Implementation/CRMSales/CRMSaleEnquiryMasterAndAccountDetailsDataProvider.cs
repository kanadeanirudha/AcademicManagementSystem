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
    public class CRMSaleEnquiryMasterAndAccountDetailsDataProvider : DBInteractionBase, ICRMSaleEnquiryMasterAndAccountDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CRMSaleEnquiryMasterAndAccountDetailsDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CRMSaleEnquiryMasterAndAccountDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation CRMSaleEnquiryMaster

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiEnquiryAccountType", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryAccountType));
                    if (searchRequest.TransactionDate != null && searchRequest.TransactionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.TransactionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryHandledById", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryHandledById));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();

                        item.CRMSaleEnquiryMasterID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryMasterID"]);
                        item.EnquiryDesription = sqlDataReader["EnquiryDesription"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        {
                            item.LastName = Convert.ToString(sqlDataReader["LastName"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        item.CRMSaleEnquiryMasterID = Convert.ToInt16(sqlDataReader["CRMSaleEnquiryMasterID"]);
                        //item.GroupName = sqlDataReader["GroupName"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCRMSaleEnquiryMasterID", SqlDbType.BigInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryMasterID));
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

                        CRMSaleEnquiryMasterAndAccountDetails _item = new CRMSaleEnquiryMasterAndAccountDetails();
                        _item.CRMSaleEnquiryMasterID = Convert.ToInt64(sqlDataReader["CRMSaleEnquiryMasterID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            _item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            _item.EnquiryContactPerson = String.Concat(sqlDataReader["FirstName"].ToString()," ", sqlDataReader["LastName"].ToString());
                        }
                        if (DBNull.Value.Equals(Convert.ToInt16(sqlDataReader["EnquiryAccountType"])) == false)
                        {
                            _item.EnquiryAccountType = Convert.ToInt16(sqlDataReader["EnquiryAccountType"]);
                        }
                        if (DBNull.Value.Equals(Convert.ToInt16(sqlDataReader["EnquirySource"])) == false)
                        {
                            _item.EnquirySource = Convert.ToInt16(sqlDataReader["EnquirySource"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["GenServiceRequiredID"]) == false)
                        //{
                        //    _item.GenServiceRequiredID = Convert.ToInt16(sqlDataReader["GenServiceRequiredID"]);
                        //}
                        
                        if (DBNull.Value.Equals(sqlDataReader["ExpectedBillingAmount"].ToString()) == false)
                        {
                            _item.ExpectedBillingAmount = Convert.ToString(sqlDataReader["ExpectedBillingAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryDesription"].ToString()) == false)
                        {
                            _item.EnquiryDesription = Convert.ToString(sqlDataReader["EnquiryDesription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Address"].ToString()) == false)
                        {
                            _item.EnquiryMasterAddress= Convert.ToString(sqlDataReader["Address"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["City"].ToString()) == false)
                        {
                            _item.EnquiryMasterCity = Convert.ToString(sqlDataReader["City"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountContactPersonID", SqlDbType.Int, 0,
                                                               ParameterDirection.Input, false, 10, 0, "",
                                                               DataRowVersion.Proposed, item.CRMSaleEnquiryAccountContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dEnquiryMasterLatitude", SqlDbType.Decimal, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.EnquiryMasterLatitude));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dEnquiryMasterLongitude", SqlDbType.Decimal, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.EnquiryMasterLongitude));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiEnquiryAccountType", SqlDbType.TinyInt, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.EnquiryAccountType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiEnquirySource", SqlDbType.TinyInt, 0,
                                                          ParameterDirection.Input, false, 10, 0, "",
                                                          DataRowVersion.Proposed, item.EnquirySource));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xGenServiceRequiredName", SqlDbType.Xml, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.GenServiceRequiredName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mExpectedBillingAmount", SqlDbType.Money, 0,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.ExpectedBillingAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryDesription", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EnquiryDesription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobName", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, String.Concat("New Job-", DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss"))));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtJobStartDate", SqlDbType.DateTime, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DateTime.Now));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryMasterAddress", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EnquiryMasterAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryMasterCity", SqlDbType.NVarChar, 0,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.EnquiryMasterCity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0,
                                                                ParameterDirection.Input, true, 10, 0, "",
                                                                DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCRMSaleEnquiryMasterID", SqlDbType.BigInt, 0, ParameterDirection.Output,
                                                                 true, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryMasterID));
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
                    if (_rowsAffected > 0)
                    {
                        item.CRMSaleEnquiryMasterID = (Int64)cmdToExecute.Parameters["@biCRMSaleEnquiryMasterID"].Value;
                    }
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_InActiveTargetType";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@siCRMSaleEnquiryMasterID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryMasterID));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMaster_InActiveTargetType' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@biCRMSaleEnquiryMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryMasterID));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        #region Method Implementation CRMSaleEnquiryAccountMaster
        
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        item.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountMasterID"]);
                        item.CRMSaleEnquiryAccountContactPersonID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountContactPersonID"]);
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        {
                            item.LastName = sqlDataReader["LastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"].ToString()) == false)
                        {
                            item.MobileNumber = Convert.ToString(sqlDataReader["MobileNumber"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailId"].ToString()) == false)
                        {
                            item.EmailId = Convert.ToString(sqlDataReader["EmailId"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["City"].ToString()) == false)
                        {
                            item.EnquiryAccountContactPersonCity = Convert.ToString(sqlDataReader["City"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VisitingCardPath"].ToString()) == false)
                        {
                            item.VisitingCardPath = Convert.ToString(sqlDataReader["VisitingCardPath"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountType"]) == false)
                        {
                            item.AccountType = Convert.ToInt16(sqlDataReader["AccountType"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAllAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAllAccountMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        item.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountMasterID"]);
                        item.CRMSaleEnquiryAccountContactPersonID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountContactPersonID"]);
                        item.OwnAccountStatus = Convert.ToInt16(sqlDataReader["OwnAccountStatus"]);
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        {
                            item.LastName = sqlDataReader["LastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"].ToString()) == false)
                        {
                            item.MobileNumber = Convert.ToString(sqlDataReader["MobileNumber"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailId"].ToString()) == false)
                        {
                            item.EmailId = Convert.ToString(sqlDataReader["EmailId"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["City"].ToString()) == false)
                        {
                            item.EnquiryAccountContactPersonCity = Convert.ToString(sqlDataReader["City"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VisitingCardPath"].ToString()) == false)
                        {
                            item.VisitingCardPath = Convert.ToString(sqlDataReader["VisitingCardPath"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountType"]) == false)
                        {
                            item.AccountType = Convert.ToInt16(sqlDataReader["AccountType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeName"].ToString()) == false)
                        {
                            item.EmployeeName = Convert.ToString(sqlDataReader["EmployeeName"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProgressType"].ToString()) == false)
                        {
                            item.ProgressType = Convert.ToString(sqlDataReader["ProgressType"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Designation"].ToString()) == false)
                        {
                            item.Designation = Convert.ToString(sqlDataReader["Designation"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleAccountProgressTypeID"]) == false)
                        {
                            item.CRMSaleAccountProgressTypeID = Convert.ToInt16(sqlDataReader["CRMSaleAccountProgressTypeID"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryAllAccountMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountName", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountProgressTypeID", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountProgressTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryAccountType", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryAccountType));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        item.CRMSaleEnquiryAccountMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.AccountName = sqlDataReader["AccountName"].ToString();
                        //if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        //{
                        //    item.FirstName = sqlDataReader["FirstName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        //{
                        //    item.LastName = sqlDataReader["LastName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
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

                        CRMSaleEnquiryMasterAndAccountDetails _item = new CRMSaleEnquiryMasterAndAccountDetails();
                        _item.AccountName = sqlDataReader["AccountName"].ToString();
                        _item.ApproxAnnualAmount = sqlDataReader["ApproxAnnualAmount"].ToString();
                        _item.GeneralIndustryMasterID = Convert.ToInt16(sqlDataReader["GeneralIndustryMasterID"]);
                        _item.CRMSaleAccountProgressTypeID = Convert.ToInt16(sqlDataReader["CRMSaleAccountProgressTypeID"]);
                        _item.EnquiryAccountMasterAddress = sqlDataReader["EnquiryAccountMasterAddress"].ToString();
                        _item.EnquiryAccountMasterCity = sqlDataReader["City"].ToString();
                        _item.EnquiryAccountMasterCountry = sqlDataReader["Country"].ToString();
                        
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountName", SqlDbType.NVarChar, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.AccountName));
                    if (item.ApproxAnnualAmount != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mApproxAnnualAmount", SqlDbType.Money, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.ApproxAnnualAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@mApproxAnnualAmount", SqlDbType.Money, 0,
                                                                 ParameterDirection.Input, false, 10, 0, "",
                                                                 DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.GeneralIndustryMasterID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiGeneralIndustryMasterID", SqlDbType.TinyInt, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.GeneralIndustryMasterID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiGeneralIndustryMasterID", SqlDbType.TinyInt, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.CRMAccountProgressTypeID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCRMAccountProgressTypeID", SqlDbType.TinyInt, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, item.CRMAccountProgressTypeID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCRMAccountProgressTypeID", SqlDbType.TinyInt, 0,
                                                              ParameterDirection.Input, false, 10, 0, "",
                                                              DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountMasterAddress", SqlDbType.NVarChar, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.EnquiryAccountMasterAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountMasterCity", SqlDbType.NVarChar, 0,
                                                                ParameterDirection.Input, false, 10, 0, "",
                                                                DataRowVersion.Proposed, item.EnquiryAccountMasterCity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountMasterCountry", SqlDbType.NVarChar, 0,
                                                               ParameterDirection.Input, false, 10, 0, "",
                                                               DataRowVersion.Proposed, item.EnquiryAccountMasterCountry));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0,
                                                               ParameterDirection.Input, false, 10, 0, "",
                                                               DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                                                 ParameterDirection.Input, true, 10, 0, "",
                                                                 DataRowVersion.Proposed, item.CreatedBy));
                    if (item.FirstName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.LastName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Designation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Designation));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.MobileNumber != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter ("@nsMobileNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EmailId != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailId", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailId));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailId", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EnquiryAccountContactPersonAddress != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.Pin != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPin", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Pin));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPin", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EnquiryAccountContactPersonLocation != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonLocation));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EnquiryAccountContactPersonCity != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCity", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCity));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCity", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.EnquiryAccountContactPersonCountry != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCountry", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCountry));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCountry", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.VisitingCardName != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.VisitingCardName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiAccountType", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AccountType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 0, ParameterDirection.Output,
                                                                   true, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
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
                    if (_rowsAffected > 0)
                    {
                        item.CRMSaleEnquiryAccountMasterID = (Int32)cmdToExecute.Parameters["@iCRMSaleEnquiryAccountMasterID"].Value;
                    }
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Insert' reported the ErrorCode: " +
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountMaster_InActiveTargetType";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@siCRMSaleEnquiryAccountMasterID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Insert' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMasterAndAccountDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountTransferRequest(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountTransferRequest_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRequestedSalesMenId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RequestedSalesMenId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nReason", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AccountTransferRequestReason));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryAccountTransferRequest_Insert' reported the ErrorCode: " + _errorCode);
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

        #region Method Implementation CRMSaleEnquiryAccountContactPerson

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountContactPerson_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleEnquiryMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        //item.CRMSaleTargetTypeId = Convert.ToInt16(sqlDataReader["CRMSaleTargetTypeID"]);
                        //item.CRMSaleEnquiryAccountContactPersonID = Convert.ToInt16(sqlDataReader["CRMSaleEnquiryAccountContactPersonID"]);
                        //if (DBNull.Value.Equals(sqlDataReader["EmployeeName"].ToString()) == false)
                        //{
                        //    item.EmployeeName = sqlDataReader["EmployeeName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TargetType"].ToString()) == false)
                        //{
                        //    item.TargetType = sqlDataReader["TargetType"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["FromDate"].ToString()) == false)
                        //{
                        //    item.FromDate = sqlDataReader["FromDate"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TargetValue"].ToString()) == false)
                        //{
                        //    item.TargetValue = Convert.ToInt64(sqlDataReader["TargetValue"].ToString());
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountContactPersonSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountContactPerson_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContactPersonName", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ContactPersonName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountContactPersonNameID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CRMSaleEnquiryAccountContactPersonNameID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryAccountType", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryAccountType));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleEnquiryMasterAndAccountDetails>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleEnquiryMasterAndAccountDetails item = new CRMSaleEnquiryMasterAndAccountDetails();
                        item.CRMSaleEnquiryAccountContactPersonID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"].ToString()) == false)
                        {
                            item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"].ToString()) == false)
                        {
                            item.LastName = sqlDataReader["LastName"].ToString();
                        }
                        item.CRMSaleEnquiryAccountMasterID = sqlDataReader["CRMSaleEnquiryAccountMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountMasterID"]);
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountContactPersonID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountContactPerson_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountContactPersonID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountContactPersonID));
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

                        CRMSaleEnquiryMasterAndAccountDetails _item = new CRMSaleEnquiryMasterAndAccountDetails();
                        _item.CRMSaleEnquiryAccountContactPersonID = Convert.ToInt32(sqlDataReader["CRMSaleEnquiryAccountContactPersonID"]);
                        
                        _item.FirstName = sqlDataReader["FirstName"].ToString();
                        _item.LastName = sqlDataReader["LastName"].ToString();                        
                        _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        _item.EmailId = sqlDataReader["EmailId"].ToString();
                        _item.EnquiryAccountContactPersonAddress = sqlDataReader["Address"].ToString();
                        _item.EnquiryAccountContactPersonCity = sqlDataReader["City"].ToString();
                        _item.EnquiryAccountContactPersonCountry = sqlDataReader["Country"].ToString();
                        _item.Designation = sqlDataReader["Designation"].ToString();
                        _item.Pin= sqlDataReader["Pin"].ToString();
                       
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryAccountContactPerson_SelectOne' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountContactPerson_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Designation));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailId", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPin", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Pin));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCity", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCountry", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCountry));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountContactPersonID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (item.VisitingCardName != null && item.VisitingCardName != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VisitingCardName));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                        item.CRMSaleEnquiryAccountContactPersonID = (Int32)cmdToExecute.Parameters["@iCRMSaleEnquiryAccountContactPersonID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryAccountContactPerson_INSERT' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryAccountContactPerson_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleEnquiryAccountContactPersonID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleEnquiryAccountContactPersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailId", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonAddress", SqlDbType.NVarChar, 80, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCity", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEnquiryAccountContactPersonCountry", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EnquiryAccountContactPersonCountry));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDesignation", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Designation));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPin", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Pin));



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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryAccountContactPerson_Update' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> response = new BaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEnquiryMasterAndAccountDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEnquiryMasterAndAccountDetails_Delete' reported the ErrorCode: " + _errorCode);
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


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
    public class InventoryCounterLogAndLockDetailsDataProvider : DBInteractionBase, IInventoryCounterLogAndLockDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryCounterLogAndLockDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryCounterLogAndLockDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from InventoryCounterLogAndLockDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsBySearch(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryCounterLogAndLockDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryCounterLogAndLockDetails item = new InventoryCounterLogAndLockDetails();
                        //item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        //item.CategoryCode = sqlDataReader["CategoryCode"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_InventoryCounterLogAndLockDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsList(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryCode", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CategoryCode));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryCounterLogAndLockDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryCounterLogAndLockDetails item = new InventoryCounterLogAndLockDetails();
                        //item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        //item.CategoryCode = Convert.ToString(sqlDataReader["CategoryCode"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryCounterLogAndLockDetails_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLogAndLockDetailsByID(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        InventoryCounterLogAndLockDetails _item = new InventoryCounterLogAndLockDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.CategoryDescription = sqlDataReader["CategoryDescription"].ToString();
                        //_item.CategoryCode = Convert.ToString(sqlDataReader["BalasheetId"]);

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
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> InsertInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Output, false, 0, 0, "",DataRowVersion.Proposed, item.CounterLockID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvCounterApplicableDetailsID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.InvCounterApplicableDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTokenCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TokenCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dOpeningCash", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OpeningCash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dClosingCash", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ClosingCash));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                    if (_rowsAffected > 1)
                    {
                        item.CounterLogID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                        
                    }
                    response.Entity = item;                    
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryCounterLogAndLockDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of InventoryCounterLogAndLockDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> UpdateInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCategoryDescription", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CategoryDescription));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CategoryCode));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                    //                    ParameterDirection.Input, true, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryCounterLogAndLockDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of InventoryCounterLogAndLockDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterLogAndLockDetails> DeleteInventoryCounterLogAndLockDetails(InventoryCounterLogAndLockDetails item)
        {
            IBaseEntityResponse<InventoryCounterLogAndLockDetails> response = new BaseEntityResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogAndLockDetails_LogOut";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTokenCode", SqlDbType.NVarChar, 500,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.TokenCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.UserID));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryCounterLogAndLockDetails_Delete' reported the ErrorCode: " +
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


        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLockStatus(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLock_Status";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvCounterMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CounterMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTokenCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TokenCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryCounterLogAndLockDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryCounterLogAndLockDetails item = new InventoryCounterLogAndLockDetails();
                        item.LoginUserCount = Convert.ToInt32(sqlDataReader["LoginUserCount"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryCounterLogAndLockDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> GetInventoryCounterLog_OpeningCashAndTotalSaleAmount(InventoryCounterLogAndLockDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterLogAndLockDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryCounterLogAndLockDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLog_OpeningCash";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CounterMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtDate", SqlDbType.DateTime, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryCounterLogAndLockDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryCounterLogAndLockDetails item = new InventoryCounterLogAndLockDetails();
                        item.ClosingCash = Convert.ToDecimal(sqlDataReader["TotalSaleAmount"]);
                        item.OpeningCash = Convert.ToDecimal(sqlDataReader["OpeningCash"]);
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryCounterLogAndLockDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

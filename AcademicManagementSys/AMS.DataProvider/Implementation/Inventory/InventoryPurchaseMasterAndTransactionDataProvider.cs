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
    public class InventoryPurchaseMasterAndTransactionDataProvider : DBInteractionBase, IInventoryPurchaseMasterAndTransactionDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryPurchaseMasterAndTransactionDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryPurchaseMasterAndTransactionDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from InventoryPurchaseMasterAndTransaction table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetInventoryPurchaseMasterAndTransactionBySearch(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMasterAndTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryPurchaseMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventoryPurchaseMasterAndTransaction item = new InventoryPurchaseMasterAndTransaction();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillAmount"]) == false)
                        {
                            item.BillAmount = Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SupplierName"]) == false)
                        {
                            item.SupplierName = Convert.ToString(sqlDataReader["SupplierName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryPurchaseMasterAndTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> GetInventoryPurchaseMasterAndTransactionByID(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMasterAndTransaction_SelectOne";
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
                        InventoryPurchaseMasterAndTransaction _item = new InventoryPurchaseMasterAndTransaction();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.PurchaseMasterID = Convert.ToInt32(sqlDataReader["InvPurchaseMasterID"]);
                        _item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);


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
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> InsertInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchase_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.TransactionDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseAtLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSupplierBillNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.BillNumber) ? item.BillNumber : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetId", SqlDbType.SmallInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalBillAmountincludingTax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mHamali", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Hamali));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mOtherExpenses", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OtherExpenses));



                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSupplierName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.SupplierName) ? item.SupplierName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ParameterXml));
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
                        item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryPurchase_InsertXML' reported the ErrorCode: " + _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage ="Create failed"
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
        /// Update a specific record of InventoryPurchaseMasterAndTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> UpdateInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMasterAndTransaction_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iInvPurchaseMasterID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.InvPurchaseMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iItemID", SqlDbType.Int,10,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.ItemID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.decimal,8,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Quantity));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.money,19,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Rate));

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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryPurchaseMasterAndTransaction_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of InventoryPurchaseMasterAndTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> DeleteInventoryPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMasterAndTransaction_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryPurchaseMasterAndTransaction_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> GetPurchaseMasterAndTransaction(InventoryPurchaseMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMasterAndTransaction_GetDetailList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryPurchaseMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventoryPurchaseMasterAndTransaction item = new InventoryPurchaseMasterAndTransaction();
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SupplierName"]) == false)
                        {
                            item.SupplierName = Convert.ToString(sqlDataReader["SupplierName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CustomerMobileNumber"]) == false)
                        //{
                        //    item.CustomerMobileNumber = Convert.ToString(sqlDataReader["CustomerMobileNumber"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalBillAmountincludingTax"]) == false)
                        //{
                        //    item.TotalBillAmountincludingTax = Convert.ToDecimal(sqlDataReader["TotalBillAmountincludingTax"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["BillAmount"]) == false)
                        {
                            item.BillAmount = Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["TaxRate"]) == false)
                        //{
                        //    item.TaxRate = Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalDiscountAmount"]) == false)
                        //{
                        //    item.TotalDiscountAmount = Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        //}
                        //if (searchRequest.IsAllocateToLocation == true)
                        //{
                        //    item.IsActive = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        //{
                        //    item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PrintingLine1"]) == false)
                        //{
                        //    item.PrintingLine1 = Convert.ToString(sqlDataReader["PrintingLine1"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PrintingLine2"]) == false)
                        //{
                        //    item.PrintingLine2 = Convert.ToString(sqlDataReader["PrintingLine2"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PrintingLine3"]) == false)
                        //{
                        //    item.PrintingLine3 = Convert.ToString(sqlDataReader["PrintingLine3"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["PrintingLine4"]) == false)
                        //{
                        //    item.PrintingLine4 = Convert.ToString(sqlDataReader["PrintingLine4"]);
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
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> CheckFocusOnAction(InventoryPurchaseMasterAndTransaction item)
        {
            IBaseEntityResponse<InventoryPurchaseMasterAndTransaction> response = new BaseEntityResponse<InventoryPurchaseMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPurchaseMaster_CheckFocusOnAction";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionOn", SqlDbType.NVarChar, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemID));
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
                        InventoryPurchaseMasterAndTransaction _item = new InventoryPurchaseMasterAndTransaction();
                        if (item.ActionName == "" || item.ActionName == null)
                        {
                            response.Entity = null;
                        }
                        else
                        { 

                        if (DBNull.Value.Equals(sqlDataReader["ActionID"]) == false)
                        {
                            _item.ActionID = Convert.ToInt32(sqlDataReader["ActionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpiryDate"]) == false)
                        {
                            _item.ExpiryDate = Convert.ToString(sqlDataReader["ExpiryDate"]);
                        }

                        response.Entity = _item;
                        }
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

        #endregion
    }
}

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
    public class InventoryIssueMasterAndIssueDetailsDataProvider : DBInteractionBase, IInventoryIssueMasterAndIssueDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        
        /// Constructor to initialized data member and member functions        
        public InventoryIssueMasterAndIssueDetailsDataProvider()
        {
        }
        
        /// Constructor to initialized data member and member functions        
        public InventoryIssueMasterAndIssueDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        // InventoryIssueMaster Method
        #region InventoryIssueMaster

        /// Select all record from InventoryIssueMaster table.     
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryIssueMasterAndIssueDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryIssueMasterAndIssueDetails item = new InventoryIssueMasterAndIssueDetails();

                        //Property of EntranceExamAvailableCentres
                        //item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        //item.CentreName = sqlDataReader["CentreName"].ToString();
                        //item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //item.Address = sqlDataReader["Address"].ToString();
                        //item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

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
                        throw new Exception("Stored Procedure 'USP_InventoryIssueMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from InventoryIssueMaster table by ID        
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterByID(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.InventoryIssueMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryIssueMasterAndIssueDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryIssueMasterAndIssueDetails item = new InventoryIssueMasterAndIssueDetails();
                        //Property of InventoryIssueMaster
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryIssueMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueNumber"]) == false)
                        {
                            item.IssueNumber = sqlDataReader["IssueNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueFromLocationID"]) == false)
                        {
                            item.IssueFromLocationID = Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueToLocationId"]) == false)
                        {
                            item.IssueToLocationID = Convert.ToInt32(sqlDataReader["IssueToLocationId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvIssueDetailsID"]) == false)
                        {
                            item.InventoryIssueDetailID = Convert.ToInt32(sqlDataReader["InvIssueDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.AvailbleQuantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueFromLocation"]) == false)
                        {
                            item.IssueFromLocationName = sqlDataReader["IssueFromLocation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueToLocation"]) == false)
                        {
                            item.IssueToLocationName = sqlDataReader["IssueToLocation"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_InventoryIssueMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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

        /// Create new record of the table        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssue_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of InventoryIssueMaster
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryIssueMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.TransactionDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iIssueFromLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IssueFromLocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iIssueToLocationId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IssueToLocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetId", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xIssueDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IssueDetails));

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
                        item.InventoryIssueMasterID = (Int32)cmdToExecute.Parameters["@InventoryIssueMasterID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssue_InsertXML' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of InventoryIssueMaster        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));

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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssueMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of InventoryIssueMaster        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of InventoryIssueMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));

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
                    item.InventoryIssueMasterID = (Int32)cmdToExecute.Parameters["@InventoryIssueMasterID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssueMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from InventoryIssueMasterAndIssueDetails table.
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamAvailableCentresSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryIssueMasterAndIssueDetails>();

                    while (sqlDataReader.Read())
                    {
                        InventoryIssueMasterAndIssueDetails item = new InventoryIssueMasterAndIssueDetails();

                        //Property of InventoryIssueMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        //{
                        //    item.CentreName = sqlDataReader["CentreName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GenLocationID"]) == false)
                        //{
                        //    item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        //{
                        //    item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        //{
                        //    item.Address = sqlDataReader["Address"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        //{
                        //    item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveUpto"]) == false)
                        //{
                        //    item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryIssueMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        // InventoryIssueDetails Method
        #region InventoryIssueDetails

        /// Select all record from InventoryIssueDetails table.     
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryIssueMasterAndIssueDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryIssueMasterAndIssueDetails item = new InventoryIssueMasterAndIssueDetails();

                        //Property of InventoryIssueMaster
                        item.InventoryIssueMasterID = Convert.ToInt32(sqlDataReader["IssueMasterID"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        item.IssueNumber = sqlDataReader["IssueNumber"].ToString();                        
                        item.IssueFromLocationName = sqlDataReader["IssueFromLocationName"].ToString();
                        item.IssueToLocationName = sqlDataReader["IssueToLocationName"].ToString();
                        item.IssueFromLocationID = Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.IssueToLocationID = Convert.ToInt32(sqlDataReader["IssueToLocationId"]);
                        
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
                        throw new Exception("Stored Procedure 'USP_InventoryIssueMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from InventoryIssueDetailsByID.        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsByID(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
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
                        InventoryIssueMasterAndIssueDetails _item = new InventoryIssueMasterAndIssueDetails();

                        //Property of EntranceExamAvailableCentres
                        //_item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //_item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //_item.Address = sqlDataReader["Address"].ToString();
                        //_item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //_item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryIssueDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of InventoryIssueMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));

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
                        item.InventoryIssueDetailID = (Int32)cmdToExecute.Parameters["@InventoryIssueDetailID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssueDetails_INSERT' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of InventoryIssueDetails        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));

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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssueDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of InventoryIssueDetails        
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> response = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of InventoryIssueMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));

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
                    item.InventoryIssueMasterID = (Int32)cmdToExecute.Parameters["@InventoryIssueMasterID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryIssueDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from InventoryIssueDetailsSearchList table.
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamAvailableCentresSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryIssueMasterAndIssueDetails>();

                    while (sqlDataReader.Read())
                    {
                        InventoryIssueMasterAndIssueDetails item = new InventoryIssueMasterAndIssueDetails();

                        //Property of InventoryIssueMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        //{
                        //    item.CentreName = sqlDataReader["CentreName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GenLocationID"]) == false)
                        //{
                        //    item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        //{
                        //    item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        //{
                        //    item.Address = sqlDataReader["Address"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        //{
                        //    item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveUpto"]) == false)
                        //{
                        //    item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryIssueDetails_SearchList' reported the ErrorCode: " + _errorCode);
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


        //Issue Location List.
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryIssueLocationMasterList(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryIssueLocationMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryLocationMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryLocationMaster item = new InventoryLocationMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.LocationName = sqlDataReader["LocationName"].ToString();
                        // item.AccBalanceSheetID = Convert.ToInt32(sqlDataReader["BalasheetId"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryIssueLocationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

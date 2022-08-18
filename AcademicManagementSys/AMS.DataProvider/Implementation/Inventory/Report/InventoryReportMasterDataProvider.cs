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
    public class InventoryReportMasterDataProvider : DBInteractionBase, IInventoryReportMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor

        /// Constructor to initialized data member and member functions        
        public InventoryReportMasterDataProvider()
        {
        }
        
        /// Constructor to initialized data member and member functions        
        public InventoryReportMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["DeveloperDBEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation 

        // InventoryReportMaster Method
        #region InventoryReportMaster

       
        /// Select a record from InventoryReportMaster table by ID        
        public IBaseEntityResponse<InventoryReportMaster> GetInventoryReportMasterByID(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> response = new BaseEntityResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryReportMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LocationID));
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
                        InventoryReportMaster _item = new InventoryReportMaster();

                        //Property of EntranceExamPaymentDetails
                        //if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        //{
                        //    _item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        //{
                        //    _item.StudentName = sqlDataReader["StudentName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_InventoryReportMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryReportMaster> InsertInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> response = new BaseEntityResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryReportMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of InventoryReportMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamValidationParameterApplicableID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamValidationParameterApplicableID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dcPaymentAmount", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentAmount));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiPaymentMode", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentMode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPaymentThrough", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentThrough));
                    
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
                        item.LocationID = (Int32)cmdToExecute.Parameters["@iLocationID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryReportMaster_Insert' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of InventoryReportMaster        
        public IBaseEntityResponse<InventoryReportMaster> UpdateInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> response = new BaseEntityResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryReportMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of InventoryReportMaster
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryReportMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of InventoryReportMaster        
        public IBaseEntityResponse<InventoryReportMaster> DeleteInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> response = new BaseEntityResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryReportMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamPaymentDetails
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));

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
                    item.LocationID = (Int32)cmdToExecute.Parameters["@iLocationID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryReportMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from InventoryReportMaster table with search list.
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetInventoryReportMasterSearchList(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryReportMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsInventoryReportMasterSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.InventoryReportMasterSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();

                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();

                        //Property of InventoryReportMaster
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
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


        /// Select all record from InventoryReportMaster table with search parameters        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetItemWiseConsumptionBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemwiseConsumption_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.VarChar, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xItemIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNameListXml));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();
                        //Property of InventoryReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["Date"]) == false)
                        {
                            item.TransactionDate = sqlDataReader["Date"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = sqlDataReader["LocationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }

                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;

                        baseEntityCollection.CollectionResponse.Add(item);                      
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemwiseConsumption_Report' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from DailyRateChange        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyRateChangeBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_DailyRateChange_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();

                        //Property of InventoryReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["Date"]) == false)
                        {
                            item.TransactionDate = sqlDataReader["Date"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentRate"]) == false)
                        {
                            item.CurrentRate = Convert.ToDecimal(sqlDataReader["CurrentRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousRate"]) == false)
                        {
                            item.PreviousRate = Convert.ToDecimal(sqlDataReader["PreviousRate"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["PreviousRate"]) == false)
                        //{
                        //    item.op = Convert.ToDecimal(sqlDataReader["PreviousRate"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
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
                        throw new Exception("Stored Procedure 'USP_DailyRateChange_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from DumpAndShrinkReport        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDumpAndShrinkReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandTimeout = 20000;
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrink_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();

                        //Property of InventoryReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OpeningBalance"]) == false)
                        {
                            item.OpeningBalance = Convert.ToDecimal(sqlDataReader["OpeningBalance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ClosingBalance"]) == false)
                        {
                            item.ClosingBalance = Convert.ToDecimal(sqlDataReader["ClosingBalance"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                        item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalInwardQuantity"]) == false)
                        {
                            item.TotalInwardQuantity = Convert.ToDecimal(sqlDataReader["TotalInwardQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalOutwardQuantity"]) == false)
                        {
                            item.TotalOutwardQuantity = Convert.ToDecimal(sqlDataReader["TotalOutwardQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpQuantity"]) == false)
                        {
                            item.DumpQuantity = Convert.ToDecimal(sqlDataReader["DumpQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShrinkQuantity"]) == false)
                        {
                            item.ShrinkQuantity = Convert.ToDecimal(sqlDataReader["ShrinkQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalPurchaseQuantity"]) == false)
                        {
                            item.TotalPurchaseQuantity = Convert.ToDecimal(sqlDataReader["TotalPurchaseQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalSaleQuantity"]) == false)
                        {
                            item.TotalSaleQuantity = Convert.ToDecimal(sqlDataReader["TotalSaleQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = sqlDataReader["LocationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = sqlDataReader["ItemCode"].ToString();
                        }
                       
                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDumpAndShrink_Report' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from InventoryReportMaster table with search parameters ( DailyItemRateChange Report)       
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyItemRateChangeReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDailyRateChange_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.VarChar, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();
                        //Property of InventoryReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        {
                            item.CategoryCode = sqlDataReader["CategoryDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = sqlDataReader["ItemCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentRate"]) == false)
                        {
                            item.CurrentRate = Convert.ToDecimal(sqlDataReader["CurrentRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PreviousSaleRate"]) == false)
                        {
                            item.PreviousSaleRate = Convert.ToDecimal(sqlDataReader["PreviousSaleRate"]);
                        }

                        item.FromDate = searchRequest.FromDate;
                        item.UptoDate = searchRequest.UptoDate;

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDailyItemRateChange_Report' reported the ErrorCode: " + _errorCode);
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

        //Below Indend Level Report.
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetBelowIndendLevelReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryBelowIndendLevelList_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountBalsheetMstID));                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@xLocationIDXmlString", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationNameListXml));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryReportMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryReportMaster item = new InventoryReportMaster();

                        //Property of InventoryReportMaster
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        {
                            item.CategoryCode = sqlDataReader["CategoryCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MinIndentLevel"]) == false)
                        {
                            item.MinIndentLevel = Convert.ToDecimal(sqlDataReader["MinIndentLevel"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Category"]) == false)
                        {
                            item.Category = sqlDataReader["Category"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentQuantity"]) == false)
                        {
                            item.CurrentQuantity = Convert.ToDecimal(sqlDataReader["CurrentQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = sqlDataReader["LocationName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IndendQuantity"]) == false)
                        {
                            item.IndendQuantity = Convert.ToDecimal(sqlDataReader["IndendQuantity"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        //baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryBelowIndendLevelList_Report' reported the ErrorCode: " + _errorCode);
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

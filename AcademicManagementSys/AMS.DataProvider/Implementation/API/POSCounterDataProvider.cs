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
    public class POSCounterDataProvider : DBInteractionBase, IPOSCounterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public POSCounterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public POSCounterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityCollectionResponse<POSCounter> GeneralCounterPOSApplicableGetOnline(POSCounterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<POSCounter> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralCounterPOSApplicable_GetOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DeviceToken));
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

                    baseEntityCollection.CollectionResponse = new List<POSCounter>();
                    while (sqlDataReader.Read())
                    {
                        POSCounter item = new POSCounter();

                        if (DBNull.Value.Equals(sqlDataReader["CounterPOSApplicableID"]) == false)
                        {
                            item.CounterPOSApplicableID = Convert.ToInt32(sqlDataReader["CounterPOSApplicableID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                        {
                            item.GeneralUnitsID = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralCounterMasterID"]) == false)
                        {
                            item.CounterMstID = Convert.ToInt32(sqlDataReader["GeneralCounterMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralPOSMasterID"]) == false)
                        {
                            item.POSMasterID = Convert.ToInt32(sqlDataReader["GeneralPOSMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralWeavingMachineMasterID"]) == false)
                        {
                            item.GeneralWeavingMachineMasterID = Convert.ToInt32(sqlDataReader["GeneralWeavingMachineMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateFrom"]) == false)
                        {
                            item.DateFrom = Convert.ToString(sqlDataReader["DateFrom"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateUpto"]) == false)
                        {
                            item.DateUpto = Convert.ToString(sqlDataReader["DateUpto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCurrent"]) == false)
                        {
                            item.IsCurrent = Convert.ToBoolean(sqlDataReader["IsCurrent"]);
                        } 

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<POSCounter> UserMasterGetOnlineForPOS(POSCounterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<POSCounter> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMasterGetOnline_ForPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DeviceToken));
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

                    baseEntityCollection.CollectionResponse = new List<POSCounter>();
                    while (sqlDataReader.Read())
                    {
                        POSCounter item = new POSCounter();

                        if (DBNull.Value.Equals(sqlDataReader["UserID"]) == false)
                        {
                            item.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["UserTypeID"]) == false)
                        {
                            item.UserTypeID = Convert.ToInt16(sqlDataReader["UserTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UserType"]) == false)
                        {
                            item.UserType = Convert.ToString(sqlDataReader["UserType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = Convert.ToString(sqlDataReader["EmailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Password"]) == false)
                        {
                            item.Password = Convert.ToString(sqlDataReader["Password"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PersonID"]) == false)
                        {
                            item.PersonID = Convert.ToInt32(sqlDataReader["PersonID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                        {
                            item.FirstName = Convert.ToString(sqlDataReader["FirstName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                        {
                            item.MiddleName = Convert.ToString(sqlDataReader["MiddleName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                        {
                            item.LastName = Convert.ToString(sqlDataReader["LastName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                        {
                            item.Gender = Convert.ToString(sqlDataReader["Gender"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfBirth"]) == false)
                        {
                            item.DateOfBirth = Convert.ToString(sqlDataReader["DateOfBirth"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToString(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToString(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeletedDate"]) == false)
                        {
                            item.DeletedDate = Convert.ToString(sqlDataReader["DeletedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<POSCounter> InventoryPOSSelfAssignPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> response = new BaseEntityResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPOSSelfAssign_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    // while (sqlDataReader.Read())
                    // {
                    POSCounter _item = new POSCounter();

                    _item.Status = (int)cmdToExecute.Parameters["@iStatus"].Value;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<POSCounter> CounterLogPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> response = new BaseEntityResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesMasterAndTransaction_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    // while (sqlDataReader.Read())
                    // {
                    POSCounter _item = new POSCounter();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    _item.Status = (int)_errorCode;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<POSCounter> UserLogPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> response = new BaseEntityResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRunningNumberForLocalInvoice_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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
                    POSCounter _item = new POSCounter();
                    while (sqlDataReader.Read())
                    {
                        
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        _item.ErrorMessage = "Something Went Wrong";
                        _item.Status = 100;
                    }
                    else
                    {
                        _item.ErrorMessage = "Bill Number Details are retrieved successfully.";
                        _item.Status = 200;
                    }
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<POSCounter> UserLogsPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> response = new BaseEntityResponse<POSCounter>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRunningNumberForLocalInvoice_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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
                    POSCounter _item = new POSCounter();
                    while (sqlDataReader.Read())
                    {
                        
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        _item.ErrorMessage = "Something Went Wrong";
                        _item.Status = 100;
                    }
                    else
                    {
                        _item.ErrorMessage = "Bill Number Details are retrieved successfully.";
                        _item.Status = 200;
                    }
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
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
       
    }
}

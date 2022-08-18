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
    public class UserMasterAPIDataProvider : DBInteractionBase, IUserMasterAPIDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public UserMasterAPIDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public UserMasterAPIDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from UserMasterAPI table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMasterAPI> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMasterAPI>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserMasterGetOnlineForPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (!string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DeviceCode));
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
                    baseEntityCollection.CollectionResponse = new List<UserMasterAPI>();
                    while (sqlDataReader.Read())
                    {
                        UserMasterAPI item = new UserMasterAPI();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.UserTypeID = sqlDataReader["UserTypeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["UserTypeID"]);
                        item.UserType = sqlDataReader["UserType"] is DBNull ? new char() : Convert.ToChar(sqlDataReader["UserType"]);
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.Password = sqlDataReader["Password"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Password"]);
                        item.PersonID = sqlDataReader["PersonID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.FirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                        item.LastName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Gender"]);
                        item.DateOfBirth = sqlDataReader["DateOfBirth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DateOfBirth"]);
                        item.DeviceToken = sqlDataReader["DateOfBirth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeviceToken"]);
                        item.IsActive = sqlDataReader["IsActive"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.CreatedBy = sqlDataReader["CreatedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreatedDate"]);
                        item.ModifiedBy = sqlDataReader["ModifiedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModifiedDate"]);
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.Flag = sqlDataReader["Flag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Flag"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMasterAPI_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI item)
        {
            IBaseEntityResponse<UserMasterAPI> response = new BaseEntityResponse<UserMasterAPI>();
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
                    cmdToExecute.CommandText = "dbo.USP_UserLogPostOnlineFromPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@xUserLogsXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.UserLogsXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xUserLogXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserLogXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ErrorMessage) ? string.Empty : item.ErrorMessage));
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

                    UserMasterAPI _item = new UserMasterAPI();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ConnectionString = string.Empty;
                    response.Entity = item;

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200 && _errorCode != 100)
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

        public IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMasterAPI> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<UserMasterAPI>();
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
                    cmdToExecute.CommandText = "dbo.USP_AccountsessionMaster_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (!string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
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
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<UserMasterAPI>();
                    while (sqlDataReader.Read())
                    {
                        UserMasterAPI item = new UserMasterAPI();
                        item.AccountsessionMasterID     = sqlDataReader["AccountsessionMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountsessionMasterID"]);
                        item.SessionStartDatetime       = sqlDataReader["SessionStartDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionStartDatetime"]);
                        item.SessionEndDatetime         = sqlDataReader["SessionEndDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionEndDatetime"]);
                        item.DefaultFlag                = sqlDataReader["DefaultFlag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["DefaultFlag"]);
                        item.Account_System             = sqlDataReader["Account_System"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Account_System"]);
                        item.IsActive                   = sqlDataReader["IsActive"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.CreatedBy                  = sqlDataReader["CreatedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.OldSessionID               = sqlDataReader["OldSessionID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["OldSessionID"]);
                        item.IsSessionClosed            = sqlDataReader["IsSessionClosed"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsSessionClosed"]);
                        item.IsBalanceCarryForward      = sqlDataReader["IsBalanceCarryForward"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsBalanceCarryForward"]); 
                        item.CreatedDate                = sqlDataReader["CreatedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreatedDate"]);
                        item.ModifiedBy                 = sqlDataReader["ModifiedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        item.ModifiedDate               = sqlDataReader["ModifiedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModifiedDate"]);
                        item.IsDeleted                  = sqlDataReader["IsDeleted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.Flag                       = sqlDataReader["Flag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Flag"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMasterAPI_SelectAll' reported the ErrorCode: " + _errorCode);
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

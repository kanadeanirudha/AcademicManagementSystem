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
    public class GeneralCounterPOSApllicableDataProvider : DBInteractionBase, IGeneralCounterPOSApllicableDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralCounterPOSApllicableDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralCounterPOSApllicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from GeneralCounterPOSApllicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> GetGeneralCounterPOSApllicable(GeneralCounterPOSApllicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralCounterPOSApllicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralCounterPOSApplicableGetOnline";
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
                    baseEntityCollection.CollectionResponse = new List<GeneralCounterPOSApllicable>();
                    while (sqlDataReader.Read())
                    {
                        GeneralCounterPOSApllicable item = new GeneralCounterPOSApllicable();                        
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitsID"]);  
                        item.GeneralCounterMasterID = sqlDataReader["GeneralCounterMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralCounterMasterID"]);
                        item.GeneralPOSMasterID = sqlDataReader["GeneralCounterMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralPOSMasterID"]);
                        item.GeneralWeavingMachineMasterID = sqlDataReader["GeneralWeavingMachineMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralWeavingMachineMasterID"]);
                        item.DateFrom = sqlDataReader["DateFrom"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DateFrom"]);
                        item.DateUpto = sqlDataReader["DateUpto"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DateUpto"]);
                        item.IsCurrent = sqlDataReader["IsCurrent"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsCurrent"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralCounterPOSApllicable_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<GeneralCounterPOSApllicable> PostPOSSelfAssignData(GeneralCounterPOSApllicable item)
        {
            IBaseEntityResponse<GeneralCounterPOSApllicable> response = new BaseEntityResponse<GeneralCounterPOSApllicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryPOSSelfAssignPostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInventoryAllocatePosOperatorXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryAllocatePosOperatorXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInventoryCounterLog", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryCounterLogXML));
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

                    GeneralCounterPOSApllicable _item = new GeneralCounterPOSApllicable();
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

        public IBaseEntityResponse<GeneralCounterPOSApllicable> CheckPOSSelfAssignDataCount(GeneralCounterPOSApllicable item)
        {
            IBaseEntityResponse<GeneralCounterPOSApllicable> response = new BaseEntityResponse<GeneralCounterPOSApllicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_CheckCounterLogAndAllocatePosCount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDataAvailable", SqlDbType.Bit, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
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

                    GeneralCounterPOSApllicable _item = new GeneralCounterPOSApllicable();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.IsDataAvailable= (bool)cmdToExecute.Parameters["@bIsDataAvailable"].Value;
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

        #endregion
    }
}

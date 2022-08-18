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
    public class GeneralTimeZoneMasterDataProvider : DBInteractionBase, IGeneralTimeZoneMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GeneralTimeZoneMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GeneralTimeZoneMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from GeneralTimeZoneMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTimeZoneMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralTimeZoneMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralTimeZoneMasterGetOnline";
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
                    baseEntityCollection.CollectionResponse = new List<GeneralTimeZoneMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralTimeZoneMaster item = new GeneralTimeZoneMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.TimeZone = sqlDataReader["TimeZone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TimeZone"]);
                        item.Coordinates= sqlDataReader["Coordinates"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Coordinates"]);
                        item.CountryCode = sqlDataReader["CountryCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CountryCode"]);
                        item.Comments = sqlDataReader["Comments"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Comments"]);
                        item.UTCoffset = sqlDataReader["UTCoffset"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UTCoffset"]);
                        item.UTCDSToffset = sqlDataReader["UTCDSToffset"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UTCDSToffset"]);
                        item.Notes = sqlDataReader["Notes"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Notes"]);
                        item.CreatedBy = sqlDataReader["CreatedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreatedDate"]);
                        item.ModifiedBy = sqlDataReader["ModifiedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModifiedDate"]);
                        item.DeletedBy = sqlDataReader["DeletedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        item.DeletedDate = sqlDataReader["DeletedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeletedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_GeneralTimeZoneMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

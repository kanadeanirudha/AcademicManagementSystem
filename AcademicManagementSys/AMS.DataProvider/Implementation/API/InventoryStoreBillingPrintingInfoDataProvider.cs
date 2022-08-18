
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
    public class InventoryStoreBillingPrintingInfoDataProvider : DBInteractionBase, IInventoryStoreBillingPrintingInfoDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryStoreBillingPrintingInfoDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryStoreBillingPrintingInfoDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from InventoryStoreBillingPrintingInfo table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryStoreBillingPrintingInfo_GetOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryStoreBillingPrintingInfo>();
                    while (sqlDataReader.Read())
                    {
                        InventoryStoreBillingPrintingInfo item = new InventoryStoreBillingPrintingInfo();
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.Address = sqlDataReader["Address"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address"]);
                        item.Footer = sqlDataReader["Footer"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Footer"]);
                        item.LogoPath = sqlDataReader["LogoPath"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LogoPath"]);
                        item.Pincode = sqlDataReader["Pincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Pincode"]);
                        item.TelephoneNumber = sqlDataReader["TelephoneNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TelephoneNumber"]);
                        item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.Url = sqlDataReader["Url"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Url"]);
                        item.DisplayIcon = sqlDataReader["DisplayIcon"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DisplayIcon"]);
                        item.Greeting = sqlDataReader["Greeting"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Greeting"]);
                        item.IsFooter = sqlDataReader["IsFooter"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsFooter"]);
                        item.IsLogoPath = sqlDataReader["IsLogoPath"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsLogoPath"]);
                        item.IsPincode = sqlDataReader["IsPincode"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsPincode"]);
                        item.IsTelephoneNumber = sqlDataReader["IsTelephoneNumber"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsTelephoneNumber"]);
                        item.IsFaxNumber = sqlDataReader["IsFaxNumber"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsFaxNumber"]);
                        item.IsEmailID = sqlDataReader["IsEmailID"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsEmailID"]);
                        item.IsUrl = sqlDataReader["IsUrl"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsUrl"]);
                        item.isGreeting = sqlDataReader["isGreeting"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["isGreeting"]);
                        item.IsAddress = sqlDataReader["IsAddress"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsAddress"]);
                        item.IsCityName = sqlDataReader["IsCityName"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsCityName"]);

                        item.CreatedBy = sqlDataReader["CreatedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreatedDate"]);
                        item.ModifiedBy = sqlDataReader["ModifiedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModifiedDate"]);
                        item.DeletedBy = sqlDataReader["DeletedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        item.DeletedDate = sqlDataReader["DeletedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeletedDate"]);
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.Flag = sqlDataReader["Flag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Flag"]);
                        item.CityName= sqlDataReader["CityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CityName"]);



                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryStoreBillingPrintingInfo_SelectAll' reported the ErrorCode: " + _errorCode);
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


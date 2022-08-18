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
    public class InventoryDailySaleReportDataProvider: DBInteractionBase, IInventoryDailySaleReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryDailySaleReportDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryDailySaleReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation
        /// <summary>
        /// Select all record from InventoryDailySaleReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDailySaleReport> GetInventoryDailySaleReportBySearch(InventoryDailySaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDailySaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDailySaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDailySale_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.UptoDate)));

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

                    baseEntityCollection.CollectionResponse = new List<InventoryDailySaleReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDailySaleReport item = new InventoryDailySaleReport();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt64(sqlDataReader["ID"]);
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
                            item.BillAmount = Math.Round(Convert.ToDecimal(sqlDataReader["BillAmount"]),2);   
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoundUpAmount"]) == false)
                        {
                            item.RoundUpAmount = Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerType"]) == false)
                        {
                            item.CustomerType = Convert.ToString(sqlDataReader["CustomerType"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt32(sqlDataReader["BalanceSheetID"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CounterLogId"]) == false)
                        {
                            item.CounterLogId = Convert.ToInt32(sqlDataReader["CounterLogId"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.LocationName = Convert.ToString(sqlDataReader["LocationName"]);     
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetHeadDesc"]) == false)
                        {
                           item.AccBalsheetHeadDesc = Convert.ToString(sqlDataReader["AccBalsheetHeadDesc"]);       
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccBalsheetCode"]) == false)
                        {
                            item.AccBalsheetCode = Convert.ToString(sqlDataReader["AccBalsheetCode"]);       
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDailySaleAmount"]) == false)
                        {
                            item.TotalDailySaleAmount = Math.Round(Convert.ToDecimal(sqlDataReader["TotalDailySaleAmount"]), 2);      
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
                        throw new Exception("Stored Procedure 'USP_InventoryDailySaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

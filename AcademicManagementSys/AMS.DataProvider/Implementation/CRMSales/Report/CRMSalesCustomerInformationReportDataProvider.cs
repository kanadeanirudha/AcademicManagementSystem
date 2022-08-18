using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public class CRMSalesCustomerInformationReportDataProvider : DBInteractionBase, ICRMSalesCustomerInformationReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public CRMSalesCustomerInformationReportDataProvider() { }
        public CRMSalesCustomerInformationReportDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReportBySearch_Account(CRMSalesCustomerInformationReportSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> baseEntityCollection = new BaseEntityCollectionResponse<CRMSalesCustomerInformationReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSalesCustomerInformation_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtStartDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionFromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dtEndDate", SqlDbType.Date, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionUptoDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstId));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccSessionId", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccountSessionID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsSubLedger", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.IsSubLedger));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@cAssetLiabilityFlag", SqlDbType.Char, 5, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AssetLiabilityFlag));
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
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

                    baseEntityCollection.CollectionResponse = new List<CRMSalesCustomerInformationReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSalesCustomerInformationReport item = new CRMSalesCustomerInformationReport();

                        if (DBNull.Value.Equals(sqlDataReader["AccountName"])== false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContactPersonName"]) == false)
                        {
                            item.ContactPersonName = Convert.ToString(sqlDataReader["ContactPersonName"]); 
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Designation"]) == false)
                        {
                            item.Designation = Convert.ToString(sqlDataReader["Designation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailId"]) == false)
                        {
                            item.EmailId = Convert.ToString(sqlDataReader["EmailId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            item.MobileNumber = Convert.ToString(sqlDataReader["MobileNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["City"]) == false)
                        {
                            item.City = Convert.ToString(sqlDataReader["City"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Country"]) == false)
                        {
                            item.Country = Convert.ToString(sqlDataReader["Country"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsVisitingCardUploaded"]) == false)
                        {
                            item.IsVisitingCardUploaded = Convert.ToString(sqlDataReader["IsVisitingCardUploaded"]);
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

    }
}

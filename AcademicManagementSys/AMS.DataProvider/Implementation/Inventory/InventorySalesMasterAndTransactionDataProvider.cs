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
    public class InventorySalesMasterAndTransactionDataProvider : DBInteractionBase, IInventorySalesMasterAndTransactionDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventorySalesMasterAndTransactionDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventorySalesMasterAndTransactionDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from InventorySalesMasterAndTransaction table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionBySearch(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesMasterAndTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventorySalesMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventorySalesMasterAndTransaction item = new InventorySalesMasterAndTransaction();
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
                            item.BillAmount = Convert.ToInt32(sqlDataReader["BillAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BillPrintStatus = Convert.ToBoolean(sqlDataReader["BillPrintStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from InventorySalesMasterAndTransaction table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetBillDetailsByID(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySale_SelectBillDetails";
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
                    baseEntityCollection.CollectionResponse = new List<InventorySalesMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventorySalesMasterAndTransaction item = new InventorySalesMasterAndTransaction();
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
                        if (DBNull.Value.Equals(sqlDataReader["NetAmount"]) == false)
                        {
                            item.NetAmount = Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        }


                        //if (DBNull.Value.Equals(sqlDataReader["TaxInclusiveNetAmount"]) == false)
                        //{
                        //    item.NetAmount = Convert.ToDecimal(sqlDataReader["TaxInclusiveNetAmount"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["DeliveryCharge"]) == false)
                        {
                            item.DeliveryCharge = Convert.ToDecimal(sqlDataReader["DeliveryCharge"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalTaxAmount"]) == false)
                        {
                            item.TotalTaxAmount = Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDiscountAmount"]) == false)
                        {
                            item.TotalDiscount = Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["TaxInclusiveRate"]) == false)
                        //{
                        //    item.Rate = Convert.ToDecimal(sqlDataReader["TaxInclusiveRate"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine1"]) == false)
                        {
                            item.PrintingLine1 = Convert.ToString(sqlDataReader["PrintingLine1"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine2"]) == false)
                        {
                            item.PrintingLine2 = Convert.ToString(sqlDataReader["PrintingLine2"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine3"]) == false)
                        {
                            item.PrintingLine3 = Convert.ToString(sqlDataReader["PrintingLine3"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine4"]) == false)
                        {
                            item.PrintingLine4 = Convert.ToString(sqlDataReader["PrintingLine4"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxInPercentage"]) == false)
                        {
                            item.TaxInPercentage = Convert.ToDecimal(sqlDataReader["TaxInPercentage"]);
                        }
                        if (searchRequest.PolicyDefaultAnswer == "1")
                        {
                            var abc = item.Rate;
                            var abc1 = (((item.Rate) * (item.TaxInPercentage)) / 100);
                            var abc2 = (item.Rate + abc1);
                            item.Rate = Math.Round(abc2, 2);


                        }
                        if (searchRequest.PolicyDefaultAnswer == "1")
                        {
                            var abc = item.NetAmount;
                            var abc1 = item.TotalTaxAmount;
                            var abc2 = (abc + abc1);
                            item.NetAmount = Math.Round(abc2, 2);


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
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionByID(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        InventorySalesMasterAndTransaction _item = new InventorySalesMasterAndTransaction();

                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["FeeTypeDesc"]) == false)
                        //{
                        //    _item.FeeTypeDesc = sqlDataReader["FeeTypeDesc"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["FeeTypeCode"]) == false)
                        //{
                        //    _item.FeeTypeCode = sqlDataReader["FeeTypeCode"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        //{
                        //    _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> GetInventoryItemQuantity(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvWeighingData_SelectQuantity";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvCounterApplicableDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvCounterApplicableDetailsID));
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
                        InventorySalesMasterAndTransaction _item = new InventorySalesMasterAndTransaction();

                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            _item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> SelectHoldBillCount(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryHoldSalesMaster_SelectHoldCount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CounterID));
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
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InventorySalesMasterAndTransaction _item = new InventorySalesMasterAndTransaction();

                        if (DBNull.Value.Equals(sqlDataReader["HoldBillCount"]) == false)
                        {
                            _item.OpenBillCount = Convert.ToInt32(sqlDataReader["HoldBillCount"]);
                        }
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
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySale_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalGrossAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalDiscount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentByCustomer", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PaymentByCustomer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mReturnChange", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReturnChange));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDeliveryCharge", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeliveryCharge));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerName) ? item.CustomerName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerContactNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerContactNo) ? item.CustomerContactNo : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerAddress) ? item.CustomerAddress : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerType", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerType) ? item.CustomerType : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleFromLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSalesDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetId", SqlDbType.SmallInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCounterLogID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterLogID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterID));
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
                    item.ID = (int)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventorySalesMasterAndTransaction_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of InventorySalesMasterAndTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> UpdateInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeDesc));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
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
                    item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventorySalesMasterAndTransaction_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of InventorySalesMasterAndTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> DeleteInventorySalesMasterAndTransaction(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeType_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'dbo.USP_InventorySalesMasterAndTransaction_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesMasterAndTransactionBillPrintList(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "USP_InventoryHoldBillDetails_SelectOne";//"dbo.USP_InventorySalesMasterAndTransaction_BillPrintByInvSaleMstID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPressKeyNumber", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.keyPressNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CounterMstID));
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
                    baseEntityCollection.CollectionResponse = new List<InventorySalesMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventorySalesMasterAndTransaction item = new InventorySalesMasterAndTransaction();
                        if (DBNull.Value.Equals(sqlDataReader["BillAmount"]) == false)
                        {
                            item.TotalGrossAmount = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["BillAmount"]));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CounterLogID"]) == false)
                        {
                            item.CounterLogID = Convert.ToInt16(sqlDataReader["CounterLogID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalTaxAmount"]) == false)
                        {
                            item.TotalTaxAmount = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["TotalTaxAmount"]));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDiscountAmount"]) == false)
                        {
                            item.TotalDiscount = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["TotalDiscountAmount"]));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NetAmount"]) == false) { 
                            if (searchRequest.PolicyDefaultAnswer == "0")
                            {
                                {
                                    item.TotalBillAmount = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["NetAmount"]));
                                }
                            }
                            else
                            {
                                var abc1 = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["NetAmount"]));
                                var abc2 = item.TotalTaxAmount;
                                item.TotalBillAmount = Math.Round(abc1 + abc2 ,2);
                            }
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeliveryCharge"]) == false)
                        {
                            item.DeliveryCharge = Convert.ToDecimal(string.Format("{0:0.00}", sqlDataReader["DeliveryCharge"]));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxAmount"]) == false)
                        {
                            item.Tax = Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DiscountAmount"]) == false)
                        {
                            item.Discount = Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterID"]) == false)
                        {
                            item.GeneralTaxGroupID = Convert.ToInt32(sqlDataReader["GenTaxGroupMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DiscountInPercentage"]) == false)
                        {
                            item.DiscountInPercentage = Convert.ToDecimal(sqlDataReader["DiscountInPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxInPercentage"]) == false)
                        {
                            item.TaxInPercentage = Convert.ToDecimal(sqlDataReader["TaxInPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BatchNumber"]) == false)
                        {
                            item.BatchNumber = Convert.ToString(sqlDataReader["BatchNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpiryDate"]) == false)
                        {
                            item.ExpiryDate = Convert.ToString(sqlDataReader["ExpiryDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoundUpAmount"]) == false)
                        {
                            item.RoundUpAmount = Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        }
                        if (searchRequest.PolicyDefaultAnswer == "1")
                        {
                            if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                            {
                                item.RateIncludingtax = Convert.ToDecimal(sqlDataReader["Rate"]);
                            }
                            var abc = item.Rate;
                            var abc1 = (((item.Rate) * (item.TaxInPercentage)) / 100);
                            var abc2 = (item.Rate + abc1);
                            item.Rate = Math.Round(abc2, 2);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NetAmount"]) == false)
                        {
                            item.TotalBillAmountIncludeTaxTemplate = Math.Round(Convert.ToDecimal(sqlDataReader["NetAmount"]),2);
                        }

                        //if (DBNull.Value.Equals(sqlDataReader["CustomerContactNo"]) == false)
                        //{
                        //    item.CustomerContactNo = Convert.ToString(sqlDataReader["CustomerContactNo"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CustomerAddress"]) == false)
                        //{
                        //    item.CustomerAddress = Convert.ToString(sqlDataReader["CustomerAddress"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CustomerID"]) == false)
                        //{
                        //    item.CustomerID = Convert.ToInt32(sqlDataReader["CustomerID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["CustomerType"]) == false)
                        //{
                        //    item.CustomerType = Convert.ToString(sqlDataReader["CustomerType"]);
                        //}


                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["BatchID"]) == false)
                        {
                            item.BatchID = Convert.ToInt32(sqlDataReader["BatchID"]);
                        }

                        //if (DBNull.Value.Equals(sqlDataReader["ItemAmount"]) == false)
                        //{
                        //    item.ItemAmount = Convert.ToDecimal(sqlDataReader["ItemAmount"]);
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
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_BillPrintByInvSaleMstID' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventorySalesMasterAndTransaction> InsertInventoryHoldBill(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryHoldBill_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDeliveryCharge", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeliveryCharge));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalGrossAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalDiscount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerName) ? item.CustomerName : string.Empty));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerContactNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerContactNo) ? item.CustomerContactNo : string.Empty));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerAddress) ? item.CustomerAddress : string.Empty));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerType", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.CustomerType) ? item.CustomerType : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHoldBillRefference", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.HoldBillReference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleFromLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xHoldBillXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetId", SqlDbType.SmallInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterLogID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterLogID));
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
                    item.ID = (int)cmdToExecute.Parameters["@iNewID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventorySalesMasterAndTransaction_INSERT' reported the ErrorCode: " + _errorCode);
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

        //For Inventory Sale Report To operator
        public IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> GetInventorySalesReportToOperator(InventorySalesMasterAndTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventorySalesMasterAndTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleReportToOperator_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsOnline", SqlDbType.Bit, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.IsOnline));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CreatedBy));
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
                    baseEntityCollection.CollectionResponse = new List<InventorySalesMasterAndTransaction>();
                    while (sqlDataReader.Read())
                    {
                        InventorySalesMasterAndTransaction item = new InventorySalesMasterAndTransaction();

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                        {
                            item.EmployeeName = Convert.ToString(sqlDataReader["EmployeeName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.Location = Convert.ToString(sqlDataReader["LocationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Date"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["Date"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalSaleAmount"]) == false)
                        {
                            item.LocationWiseSale = Convert.ToDecimal(sqlDataReader["TotalSaleAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalSaleReturnAmount"]) == false)
                        {
                            item.TotalSaleReturnAmount = Convert.ToDecimal(sqlDataReader["TotalSaleReturnAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TodaysTotalSale"]) == false)
                        {
                            item.TodaysTotalSale = Convert.ToDecimal(sqlDataReader["TodaysTotalSale"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CounterMstID"]) == false)
                        {
                            item.CounterID = Convert.ToInt32(sqlDataReader["CounterMstID"]);
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
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_BillPrintByInvSaleMstID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<InventorySalesMasterAndTransaction> CheckFocusOnAction(InventorySalesMasterAndTransaction item)
        {
            IBaseEntityResponse<InventorySalesMasterAndTransaction> response = new BaseEntityResponse<InventorySalesMasterAndTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySaleMasterAndtransaction_CheckFocusOnAction";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionOn", SqlDbType.NVarChar, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionOn));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsActionName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActionName));
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
                        InventorySalesMasterAndTransaction _item = new InventorySalesMasterAndTransaction();
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
                        if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        {
                            _item.CustomerAddress = Convert.ToString(sqlDataReader["Address"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContactNumber"]) == false)
                        {
                            _item.CustomerContactNo = Convert.ToString(sqlDataReader["ContactNumber"]);
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

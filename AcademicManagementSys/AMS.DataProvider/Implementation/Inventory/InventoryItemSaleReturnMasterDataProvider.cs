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
    public class InventoryItemSaleReturnMasterDataProvider : DBInteractionBase, IInventoryItemSaleReturnMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

         #region Constructor
       
        /// Constructor to initialized data member and member functions       
        public InventoryItemSaleReturnMasterDataProvider()
        {
        }
       
        /// Constructor to initialized data member and member functions        
        public InventoryItemSaleReturnMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; 
            _logException = logException; 
        }
        #endregion

        #region Method Implementation

        
        /// Select all record from InventoryItemSaleReturnMaster table with search parameters        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBySearch(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMasterAndTransaction_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster item = new InventoryItemSaleReturnMaster();
                        if (DBNull.Value.Equals(sqlDataReader["InvBufferSalesMasterID"]) == false)
                        {
                            item.InvBufferSalesMasterID = Convert.ToInt32(sqlDataReader["InvBufferSalesMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalesReturnAmount"]) == false)
                        {
                            item.SalesReturnAmount = Convert.ToDecimal(sqlDataReader["SalesReturnAmount"]);
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CounterLogID"]) == false)
                        {
                            item.CounterLogID = Convert.ToInt16(sqlDataReader["CounterLogID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt16(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemSaleReturnMasterAndTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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
        
        /// Select a record from table by ID        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMasterAndTransaction_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvBufferSalesMasterID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.InvBufferSalesMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster _item = new InventoryItemSaleReturnMaster();
                        if (DBNull.Value.Equals(sqlDataReader["InvBufferSalesMasterID"]) == false)
                        {
                            _item.InvBufferSalesMasterID = Convert.ToInt16(sqlDataReader["InvBufferSalesMasterID"]);
                        }                                              
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            _item.BalanceSheetID = Convert.ToInt32(sqlDataReader["BalanceSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            _item.CustomerName = sqlDataReader["CustomerName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerID"]) == false)
                        {
                            _item.CustomerID = Convert.ToInt32(sqlDataReader["CustomerID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            _item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InvSalesDetailsID"]) == false)
                        {
                            _item.InvSalesDetailsID = Convert.ToInt32(sqlDataReader["InvSalesDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            _item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            _item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemAmount"]) == false)
                        {
                          _item.ItemAmount = Convert.ToDecimal(sqlDataReader["ItemAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            _item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            _item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitCode"]) == false)
                        {
                            _item.UnitCode = sqlDataReader["UnitCode"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            _item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxInPercentage"]) == false)
                        {
                            _item.TaxInPercentage = Convert.ToDecimal(sqlDataReader["TaxInPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DiscountInPercentage"]) == false)
                        {
                            _item.DiscountInPercentage = Convert.ToDecimal(sqlDataReader["DiscountInPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CounterLogID"]) == false)
                        {
                            _item.CounterLogID = Convert.ToInt32(sqlDataReader["CounterLogID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterID"]) == false)
                        {
                            _item.GenTaxGroupMasterID = Convert.ToInt32(sqlDataReader["GenTaxGroupMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            _item.BillNumber = sqlDataReader["BillNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BatchNumber"]) == false)
                        {
                           _item.BatchNumber = sqlDataReader["BatchNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpiryDate"]) == false)
                        {
                            _item.ExpiryDate = sqlDataReader["ExpiryDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DeliveryCharge"]) == false)
                        {
                            _item.DeliveryCharge = Convert.ToDecimal(sqlDataReader["DeliveryCharge"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerType"]) == false)
                        {
                            _item.CustomerType = sqlDataReader["CustomerType"].ToString();
                        }


                        //if (DBNull.Value.Equals(sqlDataReader["BillAmount"]) == false)
                        //{
                        //    _item.BillAmount = Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["DiscountAmount"]) == false)
                        //{
                        //    _item.DiscountAmount = Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TaxAmount"]) == false)
                        //{
                        //    _item.TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalDiscountAmount"]) == false)
                        //{
                        //    _item.TotalDiscountAmount = Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ItemAmount"]) == false)
                        //{
                        //    _item.ItemAmount = Convert.ToDecimal(sqlDataReader["ItemAmount"]);
                        //}
                        

                        baseEntityCollection.CollectionResponse.Add(_item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemSaleReturnMasterAndTransaction_SelectOne' reported the ErrorCode: " + _errorCode);
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
        
        /// Select all record from InventoryItemSaleReturnMaster table with search parameters        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetBillDetailsByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.InvSalesRetrunMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster item = new InventoryItemSaleReturnMaster();
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
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
        
        /// Select a record from table by ID       
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> GetInventoryItemQuantity(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> response = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvCounterApplicableDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CounterLogID));
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
                        InventoryItemSaleReturnMaster _item = new InventoryItemSaleReturnMaster();
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
        
        /// Create new record of the table        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> InsertInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> response = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesReturn_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BillNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewID", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSaleReturnFromLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mNetAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NetAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDeliveryCharges", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DeliveryCharge));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetId", SqlDbType.SmallInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterLogID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CounterLogID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mSaleRetrunAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SalesReturnAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalDiscountAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerID", SqlDbType.Money, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CustomerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerType", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSalesReturnDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ReturnItemDetailxml));
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
                    item.InvSalesReturnMasterID = (int)cmdToExecute.Parameters["@iNewID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventorySalesReturn_InsertXML' reported the ErrorCode: " + _errorCode);
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
        
        /// Update a specific record of InventoryItemSaleReturnMaster        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> UpdateInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> response = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siInvSalesReturnMasterID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InvSalesReturnMasterID));
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
                    item.InvSalesReturnMasterID = (Int16)cmdToExecute.Parameters["@iInvSalesReturnMasterID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryItemSaleReturnMaster_Update' reported the ErrorCode: " +
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
        
        /// Delete a specific record of InventoryItemSaleReturnMaster        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> DeleteInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> response = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvSalesReturnMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InvSalesReturnMasterID));
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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryItemSaleReturnMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBillPrintList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMaster_BillPrintByInvSaleMstID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvSalesReturnMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.InvSalesRetrunMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster item = new InventoryItemSaleReturnMaster();
                        if (DBNull.Value.Equals(sqlDataReader["InvSalesReturnMasterID"]) == false)
                        {
                            item.InvSalesReturnMasterID = Convert.ToInt16(sqlDataReader["InvSalesReturnMasterID"]);
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }                        
                        
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt16(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemSaleReturnMaster_BillPrintByInvSaleMstID' reported the ErrorCode: " + _errorCode);
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


        //For Inventory Sale Report To operator
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventorySalesReportToOperator(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMaster_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 4));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster item = new InventoryItemSaleReturnMaster();                        
                        
                        if (DBNull.Value.Equals(sqlDataReader["Date"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["Date"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemSaleReturnMaster_BillPrintByInvSaleMstID' reported the ErrorCode: " + _errorCode);
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

        //Search List.
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterSearchList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemSaleReturnMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInvSalesRetrunMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.InvSalesRetrunMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemSaleReturnMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemSaleReturnMaster item = new InventoryItemSaleReturnMaster();
                        if (DBNull.Value.Equals(sqlDataReader["InvSalesReturnMasterID"]) == false)
                        {
                            item.InvSalesReturnMasterID = Convert.ToInt16(sqlDataReader["InvSalesReturnMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt16(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillNumber"]) == false)
                        {
                            item.BillNumber = Convert.ToString(sqlDataReader["BillNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemSaleReturnMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

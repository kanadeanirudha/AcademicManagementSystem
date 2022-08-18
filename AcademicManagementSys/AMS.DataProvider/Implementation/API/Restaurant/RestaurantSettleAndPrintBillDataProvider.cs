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
    public class RestaurantSettleAndPrintBillDataProvider : DBInteractionBase, IRestaurantSettleAndPrintBillDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public RestaurantSettleAndPrintBillDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public RestaurantSettleAndPrintBillDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> baseEntityCollection = new BaseEntityCollectionResponse<RestaurantSettleAndPrintBill>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantOrderPrintBill_GetOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.VarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BillNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed,  string.Empty ));

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
                    baseEntityCollection.CollectionResponse = new List<RestaurantSettleAndPrintBill>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantSettleAndPrintBill _item = new RestaurantSettleAndPrintBill();
                        _item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        _item.GlobalInvoiceNumber = sqlDataReader["GlobalInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GlobalInvoiceNumber"]);
                        _item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        _item.BillAmount = sqlDataReader["BillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        _item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        _item.DeliveryCharge = sqlDataReader["DeliveryCharge"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryCharge"]);
                        _item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        _item.TotalDiscountAmount = sqlDataReader["TotalDiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        _item.PaymentByCustomer = sqlDataReader["PaymentByCustomer"] is DBNull ?0 : Convert.ToDecimal(sqlDataReader["PaymentByCustomer"]);
                        _item.ReturnChange = sqlDataReader["ReturnChange"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReturnChange"]);
                        _item.CounterID = sqlDataReader["CounterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CounterID"]);
                        _item.RoundUpAmount = sqlDataReader["RoundUpAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        _item.Customer = sqlDataReader["Customer"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Customer"]);
                        _item.PaymentMode = sqlDataReader["PaymentMode"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["PaymentMode"]);
                        _item.BillRelevantTo = sqlDataReader["BillRelevantTo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillRelevantTo"]);
                        _item.CustomerCode = sqlDataReader["CustomerCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CustomerCode"]);
                        _item.InventoryCounterLogID = sqlDataReader["InventoryCounterLogID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InventoryCounterLogID"]);
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        _item.MenuName = sqlDataReader["MenuName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MenuName"]);
                        _item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        _item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        _item.DiscountAmount = sqlDataReader["DiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        _item.DiscountInPercentage = sqlDataReader["DiscountInPercentage"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountInPercentage"]);
                        _item.TaxInPercentage = sqlDataReader["TaxInPercentage"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxInPercentage"]);
                        _item.Quantity = sqlDataReader["Quantity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Quantity"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterID"]);
                        _item.Price = sqlDataReader["Price"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Price"]);
                        _item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        _item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        _item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        _item.ItemAmount = sqlDataReader["ItemAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ItemAmount"]);
                        //_item.TableNumber = sqlDataReader["TableNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TableNumber"]);
                        //baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.CollectionResponse.Add(_item);
                    }

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

        public IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item)
        {
            IBaseEntityResponse<RestaurantSettleAndPrintBill> response = new BaseEntityResponse<RestaurantSettleAndPrintBill>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrderSettleBill_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iRestaurantTableOrderID", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RestaurantTableOrderID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CounterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalDiscountAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalNetAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.NetAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillAmount ", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mReturnChange", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ReturnChange));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentByCustomer", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentByCustomer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bPaymentMode", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,item.PaymentMode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 40, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Customer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CustomerCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalePromotionActivityDetailsID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SalePromotionActivityDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLocalInvoiceNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ErrorMessage)? string.Empty : item.ErrorMessage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.BillNumber) ? string.Empty : item.BillNumber));
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

                    item.BillNumber = (string)cmdToExecute.Parameters["@nsBillNumber"].Value;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;                   
                    response.Entity = item;
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

        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> baseEntityCollection = new BaseEntityCollectionResponse<RestaurantSettleAndPrintBill>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantBillList_GetOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPaidUnpaidFlag", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PaidUnpaidFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CounterID));

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
                    baseEntityCollection.CollectionResponse = new List<RestaurantSettleAndPrintBill>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantSettleAndPrintBill _item = new RestaurantSettleAndPrintBill();

                        _item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        _item.GlobalInvoiceNumber = sqlDataReader["GlobalInvoiceNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["GlobalInvoiceNumber"]);
                        _item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        _item.BillAmount = sqlDataReader["BillAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["BillAmount"]);
                        _item.LocalInvoiceNumber = sqlDataReader["LocalInvoiceNumber"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["LocalInvoiceNumber"]);
                        _item.NetAmount = sqlDataReader["NetAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["NetAmount"]);
                        _item.DeliveryCharge = sqlDataReader["DeliveryCharge"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeliveryCharge"]);
                        _item.TotalTaxAmount = sqlDataReader["TotalTaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        _item.TotalDiscountAmount = sqlDataReader["TotalDiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        _item.CounterID = sqlDataReader["CounterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CounterID"]);
                        _item.RoundUpAmount = sqlDataReader["RoundUpAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RoundUpAmount"]);
                        _item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        _item.Customer = sqlDataReader["Customer"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Customer"]);
                        _item.PaymentMode = sqlDataReader["PaymentMode"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["PaymentMode"]);
                        _item.BillRelevantTo = sqlDataReader["BillRelevantTo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillRelevantTo"]);
                        _item.TransactionNumber = sqlDataReader["TransactionNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionNumber"]);
                        _item.IsPaid = sqlDataReader["IsPaid"] is DBNull ?new Boolean(): Convert.ToBoolean(sqlDataReader["IsPaid"]);
                        _item.IsAvailableForPOS = sqlDataReader["IsAvailableForPOS"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["IsAvailableForPOS"]); 
                        _item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemNumber"]);
                        _item.GeneralItemCodeID = sqlDataReader["GeneralItemCodeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        _item.TaxAmount = sqlDataReader["TaxAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        _item.DiscountAmount = sqlDataReader["DiscountAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        _item.DiscountInPercentage = sqlDataReader["DiscountInPercentage"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercentage"]);
                        _item.TaxInPercentage = sqlDataReader["TaxInPercentage"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TaxInPercentage"]);
                        _item.Quantity = sqlDataReader["Quantity"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Quantity"]);
                        _item.GenTaxGroupMasterID = sqlDataReader["GenTaxGroupMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GenTaxGroupMasterID"]);
                        _item.Price = sqlDataReader["Price"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Price"]);
                        _item.BatchNumber = sqlDataReader["BatchNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BatchNumber"]);
                        _item.ExpiryDate = sqlDataReader["ExpiryDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExpiryDate"]);
                        _item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        _item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        _item.VariationMasterId = sqlDataReader["VariationMasterId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["VariationMasterId"]);
                        _item.RestaurantTableOrderID = sqlDataReader["RestaurantTableOrderID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["RestaurantTableOrderID"]);
                        _item.TableNumber = sqlDataReader["TableNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TableNumber"]);
                        _item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        _item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        _item.PromotionActivityFlag = sqlDataReader["PromotionActivityFlag"]is DBNull ?new Boolean(): Convert.ToBoolean(sqlDataReader["PromotionActivityFlag"]);
                        _item.IsRestaurant = sqlDataReader["IsRestaurant"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        _item.SaleTransactionID = sqlDataReader["SaleTransactionID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SaleTransactionID"]);

                        baseEntityCollection.CollectionResponse.Add(_item);
                    }

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



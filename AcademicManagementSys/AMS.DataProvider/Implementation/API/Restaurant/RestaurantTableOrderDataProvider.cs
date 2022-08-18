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
    public class RestaurantTableOrderDataProvider : DBInteractionBase, IRestaurantTableOrderDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public RestaurantTableOrderDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public RestaurantTableOrderDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrder(RestaurantTableOrder item)
        {
            IBaseEntityResponse<RestaurantTableOrder> response = new BaseEntityResponse<RestaurantTableOrder>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrder_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRestaurantTableOrderID", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaidBillNumber ", SqlDbType.NVarChar,30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PaidBillNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalBillAmount", SqlDbType.Money, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TotalBillAmt));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaymentReferenceCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PaymentReferenceCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTableNumber", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TableNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xOrderXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OrderXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTakeAway", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsTakeAway));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.CreatedBy)? 0 : Convert.ToInt32(item.CreatedBy)  ));
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

                    RestaurantTableOrder _item = new RestaurantTableOrder();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ID= (int)cmdToExecute.Parameters["@iRestaurantTableOrderID"].Value; 
                    item.ErrorCode = (Int32)_errorCode;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
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
        public IBaseEntityResponse<RestaurantTableOrder> PostTableOrderStatus(RestaurantTableOrder item)
        {
            IBaseEntityResponse<RestaurantTableOrder> response = new BaseEntityResponse<RestaurantTableOrder>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrderStatus_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@biRestaurantTableOrder", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsOrderServed", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsOrderServed));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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

                    RestaurantTableOrder _item = new RestaurantTableOrder();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
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
        
        public IBaseEntityCollectionResponse<RestaurantTableOrder> GetTableOrder(RestaurantTableOrderSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableOrder> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantTableOrder>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrder_GetOnLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTableNumber", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.TableNumber));
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantTableOrder>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantTableOrder item = new RestaurantTableOrder();

                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrderID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["RestaurantTableOrderID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrdersID"]) == false)
                        {
                            item.RestaurantTableOrdersID = Convert.ToInt32(sqlDataReader["RestaurantTableOrdersID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderDateTime"]) == false)
                        {
                            item.OrderDateTime = Convert.ToString(sqlDataReader["OrderDateTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpectedTimeGivenForOrder"]) == false)
                        {
                            item.ExpectedTimeGivenForOrder = Convert.ToString(sqlDataReader["ExpectedTimeGivenForOrder"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderStatus"]) == false)
                        {
                            item.OrderStatus = Convert.ToString(sqlDataReader["OrderStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderReceiveDateTime"]) == false)
                        {
                            item.OrderReceiveDateTime = Convert.ToString(sqlDataReader["OrderReceiveDateTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrdersDetailID"]) == false)
                        {
                            item.RestaurantTableOrdersDetailID = Convert.ToInt32(sqlDataReader["RestaurantTableOrdersDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Qty"]) == false)
                        {
                            item.Qty = Convert.ToString(sqlDataReader["Qty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsId"]) == false)
                        {
                            item.GeneralUnitsId = Convert.ToInt32(sqlDataReader["GeneralUnitsId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralItemMasterID"]) == false)
                        {
                            item.GeneralItemMasterID = Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UomCode"]) == false)
                        {
                            item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsBOMRelevant"]) == false)
                        {
                            item.IsBOMRelevant = Convert.ToString(sqlDataReader["IsBOMRelevant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToInt32(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryVariationMasterID"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt32(sqlDataReader["InventoryVariationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryLocationMasterID"]) == false)
                        {
                            item.InventoryLocationMasterID = Convert.ToInt32(sqlDataReader["InventoryLocationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuName"]) == false)
                        {
                            item.MenuName = Convert.ToString(sqlDataReader["MenuName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRelatedWithCafe"]) == false)
                        {
                            item.IsRelatedWithCafe = Convert.ToInt16(sqlDataReader["IsRelatedWithCafe"]);
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
    }
}

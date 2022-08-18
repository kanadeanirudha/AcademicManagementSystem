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
    public class RestaurantKOTOrderDetailsDataProvider : DBInteractionBase, IRestaurantKOTOrderDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public RestaurantKOTOrderDetailsDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public RestaurantKOTOrderDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<RestaurantKOTOrderDetails> PostRestaurantKOTOrder(RestaurantKOTOrderDetails item)
        {
            IBaseEntityResponse<RestaurantKOTOrderDetails> response = new BaseEntityResponse<RestaurantKOTOrderDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantKOTOrder_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xKOTOrderXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.KOTOrderXML) ? string.Empty : item.KOTOrderXML));
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
                        throw new Exception("Stored Procedure 'USP_RestaurantKOTOrder_PostOnline' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetRestaurantKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantKOTOrder_GetOnLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsRelatedWith", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.IsRelatedWithCafe));
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantKOTOrderDetails>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantKOTOrderDetails item = new RestaurantKOTOrderDetails();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrdersID"]) == false)
                        {
                            item.RestaurantTableOrdersID = Convert.ToInt32(sqlDataReader["RestaurantTableOrdersID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStatus"]) == false)
                        {
                            item.JobStatus = Convert.ToInt32(sqlDataReader["JobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpectedTimeForDelevery"]) == false)
                        {
                            item.ExpectedTimeForDelevery = Convert.ToString(sqlDataReader["ExpectedTimeForDelevery"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ComplitedDateTime"]) == false)
                        {
                            item.ComplitedDateTime = Convert.ToString(sqlDataReader["ComplitedDateTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantKOTOrderDetailID"]) == false)
                        {
                            item.RestaurantKOTOrderDetailID = Convert.ToInt32(sqlDataReader["RestaurantKOTOrderDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantKOTOrderDetailTransactionDate"]) == false)
                        {
                            item.RestaurantKOTOrderDetailTransactionDate = Convert.ToString(sqlDataReader["RestaurantKOTOrderDetailTransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantKOTOrderDetailID"]) == false)
                        {
                            item.RestaurantKOTOrderDetailID = Convert.ToInt32(sqlDataReader["RestaurantKOTOrderDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Qty"]) == false)
                        {
                            item.Qty = Convert.ToDecimal(sqlDataReader["Qty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remark"]) == false)
                        {
                            item.Remark = Convert.ToString(sqlDataReader["Remark"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantKOTOrderDetailJobStatus"]) == false)
                        {
                            item.RestaurantKOTOrderDetailJobStatus = Convert.ToInt32(sqlDataReader["RestaurantKOTOrderDetailJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CookById"]) == false)
                        {
                            item.CookById = Convert.ToInt32(sqlDataReader["CookById"]);
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
                            item.IsBOMRelevant = Convert.ToInt32(sqlDataReader["IsBOMRelevant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
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
                        if (DBNull.Value.Equals(sqlDataReader["TableNumber"]) == false)
                        {
                            item.TableNumber = Convert.ToString(sqlDataReader["TableNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRelatedWithCafe"]) == false)
                        {
                            item.IsRelatedWithCafe = Convert.ToInt16(sqlDataReader["IsRelatedWithCafe"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ResponseFlag"]) == false)
                        {
                            item.ResponseFlag = Convert.ToInt16(sqlDataReader["ResponseFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsTakeAway"]) == false)
                        {
                            item.IsTakeAway = Convert.ToBoolean(sqlDataReader["IsTakeAway"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaidBillNumber"]) == false)
                        {
                            item.PaidBillNumber = Convert.ToString(sqlDataReader["PaidBillNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_RestaurantKOTOrder_GetOnLine' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetCompleteAndInCompleteKOTOrder";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStatusFlag", SqlDbType.Bit, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StatusFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantKOTOrderDetails>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantKOTOrderDetails item = new RestaurantKOTOrderDetails();
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantBillOrderdetailsID"]) == false)
                        {
                            item.RestaurantBillOrderdetailsID = Convert.ToInt32(sqlDataReader["RestaurantBillOrderdetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleMasterID"]) == false)
                        {
                            item.SaleMasterID = Convert.ToInt32(sqlDataReader["SaleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocalInvoiceNumber"]) == false)
                        {
                            item.LocalInvoiceNumber = Convert.ToString(sqlDataReader["LocalInvoiceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrderID"]) == false)
                        {
                            item.RestaurantTableOrdersID = Convert.ToInt32(sqlDataReader["RestaurantTableOrderID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToInt32(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UOMCode"]) == false)
                        {
                            item.UomCode = Convert.ToString(sqlDataReader["UOMCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VariationMasterId"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt32(sqlDataReader["VariationMasterId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalePromotionActivityDetailsID"]) == false)
                        {
                            item.SalePromotionActivityDetailsID = Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                        {
                            item.GeneralUnitsId = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRestaurant"]) == false)
                        {
                            item.IsRestaurant = Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRelatedWithCafe"]) == false)
                        {
                            item.IsRelatedWithCafe = Convert.ToInt16(sqlDataReader["IsRelatedWithCafe"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                       
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCompleteAndInCompleteKOTOrder' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> GetInCompleteKOTOrder(RestaurantKOTOrderDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantKOTOrderDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetCompleteAndInCompleteKOTOrder";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStatusFlag", SqlDbType.Bit, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StatusFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantKOTOrderDetails>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantKOTOrderDetails item = new RestaurantKOTOrderDetails();

                        if (DBNull.Value.Equals(sqlDataReader["RestaurantBillOrderdetailsID"]) == false)
                        {
                            item.RestaurantBillOrderdetailsID = Convert.ToInt32(sqlDataReader["RestaurantBillOrderdetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleMasterID"]) == false)
                        {
                            item.SaleMasterID = Convert.ToInt32(sqlDataReader["SaleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocalInvoiceNumber"]) == false)
                        {
                            item.LocalInvoiceNumber = Convert.ToString(sqlDataReader["LocalInvoiceNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RestaurantTableOrderID"]) == false)
                        {
                            item.RestaurantTableOrdersID = Convert.ToInt32(sqlDataReader["RestaurantTableOrderID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToString(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToInt32(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UOMCode"]) == false)
                        {
                            item.UomCode = Convert.ToString(sqlDataReader["UOMCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VariationMasterId"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt32(sqlDataReader["VariationMasterId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalePromotionActivityDetailsID"]) == false)
                        {
                            item.SalePromotionActivityDetailsID = Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                        {
                            item.GeneralUnitsId = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRestaurant"]) == false)
                        {
                            item.IsRestaurant = Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRelatedWithCafe"]) == false)
                        {
                            item.IsRelatedWithCafe = Convert.ToInt16(sqlDataReader["IsRelatedWithCafe"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCompleteAndInCompleteKOTOrder' reported the ErrorCode: " + _errorCode);
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

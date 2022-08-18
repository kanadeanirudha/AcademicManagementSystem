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
    public class APIInventoryDataProvider : DBInteractionBase, IAPIInventoryDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public APIInventoryDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public APIInventoryDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<APIInventory> InventoryCounterLogin(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> response = new BaseEntityResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryCounterLogin_FromPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPOSMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.POSMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTokenCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeviceToken));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTimeZone", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.TimeZone) ? string.Empty : item.TimeZone));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterMstID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CounterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@_siGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@_siAccBalancesheetID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.AccBalancesheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@_iInventoryCounterLogID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryCounterLogID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    // while (sqlDataReader.Read())
                    // {
                    APIInventory _item = new APIInventory();

                    _item.GeneralUnitsID = (int)cmdToExecute.Parameters["@_siGeneralUnitsID"].Value;
                    _item.AccBalancesheetID = (int)cmdToExecute.Parameters["@_siAccBalancesheetID"].Value;
                    _item.InventoryCounterLogID = (int)cmdToExecute.Parameters["@_iInventoryCounterLogID"].Value;
                    _item.Status = (int)cmdToExecute.Parameters["@iStatus"].Value;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_UserMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<APIInventory> PostOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> response = new BaseEntityResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesMasterAndTransaction_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleMasterXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleTransactionXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleVoucherXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleVoucherXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    // while (sqlDataReader.Read())
                    // {
                    APIInventory _item = new APIInventory();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    _item.Status = (int)_errorCode;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

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
        public IBaseEntityResponse<APIInventory> SingleBillPostOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> response = new BaseEntityResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesMasterAndTransactionSigle_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleMasterXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleTransactionXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleVoucherXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleVoucherXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ErrorMessage) ? string.Empty : item.ErrorMessage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumbers", SqlDbType.NVarChar, 1000, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.BillNumbers) ? string.Empty : item.BillNumbers));

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

                    APIInventory _item = new APIInventory();

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode == 300)
                    {
                        _item.BillNumbers = (string)cmdToExecute.Parameters["@nsBillNumbers"].Value;
                    }
                   
                    _item.ErrorCode = (int)_errorCode;
                    _item.Status = (int)_errorCode;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200 && _errorCode != 300 && _errorCode != 301 && _errorCode != 121)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransactionSigle_PostOnline' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<APIInventory> GetLocalInvoiceNo(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> response = new BaseEntityResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRunningNumberForLocalInvoice_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsKeyField", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.KeyField));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCounterMasterId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CounterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
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
                    APIInventory _item = new APIInventory();
                    while (sqlDataReader.Read())
                    {
                        if (DBNull.Value.Equals(sqlDataReader["DisplayFormat"]) == false)
                        {
                            _item.DisplayFormat = Convert.ToString(sqlDataReader["DisplayFormat"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentNumber"]) == false)
                        {
                            _item.CurrentNumber = Convert.ToString(sqlDataReader["CurrentNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            _item.Description = Convert.ToString(sqlDataReader["Description"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StartNumber"]) == false)
                        {
                            _item.StartNumber = Convert.ToInt16(sqlDataReader["StartNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Prefix"]) == false)
                        {
                            _item.Prefix = Convert.ToString(sqlDataReader["Prefix"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Seperator"]) == false)
                        {
                            _item.Seperator = Convert.ToString(sqlDataReader["Seperator"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            _item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        _item.ErrorMessage = "Something Went Wrong";
                        _item.Status = 100;
                    }
                    else
                    {
                        _item.ErrorMessage = "Bill Number Details are retrieved successfully.";
                        _item.Status = 200;
                    }
                    response.Entity = _item;

                    if (_errorCode != (int)ErrorEnum.AllOk)
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

        public IBaseEntityCollectionResponse<APIInventory> InventoryGetOnline(APIInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<APIInventory> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_GetOnLineForPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));    
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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

                    baseEntityCollection.CollectionResponse = new List<APIInventory>();
                    while (sqlDataReader.Read())
                    {
                        APIInventory item = new APIInventory();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUoMcode"]) == false)
                        {
                            item.BaseUoMcode = Convert.ToString(sqlDataReader["BaseUoMcode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseBarCode"]) == false)
                        {
                            item.BaseBarCode = Convert.ToString(sqlDataReader["BaseBarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCategoryCode"]) == false)
                        {
                            item.ItemCategoryCode = Convert.ToString(sqlDataReader["ItemCategoryCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterId"]) == false)
                        {
                            item.GenTaxGroupMasterId = Convert.ToInt32(sqlDataReader["GenTaxGroupMasterId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralItemCodeID"]) == false)
                        {
                            item.GeneralItemCodeID = Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UomCode"]) == false)
                        {
                            item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConversionFactor"]) == false)
                        {
                            item.ConversionFactor = Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDisplayFromDate"]) == false)
                        {
                            item.ItemDisplayFromDate = Convert.ToString(sqlDataReader["ItemDisplayFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["itemDisplayUpto"]) == false)
                        {
                            item.itemDisplayUpto = Convert.ToString(sqlDataReader["itemDisplayUpto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxGroupID"]) == false)
                        {
                            item.TaxGroupID = Convert.ToInt32(sqlDataReader["TaxGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxInPercentage"]) == false)
                        {
                            item.TaxInPercentage = Convert.ToDecimal(sqlDataReader["TaxInPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToString(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToString(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRestaurant"]) == false)
                        {
                            item.IsRestaurant = Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                        {
                            item.GeneralUnitsID = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryLocationMasterID"]) == false)
                        {
                            item.StorageLocationID = Convert.ToInt32(sqlDataReader["InventoryLocationMasterID"]);
                            item.InventoryLocationMasterID = Convert.ToInt32(sqlDataReader["InventoryLocationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitType"]) == false)
                        {
                            item.UnitType = Convert.ToString(sqlDataReader["UnitType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitTypeID"]) == false)
                        {
                            item.GeneralUnitTypeID = Convert.ToInt32(sqlDataReader["GeneralUnitTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ArabicTransalation"]) == false)
                        {
                            item.ArabicTransalation = Convert.ToString(sqlDataReader["ArabicTransalation"]);
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

        public IBaseEntityResponse<APIInventory> PostSaleReturnOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> response = new BaseEntityResponse<APIInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventorySalesReturnMasterAndTransaction_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleReturnMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleReturnMasterXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleReturnTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleReturnTransactionXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xInvSaleReturnVoucherXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InvSaleReturnVoucherXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    // while (sqlDataReader.Read())
                    // {
                    APIInventory _item = new APIInventory();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    _item.Status = (int)_errorCode;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = _item;
                    // }

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
    }
}

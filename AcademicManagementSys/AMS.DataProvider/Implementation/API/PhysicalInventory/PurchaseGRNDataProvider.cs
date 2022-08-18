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
    public class PurchaseGRNDataProvider : DBInteractionBase, IPurchaseGRNDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PurchaseGRNDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PurchaseGRNDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<PurchaseGRN> PostPurchaseGRN(PurchaseGRN item)
        {
            IBaseEntityResponse<PurchaseGRN> response = new BaseEntityResponse<PurchaseGRN>();
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
                    cmdToExecute.CommandText = "dbo.USP_APIPurchaseGRNMaster_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dtGRNTransDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.GRNTransDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPurchaseGRNDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,  item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLocked", SqlDbType.Bit, 25,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsLocked));
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

                    PurchaseGRN _item = new PurchaseGRN();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    _item.ErrorCode = (int)_errorCode;
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
                        throw new Exception("Stored Procedure 'USP_APIPurchaseGRNMaster_PostOnline' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNVendorList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_VendorMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["GenSupplierMasterID"]) == false)
                        {
                            item.VendorID = Convert.ToInt16(sqlDataReader["GenSupplierMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                        {
                            item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                        {
                            item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_GetPhysicalInventoryStock' reported the ErrorCode: " + _errorCode);
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
        //-----------------------------------------------Select All PO List----------------------------
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNPOList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_APIPurchaseGRNPOList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPOStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.POStatus));
                    if (string.IsNullOrEmpty(searchRequest.VendorName))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorName));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseGRNMasterID"]) == false)
                        {
                            item.PurchaseGRNMasterID = Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderMasterID"]) == false)
                        {
                            item.PurchaseOrderMasterID = Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNNumber"]) == false)
                        {
                            item.GRNNumber = Convert.ToString(sqlDataReader["GRNNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivedQuantity"]) == false)
                        {
                            item.ReceivedQuantity = Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderQuantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["PurchaseOrderQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LockedGRNQuantity"]) == false)
                        {
                            item.LockedGRNQuantity = Convert.ToDecimal(sqlDataReader["LockedGRNQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNIsLockedStatusFlag"]) == false)
                        {
                            item.GRNIsLockedStatusFlag = Convert.ToBoolean(sqlDataReader["GRNIsLockedStatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderNumber"]) == false)
                        {
                            item.PurchaseOrderNumber = Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderDate"]) == false)
                        {
                            item.PurchaseOrderDate = Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderType"]) == false)
                        {
                            item.PurchaseOrderType = Convert.ToInt32(sqlDataReader["PurchaseOrderType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                        {
                            item.VendorID = Convert.ToInt32(sqlDataReader["VendorID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                        {
                            item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                        {
                            item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNTransDate"]) == false)
                        {
                            item.GRNTransDate = Convert.ToString(sqlDataReader["GRNTransDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivedQuantityPerItem"]) == false)
                        {
                            item.ReceivedQuantityPerItem = Convert.ToDecimal(sqlDataReader["ReceivedQuantityPerItem"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivingLocationID"]) == false)
                        {
                            item.ReceivingLocationID = Convert.ToInt32(sqlDataReader["ReceivingLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.StorageLocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationName"]) == false)
                        {
                            item.StorageLocationName = Convert.ToString(sqlDataReader["LocationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderUomCode"]) == false)
                        {
                            item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remark"]) == false)
                        {
                            item.Remark = Convert.ToString(sqlDataReader["Remark"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivingLocationName"]) == false)
                        {
                            item.ReceivingLocationName = Convert.ToString(sqlDataReader["ReceivingLocationName"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetPhysicalInventoryStock' reported the ErrorCode: " + _errorCode);
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
        //----------------------------------------------------------NEW PO LIST---------------------

        public IBaseEntityCollectionResponse<PurchaseGRN> GetPOList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_APIPurchaseGRNPO_List";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiPOStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.POStatus));
                    if (string.IsNullOrEmpty(searchRequest.VendorName))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsVender", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.VendorName));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.PurchaseOrderMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderNumber"]) == false)
                        {
                            item.PurchaseOrderNumber = Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderDate"]) == false)
                        {
                            item.PurchaseOrderDate = Convert.ToString(sqlDataReader["PurchaseOrderDate"]);
                        }
                       
                        if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                        {
                            item.VendorID = Convert.ToInt32(sqlDataReader["VendorID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Vender"]) == false)
                        {
                            item.VendorName = Convert.ToString(sqlDataReader["Vender"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorNumber"]) == false)
                        {
                            item.VendorNumber = Convert.ToInt32(sqlDataReader["VendorNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderType"]) == false)
                        {
                            item.PurchaseOrderType = Convert.ToInt32(sqlDataReader["PurchaseOrderType"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                        baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetPhysicalInventoryStock' reported the ErrorCode: " + _errorCode);
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
//------------------------------------------------------FOR GRN LIST------------------------------------------------
        public IBaseEntityCollectionResponse<PurchaseGRN> GetGRNList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_APIPurchaseGRN_List";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderMasterID"]) == false)
                        {
                            item.PurchaseOrderMasterID = Convert.ToInt32(sqlDataReader["PurchaseOrderMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseGrnMasterID"]) == false)
                        {
                            item.PurchaseGRNMasterID = Convert.ToInt32(sqlDataReader["PurchaseGrnMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNNumber"]) == false)
                        {
                            item.GRNNumber = Convert.ToString(sqlDataReader["GRNNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_APIPurchaseGRN_List' reported the ErrorCode: " + _errorCode);
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
//-----------------------------------------------------------FOR GRN VIEW--------------------------
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNView(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_APIPurchaseGRNView_List";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseGRNMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseGRNMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPurchaseOrderMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseGRNMasterID"]) == false)
                        {
                            item.PurchaseGRNMasterID = Convert.ToInt32(sqlDataReader["PurchaseGRNMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNNumber"]) == false)
                        {
                            item.GRNNumber = Convert.ToString(sqlDataReader["GRNNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GRNTransDate"]) == false)
                        {
                            item.GRNTransDate = Convert.ToString(sqlDataReader["GRNTransDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocked"]) == false)
                        {
                            item.IsLocked = Convert.ToBoolean(sqlDataReader["IsLocked"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseGRNDetailsID"]) == false)
                        {
                            item.PurchaseGRNDetailsID = Convert.ToInt32(sqlDataReader["PurchaseGRNDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivedQuantity"]) == false)
                        {
                            item.ReceivedQuantity = Convert.ToDecimal(sqlDataReader["ReceivedQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderUomCode"]) == false)
                        {
                            item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOMQuantity"]) == false)
                        {
                            item.BaseUOMQuantity = Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOMCode"]) == false)
                        {
                            item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Remark"]) == false)
                        {
                            item.Remark = Convert.ToString(sqlDataReader["Remark"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReceivingLocationName"]) == false)
                        {
                            item.ReceivingLocationName = Convert.ToString(sqlDataReader["ReceivingLocationName"]);
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
                        throw new Exception("Stored Procedure 'USP_APIPurchaseGRNView_List' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNBatchList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemBatchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemNumber", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 25, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["BatchID"]) == false)
                        {
                            item.BatchID = Convert.ToInt32(sqlDataReader["BatchID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseBillID"]) == false)
                        {
                            item.PurchaseBillID = Convert.ToString(sqlDataReader["PurchaseBillID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BatchNumber"]) == false)
                        {
                            item.BatchNumber = Convert.ToString(sqlDataReader["BatchNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExpiryDate"]) == false)
                        {
                            item.ExpiryDate = Convert.ToString(sqlDataReader["ExpiryDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BatchQuantity"]) == false)
                        {
                            item.BatchQuantity = Convert.ToDecimal(sqlDataReader["BatchQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SoldQuantity"]) == false)
                        {
                            item.SoldQuantity = Convert.ToDecimal(sqlDataReader["SoldQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsBatchSold"]) == false)
                        {
                            item.IsBatchSold = Convert.ToBoolean(sqlDataReader["IsBatchSold"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleDate"]) == false)
                        {
                            item.SaleDate = Convert.ToString(sqlDataReader["SaleDate"]);
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
                        throw new Exception("Stored Procedure 'USP_GetPhysicalInventoryStock' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseOrderItemList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PurchaseGRN>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_APIGetPOListForGRNWebService";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PurchaseOrderMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    baseEntityCollection.CollectionResponse = new List<PurchaseGRN>();
                    //decimal ammount = 0;
                    while (sqlDataReader.Read())
                    {
                        PurchaseGRN item = new PurchaseGRN();
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderDetailsID"]) == false)
                        {
                            item.PurchaseOrderDetailID = Convert.ToInt32(sqlDataReader["PurchaseOrderDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BarCode"]) == false)
                        {
                            item.BarCode = Convert.ToString(sqlDataReader["BarCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOMCode"]) == false)
                        {
                            item.BaseUOMCode = Convert.ToString(sqlDataReader["BaseUOMCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderUomCode"]) == false)
                        {
                            item.OrderUomCode = Convert.ToString(sqlDataReader["OrderUomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOMQuantity"]) == false)
                        {
                            item.BaseUOMQuantity = Convert.ToDecimal(sqlDataReader["BaseUOMQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralItemCodeID"]) == false)
                        {
                            item.GeneralItemCodeID = Convert.ToInt32(sqlDataReader["GeneralItemCodeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StorageLocationID"]) == false)
                        {
                            item.StorageLocationID = Convert.ToInt32(sqlDataReader["StorageLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueFromLocationID"]) == false)
                        {
                            item.ReceivingLocationID = Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StorageLocationName"]) == false)
                        {
                            item.StorageLocationName = Convert.ToString(sqlDataReader["StorageLocationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueFromLocationName"]) == false)
                        {
                            item.ReceivingLocationName = Convert.ToString(sqlDataReader["IssueFromLocationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SerialAndBatchManagedBy"]) == false)
                        {
                            item.SerialAndBatchManagedBy = Convert.ToByte(sqlDataReader["SerialAndBatchManagedBy"]);
                        }
                        var qty = Math.Round((item.Quantity), 2);
                        var Recived = Math.Round((item.ReceivedQuantity), 2);
                        var RemainingReceivedqty = Math.Round((qty - Recived), 2);
                        item.RemainingQuantity = 0;

                        if (DBNull.Value.Equals(sqlDataReader["TotalTaxAmount"]) == false)
                        {
                            item.TotalTaxAmount = Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Discount"]) == false)
                        {
                            item.Discount = Convert.ToDecimal(sqlDataReader["Discount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Freight"]) == false)
                        {
                            item.Freight = Convert.ToDecimal(sqlDataReader["Freight"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShippingHandling"]) == false)
                        {
                            item.ShippingHandling = Convert.ToDecimal(sqlDataReader["ShippingHandling"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseOrderNumber"]) == false)
                        {
                            item.PurchaseOrderNumber = Convert.ToString(sqlDataReader["PurchaseOrderNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShelfExpiryLife"]) == false)
                        {
                            item.ShelfLife = Convert.ToString(sqlDataReader["ShelfExpiryLife"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RemainingShelfLife"]) == false)
                        {
                            item.RemainingShelfLife = Convert.ToString(sqlDataReader["RemainingShelfLife"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VendorID"]) == false)
                        {
                            item.VendorID = Convert.ToInt32(sqlDataReader["VendorID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ReturnGoods"]) == false)
                        {
                            item.ReturnGoods = Convert.ToBoolean(sqlDataReader["ReturnGoods"]);
                        }
                        var quantity = Math.Round(item.Quantity, 3);
                        var rate = Math.Round(item.Rate, 2);
                        //var amount = quantity * rate;
                        //ammount = ammount + amount;
                        //item.GrossAmount = Math.Round(ammount, 2);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetPOListForGRNWebService' reported the ErrorCode: " + _errorCode);
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

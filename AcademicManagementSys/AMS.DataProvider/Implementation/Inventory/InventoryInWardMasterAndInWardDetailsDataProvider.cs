using AMS.Base.DTO;
using AMS.DTO;
using System.Configuration;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider
{
    public class InventoryInWardMasterAndInWardDetailsDataProvider : DBInteractionBase, IInventoryInWardMasterAndInWardDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;
        private string XmlDataString = string.Empty;
        private string XmlDataString1 = string.Empty;
        private string XmlDataString2 = string.Empty;
        private string XmlDataString3 = string.Empty;
        #endregion

        #region Constructor
        public InventoryInWardMasterAndInWardDetailsDataProvider()
        {
        }

        public InventoryInWardMasterAndInWardDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException;
        }

        #endregion

        // InventoryInWardMaster Method
        #region InventoryInWardMaster

        /// Select all record from InventoryInWardMaster        
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();

                        //Property of EntranceExamAvailableCentres
                        item.InventoryInWardMasterID = Convert.ToInt32(sqlDataReader["InventoryInWardMasterID"]);
                        item.IssueFromLocationID = Convert.ToInt32(sqlDataReader["IssueFromLocationID"]);
                        item.IssueToLocationID = Convert.ToInt32(sqlDataReader["IssueToLocationID"]);
                        item.IssueFromLocationName = Convert.ToString(sqlDataReader["IssueFromLocationName"]);
                        item.IssueToLocationName = Convert.ToString(sqlDataReader["IssueToLocationName"]);
                        item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.InwardQuantity = Convert.ToDecimal(sqlDataReader["InwardQuantity"]);
                        item.DamagedQuantity = Convert.ToDecimal(sqlDataReader["DamagedQuantity"]);
                        item.Remark = Convert.ToString(sqlDataReader["Reason"]);

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
                        throw new Exception("Stored Procedure 'USP_InventoryInWardMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from InventoryInWardMaster table by ID        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterByID(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
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
                        InventoryInWardMasterAndInWardDetails _item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardMaster
                        _item.InventoryInWardMasterID = Convert.ToInt32(sqlDataReader["InventoryInWardMasterID"]);
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //_item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //_item.Address = sqlDataReader["Address"].ToString();
                        //_item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //_item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryInWardMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlCommand cmdToExecuteOnline = new SqlCommand();
            SqlTransaction transactionOffline = null;
            SqlTransaction transactionOnline = null;
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
                    if (item.FieldValue == 0) // when transaction is initialized from offline server
                    {
                        _mainConnection.ConnectionString = item.ConnectionString;
                        _onlineDbConnection.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Onlinedb.ConnectionString"]);
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecuteOnline.Connection = _onlineDbConnection;

                        cmdToExecuteOnline.CommandText = "dbo.USP_InventoryInward_InsertXML";
                        cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;

                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.Now)));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iInwardLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IssueToLocationID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInwardDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "INWARD"));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@IsOnlineOfflineFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.FieldValue)));
                        // cmdToExecuteOnline.Parameters.Add(new SqlParameter("@dtApprovedDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                        if (_mainConnectionIsCreatedLocal)
                        {
                            // Open connection. 
                            _mainConnection.Open();
                            _onlineDbConnection.Open();
                        }
                        else
                        {
                            if (_mainConnectionProvider.IsTransactionPending)
                            {
                                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                            }
                        }

                        transactionOnline = _onlineDbConnection.BeginTransaction();
                        cmdToExecuteOnline.Transaction = transactionOnline;
                        // Execute query.
                        using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                        {
                            XmlDataString = "<rows>";
                            while (sqlDataReader.Read())
                            {
                                XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                                "<ItemId>" + sqlDataReader["ItemId"] + "</ItemId>" +
                                                                "<InwardQuantity>" + sqlDataReader["InwardQuantity"] + "</InwardQuantity>" +
                                                                "<DamageQuantity>" + sqlDataReader["DamageQuantity"] + "</DamageQuantity>" +
                                                                 "<StolenStockQuantity>" + sqlDataReader["StolenStockQuantity"] + "</StolenStockQuantity>" +
                                                                 "<Remark>" + sqlDataReader["Remark"] + "</Remark>" +
                                                                 "<InwardLocationID>" + sqlDataReader["InwardLocationID"] + "</InwardLocationID></row>";

                            }
                            XmlDataString += "</rows>";
                        }

                        //------------------------------------------------Inserting / updating unit data in offline server-------------------------------------------------
                        cmdToExecute.Parameters.Clear();
                        cmdToExecute.CommandText = "dbo.USP_InventoryInward_InsertOfflineXML";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        if (XmlDataString.Length > 13)
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
                            cmdToExecute.Parameters.Add(new SqlParameter("@xInwardDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                        }
                        else
                        {
                            cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
                            cmdToExecute.Parameters.Add(new SqlParameter("@xInwardDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        }
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                        transactionOffline = _mainConnection.BeginTransaction();
                        cmdToExecute.Transaction = transactionOffline;
                        // Execute query.
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        if (_rowsAffected > 0)
                        {
                            item.InventoryInWardMasterID = (Int32)cmdToExecute.Parameters["@ID"].Value;
                        }

                        if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                        {
                            _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        }
                        if (_errorCode != (int)ErrorEnum.AllOk)
                        {
                            // Throw error.
                            throw new Exception("Stored Procedure 'USP_InventoryInWardMaster_SelectAll' reported the ErrorCode: " + _errorCode);
                        }

                        //-------------------------------------------------commiting transaction------------------------------------------------------------------------
                        transactionOffline.Commit();
                        transactionOnline.Commit();

                    }
                    else  // when transaction is initialized from online server
                    {
                        //if feild value=1
                        _mainConnection.ConnectionString = item.ConnectionString;
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.CommandText = "dbo.USP_InventoryInward_InsertXML";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;

                        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.Now)));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iInwardLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IssueToLocationID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAccountSessionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                        cmdToExecute.Parameters.Add(new SqlParameter("@xInwardDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, "INWARD"));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@IsOnlineOfflineFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.FieldValue)));
                        // cmdToExecuteOnline.Parameters.Add(new SqlParameter("@dtApprovedDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 1));

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

                        transactionOnline = _mainConnection.BeginTransaction();
                        cmdToExecute.Transaction = transactionOnline;
                        // Execute query.
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        if (_rowsAffected > 0)
                        {
                            item.InventoryInWardMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                        }
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        item.ErrorCode = (Int32)_errorCode;
                        response.Entity = item;

                        if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                        {
                            // Throw error.
                            throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardMaster_INSERT' reported the ErrorCode: " + _errorCode);
                        }

                        //-------------------------------------------------commiting transaction------------------------------------------------------------------------
                        transactionOnline.Commit();
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

                _errorCode = 30;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //   _logException.Error(ex.Message);
                if (transactionOffline != null)
                {
                    transactionOffline.Rollback();
                }
                if (transactionOnline != null)
                {
                    transactionOnline.Rollback();
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 30;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //   _logException.Error(ex.Message);
                if (transactionOffline != null)
                {
                    transactionOffline.Rollback();
                }
                if (transactionOnline != null)
                {
                    transactionOnline.Rollback();
                }
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                    _onlineDbConnection.Close();
                }
                cmdToExecuteOnline.Dispose();
                cmdToExecute.Dispose();
            }
            return response;
        }

        /// Update a specific record of InventoryInWardMaster        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));

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

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of InventoryInWardMaster        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InventoryInWardMasterID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.InventoryInWardMasterID = (Int32)cmdToExecute.Parameters["@iInventoryInWardMasterID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInWardRequestForApproval(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInwardMaster_GetRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryInWardMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InwardQuantity"]) == false)
                        {
                            item.InwardQuantity = Convert.ToDecimal(sqlDataReader["InwardQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DamageQuantity"]) == false)
                        {
                            item.DamagedQuantity = Convert.ToDecimal(sqlDataReader["DamageQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StolenStockQuantity"]) == false)
                        {
                            item.StolenQuantity = Convert.ToDecimal(sqlDataReader["StolenStockQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Qunatity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Qunatity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueToLocation"]) == false)
                        {
                            item.IssueToLocationName = Convert.ToString(sqlDataReader["IssueToLocation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueFromLocation"]) == false)
                        {
                            item.IssueFromLocationName = Convert.ToString(sqlDataReader["IssueFromLocation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IssueToLocationId"]) == false)
                        {
                            item.IssueToLocationID = Convert.ToInt32(sqlDataReader["IssueToLocationId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InWordDate"]) == false)
                        {
                            item.InWordDate = Convert.ToDateTime(sqlDataReader["InWordDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Unit"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["Unit"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InWordNumber"]) == false)
                        {
                            item.InWordNumber = Convert.ToString(sqlDataReader["InWordNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InwordType"]) == false)
                        {
                            item.InwordType = Convert.ToString(sqlDataReader["InwordType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
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

        //Laayer For InvSystemSettingMaster list

        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInvSystemSetting(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvSystemSettingMaster";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();

                        if (DBNull.Value.Equals(sqlDataReader["FieldName"]) == false)
                        {
                            item.FieldName = Convert.ToString(sqlDataReader["FieldName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Fieldvalue"]) == false)
                        {
                            item.FieldValue = Convert.ToInt32(sqlDataReader["Fieldvalue"]);
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

        // Select all record from InventoryInWardMaster table with search list.
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();

                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardMaster
                        if (DBNull.Value.Equals(sqlDataReader["InventoryInWardMasterID"]) == false)
                        {
                            item.InventoryInWardMasterID = Convert.ToInt32(sqlDataReader["InventoryInWardMasterID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        //{
                        //    item.CentreName = sqlDataReader["CentreName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GenLocationID"]) == false)
                        //{
                        //    item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        //{
                        //    item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        //{
                        //    item.Address = sqlDataReader["Address"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        //{
                        //    item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveUpto"]) == false)
                        //{
                        //    item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryInWardMaster_SearchList' reported the ErrorCode: " + _errorCode);
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




        // InventoryInWardDetails Method
        #region InventoryInWardDetails

        /// Select all record from InventoryInWardDetails        
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardDetails
                        item.InventoryInWardDetailsID = Convert.ToInt32(sqlDataReader["InventoryInWardDetailsID"]);
                        //item.CentreName = sqlDataReader["CentreName"].ToString();
                        //item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //item.Address = sqlDataReader["Address"].ToString();
                        //item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

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
                        throw new Exception("Stored Procedure 'USP_InventoryInWardDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from InventoryInWardDetails table by ID        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsByID(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.InventoryInWardDetailsID));
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
                        InventoryInWardMasterAndInWardDetails _item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardMaster
                        _item.InventoryInWardDetailsID = Convert.ToInt32(sqlDataReader["InventoryInWardDetailsID"]);
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //_item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //_item.Address = sqlDataReader["Address"].ToString();
                        //_item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //_item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryInWardDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of InventoryInWardDetails
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardDetailsID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardDetailsID));


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

                    if (_rowsAffected > 0)
                    {
                        item.InventoryInWardDetailsID = (Int32)cmdToExecute.Parameters["@InventoryInWardDetailsID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardDetails_INSERT' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of InventoryInWardDetails        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.InventoryInWardDetailsID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));

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

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardDetails_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of InventoryInWardDetails        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryInWardDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InventoryInWardDetailsID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.InventoryInWardDetailsID = (Int32)cmdToExecute.Parameters["@iInventoryInWardDetailsID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryInWardDetails_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from InventoryInWardDetails table with search list.
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryInWardDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<InventoryInWardMasterAndInWardDetails>();

                    while (sqlDataReader.Read())
                    {
                        InventoryInWardMasterAndInWardDetails item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardMaster
                        if (DBNull.Value.Equals(sqlDataReader["InventoryInWardDetailsID"]) == false)
                        {
                            item.InventoryInWardDetailsID = Convert.ToInt32(sqlDataReader["InventoryInWardDetailsID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        //{
                        //    item.CentreName = sqlDataReader["CentreName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["GenLocationID"]) == false)
                        //{
                        //    item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        //{
                        //    item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        //{
                        //    item.Address = sqlDataReader["Address"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        //{
                        //    item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ActiveUpto"]) == false)
                        //{
                        //    item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryInWardDetails_SearchList' reported the ErrorCode: " + _errorCode);
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

        //Laayer For Inv Sync History Count
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInvSyncHistoryCount(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> response = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvInward_GetSyncCount";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                        InventoryInWardMasterAndInWardDetails _item = new InventoryInWardMasterAndInWardDetails();

                        //Property of InventoryInWardMaster
                        _item.TotalrowCount = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        //_item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        //_item.Address = sqlDataReader["Address"].ToString();
                        //_item.ActiveFrom = Convert.ToDateTime(sqlDataReader["ActiveFrom"]);
                        //_item.ActiveUpto = Convert.ToDateTime(sqlDataReader["ActiveUpto"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryInWardDetails_SelectOne' reported the ErrorCode: " + _errorCode);
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
        #endregion
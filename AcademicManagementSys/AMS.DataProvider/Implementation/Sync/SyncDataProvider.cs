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
    public class SyncDataProvider : DBInteractionBase, ISyncDataProvider
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

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SyncDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SyncDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        /// <summary>
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<Sync> GetSyncBySearch(SyncSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Sync> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_Sync_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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

                    baseEntityCollection.CollectionResponse = new List<Sync>();
                    while (sqlDataReader.Read())
                    {
                        Sync item = new Sync();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        // item.CountryName = sqlDataReader["CountryName"].ToString();
                        // item.ContryCode = sqlDataReader["ContryCode"].ToString();
                        // item.SeqNo = Convert.ToInt32(sqlDataReader["SeqNo"]);
                        // item.DefaultFlag = Convert.ToBoolean(sqlDataReader["DefaultFlag"].ToString());
                        // if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        // {
                        //     item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);    
                        // }

                        //item.IsUserDefined = Convert.ToBoolean(sqlDataReader["IsUserDefined"]);    
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
                        throw new Exception("Stored Procedure 'USP_Sync_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from General Region Master table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<Sync> GetSyncGetBySearchList(SyncSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Sync> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_Sync_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<Sync>();
                    while (sqlDataReader.Read())
                    {
                        Sync item = new Sync();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.CountryName = sqlDataReader["CountryName"].ToString();
                        //item.ContryCode = sqlDataReader["ContryCode"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_Sync_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> GetLastSyncDate(Sync item)
        {
            IBaseEntityResponse<Sync> response = new BaseEntityResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvSynHistory_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSyncType", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
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
                        Sync _item = new Sync();
                        _item.LastSyncDate = Convert.ToString(sqlDataReader["SyncDateTime"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_Sync_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from General Region Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> CheckLoggedInUserCount(Sync item)
        {
            IBaseEntityResponse<Sync> response = new BaseEntityResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_Sync_CheckLoggedInUserCount";
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
                        Sync _item = new Sync();
                        _item.IsValidUserCount = Convert.ToBoolean(sqlDataReader["StatusFLag"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_Sync_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> InventorySyncProcess(Sync item)
        {
            IBaseEntityResponse<Sync> response = new BaseEntityResponse<Sync>();
            IBaseEntityCollectionResponse<Sync> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<Sync>();
            SqlCommand cmdToExecuteOffline = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    _onlineDbConnection.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Onlinedb.ConnectionString"]);
                    cmdToExecuteOffline.Connection = _mainConnection;
                    cmdToExecuteOnline.Connection = _onlineDbConnection;

                    #region Sync Item Category
                    //------------------------------------------------------------------------Getting item category data from online server-------------------------------
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryItemCategoryMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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
                            cmdToExecuteOnline.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }

                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<CategoryDescription>" + sqlDataReader["CategoryDescription"] + "</CategoryDescription>" +
                                                            "<CategoryCode>" + sqlDataReader["CategoryCode"] + "</CategoryCode>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting / updating item category data in offline server-------------------------------------------------

                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryItemCategoryMaster_PostOffline";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemCategoryMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemCategoryMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    transactionOffline = _mainConnection.BeginTransaction();
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemCategoryMaster_PostOffline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Item Units
                    //------------------------------------------------Getting unit data from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_GeneralUnitMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<UnitDescription>" + sqlDataReader["UnitDescription"] + "</UnitDescription>" +
                                                            "<ShortCode>" + sqlDataReader["ShortCode"] + "</ShortCode>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting / updating unit data in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_GeneralUnitMaster_PostOffline";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xGeneralUnitMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xGeneralUnitMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralUnitMaster_PostOffline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Items & Centrewise rates
                    //------------------------------------------------Getting Items from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryItemMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<CategoryCode>" + sqlDataReader["CategoryCode"] + "</CategoryCode>" +
                                                            "<ItemName>" + sqlDataReader["ItemName"] + "</ItemName>" +
                                                            "<ItemCode>" + sqlDataReader["ItemCode"] + "</ItemCode>" +
                                                            "<LastPurchaseRate>" + sqlDataReader["LastPurchaseRate"] + "</LastPurchaseRate>" +
                                                            "<WholeSaleRate>" + sqlDataReader["WholeSaleRate"] + "</WholeSaleRate>" +
                                                            "<RetailRate>" + sqlDataReader["RetailRate"] + "</RetailRate>" +
                                                            "<SpecialRate>" + sqlDataReader["SpecialRate"] + "</SpecialRate>" +
                                                            "<MaximumRetialPrice>" + sqlDataReader["MaximumRetialPrice"] + "</MaximumRetialPrice>" +
                                                            "<CurrencyCode>" + sqlDataReader["CurrencyCode"] + "</CurrencyCode>" +
                                                            "<ItemImage>" + sqlDataReader["ItemImage"] + "</ItemImage>" +
                                                            "<GenTaxGroupMasterID>" + sqlDataReader["GenTaxGroupMasterID"] + "</GenTaxGroupMasterID>" +
                                                            "<UnitID>" + sqlDataReader["UnitID"] + "</UnitID>" +
                                                            "<IsSerialNumber>" + sqlDataReader["IsSerialNumber"] + "</IsSerialNumber>" +
                                                            "<IsRateTaxesCentrerwise>" + sqlDataReader["IsRateTaxesCentrerwise"] + "</IsRateTaxesCentrerwise>" +
                                                            "<IsSaleRateDependOnPuchase>" + sqlDataReader["IsSaleRateDependOnPuchase"] + "</IsSaleRateDependOnPuchase>" +
                                                            "<SaleRateFactorInPercentage>" + sqlDataReader["SaleRateFactorInPercentage"] + "</SaleRateFactorInPercentage>" +
                                                            "<RetailRateFactorInPercentage>" + sqlDataReader["RetailRateFactorInPercentage"] + "</RetailRateFactorInPercentage>" +
                                                            "<MinIndentLevel>" + sqlDataReader["MinIndentLevel"] + "</MinIndentLevel>" +
                                                            "<IsExpiry>" + sqlDataReader["IsExpiry"] + "</IsExpiry>" +
                                                            "<IsTaxInclusive>" + sqlDataReader["IsTaxInclusive"] + "</IsTaxInclusive>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryItemRateCentrewise_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iAccBalsheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString1 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString1 = XmlDataString1 + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<ItemCode>" + sqlDataReader["ItemCode"] + "</ItemCode>" +
                                                            "<WholeSaleRate>" + sqlDataReader["WholeSaleRate"] + "</WholeSaleRate>" +
                                                            "<RetailRate>" + sqlDataReader["RetailRate"] + "</RetailRate>" +
                                                            "<SpecialRate>" + sqlDataReader["SpecialRate"] + "</SpecialRate>" +
                                                            "<MaximumRetialPrice>" + sqlDataReader["MaximumRetialPrice"] + "</MaximumRetialPrice>" +
                                                            "<LastPurchaseRate>" + sqlDataReader["LastPurchaseRate"] + "</LastPurchaseRate>" +
                                                            "<IsSaleRateDependOnPuchase>" + sqlDataReader["IsSaleRateDependOnPuchase"] + "</IsSaleRateDependOnPuchase>" +
                                                            "<SaleRateFactorInPercentage>" + sqlDataReader["SaleRateFactorInPercentage"] + "</SaleRateFactorInPercentage>" +
                                                            "<RetailRateFactorInPercentage>" + sqlDataReader["RetailRateFactorInPercentage"] + "</RetailRateFactorInPercentage>" +
                                                            "<CurrencyCode>" + sqlDataReader["CurrencyCode"] + "</CurrencyCode>" +
                                                            "<BalancesheetID>" + sqlDataReader["BalancesheetID"] + "</BalancesheetID>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString1 += "</rows>";
                    }
                    //------------------------------------------------Inserting / updating items in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryItemMasterAndItemCentrewise_PostOffline";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemRateCentrewiseXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvItemRateCentrewiseXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemMasterAndItemCentrewise_PostOffline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Location
                    //------------------------------------------------Getting location from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryLocationMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));


                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<LocationName>" + sqlDataReader["LocationName"] + "</LocationName>" +
                                                            "<BalasheetId>" + sqlDataReader["BalasheetId"] + "</BalasheetId>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting / updating items in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryLocationMaster_PostOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInventoryLocationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInventoryLocationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryLocationMaster_PostOffLine' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Sale transactions
                    //------------------------------------------------Getting Sale transactions from offline server --------------------------------------------------------

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventorySaleTransaction_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString1 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString1 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString1 = XmlDataString1 + "<row><InvSaleTransactionID>" + sqlDataReader["ID"] + "</InvSaleTransactionID>" +
                                                            "<SaleMasterID>" + sqlDataReader["SaleMasterID"] + "</SaleMasterID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<Quantity>" + sqlDataReader["Quantity"] + "</Quantity>" +
                                                            "<Rate>" + sqlDataReader["Rate"] + "</Rate>" +
                                                            "<DiscountInPercentage>" + sqlDataReader["DiscountInPercentage"] + "</DiscountInPercentage>" +
                                                            "<TaxAmount>" + sqlDataReader["TaxAmount"] + "</TaxAmount>" +
                                                            "<DiscountAmount>" + sqlDataReader["DiscountAmount"] + "</DiscountAmount>" +
                                                            "<GenTaxGroupMasterID>" + sqlDataReader["GenTaxGroupMasterID"] + "</GenTaxGroupMasterID>" +
                                                            "<TaxInPercentage>" + sqlDataReader["TaxInPercentage"] + "</TaxInPercentage>" +
                                                            "<BatchNumber>" + sqlDataReader["BatchNumber"] + "</BatchNumber>" +
                                                            "<ExpiryDate>" + sqlDataReader["ExpiryDate"] + "</ExpiryDate>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString1 += "</rows>";
                    }

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventorySalesMaster_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><InvSalesMasterID>" + sqlDataReader["ID"] + "</InvSalesMasterID>" +
                                                            "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                                                            "<BillNumber>" + sqlDataReader["BillNumber"] + "</BillNumber>" +
                                                            "<BillAmount>" + sqlDataReader["BillAmount"] + "</BillAmount>" +
                                                            "<RoundUpAmount>" + sqlDataReader["RoundUpAmount"] + "</RoundUpAmount>" +
                                                            "<CustomerName>" + sqlDataReader["CustomerName"] + "</CustomerName>" +
                                                            "<CustomerType>" + sqlDataReader["CustomerType"] + "</CustomerType>" +
                                                            "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                                                            "<CounterLogId>" + sqlDataReader["CounterLogId"] + "</CounterLogId>" +
                                                            "<LocationID>" + sqlDataReader["LocationID"] + "</LocationID>" +
                                                            "<PaymentByCustomer>" + sqlDataReader["PaymentByCustomer"] + "</PaymentByCustomer>" +
                                                            "<ReturnChange>" + sqlDataReader["ReturnChange"] + "</ReturnChange>" +
                                                            "<TotalTaxAmount>" + sqlDataReader["TotalTaxAmount"] + "</TotalTaxAmount>" +
                                                            "<TotalDiscountAmount>" + sqlDataReader["TotalDiscountAmount"] + "</TotalDiscountAmount>" +
                                                            "<NetAmount>" + sqlDataReader["NetAmount"] + "</NetAmount>" +
                                                            "<DeliveryCharge>" + sqlDataReader["DeliveryCharge"] + "</DeliveryCharge>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting  Sale transactions in online server-------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventorySaleMasterAndTransaction_PostOnline";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    transactionOnline = _onlineDbConnection.BeginTransaction();
                    cmdToExecuteOnline.Transaction = transactionOnline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOnline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    //throw new Exception("Stored Procedure 'USP_InventorySaleMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Sale Return
                    //------------------------------------------------Getting Sale return from offline server --------------------------------------------------------

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventorySaleReturnTransaction_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString1 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString1 = "<rows>";
                        while (sqlDataReader.Read())
                        {

                            XmlDataString1 = XmlDataString1 + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                               "<SalesReturnMasterID>" + sqlDataReader["SalesReturnMasterID"] + "</SalesReturnMasterID>" +
                                                               "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                               "<Quantity>" + sqlDataReader["Quantity"] + "</Quantity>" +
                                                               "<Rate>" + sqlDataReader["Rate"] + "</Rate>" +
                                                               "<DiscountInPercentage>" + sqlDataReader["DiscountInPercentage"] + "</DiscountInPercentage>" +
                                                               "<TaxAmount>" + sqlDataReader["TaxAmount"] + "</TaxAmount>" +
                                                               "<DiscountAmount>" + sqlDataReader["DiscountAmount"] + "</DiscountAmount>" +
                                                               "<GenTaxGroupMasterID>" + sqlDataReader["GenTaxGroupMasterID"] + "</GenTaxGroupMasterID>" +
                                                               "<TaxInPercentage>" + sqlDataReader["TaxInPercentage"] + "</TaxInPercentage>" +
                                                               "<BatchNumber>" + sqlDataReader["BatchNumber"] + "</BatchNumber>" +
                                                               "<ExpiryDate>" + sqlDataReader["ExpiryDate"] + "</ExpiryDate>" +
                                                               "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                               "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                               "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                               "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString1 += "</rows>";
                    }

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventorySaleReturnMaster_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                                                            "<BillNumber>" + sqlDataReader["BillNumber"] + "</BillNumber>" +
                                                            "<SalesReturnAmount>" + sqlDataReader["SalesReturnAmount"] + "</SalesReturnAmount>" +
                                                            "<RoundUpAmount>" + sqlDataReader["RoundUpAmount"] + "</RoundUpAmount>" +
                                                            "<CustomerName>" + sqlDataReader["CustomerName"] + "</CustomerName>" +
                                                            "<CustomerType>" + sqlDataReader["CustomerType"] + "</CustomerType>" +
                                                            "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                                                            "<CounterLogId>" + sqlDataReader["CounterLogId"] + "</CounterLogId>" +
                                                            "<LocationID>" + sqlDataReader["LocationID"] + "</LocationID>" +
                                                            "<PaymentByCustomer>" + sqlDataReader["PaymentByCustomer"] + "</PaymentByCustomer>" +
                                                            "<ReturnChange>" + sqlDataReader["ReturnChange"] + "</ReturnChange>" +
                                                            "<TotalTaxAmount>" + sqlDataReader["TotalTaxAmount"] + "</TotalTaxAmount>" +
                                                            "<TotalDiscountAmount>" + sqlDataReader["TotalDiscountAmount"] + "</TotalDiscountAmount>" +
                                                            "<NetAmount>" + sqlDataReader["NetAmount"] + "</NetAmount>" +
                                                            "<DeliveryCharge>" + sqlDataReader["DeliveryCharge"] + "</DeliveryCharge>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting  Sale return in online server-------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventorySaleReturnMasterAndTransaction_PostOnline";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleReturnMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleReturnMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleReturnTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvSaleReturnTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOnline.Transaction = transactionOnline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOnline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySaleReturnMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Batch
                    //------------------------------------------------Getting Batch from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryPurchsePurchaseItemBatchMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<PurchaseBillID>" + sqlDataReader["PurchaseBillID"] + "</PurchaseBillID>" +
                                                            "<BatchNumber>" + sqlDataReader["BatchNumber"] + "</BatchNumber>" +
                                                            "<ExpiryDate>" + sqlDataReader["ExpiryDate"] + "</ExpiryDate>" +
                                                            "<BatchQuantity>" + sqlDataReader["BatchQuantity"] + "</BatchQuantity>" +
                                                            "<SoldQuantity>" + sqlDataReader["SoldQuantity"] + "</SoldQuantity>" +
                                                            "<IsBatchSold>" + sqlDataReader["IsBatchSold"] + "</IsBatchSold>" +
                                                            "<SaleDate>" + sqlDataReader["SaleDate"] + "</SaleDate>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting Batch in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryPurchaseItemBatchMasterDetails_PostOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvPurchaseItemBatchMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvPurchaseItemBatchMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryPurchaseItemBatchMasterDetails_PostOffLine' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Stocks
                    //------------------------------------------------Getting Stocks from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryStockMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<LocationID>" + sqlDataReader["LocationID"] + "</LocationID>" +
                                                            "<OpeningBalance>" + sqlDataReader["OpeningBalance"] + "</OpeningBalance>" +
                                                            "<ClosingBalance>" + sqlDataReader["ClosingBalance"] + "</ClosingBalance>" +
                                                            "<CurrentStockQty>" + sqlDataReader["CurrentStockQty"] + "</CurrentStockQty>" +
                                                            "<FinancialYearID>" + sqlDataReader["FinancialYearID"] + "</FinancialYearID>" +
                                                            "<DamageStockQty>" + sqlDataReader["DamageStockQty"] + "</DamageStockQty>" +
                                                            "<StolenStockQty>" + sqlDataReader["StolenStockQty"] + "</StolenStockQty>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Inserting stocks in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryStockMaster_PostOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInventoryStockMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInventoryStockMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryStockMaster_PostOffLine' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Dump And Shrink Details
                    //------------------------------------------------Getting Dump And Shrink Master data from offline server --------------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryDumpAndShrinkDetails_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString1 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString1 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString1 = XmlDataString1 + "<row><InvDumpAndShrinkDetailsID>" + sqlDataReader["ID"] + "</InvDumpAndShrinkDetailsID>" +
                                                            "<InvDumpAndShrinkMasterID>" + sqlDataReader["DumpAndShrinkMasterID"] + "</InvDumpAndShrinkMasterID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<DumpQuantity>" + sqlDataReader["DumpQuantity"] + "</DumpQuantity>" +
                                                             "<ShrinkQuantity>" + sqlDataReader["ShrinkQuantity"] + "</ShrinkQuantity>" +
                                                            "<Rate>" + sqlDataReader["Rate"] + "</Rate>" +
                                                            "<ApprovedStatus>" + sqlDataReader["ApprovedStatus"] + "</ApprovedStatus>" +
                                                            "<Remark>" + sqlDataReader["Remark"] + "</Remark>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString1 += "</rows>";
                    }

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryDumpAndShrinkMaster_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><InvDumpAndShrinkMasterID>" + sqlDataReader["ID"] + "</InvDumpAndShrinkMasterID>" +
                                                            "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                                                            "<DumpAndShrinkAmount>" + sqlDataReader["DumpAndShrinkAmount"] + "</DumpAndShrinkAmount>" +
                                                            "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                                                            "<LocationID>" + sqlDataReader["LocationID"] + "</LocationID>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    //------------------------------------------------Getting Task Notification data from offline server --------------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_TaskNotificationDetails_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString2 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString2 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString2 = XmlDataString2 + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<TaskNotificationMasterID>" + sqlDataReader["TaskNotificationMasterID"] + "</TaskNotificationMasterID>" +
                                                            "<GeneralTaskReportingDetailsID>" + sqlDataReader["GeneralTaskReportingDetailsID"] + "</GeneralTaskReportingDetailsID>" +
                                                            "<NextGeneralTaskReportingDetailsID>" + sqlDataReader["NextGeneralTaskReportingDetailsID"] + "</NextGeneralTaskReportingDetailsID>" +
                                                            "<IsLastRecordFlag>" + sqlDataReader["IsLastRecordFlag"] + "</IsLastRecordFlag>" +
                                                            "<ApprovalStatus>" + sqlDataReader["ApprovalStatus"] + "</ApprovalStatus>" +
                                                            "<MenuCodeLink>" + sqlDataReader["MenuCodeLink"] + "</MenuCodeLink>" +
                                                            "<Description>" + sqlDataReader["Description"] + "</Description>" +
                                                            "<Remark>" + sqlDataReader["Remark"] + "</Remark>" +
                                                            "<IsParallalyUpdated>" + sqlDataReader["IsParallalyUpdated"] + "</IsParallalyUpdated>" +
                                                            "<ApplicationDate>" + sqlDataReader["ApplicationDate"] + "</ApplicationDate>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString2 += "</rows>";
                    }

                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_TaskNotificationMaster_GetOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString3 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    {
                        XmlDataString3 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString3 = XmlDataString3 + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                                                            "<TaskCode>" + sqlDataReader["TaskCode"] + "</TaskCode>" +
                                                            "<GeneralTaskReportingMasterID>" + sqlDataReader["GeneralTaskReportingMasterID"] + "</GeneralTaskReportingMasterID>" +
                                                            "<EntitytableName>" + sqlDataReader["EntitytableName"] + "</EntitytableName>" +
                                                            "<EntityPKName>" + sqlDataReader["EntityPKName"] + "</EntityPKName>" +
                                                            "<EntityPKValue>" + sqlDataReader["EntityPKValue"] + "</EntityPKValue>" +
                                                            "<PersonID>" + sqlDataReader["PersonID"] + "</PersonID>" +
                                                            "<PersonType>" + sqlDataReader["PersonType"] + "</PersonType>" +
                                                            "<Status>" + sqlDataReader["Status"] + "</Status>" +
                                                            "<LastApprovalStatus>" + sqlDataReader["LastApprovalStatus"] + "</LastApprovalStatus>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                        }
                        XmlDataString3 += "</rows>";
                    }

                    //------------------------------------------------Inserting  Dump And Shrink Master data in online server-------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryDumpAndShrinkMasterAndDetails_PostOnline";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvDumpAndShrinkMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvDumpAndShrinkMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvDumpAndShrinkDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvDumpAndShrinkDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString3));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString2));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOnline.Transaction = transactionOnline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOnline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDumpAndShrinkMasterAndDetails_PostOnline' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Task Notification
                    ////------------------------------------------------Getting Task Notification data from offline server --------------------------------------------------------
                    //cmdToExecuteOffline.Parameters.Clear();
                    //cmdToExecuteOffline.CommandText = "dbo.USP_TaskNotificationDetails_GetOffLine";
                    //cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    //cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //XmlDataString1 = string.Empty;
                    //using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    //{
                    //    XmlDataString1 = "<rows>";
                    //    while (sqlDataReader.Read())
                    //    {
                    //        XmlDataString1 = XmlDataString1 + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                    //                                        "<TaskNotificationMasterID>" + sqlDataReader["TaskNotificationMasterID"] + "</TaskNotificationMasterID>" +
                    //                                        "<GeneralTaskReportingDetailsID>" + sqlDataReader["GeneralTaskReportingDetailsID"] + "</GeneralTaskReportingDetailsID>" +
                    //                                        "<NextGeneralTaskReportingDetailsID>" + sqlDataReader["NextGeneralTaskReportingDetailsID"] + "</NextGeneralTaskReportingDetailsID>" +
                    //                                        "<IsLastRecordFlag>" + sqlDataReader["IsLastRecordFlag"] + "</IsLastRecordFlag>" +
                    //                                        "<ApprovalStatus>" + sqlDataReader["ApprovalStatus"] + "</ApprovalStatus>" +
                    //                                        "<MenuCodeLink>" + sqlDataReader["MenuCodeLink"] + "</MenuCodeLink>" +
                    //                                        "<Description>" + sqlDataReader["Description"] + "</Description>" +
                    //                                        "<Remark>" + sqlDataReader["Remark"] + "</Remark>" +
                    //                                        "<IsParallalyUpdated>" + sqlDataReader["IsParallalyUpdated"] + "</IsParallalyUpdated>" +
                    //                                        "<ApplicationDate>" + sqlDataReader["ApplicationDate"] + "</ApplicationDate>" +
                    //                                        "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                    //                                        "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                    //                                        "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                    //                                        "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                    //    }
                    //    XmlDataString1 += "</rows>";
                    //}

                    //cmdToExecuteOffline.Parameters.Clear();
                    //cmdToExecuteOffline.CommandText = "dbo.USP_TaskNotificationMaster_GetOffLine";
                    //cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    //cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //XmlDataString = string.Empty;
                    //using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    //{
                    //    XmlDataString = "<rows>";
                    //    while (sqlDataReader.Read())
                    //    {
                    //        XmlDataString = XmlDataString + "<row><ID>" + sqlDataReader["ID"] + "</ID>" +
                    //                                        "<TaskCode>" + sqlDataReader["TaskCode"] + "</TaskCode>" +
                    //                                        "<GeneralTaskReportingMasterID>" + sqlDataReader["GeneralTaskReportingMasterID"] + "</GeneralTaskReportingMasterID>" +
                    //                                        "<EntitytableName>" + sqlDataReader["EntitytableName"] + "</EntitytableName>" +
                    //                                        "<EntityPKName>" + sqlDataReader["EntityPKName"] + "</EntityPKName>" +
                    //                                        "<EntityPKValue>" + sqlDataReader["EntityPKValue"] + "</EntityPKValue>" +
                    //                                        "<PersonID>" + sqlDataReader["PersonID"] + "</PersonID>" +
                    //                                        "<PersonType>" + sqlDataReader["PersonType"] + "</PersonType>" +
                    //                                        "<Status>" + sqlDataReader["Status"] + "</Status>" +
                    //                                        "<LastApprovalStatus>" + sqlDataReader["LastApprovalStatus"] + "</LastApprovalStatus>" +
                    //                                        "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                    //                                        "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                    //                                        "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                    //                                        "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                    //    }
                    //    XmlDataString += "</rows>";
                    //}

                    ////------------------------------------------------Inserting  Task Notification data in online server-------------------------------------------------
                    //cmdToExecuteOnline.Parameters.Clear();
                    //cmdToExecuteOnline.CommandText = "dbo.USP_TaskNotificationMasterAndDetails_PostOnline";
                    //cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    //if (XmlDataString.Length > 13)
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (XmlDataString1.Length > 13)
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xTaskNotificationDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecuteOnline.Transaction = transactionOnline;
                    //// Execute query.
                    //_rowsAffected = cmdToExecuteOnline.ExecuteNonQuery();
                    #endregion

                    #region Sync Rate Mark Down Rates
                    //------------------------------------------------Getting Marked down rates from online server --------------------------------------------------------
                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryRateMarkDownMaster_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString = XmlDataString + "<row><RateMarkDownMasterID>" + sqlDataReader["ID"] + "</RateMarkDownMasterID>" +
                                                            "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                                                            "<RateMarkDownAmount>" + sqlDataReader["RateMarkDownAmount"] + "</RateMarkDownAmount>" +
                                                            "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString += "</rows>";
                    }

                    cmdToExecuteOnline.Parameters.Clear();
                    cmdToExecuteOnline.CommandText = "dbo.USP_InventoryRateMarkDownMasterDetails_GetOnLine";
                    cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(item.LastSyncDate))
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    }
                    else
                    {
                        cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    XmlDataString1 = string.Empty;
                    using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    {
                        XmlDataString1 = "<rows>";
                        while (sqlDataReader.Read())
                        {
                            XmlDataString1 = XmlDataString1 + "<row><InvRateMarkDownMasterDetailsID>" + sqlDataReader["ID"] + "</InvRateMarkDownMasterDetailsID>" +
                                                            "<RateMarkDownMasterID>" + sqlDataReader["RateMarkDownMasterID"] + "</RateMarkDownMasterID>" +
                                                            "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                                                            "<RateDecreaseByPercentage>" + sqlDataReader["RateDecreaseByPercentage"] + "</RateDecreaseByPercentage>" +
                                                            "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                                                            "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                                                            "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                                                            "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>" +
                                                            "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                        }
                        XmlDataString1 += "</rows>";
                    }
                    //------------------------------------------------Inserting / updating Marked down rates in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventoryRateMarkDownMasterAndTransaction_PostOffLine";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    if (XmlDataString.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvRateMarkDownMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvRateMarkDownMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (XmlDataString1.Length > 13)
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvRateMarkDownMasterDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    }
                    else
                    {
                        cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvRateMarkDownMasterDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryRateMarkDownMasterAndTransaction_PostOffLine' reported the ErrorCode: " + _errorCode);
                    }
                    #endregion

                    #region Sync Estimation Details

                    ////------------------------------------------------Getting Estimation Details from offline server --------------------------------------------------------
                    //cmdToExecuteOffline.Parameters.Clear();
                    //cmdToExecuteOffline.CommandText = "dbo.USP_InventoryEstimationMaster_GetOffLine";
                    //cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    //cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //XmlDataString = string.Empty;
                    //using (sqlDataReader = cmdToExecuteOffline.ExecuteReader())
                    //{
                    //    XmlDataString = "<rows>";
                    //    while (sqlDataReader.Read())
                    //    {
                    //        XmlDataString = XmlDataString + "<row><InvEstimationMasterID>" + sqlDataReader["ID"] + "</InvEstimationMasterID>" +
                    //                                        "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                    //                                        "<BillNumber>" + sqlDataReader["BillNumber"] + "</BillNumber>" +
                    //                                        "<EstimationAmount>" + sqlDataReader["EstimationAmount"] + "</EstimationAmount>" +
                    //                                        "<CustomerName>" + sqlDataReader["CustomerName"] + "</CustomerName>" +
                    //                                        "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                    //                                        "<IsPendingForBill>" + sqlDataReader["IsPendingForBill"] + "</IsPendingForBill>" + 
                    //                                        "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                    //                                        "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                    //                                        "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                    //                                        "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate></row>";
                    //    }
                    //    XmlDataString += "</rows>";
                    //}

                    ////------------------------------------------------Inserting / updating  Estimation Details in online server-------------------------------------------------
                    //cmdToExecuteOnline.Parameters.Clear();
                    //cmdToExecuteOnline.CommandText = "dbo.USP_InventoryEstimationMasterAndDetails_PostOnline ";
                    //cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    //if (XmlDataString.Length > 13)
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvEstimationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@xInvEstimationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecuteOnline.Transaction = transactionOnline;
                    //// Execute query.
                    //_rowsAffected = cmdToExecuteOnline.ExecuteNonQuery();


                    ////------------------------------------------------Getting Estimation data from online server --------------------------------------------------------
                    //cmdToExecuteOnline.Parameters.Clear();
                    //cmdToExecuteOnline.CommandText = "dbo.USP_InventoryEstimationMaster_GetOnLine";
                    //cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    //if (!string.IsNullOrEmpty(item.LastSyncDate))
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //XmlDataString = string.Empty;
                    //using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    //{
                    //    XmlDataString = "<rows>";
                    //    while (sqlDataReader.Read())
                    //    {
                    //        XmlDataString = XmlDataString + "<row><InvEstimationMasterID>" + sqlDataReader["ID"] + "</InvEstimationMasterID>" +
                    //                                        "<TransactionDate>" + sqlDataReader["TransactionDate"] + "</TransactionDate>" +
                    //                                        "<BillNumber>" + sqlDataReader["BillNumber"] + "</BillNumber>" +
                    //                                        "<EstimationAmount>" + sqlDataReader["EstimationAmount"] + "</EstimationAmount>" +
                    //                                        "<CustomerName>" + sqlDataReader["CustomerName"] + "</CustomerName>" +
                    //                                        "<BalanceSheetID>" + sqlDataReader["BalanceSheetID"] + "</BalanceSheetID>" +
                    //                                        "<IsPendingForBill>" + sqlDataReader["IsPendingForBill"] + "</IsPendingForBill>" +
                    //                                        "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                    //                                        "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                    //                                        "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                    //                                        "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>"+
                    //                                        "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                    //    }
                    //    XmlDataString += "</rows>";
                    //}

                    //cmdToExecuteOnline.Parameters.Clear();
                    //cmdToExecuteOnline.CommandText = "dbo.USP_InventoryEstimationMasterDetails_GetOnLine";
                    //cmdToExecuteOnline.CommandType = CommandType.StoredProcedure;
                    //if (!string.IsNullOrEmpty(item.LastSyncDate))
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.LastSyncDate)));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOnline.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iBalasheetId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BalancesheetID));
                    //cmdToExecuteOnline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    //XmlDataString1 = string.Empty;
                    //using (sqlDataReader = cmdToExecuteOnline.ExecuteReader())
                    //{
                    //    XmlDataString1 = "<rows>";
                    //    while (sqlDataReader.Read())
                    //    {
                    //        XmlDataString1 = XmlDataString1 + "<row><InvEstimationMasterDetailsID>" + sqlDataReader["ID"] + "</InvEstimationMasterDetailsID>" +
                    //                                        "<InvEstimationMasterID>" + sqlDataReader["EstimationMasterID"] + "</InvEstimationMasterID>" +
                    //                                        "<ItemID>" + sqlDataReader["ItemID"] + "</ItemID>" +
                    //                                        "<Quantity>" + sqlDataReader["Quantity"] + "</Quantity>" +
                    //                                        "<Rate>" + sqlDataReader["Rate"] + "</Rate>" +
                    //                                        "<CreatedBy>" + sqlDataReader["CreatedBy"] + "</CreatedBy>" +
                    //                                        "<CreatedDate>" + sqlDataReader["CreatedDate"] + "</CreatedDate>" +
                    //                                        "<ModifiedBy>" + sqlDataReader["ModifiedBy"] + "</ModifiedBy>" +
                    //                                        "<ModifiedDate>" + sqlDataReader["ModifiedDate"] + "</ModifiedDate>"+
                    //                                        "<Flag>" + sqlDataReader["Flag"] + "</Flag></row>";
                    //    }
                    //    XmlDataString1 += "</rows>";
                    //}
                    ////------------------------------------------------Inserting  Estimation data in offline server-------------------------------------------------
                    //cmdToExecuteOffline.Parameters.Clear();
                    //cmdToExecuteOffline.CommandText = "dbo.USP_InventoryEstimationMasterAndDetails_PostOffLine";
                    //cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    //if (XmlDataString.Length > 13)
                    //{
                    //    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvEstimationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvEstimationMasterXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (XmlDataString1.Length > 13)
                    //{
                    //    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvEstimationMasterDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, XmlDataString1));
                    //}
                    //else
                    //{
                    //    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@xInvEstimationMasterDetailsXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecuteOffline.Transaction = transactionOffline;
                    //// Execute query.
                    //_rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();
                    #endregion


                    //------------------------------------------------Inserting current sync date in offline server-------------------------------------------------
                    cmdToExecuteOffline.Parameters.Clear();
                    cmdToExecuteOffline.CommandText = "dbo.USP_InventorySyncHistory_Insert";
                    cmdToExecuteOffline.CommandType = CommandType.StoredProcedure;
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@sSyncType", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SyncType));
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecuteOffline.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecuteOffline.Transaction = transactionOffline;
                    // Execute query.
                    _rowsAffected = cmdToExecuteOffline.ExecuteNonQuery();


                    //-------------------------------------------------commiting transaction------------------------------------------------------------------------
                    transactionOffline.Commit();
                    transactionOnline.Commit();

                    if (_rowsAffected > 0)
                    {
                        _errorCode = (SqlInt32)cmdToExecuteOffline.Parameters["@iErrorCode"].Value;
                        item.ErrorCode = (Int32)_errorCode;
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                        response.Entity = item;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySyncHistory_Insert' reported the ErrorCode: " + _errorCode);
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
                cmdToExecuteOffline.Dispose();

            }
            return response;
        }

        /// <summary>
        /// Update a specific record of General Region Master
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> UpdateSync(Sync item)
        {
            IBaseEntityResponse<Sync> response = new BaseEntityResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_Sync_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCountryName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 60, 0, "", DataRowVersion.Proposed, item.CountryName.Trim()));
                    ////  cmdToExecute.Parameters.Add(new SqlParameter("@iSeqNo", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SeqNo));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@sContryCode", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ContryCode.Trim()));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@bDefaultFlag", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DefaultFlag));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_Sync_Insert' reported the ErrorCode: " + _errorCode);
                    }

                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                }
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
        /// Delete a selected record from General Region Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> DeleteSync(Sync item)
        {
            IBaseEntityResponse<Sync> response = new BaseEntityResponse<Sync>();
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
                    cmdToExecute.CommandText = "dbo.USP_Sync_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'USP_Sync_Delete' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

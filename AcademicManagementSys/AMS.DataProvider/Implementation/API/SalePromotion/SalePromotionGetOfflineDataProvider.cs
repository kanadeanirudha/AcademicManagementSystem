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
    public class SalePromotionGetOfflineDataProvider : DBInteractionBase, ISalePromotionGetOfflineDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalePromotionGetOfflineDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalePromotionGetOfflineDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityMaster(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityMaster_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
                    
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionGetOffline>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionGetOffline item = new SalePromotionGetOffline();

                        item.SalePromotionActivityMasterID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        item.GeneralUnitsID = sqlDataReader["GeneralUnitsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        item.PromotionalActivityFilter = sqlDataReader["PromotionalActivityFilter"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["PromotionalActivityFilter"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                       
                        baseEntityCollection.CollectionResponse.Add(item);

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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionActivityDetails_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionGetOffline>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionGetOffline item = new SalePromotionGetOffline();

                        item.SalePromotionActivityDetailsID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.SalePromotionPlanDetailsId = sqlDataReader["SalePromotionPlanDetailsId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalePromotionPlanDetailsId"]);
                        item.SalePromotionActivityMasterID = sqlDataReader["SalePromotionActivityMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalePromotionActivityMasterID"]);
                        item.SubActivityName = sqlDataReader["SubActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityName"]);
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProductConcessionFreeType"]) == false)
                        {
                            item.ProductConcessionFreeType = Convert.ToByte(sqlDataReader["ProductConcessionFreeType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]) == false)
                        {
                            item.IsCoupanOrGiftVoucherApplicable = Convert.ToBoolean(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExternalFlag"]) == false)
                        {
                            item.ExternalFlag = Convert.ToBoolean(sqlDataReader["ExternalFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCommon"]) == false)
                        {
                            item.IsCommon = Convert.ToBoolean(sqlDataReader["IsCommon"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        baseEntityCollection.CollectionResponse.Add(item);

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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetPromotionActivityDiscounteItemList(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
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
                    cmdToExecute.CommandText = "dbo.USP_PromotionActivityDiscounteItemList_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionGetOffline>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionGetOffline item = new SalePromotionGetOffline();

                        item.PromotionActivityDiscounteItemListID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.UOM = sqlDataReader["UOM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UOM"]);
                        item.InventoryVariationMasterID = sqlDataReader["InventoryVariationMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["InventoryVariationMasterID"]);
                        item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                       
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        baseEntityCollection.CollectionResponse.Add(item);

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
        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlan(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionPlan_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionGetOffline>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionGetOffline item = new SalePromotionGetOffline();

                        item.SalePromotionPlanID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.PlanTypeName = sqlDataReader["PlanTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeName"]);
                        item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        baseEntityCollection.CollectionResponse.Add(item);

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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlanDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionPlanDetails_GetOffLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionGetOffline>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionGetOffline item = new SalePromotionGetOffline();

                        item.SalePromotionPlanDetailsID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.SalePromotionPlanID = sqlDataReader["SalePromotionPlanID"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["SalePromotionPlanID"]);
                        item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        item.HowManyQtyToBuy = sqlDataReader["HowManyQtyToBuy"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["HowManyQtyToBuy"]);
                        item.GiftItemQty = sqlDataReader["GiftItemQty"] is DBNull ? new int() : Convert.ToInt32(sqlDataReader["GiftItemQty"]);
                        item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        item.BillAmountRangeFrom = sqlDataReader["BillAmountRangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeFrom"]);
                        item.BillAmountRangeUpto = sqlDataReader["BillAmountRangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeUpto"]);
                        item.BillDiscountAmount = sqlDataReader["BillDiscountAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillDiscountAmount"]);
                        if (DBNull.Value.Equals(sqlDataReader["IsSampling"]) == false)
                        {
                            item.IsSampling = Convert.ToBoolean(sqlDataReader["IsSampling"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsItemWiseDiscountExclude"]) == false)
                        {
                            item.IsItemWiseDiscountExclude = Convert.ToBoolean(sqlDataReader["IsItemWiseDiscountExclude"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPercentage"]) == false)
                        {
                            item.IsPercentage = Convert.ToBoolean(sqlDataReader["IsPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
                        }
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? new DateTime() : Convert.ToDateTime(sqlDataReader["ModifiedDate"]);

                        baseEntityCollection.CollectionResponse.Add(item);

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

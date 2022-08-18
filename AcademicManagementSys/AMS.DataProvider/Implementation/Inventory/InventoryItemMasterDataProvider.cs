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
    public class InventoryItemMasterDataProvider : DBInteractionBase, IInventoryItemMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryItemMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryItemMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from InventoryItemMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemMasterBySearch(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        {
                            item.ItemCategoryCode = Convert.ToString(sqlDataReader["CategoryCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["WholeSaleRate"]) == false)
                        {
                            item.WholeSaleRate = Convert.ToString(sqlDataReader["WholeSaleRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpecialRate"]) == false)
                        {
                            item.SpecialRate = Convert.ToString(sqlDataReader["SpecialRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RetailRate"]) == false)
                        {
                            item.RetailRate = Convert.ToDecimal(sqlDataReader["RetailRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MaximumRetialPrice"]) == false)
                        {
                            item.MaximumRetialPrice = Convert.ToString(sqlDataReader["MaximumRetialPrice"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CategoryDescription"]) == false)
                        {
                            item.ItemCategoryDescription = Convert.ToString(sqlDataReader["CategoryDescription"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = Convert.ToString(sqlDataReader["ItemCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SHORTCODE"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["SHORTCODE"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from InventoryItemMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = Convert.ToString(sqlDataReader["ItemCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RetailRate"]) == false)
                        {
                            item.SaleRate = Convert.ToDecimal(sqlDataReader["RetailRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemImage"]) == false)
                        {
                            item.Picture = (byte[])(sqlDataReader["ItemImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitID"]) == false)
                        {
                            item.UnitID = Convert.ToInt32(sqlDataReader["UnitID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["UnitCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExpiry"]) == false)
                        {
                            item.IsExpiry = Convert.ToBoolean(sqlDataReader["IsExpiry"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsTaxInclusive"]) == false)
                        {
                            item.IsTaxInclusive = Convert.ToBoolean(sqlDataReader["IsTaxInclusive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterID"]) == false)
                        {
                            item.GenTaxGroupMasterID = Convert.ToString(sqlDataReader["GenTaxGroupMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxRate"]) == false)
                        {
                            item.TaxRatePercentage = Convert.ToDecimal(sqlDataReader["TaxRate"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryItemMaster> GetInventoryItemMasterByID(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        InventoryItemMaster _item = new InventoryItemMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            _item.ItemName = sqlDataReader["ItemName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            _item.ItemCode = sqlDataReader["ItemCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PurchaseRate"]) == false)
                        {
                            _item.PurchaseRate = Convert.ToDecimal(sqlDataReader["PurchaseRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleRate"]) == false)
                        {
                            _item.SaleRate = Convert.ToDecimal(sqlDataReader["SaleRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitID"]) == false)
                        {
                            _item.UnitID = Convert.ToInt16(sqlDataReader["UnitID"]);
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
        public IBaseEntityResponse<InventoryItemMaster> InsertInventoryItemMaster(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCategoryCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ItemCategoryCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ItemName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemFamilyName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ItemFamily));
                    if (item.PackingUnit != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPackingUnit", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PackingUnit));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPackingUnit", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.PackingType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPackingType", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PackingType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPackingType", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mWholeSaleRate", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.WholeSaleRate != null ? Convert.ToDecimal(item.WholeSaleRate) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRetailRate", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RetailRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mSpecialRate", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SpecialRate != null ? Convert.ToDecimal(item.SpecialRate) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mMaximumRetialPrice", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MaximumRetialPrice != null ? Convert.ToDecimal(item.MaximumRetialPrice) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrencyCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CurrencyCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@vbItemImage", SqlDbType.VarBinary, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Picture != null ? item.Picture : new byte[1]));

                    if (item.GenTaxGroupMasterID != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGenTaxGroupMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(item.GenTaxGroupMasterID)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iGenTaxGroupMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUnitID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UnitID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSerialNumber", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsSerialNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRateTaxesCentrerwise", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsRateTaxesCentrerwise));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsSaleRateDependOnPuchase", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsSaleRateDependOnPuchase));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dSaleRateFactorInPercentage", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SaleRateFactorInPercentage != null ? Convert.ToDecimal(item.SaleRateFactorInPercentage) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dRetailRateFactorInPercentage", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RetailRateFactorInPercentage != null ? Convert.ToDecimal(item.RetailRateFactorInPercentage) : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsExpiry", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsExpiry));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTaxInclusive", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.IsTaxInclusive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemFamilyMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ItemFamilyMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemPackingUnitMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ItemPackingUnitMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemPackingTypeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ItemPackingTypeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dMinIndentLevel", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MinIndentLevel != null ? Convert.ToDecimal(item.MinIndentLevel) : 0));

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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryItemMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of InventoryItemMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemMaster> UpdateInventoryItemMaster(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ItemName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPurchaseRate", SqlDbType.Money, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PurchaseRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mSaleRate", SqlDbType.Money, 5, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleRate));// item.SaleRate
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPOSCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, !string.IsNullOrEmpty(item.POSCode) ? item.POSCode : Convert.ToString(DBNull.Value)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurrencyCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CurrencyCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@vbPicture", SqlDbType.VarBinary, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Picture != null ? item.Picture : new byte[1]));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUnitID", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UnitID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                    // item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryItemMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of InventoryItemMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemMaster> DeleteInventoryItemMaster(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_InventoryItemMaster_Delete' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<InventoryItemMaster> GetItemCode(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_GetItemCode";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsItemcode", SqlDbType.NVarChar, 18, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ItemCode));
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
                        InventoryItemMaster _item = new InventoryItemMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            _item.ItemCode = sqlDataReader["ItemCode"].ToString();
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
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForSale(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_SearchListForSale";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = Convert.ToString(sqlDataReader["ItemCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RetailRate"]) == false)
                        {
                            item.SaleRate = Convert.ToDecimal(sqlDataReader["RetailRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemImage"]) == false)
                        {
                            item.Picture = (byte[])(sqlDataReader["ItemImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitID"]) == false)
                        {
                            item.UnitID = Convert.ToInt32(sqlDataReader["UnitID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["UnitCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExpiry"]) == false)
                        {
                            item.IsExpiry = Convert.ToBoolean(sqlDataReader["IsExpiry"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterID"]) == false)
                        {
                            item.GenTaxGroupMasterID = Convert.ToString(sqlDataReader["GenTaxGroupMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsTaxInclusive"]) == false)
                        {
                            item.IsTaxInclusive = Convert.ToBoolean(sqlDataReader["IsTaxInclusive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxRate"]) == false)
                        {
                            item.TaxRatePercentage = Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxAmount"]) == false)
                        {
                            item.TaxAmount = Convert.ToDecimal(sqlDataReader["TaxAmount"]);
                        }

                        if((searchRequest.PolicyDefaultAnswer== "1") && (item.TaxRatePercentage > 0) && (item.IsTaxInclusive == false))
                        {
                            item.SaleRateExcludingtax = item.SaleRate;
                            var abc = item.SaleRate;
                            var abc1 = (((item.SaleRate) * (item.TaxRatePercentage)) / 100);
                            var abc2 = (item.SaleRate + abc1);
                            item.SaleRate = Math.Round(abc2, 2);
                            
                        }
                        item.RateDecreaseByPercentage = Convert.ToDecimal(sqlDataReader["RateDecreaseByPercentage"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetBatchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvPuchaseItemBatchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iItemID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["BatchID"]) == false)
                        {
                            item.BatchID = Convert.ToInt16(sqlDataReader["BatchID"]);
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
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InvPuchaseItemBatchMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        //GetInventoryItemMasterList
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemMasterList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMasteList_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CategoryCode"]) == false)
                        {
                            item.ItemCategoryCode = Convert.ToString(sqlDataReader["CategoryCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = Convert.ToString(sqlDataReader["ItemCode"]);
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
                        throw new Exception("Stored Procedure 'USP_InventoryItemMasteList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForEstimation(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_SearchList_Estimation";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DateTime.Now));
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemCode"]) == false)
                        {
                            item.ItemCode = Convert.ToString(sqlDataReader["ItemCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RetailRate"]) == false)
                        {
                            item.SaleRate = Convert.ToDecimal(sqlDataReader["RetailRate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemImage"]) == false)
                        {
                            item.Picture = (byte[])(sqlDataReader["ItemImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitID"]) == false)
                        {
                            item.UnitID = Convert.ToInt32(sqlDataReader["UnitID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["UnitCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExpiry"]) == false)
                        {
                            item.IsExpiry = Convert.ToBoolean(sqlDataReader["IsExpiry"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenTaxGroupMasterID"]) == false)
                        {
                            item.GenTaxGroupMasterID = Convert.ToString(sqlDataReader["GenTaxGroupMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsTaxInclusive"]) == false)
                        {
                            item.IsTaxInclusive = Convert.ToBoolean(sqlDataReader["IsTaxInclusive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxRate"]) == false)
                        {
                            item.TaxRatePercentage = Convert.ToDecimal(sqlDataReader["TaxRate"]);
                        }
                        item.RateDecreaseByPercentage = Convert.ToDecimal(sqlDataReader["RateDecreaseByPercentage"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryItemMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //GetItemFamilySearchList
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemFamilySearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemFamilyMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ItemFamilyMasterID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemFamilyName"]) == false)
                        {
                            item.ItemFamily = Convert.ToString(sqlDataReader["ItemFamilyName"]);
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
                        throw new Exception("Stored Procedure 'USP_ItemFamilyMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        //GetItemPackingUnitSearchList
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingUnitSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemPackingUnitMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ItemPackingUnitMasterID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PackingUnit"]) == false)
                        {
                            item.PackingUnit = Convert.ToString(sqlDataReader["PackingUnit"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {                       
                        throw new Exception("Stored Procedure 'USP_ItemPackingUnitMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        //GetItemPackingTypeSearchList       
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingTypeSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_ItemPackingTypeMaster_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<InventoryItemMaster>();
                    while (sqlDataReader.Read())
                    {
                        InventoryItemMaster item = new InventoryItemMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ItemPackingTypeMasterID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PackingType"]) == false)
                        {
                            item.PackingType = Convert.ToString(sqlDataReader["PackingType"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        throw new Exception("Stored Procedure 'USP_ItemPackingTypeMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<InventoryItemMaster> CheckFocusOnAction(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> response = new BaseEntityResponse<InventoryItemMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryItemMaster_CheckFocusOnAction";
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
                        InventoryItemMaster _item = new InventoryItemMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ActionID"]) == false)
                        {
                            _item.ActionID = Convert.ToInt32(sqlDataReader["ActionID"]);
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

        #endregion
    }
}

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
    public class RestaurantCategoryAndMenuDataProvider : DBInteractionBase, IRestaurantCategoryAndMenuDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public RestaurantCategoryAndMenuDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public RestaurantCategoryAndMenuDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRecipeMenuCategory_GetOnLine";
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantCategoryAndMenu>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantCategoryAndMenu item = new RestaurantCategoryAndMenu();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryRecipeMenuCategoryID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCategory"]) == false)
                        {
                            item.MenuCategory = Convert.ToString(sqlDataReader["MenuCategory"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCategoryCode"]) == false)
                        {
                            item.MenuCategoryCode = Convert.ToString(sqlDataReader["MenuCategoryCode"]);
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

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetRestaurantMenu(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRecipeMenuMaster_GetOnLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMenuCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.MenuCategoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));

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

                    baseEntityCollection.CollectionResponse = new List<RestaurantCategoryAndMenu>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantCategoryAndMenu item = new RestaurantCategoryAndMenu();
                        if (DBNull.Value.Equals(sqlDataReader["MenuType"]) == false)
                        {
                            item.MenuType = Convert.ToString(sqlDataReader["MenuType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuType"]) == false)
                        {
                            item.MenuType = Convert.ToString(sqlDataReader["MenuType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitName"]) == false)
                        {
                            item.UnitName = Convert.ToString(sqlDataReader["UnitName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryLocationMasterID"]) == false)
                        {
                            item.InventoryLocationMasterID = Convert.ToInt32(sqlDataReader["InventoryLocationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralUnitsID"]) == false)
                        {
                            item.GeneralUnitsID = Convert.ToInt32(sqlDataReader["GeneralUnitsID"]);
                        }
                        
                        if (DBNull.Value.Equals(sqlDataReader["GeneralItemMasterID"]) == false)
                        {
                            item.GeneralItemMasterID = Convert.ToInt32(sqlDataReader["GeneralItemMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UomCode"]) == false)
                        {
                            item.UomCode = Convert.ToString(sqlDataReader["UomCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDescription"]) == false)
                        {
                            item.MenuDescription = Convert.ToString(sqlDataReader["MenuDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillingItemName"]) == false)
                        {
                            item.BillingItemName = Convert.ToString(sqlDataReader["BillingItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsBOMRelevant"]) == false)
                        {
                            item.IsBOMRelevant = Convert.ToInt32(sqlDataReader["IsBOMRelevant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryVariationMasterID"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt32(sqlDataReader["InventoryVariationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RelatedWithCafe"]) == false)
                        {
                            item.RelatedWithCafe = Convert.ToInt32(sqlDataReader["RelatedWithCafe"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRestaurant"]) == false)
                        {
                            item.IsRestaurant = Convert.ToBoolean(sqlDataReader["IsRestaurant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyName"]) == false)
                        {
                            item.CurrencyName = Convert.ToString(sqlDataReader["CurrencyName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeMenuImage"]) == false)
                        {
                            item.RecipeMenuImage = searchRequest.ImagePath + Convert.ToString(sqlDataReader["RecipeMenuImage"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["SalePromotionActivityMasterID"]) == false)
                        {
                            item.SalePromotionActivityMasterID = Convert.ToInt32(sqlDataReader["SalePromotionActivityMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalePromotionPlanDetailsId"]) == false)
                        {
                            item.SalePromotionPlanDetailsId = Convert.ToInt32(sqlDataReader["SalePromotionPlanDetailsId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Name"]) == false)
                        {
                            item.Name = Convert.ToString(sqlDataReader["Name"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DiscountInPercent"]) == false)
                        {
                            item.DiscountInPercent = Convert.ToInt32(sqlDataReader["DiscountInPercent"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PromotionActivityFlag"]) == false)
                        {
                            item.PromotionActivityFlag = Convert.ToBoolean(sqlDataReader["PromotionActivityFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalePromotionActivityDetailsID"]) == false)
                        {
                            item.SalePromotionActivityDetailsID = Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ProductConcessionFreeType"]) == false)
                        {
                            item.ProductConcessionFreeType = Convert.ToByte(sqlDataReader["ProductConcessionFreeType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]) == false)
                        {
                            item.IsCoupanOrGiftVoucherApplicable = Convert.ToBoolean(sqlDataReader["IsCoupanOrGiftVoucherApplicable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["HowManyQtyToBuy"]) == false)
                        {
                            item.HowManyQtyToBuy = Convert.ToInt16(sqlDataReader["HowManyQtyToBuy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GiftItemQty"]) == false)
                        {
                            item.GiftItemQty = Convert.ToInt16(sqlDataReader["GiftItemQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PlanTypeCode"]) == false)
                        {
                            item.PlanTypeCode = Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeVariationDescription"]) == false)
                        {
                            item.RecipeVariationDescription = Convert.ToString(sqlDataReader["RecipeVariationDescription"]);
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

        public IBaseEntityResponse<RestaurantCategoryAndMenu> GetRestaurantMenuSpecification(RestaurantCategoryAndMenu item)
        {
            IBaseEntityResponse<RestaurantCategoryAndMenu> response = new BaseEntityResponse<RestaurantCategoryAndMenu>();
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
                    RestaurantCategoryAndMenu _item = new RestaurantCategoryAndMenu();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    //_item.Status = (int)_errorCode;
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

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuCategory(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRecipeMenuCategory_GetOffLine";
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantCategoryAndMenu>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantCategoryAndMenu item = new RestaurantCategoryAndMenu();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryRecipeMenuCategoryID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCategory"]) == false)
                        {
                            item.MenuCategory = Convert.ToString(sqlDataReader["MenuCategory"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCategoryCode"]) == false)
                        {
                            item.MenuCategoryCode = Convert.ToString(sqlDataReader["MenuCategoryCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
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

        public IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> GetInventoryRecipeMenuMaster(RestaurantCategoryAndMenuSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantCategoryAndMenu> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantCategoryAndMenu>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRecipeMenuMaster_GetOffLine";
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantCategoryAndMenu>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantCategoryAndMenu item = new RestaurantCategoryAndMenu();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryRecipeMenuCategoryID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuDescription"]) == false)
                        {
                            item.MenuDescription = Convert.ToString(sqlDataReader["MenuDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeMasterID"]) == false)
                        {
                            item.RecipeMasterID = Convert.ToInt32(sqlDataReader["RecipeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MenuCategoryID"]) == false)
                        {
                            item.MenuCategoryID = Convert.ToInt32(sqlDataReader["MenuCategoryID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Flag"]) == false)
                        {
                            item.Flag = Convert.ToBoolean(sqlDataReader["Flag"]);
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



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
    public class InventoryRecipeDetailsDataProvider : DBInteractionBase, IInventoryRecipeDetailsDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public InventoryRecipeDetailsDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public InventoryRecipeDetailsDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion
        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetInventoryRecipeMaster";
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

                    baseEntityCollection.CollectionResponse = new List<InventoryRecipeDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryRecipeDetails item = new InventoryRecipeDetails();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Title"]) == false)
                        {
                            item.Title = Convert.ToString(sqlDataReader["Title"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Description"]) == false)
                        {
                            item.Description = Convert.ToString(sqlDataReader["Description"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["VersionCode"]) == false)
                        {
                            item.VersionCode = Convert.ToString(sqlDataReader["VersionCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrimaryItemOutputID"]) == false)
                        {
                            item.PrimaryItemOutputID = Convert.ToInt32(sqlDataReader["PrimaryItemOutputID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OldRecipeID"]) == false)
                        {
                            item.OldRecipeID = Convert.ToInt32(sqlDataReader["OldRecipeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BOMRelevant"]) == false)
                        {
                            item.BOMRelevant = Convert.ToString(sqlDataReader["BOMRelevant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BillingItemName"]) == false)
                        {
                            item.BillingItemName = Convert.ToString(sqlDataReader["BillingItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ArabicTransalation"]) == false)
                        {
                            item.ArabicTransalation = Convert.ToString(sqlDataReader["ArabicTransalation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeMenuImage"]) == false)
                        {
                            item.RecipeMenuImage = Convert.ToString(sqlDataReader["RecipeMenuImage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ArabicTransalation"]) == false)
                        {
                            item.ArabicTransalation = Convert.ToString(sqlDataReader["ArabicTransalation"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToDecimal(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RelatedWithCafe"]) == false)
                        {
                            item.RelatedWithCafe = Convert.ToByte(sqlDataReader["RelatedWithCafe"]);
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

        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryVariationMaster(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryVariationMaster";
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

                    baseEntityCollection.CollectionResponse = new List<InventoryRecipeDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryRecipeDetails item = new InventoryRecipeDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryRecipeMasterID"]) == false)
                        {
                            item.InventoryRecipeMasterID = Convert.ToInt16(sqlDataReader["InventoryRecipeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeVariationTitle"]) == false)
                        {
                            item.RecipeVariationTitle = Convert.ToString(sqlDataReader["RecipeVariationTitle"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeVariationDescription"]) == false)
                        {
                            item.RecipeVariationDescription = Convert.ToString(sqlDataReader["RecipeVariationDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Price"]) == false)
                        {
                            item.Price = Convert.ToInt32(sqlDataReader["Price"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        {
                            item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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

        public IBaseEntityCollectionResponse<InventoryRecipeDetails> GetInventoryRecipeFormulaDetails(InventoryRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryRecipeDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryRecipeFormulaDetails";
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

                    baseEntityCollection.CollectionResponse = new List<InventoryRecipeDetails>();
                    while (sqlDataReader.Read())
                    {
                        InventoryRecipeDetails item = new InventoryRecipeDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.InventoryRecipeFormulaDetailsID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InoutType"]) == false)
                        {
                            item.InoutType = Convert.ToBoolean(sqlDataReader["InoutType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsOptionalIngrediant"]) == false)
                        {
                            item.IsOptionalIngrediant = Convert.ToBoolean(sqlDataReader["IsOptionalIngrediant"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Cost"]) == false)
                        {
                            item.cost = Convert.ToDecimal(sqlDataReader["Cost"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrderNumber"]) == false)
                        {
                            item.OrderNumber = Convert.ToInt16(sqlDataReader["OrderNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UOMCode"]) == false)
                        {
                            item.UOMCode = Convert.ToString(sqlDataReader["UOMCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RecipeMasterID"]) == false)
                        {
                            item.RecipeMasterID = Convert.ToInt16(sqlDataReader["RecipeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InventoryVariationMasterID"]) == false)
                        {
                            item.InventoryVariationMasterID = Convert.ToInt16(sqlDataReader["InventoryVariationMasterID"]);
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



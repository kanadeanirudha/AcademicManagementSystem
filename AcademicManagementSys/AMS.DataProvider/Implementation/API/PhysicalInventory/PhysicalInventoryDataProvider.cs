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
    public class PhysicalInventoryDataProvider : DBInteractionBase, IPhysicalInventoryDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public PhysicalInventoryDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public PhysicalInventoryDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<PhysicalInventory> PostPhysicalInventory(PhysicalInventory item)
        {
            IBaseEntityResponse<PhysicalInventory> response = new BaseEntityResponse<PhysicalInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_PhysicalInventoryStock_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.ID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TransactionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siActionStatus", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ActionStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPhysicalInventoryStockDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.PhysicalInventoryStockDetails) ? string.Empty : item.PhysicalInventoryStockDetails));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xPhysicalInventoryVoucherXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.PhysicalInventoryVoucherXml) ? string.Empty : item.PhysicalInventoryVoucherXml));
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

                    PhysicalInventory _item = new PhysicalInventory();
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

        public IBaseEntityCollectionResponse<PhysicalInventory> GetPhysicalInventory(PhysicalInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PhysicalInventory> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<PhysicalInventory>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetPhysicalInventoryStock";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siGeneralUnitsID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBarCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ItemBarCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
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

                    baseEntityCollection.CollectionResponse = new List<PhysicalInventory>();
                    while (sqlDataReader.Read())
                    {
                        PhysicalInventory item = new PhysicalInventory();

                        if (DBNull.Value.Equals(sqlDataReader["ItemNumber"]) == false)
                        {
                            item.ItemNumber = Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemDescription"]) == false)
                        {
                            item.ItemDescription = Convert.ToString(sqlDataReader["ItemDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrentStockQty"]) == false)
                        {
                            item.CurrentStockQty = Convert.ToDecimal(sqlDataReader["CurrentStockQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SalePrice"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["SalePrice"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SaleUOM"]) == false)
                        {
                            item.SaleUOM = Convert.ToString(sqlDataReader["SaleUOM"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BaseUOM"]) == false)
                        {
                            item.BaseUOM = Convert.ToString(sqlDataReader["BaseUOM"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ConversionFactor"]) == false)
                        {
                            item.ConversionFactor = Convert.ToDecimal(sqlDataReader["ConversionFactor"]);
                        }
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
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
    }
}

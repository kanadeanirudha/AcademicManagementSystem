
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
    public class RestaurantTableMasterDataProvider : DBInteractionBase, IRestaurantTableMasterDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public RestaurantTableMasterDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public RestaurantTableMasterDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityCollectionResponse<RestaurantTableMaster> RestaurantTableGetOnline(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_GetOnLine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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

                    baseEntityCollection.CollectionResponse = new List<RestaurantTableMaster>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantTableMaster item = new RestaurantTableMaster();
                        item.ID = sqlDataReader["RestaurantTableMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RestaurantTableMasterID"]);
                        item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        item.TableNumber = sqlDataReader["TableNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TableNumber"]);
                        item.Shape = sqlDataReader["Shape"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["Shape"]);
                        item.MaxCapicity = sqlDataReader["MaxCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MaxCapacity"]);
                        item.MinCapacity = sqlDataReader["MinCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MinCapacity"]);
                        item.RestaurantAllocatedTablesID = sqlDataReader["RestaurantAllocatedTablesID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["RestaurantAllocatedTablesID"]);
                        item.AllocatedFrom = sqlDataReader["AllocatedFrom"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllocatedFrom"]);
                        item.AllocatedUpto = sqlDataReader["AllocatedUpto"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllocatedUpto"]);
                        item.MatrixRowPosition = sqlDataReader["MatrixRowPosition"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MatrixRowPosition"]);
                        item.MatrixColPosition = sqlDataReader["MatrixColPosition"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MatrixColPosition"]);
                        item.IsTablePartiallyAllocated = sqlDataReader["IsTablePartiallyAllocated"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsTablePartiallyAllocated"]);
                        item.IsTableAvailableForBooking = sqlDataReader["IsTableAvailableForBooking"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsTableAvailableForBooking"]);
                        item.CenterCode = sqlDataReader["CenterCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CenterCode"]);
                        item.IsEngagedFlag = sqlDataReader["IsEngagedFlag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsEngagedFlag"]);
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

        //Methods for RestaurantTableMaster Form

        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantTableMasterBySearch(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<RestaurantTableMaster>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantTableMaster item = new RestaurantTableMaster();
                        item.ID = sqlDataReader["RestaurantTableMasterID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RestaurantTableMasterID"]);
                        item.Name = sqlDataReader["Name"] is DBNull ?  string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        item.TableNumber = sqlDataReader["TableNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TableNumber"]);
                        item.Shape = sqlDataReader["Shape"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["Shape"]);
                        item.MaxCapicity = sqlDataReader["MaxCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MaxCapacity"]);
                        item.MinCapacity = sqlDataReader["MinCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MinCapacity"]);

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
                        throw new Exception("Stored Procedure 'USP_RestaurantTableMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<RestaurantTableMaster> GetRestaurantTableMasterByID(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> response = new BaseEntityResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_SelectOne";
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
                        RestaurantTableMaster _item = new RestaurantTableMaster();
                        _item.ID = sqlDataReader["ID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["ID"]);
                        _item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        _item.TableNumber = sqlDataReader["TableNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TableNumber"]);
                        _item.Shape = sqlDataReader["Shape"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["Shape"]);
                        _item.MaxCapicity = sqlDataReader["MaxCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MaxCapacity"]);
                        _item.MinCapacity = sqlDataReader["MinCapacity"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["MinCapacity"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'RestaurantTableMaster' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<RestaurantTableMaster> InsertRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> response = new BaseEntityResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@siRestaurantTableMasterID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Name));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTableNumber", SqlDbType.NVarChar, 20,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.TableNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tishape", SqlDbType.TinyInt, 5, ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.Shape));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMinCapacity", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MinCapacity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMaxCapacity", SqlDbType.TinyInt, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MaxCapicity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                   
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    //item.errorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_RestaurantTableMaster_INSERT' reported the ErrorCode: " +
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
                            ErrorMessage = "Create failed",

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
                _errorCode = 77;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _errorCode = 77;
                item.ErrorCode = (Int32)_errorCode;
                item.ErrorMessage = "sql error";
                response.Entity = item;
                //_logException.Error(ex.Message);
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
        /// Update a specific record of RestaurantTableMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RestaurantTableMaster> UpdateRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> response = new BaseEntityResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5,ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsName", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.Name));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTableNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.TableNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiShape", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 0, 0, "",
                                                    DataRowVersion.Proposed, item.Shape));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMaxCapacity", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.MaxCapicity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siMinCapacity", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "",
                                               DataRowVersion.Proposed, item.MinCapacity));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "",
                                               DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100,
                    //                       ParameterDirection.Output, true, 10, 0, "",
                    //                       DataRowVersion.Proposed, item.ErrorMessage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                  //  item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    //item.ErrorCode = (Int32)_errorCode;
                   // response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_RestaurantTableMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of RestaurantTableMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RestaurantTableMaster> DeleteRestaurantTableMaster(RestaurantTableMaster item)
        {
            IBaseEntityResponse<RestaurantTableMaster> response = new BaseEntityResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_RestaurantTableMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<RestaurantTableMaster> GetRestaurantCategory(RestaurantTableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantTableMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<RestaurantTableMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableMaster_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<RestaurantTableMaster>();
                    while (sqlDataReader.Read())
                    {
                        RestaurantTableMaster item = new RestaurantTableMaster();

                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["MenuCategory"]) == false)
                        //{
                        //    item.MenuCategory = Convert.ToString(sqlDataReader["MenuCategory"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["MenuCategoryCode"]) == false)
                        //{
                        //    item.MenuCategoryCode = Convert.ToString(sqlDataReader["MenuCategoryCode"]);
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
                        throw new Exception("Stored Procedure 'USP_RestaurantTableMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

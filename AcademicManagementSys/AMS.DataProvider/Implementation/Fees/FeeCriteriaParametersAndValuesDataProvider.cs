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
    public class FeeCriteriaParametersAndValuesDataProvider : DBInteractionBase, IFeeCriteriaParametersAndValuesDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FeeCriteriaParametersAndValuesDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FeeCriteriaParametersAndValuesDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FeeCriteriaParametersAndValues table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetFeeCriteriaParametersAndValuesBySearch(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParametersAndValues_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalancesheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeCriteriaParametersAndValues>();
                    while (sqlDataReader.Read())
                    {
                        FeeCriteriaParametersAndValues item = new FeeCriteriaParametersAndValues();
                        item.FeeCriteriaParametersID = Convert.ToInt32(sqlDataReader["FeeCriteriaParametersID"]);
                        item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();
                        item.FeeCriteriaParametersCode = sqlDataReader["FeeCriteriaParametersCode"].ToString();
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.FeeCriteriaParametersValuesID = Convert.ToInt32(sqlDataReader["FeeCriteriaParameterValuesID"]);
                        item.FeeCriteriaParameterValue = sqlDataReader["FeeCriteriaParameterValue"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_FeeCriteriaParametersAndValues_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> GetFeeCriteriaParametersAndValuesByID(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> response = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParametersAndValues_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersID));
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
                        FeeCriteriaParametersAndValues _item = new FeeCriteriaParametersAndValues();
                        _item.FeeCriteriaParametersID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();
                        _item.FeeCriteriaParametersCode = sqlDataReader["FeeCriteriaParametersCode"].ToString();
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        _item.RelatedWith = sqlDataReader["RelatedWith"].ToString();

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

        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> SearchList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParametersAndValues_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalancesheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeCriteriaParametersAndValues>();
                    while (sqlDataReader.Read())
                    {
                        FeeCriteriaParametersAndValues item = new FeeCriteriaParametersAndValues();
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaParametersID"]) == false)
                        {
                            item.FeeCriteriaParametersID = Convert.ToInt32(sqlDataReader["FeeCriteriaParametersID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaParametersDescription"]) == false)
                        {
                            item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_FeeCriteriaParametersAndValues_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> InsertFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> response = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (item.FeeCriteriaParameterOrValue == "Parameter")
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParameters_INSERT";
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaParametersDescription", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersDescription));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaParametersCode", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalancesheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccBalanceSheetID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRelatedWith", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RelatedWith != null ? item.RelatedWith : DBNull.Value.ToString()));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    }
                    else if (item.FeeCriteriaParameterOrValue == "Value")
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParametersValue_INSERT";
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaParametersValuesID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersValuesID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@xFeeCriteriaParamValues", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParameterValue));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaParametersID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersID));                    
                    
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
                        if (item.FeeCriteriaParameterOrValue == "Parameter")
                        {
                            item.FeeCriteriaParametersID = (Int32)cmdToExecute.Parameters["@iFeeCriteriaParametersID"].Value;
                        }
                        else if (item.FeeCriteriaParameterOrValue == "Value")
                        {
                            item.FeeCriteriaParametersID = (Int32)cmdToExecute.Parameters["@iFeeCriteriaParametersID"].Value;
                        }
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_FeeCriteriaParametersAndValues_Insert' reported the ErrorCode: " +
                                            _errorCode);
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
        /// Update a specific record of FeeCriteriaParametersAndValues
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> UpdateFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> response = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParameters_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.FeeCriteriaParametersID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaParametersDescription", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.FeeCriteriaParametersDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaParametersCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.FeeCriteriaParametersCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRelatedWith", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.RelatedWith));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
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
                    item.FeeCriteriaParametersID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeCriteriaParameters_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of FeeCriteriaParametersAndValues
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeCriteriaParametersAndValues> DeleteFeeCriteriaParametersAndValues(FeeCriteriaParametersAndValues item)
        {
            IBaseEntityResponse<FeeCriteriaParametersAndValues> response = new BaseEntityResponse<FeeCriteriaParametersAndValues>();
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
                    if (item.FeeCriteriaParameterOrValue == "Parameter")
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParameters_Delete";
                        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersID));
                    }
                    else if (item.FeeCriteriaParameterOrValue == "Value")
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParametersValues_Delete";
                        cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaParametersValuesID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaParametersValuesID));
                    }
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                        throw new Exception("Stored Procedure 'USP_FeeCriteriaParametersAndValues_Delete' reported the ErrorCode: " + _errorCode);
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

        //
        public IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> GetFeePredefinedCriteriaParametersList(FeePredefinedCriteriaParametersSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeePredefinedCriteriaParameters> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeePredefinedCriteriaParameters>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeePredefinedCriteriaParameters_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt16(searchRequest.BalanceSheetID)));
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
                    baseEntityCollection.CollectionResponse = new List<FeePredefinedCriteriaParameters>();
                    while (sqlDataReader.Read())
                    {
                        FeePredefinedCriteriaParameters item = new FeePredefinedCriteriaParameters();
                        
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaParametersDescription"]) == false)
                        {
                            item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaParametersCode"]) == false)
                        {
                            item.FeeCriteriaParametersCode = sqlDataReader["FeeCriteriaParametersCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_FeePredefinedCriteriaParameters_SearchList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> GetPredefinedCriteriaParametersValueList(FeeCriteriaParametersAndValuesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeCriteriaParametersAndValues> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeCriteriaParametersAndValues>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeCriteriaParameterValues_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaParametersID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeCriteriaParametersValuesID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeCriteriaParametersAndValues>();
                    while (sqlDataReader.Read())
                    {
                        FeeCriteriaParametersAndValues item = new FeeCriteriaParametersAndValues();
                        if (DBNull.Value.Equals(sqlDataReader["PrimaryKey"]) == false)
                        {
                            item.FeeCriteriaParametersValuesID = Convert.ToInt32(sqlDataReader["PrimaryKey"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DisplayKey"]) == false)
                        {
                            item.FeeCriteriaParameterValue = sqlDataReader["DisplayKey"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeCriteriaParameterValues_SearchList' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

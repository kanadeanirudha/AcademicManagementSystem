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
    public class SalaryPayScaleMasterDataProvider : DBInteractionBase, ISalaryPayScaleMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalaryPayScaleMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalaryPayScaleMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalaryPayScaleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayScaleMasterBySearch(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 250, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy  ", SqlDbType.NVarChar, 450, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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
                    baseEntityCollection.CollectionResponse = new List<SalaryPayScaleMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryPayScaleMaster item = new SalaryPayScaleMaster();
                        item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        item.Description = Convert.ToString(sqlDataReader["Description"]);
                        item.PayScaleRuleDescription = Convert.ToString(sqlDataReader["PayScaleRuleDescription"]);
                        item.PayScaleRange = sqlDataReader["PayScaleRange"].ToString();
                        item.RangeFrom = Math.Round(Convert.ToDecimal(sqlDataReader["RangeFrom"]),2);
                        item.RangeUpto = Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]),2);
                        item.PayBandIncrementPercent = Convert.ToDecimal(sqlDataReader["PayBandIncrementPercent"]);
                        item.PaybandPeriodSpan = Convert.ToInt32(sqlDataReader["PaybandPeriodSpan"]);
                        item.PaybandPeriodUnit = sqlDataReader["PaybandPeriodUnit"].ToString();
                        item.SalaryPayRulesID = Convert.ToInt32(sqlDataReader["SalaryPayRulesID"]);


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
                        throw new Exception("Stored Procedure 'USP_SalaryPayScaleMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryPayScaleMaster> GetSalaryPayScaleMasterByID(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> response = new BaseEntityResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_SelectOne";
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
                        SalaryPayScaleMaster _item = new SalaryPayScaleMaster();
                        _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        _item.DesignationID = Convert.ToInt32(sqlDataReader["DesignationID"]);
                        _item.PayScaleRange = sqlDataReader["PayScaleRange"].ToString();
                        _item.RangeFrom = Math.Round( Convert.ToDecimal(sqlDataReader["RangeFrom"]),2);
                        _item.RangeUpto = Math.Round(Convert.ToDecimal(sqlDataReader["RangeUpto"]),2);
                        _item.PayBandIncrementPercent = Convert.ToDecimal(sqlDataReader["PayBandIncrementPercent"]);
                        _item.PaybandPeriodSpan = Convert.ToInt32(sqlDataReader["PaybandPeriodSpan"]);
                        _item.PaybandPeriodUnit = sqlDataReader["PaybandPeriodUnit"].ToString();
                        _item.SalaryPayRulesID = Convert.ToInt32(sqlDataReader["SalaryPayRulesID"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'SalaryPayScaleMaster' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> response = new BaseEntityResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DesignationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPayScaleRange", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 11, 0, "",
                                            DataRowVersion.Proposed, item.PayScaleRange));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 19,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.RangeFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 19,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.RangeUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPayBandIncrementPercent", SqlDbType.Decimal, 18,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.PayBandIncrementPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPaybandPeriodSpan", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.PaybandPeriodSpan));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaybandPeriodUnit", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 11, 0, "",
                                            DataRowVersion.Proposed, item.PaybandPeriodUnit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalaryPayRulesID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.SalaryPayRulesID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 5,
                                            ParameterDirection.Output, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                    item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryPayScaleMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of SalaryPayScaleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> response = new BaseEntityResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDesignationID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.DesignationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPayScaleRange", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 11, 0, "",
                                        DataRowVersion.Proposed, item.PayScaleRange));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRangeFrom", SqlDbType.Money, 19,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.RangeFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRangeUpto", SqlDbType.Money, 19,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.RangeUpto));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPayBandIncrementPercent", SqlDbType.Decimal, 18,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PayBandIncrementPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPaybandPeriodSpan", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PaybandPeriodSpan));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaybandPeriodUnit", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 11, 0, "",
                                        DataRowVersion.Proposed, item.PaybandPeriodUnit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalaryPayRulesID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SalaryPayRulesID));

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
                    item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryPayScaleMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalaryPayScaleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> response = new BaseEntityResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.DeletedBy));
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
                    item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryPayScaleMaster_Delete' reported the ErrorCode: " +
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
        //*****************For Salary Pay Rule
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryPayScaleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryPayScaleMaster_GetDropdownListPayScale";
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
                    baseEntityCollection.CollectionResponse = new List<SalaryPayScaleMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryPayScaleMaster item = new SalaryPayScaleMaster();
                         item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                         item.PayScaleRange = sqlDataReader["PayScaleRange"].ToString();


                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryPayRules_SelectAll' reported the ErrorCode: " + _errorCode);
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

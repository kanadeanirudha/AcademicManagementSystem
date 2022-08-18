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
    public class EntranceExamValidationParameterApplicableDataProvider : DBInteractionBase, IEntranceExamValidationParameterApplicableDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EntranceExamValidationParameterApplicableDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EntranceExamValidationParameterApplicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EntranceExamValidationParameterApplicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableBySearch(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCentreWiseSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionID));
                    
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamValidationParameterApplicable>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamValidationParameterApplicable item = new EntranceExamValidationParameterApplicable();
                        item.ID = sqlDataReader["EntranceExamValidationParameterApplicableID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["EntranceExamValidationParameterApplicableID"]);
                        //item.FeeCriteriaMasterID = sqlDataReader["FeeCriteriaMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeCriteriaMasterID"]);
                        //item.FeeCriteriaValueCombinationMasterID = sqlDataReader["FeeCriteriaValueCombinationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
                        //item.FeeCriteriaValueCombinationDescription = sqlDataReader["FeeCriteriaValueCombinationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        //item.PreQualificationCutOff = sqlDataReader["PreQualificationCutOff"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["PreQualificationCutOff"]);
                        //item.EntranceExamFeeAmount = sqlDataReader["EntranceExamFeeAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["EntranceExamFeeAmount"]);
                        //item.EntranceExamCutOff = sqlDataReader["EntranceExamCutOff"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["EntranceExamCutOff"]);

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
                        throw new Exception("Stored Procedure 'USP_EntranceExamValidationParameterApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableList(EntranceExamValidationParameterApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamValidationParameterApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                  
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamValidationParameterApplicable>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamValidationParameterApplicable item = new EntranceExamValidationParameterApplicable();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        //item.FeeCriteriaValueCombinationMasterID = sqlDataReader["FeeCriteriaValueCombinationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
                        //item.FeeCriteriaValueCombinationDescription = sqlDataReader["FeeCriteriaValueCombinationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        //item.PreQualificationCutOff = sqlDataReader["PreQualificationCutOff"] is DBNull ? 0 : Convert.ToInt16(sqlDataReader["PreQualificationCutOff"]);
                        //item.EntranceExamFeeAmount = sqlDataReader["EntranceExamFeeAmount"] is DBNull ? 0 : Convert.ToInt16(sqlDataReader["EntranceExamFeeAmount"]);
                        //item.EntranceExamCutOff = sqlDataReader["EntranceExamCutOff"] is DBNull ? 0 : Convert.ToInt16(sqlDataReader["EntranceExamCutOff"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamValidationParameterApplicable_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> GetEntranceExamValidationParameterApplicableByID(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_SelectOne";
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
                        EntranceExamValidationParameterApplicable _item = new EntranceExamValidationParameterApplicable();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                       // _item.FeeCriteriaValueCombinationDescription = sqlDataReader["FeeCriteriaValueCombinationDescription"].ToString();
                        _item.PreQualificationCutOff = Convert.ToDecimal(sqlDataReader["PreQualificationCutOff"]);
                        _item.EntranceExamFeeAmount = Convert.ToDecimal(sqlDataReader["EntranceExamFeeAmount"]);
                        _item.EntranceExamCutOff = Convert.ToDecimal(sqlDataReader["EntranceExamCutOff"]);

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
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> InsertEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Output, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaValueCombinationMasterID", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.FeeCriteriaValueCombinationMasterID));
                    ////cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaValueCombinationDescription", SqlDbType.NVarChar, 20,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.FeeCriteriaValueCombinationDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcPreQualificationCutOff", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PreQualificationCutOff));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcEntranceExamCutOff", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamCutOff));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dcEntranceExamFeeAmount", SqlDbType.Decimal,8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamFeeAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
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
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamValidationParameterApplicable_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of EntranceExamValidationParameterApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> UpdateEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaValueCombinationMasterID", SqlDbType.Int, 10,
                    //                   ParameterDirection.Input, false, 0, 0, "",
                    //                   DataRowVersion.Proposed, item.FeeCriteriaValueCombinationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeCriteriaValueCombinationDescription", SqlDbType.NVarChar, 60,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.FeeCriteriaValueCombinationDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPreQualificationCutOff", SqlDbType.Decimal, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.PreQualificationCutOff));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dEntranceExamFeeAmount", SqlDbType.Decimal, 8,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.EntranceExamFeeAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dEntranceExamCutOff", SqlDbType.Decimal, 5,
                                       ParameterDirection.Input, false, 0, 0, "",
                                       DataRowVersion.Proposed, item.EntranceExamCutOff));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamValidationParameterApplicable_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EntranceExamValidationParameterApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<EntranceExamValidationParameterApplicable> DeleteEntranceExamValidationParameterApplicable(EntranceExamValidationParameterApplicable item)
        {
            IBaseEntityResponse<EntranceExamValidationParameterApplicable> response = new BaseEntityResponse<EntranceExamValidationParameterApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamValidationParameterApplicable_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamValidationParameterApplicable_Delete' reported the ErrorCode: " +
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


        #endregion
    }
}

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
    public class ToolTemplateApplicableDataProvider : DBInteractionBase, IToolTemplateApplicableDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public ToolTemplateApplicableDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public ToolTemplateApplicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from ToolTemplateApplicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetToolTemplateApplicableBySearch(ToolTemplateApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ScopeIdentity));

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
                    baseEntityCollection.CollectionResponse = new List<ToolTemplateApplicable>();
                    while (sqlDataReader.Read())
                    {
                        ToolTemplateApplicable item = new ToolTemplateApplicable();
                        // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["TemplateID"]) == false)
                        {
                            item.TemplateID = Convert.ToInt32(sqlDataReader["TemplateID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TemplateApplicableID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["TemplateApplicableID"]);
                        }
                        if (sqlDataReader["TemplateName"] != null)
                            item.TemplateName = sqlDataReader["TemplateName"].ToString();
                        else
                            item.TemplateName = "";
                        if (DBNull.Value.Equals(sqlDataReader["BranchDetID"]) == false)
                        {
                            item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                        }
                        if (sqlDataReader["BranchDescription"] != null)
                            item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        else
                            item.BranchDescription = "";
                        item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        if (DBNull.Value.Equals(sqlDataReader["StandardNumber"]) == false)
                        {
                            item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
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
                        throw new Exception("Stored Procedure 'USP_ToolTemplateApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<ToolTemplateApplicable> GetToolTemplateApplicableByID(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> response = new BaseEntityResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_SelectOne";
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
                        ToolTemplateApplicable _item = new ToolTemplateApplicable();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.TemplateID = Convert.ToInt32(sqlDataReader["TemplateID"]);
                        _item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetailID"]);
                        _item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        _item.FromDate = Convert.ToString(sqlDataReader["FromDate"]);
                        _item.ToDate = Convert.ToString(sqlDataReader["ToDate"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

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
        public IBaseEntityResponse<ToolTemplateApplicable> InsertToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> response = new BaseEntityResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTemplateID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.TemplateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCentreWiseSessionID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CentreWiseSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsApplicableForEntranceExam", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.IsApplicableForEntranceExam));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFromDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, Convert.ToDateTime(item.FromDate)));
                    if (item.ToDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daToDate", SqlDbType.DateTime, 0,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, Convert.ToDateTime(item.ToDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daToDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, DBNull.Value));
                    }
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daToDate", SqlDbType.DateTime, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.ToDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.IsActive));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_ToolTemplateApplicable_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of ToolTemplateApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> UpdateToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> response = new BaseEntityResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTemplateID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TemplateID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFromDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, Convert.ToDateTime(item.FromDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daToDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, Convert.ToDateTime(item.ToDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsActive));
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
                        throw new Exception("Stored Procedure 'dbo.USP_ToolTemplateApplicable_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of ToolTemplateApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> DeleteToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> response = new BaseEntityResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_Delete";
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_ToolTemplateApplicable_Delete' reported the ErrorCode: " +
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
        /// Select all record from ToolTemplateApplicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetToolTemplateApplicableBySearchBranchDetails(ToolTemplateApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ToolTemplateApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_ToolTemplateApplicable_BranchDetailsList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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
                    baseEntityCollection.CollectionResponse = new List<ToolTemplateApplicable>();
                    while (sqlDataReader.Read())
                    {
                        ToolTemplateApplicable item = new ToolTemplateApplicable();
                        // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["BranchDetID"]) == false)
                        {
                            item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchDescription"]) == false)
                        {
                            item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DivisionDescription"]) == false)
                        {
                            item.DivisionDescription = sqlDataReader["DivisionDescription"].ToString();
                        }
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
                        throw new Exception("Stored Procedure 'USP_ToolTemplateApplicable_BranchDetailsList' reported the ErrorCode: " + _errorCode);
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

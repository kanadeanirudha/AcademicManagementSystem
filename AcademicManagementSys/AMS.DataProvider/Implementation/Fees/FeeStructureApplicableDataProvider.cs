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
    public class FeeStructureApplicableDataProvider : DBInteractionBase, IFeeStructureApplicableDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FeeStructureApplicableDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FeeStructureApplicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FeeStructureApplicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureApplicableBySearch(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeCriteriaMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureApplicable>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureApplicable item = new FeeStructureApplicable();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureSessionMasterID"]) == false)
                        {
                            item.FeeStructureSessionMasterID = Convert.ToInt32(sqlDataReader["FeeStructureSessionMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalFeeAmount"]) == false)
                        {
                            item.TotalFeeAmount = Convert.ToDecimal(sqlDataReader["TotalFeeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsInstallmentApplicable"]) == false)
                        {
                            item.IsInstallmentApplicable = Convert.ToBoolean(sqlDataReader["IsInstallmentApplicable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationDescription"]) == false)
                        {
                            item.FeeCriteriaValueCombinationDescription = Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader[""]) == false)
                        //{

                        //}
                        //if (DBNull.Value.Equals(sqlDataReader[""]) == false)
                        //{

                        //}
                        //if (DBNull.Value.Equals(sqlDataReader[""]) == false)
                        //{
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// 
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetStudentListAccordingToFeeStructure(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_StudentList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureApplicable>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureApplicable item = new FeeStructureApplicable();
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["studentcode"]) == false)
                        {
                            item.StudentCode = Convert.ToString(sqlDataReader["studentcode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchDescription"]) == false)
                        {
                            item.BranchName = Convert.ToString(sqlDataReader["BranchDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Descriptions"]) == false)
                        {
                            item.SectionName = Convert.ToString(sqlDataReader["Descriptions"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        item.StartRow = searchRequest.StartRow;
                        item.EndRow = searchRequest.EndRow;
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FeeStructureApplicable> GetFeeStructureApplicableByID(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> response = new BaseEntityResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_SelectOne";
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
                        FeeStructureApplicable _item = new FeeStructureApplicable();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);

                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();

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
        public IBaseEntityResponse<FeeStructureApplicable> InsertFeeStructureApplicable(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> response = new BaseEntityResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureSessionMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureSessionMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsInstallmentApplicable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsInstallmentApplicable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smAccBalsheetID", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccBalsheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApplicableFromDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableFromDate));
                    if (!string.IsNullOrEmpty(item.XMLstring))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xInstallmentApplicableDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xInstallmentApplicableDetails", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode > 0)
                    {
                        item.ErrorCode = (Int32)_errorCode;
                    }                   
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureApplicable_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of FeeStructureApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureApplicable> UpdateFeeStructureApplicable(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> response = new BaseEntityResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableToDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureApplicable_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of FeeStructureApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureApplicable> DeleteFeeStructureApplicable(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> response = new BaseEntityResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureApplicable_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureApplicable_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureCriteriaApprovalList(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStrucrureApplicable_GetRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureApplicable>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureApplicable item = new FeeStructureApplicable();
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeReceivableVoucherStructureID"]) == false)
                        {
                            item.FeeReceivableVoucherStructureID = Convert.ToInt32(sqlDataReader["FeeReceivableVoucherStructureID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountType"]) == false)
                        {
                            item.AccountType = sqlDataReader["AccountType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Amount"]) == false)
                        {
                            item.Amount = Convert.ToDecimal(sqlDataReader["Amount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CrDrStatus"]) == false)
                        {
                            item.CrDrStatus = Convert.ToBoolean(sqlDataReader["CrDrStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubTypeMasterID"]) == false)
                        {
                            item.SubTypeMasterID = Convert.ToInt32(sqlDataReader["SubTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeDesc = sqlDataReader["FeeSubTypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubShortDesc"]) == false)
                        {
                            item.FeeSubShortDesc = sqlDataReader["FeeSubShortDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Source"]) == false)
                        {
                            item.Source = Convert.ToInt16(sqlDataReader["Source"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.FeeStructureApplicableHistoryID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentID"]) == false)
                        {
                            item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdmitAcademicYear"]) == false)
                        {
                            item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName = sqlDataReader["StudentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SectionDescription"]) == false)
                        {
                            item.SectionDescription = sqlDataReader["SectionDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdmissionPattern"]) == false)
                        {
                            item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoFileHeight"]) == false)
                        {
                            item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoFilename"]) == false)
                        {
                            item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoFileSize"]) == false)
                        {
                            item.StudentPhotoFileSize = sqlDataReader["StudentPhotoFileSize"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoFileWidth"]) == false)
                        {
                            item.StudentPhotoFileWidth = sqlDataReader["StudentPhotoFileWidth"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhotoType"]) == false)
                        {
                            item.StudentPhotoType = sqlDataReader["StudentPhotoType"].ToString();
                        }


                        if (DBNull.Value.Equals(sqlDataReader["AccountSessionId"]) == false)
                        {
                            item.AccountSessionID = Convert.ToInt32(sqlDataReader["AccountSessionId"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AdmissionDetailID"]) == false)
                        //{
                        //    item.AdmissionDetailID = Convert.ToInt32(sqlDataReader["AdmissionDetailID"]);
                        //}

                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.AccBalanceSheetID = Convert.ToInt32(sqlDataReader["BalanceSheetID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["FeeStructureDetailsID"]) == false)
                        //{
                        //    item.FeeStructureDetailsID = Convert.ToInt32(sqlDataReader["FeeStructureDetailsID"]);
                        //}                        
                        //if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeAmount"]) == false)
                        //{
                        //    item.FeeSubTypeAmount = Convert.ToDecimal(sqlDataReader["FeeSubTypeAmount"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStrucrureApplicable_GetRequestForApproval' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<FeeStructureApplicable> CreateFeeStructureRequestApproval(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> response = new BaseEntityResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureRequestApproval_CreateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));

                    if (!string.IsNullOrEmpty(item.FeeApprovalXmlstring))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xFeeApprovalXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeApprovalXmlstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xFeeApprovalXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccBalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountSessionID", SqlDbType.SmallInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureApplicableHistoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureApplicableHistoryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bRequestApprovalStatus", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RequestApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLastRecord));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentID));

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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureRequestApproval_CreateXML' reported the ErrorCode: " + _errorCode);
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

        //for fee structure not applicable student list
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureNotApplicableStudentList(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeestructureNotApplicable_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureApplicable>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureApplicable item = new FeeStructureApplicable();
                        if (DBNull.Value.Equals(sqlDataReader["studentName"]) == false)
                        {
                            item.StudentName = Convert.ToString(sqlDataReader["studentName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYear"]) == false)
                        {
                            item.AddmissionYear = Convert.ToString(sqlDataReader["AcademicYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdmitAcademicYear"]) == false)
                        {
                            item.AdmitAcademicYear = Convert.ToString(sqlDataReader["AdmitAcademicYear"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDesc"]) == false)
                        {
                            item.CourseYearDesc = Convert.ToString(sqlDataReader["CourseYearDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StandardDescription"]) == false)
                        {
                            item.StandardDescription = Convert.ToString(sqlDataReader["StandardDescription"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStrucrureApplicable_GetRequestForApproval' reported the ErrorCode: " + _errorCode);
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

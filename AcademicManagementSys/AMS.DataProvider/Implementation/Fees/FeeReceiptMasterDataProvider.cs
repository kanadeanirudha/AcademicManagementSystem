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
    public class FeeReceiptMasterDataProvider : DBInteractionBase, IFeeReceiptMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FeeReceiptMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FeeReceiptMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FeeReceiptMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetFeeReceiptMasterBySearch(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<FeeReceiptMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeReceiptMaster item = new FeeReceiptMaster();
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
                        throw new Exception("Stored Procedure 'USP_FeeReceiptMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetAccountListForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_GetAccountList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsChashOrBankFlag", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.IsChashOrBankFlag));
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
                    baseEntityCollection.CollectionResponse = new List<FeeReceiptMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeReceiptMaster item = new FeeReceiptMaster();
                        item.AccountName = sqlDataReader["AccountName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountName"]);
                        item.AccountID = sqlDataReader["AccountID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_FeeReceiptMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FeeReceiptMaster> GetFeeReceiptMasterByID(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> response = new BaseEntityResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_SelectOne";
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
                        FeeReceiptMaster _item = new FeeReceiptMaster();
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
        public IBaseEntityResponse<FeeReceiptMaster> InsertFeeReceiptMaster(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> response = new BaseEntityResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccountID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccBalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLumpsum", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLumpsum));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNextFeeReceivableDueListDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NextFeeReceivableDueListDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smAccSessionId", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccSessionId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mReceiptAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ReceiptAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiReceiptType", SqlDbType.TinyInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ReceiptType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeBankName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,string.IsNullOrEmpty(item.FeeBankName) ? string.Empty :item.FeeBankName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBranchName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.BranchName) ? string.Empty :item.BranchName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBranchCity", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.BranchCity) ? string.Empty : item.BranchCity));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeChequeOrDDNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.FeeChequeOrDDNumber) ? string.Empty : item.FeeChequeOrDDNumber));
                    if (!string.IsNullOrEmpty(item.FeeChequeOrDDDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daFeeChequeOrDDDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeChequeOrDDDate));    
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daFeeChequeOrDDDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));    
                    }
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIschequeORDD", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IschequeORDD));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mLateFeeAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,string.IsNullOrEmpty(item.LateFeeAmount) ? "0" :item.LateFeeAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLstring));
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
                        throw new Exception("Stored Procedure 'dbo.USP_FeeReceiptMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of FeeReceiptMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeReceiptMaster> UpdateFeeReceiptMaster(FeeReceiptMaster item)
        {
            IBaseEntityResponse<FeeReceiptMaster> response = new BaseEntityResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_Update";
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
                        throw new Exception("Stored Procedure 'dbo.USP_FeeReceiptMaster_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentPaymentDetails(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_GetStudentPaymentDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StudentID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeReceiptMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeReceiptMaster item = new FeeReceiptMaster();
                        item.FeeStructureMasterID = sqlDataReader["FeeStructureMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                        item.FeeCriteriaValueCombinationMasterID = sqlDataReader["FeeCriteriaValueCombinationMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
                        item.FeeCriteriaValueCombinationDescription = sqlDataReader["FeeCriteriaValueCombinationDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        item.FeeStructureDetailsIDORFeeStructureInstallmentMasterID = sqlDataReader["FeeStructureDetailsIDORFeeStructureInstallmentMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeStructureDetailsIDORFeeStructureInstallmentMasterID"]);
                        item.InstallmentAmount = sqlDataReader["InstallmentAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["InstallmentAmount"]);
                        item.FeeSubTypeID = sqlDataReader["FeeSubTypeID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeSubTypeID"]);
                        item.FeeSubTypeAmount = sqlDataReader["FeeSubTypeAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FeeSubTypeAmount"]);
                        item.FeeSubTypeDesc = sqlDataReader["FeeSubTypeDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        item.FeeSubShortDesc = sqlDataReader["FeeSubShortDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeSubShortDesc"]);
                        item.AccountID = sqlDataReader["AccountID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountID"]);
                        item.FeeReceivableDueListMasterID = sqlDataReader["FeeReceivableDueListMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeReceivableDueListMasterID"]);
                        item.FeeReceivableDueListDetailsID = sqlDataReader["FeeReceivableDueListDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeReceivableDueListDetailsID"]);
                        item.FeeReceivableDueListFeeTypeDetailsID = sqlDataReader["FeeReceivableDueListFeeTypeDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeReceivableDueListFeeTypeDetailsID"]);                        
                        item.PersonType = sqlDataReader["PersonType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PersonType"]);
                        item.PersonID = sqlDataReader["PersonID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.AccSessionId = sqlDataReader["AccSessionId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccSessionId"]);
                        item.FeeReceivableStatus = sqlDataReader["FeeReceivableStatus"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["FeeReceivableStatus"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.FeeStructureInstallmentMasterID = sqlDataReader["FeeStructureInstallmentMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeStructureInstallmentMasterID"]);
                        item.FeeReceivedDueAmount = sqlDataReader["FeeReceivedDueAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FeeReceivedDueAmount"]);
                        item.InstallmentNumber = sqlDataReader["InstallmentNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["InstallmentNumber"]);
                        item.IsLumpsum = sqlDataReader["IsLumpsum"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsLumpsum"]);
                        item.ReceivedAmount = sqlDataReader["ReceivedAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ReceivedAmount"]);
                        item.ScholarShipOrDiscountAmount = sqlDataReader["DiscountOrScholarShipAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["DiscountOrScholarShipAmount"]);
                        
                        
                        //item.ScholarShipAllocationID = sqlDataReader["ScholarShipAllocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ScholarShipAllocationID"]);
                        //item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        //item.ScholarShipMasterID = sqlDataReader["ScholarShipMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ScholarShipMasterID"]);
                        //item.TransDate = sqlDataReader["TransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransDate"]);
                        //item.ScholarSheepDocumentNumber = sqlDataReader["ScholarSheepDocumentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ScholarSheepDocumentNumber"]);
                        //item.IsLastRecord = sqlDataReader["IsLastRecord"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsLastRecord"]);
                        //item.IsApproved = sqlDataReader["IsApproved"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsApproved"]);
                        //item.ApporvedBy = sqlDataReader["ApporvedBy"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ApporvedBy"]);
                        //item.ApproveStatus = sqlDataReader["ApproveStatus"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ApproveStatus"]);
                        //item.LastSectionDetailID = sqlDataReader["LastSectionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["LastSectionDetailID"]);
                        //item.ScholarShipTransactionDetailsID = sqlDataReader["ScholarShipTransactionDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ScholarShipTransactionDetailsID"]);
                        //item.StudentAmissionDetailID = sqlDataReader["StudentAmissionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentAmissionDetailID"]);
                        //item.SectionDetailId = sqlDataReader["SectionDetailId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SectionDetailId"]);
                        //item.ScholarShipOrDiscountAmount = sqlDataReader["ScholarShipOrDiscountAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["ScholarShipOrDiscountAmount"]);
                        //item.AcadCenterwiseSessionId = sqlDataReader["AcadCenterwiseSessionId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcadCenterwiseSessionId"]);
                        //item.StandarNumber = sqlDataReader["StandarNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StandarNumber"]);
                        //item.ScholarShipDescription = sqlDataReader["ScholarShipDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ScholarShipDescription"]);
                        //item.IsScholarShipApplicable = sqlDataReader["IsScholarShipApplicable"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsScholarShipApplicable"]); 
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

        public IBaseEntityCollectionResponse<FeeReceiptMaster> GetStudentDetailsForFeeReceipt(FeeReceiptMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeReceiptMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeReceiptMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_StudentDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));

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
                    baseEntityCollection.CollectionResponse = new List<FeeReceiptMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeReceiptMaster item = new FeeReceiptMaster();
                        item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        //item.StudentAmissionDetailID = sqlDataReader["StudentAmissionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentAmissionDetailID"]);
                        item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);
                        //item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        //item.BranchID = sqlDataReader["BranchID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.AdmissionPatternID = sqlDataReader["AdmissionPatternID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AdmissionPatternID"]);
                        //.CourseYearId = sqlDataReader["CourseYearId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        item.EnrollmentNumber = sqlDataReader["EnrollmentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EnrollmentNumber"]);
                        item.StandardNumber = sqlDataReader["StandardNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        //item.SectionDetailID = sqlDataReader["SectionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //item.OldSectionDetailID = sqlDataReader["OldSectionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmitAcademicYear"]);
                        item.StudentEmailID = sqlDataReader["StudentEmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentEmailID"]);
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileHeight"]);
                        item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFilename"]);                   
                        item.StudentPhotoFileWidth = sqlDataReader["StudentPhotoFileWidth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileWidth"]);
                        item.StudentPhotoType = sqlDataReader["StudentPhotoType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoType"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        item.BranchShortCode = sqlDataReader["BranchShortCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchShortCode"]);
                        item.AdmissionPattern = sqlDataReader["AdmissionPattern"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmissionPattern"]);
                        item.CourseYearDesc = sqlDataReader["CourseYearDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CourseYearDesc"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CourseYearCode"]);
                        item.SectionDetailsDesc = sqlDataReader["SectionDetailsDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SectionDetailsDesc"]);
                        item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]);
                        item.FeeStructureMasterID = sqlDataReader["FeeStructureID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeStructureID"]); 
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

        #endregion
    }
}

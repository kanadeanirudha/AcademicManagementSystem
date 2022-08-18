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
    public class FeeStructureMasterAndDetailsDataProvider : DBInteractionBase, IFeeStructureMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FeeStructureMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FeeStructureMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FeeStructureMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsBySearch(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeCriteriaMasterID));
                   
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt16(sqlDataReader["FeeStructureMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationDescription"]) == false)
                        {
                            item.FeeCriteriaCombinationName = Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalFeeAmount"]) == false)
                        {
                            item.TotalFeeAmount = Convert.ToDecimal(sqlDataReader["TotalFeeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfInstallment"]) == false)
                        {
                            item.NumberOfInstallment = Convert.ToInt16(sqlDataReader["NumberOfInstallment"]);
                        }
                        

                        if (DBNull.Value.Equals(sqlDataReader["IsRevised"]) == false)
                        {
                            item.IsRevised = Convert.ToBoolean(sqlDataReader["IsRevised"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StatusFlag"]) == false)
                        {
                            item.StatusFlag = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationMasterID"]) == false)
                        {
                            item.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from FeeStructureMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeSubType_SearchList";
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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["ID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        //{
                        //    item.FeeSubTypeDesc = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from FeeStructureMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureDetails(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_GetFeeStructureDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeStructureMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();

                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationDescription"]) == false)
                        {
                            item.FeeCriteriaCombinationName = Convert.ToString(sqlDataReader["FeeCriteriaValueCombinationDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeName = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeAmount"]) == false)
                        {
                            item.FeeSubTypeAmount = Convert.ToDecimal(sqlDataReader["FeeSubTypeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalFeeAmount"]) == false)
                        {
                            item.TotalFeeAmount = Convert.ToDecimal(sqlDataReader["TotalFeeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfInstallment"]) == false)
                        {
                            item.NumberOfInstallment = Convert.ToInt16(sqlDataReader["NumberOfInstallment"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsRevised"]) == false)
                        {
                            item.IsRevised = Convert.ToBoolean(sqlDataReader["IsRevised"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsInstallmentApplicable"]) == false)
                        {
                            item.IsInstallmentApplicable = Convert.ToBoolean(sqlDataReader["IsInstallmentApplicable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationMasterID"]) == false)
                        {
                            item.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicableFromDate"]) == false)
                        {
                            item.FeeStructureApplicableFromDate = Convert.ToString(sqlDataReader["ApplicableFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureSessionMasterID"]) == false)
                        {
                            item.FeeStructureSessionMasterID = Convert.ToInt32(sqlDataReader["FeeStructureSessionMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from FeeStructureMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureInstallmentList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_GetInstallmentDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalsheetMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeStructureMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureInstallmentMasterID"]) == false)
                        {
                            item.FeeStructureInstallmentMasterID = Convert.ToInt32(sqlDataReader["FeeStructureInstallmentMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeInstallmentNumber"]) == false)
                        {
                            item.FeeInstallmentNumber = Convert.ToInt16(sqlDataReader["FeeInstallmentNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeInstallmentAmount"]) == false)
                        {
                            item.FeeInstallmentAmount = Convert.ToDecimal(sqlDataReader["FeeInstallmentAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureSessionInstallmentDetailsID"]) == false)
                        {
                            item.FeeStructureSessionInstallmentDetailsID = Convert.ToInt32(sqlDataReader["FeeStructureSessionInstallmentDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InstallmentFromDate"]) == false)
                        {
                            item.InstallmentFromDate = Convert.ToString(sqlDataReader["InstallmentFromDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InstallmentToDate"]) == false)
                        {
                            item.InstallmentToDate = Convert.ToString(sqlDataReader["InstallmentToDate"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByID(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> response = new BaseEntityResponse<FeeStructureMasterAndDetails>();
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
                    //if (item.IsFeeTypeTransaction == true)
                    //{
                    //    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_SelectOne";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //}
                    //else
                    //{
                    //    cmdToExecute.CommandText = "dbo.USP_FeeSubTypeMaster_SelectOne";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //}

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
                        FeeStructureMasterAndDetails _item = new FeeStructureMasterAndDetails();
                        //if (item.IsFeeTypeTransaction == true)
                        //{
                        //    if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //    {
                        //        _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeTypeDesc"]) == false)
                        //    {
                        //        _item.FeeTypeDesc = sqlDataReader["FeeTypeDesc"].ToString();
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeTypeCode"]) == false)
                        //    {
                        //        _item.FeeTypeCode = sqlDataReader["FeeTypeCode"].ToString();
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        //    {
                        //        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        //    }
                        //}
                        //else
                        //{
                        //    if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //    {
                        //        _item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["ID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeTypeMasterID"]) == false)
                        //    {
                        //        _item.ID = Convert.ToInt16(sqlDataReader["FeeTypeMasterID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        //    {
                        //        _item.FeeSubTypeDesc = sqlDataReader["FeeSubTypeDesc"].ToString();
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeSubShortDesc"]) == false)
                        //    {
                        //        _item.FeeSubShortDesc = sqlDataReader["FeeSubShortDesc"].ToString();
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        //    {
                        //        _item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["SubTypeIdentification"]) == false)
                        //    {
                        //        _item.SubTypeIdentification = Convert.ToString(sqlDataReader["SubTypeIdentification"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["ConsiderFeeTypeID"]) == false)
                        //    {
                        //        _item.ConsiderFeeTypeID = Convert.ToInt32(sqlDataReader["ConsiderFeeTypeID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["CarryForwardFeeSubtypeID"]) == false)
                        //    {
                        //        _item.CarryForwardFeeSubtypeID = Convert.ToString(sqlDataReader["CarryForwardFeeSubtypeID"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["CarryForwardAcctEffects"]) == false)
                        //    {
                        //        _item.CarryForwardAcctEffects = Convert.ToString(sqlDataReader["CarryForwardAcctEffects"]);
                        //    }
                        //    if (DBNull.Value.Equals(sqlDataReader["FeeSource"]) == false)
                        //    {
                        //        _item.FeeSource = Convert.ToString(sqlDataReader["FeeSource"]);
                        //    }
                        //}
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
        public IBaseEntityResponse<FeeStructureMasterAndDetails> InsertFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> response = new BaseEntityResponse<FeeStructureMasterAndDetails>();
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

                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalFeeAmount", SqlDbType.Money, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalFeeAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeCriteriaValueCombinationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeCriteriaValueCombinationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siNumberOfInstallment", SqlDbType.SmallInt, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.NumberOfInstallment));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsInstallmentApplicable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsInstallmentApplicable));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeAccountSubTypeMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FeeAccountSubTypeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAccountType", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountIDForFeeAccountSubTypeMaster", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AccountIDForFeeAccountSubTypeMaster));


                    cmdToExecute.Parameters.Add(new SqlParameter("@bCrDrStatusForFeeAccountSubTypeMaster", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CrDrStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xFeeStructureDetailsIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLFeeStructureDetailsIDs));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xFeeStructureInstallmentMasterIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLFeeStructureInstallmentMasterIDs != null ? item.XMLFeeStructureInstallmentMasterIDs : ""));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xFeeStructureDetailsInstallmentWiseIDs", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLFeeStructureDetailsInstallmentWiseIDs != null ? item.XMLFeeStructureDetailsInstallmentWiseIDs : ""));
                            
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
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
                        item.FeeStructureMasterID = (Int32)cmdToExecute.Parameters["@iFeeStructureMasterID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage ="Create failed"
                    //    });
                    //}
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
        /// Update a specific record of FeeStructureMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> UpdateFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> response = new BaseEntityResponse<FeeStructureMasterAndDetails>();
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
                    //if (item.IsFeeTypeTransaction == true)
                    //{
                    //    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeDesc));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeCode));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //}
                    //else
                    //{
                    //    cmdToExecute.CommandText = "dbo.USP_FeeSubTypeMaster_Update";
                    //    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siFeeTypeMasterID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubTypeDesc));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubShortDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubShortDesc));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siAccountID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubTypeIdentification));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iConsiderFeeTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ConsiderFeeTypeID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siCarryForwardFeeSubtypeID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CarryForwardFeeSubtypeID));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@cCarryForwardAcctEffects", SqlDbType.Char, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CarryForwardAcctEffects));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSource));
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //}

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
                 //   item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of FeeStructureMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeStructureMasterAndDetails> DeleteFeeStructureMasterAndDetails(FeeStructureMasterAndDetails item)
        {
            IBaseEntityResponse<FeeStructureMasterAndDetails> response = new BaseEntityResponse<FeeStructureMasterAndDetails>();
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

                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'dbo.USP_FeeStructureMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage ="Create failed"
                    //    });
                    //}
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

        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeStructureMasterAndDetailsByFeeStructureMasterID(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeStructureMasterAndDetails_ByFeeStructureMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeStructureMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["FeeStructureMasterID"]) == false)
                        {
                            item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalFeeAmount"]) == false)
                        {
                            item.TotalFeeAmount = Convert.ToDecimal(sqlDataReader["TotalFeeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeCriteriaValueCombinationMasterID"]) == false)
                        {
                            item.FeeCriteriaValueCombinationMasterID = Convert.ToInt32(sqlDataReader["FeeCriteriaValueCombinationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NumberOfInstallment"]) == false)
                        {
                            item.NumberOfInstallment = Convert.ToInt16(sqlDataReader["NumberOfInstallment"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsInstallmentApplicable"]) == false)
                        {
                            item.IsInstallmentApplicable = Convert.ToBoolean(sqlDataReader["IsInstallmentApplicable"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeID"]) == false)
                        {
                            item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["FeeSubTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeName = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeAmount"]) == false)
                        {
                            item.FeeSubTypeAmount = Convert.ToDecimal(sqlDataReader["FeeSubTypeAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InstallmentAmount"]) == false)
                        {
                            item.InstallmentAmount = Convert.ToString(sqlDataReader["InstallmentAmount"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeStructureMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //Search List For Fee Account.
        public IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> GetFeeAccountTypeAndSubTypeList(FeeStructureMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeStructureMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeAccountTypeAndSubTypeMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiFeeAccountTypeCode", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.FeeAccountTypeCode));

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
                    baseEntityCollection.CollectionResponse = new List<FeeStructureMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        FeeStructureMasterAndDetails item = new FeeStructureMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["FeeAccountTypeMasterID"]) == false)
                        {
                            item.FeeAccountTypeMasterID = Convert.ToInt32(sqlDataReader["FeeAccountTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeAccountSubTypeMasterID"]) == false)
                        {
                            item.FeeAccountSubTypeMasterID = Convert.ToInt32(sqlDataReader["FeeAccountSubTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeAccountSubTypeDesc"]) == false)
                        {
                            item.FeeAccountSubTypeDesc = sqlDataReader["FeeAccountSubTypeDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeAccountTypeAndSubTypeMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

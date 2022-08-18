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
    public class FishLicenseRuleMasterDataProvider : DBInteractionBase, IFishLicenseRuleMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FishLicenseRuleMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FishLicenseRuleMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FishLicenseRuleMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishLicenseRuleMaster> GetFishLicenseRuleMasterBySearch(FishLicenseRuleMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FishLicenseRuleMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FishLicenseRuleMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_FishLicenseRuleMaster_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iLicenseTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LicenseTypeID));

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
					baseEntityCollection.CollectionResponse = new List<FishLicenseRuleMaster>();
					while (sqlDataReader.Read())
					{
						FishLicenseRuleMaster item = new FishLicenseRuleMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LicenseTypeID"]) == false)
                        {
                            item.LicenseTypeID = Convert.ToInt32(sqlDataReader["LicenseTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RuleName"]) == false)
                        {
                            item.RuleName = sqlDataReader["RuleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RuleCode"]) == false)
                        {
                            item.RuleCode = sqlDataReader["RuleCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Percentage"]) == false)
                        {
                            item.Percentage = Convert.ToDecimal(sqlDataReader["Percentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IncreaseDecreaseFlag"]) == false)
                        {
                            item.IncreaseDecreaseFlag = sqlDataReader["IncreaseDecreaseFlag"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicableFromDate"]) == false)
                        {
                            item.ApplicableFromDate = sqlDataReader["ApplicableFromDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApplicableUptoDate"]) == false)
                        {
                            item.ApplicableUptoDate = sqlDataReader["ApplicableUptoDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAplicableToAllCentre"]) == false)
                        {
                            item.IsAplicableToAllCentre = Convert.ToBoolean(sqlDataReader["IsAplicableToAllCentre"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsDeleted"]) == false)
                        {
                            item.IsDeleted = Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedBy"]) == false)
                        {
                            item.CreatedBy = Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CreatedDate"]) == false)
                        {
                            item.CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedBy"]) == false)
                        {
                            item.ModifiedBy = Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ModifiedDate"]) == false)
                        {
                            item.ModifiedDate = Convert.ToDateTime(sqlDataReader["ModifiedDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LicenseFeeAmount"]) == false)
                        {
                            item.LicenseFeeAmount = Convert.ToDecimal(sqlDataReader["LicenseFeeAmount"]);
                        }

                        
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_FishLicenseRuleMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FishLicenseRuleMaster> InsertFishLicenseRuleMaster(FishLicenseRuleMaster item)
		{
			IBaseEntityResponse<FishLicenseRuleMaster> response = new BaseEntityResponse<FishLicenseRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishLicenseRuleMaster_INSERTXML";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10, ParameterDirection.Input,false,0,0,"", DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iLicenseTypeID", SqlDbType.Int,10, ParameterDirection.Input,false,0,0,"", DataRowVersion.Proposed, item.LicenseTypeID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsRuleName", SqlDbType.NVarChar,50, ParameterDirection.Input,false,10,0,"", DataRowVersion.Proposed, item.RuleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRuleCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApplicableFromDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableFromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApplicableUptoDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableUptoDate)); 
					cmdToExecute.Parameters.Add(new SqlParameter("@dPercentage", SqlDbType.Decimal,0, ParameterDirection.Input,false,0,0,"", DataRowVersion.Proposed, item.Percentage));
					cmdToExecute.Parameters.Add(new SqlParameter("@cIncreaseDecreaseFlag", SqlDbType.Char,1, ParameterDirection.Input,false,10,0,"", DataRowVersion.Proposed, item.IncreaseDecreaseFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAplicableToAllCentre", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAplicableToAllCentre));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSelectedCentreCodes", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SelectedCentreCodes.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mLicenseFeeAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LicenseFeeAmount));
                   
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 10, ParameterDirection.Input, true, 10, 0,"",	DataRowVersion.Proposed, item.CreatedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0,"", DataRowVersion.Proposed, _errorCode));
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
						throw new Exception("Stored Procedure 'dbo.USP_FishLicenseRuleMaster_INSERT' reported the ErrorCode: " + 
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
							ErrorMessage ="Create failed"
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
        /// Delete a specific record of FishLicenseRuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> DeleteFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> response = new BaseEntityResponse<FishLicenseRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishLicenseRuleMaster_Delete"; cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLicenseTypeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.LicenseTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAplicableToAllCentre", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAplicableToAllCentre));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
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
                        throw new Exception("Stored Procedure 'dbo.USP_FishLicenseRuleMaster_Delete' reported the ErrorCode: " +
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
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> GetFishLicenseRuleMasterByID(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> response = new BaseEntityResponse<FishLicenseRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishLicenseRuleMaster_SelectOne";
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
                        FishLicenseRuleMaster _item = new FishLicenseRuleMaster();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.LicenseTypeID = Convert.ToInt32(sqlDataReader["LicenseTypeID"]);
                        _item.RuleName = sqlDataReader["RuleName"].ToString();
                        _item.RuleCode = sqlDataReader["RuleCode"].ToString();
                        _item.Percentage = Convert.ToDecimal(sqlDataReader["Percentage"]);
                        _item.IncreaseDecreaseFlag = sqlDataReader["IncreaseDecreaseFlag"].ToString();

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
        /// Update a specific record of FishLicenseRuleMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishLicenseRuleMaster> UpdateFishLicenseRuleMaster(FishLicenseRuleMaster item)
        {
            IBaseEntityResponse<FishLicenseRuleMaster> response = new BaseEntityResponse<FishLicenseRuleMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishLicenseRuleMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLicenseTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LicenseTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRuleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRuleCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RuleCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.Percentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cIncreaseDecreaseFlag", SqlDbType.Char, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IncreaseDecreaseFlag));

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
                        throw new Exception("Stored Procedure 'dbo.USP_FishLicenseRuleMaster_Delete' reported the ErrorCode: " +
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

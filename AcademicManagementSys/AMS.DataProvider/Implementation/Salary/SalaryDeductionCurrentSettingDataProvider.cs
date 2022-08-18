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
	public class SalaryDeductionCurrentSettingDataProvider : DBInteractionBase,ISalaryDeductionCurrentSettingDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public SalaryDeductionCurrentSettingDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public SalaryDeductionCurrentSettingDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from SalaryDeductionCurrentSetting table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting>GetSalaryDeductionCurrentSettingBySearch(SalaryDeductionCurrentSettingSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionCurrentSetting>();
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
					cmdToExecute.CommandText = "dbo.USP_SalaryDeductionCurrentSetting_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
					baseEntityCollection.CollectionResponse = new List<SalaryDeductionCurrentSetting>();
					while (sqlDataReader.Read())
					{
						SalaryDeductionCurrentSetting item = new SalaryDeductionCurrentSetting();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.SalaryDeductionMasterID = sqlDataReader["SalaryDeductionMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["SalaryDeductionMasterID"]);
                        item.DeductionHeadName = sqlDataReader["DeductionHeadName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeductionHeadName"]);
                        item.FixAmount = sqlDataReader["FixAmount"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["FixAmount"]), 2);
                        item.Percentage = sqlDataReader["Percentage"] is DBNull ? new Decimal() : Convert.ToDecimal(sqlDataReader["Percentage"]);
                        item.MapAccountID = sqlDataReader["MapAccountID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["MapAccountID"]);
                        item.AccountName = sqlDataReader["AccountName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountName"]);
                        item.CalculateOn = sqlDataReader["CalculateOn"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["CalculateOn"]);

				
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_SalaryDeductionCurrentSetting_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<SalaryDeductionCurrentSetting>GetSalaryDeductionCurrentSettingByID(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> response = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
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
					cmdToExecute.CommandText = "dbo.USP_SalaryDeductionCurrentSetting_SelectOne";
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
						SalaryDeductionCurrentSetting _item = new SalaryDeductionCurrentSetting();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.SalaryDeductionMasterID = Convert.ToInt32(sqlDataReader["SalaryDeductionMasterID"]);
                        _item.FixAmount = Math.Round(Convert.ToDecimal(sqlDataReader["FixAmount"]), 2);
                        _item.Percentage = Math.Round(Convert.ToDecimal(sqlDataReader["Percentage"]), 2);
                        _item.MapAccountID = Convert.ToInt16(sqlDataReader["MapAccountID"]);
                        _item.CalculateOn = Convert.ToInt16(sqlDataReader["CalculateOn"]);
					
						

						response.Entity = _item;
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
					{
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'SalaryDeductionCurrentSetting' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> InsertSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> response = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
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
					cmdToExecute.CommandText = "dbo.USP_SalaryDeductionCurrentSetting_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalaryDeductionMasterID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.SalaryDeductionMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFixAmount", SqlDbType.Money, 19,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.FixAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPercentage ", SqlDbType.Decimal, 18,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.Percentage));
               
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMapAccountID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.MapAccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCalculateOn", SqlDbType.TinyInt, 3,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.CalculateOn));
					
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.CreatedBy));
					
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_SalaryDeductionCurrentSetting_INSERT' reported the ErrorCode: " + 
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
		/// Update a specific record of SalaryDeductionCurrentSetting
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> UpdateSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> response = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			SqlCommand cmdToExecute = new SqlCommand();
			try
			{
				if (string.IsNullOrEmpty(item.ConnectionString))
				{
					response.Message.Add(new MessageDTO()
					{
						ErrorMessage ="Connection string is empty.",
						MessageType = MessageTypeEnum.Error
					});
				}
				else
				{
					_mainConnection.ConnectionString = item.ConnectionString;
					cmdToExecute.Connection = _mainConnection;
					cmdToExecute.CommandText ="dbo.USP_SalaryDeductionCurrentSetting_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSalaryDeductionMasterID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SalaryDeductionMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mFixAmount", SqlDbType.Money, 19,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.FixAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dPercentage", SqlDbType.Decimal, 18,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Percentage));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMapAccountID", SqlDbType.Int, 5,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.MapAccountID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCalculateOn", SqlDbType.TinyInt, 3,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.CalculateOn));

						cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.ModifiedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_SalaryDeductionCurrentSetting_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of SalaryDeductionCurrentSetting
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> response = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			SqlCommand cmdToExecute = new SqlCommand();
			try
			{
				if (string.IsNullOrEmpty(item.ConnectionString))
				{
					response.Message.Add(new MessageDTO()
					{
						ErrorMessage ="Connection string is empty.",
						MessageType = MessageTypeEnum.Error
					});
				}
				else
				{
					_mainConnection.ConnectionString = item.ConnectionString;
					cmdToExecute.Connection = _mainConnection;
					cmdToExecute.CommandText ="dbo.USP_SalaryDeductionCurrentSetting_Delete";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
											ParameterDirection.Input, false, 0, 0,"",
											DataRowVersion.Proposed, 0));
					cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
											ParameterDirection.Input, false, 0, 0,"",
											DataRowVersion.Proposed, 1));
					cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
											DataRowVersion.Proposed, item.DeletedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
											ParameterDirection.Output, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_SalaryDeductionCurrentSetting_Delete' reported the ErrorCode: " + 
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
        /// Select all record from SalaryDeductionCurrentSetting table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetAllowanceHeadNameList(SalaryDeductionCurrentSettingSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> baseEntityCollection = new BaseEntityCollectionResponse<SalaryDeductionCurrentSetting>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryDeductionCurrentSetting_ListForDropDown";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //-----------------------------------------------------Input Parameters ------------------------------------------------------------------
                    //scmdToExecute.Parameters.Add(new SqlParameter("@iStatusFlag", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StatusFlag));

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

                    baseEntityCollection.CollectionResponse = new List<SalaryDeductionCurrentSetting>();
                    while (sqlDataReader.Read())
                    {
                        SalaryDeductionCurrentSetting item = new SalaryDeductionCurrentSetting();
                        if (DBNull.Value.Equals(sqlDataReader["DeductionHeadName"]) == false)
                        {
                            item.DeductionHeadName = Convert.ToString(sqlDataReader["DeductionHeadName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        //{
                        //    item.MenuLink = Convert.ToString(sqlDataReader["MenuLink"]);
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
                        throw new Exception("Stored Procedure 'USP_SalaryDeductionCurrentSetting_SelectAll' reported the ErrorCode: " + _errorCode);
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

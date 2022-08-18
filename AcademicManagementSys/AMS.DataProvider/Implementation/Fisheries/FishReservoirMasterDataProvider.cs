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
    public class FishReservoirMasterDataProvider : DBInteractionBase, IFishReservoirMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FishReservoirMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FishReservoirMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FishReservoirMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishReservoirMaster> GetFishReservoirMasterBySearch(FishReservoirMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FishReservoirMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FishReservoirMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_FishReservoirMaster_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalsheetMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, searchRequest.BalancesheetID));
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
					baseEntityCollection.CollectionResponse = new List<FishReservoirMaster>();
					while (sqlDataReader.Read())
					{
						FishReservoirMaster item = new FishReservoirMaster();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.ReservoirName = sqlDataReader["ReservoirName"].ToString();
						item.ReservoirCode = sqlDataReader["ReservoirCode"].ToString();
						item.Address = sqlDataReader["Address"].ToString();
						item.LocationId = Convert.ToInt32(sqlDataReader["LocationId"]);
                        item.Latitude = Convert.ToDecimal(sqlDataReader["Latitude"]);
                        item.Logitude = Convert.ToDecimal(sqlDataReader["Logitude"]);
                        item.Area = Convert.ToDecimal(sqlDataReader["Area"]);
                        item.Capacity = Convert.ToDecimal(sqlDataReader["Capacity"]);
                        item.MinProductCapacity = Convert.ToDecimal(sqlDataReader["MinProductCapacity"]);
                        //item.BalancesheetId = Convert.ToInt32(sqlDataReader["BalancesheetId"]);
                       // item.BalancesheetName = sqlDataReader["BalancesheetName"].ToString();
                        
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_FishReservoirMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FishReservoirMaster> GetFishReservoirMasterByID(FishReservoirMaster item)
		{
			IBaseEntityResponse<FishReservoirMaster> response = new BaseEntityResponse<FishReservoirMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_FishReservoirMaster_SelectOne";
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
						FishReservoirMaster _item = new FishReservoirMaster();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.ReservoirName = sqlDataReader["ReservoirName"].ToString();
                        _item.ReservoirCode = sqlDataReader["ReservoirCode"].ToString();
                        _item.Address = sqlDataReader["Address"].ToString();
                        _item.LocationId = Convert.ToInt32(sqlDataReader["LocationId"]);
                        _item.Latitude = Convert.ToDecimal(sqlDataReader["Latitude"]);
                        _item.Logitude = Convert.ToDecimal(sqlDataReader["Logitude"]);
                        _item.Area = Convert.ToDecimal(sqlDataReader["Area"]);
                        _item.Capacity = Convert.ToDecimal(sqlDataReader["Capacity"]);
                        _item.MinProductCapacity = Convert.ToDecimal(sqlDataReader["MinProductCapacity"]);
                        //_item.BalancesheetId = Convert.ToInt32(sqlDataReader["BalancesheetId"]);
                       // _item.BalancesheetName = sqlDataReader["BalancesheetName"].ToString();


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
        public IBaseEntityResponse<FishReservoirMaster> InsertFishReservoirMaster(FishReservoirMaster item)
		{
			IBaseEntityResponse<FishReservoirMaster> response = new BaseEntityResponse<FishReservoirMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_FishReservoirMaster_INSERT";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
				    cmdToExecute.Parameters.Add(new SqlParameter("@sID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsReservoirName", SqlDbType.NVarChar,0,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.ReservoirName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsReservoirCode", SqlDbType.NVarChar,0,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.ReservoirCode.Trim()));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar,0,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetId", SqlDbType.Int, 10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(item.Latitude)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Logitude", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(item.Logitude)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Area", SqlDbType.Float,0,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.Area));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Capacity", SqlDbType.Decimal, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(item.Capacity)));
					cmdToExecute.Parameters.Add(new SqlParameter("@MinProductCapacity", SqlDbType.Decimal,0,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, Convert.ToDecimal(item.MinProductCapacity)));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.CreatedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));
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
                        item.ID = (Int32)cmdToExecute.Parameters["@sID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
					
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_FishReservoirMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of FishReservoirMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> UpdateFishReservoirMaster(FishReservoirMaster item)
		{
			IBaseEntityResponse<FishReservoirMaster> response = new BaseEntityResponse<FishReservoirMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_FishReservoirMaster_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,4,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsReservoirName", SqlDbType.NVarChar,40,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.ReservoirName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar,200,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.Address));
					cmdToExecute.Parameters.Add(new SqlParameter("@iLocationId", SqlDbType.Int,4,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.LocationId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetId", SqlDbType.Int, 4,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.BalancesheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsReservoirCode", SqlDbType.NVarChar,0,
                    //                    ParameterDirection.Input,false,10,0,"",
                    //                    DataRowVersion.Proposed, item.ReservoirCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Latitude", SqlDbType.Decimal,8,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Latitude));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Logitude", SqlDbType.Decimal,8,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Logitude));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Area", SqlDbType.Float,53,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Area));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@Capacity", SqlDbType.Decimal,8,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.Capacity));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@MinProductCapacity", SqlDbType.Decimal,8,
                    //                    ParameterDirection.Input,false,0,0,"",
                    //                    DataRowVersion.Proposed, item.MinProductCapacity));

					
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

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FishReservoirMaster_INSERT' reported the ErrorCode: " + _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
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
        /// Delete a specific record of FishReservoirMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishReservoirMaster> DeleteFishReservoirMaster(FishReservoirMaster item)
        {
            IBaseEntityResponse<FishReservoirMaster> response = new BaseEntityResponse<FishReservoirMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishReservoirMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, 1));
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
                   // item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FishReservoirMaster_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
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
        #endregion
    }
}

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
    public class FeeTypeAndSubTypeDataProvider : DBInteractionBase, IFeeTypeAndSubTypeDataProvider
    {
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public FeeTypeAndSubTypeDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public FeeTypeAndSubTypeDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from FeeTypeAndSubType table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<FeeTypeAndSubType>     GetFeeTypeAndSubTypeBySearch(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeTypeAndSubType_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<FeeTypeAndSubType>();
					while (sqlDataReader.Read())
					{
						FeeTypeAndSubType item = new FeeTypeAndSubType();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeTypeDesc"]) == false)
                        {
                            item.FeeTypeDesc =Convert.ToString(sqlDataReader["FeeTypeDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeTypeCode"]) == false)
                        {
                            item.FeeTypeCode = Convert.ToString(sqlDataReader["FeeTypeCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeID"]) == false)
                        {
                            item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["FeeSubTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeDesc = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubShortDesc"]) == false)
                        {
                            item.FeeSubShortDesc = Convert.ToString(sqlDataReader["FeeSubShortDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"]) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                        {
                            item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubTypeIdentification"]) == false)
                        {
                            switch (Convert.ToByte(sqlDataReader["SubTypeIdentification"]))
                            {
                                case 1:
                                    item.SubTypeIdentification = "Other";
                                    break;
                                case 2:
                                    item.SubTypeIdentification = "Advanced";
                                    break;
                                case 3:
                                    item.SubTypeIdentification = "Outstanding";
                                    break;
                                default:
                                    item.SubTypeIdentification = string.Empty;
                                    break;
                            }
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSource"]) == false)
                        {
                            switch(Convert.ToByte(sqlDataReader["FeeSource"]))
                            {
                                case 1:
                                    item.FeeSource = "Student";
                                    break;
                                case 2:
                                    item.FeeSource = "Government";
                                    break;
                                default:
                                    item.FeeSource =string.Empty ;
                                    break;
                            }
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_FeeTypeAndSubType_SelectAll' reported the ErrorCode: " + _errorCode);
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
		/// Select all record from FeeTypeAndSubType table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeList(FeeTypeAndSubTypeSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
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
					baseEntityCollection.CollectionResponse = new List<FeeTypeAndSubType>();
					while (sqlDataReader.Read())
					{
						FeeTypeAndSubType item = new FeeTypeAndSubType();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeDesc = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_FeeTypeAndSubType_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<FeeTypeAndSubType> GetFeeTypeAndSubTypeByID(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> response = new BaseEntityResponse<FeeTypeAndSubType>();
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
                    if (item.IsFeeTypeTransaction == true)
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_SelectOne";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeSubTypeMaster_SelectOne";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }

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
                        FeeTypeAndSubType _item = new FeeTypeAndSubType();
                        if (item.IsFeeTypeTransaction == true)
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeTypeDesc"]) == false)
                            {
                                _item.FeeTypeDesc = sqlDataReader["FeeTypeDesc"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeTypeCode"]) == false)
                            {
                                _item.FeeTypeCode = sqlDataReader["FeeTypeCode"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            {
                                _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                            }
                        }
                        else
                        {
                            if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            {
                                _item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["ID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeTypeMasterID"]) == false)
                            {
                                _item.ID = Convert.ToInt16(sqlDataReader["FeeTypeMasterID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                            {
                                _item.FeeSubTypeDesc = sqlDataReader["FeeSubTypeDesc"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeSubShortDesc"]) == false)
                            {
                                _item.FeeSubShortDesc = sqlDataReader["FeeSubShortDesc"].ToString();
                            }
                            if (DBNull.Value.Equals(sqlDataReader["AccountID"]) == false)
                            {
                                _item.AccountID = Convert.ToInt32(sqlDataReader["AccountID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["SubTypeIdentification"]) == false)
                            {
                                _item.SubTypeIdentification = Convert.ToString(sqlDataReader["SubTypeIdentification"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["ConsiderFeeTypeID"]) == false)
                            {
                                _item.ConsiderFeeTypeID = Convert.ToInt32(sqlDataReader["ConsiderFeeTypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CarryForwardFeeSubtypeID"]) == false)
                            {
                                _item.CarryForwardFeeSubtypeID = Convert.ToString(sqlDataReader["CarryForwardFeeSubtypeID"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["CarryForwardAcctEffects"]) == false)
                            {
                                _item.CarryForwardAcctEffects = Convert.ToString(sqlDataReader["CarryForwardAcctEffects"]);
                            }
                            if (DBNull.Value.Equals(sqlDataReader["FeeSource"]) == false)
                            {
                                _item.FeeSource = Convert.ToString(sqlDataReader["FeeSource"]); 
                            }
                        }
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
		public IBaseEntityResponse<FeeTypeAndSubType> InsertFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> response = new BaseEntityResponse<FeeTypeAndSubType>();
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
                    if (item.IsFeeTypeTransaction == true)
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_Insert";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeDesc", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));                        
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeSubTypeMaster_Insert";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siFeeTypeMasterID", SqlDbType.SmallInt, 5,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubTypeDesc", SqlDbType.NVarChar, 60,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.FeeSubTypeDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubShortDesc", SqlDbType.NVarChar, 10,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.FeeSubShortDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siAccountID", SqlDbType.SmallInt, 5,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AccountID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiSubTypeIdentification", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubTypeIdentification));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCarryForwardFeeSubtypeID", SqlDbType.SmallInt, 5,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed,Convert.ToInt16(item.CarryForwardFeeSubtypeID) ));
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiFeeSource", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSource));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                    }

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
                        item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_FeeTypeAndSubType_INSERT' reported the ErrorCode: " + _errorCode);
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
		/// Update a specific record of FeeTypeAndSubType
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> UpdateFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> response = new BaseEntityResponse<FeeTypeAndSubType>();
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
                    if (item.IsFeeTypeTransaction == true)
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_Update";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeSubTypeMaster_Update";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siFeeTypeMasterID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubTypeDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeSubShortDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeSubShortDesc));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siAccountID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccountID));
                        cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubTypeIdentification));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iConsiderFeeTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ConsiderFeeTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@siCarryForwardFeeSubtypeID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CarryForwardFeeSubtypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@cCarryForwardAcctEffects", SqlDbType.Char, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CarryForwardAcctEffects));
                        cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeSource));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    }

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
                    item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
					_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_FeeTypeAndSubType_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of FeeTypeAndSubType
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeTypeAndSubType> DeleteFeeTypeAndSubType(FeeTypeAndSubType item)
		{
			IBaseEntityResponse<FeeTypeAndSubType> response = new BaseEntityResponse<FeeTypeAndSubType>();
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
                    if (item.IsFeeTypeTransaction == true)
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeType_Delete";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));                        
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_FeeSubType_Delete";
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FeeSubTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,item.DeletedBy));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));   
                    }
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
						throw new Exception("Stored Procedure 'dbo.USP_FeeTypeAndSubType_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<FeeTypeAndSubType> GetFeeSubTypeSearchList(FeeTypeAndSubTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeTypeAndSubType> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeTypeAndSubType>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeSubType_SearchListUsingLike";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<FeeTypeAndSubType>();
                    while (sqlDataReader.Read())
                    {
                        FeeTypeAndSubType item = new FeeTypeAndSubType();
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeID"]) == false)
                        {
                            item.FeeSubTypeID = Convert.ToInt16(sqlDataReader["FeeSubTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubTypeDesc"]) == false)
                        {
                            item.FeeSubTypeDesc = Convert.ToString(sqlDataReader["FeeSubTypeDesc"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FeeSubShortDesc"]) == false)
                        {
                            item.FeeSubShortDesc = Convert.ToString(sqlDataReader["FeeSubShortDesc"]);
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
                        throw new Exception("Stored Procedure 'USP_FeeTypeAndSubType_SelectAll' reported the ErrorCode: " + _errorCode);
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

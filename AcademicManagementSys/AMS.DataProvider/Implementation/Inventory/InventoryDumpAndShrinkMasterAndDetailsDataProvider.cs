using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public class InventoryDumpAndShrinkMasterAndDetailsDataProvider : DBInteractionBase, IInventoryDumpAndShrinkMasterAndDetailsDataProvider
    {
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public InventoryDumpAndShrinkMasterAndDetailsDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public InventoryDumpAndShrinkMasterAndDetailsDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>     GetInventoryDumpAndShrinkMasterAndDetailsBySearch(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrinkMasterAndDetails_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,Convert.ToInt16(searchRequest.BalancesheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.LocationID));
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
					baseEntityCollection.CollectionResponse = new List<InventoryDumpAndShrinkMasterAndDetails>();
					while (sqlDataReader.Read())
					{
						InventoryDumpAndShrinkMasterAndDetails item = new InventoryDumpAndShrinkMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpAndShrinkAmount"]) == false)
                        {
                            item.DumpAndShrinkAmount = Convert.ToDecimal(sqlDataReader["DumpAndShrinkAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt16(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt16(sqlDataReader["BalanceSheetID"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_InventoryDumpAndShrinkMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkDetails(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrinkMasterAndDetails_GetDumpAndShrinkDetails";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
					baseEntityCollection.CollectionResponse = new List<InventoryDumpAndShrinkMasterAndDetails>();
					while (sqlDataReader.Read())
					{
						InventoryDumpAndShrinkMasterAndDetails item = new InventoryDumpAndShrinkMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpQuantity"]) == false)
                        {
                            item.DumpQuantity = Convert.ToDecimal(sqlDataReader["DumpQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShrinkQuantity"]) == false)
                        {
                            item.ShrinkQuantity = Convert.ToDecimal(sqlDataReader["ShrinkQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovedStatus"]) == false)
                        {
                            item.ApprovedStatus = Convert.ToBoolean(sqlDataReader["ApprovedStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovedDumpQty"]) == false)
                        {
                            item.ApprovedDumpQty = Convert.ToDecimal(sqlDataReader["ApprovedDumpQty"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ApprovedShrinkQty"]) == false)
                        {
                            item.ApprovedShrinkQty = Convert.ToDecimal(sqlDataReader["ApprovedShrinkQty"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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
		/// Select all record from InventoryDumpAndShrinkMasterAndDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> GetDumpAndShrinkRequestForApproval(InventoryDumpAndShrinkMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrinkMaster_GetRequestForApproval";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));                 
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
					baseEntityCollection.CollectionResponse = new List<InventoryDumpAndShrinkMasterAndDetails>();
					while (sqlDataReader.Read())
					{
						InventoryDumpAndShrinkMasterAndDetails item = new InventoryDumpAndShrinkMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpAndShrinkDetailsID"]) == false)
                        {
                            item.DumpAndShrinkDetailID = Convert.ToInt32(sqlDataReader["DumpAndShrinkDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BalanceSheetID"]) == false)
                        {
                            item.BalanceSheetID = Convert.ToInt32(sqlDataReader["BalanceSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocationID"]) == false)
                        {
                            item.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpQuantity"]) == false)
                        {
                            item.DumpQuantity = Convert.ToDecimal(sqlDataReader["DumpQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShrinkQuantity"]) == false)
                        {
                            item.ShrinkQuantity = Convert.ToDecimal(sqlDataReader["ShrinkQuantity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DumpAndShrinkAmount"]) == false)
                        {
                            item.DumpAndShrinkAmount = Convert.ToDecimal(sqlDataReader["DumpAndShrinkAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySale_SelectBillDetails' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> GetInventoryDumpAndShrinkMasterAndDetailsByID(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        InventoryDumpAndShrinkMasterAndDetails _item = new InventoryDumpAndShrinkMasterAndDetails();
                       
                            //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                            //{
                            //    _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                            //}
                            //if (DBNull.Value.Equals(sqlDataReader["FeeTypeDesc"]) == false)
                            //{
                            //    _item.FeeTypeDesc = sqlDataReader["FeeTypeDesc"].ToString();
                            //}
                            //if (DBNull.Value.Equals(sqlDataReader["FeeTypeCode"]) == false)
                            //{
                            //    _item.FeeTypeCode = sqlDataReader["FeeTypeCode"].ToString();
                            //}
                            //if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                            //{
                            //    _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
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
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrinkMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mDumpAndShrinkAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DumpAndShrinkAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xDumpAndShrinkDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, 0));
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
                    //item.ID = (int)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_rowsAffected > 0)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                        item.ErrorCode = (Int32)_errorCode;
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                        response.Entity = item;
                    }

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_InventoryDumpAndShrinkMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
                    _onlineDbConnection.Close(); 
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
        public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> InsertApprovedDumpAndShrinkRecord(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDumpAndShrinkMaster_InsertApprovedRecord";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToByte(item.IsLastRecord)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToInt16(item.BalanceSheetID)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtApprovedDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xDumpAndShrinkDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTaskCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.Status)); 
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
                        item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_InventoryDumpAndShrinkMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
                    _onlineDbConnection.Close(); 
				}
                cmdToExecute.Dispose();
			}
			return response;
		}        
		/// <summary>
		/// Update a specific record of InventoryDumpAndShrinkMasterAndDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> UpdateInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeTypeMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeDesc", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeDesc));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFeeTypeCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FeeTypeCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive));
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
                    item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
					_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_InventoryDumpAndShrinkMasterAndDetails_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of InventoryDumpAndShrinkMasterAndDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> DeleteInventoryDumpAndShrinkMasterAndDetails(InventoryDumpAndShrinkMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails> response = new BaseEntityResponse<InventoryDumpAndShrinkMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeType_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
						throw new Exception("Stored Procedure 'dbo.USP_InventoryDumpAndShrinkMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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
		#endregion
    }
}

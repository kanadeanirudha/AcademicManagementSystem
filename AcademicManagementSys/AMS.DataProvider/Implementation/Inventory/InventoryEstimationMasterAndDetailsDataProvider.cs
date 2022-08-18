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
    public class InventoryEstimationMasterAndDetailsDataProvider : DBInteractionBase, IInventoryEstimationMasterAndDetailsDataProvider
    {
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public InventoryEstimationMasterAndDetailsDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public InventoryEstimationMasterAndDetailsDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from InventoryEstimationMasterAndDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails>GetInventoryEstimationMasterAndDetailsBySearch(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryEstimationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryEstimationMasterAndDetails_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalancesheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt16(searchRequest.AccBalancesheetID)));
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
					baseEntityCollection.CollectionResponse = new List<InventoryEstimationMasterAndDetails>();
					while (sqlDataReader.Read())
					{
						InventoryEstimationMasterAndDetails item = new InventoryEstimationMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt16(sqlDataReader["ID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EstimationAmount"]) == false)
                        {
                            item.EstimationAmount = Convert.ToDecimal(sqlDataReader["EstimationAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerAddress"]) == false)
                        {
                            item.CustomerAddress = Convert.ToString(sqlDataReader["CustomerAddress"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerMobileNumber"]) == false)
                        {
                            item.CustomerMobileNumber = Convert.ToString(sqlDataReader["CustomerMobileNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPendingForBill"]) == false)
                        {
                            item.IsPendingForBill = Convert.ToBoolean(sqlDataReader["IsPendingForBill"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_InventoryEstimationMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
		/// Select all record from InventoryEstimationMasterAndDetails table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> GetInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryEstimationMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryEstimationMasterAndDetails>();
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
                    if (searchRequest.IsAllocateToLocation == false)
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryEstimationMasterAndDetails_GetDetailList";
                    }
                    else
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryEstimationAllocationMaster_GetDetailList";
                    }
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalsheetMstID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalancesheetID));
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
					baseEntityCollection.CollectionResponse = new List<InventoryEstimationMasterAndDetails>();
					while (sqlDataReader.Read())
					{
						InventoryEstimationMasterAndDetails item = new InventoryEstimationMasterAndDetails();
                        if (DBNull.Value.Equals(sqlDataReader["ItemName"]) == false)
                        {
                            item.ItemName = Convert.ToString(sqlDataReader["ItemName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"]) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ShortCode"]) == false)
                        {
                            item.UnitCode = Convert.ToString(sqlDataReader["ShortCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Rate"]) == false)
                        {
                            item.Rate = Convert.ToDecimal(sqlDataReader["Rate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Quantity"]) == false)
                        {
                            item.Quantity = Convert.ToDecimal(sqlDataReader["Quantity"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ItemID"]) == false)
                        {
                            item.ItemID = Convert.ToInt32(sqlDataReader["ItemID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerName"]) == false)
                        {
                            item.CustomerName = Convert.ToString(sqlDataReader["CustomerName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerAddress"]) == false)
                        {
                            item.CustomerAddress = Convert.ToString(sqlDataReader["CustomerAddress"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CustomerMobileNumber"]) == false)
                        {
                            item.CustomerMobileNumber = Convert.ToString(sqlDataReader["CustomerMobileNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EstimationAmount"]) == false)
                        {
                            item.EstimationAmount = Convert.ToDecimal(sqlDataReader["EstimationAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GrossAmount"]) == false)
                        {
                            item.GrossAmount = Convert.ToDecimal(sqlDataReader["GrossAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalTaxAmount"]) == false)
                        {
                            item.TotalTaxAmount = Convert.ToDecimal(sqlDataReader["TotalTaxAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalDiscountAmount"]) == false)
                        {
                            item.TotalDiscountAmount = Convert.ToDecimal(sqlDataReader["TotalDiscountAmount"]);
                        }
                        if (searchRequest.IsAllocateToLocation == true)
                        {
                             item.IsActive = Convert.ToBoolean(sqlDataReader["StatusFlag"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CurrencyCode"]) == false)
                        {
                            item.CurrencyCode = Convert.ToString(sqlDataReader["CurrencyCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine1"]) == false)
                        {
                            item.PrintingLine1 = Convert.ToString(sqlDataReader["PrintingLine1"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine2"]) == false)
                        {
                            item.PrintingLine2 = Convert.ToString(sqlDataReader["PrintingLine2"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine3"]) == false)
                        {
                            item.PrintingLine3 = Convert.ToString(sqlDataReader["PrintingLine3"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PrintingLine4"]) == false)
                        {
                            item.PrintingLine4 = Convert.ToString(sqlDataReader["PrintingLine4"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DiscountAmount"]) == false)
                        {
                            item.DiscountAmountForItem = Convert.ToDecimal(sqlDataReader["DiscountAmount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TaxAmount"]) == false)
                        {
                            item.TotalTaxForItem = Convert.ToDecimal(sqlDataReader["TaxAmount"]);
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
		/// Create new record of the table
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryEstimationMasterAndDetails_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBalanceSheetID", SqlDbType.SmallInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mEstimationAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EstimationAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCustomerID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerMobileNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerMobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CustomerAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.TotalDiscountAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xEstimationDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
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
                    item.ID = (int)cmdToExecute.Parameters["@iID"].Value;
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
						throw new Exception("Stored Procedure 'dbo.USP_InventoryEstimationMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<InventoryEstimationMasterAndDetails> InsertInventoryEstimationToLocation(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_InvEstimationAllocationMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(DateTime.UtcNow)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEstimationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xEstimationAllocationDetailsXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EstimateLocationWiseXMLstring));
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
                    item.ID = (int)cmdToExecute.Parameters["@iID"].Value;
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
						throw new Exception("Stored Procedure 'dbo.USP_InventoryEstimationMasterAndDetails_INSERT' reported the ErrorCode: " + _errorCode);
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
		/// Update a specific record of InventoryEstimationMasterAndDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> UpdateInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
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
						throw new Exception("Stored Procedure 'dbo.USP_InventoryEstimationMasterAndDetails_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of InventoryEstimationMasterAndDetails
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryEstimationMasterAndDetails> DeleteInventoryEstimationMasterAndDetails(InventoryEstimationMasterAndDetails item)
		{
			IBaseEntityResponse<InventoryEstimationMasterAndDetails> response = new BaseEntityResponse<InventoryEstimationMasterAndDetails>();
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
						throw new Exception("Stored Procedure 'dbo.USP_InventoryEstimationMasterAndDetails_Delete' reported the ErrorCode: " + _errorCode);
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

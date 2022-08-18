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
	public class OnlineExaminationMasterDataProvider : DBInteractionBase,IOnlineExaminationMasterDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public OnlineExaminationMasterDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public OnlineExaminationMasterDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from OnlineExaminationMaster table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OnlineExaminationMaster>GetOnlineExaminationMasterBySearch(OnlineExaminationMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OnlineExaminationMaster> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<OnlineExaminationMaster>();
					while (sqlDataReader.Read())
					{
						OnlineExaminationMaster item = new OnlineExaminationMaster();
						item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.ExaminationName = sqlDataReader["ExaminationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExaminationName"]);
                        item.Purpose = sqlDataReader["Purpose"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Purpose"]);
                        item.TotalMarks = sqlDataReader["TotalMarks"] is DBNull ? 0 : Convert.ToInt16(sqlDataReader["TotalMarks"]);
                        item.TotalQuestion = sqlDataReader["TotalQuestion"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["TotalQuestion"]);
                        item.TotalTime = sqlDataReader["TotalTime"] is DBNull? new Int16() : Convert.ToInt16(sqlDataReader["TotalTime"]);
                        item.TotalPaperSet = sqlDataReader["TotalPaperSet"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["TotalPaperSet"]);
						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_OnlineExaminationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        public IBaseEntityCollectionResponse<OnlineExaminationMaster> GetExaminationNameByCourseID(OnlineExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExaminationMaster> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExaminationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 10, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResults", SqlDbType.Int, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.MaxResults));


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
                    baseEntityCollection.CollectionResponse = new List<OnlineExaminationMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExaminationMaster item = new OnlineExaminationMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExaminationName = sqlDataReader["ExaminationName"].ToString();
                        }
                        //item.FeeCriteriaParametersDescription = sqlDataReader["FeeCriteriaParametersDescription"].ToString();


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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<OnlineExaminationMaster> GetOnlineExaminationMasterByID(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> response = new BaseEntityResponse<OnlineExaminationMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_OnlineExaminationMaster_SelectOne";
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
						OnlineExaminationMaster _item = new OnlineExaminationMaster();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.ExaminationName = sqlDataReader["ExaminationName"].ToString();
						_item.Purpose = sqlDataReader["Purpose"].ToString();
						_item.AcadSessionId = Convert.ToInt32(sqlDataReader["AcadSessionId"]);

						_item.TotalQuestion = Convert.ToInt16(sqlDataReader["TotalQuestion"]);

						_item.IsNegativeMarkingApplicable = Convert.ToBoolean(sqlDataReader["IsNegativeMarkingApplicable"]);


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
		public IBaseEntityResponse<OnlineExaminationMaster> InsertOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> response = new BaseEntityResponse<OnlineExaminationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_Insert";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //----------------------------OUTPUT PARAM----------------------------------
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,ParameterDirection.Output,false,0,0,"",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //----------------------------INPUT PARAM-----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExaminationName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ExaminationName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsPurpose", SqlDbType.NVarChar,100,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed,!string.IsNullOrEmpty(item.Purpose) ? item.Purpose :string.Empty));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAcadSessionId", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.AcadSessionId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tTotalTime", SqlDbType.TinyInt, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siTotalQuestion", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalQuestion));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dTotalMarks", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalMarks));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dMarksInEachQuestion", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.MarksInEachQuestion));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNegativeMarkingApplicable", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsNegativeMarkingApplicable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dNegativeMarksInEachQuestion", SqlDbType.Decimal, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NegativeMarksInEachQuestion));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalPaperSet", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalPaperSet));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xOnlineExamExaminationSubjectApplicable", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XMLString));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.CreatedBy));

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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
		/// Update a specific record of OnlineExaminationMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationMaster> UpdateOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> response = new BaseEntityResponse<OnlineExaminationMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_OnlineExaminationMaster_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsExaminationName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ExaminationName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsPurpose", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.Purpose));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAcadSessionId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AcadSessionId));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Time,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalTime));
					cmdToExecute.Parameters.Add(new SqlParameter("@siTotalQuestion", SqlDbType.SmallInt,5,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalQuestion));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Decimal,8,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalMarks));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Decimal,8,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.MarksInEachQuestion));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsNegativeMarkingApplicable", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.IsNegativeMarkingApplicable));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Decimal, 8,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.NegativeMarksInEachQuestion));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt,3,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TotalPaperSet));

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
						throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationMaster_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of OnlineExaminationMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OnlineExaminationMaster> DeleteOnlineExaminationMaster(OnlineExaminationMaster item)
		{
			IBaseEntityResponse<OnlineExaminationMaster> response = new BaseEntityResponse<OnlineExaminationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationMaster_DELETE";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0,"",DataRowVersion.Proposed, 1));
					cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0,"",DataRowVersion.Proposed, 1));
					cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, 1));
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
					item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
					_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_OnlineExaminationMaster_Delete' reported the ErrorCode: " + 
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
		#endregion
	}
}

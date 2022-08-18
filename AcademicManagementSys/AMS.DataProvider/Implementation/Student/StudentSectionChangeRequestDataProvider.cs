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
	public class StudentSectionChangeRequestDataProvider : DBInteractionBase,IStudentSectionChangeRequestDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public StudentSectionChangeRequestDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public StudentSectionChangeRequestDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from StudentSectionChangeRequest table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<StudentSectionChangeRequest>     GetStudentSectionChangeRequestBySearch(StudentSectionChangeRequestSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentSectionChangeRequest> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSectionChangeRequest>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentSectionChangeRequest_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
					baseEntityCollection.CollectionResponse = new List<StudentSectionChangeRequest>();
					while (sqlDataReader.Read())
					{
						StudentSectionChangeRequest item = new StudentSectionChangeRequest();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
						item.RequestSectionDetailId = Convert.ToInt32(sqlDataReader["RequestSectionDetailId"]);
						item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
						item.CentreCode = sqlDataReader["CentreCode"].ToString();
						item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
						item.StatusOfRequest = sqlDataReader["StatusOfRequest"].ToString();
						item.ApprovedEmployeeId = Convert.ToInt32(sqlDataReader["ApprovedEmployeeId"]);
						item.ApprovedDate = Convert.ToString(sqlDataReader["ApprovedDate"]);

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_StudentSectionChangeRequest_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<StudentSectionChangeRequest> GetStudentSectionChangeRequestByID(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> response = new BaseEntityResponse<StudentSectionChangeRequest>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentSectionChangeRequest_SelectOne";
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
						StudentSectionChangeRequest _item = new StudentSectionChangeRequest();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
						_item.RequestSectionDetailId = Convert.ToInt32(sqlDataReader["RequestSectionDetailId"]);
						_item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
						_item.CentreCode = sqlDataReader["CentreCode"].ToString();
						_item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
						_item.StatusOfRequest = sqlDataReader["StatusOfRequest"].ToString();
						_item.ApprovedEmployeeId = Convert.ToInt32(sqlDataReader["ApprovedEmployeeId"]);
                        _item.ApprovedDate = Convert.ToString(sqlDataReader["ApprovedDate"]);

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
		public IBaseEntityResponse<StudentSectionChangeRequest> InsertStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> response = new BaseEntityResponse<StudentSectionChangeRequest>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentSectionChangeRequest_Insert";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,ParameterDirection.Output,false,0,0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.StudentId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRequestSectionDetailId", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.RequestSectionDetailId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.SessionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,15,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.OldSectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStatusOfRequest", SqlDbType.VarChar,15,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.StatusOfRequest));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0,"",DataRowVersion.Proposed, item.CreatedBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0,"",DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStatusMessage", SqlDbType.VarChar, 50, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, string.Empty));
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
                    item.errorMessage = Convert.ToString(cmdToExecute.Parameters["@sStatusMessage"].Value);    
                     item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
					{
						
						throw new Exception("Stored Procedure 'dbo.USP_StudentSectionChangeRequest_INSERT' reported the ErrorCode: " + _errorCode);
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
		/// Update a specific record of StudentSectionChangeRequest
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> UpdateStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> response = new BaseEntityResponse<StudentSectionChangeRequest>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentSectionChangeRequest_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.StudentID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRequestSectionDetailId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.RequestSectionDetailId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SessionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.OldSectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStatusOfRequest", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StatusOfRequest));
					cmdToExecute.Parameters.Add(new SqlParameter("@iApprovedEmployeeId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ApprovedEmployeeId));
					cmdToExecute.Parameters.Add(new SqlParameter("@daApprovedDate", SqlDbType.DateTime,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ApprovedDate));

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
						throw new Exception("Stored Procedure 'dbo.USP_StudentSectionChangeRequest_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of StudentSectionChangeRequest
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentSectionChangeRequest> DeleteStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			IBaseEntityResponse<StudentSectionChangeRequest> response = new BaseEntityResponse<StudentSectionChangeRequest>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentSectionChangeRequest_Delete";
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
											DataRowVersion.Proposed, 1));
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
						throw new Exception("Stored Procedure 'dbo.USP_StudentSectionChangeRequest_Delete' reported the ErrorCode: " + 
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
		/// Select all record from StudentSectionChangeRequest table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetSectionList(StudentSectionChangeRequestSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentSectionChangeRequest> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSectionChangeRequest>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentRequest_GetSectionList";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
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
					baseEntityCollection.CollectionResponse = new List<StudentSectionChangeRequest>();
					while (sqlDataReader.Read())
					{
						StudentSectionChangeRequest item = new StudentSectionChangeRequest();
                        item.SectionID = Convert.ToInt32(sqlDataReader["SectionID"]);
                       // item.SectionDesc = Convert.ToString(sqlDataReader["SectionName"]);
                        item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        item.SectionDetailCode = Convert.ToString(sqlDataReader["SectionDetailCode"]);
                        item.SectionDesc = Convert.ToString(sqlDataReader["SectionDetailsDesc"]);
						baseEntityCollection.CollectionResponse.Add(item);
						
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_StudentSectionChangeRequest_SelectAll' reported the ErrorCode: " + _errorCode);
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

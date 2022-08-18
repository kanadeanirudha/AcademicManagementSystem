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
	public class GenerateStudentRollNumberDataProvider : DBInteractionBase,IGenerateStudentRollNumberDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public GenerateStudentRollNumberDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public GenerateStudentRollNumberDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from GenerateStudentRollNumber table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<GenerateStudentRollNumber>     GetGenerateStudentRollNumberBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<GenerateStudentRollNumber> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GenerateStudentRollNumber>();
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
                    // Use base class' connection object      USP_StudentList_ReadyforPromotion
					_mainConnection.ConnectionString = searchRequest.ConnectionString;
					cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_StudentList_ReadyforPromoWithAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input , true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StatusCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionStatus", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmissionStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID ));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (searchRequest.IsFirstYearPromotion== true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNextSectionDetailId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));    
                    }
                    else if (searchRequest.IsFirstYearPromotion == false)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iNextSectionDetailId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
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
					baseEntityCollection.CollectionResponse = new List<GenerateStudentRollNumber>();
					while (sqlDataReader.Read())
					{
						GenerateStudentRollNumber item = new GenerateStudentRollNumber();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName = sqlDataReader["StudentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearId"]) == false)
                        {
                            item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SectionDetailID"]) == false)
                        {
                            item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["YearlyRollNumber"]) == false)
                        {
                            item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentAdmissionDetailId"]) == false)
                        {
                            item.StudentAdmissionDetailId = Convert.ToInt32(sqlDataReader["StudentAdmissionDetailId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NextSectionDetailID"]) == false && sqlDataReader["NextSectionDetailID"].ToString()!="")
                        {
                            item.NextSectionDetailID = Convert.ToInt32(sqlDataReader["NextSectionDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NextSectionDescription"]) == false && sqlDataReader["NextSectionDescription"].ToString() != "")
                        {
                            item.NextSectionDescription = Convert.ToString(sqlDataReader["NextSectionDescription"]);
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
						
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    
                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_GenerateStudentRollNumber_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all student record  with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberStudentListBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GenerateStudentRollNumber> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GenerateStudentRollNumber>();
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
                    cmdToExecute.CommandText = "dbo.USP_GenerateStudentRollNumber_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<GenerateStudentRollNumber>();
                    while (sqlDataReader.Read())
                    {
                        GenerateStudentRollNumber item = new GenerateStudentRollNumber();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.FormNumber = sqlDataReader["FormNumber"].ToString();

                        item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);

                        item.AdmissionActiveFlag = Convert.ToBoolean(sqlDataReader["AdmissionActiveFlag"]);
                        item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
                        item.RollNoSortOrder = sqlDataReader["RollNoSortOrder"].ToString();
                        item.SortOrderStatus = sqlDataReader["SortOrderStatus"].ToString();

                        item.ResultStatus = sqlDataReader["ResultStatus"].ToString();
                        item.AdmissionCancelStatus = Convert.ToBoolean(sqlDataReader["AdmissionCancelStatus"]);
                        item.AdmissionStatus = sqlDataReader["AdmissionStatus"].ToString();

                        item.BranchId = Convert.ToInt32(sqlDataReader["BranchId"]);
                        item.PromotedToNextBranch = sqlDataReader["PromotedToNextBranch"].ToString();
                        item.StatusCode = sqlDataReader["StatusCode"].ToString();

                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.Remark = sqlDataReader["Remark"].ToString();
                        item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
                        item.PrevExamSeatNo = sqlDataReader["PrevExamSeatNo"].ToString();
                        item.EligibForCuryrAdmsn = sqlDataReader["EligibForCuryrAdmsn"].ToString();
                        item.ResultCurYear = sqlDataReader["ResultCurYear"].ToString();
                        item.DtndForSemester = sqlDataReader["DtndForSemester"].ToString();
                        item.SemesterSpecificAdmsn = sqlDataReader["SemesterSpecificAdmsn"].ToString();
                        item.StuRevalAppliId = Convert.ToInt32(sqlDataReader["StuRevalAppliId"]);
                        item.ProvisionalType = sqlDataReader["ProvisionalType"].ToString();
                        item.AdmissionFinalStatus = sqlDataReader["AdmissionFinalStatus"].ToString();
                        item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        item.IsLastRecord = Convert.ToBoolean(sqlDataReader["IsLastRecord"]);

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
                        throw new Exception("Stored Procedure 'USP_GenerateStudentRollNumber_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberByID(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> response = new BaseEntityResponse<GenerateStudentRollNumber>();
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
					cmdToExecute.CommandText = "dbo.USP_GenerateStudentRollNumber_SelectOne";
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
						GenerateStudentRollNumber _item = new GenerateStudentRollNumber();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
						_item.FormNumber = sqlDataReader["FormNumber"].ToString();
						
						_item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
						
						_item.AdmissionActiveFlag = Convert.ToBoolean(sqlDataReader["AdmissionActiveFlag"]);
						_item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
						_item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
						_item.RollNoSortOrder = sqlDataReader["RollNoSortOrder"].ToString();
						_item.SortOrderStatus = sqlDataReader["SortOrderStatus"].ToString();
						
						
						_item.ResultStatus = sqlDataReader["ResultStatus"].ToString();
						_item.AdmissionCancelStatus = Convert.ToBoolean(sqlDataReader["AdmissionCancelStatus"]);
						_item.AdmissionStatus = sqlDataReader["AdmissionStatus"].ToString();
						
						_item.BranchId = Convert.ToInt32(sqlDataReader["BranchId"]);
						_item.PromotedToNextBranch = sqlDataReader["PromotedToNextBranch"].ToString();
						_item.StatusCode = sqlDataReader["StatusCode"].ToString();
						
						
						_item.CentreCode = sqlDataReader["CentreCode"].ToString();
						_item.Remark = sqlDataReader["Remark"].ToString();
						_item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
						_item.PrevExamSeatNo = sqlDataReader["PrevExamSeatNo"].ToString();
						_item.EligibForCuryrAdmsn = sqlDataReader["EligibForCuryrAdmsn"].ToString();
						_item.ResultCurYear = sqlDataReader["ResultCurYear"].ToString();
						_item.DtndForSemester = sqlDataReader["DtndForSemester"].ToString();
						_item.SemesterSpecificAdmsn = sqlDataReader["SemesterSpecificAdmsn"].ToString();
						_item.StuRevalAppliId = Convert.ToInt32(sqlDataReader["StuRevalAppliId"]);
						_item.ProvisionalType = sqlDataReader["ProvisionalType"].ToString();
						_item.AdmissionFinalStatus = sqlDataReader["AdmissionFinalStatus"].ToString();
						_item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
						_item.IsLastRecord = Convert.ToBoolean(sqlDataReader["IsLastRecord"]);

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
		public IBaseEntityResponse<GenerateStudentRollNumber> InsertGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> response = new BaseEntityResponse<GenerateStudentRollNumber>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuSectionWisePromotion_Insert_XML";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIDs", SqlDbType.VarChar, 4000,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.PromotedStudentList));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,ParameterDirection.Input,false,10,0,"",DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.SessionID));
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
					item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
					_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_GenerateStudentRollNumber_INSERT' reported the ErrorCode: " + 
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
		/// Update a specific record of GenerateStudentRollNumber
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> UpdateGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> response = new BaseEntityResponse<GenerateStudentRollNumber>();
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
					cmdToExecute.CommandText ="dbo.USP_GenerateStudentRollNumber_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.StudentId));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsFormNumber", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.FormNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FormDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@bAdmissionActiveFlag", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionActiveFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAcademicYear", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AcademicYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsYearlyRollNumber", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.YearlyRollNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@cRollNoSortOrder", SqlDbType.Char,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.RollNoSortOrder));
					cmdToExecute.Parameters.Add(new SqlParameter("@cSortOrderStatus", SqlDbType.Char,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.SortOrderStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FromSession));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.UptoSession));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsResultStatus", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ResultStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@bAdmissionCancelStatus", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionCancelStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionCancelDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.BranchId));
					cmdToExecute.Parameters.Add(new SqlParameter("@cPromotedToNextBranch", SqlDbType.Char,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.PromotedToNextBranch));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StatusCode));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionConfirmDate));
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionPromoteDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.Remark));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAdmissionNumber", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsPrevExamSeatNo", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.PrevExamSeatNo));
					cmdToExecute.Parameters.Add(new SqlParameter("@sEligibForCuryrAdmsn", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.EligibForCuryrAdmsn));
					cmdToExecute.Parameters.Add(new SqlParameter("@sResultCurYear", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ResultCurYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@sDtndForSemester", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.DtndForSemester));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSemesterSpecificAdmsn", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.SemesterSpecificAdmsn));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStuRevalAppliId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.StuRevalAppliId));
					cmdToExecute.Parameters.Add(new SqlParameter("@sProvisionalType", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ProvisionalType));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionFinalStatus", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionFinalStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SessionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsLastRecord", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.IsLastRecord));

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
						throw new Exception("Stored Procedure 'dbo.USP_GenerateStudentRollNumber_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of GenerateStudentRollNumber
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<GenerateStudentRollNumber> DeleteGenerateStudentRollNumber(GenerateStudentRollNumber item)
		{
			IBaseEntityResponse<GenerateStudentRollNumber> response = new BaseEntityResponse<GenerateStudentRollNumber>();
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
					cmdToExecute.CommandText ="dbo.USP_GenerateStudentRollNumber_Delete";
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
						throw new Exception("Stored Procedure 'dbo.USP_GenerateStudentRollNumber_Delete' reported the ErrorCode: " + 
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

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
	public class StudentReadmissionDataProvider : DBInteractionBase,IStudentReadmissionDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public StudentReadmissionDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public StudentReadmissionDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
		/// <summary>
		/// Select all record from StudentReadmission table with search parameters
		/// </summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<StudentReadmission>  GetStudentReadmissionBySearch(StudentReadmissionSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<StudentReadmission> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReadmission>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentReadmission_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<StudentReadmission>();
					while (sqlDataReader.Read())
					{
						StudentReadmission item = new StudentReadmission();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
						item.FormNumber = sqlDataReader["FormNumber"].ToString();
						//Not
						item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
						//Not
						item.AdmissionActiveFlag = Convert.ToBoolean(sqlDataReader["AdmissionActiveFlag"]);
						item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
						item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
						item.RollNoSortOrder = sqlDataReader["RollNoSortOrder"].ToString();
						item.SortOrderStatus = sqlDataReader["SortOrderStatus"].ToString();
						//Not
						//Not
						item.ResultStatus = sqlDataReader["ResultStatus"].ToString();
						item.AdmissionCancelStatus = sqlDataReader["AdmissionCancelStatus"].ToString();
						item.AdmissionStatus = sqlDataReader["AdmissionStatus"].ToString();
						//Not
						item.BranchId = Convert.ToInt32(sqlDataReader["BranchId"]);
						item.PromotedToNextBranch = sqlDataReader["PromotedToNextBranch"].ToString();
						item.StatusCode = sqlDataReader["StatusCode"].ToString();
						//Not
						//Not
						item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
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

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_StudentReadmission_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<StudentReadmission> GetStudentReadmissionByID(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> response = new BaseEntityResponse<StudentReadmission>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentMaster_GetStudentDetails";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.searchType == "CurrentYearStudent")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentId));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));// for current year student
                    }
                    if (item.searchType == "BackYearStudent")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentId));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));// for back year student
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
						StudentReadmission _item = new StudentReadmission();
						//_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						//.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
						//_item.FormNumber = sqlDataReader["FormNumber"].ToString();
						
						//_item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
						
						//_item.AdmissionActiveFlag = Convert.ToBoolean(sqlDataReader["AdmissionActiveFlag"]);
						//_item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
						//_item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
						//_item.RollNoSortOrder = sqlDataReader["RollNoSortOrder"].ToString();
						//_item.SortOrderStatus = sqlDataReader["SortOrderStatus"].ToString();
						
						//_item.ResultStatus = sqlDataReader["ResultStatus"].ToString();
						//_item.AdmissionCancelStatus = sqlDataReader["AdmissionCancelStatus"].ToString();
						//_item.AdmissionStatus = sqlDataReader["AdmissionStatus"].ToString();
						
						//_item.BranchId = Convert.ToInt32(sqlDataReader["BranchId"]);
					//	_item.PromotedToNextBranch = sqlDataReader["PromotedToNextBranch"].ToString();
					//	_item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        // _item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        //_item.SectionDesc = sqlDataReader["SectionDesc"].ToString();
                        //_item.CourseYearDesc = sqlDataReader["CourseYearDes"].ToString();
                        //_item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);
                        //_item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
						//_item.Remark = sqlDataReader["Remark"].ToString();
                        //_item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
                        //_item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
					///	_item.PrevExamSeatNo = sqlDataReader["PrevExamSeatNo"].ToString();
					//	_item.EligibForCuryrAdmsn = sqlDataReader["EligibForCuryrAdmsn"].ToString();
					//	_item.ResultCurYear = sqlDataReader["ResultCurYear"].ToString();
				//		_item.DtndForSemester = sqlDataReader["DtndForSemester"].ToString();
				//		_item.SemesterSpecificAdmsn = sqlDataReader["SemesterSpecificAdmsn"].ToString();
				//		_item.StuRevalAppliId = Convert.ToInt32(sqlDataReader["StuRevalAppliId"]);
				//		_item.ProvisionalType = sqlDataReader["ProvisionalType"].ToString();
				//		_item.AdmissionFinalStatus = sqlDataReader["AdmissionFinalStatus"].ToString();

                       // _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        _item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                        _item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        _item.BranchId = Convert.ToInt32(sqlDataReader["OrginalBranchID"]);
                        _item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        _item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        _item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        _item.SectionDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        _item.CourseYearDesc = sqlDataReader["CourseYearDesc"].ToString();
                        _item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);
                        _item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        _item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        _item.AdmissionDate =Convert.ToString( sqlDataReader["AdmissionDate"]);
                        _item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        if (DBNull.Value.Equals(sqlDataReader["OldSectionDetailID"]) == false)
                        {
                            _item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);    
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearOldId"]) == false)
                        {
                            _item.CourseYearOldId = Convert.ToInt32(sqlDataReader["CourseYearOldId"]);     
                        }
                        _item.StuAdmissionDetailID = Convert.ToInt32(sqlDataReader["StuAdmissionDetailID"]);

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
		public IBaseEntityResponse<StudentReadmission> InsertStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> response = new BaseEntityResponse<StudentReadmission>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentReadmission_INSERT";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,ParameterDirection.Output,false,0,0,"",DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.StudentId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SessionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daAdmissionDate", SqlDbType.DateTime, 0,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.AdmissionDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,Convert.ToInt32(item.ActiveSessionFlag)));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchId", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.BranchId));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar,15,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAcademicYear", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AcademicYear));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCategoryMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_StudentReadmission_INSERT' reported the ErrorCode: " + 
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
		/// Update a specific record of StudentReadmission
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> UpdateStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> response = new BaseEntityResponse<StudentReadmission>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentReadmission_Update";
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
					cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FormDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
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
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FromSession));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.UptoSession));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsResultStatus", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ResultStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAdmissionCancelStatus", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionCancelStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
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
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionConfirmDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.DateTime, 0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionPromoteDate));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCentreCode", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_StudentReadmission_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of StudentReadmission
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentReadmission> DeleteStudentReadmission(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> response = new BaseEntityResponse<StudentReadmission>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentReadmission_Delete";
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
						throw new Exception("Stored Procedure 'dbo.USP_StudentReadmission_Delete' reported the ErrorCode: " + 
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
		/// Data Provider method for AuthoriseStudentSectionChangeRequest form
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentReadmission> InsertAuthoriseStudentSectionChangeRequest(StudentReadmission item)
		{
			IBaseEntityResponse<StudentReadmission> response = new BaseEntityResponse<StudentReadmission>();
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
					cmdToExecute.CommandText = "dbo.USP_AuthoriseStudentSectionChangeRequest_Insert";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

					
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.StudentId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,ParameterDirection.Input,false,0,0,"",DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStuAdmissionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StuAdmissionDetailID));
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
                    
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_AccountCategoryMaster_Insert' reported the ErrorCode: " +
                                            _errorCode);
                    }
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
						throw new Exception("Stored Procedure 'dbo.USP_StudentReadmission_INSERT' reported the ErrorCode: " + 
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

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
	public class StudentMasterDataProvider : DBInteractionBase,IStudentMasterDataProvider
	{
		#region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public StudentMasterDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public StudentMasterDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
		#region Method Implementation
        /// <summary>
        /// Select all record from StudentMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentMaster> GetStudentSearchList(StudentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    if (searchRequest.SearchType == "StudentReadmission")
                    {
                        //-------------------------------------------------------Parameters for Readmission Form Search List-------------------------------------------------------------------//
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode /* searchRequest.CentreCode*/));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResult", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.maxResult));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,Convert.ToInt32(searchRequest.ActiveSessionFlag)));// for back year student
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionStatus", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "C"));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Pursuing"));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCancelStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));//
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    }
                    if (searchRequest.SearchType == "AuthoriseStudentSectionChange")
                    {
                        //-------------------------------------------------------Parameters for Authorise Student Section Change Form Search List-------------------------------------------------------------------//
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode /* searchRequest.CentreCode*/));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResult", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.maxResult));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));// for current year student
                        cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionStatus", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "C"));
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Pursuing"));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCancelStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));// 
                        cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
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
                    baseEntityCollection.CollectionResponse = new List<StudentMaster>();
                    while (sqlDataReader.Read())
                    {
                        StudentMaster item = new StudentMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentName = sqlDataReader["StudentName"].ToString();
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearId"]) == false)
                        {
                            item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SectionDetailID"]) == false)
                        {
                            item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
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
                        throw new Exception("Stored Procedure 'USP_StudentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
		public IBaseEntityResponse<StudentMaster> GetStudentMasterByID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentMaster_SelectOne";
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
						StudentMaster _item = new StudentMaster();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.StudentCode = sqlDataReader["StudentCode"].ToString();
						_item.Title = sqlDataReader["Title"].ToString();
						_item.NickName = sqlDataReader["NickName"].ToString();
						_item.FirstName = sqlDataReader["FirstName"].ToString();
						_item.MiddleName = sqlDataReader["MiddleName"].ToString();
						_item.LastName = sqlDataReader["LastName"].ToString();
						_item.MotherName = sqlDataReader["MotherName"].ToString();
						_item.StudentOccupation = sqlDataReader["StudentOccupation"].ToString();
						_item.StudentMobileNumber = Convert.ToInt32(sqlDataReader["StudentMobileNumber"]);
						_item.ParentMobileNumber = Convert.ToInt32(sqlDataReader["ParentMobileNumber"]);
						_item.GuardianMobileNumber = Convert.ToInt32(sqlDataReader["GuardianMobileNumber"]);
						_item.ParentLandlineNumber = Convert.ToInt32(sqlDataReader["ParentLandlineNumber"]);
						_item.ParentEmailID = sqlDataReader["ParentEmailID"].ToString();
						_item.GuardianEmailID = sqlDataReader["GuardianEmailID"].ToString();
						_item.FatherEmailID = sqlDataReader["FatherEmailID"].ToString();
						_item.MotherEmailID = sqlDataReader["MotherEmailID"].ToString();
						_item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
						_item.NameAsPerLeaving = sqlDataReader["NameAsPerLeaving"].ToString();
						_item.LastSchoolCollegeAttend = sqlDataReader["LastSchoolCollegeAttend"].ToString();
						_item.PreviousLeavingNumber = Convert.ToInt32(sqlDataReader["PreviousLeavingNumber"]);
						_item.CastAsPerLeaving = sqlDataReader["CastAsPerLeaving"].ToString();
                        //_item.LeavingDatetime = Convert.ToDateTime(sqlDataReader["LeavingDatetime"]);
                        //_item.EnrollmentNumber = Convert.ToInt32(sqlDataReader["EnrollmentNumber"]);
                        //_item.DomicileStateID = Convert.ToInt32(sqlDataReader["DomicileStateID"]);
                        //_item.DomicileCountryID = Convert.ToInt32(sqlDataReader["DomicileCountryID"]);
                        //_item.MigrationNumber = Convert.ToInt32(sqlDataReader["MigrationNumber"]);
                        //_item.MigrationDatetime = Convert.ToDateTime(sqlDataReader["MigrationDatetime"]);
						_item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
						_item.AdmissionCategoryID = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"]);
						_item.AdmissionTypeID = Convert.ToInt32(sqlDataReader["AdmissionTypeID"]);
						_item.QuotaMstID = Convert.ToInt32(sqlDataReader["QuotaMstID"]);
						_item.SeatMstID = Convert.ToInt32(sqlDataReader["SeatMstID"]);
						_item.IsHostelResidency = Convert.ToBoolean(sqlDataReader["IsHostelResidency"]);
						_item.RfidTagIDNo = Convert.ToInt32(sqlDataReader["RfidTagIDNo"]);
						_item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
						_item.FeeStructureID = Convert.ToInt32(sqlDataReader["FeeStructureID"]);
						_item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
						_item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
						_item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
						_item.CourseYearOldId = Convert.ToInt32(sqlDataReader["CourseYearOldId"]);
						_item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
						_item.StudentStatus = sqlDataReader["StudentStatus"].ToString();
						_item.StatusCode = sqlDataReader["StatusCode"].ToString();
						_item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
						_item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
						_item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
						_item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
						_item.QulifyingExamType = sqlDataReader["QulifyingExamType"].ToString();
						//_item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
						//_item.CentreCode = Convert.ToInt32(sqlDataReader["CentreCode"]);
						_item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
						_item.TransferSectionID = Convert.ToInt32(sqlDataReader["TransferSectionID"]);
						_item.RegistrationID = Convert.ToInt32(sqlDataReader["RegistrationID"]);
						_item.IsDomicleFromLast3Year = Convert.ToBoolean(sqlDataReader["IsDomicleFromLast3Year"]);
						_item.IsNriPoi = Convert.ToBoolean(sqlDataReader["IsNriPoi"]);
						_item.TransferCoursesYearId = Convert.ToInt32(sqlDataReader["TransferCoursesYearId"]);
						_item.DirectSecYrAdmissionMode = sqlDataReader["DirectSecYrAdmissionMode"].ToString();
						_item.AdmittedInShift = sqlDataReader["AdmittedInShift"].ToString();
						_item.AllotAdmThrough = sqlDataReader["AllotAdmThrough"].ToString();
						_item.BankAccountNumber = Convert.ToInt32(sqlDataReader["BankAccountNumber"]);
						_item.BankBranchName = sqlDataReader["BankBranchName"].ToString();
						_item.BankBranchCity = sqlDataReader["BankBranchCity"].ToString();
						_item.UniqueIdentificatinNumber = Convert.ToInt32(sqlDataReader["UniqueIdentificatinNumber"]);
						_item.IdentificationType = sqlDataReader["IdentificationType"].ToString();

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
		/// Select a record from table by ID
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentMaster> GetStudentDetails(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));// for current year student
                    }
                    if (item.searchType == "BackYearStudent")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
					     StudentMaster _item = new StudentMaster();
                            //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
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
                        response.Entity = _item;

                        //_item.FormNumber = sqlDataReader["FormNumber"].ToString();
                        //_item.AdmissionActiveFlag = Convert.ToBoolean(sqlDataReader["AdmissionActiveFlag"]);
                        //_item.YearlyRollNumber = sqlDataReader["YearlyRollNumber"].ToString();
                        //_item.RollNoSortOrder = sqlDataReader["RollNoSortOrder"].ToString();
                        //_item.SortOrderStatus = sqlDataReader["SortOrderStatus"].ToString();
                        //_item.ResultStatus = sqlDataReader["ResultStatus"].ToString();
                        //_item.AdmissionCancelStatus = sqlDataReader["AdmissionCancelStatus"].ToString();
                        //_item.AdmissionStatus = sqlDataReader["AdmissionStatus"].ToString();
                        //	_item.PromotedToNextBranch = sqlDataReader["PromotedToNextBranch"].ToString();
                        //	_item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        //_item.Remark = sqlDataReader["Remark"].ToString();
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
		public IBaseEntityResponse<StudentMaster> InsertStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
					cmdToExecute.CommandText = "dbo.USP_StudentMaster_INSERT";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
										cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StudentCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.Title));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsNickName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.NickName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.FirstName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.MiddleName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.LastName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.MotherName));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentOccupation", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StudentOccupation));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentMobileNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.StudentMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iParentMobileNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ParentMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iGuardianMobileNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.GuardianMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iParentLandlineNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.ParentLandlineNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.ParentEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.GuardianEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.FatherEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.MotherEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StudentEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.NameAsPerLeaving));
					cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.LastSchoolCollegeAttend));
					cmdToExecute.Parameters.Add(new SqlParameter("@iPreviousLeavingNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.PreviousLeavingNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.CastAsPerLeaving));
					cmdToExecute.Parameters.Add(new SqlParameter("@daLeavingDatetime", SqlDbType.DateTime,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.LeavingDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEnrollmentNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.EnrollmentNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileStateID", SqlDbType.SmallInt,5,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.DomicileStateID));
					cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileCountryID", SqlDbType.SmallInt,5,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.DomicileCountryID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMigrationNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.MigrationNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.MigrationDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAdmissionNumber", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AdmissionNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.AdmissionCategoryID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.AdmissionTypeID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iQuotaMstID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.QuotaMstID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSeatMstID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SeatMstID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.IsHostelResidency));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRfidTagIDNo", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.RfidTagIDNo));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.BranchID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.FeeStructureID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.SectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.OldSectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.CourseYearId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearOldId", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.CourseYearOldId));
					cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.StudentActiveFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentStatus", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StudentStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsStatusCode", SqlDbType.NVarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StatusCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionCode", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StuAdmissionCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAcademicYear", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AcademicYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmitAcademicYear", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AdmitAcademicYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionType", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.StuAdmissionType));
					cmdToExecute.Parameters.Add(new SqlParameter("@sQulifyingExamType", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.QulifyingExamType));
					cmdToExecute.Parameters.Add(new SqlParameter("@daFirstAdmissionDatetime", SqlDbType.DateTime,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.FirstAdmissionDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCentreCode", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionPattern", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AdmissionPattern));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTransferSectionID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.TransferSectionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.RegistrationID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDomicleFromLast3Year", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.IsDomicleFromLast3Year));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsNriPoi", SqlDbType.Bit,0,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.IsNriPoi));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTransferCoursesYearId", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.TransferCoursesYearId));
					cmdToExecute.Parameters.Add(new SqlParameter("@sDirectSecYrAdmissionMode", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.DirectSecYrAdmissionMode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmittedInShift", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AdmittedInShift));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAllotAdmThrough", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.AllotAdmThrough));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBankAccountNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.BankAccountNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchName", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.BankBranchName));
					cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchCity", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.BankBranchCity));
					cmdToExecute.Parameters.Add(new SqlParameter("@iUniqueIdentificatinNumber", SqlDbType.Int,10,
											ParameterDirection.Input,false,0,0,"",
											DataRowVersion.Proposed, item.UniqueIdentificatinNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sIdentificationType", SqlDbType.VarChar,0,
											ParameterDirection.Input,false,10,0,"",
											DataRowVersion.Proposed, item.IdentificationType));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
											ParameterDirection.Input, true, 10, 0,"",
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
						throw new Exception("Stored Procedure 'dbo.USP_StudentMaster_INSERT' reported the ErrorCode: " + 
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
		/// Update a specific record of StudentMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> UpdateStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentMaster_Update";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StudentCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.Title));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsNickName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.NickName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.FirstName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.MiddleName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.LastName));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.MotherName));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentOccupation", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StudentOccupation));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStudentMobileNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.StudentMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iParentMobileNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ParentMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iGuardianMobileNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.GuardianMobileNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iParentLandlineNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.ParentLandlineNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.ParentEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.GuardianEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.FatherEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.MotherEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StudentEmailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.NameAsPerLeaving));
					cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.LastSchoolCollegeAttend));
					cmdToExecute.Parameters.Add(new SqlParameter("@iPreviousLeavingNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.PreviousLeavingNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.CastAsPerLeaving));
					cmdToExecute.Parameters.Add(new SqlParameter("@daLeavingDatetime", SqlDbType.DateTime,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.LeavingDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEnrollmentNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.EnrollmentNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileStateID", SqlDbType.SmallInt,5,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.DomicileStateID));
					cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileCountryID", SqlDbType.SmallInt,5,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.DomicileCountryID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iMigrationNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.MigrationNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.MigrationDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsAdmissionNumber", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionCategoryID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.AdmissionTypeID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iQuotaMstID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.QuotaMstID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSeatMstID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SeatMstID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.IsHostelResidency));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRfidTagIDNo", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.RfidTagIDNo));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.BranchID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FeeStructureID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.SectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.OldSectionDetailID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.CourseYearId));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearOldId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.CourseYearOldId));
					cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.StudentActiveFlag));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStudentStatus", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StudentStatus));
					cmdToExecute.Parameters.Add(new SqlParameter("@nsStatusCode", SqlDbType.NVarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StatusCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionCode", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StuAdmissionCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAcademicYear", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AcademicYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmitAcademicYear", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmitAcademicYear));
					cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionType", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.StuAdmissionType));
					cmdToExecute.Parameters.Add(new SqlParameter("@sQulifyingExamType", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.QulifyingExamType));
					cmdToExecute.Parameters.Add(new SqlParameter("@daFirstAdmissionDatetime", SqlDbType.DateTime,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.FirstAdmissionDatetime));
					cmdToExecute.Parameters.Add(new SqlParameter("@iCentreCode", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.CentreCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionPattern", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmissionPattern));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTransferSectionID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TransferSectionID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.RegistrationID));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsDomicleFromLast3Year", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.IsDomicleFromLast3Year));
					cmdToExecute.Parameters.Add(new SqlParameter("@bIsNriPoi", SqlDbType.Bit,0,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.IsNriPoi));
					cmdToExecute.Parameters.Add(new SqlParameter("@iTransferCoursesYearId", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.TransferCoursesYearId));
					cmdToExecute.Parameters.Add(new SqlParameter("@sDirectSecYrAdmissionMode", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.DirectSecYrAdmissionMode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAdmittedInShift", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AdmittedInShift));
					cmdToExecute.Parameters.Add(new SqlParameter("@sAllotAdmThrough", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.AllotAdmThrough));
					cmdToExecute.Parameters.Add(new SqlParameter("@iBankAccountNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.BankAccountNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchName", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.BankBranchName));
					cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchCity", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.BankBranchCity));
					cmdToExecute.Parameters.Add(new SqlParameter("@iUniqueIdentificatinNumber", SqlDbType.Int,10,
										ParameterDirection.Input,false,0,0,"",
										DataRowVersion.Proposed, item.UniqueIdentificatinNumber));
					cmdToExecute.Parameters.Add(new SqlParameter("@sIdentificationType", SqlDbType.VarChar,0,
										ParameterDirection.Input,false,10,0,"",
										DataRowVersion.Proposed, item.IdentificationType));

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
						throw new Exception("Stored Procedure 'dbo.USP_StudentMaster_Delete' reported the ErrorCode: " + 
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
		/// Delete a specific record of StudentMaster
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<StudentMaster> DeleteStudentMaster(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
					cmdToExecute.CommandText ="dbo.USP_StudentMaster_Delete";
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
						throw new Exception("Stored Procedure 'dbo.USP_StudentMaster_Delete' reported the ErrorCode: " + 
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
        /// Select all record from StudentMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentMaster> GetStudentMasterBySearch(StudentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentMaster_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<StudentMaster>();
                    while (sqlDataReader.Read())
                    {
                        StudentMaster item = new StudentMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.Title = sqlDataReader["Title"].ToString();
                        item.NickName = sqlDataReader["NickName"].ToString();
                        item.FirstName = sqlDataReader["FirstName"].ToString();
                        item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        item.LastName = sqlDataReader["LastName"].ToString();
                        item.MotherName = sqlDataReader["MotherName"].ToString();
                        item.StudentOccupation = sqlDataReader["StudentOccupation"].ToString();
                        item.StudentMobileNumber = Convert.ToInt32(sqlDataReader["StudentMobileNumber"]);
                        item.ParentMobileNumber = Convert.ToInt32(sqlDataReader["ParentMobileNumber"]);
                        item.GuardianMobileNumber = Convert.ToInt32(sqlDataReader["GuardianMobileNumber"]);
                        item.ParentLandlineNumber = Convert.ToInt32(sqlDataReader["ParentLandlineNumber"]);
                        item.ParentEmailID = sqlDataReader["ParentEmailID"].ToString();
                        item.GuardianEmailID = sqlDataReader["GuardianEmailID"].ToString();
                        item.FatherEmailID = sqlDataReader["FatherEmailID"].ToString();
                        item.MotherEmailID = sqlDataReader["MotherEmailID"].ToString();
                        item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
                        item.NameAsPerLeaving = sqlDataReader["NameAsPerLeaving"].ToString();
                        item.LastSchoolCollegeAttend = sqlDataReader["LastSchoolCollegeAttend"].ToString();
                        item.PreviousLeavingNumber = Convert.ToInt32(sqlDataReader["PreviousLeavingNumber"]);
                        item.CastAsPerLeaving = sqlDataReader["CastAsPerLeaving"].ToString();
                        //item.LeavingDatetime = Convert.ToDateTime(sqlDataReader["LeavingDatetime"]);
                        //item.EnrollmentNumber = Convert.ToInt32(sqlDataReader["EnrollmentNumber"]);
                        //item.DomicileStateID = Convert.ToInt32(sqlDataReader["DomicileStateID"]);
                        //item.DomicileCountryID = Convert.ToInt32(sqlDataReader["DomicileCountryID"]);
                        //item.MigrationNumber = Convert.ToInt32(sqlDataReader["MigrationNumber"]);
                        //item.MigrationDatetime = Convert.ToDateTime(sqlDataReader["MigrationDatetime"]);
                        item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
                        item.AdmissionCategoryID = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"]);
                        item.AdmissionTypeID = Convert.ToInt32(sqlDataReader["AdmissionTypeID"]);
                        item.QuotaMstID = Convert.ToInt32(sqlDataReader["QuotaMstID"]);
                        item.SeatMstID = Convert.ToInt32(sqlDataReader["SeatMstID"]);
                        item.IsHostelResidency = Convert.ToBoolean(sqlDataReader["IsHostelResidency"]);
                        item.RfidTagIDNo = Convert.ToInt32(sqlDataReader["RfidTagIDNo"]);
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.FeeStructureID = Convert.ToInt32(sqlDataReader["FeeStructureID"]);
                        item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        item.CourseYearOldId = Convert.ToInt32(sqlDataReader["CourseYearOldId"]);
                        item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
                        item.StudentStatus = sqlDataReader["StudentStatus"].ToString();
                        item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
                        item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
                        item.QulifyingExamType = sqlDataReader["QulifyingExamType"].ToString();
                        //item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
                       // item.CentreCode = Convert.ToInt32(sqlDataReader["CentreCode"]);
                        item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
                        item.TransferSectionID = Convert.ToInt32(sqlDataReader["TransferSectionID"]);
                        item.RegistrationID = Convert.ToInt32(sqlDataReader["RegistrationID"]);
                        item.IsDomicleFromLast3Year = Convert.ToBoolean(sqlDataReader["IsDomicleFromLast3Year"]);
                        item.IsNriPoi = Convert.ToBoolean(sqlDataReader["IsNriPoi"]);
                        item.TransferCoursesYearId = Convert.ToInt32(sqlDataReader["TransferCoursesYearId"]);
                        item.DirectSecYrAdmissionMode = sqlDataReader["DirectSecYrAdmissionMode"].ToString();
                        item.AdmittedInShift = sqlDataReader["AdmittedInShift"].ToString();
                        item.AllotAdmThrough = sqlDataReader["AllotAdmThrough"].ToString();
                        item.BankAccountNumber = Convert.ToInt32(sqlDataReader["BankAccountNumber"]);
                        item.BankBranchName = sqlDataReader["BankBranchName"].ToString();
                        item.BankBranchCity = sqlDataReader["BankBranchCity"].ToString();
                        item.UniqueIdentificatinNumber = Convert.ToInt32(sqlDataReader["UniqueIdentificatinNumber"]);
                        item.IdentificationType = sqlDataReader["IdentificationType"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_StudentMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentMaster> GetStudentCentreByID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentMaster_GetStudentCentreByID";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (item.searchType == "CurrentYearStudent")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
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
					     StudentMaster _item = new StudentMaster();
                            //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        _item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);
                        _item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
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
		/// Select a record from table by ID
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<StudentMaster> GetCentreFromStudentMasterByStudentID(StudentMaster item)
		{
			IBaseEntityResponse<StudentMaster> response = new BaseEntityResponse<StudentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreCodeFromStuStudentMaster_ByStudentID";
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
					     StudentMaster _item = new StudentMaster();
                            //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);                       
                        _item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        response.Entity = _item;

                       
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
					{
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)
					{
						// Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreCodeFromStuStudentMaster_ByStudentID' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentMaster> GetStudentAdmissionCancel(StudentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentAdmissionCancel_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                   
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
                    baseEntityCollection.CollectionResponse = new List<StudentMaster>();
                    while (sqlDataReader.Read())
                    {
                        StudentMaster item = new StudentMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                      //  item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        if (Convert.ToBoolean(sqlDataReader["Gender"]) == true)
                        {
                            item.StudentGender = "M";
                        }
                        else
                        {
                            item.StudentGender = "F";
                        } 
                        //item.FirstName = sqlDataReader["FirstName"].ToString();
                        //item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        //item.LastName = sqlDataReader["LastName"].ToString();
                        //item.MotherName = sqlDataReader["MotherName"].ToString();
                        //item.StudentOccupation = sqlDataReader["StudentOccupation"].ToString();
                        //item.StudentMobileNumber = Convert.ToInt32(sqlDataReader["StudentMobileNumber"]);
                        //item.ParentMobileNumber = Convert.ToInt32(sqlDataReader["ParentMobileNumber"]);
                        //item.GuardianMobileNumber = Convert.ToInt32(sqlDataReader["GuardianMobileNumber"]);
                        //item.ParentLandlineNumber = Convert.ToInt32(sqlDataReader["ParentLandlineNumber"]);
                        //item.ParentEmailID = sqlDataReader["ParentEmailID"].ToString();
                        //item.GuardianEmailID = sqlDataReader["GuardianEmailID"].ToString();
                        //item.FatherEmailID = sqlDataReader["FatherEmailID"].ToString();
                        //item.MotherEmailID = sqlDataReader["MotherEmailID"].ToString();
                        //item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
                        //item.NameAsPerLeaving = sqlDataReader["NameAsPerLeaving"].ToString();
                        //item.LastSchoolCollegeAttend = sqlDataReader["LastSchoolCollegeAttend"].ToString();
                        //item.PreviousLeavingNumber = Convert.ToInt32(sqlDataReader["PreviousLeavingNumber"]);
                        //item.CastAsPerLeaving = sqlDataReader["CastAsPerLeaving"].ToString();
                        ////item.LeavingDatetime = Convert.ToDateTime(sqlDataReader["LeavingDatetime"]);
                        ////item.EnrollmentNumber = Convert.ToInt32(sqlDataReader["EnrollmentNumber"]);
                        ////item.DomicileStateID = Convert.ToInt32(sqlDataReader["DomicileStateID"]);
                        ////item.DomicileCountryID = Convert.ToInt32(sqlDataReader["DomicileCountryID"]);
                        ////item.MigrationNumber = Convert.ToInt32(sqlDataReader["MigrationNumber"]);
                        ////item.MigrationDatetime = Convert.ToDateTime(sqlDataReader["MigrationDatetime"]);
                        //item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
                        //item.AdmissionCategoryID = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"]);
                        //item.AdmissionTypeID = Convert.ToInt32(sqlDataReader["AdmissionTypeID"]);
                        //item.QuotaMstID = Convert.ToInt32(sqlDataReader["QuotaMstID"]);
                        //item.SeatMstID = Convert.ToInt32(sqlDataReader["SeatMstID"]);
                        //item.IsHostelResidency = Convert.ToBoolean(sqlDataReader["IsHostelResidency"]);
                        //item.RfidTagIDNo = Convert.ToInt32(sqlDataReader["RfidTagIDNo"]);
                        //item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //item.FeeStructureID = Convert.ToInt32(sqlDataReader["FeeStructureID"]);
                        //item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        //item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        //item.CourseYearOldId = Convert.ToInt32(sqlDataReader["CourseYearOldId"]);
                        //item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
                        //item.StudentStatus = sqlDataReader["StudentStatus"].ToString();
                        //item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        //item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
                        //item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        //item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        //item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
                        //item.QulifyingExamType = sqlDataReader["QulifyingExamType"].ToString();
                        ////item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
                        //// item.CentreCode = Convert.ToInt32(sqlDataReader["CentreCode"]);
                        //item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
                        //item.TransferSectionID = Convert.ToInt32(sqlDataReader["TransferSectionID"]);
                        //item.RegistrationID = Convert.ToInt32(sqlDataReader["RegistrationID"]);
                        //item.IsDomicleFromLast3Year = Convert.ToBoolean(sqlDataReader["IsDomicleFromLast3Year"]);
                        //item.IsNriPoi = Convert.ToBoolean(sqlDataReader["IsNriPoi"]);
                        //item.TransferCoursesYearId = Convert.ToInt32(sqlDataReader["TransferCoursesYearId"]);
                        //item.DirectSecYrAdmissionMode = sqlDataReader["DirectSecYrAdmissionMode"].ToString();
                        //item.AdmittedInShift = sqlDataReader["AdmittedInShift"].ToString();
                        //item.AllotAdmThrough = sqlDataReader["AllotAdmThrough"].ToString();
                        //item.BankAccountNumber = Convert.ToInt32(sqlDataReader["BankAccountNumber"]);
                        //item.BankBranchName = sqlDataReader["BankBranchName"].ToString();
                        //item.BankBranchCity = sqlDataReader["BankBranchCity"].ToString();
                        //item.UniqueIdentificatinNumber = Convert.ToInt32(sqlDataReader["UniqueIdentificatinNumber"]);
                        //item.IdentificationType = sqlDataReader["IdentificationType"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_StudentAdmissionCancel_SelectAll' reported the ErrorCode: " + _errorCode);
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

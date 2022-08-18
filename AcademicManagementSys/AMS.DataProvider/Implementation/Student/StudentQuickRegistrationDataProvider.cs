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
    public class StudentQuickRegistrationDataProvider : DBInteractionBase, IStudentQuickRegistrationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentQuickRegistrationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentQuickRegistrationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudentQuickRegistration table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentQuickRegistration> GetStudentQuickRegistrationBySearch(StudentQuickRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentQuickRegistration> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentQuickRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentQuickRegistration_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<StudentQuickRegistration>();
                    while (sqlDataReader.Read())
                    {
                        StudentQuickRegistration item = new StudentQuickRegistration();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.Title = sqlDataReader["Title"].ToString();
                        item.FirstName = sqlDataReader["FirstName"].ToString();
                        item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        item.LastName = sqlDataReader["LastName"].ToString();
                        item.MotherName = sqlDataReader["MotherName"].ToString();
                        item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
                        item.StudentStatus = Convert.ToBoolean(sqlDataReader["StudentStatus"]);
                        item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
                        item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
                        item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
                        item.TransferSectionID = Convert.ToInt32(sqlDataReader["TransferSectionID"]);
                        item.DirectSecYrAdmissionMode = sqlDataReader["DirectSecYrAdmissionMode"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_StudentQuickRegistration_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentQuickRegistration> GetStudentQuickRegistrationByID(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> response = new BaseEntityResponse<StudentQuickRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentQuickRegistration_SelectOne";
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
                        StudentQuickRegistration _item = new StudentQuickRegistration();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        _item.Title = sqlDataReader["Title"].ToString();
                        _item.FirstName = sqlDataReader["FirstName"].ToString();
                        _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.LastName = sqlDataReader["LastName"].ToString();
                        _item.MotherName = sqlDataReader["MotherName"].ToString();
                        _item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
                        _item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        _item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        _item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        _item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
                        _item.StudentStatus = Convert.ToBoolean(sqlDataReader["StudentStatus"]);
                        _item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        _item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
                        _item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        _item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        _item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        _item.AdmissionPattern = sqlDataReader["AdmissionPattern"].ToString();
                        _item.TransferSectionID = Convert.ToInt32(sqlDataReader["TransferSectionID"]);
                        _item.DirectSecYrAdmissionMode = sqlDataReader["DirectSecYrAdmissionMode"].ToString();

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
        public IBaseEntityResponse<StudentQuickRegistration> InsertStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> response = new BaseEntityResponse<StudentQuickRegistration>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlCommand cmdToExecute1 = new SqlCommand();
            SqlTransaction transaction = null;
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
                    cmdToExecute1.Connection = _mainConnection;

                    cmdToExecute.CommandText = "dbo.USP_StudentQuickRegistration_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   
                    //StudentQuickInformation
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Title));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MotherName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtDateOfBirth", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.DateofBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.StudentGender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentMobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentEmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.studentAddress));

                    //Quickregistration
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStatusCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StatusCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAcademicYearID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AcademicSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdmitAcademicYear", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdmitAcademicYear));    
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionPattern", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdmissionPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentMstID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    // cmdToExecute.Parameters.Add(new SqlParameter("@nsNickName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@sStudentOccupation", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iParentMobileNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iGuardianMobileNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iParentLandlineNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sParentEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sGuardianEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sFatherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@sMotherEmailID", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsNameAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sLastSchoolCollegeAttend", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iPreviousLeavingNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCastAsPerLeaving", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daLeavingDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iEnrollmentNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileStateID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@siDomicileCountryID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iMigrationNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daMigrationDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsAdmissionNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCategoryID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionTypeID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iQuotaMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSeatMstID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsHostelResidency", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iRfidTagIDNo", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearOldId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionCode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,  DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sQulifyingExamType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daFirstAdmissionDatetime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTransferSectionID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iRegistrationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsDomicleFromLast3Year", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsNriPoi", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iTransferCoursesYearId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@sDirectSecYrAdmissionMode", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sAdmittedInShift", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sAllotAdmThrough", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBankAccountNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sBankBranchCity", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iUniqueIdentificatinNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sIdentificationType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));


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
                        if (DBNull.Value.Equals(cmdToExecute.Parameters["@iStudentMstID"].Value) == false)
                        {
                            //item.ID = (Int16)cmdToExecute.Parameters["@siID"].Value;
                            item.StudentID = (Int32)cmdToExecute.Parameters["@iStudentMstID"].Value;
                        }

                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentQuickRegistration_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of StudentQuickRegistration
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> UpdateStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> response = new BaseEntityResponse<StudentQuickRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentQuickRegistration_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StudentCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsTitle", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Title));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMotherName", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MotherName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentEmailID", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StudentEmailID));

                   

                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentActiveFlag", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StudentActiveFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bStudentStatus", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StudentStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStatusCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StatusCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStuAdmissionCode", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StuAdmissionCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAcademicYear", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.AcademicYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdmitAcademicYear", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.AdmitAcademicYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daFirstAdmissionDatetime", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.FirstAdmissionDatetime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionPattern", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.AdmissionPattern));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTransferSectionID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.TransferSectionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sDirectSecYrAdmissionMode", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.DirectSecYrAdmissionMode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                         ParameterDirection.Output, true, 10, 0, "",
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
                        throw new Exception("Stored Procedure 'dbo.USP_StudentQuickRegistration_Delete' reported the ErrorCode: " +
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
                            ErrorMessage = "Create failed"
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
        /// Delete a specific record of StudentQuickRegistration
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentQuickRegistration> DeleteStudentQuickRegistration(StudentQuickRegistration item)
        {
            IBaseEntityResponse<StudentQuickRegistration> response = new BaseEntityResponse<StudentQuickRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentQuickRegistration_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                                ParameterDirection.Input, false, 0, 0, "",
                                                DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                                ParameterDirection.Output, true, 10, 0, "",
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
                        throw new Exception("Stored Procedure 'dbo.USP_StudentQuickRegistration_Delete' reported the ErrorCode: " +
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
                            ErrorMessage = "Create failed"
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

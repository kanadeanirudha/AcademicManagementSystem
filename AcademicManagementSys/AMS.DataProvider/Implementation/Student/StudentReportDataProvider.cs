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
    public class StudentReportDataProvider : DBInteractionBase, IStudentReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForOrignalBranchwise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRptOriginalBranchWiseStudentList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    if (searchRequest.AdmissionStatus == "null" || searchRequest.AdmissionStatus == "B")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmissionStatus));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortOrder", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortOrder));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.SerialNumber = sqlDataReader["SerialNumber"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.StudentTitle = sqlDataReader["StudentTitle"].ToString();
                        //item.StudentFirstName = sqlDataReader["StudentFirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["StudentMiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["StudentLastName"].ToString();
                        item.RollNumber = sqlDataReader["RollNumber"].ToString();
                        item.AcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        item.CourseYearDesciption = sqlDataReader["CourseYearDesciption"].ToString();
                        item.SectionDetailDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();

                        item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"].ToString();
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"].ToString();
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"].ToString();
                        item.SortByList = sqlDataReader["SortByList"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {

                            item.Logo = (byte[])(sqlDataReader["Logo"]);
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
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentList(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRptNameWiseStudentList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    if (searchRequest.AdmissionStatus == "null" || searchRequest.AdmissionStatus == "B")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmissionStatus));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortOrder", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortOrder));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.SerialNumber = sqlDataReader["SerialNumber"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.StudentTitle = sqlDataReader["StudentTitle"].ToString();
                        //item.StudentFirstName = sqlDataReader["StudentFirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["StudentMiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["StudentLastName"].ToString();
                        item.RollNumber = sqlDataReader["RollNumber"].ToString();
                        item.AcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        item.CourseYearDesciption = sqlDataReader["CourseYearDesciption"].ToString();
                        item.SectionDetailDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();

                        item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"].ToString();
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"].ToString();
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"].ToString();
                        item.SortByList = sqlDataReader["SortByList"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {

                            item.Logo = (byte[])(sqlDataReader["Logo"]);
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
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForAddress(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuStudentSearchWithPagination";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    if (searchRequest.CentreCode != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, string.Empty));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "null"));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "null"));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNextSectionDetailId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();
                        item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.StudentFullName = sqlDataReader["Title"].ToString() + " " + sqlDataReader["FirstName"].ToString() + " " + sqlDataReader["MiddleName"].ToString() + " " + sqlDataReader["LastName"].ToString();
                        //item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.RollNumber = sqlDataReader["YearlyRollNumber"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForRollListwise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRptStudentRollList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    if (searchRequest.AdmissionStatus == "null" || searchRequest.AdmissionStatus == "B")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmissionStatus));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortOrder", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortOrder));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.SerialNumber = sqlDataReader["SerialNumber"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.StudentTitle = sqlDataReader["StudentTitle"].ToString();
                        //item.StudentFirstName = sqlDataReader["StudentFirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["StudentMiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["StudentLastName"].ToString();
                        item.RollNumber = sqlDataReader["RollNumber"].ToString();
                        item.AcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        item.CourseYearDesciption = sqlDataReader["CourseYearDesciption"].ToString();
                        item.SectionDetailDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();

                        item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"].ToString();
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"].ToString();
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"].ToString();
                        item.SortByList = sqlDataReader["SortByList"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {

                            item.Logo = (byte[])(sqlDataReader["Logo"]);
                        }
                        item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
                        item.CategoryName = sqlDataReader["CategoryName"].ToString();
                        item.EnrollmentNumber = sqlDataReader["EnrollmentNumber"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForCategorywise(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRptStudentCaseCategoryWiseList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    if (searchRequest.AdmissionStatus == "null" || searchRequest.AdmissionStatus == "B")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@cAdmissionStatus", SqlDbType.Char, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.AdmissionStatus));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortOrder", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortOrder));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CategoryId));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.SerialNumber = sqlDataReader["SerialNumber"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.StudentTitle = sqlDataReader["StudentTitle"].ToString();
                        //item.StudentFirstName = sqlDataReader["StudentFirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["StudentMiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["StudentLastName"].ToString();
                        item.RollNumber = sqlDataReader["RollNumber"].ToString();
                        item.AcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        item.CourseYearDesciption = sqlDataReader["CourseYearDesciption"].ToString();
                        item.SectionDetailDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();

                        item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"].ToString();
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"].ToString();
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"].ToString();
                        item.SortByList = sqlDataReader["SortByList"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {

                            item.Logo = (byte[])(sqlDataReader["Logo"]);
                        }
                        item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
                        item.CategoryName = sqlDataReader["CategoryName"].ToString();
                        item.EnrollmentNumber = sqlDataReader["EnrollmentNumber"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //searchlist

        public IBaseEntityCollectionResponse<StudentReport> GetStudentSearchListForIdentityCard(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentIdentityCardReport_SearchListForStudent";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.SessionID)));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StudentId));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        //item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //item.StudentTitle = sqlDataReader["StudentTitle"].ToString();
                        //item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        //item.StudentFirstName = sqlDataReader["StudentFirstName"].ToString();
                        //item.StudentMiddleName = sqlDataReader["StudentMiddleName"].ToString();
                        //item.StudentLastName = sqlDataReader["StudentLastName"].ToString();
                        
                       
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentIdentityCardReport_SearchListForStudent' reported the ErrorCode: " + _errorCode);
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







        public IBaseEntityCollectionResponse<StudentReport> GetBySearchForStudentIdentityCard(StudentReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_StuRptStudentIdentityCardList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt32(searchRequest.AcademicYear)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StudentId));
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<StudentReport>();
                    while (sqlDataReader.Read())
                    {
                        StudentReport item = new StudentReport();

                        item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        item.StudentBloodGroup = sqlDataReader["StudentBloodGroup"].ToString();
                        item.StudentDOB = sqlDataReader["StudentDOB"].ToString();
                        item.StudentParentMobileNo = sqlDataReader["StudentParentMobileNo"].ToString();
                        item.StudentIdentificationMark = sqlDataReader["StudentIdentificationMark"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentSignature"]) == false)
                        {
                            item.StudentSignature = (byte[])(sqlDataReader["StudentSignature"]);
                        }
                        item.StudentAddress = sqlDataReader["StudentAddress"].ToString();
                        item.SerialNumber = sqlDataReader["SerialNumber"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.RollNumber = sqlDataReader["RollNumber"].ToString();
                        item.AdmissionDate = sqlDataReader["AdmissionDate"].ToString();
                        item.CourseYearDesciption = sqlDataReader["CourseYearDesciption"].ToString();
                        item.SectionDetailDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        item.PrintingLine1 = sqlDataReader["PrintingLine1"].ToString();
                        item.PrintingLine2 = sqlDataReader["PrintingLine2"].ToString();
                        item.PrintingLine3 = sqlDataReader["PrintingLine3"].ToString();
                        item.PrintingLine4 = sqlDataReader["PrintingLine4"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["Logo"]) == false)
                        {
                            item.Logo = (byte[])(sqlDataReader["Logo"]);
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
                        throw new Exception("Stored Procedure 'USP_StudentReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

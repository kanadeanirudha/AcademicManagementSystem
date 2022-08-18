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
    public class TimeTableAttendanceMasterAndDetailsDataProvider : DBInteractionBase, ITimeTableAttendanceMasterAndDetailsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public TimeTableAttendanceMasterAndDetailsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public TimeTableAttendanceMasterAndDetailsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from TimeTableAttendanceMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetStudentSearchList(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode /* searchRequest.CentreCode*/));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iMaxResult", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.maxResult));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));// for current year student
                        //cmdToExecute.Parameters.Add(new SqlParameter("@sAdmissionStatus", SqlDbType.Char, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "C"));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@sStatusCode", SqlDbType.VarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, "Pursuing"));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionCancelStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));// 
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));
                   

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
                    baseEntityCollection.CollectionResponse = new List<TimeTableAttendanceMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        TimeTableAttendanceMasterAndDetails item = new TimeTableAttendanceMasterAndDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.StudentName = sqlDataReader["StudentName"].ToString();
                        //item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        //if (DBNull.Value.Equals(sqlDataReader["CourseYearId"]) == false)
                        //{
                        //    item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SectionDetailID"]) == false)
                        //{
                        //    item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //}


                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_TimeTableAttendanceMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> GetTimeTableAttendanceMasterAndDetailsByID(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_SelectOne";
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
                        TimeTableAttendanceMasterAndDetails _item = new TimeTableAttendanceMasterAndDetails();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //_item.Title = sqlDataReader["Title"].ToString();
                        //_item.NickName = sqlDataReader["NickName"].ToString();
                        //_item.FirstName = sqlDataReader["FirstName"].ToString();
                        //_item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        //_item.LastName = sqlDataReader["LastName"].ToString();
                        //_item.MotherName = sqlDataReader["MotherName"].ToString();
                        //_item.StudentOccupation = sqlDataReader["StudentOccupation"].ToString();
                        //_item.StudentMobileNumber = Convert.ToInt32(sqlDataReader["StudentMobileNumber"]);
                        //_item.ParentMobileNumber = Convert.ToInt32(sqlDataReader["ParentMobileNumber"]);
                        //_item.GuardianMobileNumber = Convert.ToInt32(sqlDataReader["GuardianMobileNumber"]);
                        //_item.ParentLandlineNumber = Convert.ToInt32(sqlDataReader["ParentLandlineNumber"]);
                        //_item.ParentEmailID = sqlDataReader["ParentEmailID"].ToString();
                        //_item.GuardianEmailID = sqlDataReader["GuardianEmailID"].ToString();
                        //_item.FatherEmailID = sqlDataReader["FatherEmailID"].ToString();
                        //_item.MotherEmailID = sqlDataReader["MotherEmailID"].ToString();
                        //_item.StudentEmailID = sqlDataReader["StudentEmailID"].ToString();
                        //_item.NameAsPerLeaving = sqlDataReader["NameAsPerLeaving"].ToString();
                        //_item.LastSchoolCollegeAttend = sqlDataReader["LastSchoolCollegeAttend"].ToString();
                        //_item.PreviousLeavingNumber = Convert.ToInt32(sqlDataReader["PreviousLeavingNumber"]);
                        //_item.CastAsPerLeaving = sqlDataReader["CastAsPerLeaving"].ToString();
                        //_item.LeavingDatetime = Convert.ToDateTime(sqlDataReader["LeavingDatetime"]);
                        //_item.EnrollmentNumber = Convert.ToInt32(sqlDataReader["EnrollmentNumber"]);
                        //_item.DomicileStateID = Convert.ToInt32(sqlDataReader["DomicileStateID"]);
                        //_item.DomicileCountryID = Convert.ToInt32(sqlDataReader["DomicileCountryID"]);
                        //_item.MigrationNumber = Convert.ToInt32(sqlDataReader["MigrationNumber"]);
                        //_item.MigrationDatetime = Convert.ToDateTime(sqlDataReader["MigrationDatetime"]);
                        //_item.AdmissionNumber = sqlDataReader["AdmissionNumber"].ToString();
                        //_item.AdmissionCategoryID = Convert.ToInt32(sqlDataReader["AdmissionCategoryID"]);
                        //_item.AdmissionTypeID = Convert.ToInt32(sqlDataReader["AdmissionTypeID"]);
                        //_item.QuotaMstID = Convert.ToInt32(sqlDataReader["QuotaMstID"]);
                        //_item.SeatMstID = Convert.ToInt32(sqlDataReader["SeatMstID"]);
                        //_item.IsHostelResidency = Convert.ToBoolean(sqlDataReader["IsHostelResidency"]);
                        //_item.RfidTagIDNo = Convert.ToInt32(sqlDataReader["RfidTagIDNo"]);
                        //_item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        //_item.FeeStructureID = Convert.ToInt32(sqlDataReader["FeeStructureID"]);
                        //_item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //_item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        //_item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        //_item.CourseYearOldId = Convert.ToInt32(sqlDataReader["CourseYearOldId"]);
                        //_item.StudentActiveFlag = Convert.ToBoolean(sqlDataReader["StudentActiveFlag"]);
                        //_item.StudentStatus = sqlDataReader["StudentStatus"].ToString();
                        //_item.StatusCode = sqlDataReader["StatusCode"].ToString();
                        //_item.StuAdmissionCode = sqlDataReader["StuAdmissionCode"].ToString();
                        //_item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        //_item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"].ToString();
                        //_item.StuAdmissionType = sqlDataReader["StuAdmissionType"].ToString();
                        //_item.QulifyingExamType = sqlDataReader["QulifyingExamType"].ToString();
                        //_item.FirstAdmissionDatetime = Convert.ToDateTime(sqlDataReader["FirstAdmissionDatetime"]);
                        //_item.CentreCode = Convert.ToInt32(sqlDataReader["CentreCode"]);
                     

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
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> GetStudentDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_GetStudentDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));// for back year student
                  
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
                        TimeTableAttendanceMasterAndDetails _item = new TimeTableAttendanceMasterAndDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        //_item.StudentName = Convert.ToString(sqlDataReader["StudentName"]);
                        //_item.SectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //_item.BranchId = Convert.ToInt32(sqlDataReader["OrginalBranchID"]);
                        //_item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        //_item.CourseYearId = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        //_item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        //_item.SectionDesc = sqlDataReader["SectionDetailDesc"].ToString();
                        //_item.CourseYearDesc = sqlDataReader["CourseYearDesc"].ToString();
                        //_item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);
                        //_item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        //_item.StudentCode = sqlDataReader["StudentCode"].ToString();
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
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> InsertTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));                 
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
                        throw new Exception("Stored Procedure 'dbo.USP_TimeTableAttendanceMasterAndDetails_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of TimeTableAttendanceMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> UpdateTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));                 
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
                        throw new Exception("Stored Procedure 'dbo.USP_TimeTableAttendanceMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of TimeTableAttendanceMasterAndDetails
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> DeleteTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_TimeTableAttendanceMasterAndDetails_Delete' reported the ErrorCode: " +
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
        /// Select all record from TimeTableAttendanceMasterAndDetails table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetTimeTableAttendanceMasterAndDetailsBySearch(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<TimeTableAttendanceMasterAndDetails>();
                    while (sqlDataReader.Read())
                    {
                        TimeTableAttendanceMasterAndDetails item = new TimeTableAttendanceMasterAndDetails();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);

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
                        throw new Exception("Stored Procedure 'USP_TimeTableAttendanceMasterAndDetails_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> GetStudentCentreByID(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_TimeTableAttendanceMasterAndDetails_GetStudentCentreByID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  
                        cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iActiveSessionFlag", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                        cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   
                   
                        // Open connection.
                        _mainConnection.Open();
                   
                     
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TimeTableAttendanceMasterAndDetails _item = new TimeTableAttendanceMasterAndDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);                       
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
        public IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> GetCentreFromTimeTableAttendanceMasterAndDetailsByStudentID(TimeTableAttendanceMasterAndDetails item)
        {
            IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> response = new BaseEntityResponse<TimeTableAttendanceMasterAndDetails>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetCentreCodeFromStuTimeTableAttendanceMasterAndDetails_ByStudentID";
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
                        TimeTableAttendanceMasterAndDetails _item = new TimeTableAttendanceMasterAndDetails();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.CentreCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        response.Entity = _item;


                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GetCentreCodeFromStuTimeTableAttendanceMasterAndDetails_ByStudentID' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

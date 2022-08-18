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
    public class StudentChangeCourseRequestApplicationDataProvider : DBInteractionBase, IStudentChangeCourseRequestApplicationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentChangeCourseRequestApplicationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentChangeCourseRequestApplicationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudentChangeCourseRequestApplication table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetStudentChangeCourseRequestApplicationBySearch(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<StudentChangeCourseRequestApplication>();
                    while (sqlDataReader.Read())
                    {
                        StudentChangeCourseRequestApplication item = new StudentChangeCourseRequestApplication();
                        if (DBNull.Value.Equals(sqlDataReader["Id"]) == false)
                        {
                            item.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        }

                        item.ApplicationDate = Convert.ToDateTime(sqlDataReader["ApplicationDate"]);
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYearId"]) == false)
                        {
                            item.AcademicYearId = Convert.ToInt32(sqlDataReader["AcademicYearId"]);

                        }
                        item.OldCourseId = Convert.ToInt32(sqlDataReader["OldCourseId"]);
                        item.NewCourseId = Convert.ToInt32(sqlDataReader["NewCourseId"]);
                        item.AdmittedCourse = sqlDataReader["AdmittedCourse"].ToString();
                        item.NewCourse = sqlDataReader["NewCourse"].ToString();
                        item.NewSectionDetailsID = Convert.ToInt32(sqlDataReader["NewSectionDetailsID"]);
                        item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        item.RequestSectionDetailID = Convert.ToInt32(sqlDataReader["RequestSectionDetailID"]);
                        item.CenterCode = sqlDataReader["CenterCode"].ToString();
                        item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        item.RoleID = Convert.ToInt32(sqlDataReader["RoleID"]);
                        item.ApprovalDate = Convert.ToDateTime(sqlDataReader["ApprovalDate"]);
                        item.ApplicationReason = sqlDataReader["ApplicationReason"].ToString();
                        item.CancellationReason = sqlDataReader["CancellationReason"].ToString();                              
                        item.ApplicationStatus = Convert.ToBoolean(sqlDataReader["ApplicationStatus"]);
                       
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
                        throw new Exception("Stored Procedure 'USP_StudentChangeCourseRequestApplication_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> GetStudentChangeCourseRequestApplicationByID(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Id));
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
                        StudentChangeCourseRequestApplication _item = new StudentChangeCourseRequestApplication();
                        _item.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        _item.ChangeRequestMasterId = Convert.ToInt32(sqlDataReader["ChangeRequestMasterId"]);
                        _item.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        _item.ApplicationDate = Convert.ToDateTime(sqlDataReader["ApplicationDate"]);
                        _item.AcademicYearId = Convert.ToInt32(sqlDataReader["AcademicYearId"]);
                        _item.OldCourseId = Convert.ToInt32(sqlDataReader["OldCourseId"]);
                        _item.NewCourseId = Convert.ToInt32(sqlDataReader["NewCourseId"]);
                        _item.ApprovalStatus = Convert.ToBoolean(sqlDataReader["ApprovalStatus"]);
                        _item.NewSectionDetailsID = Convert.ToInt32(sqlDataReader["NewSectionDetailsID"]);
                        _item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        _item.RequestSectionDetailID = Convert.ToInt32(sqlDataReader["RequestSectionDetailID"]);

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


        //By login Id


        public IBaseEntityResponse<StudentChangeCourseRequestApplication> SelectByUserLoginId(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsUserLoginId", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.UserLoginId));
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
                    while (sqlDataReader.Read())
                    {
                        StudentChangeCourseRequestApplication _item = new StudentChangeCourseRequestApplication();

                        _item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);
                        _item.UniversityName = Convert.ToString(sqlDataReader["UniversityName"]);
                        _item.UniversityID = Convert.ToInt32(sqlDataReader["UniversityID"]);
                        _item.BranchDescription = Convert.ToString(sqlDataReader["BranchDescription"]);
                        _item.CenterCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        _item.OldCourseId = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        _item.OldSectionDetailID = Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        //_item.ApplicationReason = Convert.ToString(sqlDataReader["ApplicationReason"]);
                        //_item.ApplicationStatus = Convert.ToBoolean(sqlDataReader["ApplicationStatus"]);

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
        /// 

        //For searchlist


        public IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> GetBySearchlist(StudentChangeCourseRequestApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentChangeCourseRequestApplication> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.VarChar, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));
                    

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

                    baseEntityCollection.CollectionResponse = new List<StudentChangeCourseRequestApplication>();
                    while (sqlDataReader.Read())
                    {
                        StudentChangeCourseRequestApplication item = new StudentChangeCourseRequestApplication();
                        item.BranchID = Convert.ToInt32(sqlDataReader["BranchID"]);
                        item.BranchDescription = Convert.ToString(sqlDataReader["BranchDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudentChangeCourseRequestApplication_SearchList' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityResponse<StudentChangeCourseRequestApplication> InsertStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.Id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.StudentId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldCourseId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.OldCourseId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewCourseId", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.NewCourseId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.VarChar, 30,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4,
                                           ParameterDirection.Input, false, 0, 0, "",
                                           DataRowVersion.Proposed, item.UniversityID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daApplicationDate", SqlDbType.DateTime,4,
                    //                      ParameterDirection.Input, false, 0, 0, "",
                    //                      DataRowVersion.Proposed, item.ApplicationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int, 4,
                                         ParameterDirection.Input, false, 0, 0, "",
                                         DataRowVersion.Proposed, item.OldSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsApplicationReason", SqlDbType.VarChar, 100,
                                          ParameterDirection.Input, false, 0, 0, "",
                                          DataRowVersion.Proposed, item.ApplicationReason));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsApplicationStatus", SqlDbType.Bit, 4,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApplicationStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsOldSection", SqlDbType.VarChar, 4,
                    //                  ParameterDirection.Input, false, 0, 0, "",
                    //                  DataRowVersion.Proposed, item.OldSection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.CreatedBy));
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
                    item.Id = (Int32)cmdToExecute.Parameters["@iId"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentChangeCourseRequestApplication_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of StudentChangeCourseRequestApplication
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> UpdateStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.Id));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iChangeRequestMasterId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ChangeRequestMasterId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StudentId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApplicationDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApplicationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAcademicYearId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.AcademicYearId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldCourseId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OldCourseId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewCourseId", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NewCourseId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cApprovalStatus", SqlDbType.Char, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ApprovalStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNewSectionDetailsID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.NewSectionDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldSectionDetailID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.OldSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRequestSectionDetailID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.RequestSectionDetailID));

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
                    item.Id = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentChangeCourseRequestApplication_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of StudentChangeCourseRequestApplication
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentChangeCourseRequestApplication> DeleteStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication item)
        {
            IBaseEntityResponse<StudentChangeCourseRequestApplication> response = new BaseEntityResponse<StudentChangeCourseRequestApplication>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentChangeCourseRequestApplication_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.Id));
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
                    item.Id = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentChangeCourseRequestApplication_Delete' reported the ErrorCode: " +
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

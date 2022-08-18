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
    public class StudentSelfRegistrationDataProvider : DBInteractionBase, IStudentSelfRegistrationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentSelfRegistrationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentSelfRegistrationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudentSelfRegistration table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetStudentSelfRegistrationBySearch(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentSelfRegistration_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<StudentSelfRegistration>();
                    while (sqlDataReader.Read())
                    {
                        StudentSelfRegistration item = new StudentSelfRegistration();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.EmailID = sqlDataReader["EmailID"].ToString();
                        item.Password = sqlDataReader["Password"].ToString();
                        item.Title = sqlDataReader["Title"].ToString();
                        item.FirstName = sqlDataReader["FirstName"].ToString();
                        item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        item.LastName = sqlDataReader["LastName"].ToString();
                        item.ContactNumber = sqlDataReader["ContactNumber"].ToString();
                        item.Gender = sqlDataReader["Gender"].ToString();
                        item.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();
                        item.CenterCode = sqlDataReader["CenterCode"].ToString();
                        item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        item.WebRegistrationStatus = sqlDataReader["WebRegistrationStatus"].ToString();
                        item.WebAdminComments = sqlDataReader["WebAdminComments"].ToString();
                        item.ApprovalDate = Convert.ToDateTime(sqlDataReader["ApprovalDate"]);
                        item.AdminApprovedBy = Convert.ToInt32(sqlDataReader["AdminApprovedBy"]);
                        item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.ApprovStudSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovStudSecEmployeeID"]);
                        item.ApprovAcctSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovAcctSecEmployeeID"]);

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
                        throw new Exception("Stored Procedure 'USP_StudentSelfRegistration_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentSelfRegistration> SelectByStudentEmailIDPassword(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> response = new BaseEntityResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentSelfRegistration_SelectOneByEmailIDPassword";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmail", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPassword", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Password.Trim()));
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
                        StudentSelfRegistration _item = new StudentSelfRegistration();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EmailID = sqlDataReader["EmailID"].ToString();
                        _item.Password = sqlDataReader["Password"].ToString();
                        _item.Title = sqlDataReader["Title"].ToString();
                        _item.FirstName = sqlDataReader["FirstName"].ToString();
                        _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        _item.LastName = sqlDataReader["LastName"].ToString();
                        _item.ContactNumber = sqlDataReader["ContactNumber"].ToString();
                        // _item.Gender = sqlDataReader["Gender"].ToString();
                        //  _item.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                        _item.CenterCode = sqlDataReader["CenterCode"].ToString();
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        _item.StudentRegistrationMasterID = Convert.ToInt32(sqlDataReader["StuRegistrationStudentMasterID"].ToString());
                        _item.ApproveRejectStatus = sqlDataReader["ApproveRejectStatus"].ToString();
                        //_item.WebRegistrationStatus = sqlDataReader["WebRegistrationStatus"].ToString();
                        //_item.WebAdminComments = sqlDataReader["WebAdminComments"].ToString();
                        //_item.ApprovalDate = Convert.ToDateTime(sqlDataReader["ApprovalDate"]);
                        //_item.AdminApprovedBy = Convert.ToInt32(sqlDataReader["AdminApprovedBy"]);
                        //_item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        //_item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        //_item.ApprovStudSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovStudSecEmployeeID"]);
                        //_item.ApprovAcctSecEmployeeID = Convert.ToInt32(sqlDataReader["ApprovAcctSecEmployeeID"]);

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

        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetGeneralCountryMasterGetBySearchList(GeneralCountryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralCountryMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralCountryMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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

                    baseEntityCollection.CollectionResponse = new List<GeneralCountryMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralCountryMaster item = new GeneralCountryMaster();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.CountryName = sqlDataReader["CountryName"].ToString();

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_GeneralCountryMaster_SearchList' reported the ErrorCode: " + _errorCode);
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

        //For Caste Master

        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCentreMasterOfApplicableToStudentTemplate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (searchRequest.ApplicableForEntranceExam != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsApplicableForEntranceExam", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToBoolean(searchRequest.ApplicableForEntranceExam)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsApplicableForEntranceExam", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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
                    baseEntityCollection.CollectionResponse = new List<StudentSelfRegistration>();
                    while (sqlDataReader.Read())
                    {
                        StudentSelfRegistration item = new StudentSelfRegistration();

                        item.CenterCode = Convert.ToString(sqlDataReader["CentreCode"]);
                        item.CentreName = Convert.ToString(sqlDataReader["CentreName"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                      //  baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OrgStudyCentreMasterOfApplicableToStudentTemplate' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListBranchDetailsOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_BranchDetailsListOfApplicableToStudentTemplate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));

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
                    baseEntityCollection.CollectionResponse = new List<StudentSelfRegistration>();
                    while (sqlDataReader.Read())
                    {
                        StudentSelfRegistration item = new StudentSelfRegistration();
                        // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["BranchDetID"]) == false)
                        {
                            item.BranchDetailID = Convert.ToInt32(sqlDataReader["BranchDetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BranchDescription"]) == false)
                        {
                            item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DivisionDescription"]) == false)
                        {
                            item.DivisionDescription = sqlDataReader["DivisionDescription"].ToString();
                        }
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
                        throw new Exception("Stored Procedure 'USP_ToolTemplateApplicable_BranchDetailsList' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListStandardNumberOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStandardNumberOfApplicableToStudentTemplate";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchDetailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CenterCode));

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
                    baseEntityCollection.CollectionResponse = new List<StudentSelfRegistration>();
                    while (sqlDataReader.Read())
                    {
                        StudentSelfRegistration item = new StudentSelfRegistration();
                        // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["StandardNumber"]) == false)
                        {
                            item.StandardNumber = Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StandardDescription"]) == false)
                        {
                            item.StandardDescription = sqlDataReader["StandardDescription"].ToString();
                        }
                      
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
                        throw new Exception("Stored Procedure 'USP_ToolTemplateApplicable_BranchDetailsList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentSelfRegistration> InsertStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> response = new BaseEntityResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentRegistration_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailID", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPassword", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTitle", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Title));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sFirstName", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMiddleName", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, (item.MiddleName != null) ? item.MiddleName : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLastName", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContactNumber", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ContactNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGender", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Gender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, true));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchDetailID", SqlDbType.Int, 10,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.BranchDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandardNumber", SqlDbType.Int, 10,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.StandardNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdmissionPattern", SqlDbType.Int, 10,
                       ParameterDirection.Input, false, 0, 0, "",
                       DataRowVersion.Proposed, item.AdmissionPattern));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sWebRegistrationStatus", SqlDbType.VarChar, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.WebRegistrationStatus));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sWebAdminComments", SqlDbType.VarChar, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.WebAdminComments));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daApprovalDate", SqlDbType.DateTime, 0,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.ApprovalDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminApprovedBy", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.AdminApprovedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.StudentID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sStudentCode", SqlDbType.VarChar, 0,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.StudentCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iApprovStudSecEmployeeID", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.ApprovStudSecEmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iApprovAcctSecEmployeeID", SqlDbType.Int, 10,
                    //                        ParameterDirection.Input, false, 0, 0, "",
                    //                        DataRowVersion.Proposed, item.ApprovAcctSecEmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,
                    //                        ParameterDirection.Input, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.CreatedBy));
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
                        throw new Exception("Stored Procedure 'USP_StudentRegistration_Insert' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of StudentSelfRegistration
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentSelfRegistration> UpdateStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> response = new BaseEntityResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentSelfRegistration_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmailID", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.EmailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPassword", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Password));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTitle", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Title));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sFirstName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMiddleName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sLastName", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsContactNumber", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.ContactNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sGender", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.Gender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.DateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCenterCode", SqlDbType.NVarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.CenterCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWebRegistrationStatus", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.WebRegistrationStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sWebAdminComments", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.WebAdminComments));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daApprovalDate", SqlDbType.DateTime, 0,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApprovalDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminApprovedBy", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.AdminApprovedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sStudentCode", SqlDbType.VarChar, 0,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.StudentCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iApprovStudSecEmployeeID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApprovStudSecEmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iApprovAcctSecEmployeeID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ApprovAcctSecEmployeeID));

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
                        throw new Exception("Stored Procedure 'dbo.USP_StudentSelfRegistration_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of StudentSelfRegistration
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentSelfRegistration> DeleteStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> response = new BaseEntityResponse<StudentSelfRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentSelfRegistration_Delete";
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
                                            DataRowVersion.Proposed, item.DeletedBy));
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
                        throw new Exception("Stored Procedure 'dbo.USP_StudentSelfRegistration_Delete' reported the ErrorCode: " +
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

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
    public class StudentIdentityCardDataProvider : DBInteractionBase, IStudentIdentityCardDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudentIdentityCardDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudentIdentityCardDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudentIdentityCard table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentIdentityCard> GetStudentIdentityCardBySearch(StudentIdentityCardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentIdentityCard> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudentIdentityCard>();
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
                    baseEntityCollection.CollectionResponse = new List<StudentIdentityCard>();
                    while (sqlDataReader.Read())
                    {
                        StudentIdentityCard item = new StudentIdentityCard();
                        item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentFullName = sqlDataReader["Title"].ToString() + " " + sqlDataReader["FirstName"].ToString() + " " + sqlDataReader["MiddleName"].ToString() + " " + sqlDataReader["LastName"].ToString();
                        item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        item.RollNumber = sqlDataReader["YearlyRollNumber"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_StudentIdentityCard_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<StudentIdentityCard> GetStudentIdentityCardByID(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> response = new BaseEntityResponse<StudentIdentityCard>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentIdentityCard_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentId));
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
                        StudentIdentityCard _item = new StudentIdentityCard();
                        _item.StudentId = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentFullName = sqlDataReader["StudentFullName"].ToString();
                        _item.StudentCode = sqlDataReader["StudentCode"].ToString();
                        _item.StudentMobileNumber = sqlDataReader["StudentMobileNumber"].ToString();
                        _item.ParentMobileNumber = sqlDataReader["ParentMobileNumber"].ToString();
                        _item.StudentIdentificationMark = sqlDataReader["IdentificationMark"].ToString();
                        _item.PermanentAddressLine1 = sqlDataReader["AddressLine1"].ToString();
                        _item.PermanentAddressLine2 = sqlDataReader["AddressLine2"].ToString();
                        _item.CorrespondenceAddressLine1 = sqlDataReader["AddressLine1_C"].ToString();
                        _item.CorrespondenceAddressLine2 = sqlDataReader["AddressLine2_C"].ToString();
                        _item.DateOfBirth = sqlDataReader["DOB"].ToString();
                        _item.Bloodgroup = sqlDataReader["BloodGroup"].ToString();


                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            _item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentSignature"]) == false)
                        {
                            _item.StudentSignature = (byte[])(sqlDataReader["StudentSignature"]);
                        }


                        _item.StudentPhotoType = sqlDataReader["StudentPhotoType"].ToString();
                        _item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"].ToString();
                        _item.StudentPhotoFileWidth = sqlDataReader["StudentPhotoFileWidth"].ToString();
                        _item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"].ToString();
                        _item.StudentPhotoFileSize = sqlDataReader["StudentPhotoFileSize"].ToString();

                        _item.StudentSignatureType = sqlDataReader["StudentSignatureType"].ToString();
                        _item.StudentSignatureFilename = sqlDataReader["StudentSignatureFilename"].ToString();
                        _item.StudentSignatureFileWidth = sqlDataReader["StudentSignatureFileWidth"].ToString();
                        _item.StudentSignatureFileHeight = sqlDataReader["StudentSignatureFileHeight"].ToString();
                        _item.StudentSignatureFileSize = sqlDataReader["StudentSignatureFileSize"].ToString();



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
        public IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> response = new BaseEntityResponse<StudentIdentityCard>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentIdentityCard_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                        ParameterDirection.Input, false, 0, 0, "",
                        DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentFullName", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StudentFullName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StudentCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.StudentMobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iParentMobileNumber", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.ParentMobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRollNumber", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.RollNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.UniversityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailID", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.SectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sAcademicYear", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AcademicYear));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniqueIdentificatinNumber", SqlDbType.Int, 10,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.UniqueIdentificatinNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cAddressType", SqlDbType.Char, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AddressType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressLine1", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PermanentAddressLine1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddressLine2", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PermanentAddressLine2));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlotNumber", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PlotNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsStreet", SqlDbType.NVarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Street));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, item.DateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Bloodgroup));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentIdentityCard_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of StudentIdentityCard
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> response = new BaseEntityResponse<StudentIdentityCard>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentIdentityCard_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentId));

                    #region Photo
                    if (item.StudentPhoto != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhoto));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhoto", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFilename != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFilename));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileWidth != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileWidth));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileHeight));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentPhotoFileHeight != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentPhotoFileSize));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentPhotoFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    #endregion Photo
                    #region Signature
                    if (item.StudentSignature != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignature));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignature", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFilename != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFilename));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFilename", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureType != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileWidth != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileWidth));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileWidth", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileHeight));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileHeight", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentSignatureFileHeight != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentSignatureFileSize));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sStudentSignatureFileSize", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    #endregion Signature
                    if (item.PermanentAddressLine1 != null && item.PermanentAddressLine1 != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPermanentAddressLine1", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PermanentAddressLine1));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPermanentAddressLine1", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.PermanentAddressLine2 != null && item.PermanentAddressLine2 != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPermanentAddressLine2", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PermanentAddressLine2));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsPermanentAddressLine2", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    //if (item.CorrespondenceAddressLine1 != null && item.CorrespondenceAddressLine1 != string.Empty)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCorrespondenceAddressLine1", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CorrespondenceAddressLine1));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCorrespondenceAddressLine1", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.CorrespondenceAddressLine2 != null && item.CorrespondenceAddressLine2 != string.Empty)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCorrespondenceAddressLine2", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CorrespondenceAddressLine2));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@nsCorrespondenceAddressLine2", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}

                    if (item.Bloodgroup != null && item.Bloodgroup != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Proposed, item.Bloodgroup));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sBloodgroup", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 5, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.DateOfBirth != null && item.DateOfBirth != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.DateOfBirth)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.StudentMobileNumber != null && item.StudentMobileNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.StudentMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ParentMobileNumber != null && item.ParentMobileNumber != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, item.ParentMobileNumber));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsParentMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 15, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.StudentIdentificationMark != null && item.StudentIdentificationMark != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, item.StudentIdentificationMark));

                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentIdentificationMark", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 50, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    }
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@nsStudentCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.StudentCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.StudentId = (Int32)cmdToExecute.Parameters["@iStudentId"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_StudentIdentityCard_Update' reported the ErrorCode: " +
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
        /// Delete a specific record of StudentIdentityCard
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> response = new BaseEntityResponse<StudentIdentityCard>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentIdentityCard_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_StudentIdentityCard_Delete' reported the ErrorCode: " +
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

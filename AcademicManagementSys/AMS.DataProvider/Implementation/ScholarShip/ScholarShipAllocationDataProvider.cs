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
    public class ScholarShipAllocationDataProvider : DBInteractionBase, IScholarShipAllocationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public ScholarShipAllocationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public ScholarShipAllocationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from ScholarShipAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));

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
                    baseEntityCollection.CollectionResponse = new List<ScholarShipAllocation>();
                    while (sqlDataReader.Read())
                    {
                        ScholarShipAllocation item = new ScholarShipAllocation();
                        item.ID = sqlDataReader["ScholarShipAllocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ScholarShipAllocationID"]);
                        item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);
                        item.TransDate = sqlDataReader["TransDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransDate"]);
                        item.ScholarSheepDocumentNumber = sqlDataReader["ScholarSheepDocumentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ScholarSheepDocumentNumber"]);
                        item.BranchDesc = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        item.ApproveStatus = sqlDataReader["ApproveStatus"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ApproveStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_ScholarShipAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from ScholarShipAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationRequestForApproval(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_GetRequestForApproval";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.PersonID));
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
                    baseEntityCollection.CollectionResponse = new List<ScholarShipAllocation>();
                    while (sqlDataReader.Read())
                    {
                        ScholarShipAllocation item = new ScholarShipAllocation();

                        item.ID = sqlDataReader["ScholarShipAllocationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ScholarShipAllocationID"]);
                        item.ScholarSheepDocumentNumber = sqlDataReader["ScholarSheepDocumentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ScholarSheepDocumentNumber"]);
                        item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);
                        item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        item.StudentPhotoFileSize = sqlDataReader["StudentPhotoFileSize"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentPhotoFileSize"]);
                        item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileHeight"]);
                        item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFilename"]);
                        item.StudentPhotoType = sqlDataReader["StudentPhotoType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoType"]);
                        item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]);
                        item.SectionDetailDescription = sqlDataReader["SectionDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SectionDescription"]);
                        item.ScholarShipDescription = sqlDataReader["ScholarShipDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ScholarShipDescription"]);
                        item.Amount = sqlDataReader["FixAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["FixAmount"]);
                        item.FeeAccountSubTypeDesc = sqlDataReader["FeeAccountSubTypeDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FeeAccountSubTypeDesc"]);
                        item.AccountID = sqlDataReader["AccountID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountID"]);
                        item.FeeAccountTypeCode = sqlDataReader["FeeAccountTypeCode"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["FeeAccountTypeCode"]);
                        item.CrDrStatusFlag = sqlDataReader["CrDrStatusFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CrDrStatusFlag"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ScholarShipAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from ScholarShipAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetStudentListBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_StudentSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.BranchID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<ScholarShipAllocation>();
                    while (sqlDataReader.Read())
                    {
                        ScholarShipAllocation item = new ScholarShipAllocation();
                        item.StudentID= sqlDataReader["StudentID"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentAmissionDetailID = sqlDataReader["StudentAmissionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentAmissionDetailID"]); 
                        item.StudentName= sqlDataReader["StudentName"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentName"]); 
                        item.AcademicYearID= sqlDataReader["AcademicYearID"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["AcademicYearID"]); 
                        item.BranchID= sqlDataReader["BranchID"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["BranchID"]); 
                        item.AdmissionPatternID= sqlDataReader["AdmissionPatternID"] is DBNull ? 0 :  Convert.ToInt32(sqlDataReader["AdmissionPatternID"]); 
                        item.CourseYearId= sqlDataReader["CourseYearId"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["CourseYearId"]); 
                        item.Gender= sqlDataReader["Gender"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["Gender"]); 
                        item.EnrollmentNumber= sqlDataReader["EnrollmentNumber"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["EnrollmentNumber"]); 
                        item.StandardNumber= sqlDataReader["StandardNumber"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StandardNumber"]); 
                        item.SectionDetailID= sqlDataReader["SectionDetailID"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["SectionDetailID"]); 
                        item.OldSectionDetailID= sqlDataReader["OldSectionDetailID"] is DBNull ? 0  :  Convert.ToInt32(sqlDataReader["OldSectionDetailID"]); 
                        item.AdmitAcademicYear= sqlDataReader["AdmitAcademicYear"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["AdmitAcademicYear"]); 
                        item.StudentEmailID= sqlDataReader["StudentEmailID"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentEmailID"]); 
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }                        
                        item.StudentPhotoFileHeight= sqlDataReader["StudentPhotoFileHeight"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentPhotoFileHeight"]); 
                        item.StudentPhotoFilename= sqlDataReader["StudentPhotoFilename"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentPhotoFilename"]); 
                        item.StudentSignatureFileSize= sqlDataReader["StudentSignatureFileSize"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentSignatureFileSize"]); 
                        item.StudentPhotoFileWidth= sqlDataReader["StudentPhotoFileWidth"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentPhotoFileWidth"]); 
                        item.StudentPhotoType= sqlDataReader["StudentPhotoType"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["StudentPhotoType"]); 
                        item.BranchDescription= sqlDataReader["BranchDescription"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["BranchDescription"]); 
                        item.BranchShortCode= sqlDataReader["BranchShortCode"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["BranchShortCode"]); 
                        item.AdmissionPattern= sqlDataReader["AdmissionPattern"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["AdmissionPattern"]); 
                        item.CourseYearDesc= sqlDataReader["CourseYearDesc"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["CourseYearDesc"]); 
                        item.CourseYearCode= sqlDataReader["CourseYearCode"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["CourseYearCode"]); 
                        item.SectionDetailsDesc= sqlDataReader["SectionDetailsDesc"] is DBNull ? string.Empty  :  Convert.ToString(sqlDataReader["SectionDetailsDesc"]);
                        item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]); 
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ScholarShipAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from ScholarShipAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetCourseYearList(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_CourseSearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<ScholarShipAllocation>();
                    while (sqlDataReader.Read())
                    {
                        ScholarShipAllocation item = new ScholarShipAllocation();
                        item.BranchID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.BranchDesc = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ScholarShipAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from ScholarShipAllocation table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipList(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_ScholarShipList";
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
                    baseEntityCollection.CollectionResponse = new List<ScholarShipAllocation>();
                    while (sqlDataReader.Read())
                    {
                        ScholarShipAllocation item = new ScholarShipAllocation();
                        item.ScholarShipMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.ScholarShipDescription = Convert.ToString(sqlDataReader["ScholarShipDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_ScholarShipAllocation_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<ScholarShipAllocation> GetScholarShipAllocationByID(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> response = new BaseEntityResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_SelectOne";
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
                        ScholarShipAllocation _item = new ScholarShipAllocation();
                        _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.StudentID = Convert.ToInt32(sqlDataReader["StudentID"]);
                        _item.ScholarShipMasterID = Convert.ToInt32(sqlDataReader["ScholarShipMasterID"]);
                        _item.TransDate = Convert.ToString(sqlDataReader["TransDate"]);
                        _item.ScholarSheepDocumentNumber = sqlDataReader["ScholarSheepDocumentNumber"].ToString();
                        _item.IsApproved = Convert.ToBoolean(sqlDataReader["IsApproved"]);
                        _item.ApporvedBy = Convert.ToInt32(sqlDataReader["ApporvedBy"]);
                        _item.ApproveStatus = Convert.ToString(sqlDataReader["ApproveStatus"]);
                        _item.LastSectionDetailID = Convert.ToInt32(sqlDataReader["LastSectionDetailID"]);

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
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> response = new BaseEntityResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iScholarShipMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ScholarShipMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentAmissionDetailID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentAmissionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSectionDetailId", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SectionDetailId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStandarNumber", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StandarNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastSectionDetailID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LastSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarSheepDocumentNumber", SqlDbType.NVarChar, 30,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ScholarSheepDocumentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));

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
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_ScholarShipAllocation_INSERT' reported the ErrorCode: " +_errorCode);
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
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocationApproveRequest(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> response = new BaseEntityResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocationRequestApproval_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    if (!string.IsNullOrEmpty(item.XMLstring))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.XMLstring));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iScholarShipAllocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ScholarShipAllocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bRequestApprovedStatus", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RequestApprovedStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iPersonID", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PersonID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStageSequenceNumber", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StageSequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTaskNotificationDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TaskNotificationDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralTaskReportingDetailsID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralTaskReportingDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLast", SqlDbType.Bit, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLastRecord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_ScholarShipAllocation_INSERT' reported the ErrorCode: " +_errorCode);
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
        /// Update a specific record of ScholarShipAllocation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> UpdateScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> response = new BaseEntityResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iScholarShipMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ScholarShipMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daTransDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.TransDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarSheepDocumentNumber", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.ScholarSheepDocumentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsApproved", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsApproved));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iApporvedBy", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ApporvedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bApproveStatus", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ApproveStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastSectionDetailID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.LastSectionDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ModifiedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_ScholarShipAllocation_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of ScholarShipAllocation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> DeleteScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> response = new BaseEntityResponse<ScholarShipAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_ScholarShipAllocation_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_ScholarShipAllocation_Delete' reported the ErrorCode: " +
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

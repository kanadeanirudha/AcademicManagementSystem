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
    public class OnlineExamAssignpapersetterDataProvider : DBInteractionBase, IOnlineExamAssignpapersetterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamAssignpapersetterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamAssignpapersetterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExamAssignpapersetter table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterBySearch(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamPaperSetter_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenSessionMaster", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GenSessionMaster));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSemesterMstID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SemesterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMaster", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamAssignpapersetter>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamAssignpapersetter item = new OnlineExamAssignpapersetter();

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearID"]) == false)
                        {
                            item.CourseYearID = Convert.ToInt32(sqlDataReader["CourseYearID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationCourseApplicableID"]) == false)
                        {
                            item.OnlineExamExaminationCourseApplicableID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationCourseApplicableID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationFor"]) == false)
                        {
                            item.ExaminationFor = Convert.ToString(sqlDataReader["ExaminationFor"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamSubjectGroupScheduleID"]) == false)
                        {
                            item.OnlineExamSubjectGroupScheduleID = Convert.ToInt16(sqlDataReader["OnlineExamSubjectGroupScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SemesterMstID"]) == false)
                        {
                            item.SemesterMstID = Convert.ToInt32(sqlDataReader["SemesterMstID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupID"]) == false)
                        {
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDescription"]) == false)
                        {
                            item.SubjectGroupDescription = Convert.ToString(sqlDataReader["SubjectGroupDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectShortDescription"]) == false)
                        {
                            item.SubjectShortDescription = Convert.ToString(sqlDataReader["SubjectShortDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuestionPaperID"]) == false)
                        {
                            item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]) == false)
                        {
                            item.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperSet"]) == false)
                        {
                            item.PaperSet = Convert.ToString(sqlDataReader["PaperSet"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamAllocateJobSupportStaff"]) == false)
                        {
                            item.OnlineExamAllocateJobSupportStaff = Convert.ToString(sqlDataReader["OnlineExamAllocateJobSupportStaff"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFinal"]) == false)
                        {
                            item.IsFinal = Convert.ToBoolean(sqlDataReader["IsFinal"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsSelected"]) == false)
                        {
                            item.IsSelected = Convert.ToBoolean(sqlDataReader["IsSelected"]);
                        }
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamAssignpapersetter_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamSupportStaffSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSupportStaff_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectGroupId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGlobalSessionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.GlobalSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamAssignpapersetter>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamAssignpapersetter item = new OnlineExamAssignpapersetter();
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]) == false)
                        {
                            item.OnlineExamAllocateJobSupportStaffID = Convert.ToInt32(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AllotedJobName"]) == false)
                        {
                            item.AllotedJobName = Convert.ToString(sqlDataReader["AllotedJobName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AllotedJobCode"]) == false)
                        {
                            item.AllotedJobCode = Convert.ToString(sqlDataReader["AllotedJobCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobAllotedForCentreCode"]) == false)
                        {
                            item.JobAllotedForCentreCode = Convert.ToString(sqlDataReader["JobAllotedForCentreCode"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamAllocateSupportStaffID"]) == false)
                        {
                            item.OnlineExamAllocateSupportStaffID = Convert.ToInt32(sqlDataReader["OnlineExamAllocateSupportStaffID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupId"]) == false)
                        {
                            item.SubjectGroupId = Convert.ToInt32(sqlDataReader["SubjectGroupId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoleMasterID"]) == false)
                        {
                            item.RoleMasterID = Convert.ToInt32(sqlDataReader["RoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = Convert.ToString(sqlDataReader["EmployeeFirstName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                            item.EmployeeLastName = Convert.ToString(sqlDataReader["EmployeeLastName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            item.EmployeeMiddleName = Convert.ToString(sqlDataReader["EmployeeMiddleName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FullName"]) == false)
                        {
                            item.FullName = Convert.ToString(sqlDataReader["FullName"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamSupportStaff_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterSearchList(OnlineExamAssignpapersetterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAssignpapersetter> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSupportStaff_SearchList";
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode ", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectGroupId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGlobalSessionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.GlobalSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamAssignpapersetter>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamAssignpapersetter item = new OnlineExamAssignpapersetter();
                      
                        {
                            item.FullName = Convert.ToString(sqlDataReader["FullName"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamSupportStaff_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// 
       
        public IBaseEntityResponse<OnlineExamAssignpapersetter> GetOnlineExamAssignpapersetterByID(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> response = new BaseEntityResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAssignpapersetter_SelectOne";
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
                        OnlineExamAssignpapersetter _item = new OnlineExamAssignpapersetter();
                        ////_item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        //_item.UnitName = sqlDataReader["UnitName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitName"]);
                        //_item.GeneralUnitTypeID = sqlDataReader["GeneralUnitTypeID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["GeneralUnitTypeID"].ToString());
                        //_item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        //_item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //_item.LocationAddress = sqlDataReader["LocationAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LocationAddress"]);
                        //_item.CityId = sqlDataReader["CityId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityId"]);
                        //_item.UnitType = sqlDataReader["UnitType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UnitType"]);
                        //_item.Relatedwith = sqlDataReader["RelatedWith"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["RelatedWith"]);
                        //if (_item.Relatedwith == 1)
                        //{
                        //    _item.RelatedwithUnitType = "Manufacturing";
                        //}
                        //else if (_item.Relatedwith == 2)
                        //{
                        //    _item.RelatedwithUnitType = "Sales";
                        //}
                        //else if (_item.Relatedwith == 3)
                        //{
                        //    _item.RelatedwithUnitType = "Purchase";
                        //}
                        //else if (_item.Relatedwith == 4)
                        //{
                        //    _item.RelatedwithUnitType = "Warehouse";
                        //}
                        //else if (_item.Relatedwith == 5)
                        //{
                        //    _item.RelatedwithUnitType = "Processing";
                        //}
                        //_item.CentreName = sqlDataReader["CentreName"].ToString();
                        //_item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        //_item.CityName = sqlDataReader["CityName"].ToString();
                        //response.Entity = _item;
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
        public IBaseEntityResponse<OnlineExamAssignpapersetter> InsertOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> response = new BaseEntityResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamPaperSetter_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                          ParameterDirection.Output, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cPaperSet", SqlDbType.Char, 200,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PaperSet));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamSubjectGroupScheduleID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamSubjectGroupScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamAllocateJobSupportStaffID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamAllocateJobSupportStaffID));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.OnlineExamExaminationQuestionPaperID = (int)cmdToExecute.Parameters["@iID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamAssignpapersetter_Insert' reported the ErrorCode: " +
                                            _errorCode);
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
        /// Update a specific record of OnlineExamAssignpapersetter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> UpdateOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> response = new BaseEntityResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAssignpapersetter_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterName", SqlDbType.NVarChar, 60,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

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
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamAssignpapersetter_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of GeneralPaperSetMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAssignpapersetter> DeleteOnlineExamAssignpapersetter(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> response = new BaseEntityResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAssignpapersetter_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamAssignpapersetter_Delete' reported the ErrorCode: " + _errorCode);
                    }

            //        if (_rowsAffected > 0)
            //        {
            //            response.Entity = item;
            //        }
            //        else
            //        {
            //            response.Message.Add(new MessageDTO
            //            {
            //                ErrorMessage = "Create failed"
            //            });
            //        }
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

        public IBaseEntityResponse<OnlineExamAssignpapersetter> OnlineExamSelectQuestionPaper(OnlineExamAssignpapersetter item)
        {
            IBaseEntityResponse<OnlineExamAssignpapersetter> response = new BaseEntityResponse<OnlineExamAssignpapersetter>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamSelectQuestionPaper";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 25)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamSelectQuestionPaper' reported the ErrorCode: " + _errorCode);
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

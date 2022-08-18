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
    public class OnlineExamExaminationCourseApplicableDataProvider : DBInteractionBase, IOnlineExamExaminationCourseApplicableDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamExaminationCourseApplicableDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamExaminationCourseApplicableDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExamExaminationCourseApplicable table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 300, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //   cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationCourseApplicable>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationCourseApplicable item = new OnlineExamExaminationCourseApplicable();
                        //Passing Parameter From OnlineExamExaminationCourseApplicable
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.OnlineExamExaminationMasterId = sqlDataReader["OnlineExamExaminationMasterId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterId"]);
                        item.CourseYearID = sqlDataReader["CourseYearID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["CourseYearID"]);

                        //Passing Field Data From OrgCourse Year Details
                        item.Description = sqlDataReader["Description"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["Description"]);
                        item.DepartmentID = sqlDataReader["DepartmentID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["DepartmentID"]);

                        //Passing Field Data From OrgSemesterMaster

                        //Passing Field From OrgDepartment Master 
                        item.DepartmentName = sqlDataReader["DepartmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DepartmentName"]);
                        item.ExaminationStartDate = sqlDataReader["ExaminationStartDate"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["ExaminationStartDate"]);
                        item.ExaminationEndDate = sqlDataReader["ExaminationEndDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExaminationEndDate"]);
                        item.ResultAnnounceDate = sqlDataReader["ResultAnnounceDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ResultAnnounceDate"]);

                        //Passing parameter From OnlineExamExaminationMaster
                        //item.OnlineExamExaminationMasterID = sqlDataReader["OnlineExamExaminationMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        item.ExaminationName = sqlDataReader["ExaminationName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExaminationName"]);
                        item.Purpose = sqlDataReader["Purpose"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Purpose"]);
                        item.AcadSessionId = sqlDataReader["AcadSessionId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["AcadSessionId"]);
                        item.ExaminationFor = sqlDataReader["ExaminationFor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ExaminationFor"]);
                        item.Semester = sqlDataReader["OrgSemesterName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrgSemesterName"]);

                        item.IsResultAnnounce = sqlDataReader["IsResultAnnounce"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsResultAnnounce"]);
                        item.IsAllChecked = sqlDataReader["IsAllChecked"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsAllChecked"]);

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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationCourseApplicable>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamExaminationCourseApplicable item = new OnlineExamExaminationCourseApplicable();
                        //if (DBNull.Value.Equals(sqlDataReader["SessionName"]) == false)
                        //{
                        //    item.SessionName = Convert.ToString(sqlDataReader["SessionName"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
                        //{
                        //    item.MenuLink = Convert.ToString(sqlDataReader["MenuLink"]);
                        //}
                        baseEntityCollection.CollectionResponse.Add(item);
                    }



                    //while (sqlDataReader.Read())
                    //{
                    //    OnlineExamExaminationCourseApplicable item = new OnlineExamExaminationCourseApplicable();
                    //    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    //    //item.GroupDescription = sqlDataReader["GroupDescription"].ToString();
                    //    //item.MarchandiseGroupCode = Convert.ToString(sqlDataReader["MarchandiseGroupCode"]);
                    //    baseEntityCollection.CollectionResponse.Add(item);
                    //}
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OnlineExamExaminationCourseApplicable table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        //public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetSessionNameList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        //{
        //    //throw new NotImplementedException();
        //    IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(searchRequest.ConnectionString))
        //        {
        //            baseEntityCollection.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _mainConnection.ConnectionString = searchRequest.ConnectionString;

        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_SearchListForDropDown";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
        //            //-----------------------------------------------------Input Parameters ------------------------------------------------------------------
        //            //scmdToExecute.Parameters.Add(new SqlParameter("@iStatusFlag", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StatusFlag));

        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            sqlDataReader = cmdToExecute.ExecuteReader();

        //            baseEntityCollection.CollectionResponse = new List<OnlineExamExaminationCourseApplicable>();
        //            while (sqlDataReader.Read())
        //            {
        //                OnlineExamExaminationCourseApplicable item = new OnlineExamExaminationCourseApplicable();
        //                if (DBNull.Value.Equals(sqlDataReader["SessionName"]) == false)
        //                {
        //                    item.SessionName = Convert.ToString(sqlDataReader["SessionName"]);
        //                }
        //                if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
        //                {
        //                    item.ID = Convert.ToInt32(sqlDataReader["ID"]);
        //                }
        //                //if (DBNull.Value.Equals(sqlDataReader["MenuLink"]) == false)
        //                //{
        //                //    item.MenuLink = Convert.ToString(sqlDataReader["MenuLink"]);
        //                //}
        //                baseEntityCollection.CollectionResponse.Add(item);
        //            }

        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }
        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseEntityCollection.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return baseEntityCollection;
        //}        

        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableByID(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_SelectOne";
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
                        OnlineExamExaminationCourseApplicable _item = new OnlineExamExaminationCourseApplicable();
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
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterId", SqlDbType.Int, 4,
                                          ParameterDirection.Input, true, 10, 0, "",
                                          DataRowVersion.Proposed, item.OnlineExamExaminationMasterId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CourseYearID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSemesterMstID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SemesterMstID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iExaminationStatus", SqlDbType.Int, 4,
                                          ParameterDirection.Input, false, 10, 0, "",
                                          DataRowVersion.Proposed, item.ExaminationStatus));

                    cmdToExecute.Parameters.Add(new SqlParameter("nsExaminationStartDate", SqlDbType.DateTime, 0,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.ExaminationStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("nsExaminationEndDate", SqlDbType.DateTime, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.ExaminationEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("nsResultAnnounceDate", SqlDbType.DateTime, 0,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.ResultAnnounceDate));

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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iOnlineExamExaminationCourseApplicableID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationCourseApplicable_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of OnlineExamExaminationCourseApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_Update";
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
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamExaminationCourseApplicable_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OnlineExamExaminationCourseApplicable
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationCourseApplicable_Delete";
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry && _errorCode != 30)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item)
        {
            IBaseEntityResponse<OnlineExamExaminationCourseApplicable> response = new BaseEntityResponse<OnlineExamExaminationCourseApplicable>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExamination_AnnounceResult";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationCourseApplicable_Delete' reported the ErrorCode: " + _errorCode);
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

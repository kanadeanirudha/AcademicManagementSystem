using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//using AMS.DataProvider.Implementation.OnlineExam;

namespace AMS.DataProvider
{
    public class OnlineExamAllocateSupportStaffDataProvider : DBInteractionBase, IOnlineExamAllocateSupportStaffDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExamAllocateSupportStaffDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExamAllocateSupportStaffDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from OnlineExamAllocateSupportStaff table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateJobAndSupportStaff_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 250, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSessionId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SessionId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iExaminationID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamAllocateSupportStaff>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamAllocateSupportStaff item = new OnlineExamAllocateSupportStaff();

                          item.OnlineExamAllocateSupportStaffID = sqlDataReader["OnlineExamAllocateSupportStaffId"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamAllocateSupportStaffId"]);
                           item.OnlineExamExaminationMasterID = sqlDataReader["OnlineExamExaminationMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                           item.OnlineExamAllocateJobSupportStaffID = sqlDataReader["OnlineExamAllocateJobSupportStaffID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]);
                           item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);
                           item.EmployeeFullName = sqlDataReader["EmployeeFullName"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["EmployeeFullName"]);
                           item.ExaminationName = sqlDataReader["ExaminationName"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["ExaminationName"]);
                           item.SubjectCode = sqlDataReader["SubjectCode"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["SubjectCode"]);
                           item.AllotedJobName = sqlDataReader["AllotedJobName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllotedJobName"]);
                           item.AllotedJobCode = sqlDataReader["AllotedJobCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AllotedJobCode"]);
                           item.JobStartDate = sqlDataReader["JobStartDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["JobStartDate"]);
                           item.JobEndDate = sqlDataReader["JobEndDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["JobEndDate"]);
                           item.JobAllotedForCentreCode = sqlDataReader["JobAllotedForCentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["JobAllotedForCentreCode"]);
                           item.SubjectName = sqlDataReader["SubjectName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubjectName"]);
                           item.AcademicSessionID = sqlDataReader["AcadSessionID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["AcadSessionID"]);
                           item.RoleMasterID = sqlDataReader["RoleMasterID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["RoleMasterID"]);
                           item.SubjectGroupId = sqlDataReader["SubjectGroupId"] is DBNull ? new Int32 () : Convert.ToInt32(sqlDataReader["SubjectGroupId"]);
                           item.JobStatusFlag = sqlDataReader["JobStatusFlag"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["JobStatusFlag"]);

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
                        throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<OnlineExamAllocateSupportStaff>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamAllocateSupportStaff item = new OnlineExamAllocateSupportStaff();
                        //if (DBNull.Value.Equals(sqlDataReader["SessionName"]) == false)
                        //{
                        //    item. = Convert.ToString(sqlDataReader["SessionName"]);
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
                    //    OnlineExamAllocateSupportStaff item = new OnlineExamAllocateSupportStaff();
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_SearchList' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from OnlineExamAllocateSupportStaff table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        //public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetSessionNameList(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        //{
        //    //throw new NotImplementedException();
        //    IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamAllocateSupportStaff>();
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
        //            cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_SearchListForDropDown";
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

        //            baseEntityCollection.CollectionResponse = new List<OnlineExamAllocateSupportStaff>();
        //            while (sqlDataReader.Read())
        //            {
        //                OnlineExamAllocateSupportStaff item = new OnlineExamAllocateSupportStaff();
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
        //                throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffByID(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamAllocateJobSupportStaffID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamAllocateJobSupportStaffID));
                    
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
                        OnlineExamAllocateSupportStaff _item = new OnlineExamAllocateSupportStaff();
                        // item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.EmployeeFullName = sqlDataReader["EmployeeFullName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeFullName"]);
                        _item.AllotedJobName = sqlDataReader["AllotedJobName"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["AllotedJobName"]);
                        _item.AllotedJobCode = sqlDataReader["AllotedJobCode"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["AllotedJobCode"]);
                        _item.JobStartDate = sqlDataReader["JobStartDate"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["JobStartDate"]);
                        _item.JobEndDate = sqlDataReader["JobEndDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["JobEndDate"]);
                        _item.OnlineExamAllocateJobSupportStaffID=sqlDataReader["OnlineExamAllocateJobSupportStaffID"] is DBNull?new Int32():Convert.ToInt32(sqlDataReader["OnlineExamAllocateJobSupportStaffID"]);
                        _item.OnlineExamAllocateSupportStaffID=sqlDataReader["OnlineExamAllocateSupportStaffID"] is DBNull ? new Int32():Convert.ToInt32(sqlDataReader["OnlineExamAllocateSupportStaffID"]);
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
                //_logException.Error(ex.Message);
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
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                   
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeId", SqlDbType.Int, 4,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.EmployeeID));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                  
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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iOnlineExamAllocateSupportStaffID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_OnlineExamAllocateSupportStaff_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of OnlineExamAllocateSupportStaff
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_Update";
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
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineExamAllocateSupportStaff_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of OnlineExamAllocateSupportStaff
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateSupportStaff_Delete";
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_errorCode != (int)ErrorEnum.AllOk)
                        if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> response = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamAllocateJobSupportStaff_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                   

                 
                 
                    //Fields From OnlineExamAllocateJobSupportStaff


                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamAllocateSupportStaffID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.OnlineExamAllocateSupportStaffID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAllotedJobName", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AllotedJobName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAllotedJobCode", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AllotedJobCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@dtJobStartDate", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.JobStartDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtJobEndDate", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.JobEndDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupId", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.SubjectGroupId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAcademicSessionID", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.AcademicSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNotificationNeedToSentCompulsory", SqlDbType.Bit, 0,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.IsNotificationNeedToSentCompulsory));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 35,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.CentreCode));
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
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iOnlineExamAllocateSupportStaffID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_OnlineExamAllocateSupportStaff_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamAllocateSupportStaff_Insert' reported the ErrorCode: " +
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
        #endregion
    }
}

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
    public class OnlineEntranceExamQuestionBankMasterDataProvider : DBInteractionBase, IOnlineEntranceExamQuestionBankMasterDataProvider
    {

        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        public OnlineEntranceExamQuestionBankMasterDataProvider()
        {
        }

        /// Constructor to initialized data member and member functions
        public OnlineEntranceExamQuestionBankMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation

        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetOnlineEntranceExamQuestionBankMasterSelectAll(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamQuestionBankMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineEntranceExamQuestionBankMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineEntranceExamQuestionBankMaster item = new OnlineEntranceExamQuestionBankMaster();
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankMasterID"]) == false)
                        {
                            item.OnlineExamQuestionBankMasterID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDesc"]) == false)
                        {
                            item.SubjectGroupDesc = sqlDataReader["SubjectGroupDesc"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectGroupDetailsID"]) == false)
                        {
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectGroupDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"]) == false)
                        {
                            item.SubjectName = sqlDataReader["SubjectName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAcademic"]) == false)
                        {
                            item.IsAcademic = Convert.ToInt16(sqlDataReader["IsAcademic"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"]) == false)
                        {
                            item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageType"]) == false)
                        {
                            item.ImageType = sqlDataReader["ImageType"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageName"]) == false)
                        {
                            item.ImageName = sqlDataReader["ImageName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsQuestionInImage"]) == false)
                        {
                            item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        }
                       
                        if (DBNull.Value.Equals(sqlDataReader["OptionImage"]) == false)
                        {
                            item.OptionImage = sqlDataReader["OptionImage"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionText"]) == false)
                        {
                            item.OptionText = sqlDataReader["OptionText"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GeneralQuestionLevelMasterID"]) == false)
                        {
                            item.GeneralQuestionLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralQuestionLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsAnswer"]) == false)
                        {
                            item.IsAnswer = Convert.ToBoolean(sqlDataReader["IsAnswer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineQuestionBankDetailsID"]) == false)
                        {
                            item.OnlineQuestionBankDetailsID = Convert.ToInt32(sqlDataReader["OnlineQuestionBankDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamQuestionBankAnsDetID"]) == false)
                        {
                            item.OnlineExamQuestionBankAnsDetailsID = Convert.ToInt32(sqlDataReader["OnlineExamQuestionBankAnsDetID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineEntranceExamQuestionBankMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from table by ID.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> SelectOnlineEntranceExamQuestionBankMasterByID(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamQuestionBankMaster_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
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
                        OnlineEntranceExamQuestionBankMaster _item = new OnlineEntranceExamQuestionBankMaster();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);

                        //_item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        //_item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        //_item.ImageType = sqlDataReader["ImageType"].ToString();
                        //_item.ImageName = sqlDataReader["ImageName"].ToString();
                        //_item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        //_item.LastAppearedInExamID = Convert.ToInt32(sqlDataReader["LastAppearedInExamID"]);
                        //_item.AppearDate = Convert.ToString(sqlDataReader["AppearDate"]);

                        //response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamQuestionBankMaster_SelectOne' reported the ErrorCode: " + _errorCode);
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


        /// Create new subject of the question bank.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertSubjectOnlineExamQuestionBank(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SubjectForOnlineEntranceExamQuestionBank_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //----------------------------OUTPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    ////----------------------------INPUT PARAM----------------------------------
                    //cmdToExecute.Parameters.Add(new SqlParameter("@tiGenQuestionTypeID", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenQuestionTypeID));
                    //if (item.SubjectID == 0)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //else
                    //{
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                    //}
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CourseYearDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iIsAcademic", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAcademic));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOldOnlineExamQuestionBankMasterID", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

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
                        item.OnlineExamQuestionBankMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SubjectForOnlineEntranceExamQuestionBank_Insert' reported the ErrorCode: " + _errorCode);
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


        /// Create new record of the table.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> InsertOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamQuestionBankMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    ////----------------------------OUTPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankDetailsID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineQuestionBankDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    ////----------------------------INPUT PARAM----------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenQuestionTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralQuestionTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralQuestionLevelID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GeneralQuestionLevelID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSyllabusGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SyllabusGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSyllabusGroupDetID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SyllabusGroupDetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSyllabusTopicGroupID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SyllabusTopicGroupID));
                    if (item.QuestionLableText != "-")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionLableText));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageType != null ? item.ImageType.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageName != null ? item.ImageName.Trim() : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionInImage", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionInImage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastAppearedInExamID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daAppearDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xXmlOnlineExamQuestionBankMaster", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SelectedXml.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));

                    //if (item.SubjectID == 0)
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                    //}

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
                        item.OnlineExamQuestionBankMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamQuestionBankMaster_InsertXML' reported the ErrorCode: " + _errorCode);
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


        /// Update a specific record of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> UpdateOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamQuestionBankMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenQuestionTypeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.SubjectID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsQuestionLableText", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.QuestionLableText));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sImageType", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sImageName", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ImageName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsQuestionInImage", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsQuestionInImage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLastAppearedInExamID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LastAppearedInExamID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daAppearDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AppearDate));

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
                    item.OnlineExamQuestionBankMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamQuestionBankMaster_Update' reported the ErrorCode: " +
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

        /// Delete a specific record of OnlineEntranceExamQuestionBankMaster.
        public IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> DeleteOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster item)
        {
            IBaseEntityResponse<OnlineEntranceExamQuestionBankMaster> response = new BaseEntityResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineEntranceExamSubjectsQuestion_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankAnsDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.OnlineExamQuestionBankAnsDetailsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.DeletedBy));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_OnlineEntranceExamSubjectsQuestion_Delete' reported the ErrorCode: " +
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


        /// Select all record from OnlineEntranceExamQuestionBankMaster table with search parameters
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseByCentreCodeAndUniversity(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CourseDetailsFromUniversityAndDepartment_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SelectedCentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUniversityID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SelectedUniversityID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineEntranceExamQuestionBankMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineEntranceExamQuestionBankMaster item = new OnlineEntranceExamQuestionBankMaster();
                        if (DBNull.Value.Equals(sqlDataReader["OrgBranchDetailsID"]) == false)
                        {
                            item.OrgBranchDetailsID = Convert.ToInt32(sqlDataReader["OrgBranchDetailsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OrgBranchMasterID"]) == false)
                        {
                            item.OrgBranchMasterID = Convert.ToInt32(sqlDataReader["OrgBranchMasterID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["BranchDescription"]) == false)
                        {
                            item.BranchDescription = sqlDataReader["BranchDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["BranchShortCode"]) == false)
                        {
                            item.BranchShortCode = sqlDataReader["BranchShortCode"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CourseDetailsFromUniversityAndDepartment_SearchList' reported the ErrorCode: " + _errorCode);
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

        //GetCourseYearFromBranchMasterID
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetCourseYearFromBranchMasterID(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_CourseYearDetailsFromBranchMaster_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBranchMaster", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SelectedCourseID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineEntranceExamQuestionBankMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineEntranceExamQuestionBankMaster item = new OnlineEntranceExamQuestionBankMaster();
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailsID"]) == false)
                        {
                            item.SelectedCourseYearID = sqlDataReader["CourseYearDetailsID"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailsDescription"]) == false)
                        {
                            item.CourseYearDetailsDescription = sqlDataReader["CourseYearDetailsDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CourseYearCode"]) == false)
                        {
                            item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
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
                        throw new Exception("Stored Procedure 'dbo.USP_CourseYearDetailsFromBranchMaster_SearchList' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetSubjectGroupFromCourseYearDetail(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetSubjectGroupFromCourseYearDetail_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCourseYearID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CourseYearID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineEntranceExamQuestionBankMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineEntranceExamQuestionBankMaster item = new OnlineEntranceExamQuestionBankMaster();
                        if (DBNull.Value.Equals(sqlDataReader["SubjectgroupID"]) == false)
                        {
                            //item.SubjectgroupID = Convert.ToInt32(sqlDataReader["SubjectgroupID"]);
                            item.SubjectGroupID = Convert.ToInt32(sqlDataReader["SubjectgroupID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["SubjectID"]) == false)
                        {
                            item.SubjectID = Convert.ToInt32(sqlDataReader["SubjectID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"]) == false)
                        {
                            item.SubjectName = sqlDataReader["SubjectName"].ToString();
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
                        throw new Exception("Stored Procedure 'dbo.USP_CourseYearDetailsFromBranchMaster_SearchList' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from GeneralQuestionLevelMasterList table with search parameters
        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterList(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GeneralQuestionLevelMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralQuestionLevelMaster_SelectAll";
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
                    //DataTable dt = new DataTable();
                    //dt.Load(sqlDataReader);
                    baseEntityCollection.CollectionResponse = new List<GeneralQuestionLevelMaster>();
                    while (sqlDataReader.Read())
                    {
                        GeneralQuestionLevelMaster item = new GeneralQuestionLevelMaster();
                        if (DBNull.Value.Equals(sqlDataReader["GeneralQuestionLevelMasterID"]) == false)
                        {
                            item.GeneralQuestionLevelMasterID = Convert.ToInt32(sqlDataReader["GeneralQuestionLevelMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LevelCode"]) == false)
                        {
                            item.LevelCode = sqlDataReader["LevelCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LevelDescription"]) == false)
                        {
                            item.LevelDescription = sqlDataReader["LevelDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralQuestionLevelMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from GetSyllabusGroupUnitList table with search parameters
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupUnitList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrganisationSyllabusUnitBySubjectGrpID_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSubjectGroupID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SubjectGroupID));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSyllabusGroupMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSyllabusGroupMaster item = new OrganisationSyllabusGroupMaster();
                        if (DBNull.Value.Equals(sqlDataReader["SyllabusGroupID"]) == false)
                        {
                            item.SyllabusGroupID = Convert.ToInt32(sqlDataReader["SyllabusGroupID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SyllabusGroupDetID"]) == false)
                        {
                            item.SyllabusGroupDetID = Convert.ToInt32(sqlDataReader["SyllabusGroupDetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UnitDescription"]) == false)
                        {
                            item.UnitDescription = sqlDataReader["UnitDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_OrganisationSyllabusUnitBySubjectGrpID_SelectAll' reported the ErrorCode: " + _errorCode);
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


        /// Select all record from SyllabusGroupTopicMasterList table with search parameters
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetSyllabusGroupTopicMasterList(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgSyllabusTopicBySubGrpIDAndSyllabusGrpID_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSyllabusGroupID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SyllabusGroupID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSyllabusGroupDetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SyllabusGroupDetID));

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
                    baseEntityCollection.CollectionResponse = new List<OrganisationSyllabusGroupMaster>();
                    while (sqlDataReader.Read())
                    {
                        OrganisationSyllabusGroupMaster item = new OrganisationSyllabusGroupMaster();
                        if (DBNull.Value.Equals(sqlDataReader["SyllabusGrpTopicsID"]) == false)
                        {
                            item.SyllabusGrpTopicsID = Convert.ToInt32(sqlDataReader["SyllabusGrpTopicsID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TopicName"]) == false)
                        {
                            item.TopicName = sqlDataReader["TopicName"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_OrgSyllabusTopicBySubGrpIDAndSyllabusGrpID_SearchList' reported the ErrorCode: " + _errorCode);
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



        /// Select all record from QuestionBankAndDetailList table with search parameters
        public IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> GetQuestionBankAndDetailList(OnlineEntranceExamQuestionBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<OnlineEntranceExamQuestionBankMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetQuestionAndOptionDetailList_ViewList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamQuestionBankAnsDetailsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamQuestionBankAnsDetailsID));

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
                    baseEntityCollection.CollectionResponse = new List<OnlineEntranceExamQuestionBankMaster>();
                    while (sqlDataReader.Read())
                    {
                        OnlineEntranceExamQuestionBankMaster item = new OnlineEntranceExamQuestionBankMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ImageName"]) == false)
                        {
                            item.ImageName = sqlDataReader["ImageName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ImageType"]) == false)
                        {
                            item.ImageType = sqlDataReader["ImageType"].ToString();
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ImageType"]) == false)
                        //{
                        item.IsQuestionInImage = Convert.ToBoolean(sqlDataReader["IsQuestionInImage"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["QuestionLableText"]) == false)
                        {
                            item.QuestionLableText = sqlDataReader["QuestionLableText"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionImage"]) == false)
                        {
                            item.OptionImage = sqlDataReader["OptionImage"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OptionText"]) == false)
                        {
                            item.OptionText = sqlDataReader["OptionText"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GetQuestionAndOptionDetailList_ViewList' reported the ErrorCode: " + _errorCode);
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

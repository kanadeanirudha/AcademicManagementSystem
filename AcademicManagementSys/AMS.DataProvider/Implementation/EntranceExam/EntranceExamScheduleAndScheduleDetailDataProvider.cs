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
    public class EntranceExamScheduleAndScheduleDetailDataProvider : DBInteractionBase, IEntranceExamScheduleAndScheduleDetailDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor

        /// Constructor to initialized data member and member functions        
        public EntranceExamScheduleAndScheduleDetailDataProvider()
        {
        }

        /// Constructor to initialized data member and member functions        
        public EntranceExamScheduleAndScheduleDetailDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation

        // EntranceExamSchedule Method
        #region EntranceExamSchedule


        /// Select all record from EntranceExamSchedule table with search parameters.        
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ExaminationID));
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
					baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();
					while (sqlDataReader.Read())
					{
						EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamScheduleID"]) == false)
                        {
                            item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleName"]) == false)
                        {
                            item.ScheduleName = sqlDataReader["ScheduleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDate"]) == false)
                        {
                            item.ScheduleDate = sqlDataReader["ScheduleDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeStart"]) == false)
                        {
                            item.ScheduleTimeStart = sqlDataReader["ScheduleTimeStart"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleEndTime"]) == false)
                        {
                            item.ScheduleEndTime = sqlDataReader["ScheduleEndTime"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuestionPaperID"]) == false)
                        {
                            item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamInfrastructureDetailID"]) == false)
                        {
                            item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamCenteApllicableToExamID"]) == false)
                        {
                            item.EntranceExamCenteApllicableToExamID = Convert.ToInt32(sqlDataReader["EntranceExamCenteApllicableToExamID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["TotalStudentApllicableID"]) == false)
                        //{
                        //    item.TotalStudentApllicableID = Convert.ToInt32(sqlDataReader["TotalStudentApllicableID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CentreWiseSessionID"]) == false)
                        {
                            item.CentreWiseSessionID = Convert.ToInt32(sqlDataReader["CentreWiseSessionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SessionID"]) == false)
                        {
                            item.SessionID = Convert.ToInt32(sqlDataReader["SessionID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamAvailableCentresID"]) == false)
                        {
                            item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        {
                            item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CourseYearDetailID"]) == false)
                        {
                            item.CourseYearDetailID = Convert.ToInt32(sqlDataReader["CourseYearDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationFromDate"]) == false)
                        {
                            item.ExaminationFromDate = sqlDataReader["ExaminationFromDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationUpToDate"]) == false)
                        {
                            item.ExaminationUpToDate = sqlDataReader["ExaminationUpToDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExtraDescription"]) == false)
                        {
                            item.ExtraDescription = sqlDataReader["ExtraDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomCapacity"]) == false)
                        {
                            item.RoomCapacity = Convert.ToInt32(sqlDataReader["RoomCapacity"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomName"]) == false)
                        {
                            item.RoomName = sqlDataReader["RoomName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomNumber"]) == false)
                        {
                            item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentCount"]) == false)
                        {
                            item.StudentCount = Convert.ToInt32(sqlDataReader["StudentCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamApplicableExamToCourseID"]) == false)
                        {
                            item.OnlineExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["OnlineExamApplicableExamToCourseID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamAvailbleCentreID"]) == false)
                        {
                            item.EntranceExamAvailbleCentreID = Convert.ToInt32(sqlDataReader["EntranceExamAvailbleCentreID"]);
                        }

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EntranceExamSchedule_SelectAll' reported the ErrorCode: " + _errorCode);
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
        
        /// Select a record from table by ID        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleByID(EntranceExamScheduleAndScheduleDetail item)
		{
			IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_SelectOne";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
					cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
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
						EntranceExamScheduleAndScheduleDetail _item = new EntranceExamScheduleAndScheduleDetail();
						_item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
						_item.ScheduleName = sqlDataReader["ScheduleName"].ToString();
                        _item.ScheduleDate = sqlDataReader["ScheduleDate"].ToString();
						_item.ScheduleTimeStart = sqlDataReader["ScheduleTimeStart"].ToString();
						_item.ScheduleEndTime = sqlDataReader["ScheduleEndTime"].ToString();
                        _item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        _item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        _item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        _item.EntranceExamCenteApllicableToExamID = Convert.ToInt32(sqlDataReader["EntranceExamCenteApllicableToExamID"]);
                        _item.TotalStudentApllicable = Convert.ToInt32(sqlDataReader["TotalStudentApllicable"]);

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
        
        /// Create new record of the table        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsScheduleName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScheduleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtScheduleDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ScheduleDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtScheduleTimeStart", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ScheduleTimeStart)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtScheduleEndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ScheduleEndTime)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biOnlineExamExaminationQuestionPaperID", SqlDbType.BigInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailId", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamCenteApllicableToExamID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamCenteApllicableToExamID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalStudentApllicable", SqlDbType.TinyInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalStudentApllicable));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xEntranceExamScheduleDetail", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SelectedUnAllotedStudentXml.Trim()));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
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

                    if (_rowsAffected > 0)
                    {
                        item.EntranceExamScheduleID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamSchedule_INSERT' reported the ErrorCode: " + _errorCode);
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
        
        /// Update a specific record of EntranceExamSchedule        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsScheduleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScheduleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dScheduleDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ScheduleDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daScheduleTimeStart", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ScheduleTimeStart));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daScheduleEndTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ScheduleEndTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamCenteApllicableToExamID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamCenteApllicableToExamID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiTotalStudentApllicableID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalStudentApllicable));

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
                    item.EntranceExamScheduleID = (Int32)cmdToExecute.Parameters["@iEntranceExamScheduleID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamSchedule_Delete' reported the ErrorCode: " + _errorCode);
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
        
        /// Delete a specific record of EntranceExamSchedule        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.EntranceExamScheduleID = (Int32)cmdToExecute.Parameters["@iEntranceExamScheduleID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamSchedule_Delete' reported the ErrorCode: " +
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

        // Select all record from EntranceExamSchedule table with search list.
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamSchedule_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamScheduleSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamScheduleSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();

                        //Property of EntranceExamAvailableCentres
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamScheduleID"]) == false)
                        {
                            item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleName"]) == false)
                        {
                            item.ScheduleName = sqlDataReader["ScheduleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDate"]) == false)
                        {
                            item.ScheduleDate = sqlDataReader["ScheduleDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeStart"]) == false)
                        {
                            item.ScheduleTimeStart = sqlDataReader["ScheduleTimeStart"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleEndTime"]) == false)
                        {
                            item.ScheduleEndTime = sqlDataReader["ScheduleEndTime"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuestionPaperID"]) == false)
                        {
                            item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamInfrastructureDetailID"]) == false)
                        {
                            item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamCenteApllicableToExamID"]) == false)
                        {
                            item.EntranceExamCenteApllicableToExamID = Convert.ToInt32(sqlDataReader["EntranceExamCenteApllicableToExamID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalStudentApllicableID"]) == false)
                        {
                            item.TotalStudentApllicable = Convert.ToInt32(sqlDataReader["TotalStudentApllicable"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamSchedule_SearchList' reported the ErrorCode: " + _errorCode);
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

        ///EntranceExamScheduleDetail Method
        #region EntranceExamScheduleDetail


        /// Select all record from EntranceExamScheduleDetail Method table.        
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();
                        item.EntranceExamScheduleDetailID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleDetailID"]);
                        item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
                       

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
                        throw new Exception("Stored Procedure 'USP_EntranceExamScheduleDetail_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from table by ID        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailByID(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleDetailID));
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
                        EntranceExamScheduleAndScheduleDetail _item = new EntranceExamScheduleAndScheduleDetail();
                        _item.EntranceExamScheduleDetailID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleDetailID"]);
                        _item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        _item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        _item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        _item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        _item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EntranceExamScheduleDetail_SelectOne' reported the ErrorCode: " + _errorCode);
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

        /// Create new record of the table        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));
                    

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

                    if (_rowsAffected > 0)
                    {
                        item.EntranceExamScheduleDetailID = (Int32)cmdToExecute.Parameters["@iEntranceExamScheduleDetailID"].Value;
                    }

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamScheduleDetail_INSERT' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of EntranceExamScheduleDetail        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleDetailID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentRegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationQuestionPaperID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationQuestionPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.OnlineExamExaminationMasterID));

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
                    item.EntranceExamScheduleDetailID = (Int32)cmdToExecute.Parameters["@iEntranceExamScheduleDetailID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamSchedule_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of EntranceExamScheduleDetail        
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> response = new BaseEntityResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleDetailID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamScheduleDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.EntranceExamScheduleDetailID = (Int32)cmdToExecute.Parameters["@iEntranceExamScheduleDetailID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamScheduleDetail_Delete' reported the ErrorCode: " +
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

        // Select all record from EntranceExamSchedule table with search list.
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamScheduleDetail_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamScheduleDetailSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamScheduleDetailSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();

                        //Property of EntranceExamAvailableCentres
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamScheduleID"]) == false)
                        {
                            item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleName"]) == false)
                        {
                            item.ScheduleName = sqlDataReader["ScheduleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDate"]) == false)
                        {
                            item.ScheduleDate = sqlDataReader["ScheduleDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeStart"]) == false)
                        {
                            item.ScheduleTimeStart = sqlDataReader["ScheduleTimeStart"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleEndTime"]) == false)
                        {
                            item.ScheduleEndTime = sqlDataReader["ScheduleEndTime"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamSchedule_SearchList' reported the ErrorCode: " + _errorCode);
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


        // Select Question Paper list.
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetOnlineExamQuestionPaperSet(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationQuestionPaperSet_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationMasterID));
                    
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();

                        //Property of EntranceExamAvailableCentres
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationQuestionPaperID"]) == false)
                        {
                            item.OnlineExamExaminationQuestionPaperID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationQuestionPaperID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperSet"]) == false)
                        {
                            item.PaperSet = sqlDataReader["PaperSet"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OnlineExamExaminationMasterID"]) == false)
                        {
                            item.OnlineExamExaminationMasterID = Convert.ToInt32(sqlDataReader["OnlineExamExaminationMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_OnlineExamExaminationQuestionPaperSet_SearchList' reported the ErrorCode: " + _errorCode);
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


        // Select all un-alloted student list.
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStuentForScheduleAvailCentreList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamNotAllotedStuentForScheduleAvailCentre_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamApplicableExamToCourseID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamApplicableExamToCourseID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEntranceExamAvailbleCentreID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamAvailbleCentreID));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();

                        //Property of EntranceExamAvailableCentres
                        if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        {
                            item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName = sqlDataReader["StudentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYear"]) == false)
                        {
                            item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYearID"]) == false)
                        {
                            item.AcademicYearID = Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AllotedFlag"]) == false)
                        {
                            item.AllotedFlag = Convert.ToBoolean(sqlDataReader["AllotedFlag"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamNotAllotedStuentForScheduleAvailCentre_SelectAll' reported the ErrorCode: " + _errorCode);
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

        //GetAllotedStudentListForCentre
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStudentListForCentre(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAllotedStudentScheduleWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamScheduleId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamScheduleID));
                    

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamScheduleAndScheduleDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamScheduleAndScheduleDetail item = new EntranceExamScheduleAndScheduleDetail();                        
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamScheduleDetailID"]) == false)
                        {
                            item.EntranceExamScheduleDetailID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentRegistrationID"]) == false)
                        {
                            item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamScheduleID"]) == false)
                        {
                            item.EntranceExamScheduleID = Convert.ToInt32(sqlDataReader["EntranceExamScheduleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["StudentName"]) == false)
                        {
                            item.StudentName = sqlDataReader["StudentName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYear"]) == false)
                        {
                            item.AcademicYear = sqlDataReader["AcademicYear"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicYearID"]) == false)
                        {
                            item.AcademicYearID = Convert.ToInt32(sqlDataReader["AcademicYearID"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamAllotedStudentScheduleWise' reported the ErrorCode: " + _errorCode);
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

        #endregion

    }
}

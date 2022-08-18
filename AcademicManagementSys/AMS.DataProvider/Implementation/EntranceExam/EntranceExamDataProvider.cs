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
    public class EntranceExamDataProvider : DBInteractionBase, IEntranceExamDataProvider
    {
        #region Variable Declaration
		private readonly string _connectionString;
		private readonly ILogger _logException;
		#endregion
		#region Constructor
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		public EntranceExamDataProvider()
		{
		}
		/// <summary>
		/// Constructor to initialized data member and member functions
		/// </summary>
		/// <param name="logException"></param>
		public EntranceExamDataProvider(ILogger logException)
		{
			_connectionString =""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
		}
		#endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EntranceExam table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamBySearch(EntranceExamSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EntranceExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExam>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<EntranceExam>();
					while (sqlDataReader.Read())
					{
						EntranceExam item = new EntranceExam();
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
						item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
						item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
						item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
						item.SessionName = sqlDataReader["SessionName"].ToString();
						item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
						item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
						item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
						item.IPAddress = sqlDataReader["IPAddress"].ToString();

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EntranceExam_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EntranceExam table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndStudentExamInfo(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExam>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExam item = new EntranceExam();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
                        item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        item.SessionName = sqlDataReader["SessionName"].ToString();
                        item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
                        item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
                        item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
                        item.IPAddress = sqlDataReader["IPAddress"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EntranceExam_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EntranceExam table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndExamQuestionType(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExam>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExam item = new EntranceExam();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
                        item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        item.SessionName = sqlDataReader["SessionName"].ToString();
                        item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
                        item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
                        item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
                        item.IPAddress = sqlDataReader["IPAddress"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EntranceExam_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EntranceExam table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> EntranceExamIndEGetSetQuestion(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExam>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExam item = new EntranceExam();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
                        item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        item.SessionName = sqlDataReader["SessionName"].ToString();
                        item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
                        item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
                        item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
                        item.IPAddress = sqlDataReader["IPAddress"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EntranceExam_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from EntranceExam table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamGetResultofStudent(EntranceExamSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExam> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExam>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExam item = new EntranceExam();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
                        item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
                        //item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
                        item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
                        item.SessionName = sqlDataReader["SessionName"].ToString();
                        item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
                        item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
                        item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
                        item.IPAddress = sqlDataReader["IPAddress"].ToString();

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
                        throw new Exception("Stored Procedure 'USP_EntranceExam_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EntranceExam> GetEntranceExamByID(EntranceExam item)
		{
			IBaseEntityResponse<EntranceExam> response = new BaseEntityResponse<EntranceExam>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExam_SelectOne";
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
						EntranceExam _item = new EntranceExam();
						_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.StudentRegistrationID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
						_item.EntranceExamApplicableExamToCourseID = Convert.ToInt32(sqlDataReader["EntranceExamApplicableExamToCourseID"]);
						_item.CourseYearCode = sqlDataReader["CourseYearCode"].ToString();
						
                        //_item.AttendLogInTime = Convert.ToDateTime(sqlDataReader["AttendLogInTime"]);
                        //_item.ExaminationDate = Convert.ToDateTime(sqlDataReader["ExaminationDate"]);
                        //_item.ExaminationStartTime = Convert.ToDateTime(sqlDataReader["ExaminationStartTime"]);
                        //_item.ExaminationEndTime = Convert.ToDateTime(sqlDataReader["ExaminationEndTime"]);
						_item.IsExaminationOver = Convert.ToBoolean(sqlDataReader["IsExaminationOver"]);
						_item.SessionName = sqlDataReader["SessionName"].ToString();
						_item.LoginStatus = Convert.ToBoolean(sqlDataReader["LoginStatus"]);
						_item.IsLock = Convert.ToBoolean(sqlDataReader["IsLock"]);
						_item.OnlineExaminationPaperID = Convert.ToInt32(sqlDataReader["OnlineExaminationPaperID"]);
						_item.IPAddress = sqlDataReader["IPAddress"].ToString();

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
        public IBaseEntityResponse<EntranceExam> InsertEntranceExam(EntranceExam item)
        {
            IBaseEntityResponse<EntranceExam> response = new BaseEntityResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StudentRegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamApplicableExamToCourseID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.EntranceExamApplicableExamToCourseID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCourseYearCode", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.CourseYearCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AttendanceFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daAttendLogInTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AttendLogInTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationStartTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationEndTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsExaminationOver", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsExaminationOver));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSessionName", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SessionName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLoginStatus", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.LoginStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLock", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsLock));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExaminationPaperID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OnlineExaminationPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sIPAddress", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.IPAddress));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExam_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of EntranceExam
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExam> UpdateEntranceExam(EntranceExam item)
        {
            IBaseEntityResponse<EntranceExam> response = new BaseEntityResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.StudentRegistrationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamApplicableExamToCourseID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.EntranceExamApplicableExamToCourseID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCourseYearCode", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.CourseYearCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.TinyInt, 3,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AttendanceFlag));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daAttendLogInTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.AttendLogInTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationDate", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationStartTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationStartTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daExaminationEndTime", SqlDbType.DateTime, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ExaminationEndTime));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsExaminationOver", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsExaminationOver));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSessionName", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.SessionName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bLoginStatus", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.LoginStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLock", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsLock));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExaminationPaperID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.OnlineExaminationPaperID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sIPAddress", SqlDbType.VarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.IPAddress));
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
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExam_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of EntranceExam
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EntranceExam> DeleteEntranceExam(EntranceExam item)
        {
            IBaseEntityResponse<EntranceExam> response = new BaseEntityResponse<EntranceExam>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExam_Delete";
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
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExam_Delete' reported the ErrorCode: " +
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

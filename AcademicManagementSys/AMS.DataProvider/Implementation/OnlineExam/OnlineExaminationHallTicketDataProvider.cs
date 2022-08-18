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
    public class OnlineExaminationHallTicketDataProvider : DBInteractionBase, IOnlineExaminationHallTicketDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public OnlineExaminationHallTicketDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public OnlineExaminationHallTicketDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExaminationHallTicket> GetOnlineExaminationHallTicketByID(OnlineExaminationHallTicket item)
        {
            IBaseEntityResponse<OnlineExaminationHallTicket> response = new BaseEntityResponse<OnlineExaminationHallTicket>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamExaminationHallTicket_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentRegistrationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 21));
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
                        OnlineExaminationHallTicket _item = new OnlineExaminationHallTicket();
                        _item.ID = Convert.ToInt32(sqlDataReader["StudentRegistrationID"]);
                        _item.RegistrationNumber = sqlDataReader["StudentRegistrationID"].ToString();
                        _item.RollNumber = sqlDataReader["RollNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["RollNumber"]);
                        _item.StudentFullName = Convert.ToString(sqlDataReader["StudentName"]);
                        _item.Gender = Convert.ToString(sqlDataReader["Gender"]);

                        if (_item.Gender == "M")
                        {
                            _item.Gender = "Male";
                        }
                        else
                        {
                            _item.Gender = "Female";
                        }

                        _item.ExamTime = Convert.ToString(sqlDataReader["ScheduleTimeStart"]) + "-" + Convert.ToString(sqlDataReader["ScheduleEndTime"]);
                        _item.ExamDate = Convert.ToString(sqlDataReader["ScheduleDate"]);
                        _item.Venue = Convert.ToString(sqlDataReader["CentreName"]);
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            _item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }
                        _item.StudentPhotoFileSize = sqlDataReader["StudentPhotoFileSize"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["StudentSignature"]) == false)
                        {
                            _item.StudentSignature = (byte[])(sqlDataReader["StudentSignature"]);
                        }
                        _item.StudentSignatureFileSize = sqlDataReader["StudentSignatureFileSize"].ToString();
                        _item.Venue1 = Convert.ToString(sqlDataReader["LocationAddress"]) + "," + Convert.ToString(sqlDataReader["RegionName"]) + "-" + Convert.ToString(sqlDataReader["PostCode"]);
                        _item.ExaminationName = sqlDataReader["CourseYearCode"].ToString();
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
        #endregion
    }
}

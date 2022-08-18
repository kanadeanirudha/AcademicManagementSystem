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
    public class StudentReportCardDataProvider : DBInteractionBase, IStudentReportCardDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public StudentReportCardDataProvider() { }
        public StudentReportCardDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentReportCard> GetStudentReportCardData(StudentReportCardSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<StudentReportCard> baseEntityCollection = new BaseEntityCollectionResponse<StudentReportCard>();
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
                    cmdToExecute.CommandText = "dbo.USP_StudentReportCard_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamExaminationCourseApplicableID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamExaminationCourseApplicableID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StudentID));
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

                    baseEntityCollection.CollectionResponse = new List<StudentReportCard>();
                    while (sqlDataReader.Read())
                    {
                        StudentReportCard item = new StudentReportCard();
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"].ToString()) == false)
                        {
                            item.ExaminationName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"].ToString()) == false)
                        {
                            item.SubjectName = Convert.ToString(sqlDataReader["SubjectName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalMarks"].ToString()) == false)
                        {
                            item.TotalMarks = Convert.ToInt16(sqlDataReader["TotalMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationDate"].ToString()) == false)
                        {
                            item.ExaminationDate = Convert.ToString(sqlDataReader["ExaminationDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MarkObtained"].ToString()) == false)
                        {
                            item.MarkObtained = Convert.ToDecimal(sqlDataReader["MarkObtained"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["OverAllTotalMarks"].ToString()) == false)
                        {
                            item.OverAllTotalMarks = Convert.ToInt16(sqlDataReader["OverAllTotalMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalMarkObtained"].ToString()) == false)
                        {
                            item.TotalMarkObtained = Convert.ToDecimal(sqlDataReader["TotalMarkObtained"]);
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
                        throw new Exception("Stored Procedure 'USP_AccountTransactionMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
    }
}

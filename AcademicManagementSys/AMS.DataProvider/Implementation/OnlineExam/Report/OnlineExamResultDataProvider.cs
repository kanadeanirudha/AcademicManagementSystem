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
    public class OnlineExamResultDataProvider : DBInteractionBase, IOnlineExamResultDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion

        #region Constructor
        public OnlineExamResultDataProvider() { }
        public OnlineExamResultDataProvider(ILogger logException)
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
        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_AllVendorList(OnlineExamResultSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<OnlineExamResult> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamResult>();
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
                    cmdToExecute.CommandText = "dbo.USP_OnlineExamResult_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    // ---------------------------------------------------Input Parameters -------------------------------------------------------------------
                    cmdToExecute.Parameters.Add(new SqlParameter("@iOnlineExamIndStudentExamInfoID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.OnlineExamIndStudentExamInfoID));
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

                    baseEntityCollection.CollectionResponse = new List<OnlineExamResult>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamResult item = new OnlineExamResult();
                        //On Selection Of All

                        if (DBNull.Value.Equals(sqlDataReader["ExaminationName"]) == false)
                        {
                            item.ExamName = Convert.ToString(sqlDataReader["ExaminationName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubjectName"]) == false)
                        {
                            item.SubjectName = Convert.ToString(sqlDataReader["SubjectName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExaminationDate"]) == false)
                        {
                            item.ExamDate = Convert.ToString(sqlDataReader["ExaminationDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalMarks"]) == false)
                        {
                            item.TotalMarks = Convert.ToByte(sqlDataReader["TotalMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalQuestions"]) == false)
                        {
                            item.TotalQuestions = Convert.ToByte(sqlDataReader["TotalQuestions"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExamDuration"]) == false)
                        {
                            item.ExamDuration = Convert.ToByte(sqlDataReader["ExamDuration"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CorrectAnswer"]) == false)
                        {
                            item.CorrectAnswer = Convert.ToInt16(sqlDataReader["CorrectAnswer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["InCorrectAnswer"]) == false)
                        {
                            item.IncorrectAnswer = Convert.ToInt16(sqlDataReader["InCorrectAnswer"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NotAnswered"]) == false)
                        {
                            item.NotAnswered = Convert.ToInt16(sqlDataReader["NotAnswered"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CorrectMarks"]) == false)
                        {
                            item.CorrectMarks = Convert.ToDecimal(sqlDataReader["CorrectMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NegativeMarks"]) == false)
                        {
                            item.NegativeMarks = Convert.ToDecimal(sqlDataReader["NegativeMarks"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalMarksObtained"]) == false)
                        {
                            item.TotalMarksObtained = Convert.ToDecimal(sqlDataReader["TotalMarksObtained"]);
                        }
                    
                        //On the Selection Of Vendor Restriction
                     
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
        //Item Master Missing Rxception report
        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_ItemList(OnlineExamResultSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<OnlineExamResult> baseEntityCollection = new BaseEntityCollectionResponse<OnlineExamResult>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralItemMaster_PriceReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
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

                    baseEntityCollection.CollectionResponse = new List<OnlineExamResult>();
                    while (sqlDataReader.Read())
                    {
                        OnlineExamResult item = new OnlineExamResult();

                        //item.ItemName = sqlDataReader["ItemName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ItemName"]);
                        //item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["ItemNumber"]);
                        //item.OrderUoM = sqlDataReader["OrderUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OrderUoM"]);
                        //item.BaseUoM = sqlDataReader["BaseUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BaseUoM"]);
                        //item.SalesUoM = sqlDataReader["SalesUoM"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SalesUoM"]);
                        //item.Vendor = sqlDataReader["Vendor"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Vendor"]);
                        //item.LeadTime = sqlDataReader["LeadTime"] is DBNull ? string.Empty: Convert.ToString(sqlDataReader["LeadTime"]);

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

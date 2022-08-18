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
    public class CRMReportDataProvider : DBInteractionBase, ICRMReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion


        #region Constructor


        /// Constructor to initialized data member and member functions       
        public CRMReportDataProvider()
        {
        }


        /// Constructor to initialized data member and member functions       
        public CRMReportDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException;
        }

        #endregion


        #region Method Implementation CRMReport

        public IBaseEntityCollectionResponse<CRMReport> GetConvertedCallDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardConvertedCallDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();


                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CRMReport> GetCRMConversionReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardMonthlyCallConversionDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();


                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
                        }

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMReport> GetCRMCallAverageDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardCompanyAvgVsSelfAvgConversion_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();


                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}

                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["MonthName"].ToString()) == false)
                        //{
                        //    item.InvoiceMonth = Convert.ToString(sqlDataReader["MonthName"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
                        }

  

                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CRMReport> GetCRMCallbackReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardMonthlyCallBackVsCallBackConverionByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();


                      
                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
                   
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        public IBaseEntityCollectionResponse<CRMReport> GetCRMWicklyStatusDetailsInDateRangeReport(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;

                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_CRMWicklyStatusDetailsInDateRange_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtFromDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.FromDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtUptoDate", SqlDbType.Date, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.UptoDate));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();


                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = Convert.ToDateTime(sqlDataReader["TransactionDate"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionFromDateTime"].ToString()) == false)
                        {
                            item.TransactionFromDateTime = Convert.ToDateTime(sqlDataReader["TransactionFromDateTime"].ToString());
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TransactionUpToTime"].ToString()) == false)
                        {
                            item.TransactionUpToTime = Convert.ToDateTime(sqlDataReader["TransactionUpToTime"].ToString());
                        }


                        if (DBNull.Value.Equals(sqlDataReader["ScheduleTimeInMin"].ToString()) == false)
                        {
                            item.ScheduleTimeInMin = Convert.ToInt32(sqlDataReader["ScheduleTimeInMin"]);
                        }

                        if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 1)
                        {
                            if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 1)
                            {
                                item.BackgroundColor = "#795548";
                            }
                            else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 2)
                            {
                                item.BackgroundColor = "#009688";
                            }
                            else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 3)
                            {
                                item.BackgroundColor = "#3F51B5";
                            }
                            else if (Convert.ToInt16(sqlDataReader["SubScheduleType"]) == 4)
                            {
                                item.BackgroundColor = "#9C27B0";
                            }
                        }
                        else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 2)
                        {
                            item.BackgroundColor = "#03A9F4";
                        }
                        else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 3)
                        {
                            item.BackgroundColor = "#673AB7";
                        }
                        else if (Convert.ToInt16(sqlDataReader["ScheduleType"]) == 4)
                        {
                            item.BackgroundColor = "#607D8B";
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceNumber"].ToString()) == false)
                        //{
                        //    item.InvoiceNumber = sqlDataReader["InvoiceNumber"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceDate"].ToString()) == false)
                        //{
                        //    item.InvoiceDate = sqlDataReader["InvoiceDate"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["InvoiceAmount"].ToString()) == false)
                        //{
                        //    item.InvoiceAmount = Convert.ToDecimal(sqlDataReader["InvoiceAmount"]);
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = sqlDataReader["AccountName"].ToString();
                        //}

                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforPendingCalls(CRMReportSearchRequest searchRequest)    
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardPendingCallDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalAllocatedCall(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardAllocatedCallForEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<CRMReport> GetCRMDashboardSparklineChartsReportforCallbackCalls(CRMReportSearchRequest searchRequest)    
   
         {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardCallbackCallDetailsByEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CRMReport> GetCRMTotalCallbackCall(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardCallBackCountForEmployee_Report";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.CallCountList = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallStatus"].ToString()) == false)
                        {
                            item.CallStatus = Convert.ToString(sqlDataReader["CallStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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



        public IBaseEntityCollectionResponse<CRMReport> GetListTodaysMeetingSchedule(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_GetTodaysMeetingScheduleList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubScheduleType"].ToString()) == false)
                        {
                            item.SubScheduleType = Convert.ToInt16(sqlDataReader["SubScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = sqlDataReader["FromTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UptoTime"].ToString()) == false)
                        {
                            item.UptoTime = sqlDataReader["UptoTime"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        throw new Exception("Stored Procedure 'USP_GetTodaysMeetingScheduleList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMReport> GetListTodaysEnquiryDetails(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardEnquiryList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["EnquiryDesription"].ToString()) == false)
                        {
                            item.EnquiryDesription = Convert.ToString(sqlDataReader["EnquiryDesription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EnquiryProgressStatus"].ToString()) == false)
                        {
                            item.EnquiryProgressStatus = Convert.ToInt16(sqlDataReader["EnquiryProgressStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMReport> GetListSalesCallSchedule(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardSalesCallList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dTransactionDate", SqlDbType.Date, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.TodaysDate));
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

                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = Convert.ToString(sqlDataReader["FromTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UptoTime"].ToString()) == false)
                        {
                            item.UptoTime = Convert.ToString(sqlDataReader["UptoTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"].ToString()) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMReport> GetListReminders(CRMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMDashboardRemindersList_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
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
                    baseEntityCollection.CollectionResponse = new List<CRMReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMReport item = new CRMReport();

                        if (DBNull.Value.Equals(sqlDataReader["FromUserName"].ToString()) == false)
                        {
                            item.FromUserName = Convert.ToString(sqlDataReader["FromUserName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BodyDescription"].ToString()) == false)
                        {
                            item.BodyDescription = sqlDataReader["BodyDescription"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

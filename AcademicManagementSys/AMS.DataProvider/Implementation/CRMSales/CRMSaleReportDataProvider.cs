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
    public class CRMSaleReportDataProvider : DBInteractionBase, ICRMSaleReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion


        #region Constructor


        /// Constructor to initialized data member and member functions       
        public CRMSaleReportDataProvider()
        {
        }


        /// Constructor to initialized data member and member functions       
        public CRMSaleReportDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException;
        }

        #endregion


        #region Method Implementation CRMSaleReport

        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleTopFiveAccountReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardTopFiveAccountDetailsByEmployee_Report";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();


                        if (DBNull.Value.Equals(sqlDataReader["Months"].ToString()) == false)
                        {
                            item.InvoiceMonth = Convert.ToString(sqlDataReader["Months"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmountList"].ToString()) == false)
                        {
                            item.TotalInvoiceAmountList = Convert.ToString(sqlDataReader["TotalInvoiceAmountList"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleMonthlyRevenueReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardMonthlyRevenueDetailsByEmployee_Report";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();


                        //if (DBNull.Value.Equals(sqlDataReader["TotalInvoiceAmount"].ToString()) == false)
                        //{
                        //    item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["TotalInvoiceAmount"]);
                        //}

                        if (DBNull.Value.Equals(sqlDataReader["CallCountList"].ToString()) == false)
                        {
                            item.TotalInvoiceAmount = Convert.ToString(sqlDataReader["CallCountList"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["MonthName"].ToString()) == false)
                        //{
                        //    item.InvoiceMonth = Convert.ToString(sqlDataReader["MonthName"]);
                        //}

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityCollectionResponse<CRMSaleReport> GetCRMSaleWicklyStatusDetailsInDateRangeReport(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleWicklyStatusDetailsInDateRange_Report";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();


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
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<CRMSaleReport> CRMSaleDashboardSparklineChartsReportByEmployeeID(CRMSaleReport item)
        {
            IBaseEntityResponse<CRMSaleReport> response = new BaseEntityResponse<CRMSaleReport>();
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
                    if (item.DataFor == "TodaysMeeting")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TodaysMeetingReport";
                    }
                    else if (item.DataFor == "AccountTarget")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_AccountTargetReport";
                    }
                    else if (item.DataFor == "BillingTarget")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_BillingTargetReport";
                    }
                    else if (item.DataFor == "TotalSale")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TotalSaleReport";
                    }
                    else if (item.DataFor == "TotalHotAccount")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TotalHotAccountReport";
                    }
                    else if (item.DataFor == "TotalColdAccount")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TotalColdAccountReport";
                    }
                    else if (item.DataFor == "TotalExistingAccount")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TotalExistingAccountReport";
                    }
                    else if (item.DataFor == "TotalEnquiries")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_TotalEnquiriesReport";
                    }
                    else if (item.DataFor == "ConversionRate")
                    {
                        cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSparklineCharts_ConversionRateReport";
                    }

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@sDataFor", SqlDbType.VarChar, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.DataFor));

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

                        CRMSaleReport _item = new CRMSaleReport();
                        _item.ReportCount = Convert.ToInt32(sqlDataReader["ReportCount"]);
                        _item.ReportList = Convert.ToString(sqlDataReader["ReportList"]);
                        if (item.DataFor == "AccountTarget" || item.DataFor == "BillingTarget")
                        {
                            _item.PeriodType = Convert.ToString(sqlDataReader["PeriodType"]);
                        }   
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysMeetingSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListTodaysEnquiryDetails(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardEnquiryList_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListSalesCallSchedule(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardSalesCallList_SelectAll";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleReport> GetListReminders(CRMSaleReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleDashboardRemindersList_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<CRMSaleReport>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleReport item = new CRMSaleReport();

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
                        throw new Exception("Stored Procedure 'USP_CRMSaleDashboardEnquiryList_SelectAll' reported the ErrorCode: " + _errorCode);
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

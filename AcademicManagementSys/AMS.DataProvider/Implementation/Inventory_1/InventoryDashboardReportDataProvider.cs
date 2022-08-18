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
    public class InventoryDashboardReportDataProvider : DBInteractionBase, IInventoryDashboardReportDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion


        #region Constructor


        /// Constructor to initialized data member and member functions       
        public InventoryDashboardReportDataProvider()
        {
        }


        /// Constructor to initialized data member and member functions       
        public InventoryDashboardReportDataProvider(ILogger logException)
        {
            _connectionString = "";
            _logException = logException;
        }

        #endregion


        #region Method Implementation InventoryDashboardReport

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetMonthlySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardCharts_MonthlySale";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    if (searchRequest.CentreListXML != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleID));
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

                    baseEntityCollection.CollectionResponse = new List<InventoryDashboardReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDashboardReport item = new InventoryDashboardReport();

                        item.BillRelevantTo = sqlDataReader["BillRelevantTo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BillRelevantTo"]);
                        item.TotalInvoiceAmountList = sqlDataReader["TotalInvoiceAmountList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TotalInvoiceAmountList"]);
                        item.Months = sqlDataReader["Months"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Months"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                     
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetDailySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardCharts_DailySale";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,DateTime.UtcNow));
                    if (searchRequest.CentreListXML != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<InventoryDashboardReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDashboardReport item = new InventoryDashboardReport();

                        item.Days = sqlDataReader["Days"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Days"]);
                        item.ReportList = sqlDataReader["ReportList"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ReportList"]);
                        
                        baseEntityCollection.CollectionResponse.Add(item);
                        
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardReportSparkLineChartReport(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> response = new BaseEntityResponse<InventoryDashboardReport>();
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
                    if (item.DataFor == "TotalItemCount")
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryDashboardSparklineCharts_TotalItemCount";
                    }
                    else if (item.DataFor == "TotalInventoryAmount")
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryDashboardSparklineCharts_TotalInventoryAmount";
                    }
                    else if (item.DataFor == "TotalRestaurantItems")
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryDashboardSparklineCharts_TotalRestaurantItems";
                    }
                    else if (item.DataFor == "TotalRetailSaleItems")
                    {
                        cmdToExecute.CommandText = "dbo.USP_InventoryDashboardSparklineCharts_TotalRetailSaleItems";
                    }
                  

                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
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

                        InventoryDashboardReport _item = new InventoryDashboardReport();
                       // _item.ReportCount = Convert.ToInt32(sqlDataReader["ReportCount"]);
                        _item.ReportList = Convert.ToString(sqlDataReader["ReportList"]);
                       
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTotalSaleAndPromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardPieChart_SalePromotion";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    if (searchRequest.CentreListXML != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<InventoryDashboardReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDashboardReport item = new InventoryDashboardReport();

                        item.SourceKey = sqlDataReader["SourceKey"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SourceKey"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetTopFivePromotionReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardTopFiveSalePromotion";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    if (searchRequest.CentreListXML != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<InventoryDashboardReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDashboardReport item = new InventoryDashboardReport();

                        item.SourceKey = sqlDataReader["PromotionActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PromotionActivityName"]);
                        item.PromotionAmount = sqlDataReader["PromotionAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["PromotionAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetFineDineTakeAwayPieChartReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
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
                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardPieChart_TakeAwayFineDine";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    if (searchRequest.CentreListXML != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreListXML));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreListXML", SqlDbType.Xml, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
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

                    baseEntityCollection.CollectionResponse = new List<InventoryDashboardReport>();
                    while (sqlDataReader.Read())
                    {
                        InventoryDashboardReport item = new InventoryDashboardReport();

                        item.SourceKey = sqlDataReader["SourceKey"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SourceKey"]);
                        item.SaleAmount = sqlDataReader["SaleAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["SaleAmount"]);

                        baseEntityCollection.CollectionResponse.Add(item);

                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForCafe(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> response = new BaseEntityResponse<InventoryDashboardReport>();
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

                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardCharts_MonthlyCafeSaleAmount";
                    
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
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

                        InventoryDashboardReport _item = new InventoryDashboardReport();

                        _item.SaleAmount = sqlDataReader["Amount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Amount"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<InventoryDashboardReport> InventoryDashboardStockAmountSparkLineChartReportForRetail(InventoryDashboardReport item)
        {
            IBaseEntityResponse<InventoryDashboardReport> response = new BaseEntityResponse<InventoryDashboardReport>();
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

                    cmdToExecute.CommandText = "dbo.USP_InventoryDashboardCharts_MonthlyRetailSaleAmount";



                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.UtcNow));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.AdminRoleID));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DateTime.Now));
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

                        InventoryDashboardReport _item = new InventoryDashboardReport();

                        _item.SaleAmount = sqlDataReader["Amount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Amount"]);
                        response.Entity = _item;
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventoryDashboardReport_SelectAll' reported the ErrorCode: " + _errorCode);
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

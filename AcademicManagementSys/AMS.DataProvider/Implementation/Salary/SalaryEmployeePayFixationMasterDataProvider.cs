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
    public class SalaryEmployeePayFixationMasterDataProvider : DBInteractionBase, ISalaryEmployeePayFixationMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalaryEmployeePayFixationMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalaryEmployeePayFixationMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from SalaryEmployeePayFixationMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearch(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
                    baseEntityCollection.CollectionResponse = new List<SalaryEmployeePayFixationMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryEmployeePayFixationMaster item = new SalaryEmployeePayFixationMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        item.Basic = sqlDataReader["Basic"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Basic"]),2);
                        item.PayScaleRange = sqlDataReader["PayScaleRange"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PayScaleRange"]),2);
                        item.GradePayAmount = sqlDataReader["GradePayAmount"] is DBNull ? new Decimal() :Math.Round(Convert.ToDecimal(sqlDataReader["GradePayAmount"]),2);
                        item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        item.ArriersGenerationStatus = sqlDataReader["ArriersGenerationStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ArriersGenerationStatus"]);
                        item.SalaryPayScaleMasterID = sqlDataReader["SalaryPayScaleMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SalaryPayScaleMasterID"]);
                        item.SalaryGradePayMasterID = sqlDataReader["SalaryGradePayMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SalaryGradePayMasterID"]);


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
                        throw new Exception("Stored Procedure 'USP_SalaryEmployeePayFixationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> GetSalaryEmployeePayFixationMasterByID(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_SelectOne";
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
                        SalaryEmployeePayFixationMaster _item = new SalaryEmployeePayFixationMaster();
                        _item.ID = sqlDataReader["ID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ID"]);
                        _item.EmployeeID = sqlDataReader["EmployeeID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        _item.Basic = sqlDataReader["Basic"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["Basic"]), 2);
                        _item.PayScaleRange = sqlDataReader["PayScaleRange"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["PayScaleRange"]), 2);
                        _item.GradePayAmount = sqlDataReader["GradePayAmount"] is DBNull ? new Decimal() : Math.Round(Convert.ToDecimal(sqlDataReader["GradePayAmount"]), 2);
                        _item.EmployeeName = sqlDataReader["EmployeeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmployeeName"]);
                        _item.ArriersGenerationStatus = sqlDataReader["ArriersGenerationStatus"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["ArriersGenerationStatus"]);

                        _item.SalaryPayScaleMasterID = sqlDataReader["SalaryPayScaleMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SalaryPayScaleMasterID"]);

                        _item.SalaryGradePayMasterID = sqlDataReader["SalaryGradePayMasterID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["SalaryGradePayMasterID"]);


                    


                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        //_item.Basic = Convert.ToDecimal(sqlDataReader["Basic"]);
                        //_item.SalaryPayScaleMasterID = Convert.ToInt16(sqlDataReader["SalaryPayScaleMasterID"]);
                        //_item.SalaryGradePayMasterID = Convert.ToInt16(sqlDataReader["SalaryGradePayMasterID"]);
                        //_item.ArriersGenerationStatus = Convert.ToByte(sqlDataReader["ArriersGenerationStatus"]);
                        //_item.EmployeeName = (sqlDataReader["EmployeeID"]).ToString();

                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'SalaryEmployeePayFixationMaster' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> InsertSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters .Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0,
                                             ParameterDirection.Input, false, 10, 0, "",
                                             DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters .Add(new SqlParameter("@iOldSalaryEmployeePayFixationMasterID", SqlDbType.Int, 4,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.OldSalaryEmployeePayFixationMasterID));
                    cmdToExecute.Parameters .Add(new SqlParameter("@dBasic", SqlDbType.Decimal, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.Basic));
                    cmdToExecute.Parameters .Add(new SqlParameter("@iSalaryPayScaleMasterID", SqlDbType.Int, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.SalaryPayScaleMasterID));
                    cmdToExecute.Parameters .Add(new SqlParameter("@iSalaryGradePayMasterID", SqlDbType.Int, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.SalaryGradePayMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siPayIncrementCount", SqlDbType.SmallInt, 5,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.PayIncrementCount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBandPay", SqlDbType.Decimal, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.BandPay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dGradePay", SqlDbType.Decimal, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.GradePay));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiApprovedStatus", SqlDbType.TinyInt, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.ApprovedStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iApprovedBy", SqlDbType.Int, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.ApprovedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsCurrent", SqlDbType.Bit, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.IsCurrent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daOrderDate", SqlDbType.DateTime, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.OrderDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsOrderNumber", SqlDbType.NVarChar, 20,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.OrderNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daEffectiveFrom", SqlDbType.DateTime, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.EffectiveFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNeedGenerateArriers", SqlDbType.Bit, 0,
                                             ParameterDirection.Input, true, 10, 0, "",
                                             DataRowVersion.Proposed, item.IsNeedGenerateArriers));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiArriersGenerationStatus", SqlDbType.TinyInt, 0,
                                             ParameterDirection.Input, false, 0, 0, "",
                                             DataRowVersion.Proposed, item.ArriersGenerationStatus));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryEmployeePayFixationMaster_INSERT' reported the ErrorCode: " +
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
        /// Update a specific record of SalaryEmployeePayFixationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> UpdateSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPayScaleRuleDescription", SqlDbType.NVarChar, 0,
                    //                    ParameterDirection.Input, false, 11, 0, "",
                    //                    DataRowVersion.Proposed, item.PayScaleRuleDescription));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daPayScaleFromDate", SqlDbType.DateTime, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PayScaleFromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@daPayScaleUptoDate", SqlDbType.DateTime, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.PayScaleUptoDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.IsActive));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                    //                    ParameterDirection.Input, true, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                    //                        ParameterDirection.Output, true, 10, 0, "",
                    //                        DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryEmployeePayFixationMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of SalaryEmployeePayFixationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_Delete";
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
                                            DataRowVersion.Proposed, item.DeletedBy));
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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_SalaryEmployeePayFixationMaster_Delete' reported the ErrorCode: " +
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
        //*****************For Salary Pay Rule
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearchList(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalaryEmployeePayFixationMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalaryEmployeePayFixationMaster_SearchListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<SalaryEmployeePayFixationMaster>();
                    while (sqlDataReader.Read())
                    {
                        SalaryEmployeePayFixationMaster item = new SalaryEmployeePayFixationMaster();
                        //item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //item.PayScaleRuleDescription = sqlDataReader["PayScaleRuleDescription"].ToString();
                       

                        baseEntityCollection.CollectionResponse.Add(item);
                       
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SalaryEmployeePayFixationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

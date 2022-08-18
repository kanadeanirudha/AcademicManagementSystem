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
    public class CRMSaleJobUserJobScheduleSheetDataProviderDataProvider : DBInteractionBase, ICRMSaleJobUserJobScheduleSheetDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// Constructor to initialized data member and member functions.
        public CRMSaleJobUserJobScheduleSheetDataProviderDataProvider()
        {
        }

        /// Constructor to initialized data member and member functions
        public CRMSaleJobUserJobScheduleSheetDataProviderDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        #region Method Implementation CRMSaleJobUserJobScheduleSheet

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetCRMSaleJobUserJobScheduleSheetSearchList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_SearchList";
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
                    //dt.Rows.Add(sqlDataReader);

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();

                        //if (DBNull.Value.Equals(sqlDataReader["ID"].ToString()) == false)
                        //{
                        item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        // }
                        if (DBNull.Value.Equals(sqlDataReader["JobName"].ToString()) == false)
                        {
                            item.Job = sqlDataReader["JobName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCode"].ToString()) == false)
                        {
                            item.JobCode = sqlDataReader["JobCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCreationAllocationID"].ToString()) == false)
                        {
                            item.JobCreationAllocationID = Convert.ToInt64(sqlDataReader["JobCreationAllocationID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ScheduleType"].ToString()) == false)
                        //{
                        //    item.Schedule = sqlDataReader["ScheduleType"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["SubScheduleType"].ToString()) == false)
                        //{
                        //    item.ScheduleSubType = Convert.ToString(sqlDataReader["SubScheduleType"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = Convert.ToString(sqlDataReader["FromTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UpToTime"].ToString()) == false)
                        {
                            item.UpToTime = Convert.ToString(sqlDataReader["UpToTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> SelectByCRMSaleJobUserJobScheduleSheetID(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.ID));

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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();

                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleJobUserJobScheduleSheetID"].ToString()) == false)
                        {
                            item.ID = Convert.ToInt64(sqlDataReader["CRMSaleJobUserJobScheduleSheetID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = sqlDataReader["ScheduleDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScheduleType"].ToString()) == false)
                        {
                            item.ScheduleType = Convert.ToInt16(sqlDataReader["ScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubScheduleType"].ToString()) == false)
                        {
                            item.SubScheduleType = Convert.ToInt16(sqlDataReader["SubScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = Convert.ToString(sqlDataReader["FromTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UpToTime"].ToString()) == false)
                        {
                            item.UpToTime = Convert.ToString(sqlDataReader["UpToTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = Convert.ToString(sqlDataReader["AccountName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContactPerson"].ToString()) == false)
                        {
                            item.ContactPerson = Convert.ToString(sqlDataReader["ContactPerson"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_SelectOne' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> InsertCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (item.JobCreationAllocationID > 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@biJobCreationAllocationID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobCreationAllocationID));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@biJobCreationAllocationID", SqlDbType.BigInt, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobType", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.TransactionDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tFromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.FromTime)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tUpToTime", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.UpToTime)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siScheduleType", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScheduleType));
                    if (item.ScheduleType == 1)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siSubScheduleType", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SubScheduleType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@siSubScheduleType", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAttendOther", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsAttendOther));
                    if (item.IsAttendOther == true)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherListEmployeId", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OtherListEmployeId));
                        cmdToExecute.Parameters.Add(new SqlParameter("@xOtherListEmployeIDXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OtherListEmployeIDXml));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsOtherListEmployeId", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@xOtherListEmployeIDXml", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCallerJobStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsScheduleDescription", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScheduleDescription));
                    if (item.GeneralOtherJobTypeID > 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiGeneralOtherJobTypeID", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralOtherJobTypeID));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRelatedwith", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Relatedwith));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiGeneralOtherJobTypeID", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsRelatedwith", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biID", SqlDbType.BigInt, 0, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                        item.ID = (Int64)cmdToExecute.Parameters["@biID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    //response.Message.Add(new MessageDTO
                    //    //{
                    //    //    ErrorMessage = "Create failed"
                    //    //});
                    //    response.Entity = item;
                    //}
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_Insert' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.SmallInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_Update' reported the ErrorCode: " + _errorCode);
                    }

                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                }
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

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> DeleteCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCRMSaleAccountProgressTypeRuleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_Delete' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheet_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (searchRequest.SelectedDate != null && searchRequest.SelectedDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSelectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.SelectedDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSelectedDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CallerJobStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 400, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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
                    //DataTable dt = new DataTable();
                    //dt.Rows.Add(sqlDataReader);

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();


                        item.ID = Convert.ToInt64(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = Convert.ToString(sqlDataReader["ScheduleDescription"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCreationAllocationID"].ToString()) == false)
                        {
                            item.JobCreationAllocationID = Convert.ToInt64(sqlDataReader["JobCreationAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleType"].ToString()) == false)
                        {
                            item.ScheduleType = Convert.ToInt16(sqlDataReader["ScheduleType"].ToString());
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubScheduleType"].ToString()) == false)
                        {
                            item.SubScheduleType = Convert.ToInt16(sqlDataReader["SubScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = Convert.ToString(sqlDataReader["FromTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UpToTime"].ToString()) == false)
                        {
                            item.UpToTime = Convert.ToString(sqlDataReader["UpToTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"]) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = Convert.ToString(sqlDataReader["TransactionDate"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleEmployeeJobsName_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobType", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.JobType));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryAccountMasterId", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryAccountMasterId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEnquiryAccountContactPersonId", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EnquiryAccountContactPersonId));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();

                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleJobCreationAllocationID"].ToString()) == false)
                        {
                            item.JobCreationAllocationID = Convert.ToInt32(sqlDataReader["CRMSaleJobCreationAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobName"].ToString()) == false)
                        {
                            item.JobName = sqlDataReader["JobName"].ToString();
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        //{
                        //    item.AccountName = sqlDataReader["AccountName"].ToString();
                        //}
                        //if (DBNull.Value.Equals(sqlDataReader["ContactPerson"].ToString()) == false)
                        //{
                        //    item.ContactPerson = sqlDataReader["ContactPerson"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEmployeeJobsName_SearchList' reported the ErrorCode: " + _errorCode);
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


        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetGeneralOtherJobTypeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralOtherJobType_SearchList";
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();

                        if (DBNull.Value.Equals(sqlDataReader["GeneralOtherJobTypeID"].ToString()) == false)
                        {
                            item.GeneralOtherJobTypeID = Convert.ToInt16(sqlDataReader["GeneralOtherJobTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Relatedwith"].ToString()) == false)
                        {
                            item.Relatedwith = sqlDataReader["Relatedwith"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_GeneralOtherJobType_SearchList' reported the ErrorCode: " + _errorCode);
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


        //CRMSaleJobUserJobScheduleSheetUpdate
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleSheetUpdate_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    if (searchRequest.TransactionDate != null && searchRequest.TransactionDate != string.Empty)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(searchRequest.TransactionDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiScheduleStatus", SqlDbType.TinyInt, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.MeetingStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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
                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();
                        item.ID = Convert.ToInt64(sqlDataReader["CRMSaleJobUserJobScheduleSheetID"]);
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleDescription"].ToString()) == false)
                        {
                            item.ScheduleDescription = sqlDataReader["ScheduleDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TransactionDate"].ToString()) == false)
                        {
                            item.TransactionDate = sqlDataReader["TransactionDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FromTime"].ToString()) == false)
                        {
                            item.FromTime = Convert.ToString(sqlDataReader["FromTime"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UpToTime"].ToString()) == false)
                        {
                            item.UpToTime = sqlDataReader["UpToTime"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScheduleType"].ToString()) == false)
                        {
                            item.ScheduleType = Convert.ToInt16(sqlDataReader["ScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SubScheduleType"].ToString()) == false)
                        {
                            item.SubScheduleType = Convert.ToInt16(sqlDataReader["SubScheduleType"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallerJobStatus"].ToString()) == false)
                        {
                            item.CallerJobStatus = Convert.ToInt16(sqlDataReader["CallerJobStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCreationAllocationID"].ToString()) == false)
                        {
                            item.JobCreationAllocationID = Convert.ToInt64(sqlDataReader["JobCreationAllocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CRMSaleCallMasterID"].ToString()) == false)
                        {
                            item.CRMSaleCallMasterID = Convert.ToInt64(sqlDataReader["CRMSaleCallMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallEnquiryMasterID"].ToString()) == false)
                        {
                            item.CallEnquiryMasterID = Convert.ToInt64(sqlDataReader["CallEnquiryMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["UpdateStatus"].ToString()) == false)
                        {
                            item.UpdateStatus = Convert.ToBoolean(sqlDataReader["UpdateStatus"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsInvitation"].ToString()) == false)
                        {
                            item.IsInvitation = Convert.ToBoolean(sqlDataReader["IsInvitation"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> response = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleJobUserJobScheduleStatusUpdate_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@biJobCreationAllocationID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.JobCreationAllocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCallEnquiryMasterID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallEnquiryMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCRMJobUserJobScheduleId", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@biCRMSaleCallMasterId", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CRMSaleCallMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiScheduleStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ScheduleStatus));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsReasonRemark", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Remark));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dVisistedLat", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dVisistedLang", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));

                    //if (item.ScheduleType > 0)
                    //{
                        cmdToExecute.Parameters.Add(new SqlParameter("@siScheduleType", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ScheduleType));
                    //} else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siScheduleType", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}

                    //if(item.SubScheduleType >0)
                    //{
                        cmdToExecute.Parameters.Add(new SqlParameter("@siScheduleSubType", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.SubScheduleType));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@siScheduleSubType", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}

                    if (item.NextDate != null && item.NextDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtNextCallDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.NextDate)));
                    } else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtNextCallDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NextFromTime != null && item.NextFromTime != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tNextFromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.NextFromTime)));
                    } else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tNextFromTime", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.NextUpToTime != null && item.NextUpToTime != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tNextUpToTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.NextUpToTime)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tNextUpToTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    //---CRMSaleCallMaster--
                    //if (item.CallStatus > 0)
                    //{
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallStatus));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}

                    //---CRMSaleCallDetails--
                    //if (item.Interestlevel > 0)
                    //{
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiInterestlevel", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.Interestlevel));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiInterestlevel", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    //if (item.CallerJobStatus > 0)
                    //{
                        cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CallerJobStatus));
                    //}
                    //else
                    //{
                    //    cmdToExecute.Parameters.Add(new SqlParameter("@tiCallerJobStatus", SqlDbType.TinyInt, 3, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    //}
                    if (item.FollowUpType != null && item.FollowUpType != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFallowupType", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FollowUpType));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sFallowupType", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    

                    //---if Meeting type survey
                    if (item.ServeyDate != null && item.ServeyDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSurveyDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ServeyDate)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dtSurveyDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ServeyTime != null && item.ServeyTime != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tSurveyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ServeyTime)));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@tSurveyTime", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMoveFromLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMoveToLocation", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    if (item.FromAddress != null && item.FromAddress != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.FromAddress));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsFromAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.ToAddress != null && item.ToAddress != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsToAdress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ToAddress));
                    }else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsToAdress", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    if (item.VisitingCardName != null && item.VisitingCardName != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.VisitingCardName));
                    }else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sVisitingCardPath", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@dtTransactionDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.TransactionDate)));
                    if (item.ToMail != null && item.ToMail != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sToContactPersons", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (item.ContactPerson).Trim()));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@sToContactPersons", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if(item.ToSubject != null && item.ToSubject != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubject", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ToSubject));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsSubject", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleJobUserJobScheduleSheet_Update' reported the ErrorCode: " + _errorCode);
                    }

                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                }
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


        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetAllocatedJobEmployeeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMSaleAllocatedJobEmployeesName_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iJobCreationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.JobCreationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
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

                    baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
                    while (sqlDataReader.Read())
                    {
                        CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();
                        
                        if (DBNull.Value.Equals(sqlDataReader["AccountName"].ToString()) == false)
                        {
                            item.AccountName = sqlDataReader["AccountName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ContactPerson"].ToString()) == false)
                        {
                            item.ContactPerson = sqlDataReader["ContactPerson"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_CRMSaleEmployeeJobsName_SearchList' reported the ErrorCode: " + _errorCode);
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

        ////Get Todays Meeting Schedule.
        //public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetListTodaysMeetingSchedule(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    SqlDataReader sqlDataReader = null;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(searchRequest.ConnectionString))
        //        {
        //            baseEntityCollection.Message.Add(new MessageDTO()
        //            {
        //                ErrorMessage = "Connection string is empty.",
        //                MessageType = MessageTypeEnum.Error
        //            });
        //        }
        //        else
        //        {
        //            // Use base class' connection object
        //            _mainConnection.ConnectionString = searchRequest.ConnectionString;

        //            cmdToExecute.Connection = _mainConnection;
        //            cmdToExecute.CommandText = "dbo.USP_GetTodaysMeetingScheduleList_SelectAll";
        //            cmdToExecute.CommandType = CommandType.StoredProcedure;
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
        //            cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
        //            if (_mainConnectionIsCreatedLocal)
        //            {
        //                // Open connection.
        //                _mainConnection.Open();
        //            }
        //            else
        //            {
        //                if (_mainConnectionProvider.IsTransactionPending)
        //                {
        //                    cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //                }
        //            }

        //            sqlDataReader = cmdToExecute.ExecuteReader();

        //            baseEntityCollection.CollectionResponse = new List<CRMSaleJobUserJobScheduleSheet>();
        //            while (sqlDataReader.Read())
        //            {
        //                CRMSaleJobUserJobScheduleSheet item = new CRMSaleJobUserJobScheduleSheet();
        //                    item.ScheduleDescription = sqlDataReader["ScheduleDescription"].ToString();                           
        //                    item.SubScheduleType = Convert.ToInt16(sqlDataReader["SubScheduleType"]);                            

        //                baseEntityCollection.CollectionResponse.Add(item);

        //            }

        //            if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
        //            {
        //                _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
        //            }
        //            if (_errorCode != (int)ErrorEnum.AllOk)
        //            {
        //                // Throw error.
        //                throw new Exception("Stored Procedure 'USP_GetTodaysMeetingScheduleList_SelectAll' reported the ErrorCode: " + _errorCode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        baseEntityCollection.Message.Add(new MessageDTO()
        //        {
        //            ErrorMessage = ex.InnerException.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        // _logException.Error(ex.Message);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //    }
        //    return baseEntityCollection;
        //}



        #endregion

    }
}

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public class CRMJobCreationMasterAndAllocationDataProvider : DBInteractionBase, ICRMJobCreationMasterAndAllocationDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CRMJobCreationMasterAndAllocationDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CRMJobCreationMasterAndAllocationDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from CRMJobCreationMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetCRMJobCreationMasterAndAllocationBySearch(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
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
                    baseEntityCollection.CollectionResponse = new List<CRMJobCreationMasterAndAllocation>();
                    while (sqlDataReader.Read())
                    {
                        CRMJobCreationMasterAndAllocation item = new CRMJobCreationMasterAndAllocation();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                        item.JobCreationMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.JobName = sqlDataReader["JobName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCode"]) == false)
                        {
                            item.JobCode = sqlDataReader["JobCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobStartDate"]) == false)
                        {
                            item.JobStartDate = Convert.ToString(sqlDataReader["JobStartDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobEndDate"]) == false)
                        {
                            item.JobEndDate = Convert.ToString(sqlDataReader["JobEndDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallTypeID"]) == false)
                        {
                            item.CallTypeID = Convert.ToInt16(sqlDataReader["CallTypeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallTypeDescription"]) == false)
                        {
                            item.CallTypeDescription = sqlDataReader["CallTypeDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsExpire"]) == false)
                        {
                            item.IsExpire = Convert.ToBoolean(sqlDataReader["IsExpire"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMJobCreationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> GetCRMJobCreationMasterAndAllocationByID(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMasterAndAllocation_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobCreationMasterID));
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
                        CRMJobCreationMasterAndAllocation _item = new CRMJobCreationMasterAndAllocation();
                        _item.JobCreationMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["JobName"]) == false)
                        {
                            _item.JobName = sqlDataReader["JobName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobCode"]) == false)
                        {
                            _item.JobCode = sqlDataReader["JobCode"].ToString();
                        }   
                        if (DBNull.Value.Equals(sqlDataReader["JobStartDate"]) == false)
                        {
                            _item.JobStartDate = Convert.ToString(sqlDataReader["JobStartDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["JobEndDate"]) == false)
                        {
                            _item.JobEndDate = Convert.ToString(sqlDataReader["JobEndDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CallTypeID"]) == false)
                        {
                            _item.CallTypeID = Convert.ToInt16(sqlDataReader["CallTypeID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        //{
                        //    _item.IsNeededCaptureData = Convert.ToBoolean(sqlDataReader["IsNeededCaptureData"]);
                        //}

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
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> InsertCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMasterAndDetails_InsertUpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.JobCreationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobName", SqlDbType.NVarChar, 0,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.JobName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daJobStartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.JobStartDate)));
                    if (item.JobEndDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJobEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJobEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.JobEndDate)));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCallTypeID", SqlDbType.SmallInt, 5,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CallTypeID));
                //    cmdToExecute.Parameters.Add(new SqlParameter("@xJobAllocationDetailsXMLstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobAllocationDetailsXMLstring.Trim()));                     
                    if (item.JobAllocationDetailsXMLstring == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xJobAllocationDetailsXMLstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xJobAllocationDetailsXMLstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobAllocationDetailsXMLstring.Trim()));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsNeededCaptureData", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsNeededCaptureData));
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
                        item.JobCreationMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
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
                        throw new Exception("Stored Procedure 'USP_CRMJobCreationMasterAndDetails_InsertUpdateXML' reported the ErrorCode: " +
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
        /// <summary>
        /// Update a specific record of CRMJobCreationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> UpdateCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMasterAndDetails_InsertUpdateXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.JobCreationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, String.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daJobStartDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    if (item.JobEndDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJobEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daJobEndDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.JobEndDate)));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@siCallTypeID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.CallTypeID));
                    if (item.JobAllocationDetailsXMLstring == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xJobAllocationDetailsXMLstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@xJobAllocationDetailsXMLstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobAllocationDetailsXMLstring.Trim()));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                        throw new Exception("Stored Procedure 'USP_CRMJobCreationMasterAndDetails_InsertUpdateXML' reported the ErrorCode: " + _errorCode);
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
        /// Delete a specific record of CRMJobCreationMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> DeleteCRMJobCreationMasterAndAllocation(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.JobCreationMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    item.JobCreationMasterID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_CRMJobCreationMaster_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> GetByCRMJobListByEmployeeID(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobCreationMaster_ByEmployeeID";
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
                    baseEntityCollection.CollectionResponse = new List<CRMJobCreationMasterAndAllocation>();
                    while (sqlDataReader.Read())
                    {
                        CRMJobCreationMasterAndAllocation item = new CRMJobCreationMasterAndAllocation();
                        item.JobCreationMasterID = Convert.ToInt32(sqlDataReader["ID"]);
                        item.JobName = sqlDataReader["JobName"].ToString();
                        item.JobCode = sqlDataReader["JobCode"].ToString();
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMJobCreationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// Select a record from table to find duplicate job name
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMJobCreationMasterAndAllocation> SearchForDuplicateJobName(CRMJobCreationMasterAndAllocation item)
        {
            IBaseEntityResponse<CRMJobCreationMasterAndAllocation> response = new BaseEntityResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_SearchForDuplicateJobName";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsJobName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.JobName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bExists", SqlDbType.Bit, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.IsExists));
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
                    sqlDataReader.Close();
                    CRMJobCreationMasterAndAllocation _item = new CRMJobCreationMasterAndAllocation();
                    response.Entity = _item;
                    if (cmdToExecute.Parameters["@bExists"].Value != DBNull.Value)
                    {
                        _item.IsExists = Convert.ToBoolean(cmdToExecute.Parameters["@bExists"].Value);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_SearchForDuplicateJobName' reported the ErrorCode: " + _errorCode);
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
        /// Select all record from CRMJobCreationMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> CRMJobAllocationList(CRMJobCreationMasterAndAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<CRMJobCreationMasterAndAllocation>();
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
                    cmdToExecute.CommandText = "dbo.USP_CRMJobAllocationList_SelectByJobCreationMasterID";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iJobCreationMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.JobCreationMasterID));
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
                    baseEntityCollection.CollectionResponse = new List<CRMJobCreationMasterAndAllocation>();
                    while (sqlDataReader.Read())
                    {
                        CRMJobCreationMasterAndAllocation item = new CRMJobCreationMasterAndAllocation();
                        if (DBNull.Value.Equals(sqlDataReader["AdminRoleMasterID"]) == false)
                        {
                            item.AdminRoleMasterID = Convert.ToInt32(sqlDataReader["AdminRoleMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeName"]) == false)
                        {
                            item.EmployeeName = Convert.ToString(sqlDataReader["EmployeeName"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PerDayCallTarget"]) == false)
                        {
                            item.PerDayCallTarget = Convert.ToInt16(sqlDataReader["PerDayCallTarget"]);
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
                        throw new Exception("Stored Procedure 'USP_CRMJobCreationMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

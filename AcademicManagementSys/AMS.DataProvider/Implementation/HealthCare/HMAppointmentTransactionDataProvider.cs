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
    public class HMAppointmentTransactionDataProvider : DBInteractionBase, IHMAppointmentTransactionDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public HMAppointmentTransactionDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public HMAppointmentTransactionDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from HMAppointmentTransaction table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionBySearch(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<HMAppointmentTransaction>();
                    while (sqlDataReader.Read())
                    {
                        HMAppointmentTransaction item = new HMAppointmentTransaction();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                      //  item.RoomType = sqlDataReader["RoomType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RoomType"]);
                        

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
                        throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetHMAppointmentTransactionSearchList(HMAppointmentTransactionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMAppointmentTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<HMAppointmentTransaction>();
                    while (sqlDataReader.Read())
                    {
                        HMAppointmentTransaction item = new HMAppointmentTransaction();
                        //item.ID = Convert.ToInt16(sqlDataReader["HMAppointmentTransactionID"]);
                        //item.AttributeName = sqlDataReader["AttributeName"].ToString();
                        //item.MarchandiseBaseCategoryCode = Convert.ToString(sqlDataReader["MarchandiseBaseCatgoryCode"]);

                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<HMAppointmentTransaction> GetHMAppointmentTransactionByID(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_SelectOne";
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
                        HMAppointmentTransaction _item = new HMAppointmentTransaction();
                        _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                       // _item.OPDName = sqlDataReader["OPDName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OPDName"]);
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
        public IBaseEntityResponse<HMAppointmentTransaction> InsertHMAppointmentTransaction(HMAppointmentTransaction item) 
        {
            IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    if (item.TransactionDate == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionDate", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsTransactionDate", SqlDbType.NVarChar, 50,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.TransactionDate));
                    }
                    if (item.IsNewPatient == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsNewPatient", SqlDbType.Bit, 16,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.IsNewPatient));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@bIsNewPatient", SqlDbType.Bit, 16,
                                                   ParameterDirection.Input, false, 10, 0, "",
                                                   DataRowVersion.Proposed, item.IsNewPatient));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralPatientMasterId", SqlDbType.Int, 4, 
                                               ParameterDirection.Input, true, 10, 0, "",
                                               DataRowVersion.Proposed, item.GeneralPatientMasterId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSymtomp",SqlDbType.NVarChar,100,
                                               ParameterDirection.Input,false,10,0,"",
                                               DataRowVersion.Proposed,item.Symtomp));
                    if(item.CaseHistoryNumber== null)
                    {
                      cmdToExecute.Parameters.Add(new SqlParameter("@nsCaseHistoryNumber", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsCaseHistoryNumber", SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.CaseHistoryNumber));
                    }
                    if (item.ConsultantID == null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iConsultantID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@iConsultantID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, false, 10, 0, "",
                                                DataRowVersion.Proposed, item.ConsultantID));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNextAppointmentDate", SqlDbType.NVarChar, 100,
                                               ParameterDirection.Input, false, 10, 0, "",
                                               DataRowVersion.Proposed, item.NextAppointmentDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.Status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iHMOPDHealthCentreID", SqlDbType.Int, 4,
                                                ParameterDirection.Input, true, 10, 0, "",
                                                DataRowVersion.Proposed, item.HMOPDHealthCentreID));
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
                    //if (_rowsAffected > 0)
                    //{
                    //    item.ID = (Int16)cmdToExecute.Parameters["@iGeneralItemMarchandiseBaseCatgoryID"].Value;
                    //}

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    //if (_errorCode != (int)ErrorEnum.AllOk)
                    //{
                    //    // Throw error.
                    //    throw new Exception("Stored Procedure 'dbo.USP_HMAppointmentTransaction_Insert' reported the ErrorCode: " +
                    //                    _errorCode);
                    //}
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
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        //Throw error.
                        throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of HMAppointmentTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> UpdateHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,
                                        ParameterDirection.Input, false, 0, 0, "",
                                        DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsOPDName", SqlDbType.NVarChar, 30,
                    //                    ParameterDirection.Input, false, 10, 0, "",
                    //                    DataRowVersion.Proposed, item.OPDName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCounterCode", SqlDbType.NVarChar,20,
                    //                    ParameterDirection.Input, false, 0, 0, "",
                    //                    DataRowVersion.Proposed, item.CounterCode));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4,
                                        ParameterDirection.Input, true, 10, 0, "",
                                        DataRowVersion.Proposed, item.ModifiedBy));
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
                    // item.ID = (Int16)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_HMAppointmentTransaction_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of HMAppointmentTransaction
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMAppointmentTransaction> DeleteHMAppointmentTransaction(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
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
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_Delete' reported the ErrorCode: " + _errorCode);
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

        //for general
        /// <summary>
        /// Select all record from HMAppointmentTransaction table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        /// 

         public IBaseEntityResponse<HMAppointmentTransaction> GetGeneralDataByGeneralPatientMasterId(HMAppointmentTransaction item)
        {
            IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_General";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralPatientMasterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralPatientMasterId));
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
                        HMAppointmentTransaction _item = new HMAppointmentTransaction();

                        _item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                        _item.Name = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);
                        _item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                        _item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        _item.Symtomp = sqlDataReader["Note"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Note"]);
                        _item.Status = sqlDataReader["Status"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Status"]);
                        _item.NextAppointmentDate = sqlDataReader["NextAppointmentDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NextAppointmentDate"]);
                        _item.HMOPDHealthCentreID = sqlDataReader["HMOPDHealthCentreID"] is DBNull ? new Int16 ():Convert.ToInt16(sqlDataReader["HMOPDHealthCentreID"]);



                        DateTime NextAppointmentDate = Convert.ToDateTime(_item.NextAppointmentDate);
                        _item.NextAppointmentDate = NextAppointmentDate.ToString("dd/MM/yyyy");
                      
                        //DateTime NextAppointmentDate = Convert.ToDateTime(_item.NextAppointmentDate);
                        //_item.NextAppointmentDate    =Convert.ToString("DD/MM/YYYY");
                        response.Entity = _item;
                      
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                //baseEntityCollection.Message.Add(new MessageDTO()
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
        ///For Last Case History
        ///
         public IBaseEntityResponse<HMAppointmentTransaction> LastcaseHistory(HMAppointmentTransaction item)
         {
             IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                     cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_LastcaseHistory";
                     cmdToExecute.CommandType = CommandType.StoredProcedure;
                     cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                     cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralPatientMasterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralPatientMasterId));
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
                         HMAppointmentTransaction _item = new HMAppointmentTransaction();

                         _item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                         _item.Symtomp = sqlDataReader["Symtomp"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Symtomp"]);
                         _item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                         _item.GeneralPatientMasterId = sqlDataReader["GeneralPatientMasterId"] is DBNull ? new Int64(): Convert.ToInt64(sqlDataReader["GeneralPatientMasterId"]);
                         _item.CaseHistoryNumber = sqlDataReader["CaseHistoryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CaseHistoryNumber"]);
                         _item.AppointmentTransactionId = sqlDataReader["AppointmentTransactionId"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["AppointmentTransactionId"]);
                         _item.TreatmentName = sqlDataReader["TreatmentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TreatmentName"]);
                         _item.TreatmentDescription = sqlDataReader["TreatmentDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TreatmentDescription"]);
                         _item.ConsultantID = sqlDataReader["ConsultantID"] is DBNull ? new Int32 (): Convert.ToInt32(sqlDataReader["ConsultantID"]);
                         _item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);

                         DateTime TransactionDate = Convert.ToDateTime(_item.TransactionDate);
                         _item.TransactionDate = TransactionDate.ToString("dd/MM/yyyy");
                      

                         response.Entity = _item;

                     }
                     if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                     {
                         _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                     }
                     if (_errorCode != (int)ErrorEnum.AllOk)
                     {
                         // Throw error.
                         throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
                     }
                 }
             }
             catch (Exception ex)
             {
                 //baseEntityCollection.Message.Add(new MessageDTO()
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
        //ForLastPriscription

         public IBaseEntityResponse<HMAppointmentTransaction> LastPrescription(HMAppointmentTransaction item)
         {
             IBaseEntityResponse<HMAppointmentTransaction> response = new BaseEntityResponse<HMAppointmentTransaction>();
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
                     cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_LastPriscription";
                     cmdToExecute.CommandType = CommandType.StoredProcedure;
                     cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                     cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralPatientMasterId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralPatientMasterId));
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
                         HMAppointmentTransaction _item = new HMAppointmentTransaction();

                         _item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                         _item.Symtomp = sqlDataReader["Symtomp"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Symtomp"]);
                         _item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                         _item.GeneralPatientMasterId = sqlDataReader["GeneralPatientMasterId"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["GeneralPatientMasterId"]);
                         _item.CaseHistoryNumber = sqlDataReader["CaseHistoryNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CaseHistoryNumber"]);

                         _item.Status = sqlDataReader["Status"] is DBNull ? new Byte() : Convert.ToByte(sqlDataReader["Status"]);
                         //_item.TreatmentDescription = sqlDataReader["TreatmentDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TreatmentDescription"]);
                         _item.ConsultantID = sqlDataReader["ConsultantID"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ConsultantID"]);
                         _item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                         _item.DosesDescription = sqlDataReader["DosesDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DosesDescription"]);
                         _item.ForNumberOfDays = sqlDataReader["ForNumberOfDays"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ForNumberOfDays"]);
                        
                         DateTime TransactionDate = Convert.ToDateTime(_item.TransactionDate);
                         _item.TransactionDate = TransactionDate.ToString("dd/MM/yyyy");


                         response.Entity = _item;

                     }
                     if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                     {
                         _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                     }
                     if (_errorCode != (int)ErrorEnum.AllOk)
                     {
                         // Throw error.
                         throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
                     }
                 }
             }
             catch (Exception ex)
             {
                 //baseEntityCollection.Message.Add(new MessageDTO()
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
        //List of patient 
         public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetListOfPatient(HMAppointmentTransactionSearchRequest searchRequest)
         {
             //throw new NotImplementedException();
             IBaseEntityCollectionResponse<HMAppointmentTransaction> baseEntityCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
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
                     cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_GetSearchListForPatientInfo";
                     cmdToExecute.CommandType = CommandType.StoredProcedure;
                     //-----------------------------------------------------Output Parameters ------------------------------------------------------------------
                     cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                     //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                     cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                     //-----------------------------------------------------Input Parameters ------------------------------------------------------------------
                     //scmdToExecute.Parameters.Add(new SqlParameter("@iStatusFlag", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StatusFlag));

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

                     baseEntityCollection.CollectionResponse = new List<HMAppointmentTransaction>();
                     while (sqlDataReader.Read())
                     {
                         HMAppointmentTransaction item = new HMAppointmentTransaction();
                         item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                         item.PatientName = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);
                         item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                         item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                         item.symtoms = sqlDataReader["Note"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Note"]);
                         item.NextAppointmentDate = sqlDataReader["NextAppointmentDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NextAppointmentDate"]);
                         item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                         item.IsCaseClosed = sqlDataReader["IsCaseClosed"] is DBNull ? new bool() : Convert.ToBoolean(sqlDataReader["IsCaseClosed"]);
                         item.Status = sqlDataReader["Status"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Status"]);
                         item.HMOPDHealthCentreID = sqlDataReader["HMOPDHealthCentreID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["HMOPDHealthCentreID"]);
                         baseEntityCollection.CollectionResponse.Add(item);
                     }

                     if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                     {
                         _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                     }
                     if (_errorCode != (int)ErrorEnum.AllOk)
                     {
                         // Throw error.
                         throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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
        //For Paitent Appointment
         /// <summary>
         /// Select all record from HMAppointmentTransaction table with search parameters
         /// </summary>
         /// <param name="searchRequest"></param>
         /// <returns></returns>
         public IBaseEntityCollectionResponse<HMAppointmentTransaction> GetAppointmentData(HMAppointmentTransactionSearchRequest searchRequest)
         {
             IBaseEntityCollectionResponse<HMAppointmentTransaction> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<HMAppointmentTransaction>();
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
                     cmdToExecute.CommandText = "dbo.USP_HMAppointmentTransaction_SelectAll";
                     cmdToExecute.CommandType = CommandType.StoredProcedure;
                     cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                     cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar,100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                     cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                     cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                     cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
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
                     baseEntityCollection.CollectionResponse = new List<HMAppointmentTransaction>();
                     while (sqlDataReader.Read())
                     {
                         HMAppointmentTransaction item = new HMAppointmentTransaction();

                         item.ID = sqlDataReader["ID"] is DBNull ? new Int64() : Convert.ToInt64(sqlDataReader["ID"]);
                         item.GeneralPatientMasterId = sqlDataReader["GeneralPatientMasterId"] is DBNull ?new Int64():Convert.ToInt64(sqlDataReader["GeneralPatientMasterId"]);
                         item.PatientName = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);
                         item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                         item.OPDName = sqlDataReader["OPDName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["OPDName"]);
                         item.HMOPDHealthCentreID = sqlDataReader["HMOPDHealthCentreID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["HMOPDHealthCentreID"]);
                         item.Status = sqlDataReader["Status"] is DBNull ? new byte(): Convert.ToByte(sqlDataReader["Status"]);


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
                         throw new Exception("Stored Procedure 'USP_HMAppointmentTransaction_SelectAll' reported the ErrorCode: " + _errorCode);
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

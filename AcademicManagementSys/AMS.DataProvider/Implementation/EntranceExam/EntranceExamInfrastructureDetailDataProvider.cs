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
    public class EntranceExamInfrastructureDetailDataProvider : DBInteractionBase, IEntranceExamInfrastructureDetailDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        
        /// Constructor to initialized data member and member functions        
        public EntranceExamInfrastructureDetailDataProvider()
        {
        }
        
        /// Constructor to initialized data member and member functions        
        public EntranceExamInfrastructureDetailDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        #region Method Implementation

        // EntranceExamAvailableCentres Method
        #region EntranceExamAvailableCentres

        /// Select all record from EntranceExamAvailableCentres table with search parameters        
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_SelectAll";
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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamInfrastructureDetail>();
                    while (sqlDataReader.Read())
                    {
                        EntranceExamInfrastructureDetail item = new EntranceExamInfrastructureDetail();

                        //Property of EntranceExamAvailableCentres
                        item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        item.CentreName = sqlDataReader["CentreName"].ToString();
                        item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        item.Address = sqlDataReader["Address"].ToString();
                        item.ActiveFrom = sqlDataReader["ActiveFrom"].ToString();
                        item.ActiveUpto = sqlDataReader["ActiveFrom"].ToString();
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamInfrastructureDetailID"]) == false)
                        {
                            item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        }
                      
                        if (sqlDataReader["RoomName"] != null){
                            item.RoomName = sqlDataReader["RoomName"].ToString();
                        }
                        else { 
                            item.RoomName = "";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomNumber"]) == false)
                        {
                            item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                        }
                        if (sqlDataReader["ExtraDescription"] != null){
                            item.ExtraDescription = sqlDataReader["ExtraDescription"].ToString();
                        }
                        else { 
                            item.ExtraDescription = "";
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomCapacity"]) == false)
                        {
                            item.RoomCapacity = Convert.ToInt32(sqlDataReader["RoomCapacity"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamAvailableCentres_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from EntranceExamAvailableCentres table by ID        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresByID(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAvailableCentres_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
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
                        EntranceExamInfrastructureDetail _item = new EntranceExamInfrastructureDetail();

                        //Property of EntranceExamAvailableCentres
                        _item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        _item.CentreName = sqlDataReader["CentreName"].ToString();
                        _item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        _item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        _item.Address = sqlDataReader["Address"].ToString();
                        _item.ActiveFrom = sqlDataReader["ActiveFrom"].ToString();
                        _item.ActiveUpto = sqlDataReader["ActiveUpto"].ToString();
                        
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

        /// Create new record of the table        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAvailableCentres_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,Convert.ToDateTime(item.ActiveFrom)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.ActiveUpto)));
                                        
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        item.EntranceExamAvailableCentresID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamAvailableCentres_INSERT' reported the ErrorCode: " + _errorCode);
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

        /// Update a specific record of EntranceExamAvailableCentres        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAvailableCentres_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGenLocationID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.GenLocationID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iTotalRoom", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.TotalRoom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dActiveFrom", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveFrom));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dActiveUpto", SqlDbType.DateTime, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ActiveUpto));
                                                            
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

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamAvailableCentres_Delete' reported the ErrorCode: " + _errorCode);
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

        /// Delete a specific record of EntranceExamAvailableCentres        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAvailableCentres_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    //Property of EntranceExamAvailableCentres
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamAvailableCentresID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.EntranceExamAvailableCentresID = (Int32)cmdToExecute.Parameters["@iEntranceExamAvailableCentresID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamAvailableCentres_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from EntranceExamAvailableCentres table with search list.
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamAvailableCentresSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamAvailableCentres_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamAvailableCentresSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamAvailableCentresSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamInfrastructureDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamInfrastructureDetail item = new EntranceExamInfrastructureDetail();

                        //Property of EntranceExamAvailableCentres
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailableCentresID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["GenLocationID"]) == false)
                        {
                            item.GenLocationID = Convert.ToInt32(sqlDataReader["GenLocationID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalRoom"]) == false)
                        {
                            item.TotalRoom = Convert.ToInt32(sqlDataReader["TotalRoom"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        {
                            item.Address = sqlDataReader["Address"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActiveFrom"]) == false)
                        {
                            item.ActiveFrom = sqlDataReader["ActiveFrom"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ActiveUpto"]) == false)
                        {
                            item.ActiveUpto = sqlDataReader["ActiveUpto"].ToString();
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamAvailableCentres_SearchList' reported the ErrorCode: " + _errorCode);
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

        
        #endregion


        // EntranceExamInfrastructureDetail Method
        #region EntranceExamInfrastructureDetail

        /// Select all record from EntranceExamInfrastructureDetail table with search parameters        
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailBySearch(EntranceExamInfrastructureDetailSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_SelectAll";
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
					baseEntityCollection.CollectionResponse = new List<EntranceExamInfrastructureDetail>();
					while (sqlDataReader.Read())
					{
						EntranceExamInfrastructureDetail item = new EntranceExamInfrastructureDetail();
                                                
                        //Property of EntranceExamInfrastructureDetail
                        item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
						item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailbleCentreID"]);
						item.RoomName = sqlDataReader["RoomName"].ToString();
					   // item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                        if (DBNull.Value.Equals(sqlDataReader["RoomNumber"]) == false)
                        {
                            item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                        }
						item.ExtraDescription = sqlDataReader["ExtraDescription"].ToString();
                        item.RoomCapacity = Convert.ToInt32(sqlDataReader["RoomCapacity"]);

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EntranceExamInfrastructureDetail_SelectAll' reported the ErrorCode: " + _errorCode);
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

        /// Select a record from EntranceExamInfrastructureDetail table by ID        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailByID(EntranceExamInfrastructureDetail item)
		{
			IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
					cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_SelectOne";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
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
						EntranceExamInfrastructureDetail _item = new EntranceExamInfrastructureDetail();
                                                
                        //Property of EntranceExamInfrastructureDetail
                        _item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["ID"]);
						_item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailbleCentreID"]);
						_item.RoomName = sqlDataReader["RoomName"].ToString();
                        _item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
						_item.ExtraDescription = sqlDataReader["ExtraDescription"].ToString();
                        _item.RoomCapacity = Convert.ToInt32(sqlDataReader["RoomCapacity"]);

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
       
        /// Create new record of the table        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> InsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    
                    //Property of EntranceExamInfrastructureDetail
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEntranceExamAvailbleCentreID", SqlDbType.SmallInt, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRoomName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoomName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRoomNumber", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoomNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExtraDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ExtraDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiRoomCapacity", SqlDbType.TinyInt, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoomCapacity));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
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
                        item.EntranceExamInfrastructureDetailID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamInfrastructureDetail_INSERT' reported the ErrorCode: " + _errorCode);
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
        
        /// Update a specific record of EntranceExamInfrastructureDetail        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> UpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    
                    // EntranceExamInfrastructureDetail Table Property.
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@siEntranceExamAvailbleCentreID", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamAvailableCentresID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRoomName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.RoomName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoomNumber", SqlDbType.Int, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoomNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsExtraDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ExtraDescription));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRoomCapacity", SqlDbType.Int, 3, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RoomCapacity));

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

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamInfrastructureDetail_Delete' reported the ErrorCode: " + _errorCode);
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
        
        /// Delete a specific record of EntranceExamInfrastructureDetail        
        public IBaseEntityResponse<EntranceExamInfrastructureDetail> DeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail item)
        {
            IBaseEntityResponse<EntranceExamInfrastructureDetail> response = new BaseEntityResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                                        
                    // EntranceExamInfrastructureDetail Table Property.
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEntranceExamInfrastructureDetailID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.EntranceExamInfrastructureDetailID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 1));
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
                    item.EntranceExamInfrastructureDetailID = (Int32)cmdToExecute.Parameters["@iEntranceExamInfrastructureDetailID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EntranceExamInfrastructureDetail_Delete' reported the ErrorCode: " + _errorCode);
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


        // Select all record from EntranceExamInfrastructureDetail table with search list.
        public IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> GetEntranceExamInfrastructureDetailSearchList(EntranceExamInfrastructureDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EntranceExamInfrastructureDetail> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EntranceExamInfrastructureDetail>();
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
                    cmdToExecute.CommandText = "dbo.USP_EntranceExamInfrastructureDetail_SearchList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEntranceExamInfrastructureDetailSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.EntranceExamInfrastructureDetailSearchWord));

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
                    baseEntityCollection.CollectionResponse = new List<EntranceExamInfrastructureDetail>();

                    while (sqlDataReader.Read())
                    {
                        EntranceExamInfrastructureDetail item = new EntranceExamInfrastructureDetail();
                        
                        // EntranceExamInfrastructureDetail Table Property.
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamInfrastructureDetailID"]) == false)
                        {
                            item.EntranceExamInfrastructureDetailID = Convert.ToInt32(sqlDataReader["EntranceExamInfrastructureDetailID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EntranceExamAvailbleCentreID"]) == false)
                        {
                            item.EntranceExamAvailableCentresID = Convert.ToInt32(sqlDataReader["EntranceExamAvailbleCentreID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomName"]) == false)
                        {
                            item.RoomName = sqlDataReader["RoomName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomNumber"]) == false)
                        {
                            item.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExtraDescription"]) == false)
                        {
                            item.ExtraDescription = sqlDataReader["ExtraDescription"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RoomCapacity"]) == false)
                        {
                            item.RoomCapacity = Convert.ToInt32(sqlDataReader["RoomCapacity"]);
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
                        throw new Exception("Stored Procedure 'USP_EntranceExamInfrastructureDetail_SearchList' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch(Exception ex)
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

        #endregion

        #endregion
    }
}

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
    public class HMPatientMasterDataProvider : DBInteractionBase, IHMPatientMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public HMPatientMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public HMPatientMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from HMPatientMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMPatientMaster> GetHMPatientMasterBySearch(HMPatientMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMPatientMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 100, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
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
                    baseEntityCollection.CollectionResponse = new List<HMPatientMaster>();
                    while (sqlDataReader.Read())
                    {
                        HMPatientMaster item = new HMPatientMaster();

                        item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                        item.PatientCode = sqlDataReader["PatientCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientCode"]);
                        item.PatientName = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);
                       // item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                       // item.LastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                       // item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                         item.Age = sqlDataReader["Age"] is DBNull ? string.Empty:Convert.ToString(sqlDataReader["Age"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        item.DOB = sqlDataReader["DOB"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DOB"]);
                        item.Address = sqlDataReader["Address"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address"]);
                        item.City = sqlDataReader["City"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["City"]);
                        item.PinCode = sqlDataReader["PinCode"] is DBNull ? string.Empty  : Convert.ToString (sqlDataReader["PinCode"]);
                        item.Note = sqlDataReader["Note"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Note"]);
                        item.IdentityNumber = sqlDataReader["IdentityNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IdentityNumber"]);
                        item.FamilyMobileNumber = sqlDataReader["FamilyMobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FamilyMobileNumber"]);
                        item.NextAppointmentDate = sqlDataReader["NextAppointmentDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NextAppointmentDate"]);
                        item.LastAppointmentTransactionID = sqlDataReader["LastAppointmentTransactionID"] is DBNull ? new Int64() : Convert.ToInt16(sqlDataReader["LastAppointmentTransactionID"]);
                        item.IsIPDPatient = sqlDataReader["IsIPDPatient"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["IsIPDPatient"]);

                        //if (DBNull.Value.Equals(sqlDataReader["PatientName"]) == false)
                        //{
                        //    item.PatientName = Convert.ToString(sqlDataReader["FirstName"]) + " " + Convert.ToString(sqlDataReader["MiddleName"]) + " " + Convert.ToString(sqlDataReader["LastName"]);
                        //}

                       // DateTime DOB = Convert.ToDateTime(searchRequest.DOB);
                        //item.DOB = DOB.ToString("d MM yyyy");
                      

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
                        throw new Exception("Stored Procedure 'USP_HMPatientMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<HMPatientMaster> GetHMPatientMasterSearchList(HMPatientMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMPatientMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_GetListForDropDown";
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
                    baseEntityCollection.CollectionResponse = new List<HMPatientMaster>();
                    while (sqlDataReader.Read())
                    {
                        HMPatientMaster item = new HMPatientMaster();
                        //item.ID = Convert.ToInt16(sqlDataReader["HMPatientMasterID"]);
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
                        throw new Exception("Stored Procedure 'USP_HMPatientMaster_SearchList' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<HMPatientMaster> GetHMPatientMasterByID(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> response = new BaseEntityResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_SelectOne";
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
                        HMPatientMaster _item = new HMPatientMaster();
                      //  _item.ID = Convert.ToInt16(sqlDataReader["ID"]);
                        _item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                        _item.PatientCode = sqlDataReader["PatientCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientCode"]);
                       // _item.PatientName = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);

                        _item.FirstName = sqlDataReader["FirstName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FirstName"]);
                        _item.MiddleName = sqlDataReader["MiddleName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["MiddleName"]);
                         _item.LastName = sqlDataReader["LastName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["LastName"]);
                        // _item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                        _item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                        _item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        _item.DOB = sqlDataReader["DOB"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DOB"]);
                        _item.Address = sqlDataReader["Address"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Address"]);
                        _item.City = sqlDataReader["City"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["City"]);
                        _item.PinCode = sqlDataReader["PinCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PinCode"]);
                        _item.Note = sqlDataReader["Note"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Note"]);
                        _item.IdentityNumber = sqlDataReader["IdentityNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["IdentityNumber"]);
                        _item.FamilyMobileNumber = sqlDataReader["FamilyMobileNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FamilyMobileNumber"]);
                        _item.NextAppointmentDate = sqlDataReader["NextAppointmentDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NextAppointmentDate"]);
                        _item.LastAppointmentTransactionID = sqlDataReader["LastAppointmentTransactionID"] is DBNull ? new Int64() : Convert.ToInt16(sqlDataReader["LastAppointmentTransactionID"]);
                        _item.IsIPDPatient = sqlDataReader["IsIPDPatient"] is DBNull ? new Boolean() : Convert.ToBoolean(sqlDataReader["IsIPDPatient"]);
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
        public IBaseEntityResponse<HMPatientMaster> InsertHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> response = new BaseEntityResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_Insert";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsPatientCode", SqlDbType.NVarChar, 100,
                    //                        ParameterDirection.Input, false, 10, 0, "",
                    //                        DataRowVersion.Proposed, item.PatientCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FirstName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.MiddleName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.LastName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAge", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Age));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsGender", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Gender));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDOB ", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.DOB));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCity", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.City));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPinCode", SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.PinCode));
                    if(item.NextAppointmentDate==null)
                    { 
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNextAppointmentDate", SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, DBNull.Value));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsNextAppointmentDate", SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input, false, 10, 0, "",
                                           DataRowVersion.Proposed, item.NextAppointmentDate));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNote", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.Note));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsIdentityNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.IdentityNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFamilyMobileNumber", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input, false, 10, 0, "",
                                            DataRowVersion.Proposed, item.FamilyMobileNumber));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@biLastAppointmentTransactionID", SqlDbType.BigInt, 4,
                                         ParameterDirection.Input, false, 10, 0, "",
                                         DataRowVersion.Proposed, item.LastAppointmentTransactionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsIPDPatient", SqlDbType.Bit, 4,
                                        ParameterDirection.Input, false, 10, 0, "",
                                        DataRowVersion.Proposed, item.IsIPDPatient));


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
                    //    throw new Exception("Stored Procedure 'dbo.USP_HMPatientMaster_Insert' reported the ErrorCode: " +
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
                        throw new Exception("Stored Procedure 'USP_HMPatientMaster_Insert' reported the ErrorCode: " +
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
        /// Update a specific record of HMPatientMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> UpdateHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> response = new BaseEntityResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_Update";
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
                        throw new Exception("Stored Procedure 'dbo.USP_HMPatientMaster_Delete' reported the ErrorCode: " +
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
        /// Delete a specific record of HMPatientMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> DeleteHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> response = new BaseEntityResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_Delete";
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
                        throw new Exception("Stored Procedure 'USP_HMPatientMaster_Delete' reported the ErrorCode: " + _errorCode);
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

        //for Dropdown


        /// <summary>
        /// Select all record from HMPatientMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMPatientMaster> GetListOfPatient(HMPatientMasterSearchRequest searchRequest)
        {
            //throw new NotImplementedException();
            IBaseEntityCollectionResponse<HMPatientMaster> baseEntityCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_HMPatientMaster_GetSearchListForPatientInfo";
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

                    baseEntityCollection.CollectionResponse = new List<HMPatientMaster>();
                    while (sqlDataReader.Read())
                    {
                        HMPatientMaster item = new HMPatientMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["ID"]);
                        item.PatientName = sqlDataReader["PatientName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PatientName"]);
                        item.Age = sqlDataReader["Age"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Age"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        item.symtoms = sqlDataReader["Note"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Note"]);
                        item.NextAppointmentDate = sqlDataReader["NextAppointmentDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["NextAppointmentDate"]);
                        item.TransactionDate = sqlDataReader["TransactionDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TransactionDate"]);
                        item.IsCaseClosed = sqlDataReader["IsCaseClosed"] is DBNull ? new bool(): Convert.ToBoolean(sqlDataReader["IsCaseClosed"]);
                        item.Status = sqlDataReader["Status"] is DBNull ? new byte() : Convert.ToByte(sqlDataReader["Status"]);
                        item.HMOPDHealthCentreID = sqlDataReader["HMOPDHealthCentreID"] is DBNull ? new Int16(): Convert.ToInt16(sqlDataReader["HMOPDHealthCentreID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_HMPatientMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

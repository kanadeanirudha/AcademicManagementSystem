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
    public class FishFishermenMasterDataProvider : DBInteractionBase, IFishFishermenMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FishFishermenMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FishFishermenMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FishFishermenMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FishFishermenMaster> GetFishFishermenMasterBySearch(FishFishermenMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FishFishermenMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FishFishermenMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishFishermenMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //Required value to pass for Procedure

                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsEntityLevel", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EntityLevel));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAdminRoleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AdminRoleMasterID));

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
                    baseEntityCollection.CollectionResponse = new List<FishFishermenMaster>();
                    while (sqlDataReader.Read())
                    {
                        FishFishermenMaster item = new FishFishermenMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FishermenCode"]) == false)
                        {
                            item.FishermenCode = sqlDataReader["FishermenCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NameTitleID"]) == false)
                        {
                            item.NameTitleID = Convert.ToInt32(sqlDataReader["NameTitleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                        {
                            item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                        {
                            item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                        {
                            item.LastName = sqlDataReader["LastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        {
                            item.Address = sqlDataReader["Address"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PostalAddress"]) == false)
                        {
                            item.PostalAddress = sqlDataReader["PostalAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            item.EmailID = sqlDataReader["EmailID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocalMember"]) == false)
                        {
                            item.IsLocalMember = Convert.ToBoolean(sqlDataReader["IsLocalMember"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocalMemberId"]) == false)
                        {
                            item.LocalMemberId = Convert.ToInt32(sqlDataReader["LocalMemberId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFederationMember"]) == false)
                        {
                            item.IsFederationMember = Convert.ToBoolean(sqlDataReader["IsFederationMember"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FederationMemberId"]) == false)
                        {
                            item.FederationMemberId = Convert.ToInt32(sqlDataReader["FederationMemberId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                        {
                            item.Gender = sqlDataReader["Gender"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BirthDate"]) == false)
                        {
                            item.BirthDate = sqlDataReader["BirthDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NationalityID"]) == false)
                        {
                            item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PanNumber"]) == false)
                        {
                            item.PanNumber = sqlDataReader["PanNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdharCardNumber"]) == false)
                        {
                            item.AdharCardNumber = sqlDataReader["AdharCardNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankName"]) == false)
                        {
                            item.BankName = sqlDataReader["BankName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankNumber"]) == false)
                        {
                            item.BankNumber = sqlDataReader["BankNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["DepartmentID"]) == false)
                        //{
                        //    item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        //}
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            item.JoiningDate = (sqlDataReader["JoiningDate"]).ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfLeaving"]) == false)
                        {
                            item.DateOfLeaving = (sqlDataReader["DateOfLeaving"]).ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BioMatrixID"]) == false)
                        {
                            item.BioMatrixID = Convert.ToInt32(sqlDataReader["BioMatrixID"]);
                        }
                        //if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        //{
                        //    item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        //}

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
                        throw new Exception("Stored Procedure 'USP_FishFishermenMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FishFishermenMaster> GetFishFishermenMasterByID(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> response = new BaseEntityResponse<FishFishermenMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishFishermenMaster_SelectOne";
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
                        FishFishermenMaster _item = new FishFishermenMaster();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FishermenCode"]) == false)
                        {
                            _item.FishermenCode = sqlDataReader["FishermenCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NameTitleID"]) == false)
                        {
                            _item.NameTitleID = Convert.ToInt32(sqlDataReader["NameTitleID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FirstName"]) == false)
                        {
                            _item.FirstName = sqlDataReader["FirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MiddleName"]) == false)
                        {
                            _item.MiddleName = sqlDataReader["MiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LastName"]) == false)
                        {
                            _item.LastName = sqlDataReader["LastName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Address"]) == false)
                        {
                            _item.Address = sqlDataReader["Address"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PostalAddress"]) == false)
                        {
                            _item.PostalAddress = sqlDataReader["PostalAddress"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmailID"]) == false)
                        {
                            _item.EmailID = sqlDataReader["EmailID"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsLocalMember"]) == false)
                        {
                            _item.IsLocalMember = Convert.ToBoolean(sqlDataReader["IsLocalMember"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["LocalMemberId"]) == false)
                        {
                            _item.LocalMemberId = Convert.ToInt32(sqlDataReader["LocalMemberId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsFederationMember"]) == false)
                        {
                            _item.IsFederationMember = Convert.ToBoolean(sqlDataReader["IsFederationMember"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["FederationMemberId"]) == false)
                        {
                            _item.FederationMemberId = Convert.ToInt32(sqlDataReader["FederationMemberId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["Gender"]) == false)
                        {
                            _item.Gender = sqlDataReader["Gender"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BirthDate"]) == false)
                        {
                            _item.BirthDate = sqlDataReader["BirthDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["NationalityID"]) == false)
                        {
                            _item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PanNumber"]) == false)
                        {
                            _item.PanNumber = sqlDataReader["PanNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AdharCardNumber"]) == false)
                        {
                            _item.AdharCardNumber = sqlDataReader["AdharCardNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankName"]) == false)
                        {
                            _item.BankName = sqlDataReader["BankName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BankNumber"]) == false)
                        {
                            _item.BankNumber = sqlDataReader["BankNumber"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            _item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        //_item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentID"]);
                        if (DBNull.Value.Equals(sqlDataReader["JoiningDate"]) == false)
                        {
                            _item.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DateOfLeaving"]) == false)
                        {
                            _item.DateOfLeaving = sqlDataReader["DateOfLeaving"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["BioMatrixID"]) == false)
                        {
                            _item.BioMatrixID = Convert.ToInt32(sqlDataReader["BioMatrixID"]);
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
        public IBaseEntityResponse<FishFishermenMaster> InsertFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> response = new BaseEntityResponse<FishFishermenMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishFishermenMaster_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFishermenCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNameTitleID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NameTitleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MiddleName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPostalAddress", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PostalAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsLocalMember", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, !item.IsLocalMember == false ? item.IsLocalMember : false));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLocalMemberId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFederationMember", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsFederationMember));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFederationMemberId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FederationMemberId != null ? item.FederationMemberId : 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 1, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Gender.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBirthDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.BirthDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NationalityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPanNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PanNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdharCardNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 60, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dJoiningDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Convert.ToDateTime(item.JoiningDate)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dDateOfLeaving", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iBioMatrixID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsActive == false ? item.IsActive : false));

                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iUserID", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.UserID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStatus", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.Status));

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
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FishFishermenMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of FishFishermenMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> UpdateFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> response = new BaseEntityResponse<FishFishermenMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishFishermenMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsFishermenCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FishermenCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNameTitleID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NameTitleID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsFirstName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.FirstName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMiddleName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MiddleName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLastName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.LastName.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPostalAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PostalAddress));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sMobileNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MobileNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sEmailID", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.EmailID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@bIsLocalMember", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsLocalMember));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iLocalMemberId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.LocalMemberId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsFederationMember", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsFederationMember));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iFederationMemberId", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FederationMemberId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cGender", SqlDbType.Char, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Gender.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dBirthDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BirthDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.NationalityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPanNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PanNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdharCardNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBankNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.BankNumber.Trim()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode.Trim()));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@dJoiningDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.JoiningDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@dDateOfLeaving", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.DateOfLeaving));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iBioMatrixID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.BioMatrixID));

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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FishFishermenMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        /// Delete a specific record of FishFishermenMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FishFishermenMaster> DeleteFishFishermenMaster(FishFishermenMaster item)
        {
            IBaseEntityResponse<FishFishermenMaster> response = new BaseEntityResponse<FishFishermenMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FishFishermenMaster_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ID));
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
                    //item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;

                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;

                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DependantEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FishFishermenMaster_Delete' reported the ErrorCode: " + _errorCode);
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
        #endregion
    }
}

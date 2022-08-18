using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public class FeeRefundMasterDataProvider : DBInteractionBase, IFeeRefundMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public FeeRefundMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public FeeRefundMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from FeeRefundMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetFeeRefundMasterBySearch(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_SelectAll";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@siAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeRefundMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeRefundMaster item = new FeeRefundMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        item.PersonType = sqlDataReader["PersonType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PersonType"]);
                        item.PersonID = sqlDataReader["PersonID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.IsRefundByCashOrBank = sqlDataReader["IsRefundByCashOrBank"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRefundByCashOrBank"]);
                        item.Remark = sqlDataReader["Remark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Remark"]);
                        item.RefundAmount = sqlDataReader["RefundAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RefundAmount"]);
                        item.ChequeNumber = sqlDataReader["ChequeNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeNumber"]);
                        item.ChequeDate = sqlDataReader["ChequeDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeDate"]);
                        item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);                       
                        item.RefundDate = sqlDataReader["RefundDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RefundDate"]);
                        item.IsRefundGiven = sqlDataReader["IsRefundGiven"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRefundGiven"]);
                        item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        item.BranchShortCode = sqlDataReader["BranchShortCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchShortCode"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]); 
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
                        throw new Exception("Stored Procedure 'USP_FeeRefundMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        /// 
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<FeeRefundMaster> GetAccountListForFeeRefund(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeReceiptMaster_GetAccountList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@tiIsChashOrBankFlag", SqlDbType.TinyInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.IsChashOrBankFlag));
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
                    baseEntityCollection.CollectionResponse = new List<FeeRefundMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeRefundMaster item = new FeeRefundMaster();
                        item.AccountName = sqlDataReader["AccountName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountName"]);
                        item.AccountID = sqlDataReader["AccountID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_FeeRefundMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<FeeRefundMaster> GetFeeRefundMasterByID(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> response = new BaseEntityResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_SelectOne";
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
                        FeeRefundMaster _item = new FeeRefundMaster();
                        //_item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        //_item.FeeStructureMasterID = Convert.ToInt32(sqlDataReader["FeeStructureMasterID"]);

                        _item.CentreCode = sqlDataReader["CentreCode"].ToString();

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
        public IBaseEntityResponse<FeeRefundMaster> InsertFeeRefundMaster(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> response = new BaseEntityResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_InsertXML";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iStudentID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.StudentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smAccBalsheetID", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccBalsheetID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smAccSessionID", SqlDbType.SmallInt, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.AccSessionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xXmlstring", SqlDbType.Xml, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.XmlString));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsRefundByCashOrBank", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsRefundByCashOrBank));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsChequeNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ChequeNumber) ? string.Empty : item.ChequeNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsRemark", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.Remark) ? string.Empty : item.Remark));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRefundAmount", SqlDbType.Money, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.RefundAmount));
                    if (!string.IsNullOrEmpty(item.ChequeDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChequeDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ChequeDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daChequeDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

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
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode > 0)
                    {
                        item.ErrorCode = (Int32)_errorCode;
                    }
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_FeeRefundMaster_INSERT' reported the ErrorCode: " + _errorCode);
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
        /// Update a specific record of FeeRefundMaster
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<FeeRefundMaster> UpdateFeeRefundMaster(FeeRefundMaster item)
        {
            IBaseEntityResponse<FeeRefundMaster> response = new BaseEntityResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iFeeStructureMasterID", SqlDbType.Int, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.FeeStructureMasterID));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableFromDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("Not", SqlDbType.Date, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.ApplicableToDate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
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
                        throw new Exception("Stored Procedure 'dbo.USP_FeeRefundMaster_Delete' reported the ErrorCode: " +
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

        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentPaymentDetails(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_GetStudentRefundDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.ID));
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
                    baseEntityCollection.CollectionResponse = new List<FeeRefundMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeRefundMaster item = new FeeRefundMaster();
                        item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);
                        item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        item.EnrollmentNumber = sqlDataReader["EnrollmentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EnrollmentNumber"]);
                        item.StandardNumber = sqlDataReader["StandardNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StandardNumber"]);
                        item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmitAcademicYear"]);
                        item.EmailID = sqlDataReader["StudentEmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentEmailID"]);
                        if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        {
                            item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        }                       
                        item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileHeight"]);
                        item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFilename"]);
                        item.StudentPhotoType = sqlDataReader["StudentPhotoType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoType"]);
                        item.BranchDescription = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        item.BranchShortCode = sqlDataReader["BranchShortCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchShortCode"]);
                        item.AdmissionPattern = sqlDataReader["AdmissionPattern"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmissionPattern"]);
                        item.Course = sqlDataReader["CourseYearDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CourseYearDesc"]);
                        item.SectionDetailsDesc = sqlDataReader["SectionDetailsDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SectionDetailsDesc"]);
                        item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]);
                        item.ID = sqlDataReader["FeeRefundMasterID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeRefundMasterID"]);
                        item.AccSessionID = sqlDataReader["AccSessionID"] is DBNull ? new short() : Convert.ToInt16(sqlDataReader["AccSessionID"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        item.PersonType = sqlDataReader["PersonType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PersonType"]);
                        item.PersonID = sqlDataReader["PersonID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["PersonID"]);
                        item.IsRefundByCashOrBank = sqlDataReader["IsRefundByCashOrBank"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRefundByCashOrBank"]);
                        item.Remark = sqlDataReader["Remark"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Remark"]);
                        item.RefundAmount = sqlDataReader["RefundAmount"] is DBNull ? 0 : Convert.ToDecimal(sqlDataReader["RefundAmount"]);
                        item.RefundDate = sqlDataReader["RefundDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["RefundDate"]);
                        item.ChequeNumber = sqlDataReader["ChequeNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeNumber"]);
                        item.ChequeDate = sqlDataReader["ChequeDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ChequeDate"]);
                        item.IsRefundGiven = sqlDataReader["IsRefundGiven"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsRefundGiven"]);
                        item.AccountIDForStudentOutStanding = sqlDataReader["AccountID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AccountID"]);
                        item.AccountType = sqlDataReader["AccountType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountType"]);
                        item.AccountName = sqlDataReader["AccountName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AccountName"]); 
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_FeeStrucrureApplicable_GetRequestForApproval' reported the ErrorCode: " + _errorCode);
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

        public IBaseEntityCollectionResponse<FeeRefundMaster> GetStudentDetailsForFeeReceipt(FeeRefundMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeRefundMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<FeeRefundMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_FeeRefundMaster_StudentDetails";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchWord", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@iAccBalanceSheetID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.AccBalanceSheetID));

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
                    baseEntityCollection.CollectionResponse = new List<FeeRefundMaster>();
                    while (sqlDataReader.Read())
                    {
                        FeeRefundMaster item = new FeeRefundMaster();
                        //item.StudentID = sqlDataReader["StudentID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentID"]);
                        ////item.StudentAmissionDetailID = sqlDataReader["StudentAmissionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StudentAmissionDetailID"]);
                        //item.StudentName = sqlDataReader["StudentName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentName"]);
                        ////item.AcademicYearID = sqlDataReader["AcademicYearID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AcademicYearID"]);
                        ////item.BranchID = sqlDataReader["BranchID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["BranchID"]);
                        ////item.AdmissionPatternID = sqlDataReader["AdmissionPatternID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["AdmissionPatternID"]);
                        ////.CourseYearId = sqlDataReader["CourseYearId"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CourseYearId"]);
                        //item.Gender = sqlDataReader["Gender"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Gender"]);
                        //item.EnrollmentNumber = sqlDataReader["EnrollmentNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EnrollmentNumber"]);
                        //item.StandardNumber = sqlDataReader["StandardNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["StandardNumber"]);
                        ////item.SectionDetailID = sqlDataReader["SectionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SectionDetailID"]);
                        ////item.OldSectionDetailID = sqlDataReader["OldSectionDetailID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["OldSectionDetailID"]);
                        //item.AdmitAcademicYear = sqlDataReader["AdmitAcademicYear"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmitAcademicYear"]);
                        //item.StudentEmailID = sqlDataReader["StudentEmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentEmailID"]);
                        //if (DBNull.Value.Equals(sqlDataReader["StudentPhoto"]) == false)
                        //{
                        //    item.StudentPhoto = (byte[])(sqlDataReader["StudentPhoto"]);
                        //}
                        //item.StudentPhotoFileHeight = sqlDataReader["StudentPhotoFileHeight"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileHeight"]);
                        //item.StudentPhotoFilename = sqlDataReader["StudentPhotoFilename"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFilename"]);
                        //item.StudentPhotoFileWidth = sqlDataReader["StudentPhotoFileWidth"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoFileWidth"]);
                        //item.StudentPhotoType = sqlDataReader["StudentPhotoType"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StudentPhotoType"]);
                        //item.BranchDescription = sqlDataReader["BranchDescription"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchDescription"]);
                        //item.BranchShortCode = sqlDataReader["BranchShortCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["BranchShortCode"]);
                        //item.AdmissionPattern = sqlDataReader["AdmissionPattern"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["AdmissionPattern"]);
                        //item.CourseYearDesc = sqlDataReader["CourseYearDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CourseYearDesc"]);
                        //item.CourseYearCode = sqlDataReader["CourseYearCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CourseYearCode"]);
                        //item.SectionDetailsDesc = sqlDataReader["SectionDetailsDesc"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SectionDetailsDesc"]);
                        //item.SessionName = sqlDataReader["SessionName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SessionName"]);
                        //item.FeeStructureMasterID = sqlDataReader["FeeStructureID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["FeeStructureID"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_FeeStrucrureApplicable_GetRequestForApproval' reported the ErrorCode: " + _errorCode);
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

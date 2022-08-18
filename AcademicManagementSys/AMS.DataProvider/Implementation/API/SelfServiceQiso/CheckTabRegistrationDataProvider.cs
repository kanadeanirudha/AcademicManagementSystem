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
    public class CheckTabRegistrationDataProvider : DBInteractionBase, ICheckTabRegistrationDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public CheckTabRegistrationDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public CheckTabRegistrationDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        public IBaseEntityResponse<CheckTabRegistration> CheckTabRegistrationSelfService(CheckTabRegistration item)
        {
            IBaseEntityResponse<CheckTabRegistration> response = new BaseEntityResponse<CheckTabRegistration>();
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
                    cmdToExecute.CommandText = "dbo.USP_GeneralPosRegisrtation_CheckStatus";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceToken", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.DeviceToken));
                    cmdToExecute.Parameters.Add(new SqlParameter("@smUnitID", SqlDbType.SmallInt, 0, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, item.UnitsID)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 200, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, item.ErrorMessage));
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

                    CheckTabRegistration _item = new CheckTabRegistration();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    _item.ErrorCode = (Int32)_errorCode;
                    _item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    _item.UnitsID = (Int16)cmdToExecute.Parameters["@smUnitID"].Value;
                    response.Entity = _item;



                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200 && _errorCode != 300 && _errorCode != 100)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_InventorySalesMasterAndTransaction_PostOnline' reported the ErrorCode: " + _errorCode);
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

       
        

    }
}

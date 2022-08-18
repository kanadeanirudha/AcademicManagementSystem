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
    public class SelfServiceQisoDataProvider : DBInteractionBase, ISelfServiceQisoDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SelfServiceQisoDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SelfServiceQisoDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion

        public IBaseEntityResponse<SelfServiceQiso> PostTableOrder(SelfServiceQiso item)
        {
            IBaseEntityResponse<SelfServiceQiso> response = new BaseEntityResponse<SelfServiceQiso>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrder_PostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;


                    cmdToExecute.Parameters.Add(new SqlParameter("@iRestaurantTableOrderID", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.CentreCode));
                    
                    
                    
                     cmdToExecute.Parameters.Add(new SqlParameter("@nsPaidBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalBillAmount", SqlDbType.Money, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TotalBillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPaymentReferenceCode", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.PaymentReferenceCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sTableNumber", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, item.TableNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xOrderXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.OrderXML));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsTakeAway", SqlDbType.Bit, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.IsTakeAway));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.CreatedBy) ? 0 : Convert.ToInt32(item.CreatedBy)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ErrorMessage) ? string.Empty : item.ErrorMessage));
                    
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

                    SelfServiceQiso _item = new SelfServiceQiso();
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ID= (int)cmdToExecute.Parameters["@iRestaurantTableOrderID"].Value; 
                    item.ErrorCode = (Int32)_errorCode;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    response.Entity = item;
             
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
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

        public IBaseEntityResponse<SelfServiceQiso> RestaurantSettleBillPost(SelfServiceQiso item)
        {
            IBaseEntityResponse<SelfServiceQiso> response = new BaseEntityResponse<SelfServiceQiso>();
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
                    cmdToExecute.CommandText = "dbo.USP_RestaurantTableOrderSettleBill_SelfServicePostOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iRestaurantTableOrderID", SqlDbType.BigInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RestaurantTableOrderID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventorySaleMasterID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.InventorySaleMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.CentreCode) ? string.Empty : item.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.GeneralUnitsID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCounterID", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.CounterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalTaxAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalTaxAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalDiscountAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.TotalDiscountAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mTotalNetAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.NetAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mBillAmount ", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.BillAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mReturnChange", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ReturnChange));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mPaymentByCustomer", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentByCustomer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@mRoundUpAmount", SqlDbType.Money, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.RoundUpAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bPaymentMode", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.PaymentMode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsBillPaid", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.IsBillPaid)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerName", SqlDbType.NVarChar, 40, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.Customer)? string.Empty : item.Customer));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCustomerCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.CustomerCode)? string.Empty: item.CustomerCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.CreatedBy)? 0 : Convert.ToInt32(item.CreatedBy)));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsAvailableForPOS", SqlDbType.Bit, 0, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.IsAvailableForPOS)); 
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsErrorMessage", SqlDbType.NVarChar, 100, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.ErrorMessage) ? string.Empty : item.ErrorMessage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsBillNumber", SqlDbType.NVarChar, 30, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, string.IsNullOrEmpty(item.BillNumber) ? string.Empty : item.BillNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@xSaleTransactionXML", SqlDbType.Xml, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.SaleTransactionXML));
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

                    item.BillNumber = (string)cmdToExecute.Parameters["@nsBillNumber"].Value;
                    item.ErrorMessage = (string)cmdToExecute.Parameters["@nsErrorMessage"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != 200)
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

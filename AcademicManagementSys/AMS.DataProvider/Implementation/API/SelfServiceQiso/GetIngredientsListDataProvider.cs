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
    public class GetIngredientsListDataProvider : DBInteractionBase, IGetIngredientsListDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public GetIngredientsListDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public GetIngredientsListDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        public IBaseEntityCollectionResponse<GetIngredientsList> GetIngredientsListSelfService(GetIngredientsListSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GetIngredientsList> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<GetIngredientsList>();
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
                    cmdToExecute.CommandText = "dbo.USP_GetIngredientsList_GetOnline";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iInventoryVariationMasterID", SqlDbType.SmallInt, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.InventoryVariationMasterID));
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

                    baseEntityCollection.CollectionResponse = new List<GetIngredientsList>();
                    while (sqlDataReader.Read())
                    {
                        GetIngredientsList item = new GetIngredientsList();
                        item.ItemNumber = sqlDataReader["ItemNumber"] is DBNull ? new Int32() : Convert.ToInt32(sqlDataReader["ItemNumber"]);
                        item.Quantity = sqlDataReader["Quantity"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Quantity"]);
                        item.UOMCode = sqlDataReader["UOMCode"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["UOMCode"]);
                        item.Cost = sqlDataReader["Cost"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Cost"]);
                        item.ItemDescription = sqlDataReader["ItemDescription"] is DBNull ? String.Empty : Convert.ToString(sqlDataReader["ItemDescription"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                        // baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
                    }

                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_CRMSaleReport_SelectAll' reported the ErrorCode: " + _errorCode);
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




    }
}

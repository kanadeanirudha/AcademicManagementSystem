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
    public class SalePromotionOnFixAmountPlanDataProvider : DBInteractionBase, ISalePromotionOnFixAmountPlanDataProvider
    {
        #region Variable Declaration

        private readonly string _connectionString;
        private readonly ILogger _logException;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public SalePromotionOnFixAmountPlanDataProvider()
        {
        }

        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public SalePromotionOnFixAmountPlanDataProvider(ILogger logException)
        {
            _connectionString = "";//ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }

        #endregion


        public IBaseEntityCollectionResponse<SalePromotionOnFixAmountPlan> SalePromotionPriceDiscountOnFixAmountPlan(SalePromotionOnFixAmountPlanSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionOnFixAmountPlan> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<SalePromotionOnFixAmountPlan>();
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
                    cmdToExecute.CommandText = "dbo.USP_SalePromotionGetPriceDiscountOnFixAmountPlan";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;

                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralUnitsID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.GeneralUnitsID));
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

                    baseEntityCollection.CollectionResponse = new List<SalePromotionOnFixAmountPlan>();
                    while (sqlDataReader.Read())
                    {
                        SalePromotionOnFixAmountPlan item = new SalePromotionOnFixAmountPlan();
                        
                        item.SalePromotionActivityMasterID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.SalePromotionActivityDetailsID = sqlDataReader["SalePromotionActivityDetailsID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["SalePromotionActivityDetailsID"]);
                        item.Name = sqlDataReader["Name"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Name"]);
                        item.FromDate = sqlDataReader["FromDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FromDate"]);
                        item.UptoDate = sqlDataReader["UptoDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["UptoDate"]);
                        item.PlanTypeCode = sqlDataReader["PlanTypeCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeCode"]);
                        item.PlanTypeName = sqlDataReader["PlanTypeName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlanTypeName"]);
                        item.SubActivityName = sqlDataReader["SubActivityName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["SubActivityName"]);
                        item.BillAmountRangeFrom = sqlDataReader["BillAmountRangeFrom"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeFrom"]);
                        item.BillAmountRangeUpto = sqlDataReader["BillAmountRangeUpto"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillAmountRangeUpto"]);
                        item.BillDiscountAmount = sqlDataReader["BillDiscountAmount"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["BillDiscountAmount"]);
                        item.DiscountInPercent = sqlDataReader["DiscountInPercent"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["DiscountInPercent"]);
                        item.GiftItemQty = sqlDataReader["GiftItemQty"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["GiftItemQty"]);
                        item.HowManyQtyToBuy = sqlDataReader["HowManyQtyToBuy"] is DBNull ? new Int16() : Convert.ToInt16(sqlDataReader["HowManyQtyToBuy"]);

                        if (DBNull.Value.Equals(sqlDataReader["IsItemWiseDiscountExclude"]) == false)
                        {
                            item.IsItemWiseDiscountExclude = Convert.ToBoolean(sqlDataReader["IsItemWiseDiscountExclude"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsPercentage"]) == false)
                        {
                            item.IsPercentage = Convert.ToBoolean(sqlDataReader["IsPercentage"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsSampling"]) == false)
                        {
                            item.IsSampling = Convert.ToBoolean(sqlDataReader["IsSampling"]);
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

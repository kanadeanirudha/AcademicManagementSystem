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
    public class StudyCentreMasterDataProvider : DBInteractionBase, IStudyCentreMasterDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public StudyCentreMasterDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public StudyCentreMasterDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from StudyCentreMaster table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudyCentreMaster> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<StudyCentreMaster>();
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
                    cmdToExecute.CommandText = "dbo.USP_OrgStudyCenterMasterForPOS";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (!string.IsNullOrEmpty(searchRequest.LastSyncDate))
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.LastSyncDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daLastSyncDate", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDeviceCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DeviceCode));
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
                    baseEntityCollection.CollectionResponse = new List<StudyCentreMaster>();
                    while (sqlDataReader.Read())
                    {
                        StudyCentreMaster item = new StudyCentreMaster();
                        item.ID = sqlDataReader["ID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ID"]);
                        item.CentreCode = sqlDataReader["CentreCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreCode"]);
                        item.CentreName = sqlDataReader["CentreName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreName"]);
                        item.HoCoRoScFlag = sqlDataReader["HoCoRoScFlag"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["HoCoRoScFlag"]);
                        item.HoID = sqlDataReader["HoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["HoID"]);
                        item.CoID = sqlDataReader["CoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CoID"]);
                        item.RoID = sqlDataReader["RoID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["RoID"]);
                        item.CentreSpecialization = sqlDataReader["CentreSpecialization"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreSpecialization"]);
                        item.CentreAddress = sqlDataReader["CentreAddress"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreAddress"]);
                        item.PlotNo = sqlDataReader["PlotNo"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PlotNo"]);
                        item.StreetName = sqlDataReader["StreetName"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["StreetName"]);
                        item.CityID = sqlDataReader["CityID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CityID"]);
                        item.Pincode = sqlDataReader["Pincode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Pincode"]);
                        item.EmailID = sqlDataReader["EmailID"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["EmailID"]);
                        item.Url = sqlDataReader["Url"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["Url"]);
                        item.CellPhone = sqlDataReader["CellPhone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CellPhone"]);
                        item.FaxNumber = sqlDataReader["FaxNumber"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["FaxNumber"]);
                        item.PhoneNumberOffice = sqlDataReader["PhoneNumberOffice"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["PhoneNumberOffice"]);
                        item.CentreEstablishmentDatetime = sqlDataReader["CentreEstablishmentDatetime"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CentreEstablishmentDatetime"]);
                        item.OrganisationID = sqlDataReader["OrganisationID"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["OrganisationID"]);
                        item.CentreLoginNumber = sqlDataReader["CentreLoginNumber"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CentreLoginNumber"]);
                        item.InstituteCode = sqlDataReader["InstituteCode"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["InstituteCode"]);
                        item.TimeZone = sqlDataReader["TimeZone"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["TimeZone"]);
                        item.Latitude = sqlDataReader["Latitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Latitude"]);
                        item.Longitude = sqlDataReader["Longitude"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["Longitude"]);
                        item.CampusArea = sqlDataReader["CampusArea"] is DBNull ? new decimal() : Convert.ToDecimal(sqlDataReader["CampusArea"]);
                        item.CreatedBy = sqlDataReader["CreatedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["CreatedBy"]);
                        item.CreatedDate = sqlDataReader["CreatedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["CreatedDate"]);
                        item.ModifiedBy = sqlDataReader["ModifiedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["ModifiedBy"]);
                        item.ModifiedDate = sqlDataReader["ModifiedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["ModifiedDate"]);
                        item.DeletedBy = sqlDataReader["DeletedBy"] is DBNull ? 0 : Convert.ToInt32(sqlDataReader["DeletedBy"]);
                        item.DeletedDate = sqlDataReader["DeletedDate"] is DBNull ? string.Empty : Convert.ToString(sqlDataReader["DeletedDate"]);
                        item.IsDeleted = sqlDataReader["IsDeleted"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["IsDeleted"]);
                        item.Flag = sqlDataReader["Flag"] is DBNull ? false : Convert.ToBoolean(sqlDataReader["Flag"]);
                        baseEntityCollection.CollectionResponse.Add(item);
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_StudyCentreMaster_SelectAll' reported the ErrorCode: " + _errorCode);
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

        #endregion
    }
}

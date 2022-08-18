using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ICRMCallMasterAndDetailsDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsBySearch(CRMCallMasterAndDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsGetBySearchList(CRMCallMasterAndDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> GetCRMCallMasterAndDetailsByID(CRMCallMasterAndDetails item);

        /// <summary>
        /// data provider interface of insert new record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> InsertCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        /// <summary>
        /// data provider interface of update record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> UpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        /// <summary>
        /// data provider interface of dalete record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> DeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        IBaseEntityResponse<CRMCallMasterAndDetails> SelectByJobAllocationID(CRMCallMasterAndDetails item);

        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CallerConvertedReportForTable(CRMCallMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CRMMarketingEffectivenessReport(CRMCallMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityResponse<CRMCallMasterAndDetails> GetStudentStatusDetailsByCalleeMasterID(CRMCallMasterAndDetails item);
        
    }
}

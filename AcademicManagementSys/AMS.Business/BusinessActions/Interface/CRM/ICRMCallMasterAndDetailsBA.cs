using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMCallMasterAndDetailsBA
    {
        /// <summary>
        /// business action interface of insert new record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> InsertCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        /// <summary>
        /// business action interface of update record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> UpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        /// <summary>
        /// business action interface of dalete record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> DeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails item);

        /// <summary>
        /// business action interface of select all record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearch(CRMCallMasterAndDetailsSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearchList(CRMCallMasterAndDetailsSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallMasterAndDetails> SelectByID(CRMCallMasterAndDetails item);

        IBaseEntityResponse<CRMCallMasterAndDetails> SelectByJobAllocationID(CRMCallMasterAndDetails item);

        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CallerConvertedReportForTable(CRMCallMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CRMMarketingEffectivenessReport(CRMCallMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityResponse<CRMCallMasterAndDetails> GetStudentStatusDetailsByCalleeMasterID(CRMCallMasterAndDetails item);

        
        
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMCallMasterAndDetailsServiceAccess : ICRMCallMasterAndDetailsServiceAccess
    {
        ICRMCallMasterAndDetailsBA _CRMCallMasterAndDetailsBA = null;

        public CRMCallMasterAndDetailsServiceAccess()
        {
            _CRMCallMasterAndDetailsBA = new CRMCallMasterAndDetailsBA();
        }
        /// <summary>
        /// Service access of create new record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> InsertCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.InsertCRMCallMasterAndDetails(item);
        }

        /// <summary>
        /// Service access of update a specific record of CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> UpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.UpdateCRMCallMasterAndDetails(item);
        }

        /// <summary>
        /// Service access of delete a selected record from CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> DeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.DeleteCRMCallMasterAndDetails(item);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallMasterAndDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearch(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            return _CRMCallMasterAndDetailsBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallMasterAndDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> GetBySearchList(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            return _CRMCallMasterAndDetailsBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from CRMCallMasterAndDetails table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallMasterAndDetails> SelectByID(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.SelectByID(item);
        }

        public IBaseEntityResponse<CRMCallMasterAndDetails> SelectByJobAllocationID(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.SelectByJobAllocationID(item);
        }
        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CallerConvertedReportForTable(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            return _CRMCallMasterAndDetailsBA.CallerConvertedReportForTable(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMCallMasterAndDetails> CRMMarketingEffectivenessReport(CRMCallMasterAndDetailsSearchRequest searchRequest)
        {
            return _CRMCallMasterAndDetailsBA.CRMMarketingEffectivenessReport(searchRequest);
        }
        public IBaseEntityResponse<CRMCallMasterAndDetails> GetStudentStatusDetailsByCalleeMasterID(CRMCallMasterAndDetails item)
        {
            return _CRMCallMasterAndDetailsBA.GetStudentStatusDetailsByCalleeMasterID(item);
        }
    }
}


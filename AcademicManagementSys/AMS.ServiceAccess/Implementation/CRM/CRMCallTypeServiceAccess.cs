using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMCallTypeServiceAccess : ICRMCallTypeServiceAccess
    {
        ICRMCallTypeBA _CRMCallTypeBA = null;

        public CRMCallTypeServiceAccess()
        {
            _CRMCallTypeBA = new CRMCallTypeBA();
        }
        /// <summary>
        /// Service access of create new record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> InsertCRMCallType(CRMCallType item)
        {
            return _CRMCallTypeBA.InsertCRMCallType(item);
        }

        /// <summary>
        /// Service access of update a specific record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> UpdateCRMCallType(CRMCallType item)
        {
            return _CRMCallTypeBA.UpdateCRMCallType(item);
        }

        /// <summary>
        /// Service access of delete a selected record from CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> DeleteCRMCallType(CRMCallType item)
        {
            return _CRMCallTypeBA.DeleteCRMCallType(item);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallType table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallType> GetBySearch(CRMCallTypeSearchRequest searchRequest)
        {
            return _CRMCallTypeBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallType table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallType> GetCRMCallTypeList(CRMCallTypeSearchRequest searchRequest)
        {
            return _CRMCallTypeBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from CRMCallType table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallType> SelectByID(CRMCallType item)
        {
            return _CRMCallTypeBA.SelectByID(item);
        }
    }
}


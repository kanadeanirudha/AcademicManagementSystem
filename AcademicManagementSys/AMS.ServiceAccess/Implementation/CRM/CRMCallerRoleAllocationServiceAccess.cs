using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMCallerRoleAllocationServiceAccess : ICRMCallerRoleAllocationServiceAccess
    {
        ICRMCallerRoleAllocationBA _CRMCallerRoleAllocationBA = null;

        public CRMCallerRoleAllocationServiceAccess()
        {
            _CRMCallerRoleAllocationBA = new CRMCallerRoleAllocationBA();
        }
        /// <summary>
        /// Service access of create new record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> InsertCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            return _CRMCallerRoleAllocationBA.InsertCRMCallerRoleAllocation(item);
        }

        /// <summary>
        /// Service access of update a specific record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> UpdateCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            return _CRMCallerRoleAllocationBA.UpdateCRMCallerRoleAllocation(item);
        }

        /// <summary>
        /// Service access of delete a selected record from CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> DeleteCRMCallerRoleAllocation(CRMCallerRoleAllocation item)
        {
            return _CRMCallerRoleAllocationBA.DeleteCRMCallerRoleAllocation(item);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallerRoleAllocation table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearch(CRMCallerRoleAllocationSearchRequest searchRequest)
        {
            return _CRMCallerRoleAllocationBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from CRMCallerRoleAllocation table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetCRMCallerRoleAllocationList(CRMCallerRoleAllocationSearchRequest searchRequest)
        {
            return _CRMCallerRoleAllocationBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from CRMCallerRoleAllocation table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<CRMCallerRoleAllocation> SelectByID(CRMCallerRoleAllocation item)
        {
            return _CRMCallerRoleAllocationBA.SelectByID(item);
        }
    }
}


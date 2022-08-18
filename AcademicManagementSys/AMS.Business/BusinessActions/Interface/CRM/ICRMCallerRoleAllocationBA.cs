using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMCallerRoleAllocationBA
    {
        /// <summary>
        /// business action interface of insert new record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> InsertCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// business action interface of update record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> UpdateCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// business action interface of dalete record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> DeleteCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// business action interface of select all record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearch(CRMCallerRoleAllocationSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetBySearchList(CRMCallerRoleAllocationSearchRequest searchRequest);



        IBaseEntityResponse<CRMCallerRoleAllocation> SelectByID(CRMCallerRoleAllocation item);
    }
}

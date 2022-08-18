using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ICRMCallerRoleAllocationDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> InsertCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// data provider interface of update record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> UpdateCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// data provider interface of dalete record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> DeleteCRMCallerRoleAllocation(CRMCallerRoleAllocation item);

        /// <summary>
        /// data provider interface of select all record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetCRMCallerRoleAllocationBySearch(CRMCallerRoleAllocationSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallerRoleAllocation> GetCRMCallerRoleAllocationBySearchList(CRMCallerRoleAllocationSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of CRMCallerRoleAllocation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallerRoleAllocation> GetCRMCallerRoleAllocationByID(CRMCallerRoleAllocation item);
    }
}

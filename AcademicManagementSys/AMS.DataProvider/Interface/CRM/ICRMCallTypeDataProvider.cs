using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ICRMCallTypeDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> InsertCRMCallType(CRMCallType item);

        /// <summary>
        /// data provider interface of update record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> UpdateCRMCallType(CRMCallType item);

        /// <summary>
        /// data provider interface of dalete record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> DeleteCRMCallType(CRMCallType item);

        /// <summary>
        /// data provider interface of select all record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallType> GetCRMCallTypeBySearch(CRMCallTypeSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallType> GetCRMCallTypeBySearchList(CRMCallTypeSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> GetCRMCallTypeByID(CRMCallType item);
    }
}

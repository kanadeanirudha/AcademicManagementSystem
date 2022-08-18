using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMCallTypeBA
    {
        /// <summary>
        /// business action interface of insert new record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> InsertCRMCallType(CRMCallType item);

        /// <summary>
        /// business action interface of update record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> UpdateCRMCallType(CRMCallType item);

        /// <summary>
        /// business action interface of dalete record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<CRMCallType> DeleteCRMCallType(CRMCallType item);

        /// <summary>
        /// business action interface of select all record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallType> GetBySearch(CRMCallTypeSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of CRMCallType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<CRMCallType> GetBySearchList(CRMCallTypeSearchRequest searchRequest);



        IBaseEntityResponse<CRMCallType> SelectByID(CRMCallType item);
    }
}

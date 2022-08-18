using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralJobStatusServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> InsertGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// Service access interface of update record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> UpdateGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// Service access interface of dalete record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> DeleteGeneralJobStatus(GeneralJobStatus item);

        /// <summary>
        /// Service access interface of select all record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearch(GeneralJobStatusSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearchList(GeneralJobStatusSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobStatus> SelectByID(GeneralJobStatus item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralTitleMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> InsertGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> UpdateGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> DeleteGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearch(GeneralTitleMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearchList(GeneralTitleMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> SelectByID(GeneralTitleMaster item);
    }
}

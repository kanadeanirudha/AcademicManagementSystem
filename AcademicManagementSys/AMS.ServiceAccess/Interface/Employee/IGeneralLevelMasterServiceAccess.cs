using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralLevelMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> InsertGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> UpdateGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> DeleteGeneralLevelMaster(GeneralLevelMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearch(GeneralLevelMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLevelMaster> GetBySearchList(GeneralLevelMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralLevelMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLevelMaster> SelectByID(GeneralLevelMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralRegionMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> InsertGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> UpdateGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> DeleteGeneralRegionMaster(GeneralRegionMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetBySearch(GeneralRegionMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRegionMaster> GetByCountryID(GeneralRegionMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralRegionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRegionMaster> SelectByID(GeneralRegionMaster item);
    }
}

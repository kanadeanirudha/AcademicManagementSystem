using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralCityMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> InsertGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// Service access interface of update record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> UpdateGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// Service access interface of dalete record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> DeleteGeneralCityMaster(GeneralCityMaster item);

        /// <summary>
        /// Service access interface of select all record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearch(GeneralCityMasterSearchRequest searchRequest);

         /// <summary>
        /// Service access interface of select all record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCityMaster> GetByRegionID(GeneralCityMasterSearchRequest searchRequest);

       
        /// <summary>
        /// Service access interface of select one record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCityMaster> SelectByID(GeneralCityMaster item);
        /// <summary>
        /// Service access interface For General City Master search list.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        IBaseEntityCollectionResponse<GeneralCityMaster> GetBySearchList(GeneralCityMasterSearchRequest searchRequest);
    }
}

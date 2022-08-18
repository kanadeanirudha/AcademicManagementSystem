using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralLocationMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> InsertGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> UpdateGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> DeleteGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearch(GeneralLocationMasterSearchRequest searchRequest);
        

        /// <summary>
        /// Service access interface of select all record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchList(GeneralLocationMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralLocationMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> SelectByID(GeneralLocationMaster item);

          /// <summary>
        /// Service access interface of select one record of GeneralLocationMaster by CityID.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetByCityID(GeneralLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetByRegionIDAndCityID(GeneralLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchKeyWord(GeneralLocationMasterSearchRequest searchRequest);
        
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IGeneralLocationMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> InsertGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// business action interface of update record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> UpdateGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// business action interface of dalete record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> DeleteGeneralLocationMaster(GeneralLocationMaster item);

        /// <summary>
        /// business action interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearch(GeneralLocationMasterSearchRequest searchRequest);
        
        /// <summary>
        /// business action interface of select all record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchList(GeneralLocationMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of General Location Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralLocationMaster> SelectByID(GeneralLocationMaster item);

       
         /// <summary>
        /// business action interface of select all record of General Location Master by CityID.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralLocationMaster> GetByCityID(GeneralLocationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralLocationMaster> GetByRegionIDAndCityID(GeneralLocationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralLocationMaster> GetBySearchKeyWord(GeneralLocationMasterSearchRequest searchRequest);
        
    }
}

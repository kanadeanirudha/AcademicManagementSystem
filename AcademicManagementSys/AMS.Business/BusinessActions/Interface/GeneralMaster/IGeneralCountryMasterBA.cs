using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralCountryMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> InsertGeneralCountryMaster(GeneralCountryMaster item);

        /// <summary>
        /// business action interface of update record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> UpdateGeneralCountryMaster(GeneralCountryMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> DeleteGeneralCountryMaster(GeneralCountryMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearch(GeneralCountryMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearchList(GeneralCountryMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralCountryMaster> SelectByID(GeneralCountryMaster item);
    }
}

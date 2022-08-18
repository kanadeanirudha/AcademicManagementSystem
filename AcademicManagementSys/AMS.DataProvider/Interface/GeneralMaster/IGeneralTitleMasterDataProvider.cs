using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralTitleMasterDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> InsertGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// data provider interface of update record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> UpdateGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// data provider interface of dalete record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> DeleteGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// data provider interface of select all record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetGeneralTitleMasterBySearch(GeneralTitleMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralCountryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetGeneralTitleMasterBySearchList(GeneralTitleMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> GetGeneralTitleMasterByID(GeneralTitleMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralTitleMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> InsertGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// business action interface of update record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> UpdateGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTitleMaster> DeleteGeneralTitleMaster(GeneralTitleMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearch(GeneralTitleMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralTitleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTitleMaster> GetBySearchList(GeneralTitleMasterSearchRequest searchRequest);

       

        IBaseEntityResponse<GeneralTitleMaster> SelectByID(GeneralTitleMaster item);
    }
}

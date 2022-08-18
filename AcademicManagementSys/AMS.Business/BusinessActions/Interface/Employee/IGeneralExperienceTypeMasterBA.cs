using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IGeneralExperienceTypeMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> InsertGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// business action interface of update record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> UpdateGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// business action interface of dalete record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// business action interface of select all record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearch(GeneralExperienceTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralExperienceTypeMaster for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearchList(GeneralExperienceTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralExperienceTypeMaster> SelectByID(GeneralExperienceTypeMaster item);
    }
}

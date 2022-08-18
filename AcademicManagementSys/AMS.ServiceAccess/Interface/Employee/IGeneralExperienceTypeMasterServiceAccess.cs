using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralExperienceTypeMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> InsertGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> UpdateGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearch(GeneralExperienceTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> GetBySearchList(GeneralExperienceTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralExperienceTypeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralExperienceTypeMaster> SelectByID(GeneralExperienceTypeMaster item);
    }
}

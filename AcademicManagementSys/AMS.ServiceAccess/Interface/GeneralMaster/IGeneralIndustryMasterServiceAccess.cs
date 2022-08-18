using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralIndustryMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> InsertGeneralIndustryMaster(GeneralIndustryMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> UpdateGeneralIndustryMaster(GeneralIndustryMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> DeleteGeneralIndustryMaster(GeneralIndustryMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralIndustryMaster> GetBySearch(GeneralIndustryMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralIndustryMaster> GetBySearchList(GeneralIndustryMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralIndustryMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralIndustryMaster> SelectByID(GeneralIndustryMaster item);
    }
}

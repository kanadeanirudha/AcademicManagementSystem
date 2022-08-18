using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralJobProfileServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> InsertGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// Service access interface of update record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> UpdateGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// Service access interface of dalete record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> DeleteGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// Service access interface of select all record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearch(GeneralJobProfileSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearchList(GeneralJobProfileSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> SelectByID(GeneralJobProfile item);



    }
}

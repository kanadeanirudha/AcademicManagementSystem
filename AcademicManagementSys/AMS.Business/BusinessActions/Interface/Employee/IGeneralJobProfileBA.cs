using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralJobProfileBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> InsertGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// business action interface of update record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> UpdateGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// business action interface of dalete record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralJobProfile> DeleteGeneralJobProfile(GeneralJobProfile item);

        /// <summary>
        /// business action interface of select all record of GeneralJobProfile.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearch(GeneralJobProfileSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select record of GeneralJobProfile for dropdown.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
    
        IBaseEntityCollectionResponse<GeneralJobProfile> GetBySearchList(GeneralJobProfileSearchRequest searchRequest);

        IBaseEntityResponse<GeneralJobProfile> SelectByID(GeneralJobProfile item);
    }
}

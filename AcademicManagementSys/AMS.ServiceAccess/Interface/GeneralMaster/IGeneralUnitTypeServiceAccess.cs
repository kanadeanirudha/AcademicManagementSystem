using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralUnitTypeServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> InsertGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// Service access interface of update record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> UpdateGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// Service access interface of dalete record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> DeleteGeneralUnitType(GeneralUnitType item);

        /// <summary>
        /// Service access interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetBySearch(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralUnitType> GetBySearchList(GeneralUnitTypeSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralUnitType.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralUnitType> SelectByID(GeneralUnitType item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IGeneralTaxMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> InsertGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// Service access interface of update record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> UpdateGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// Service access interface of dalete record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> DeleteGeneralTaxMaster(GeneralTaxMaster item);

        /// <summary>
        /// Service access interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearch(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearchList(GeneralTaxMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralTaxMaster> SelectByID(GeneralTaxMaster item);
    }
}

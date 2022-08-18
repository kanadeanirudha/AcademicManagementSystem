using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralSupplierMasterServiceAccess
    {

        /// <summary>
        /// Service access interface of insert new record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// Service access interface of update record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// Service access interface of dalete record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item);

        /// <summary>
        /// Service access interface of select all record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearch(GeneralSupplierMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of general supplier master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSupplierMaster> SelectByID(GeneralSupplierMaster item);

        IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearchList(GeneralSupplierMasterSearchRequest searchRequest);
    }
}

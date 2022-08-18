using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralSessionMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> InsertGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// Service access interface of update record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> UpdateGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// Service access interface of dalete record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> DeleteGeneralSessionMaster(GeneralSessionMaster item);

        /// <summary>
        /// Service access interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearch(GeneralSessionMasterSearchRequest searchRequest);

        
        /// <summary>
        /// Service access interface of select all record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetBySearchList(GeneralSessionMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of General Session Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralSessionMaster> SelectByID(GeneralSessionMaster item);
        //Used in Online
        IBaseEntityCollectionResponse<GeneralSessionMaster> GetSession(GeneralSessionMasterSearchRequest searchRequest);
    }
}

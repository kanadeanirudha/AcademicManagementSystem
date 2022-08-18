using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ISyncServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> InventorySyncProcess(Sync item);

        /// <summary>
        /// Service access interface of update record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> UpdateSync(Sync item);

        /// <summary>
        /// Service access interface of dalete record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> DeleteSync(Sync item);

        /// <summary>
        /// Service access interface of select all record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<Sync> GetBySearch(SyncSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<Sync> GetBySearchList(SyncSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> GetLastSyncDate(Sync item);

        /// <summary>
        /// Service access interface of select one record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> CheckLoggedInUserCount(Sync item);        
    }
}

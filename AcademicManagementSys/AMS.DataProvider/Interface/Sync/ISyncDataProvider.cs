using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISyncDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<Sync> GetSyncBySearch(SyncSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<Sync> GetSyncGetBySearchList(SyncSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> GetLastSyncDate(Sync item);

        /// <summary>
        /// data provider interface of select one record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> CheckLoggedInUserCount(Sync item);        

        /// <summary>
        /// data provider interface of insert new record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> InventorySyncProcess(Sync item);

        /// <summary>
        /// data provider interface of update record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> UpdateSync(Sync item);

        /// <summary>
        /// data provider interface of dalete record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<Sync> DeleteSync(Sync item);
    }
}

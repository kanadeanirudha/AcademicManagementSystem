using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class SyncServiceAccess : ISyncServiceAccess
    {
        ISyncBA _SyncBA = null;

        public SyncServiceAccess()
        {
            _SyncBA = new SyncBA();
        }
        /// <summary>
        /// Service access of create new record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> InventorySyncProcess(Sync item)
        {
            return _SyncBA.InventorySyncProcess(item);
        }

        /// <summary>
        /// Service access of update a specific record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> UpdateSync(Sync item)
        {
            return _SyncBA.UpdateSync(item);
        }

        /// <summary>
        /// Service access of delete a selected record from Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> DeleteSync(Sync item)
        {
            return _SyncBA.DeleteSync(item);
        }

        /// <summary>
        /// /// Service access of select all record from Sync table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<Sync> GetBySearch(SyncSearchRequest searchRequest)
        {
            return _SyncBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all record from Sync table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<Sync> GetBySearchList(SyncSearchRequest searchRequest)
        {
            return _SyncBA.GetBySearchList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from Sync table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> GetLastSyncDate(Sync item)
        {
            return _SyncBA.GetLastSyncDate(item);
        }

        /// <summary>
        /// Service access of select a record from Sync table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> CheckLoggedInUserCount(Sync item)
        {
            return _SyncBA.CheckLoggedInUserCount(item);
        }        
    }
}


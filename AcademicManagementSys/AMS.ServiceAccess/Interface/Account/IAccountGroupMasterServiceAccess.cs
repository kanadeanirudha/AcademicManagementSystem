using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountGroupMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> InsertAccountGroupMaster(AccountGroupMaster item);

        /// <summary>
        /// Service access interface of update record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> UpdateAccountGroupMaster(AccountGroupMaster item);

        /// <summary>
        /// Service access interface of dalete record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> DeleteAccountGroupMaster(AccountGroupMaster item);

        /// <summary>
        /// Service access interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMaster> GetBySearch(AccountGroupMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> SelectByID(AccountGroupMaster item);
    }
}

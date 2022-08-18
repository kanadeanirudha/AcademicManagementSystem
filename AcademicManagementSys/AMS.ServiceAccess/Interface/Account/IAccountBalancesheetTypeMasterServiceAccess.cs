using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountBalancesheetTypeMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> InsertAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// Service access interface of update record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> UpdateAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// Service access interface of dalete record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> DeleteAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// Service access interface of select all record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> GetBySearch(AccountBalancesheetTypeMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account balace sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountBalancesheetTypeMaster> SelectByID(AccountBalancesheetTypeMaster item);
    }
}

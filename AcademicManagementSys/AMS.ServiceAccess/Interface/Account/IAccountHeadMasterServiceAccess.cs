using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountHeadMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMaster> InsertAccountHeadMaster(AccountHeadMaster item);

        /// <summary>
        /// Service access interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMaster> UpdateAccountHeadMaster(AccountHeadMaster item);

        /// <summary>
        /// Service access interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMaster> DeleteAccountHeadMaster(AccountHeadMaster item);

        /// <summary>
        /// Service access interface of select all record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMaster> GetBySearch(AccountHeadMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all head name list from account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountHeadMaster> GetHeadNameList(AccountHeadMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select one record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountHeadMaster> SelectByID(AccountHeadMaster item);
    }
}

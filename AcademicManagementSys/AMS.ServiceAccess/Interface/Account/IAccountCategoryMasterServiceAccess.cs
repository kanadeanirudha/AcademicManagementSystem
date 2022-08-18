using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IAccountCategoryMasterServiceAccess
    {
        /// <summary>
        /// Service access interface of insert new record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> InsertAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// Service access interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> UpdateAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// Service access interface of dalete record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> DeleteAccountCategoryMaster(AccountCategoryMaster item);

        /// <summary>
        /// Service access interface of select all record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetBySearch(AccountCategoryMasterSearchRequest searchRequest);

        /// <summary>
        /// Service access interface of select all category name list of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountCategoryMaster> GetCategoryList(AccountCategoryMasterSearchRequest searchRequest);


        /// <summary>
        /// Service access interface of select one record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountCategoryMaster> SelectByID(AccountCategoryMaster item);
    }
}

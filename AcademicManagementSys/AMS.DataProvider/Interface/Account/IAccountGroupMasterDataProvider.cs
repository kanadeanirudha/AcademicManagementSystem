using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAccountGroupMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountGroupMaster> GetAccountGroupMasterBySearch(AccountGroupMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> GetAccountGroupMasterByID(AccountGroupMaster item);

        /// <summary>
        /// data provider interface of insert new record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> InsertAccountGroupMaster(AccountGroupMaster item);

        /// <summary>
        /// data provider interface of update record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> UpdateAccountGroupMaster(AccountGroupMaster item);

        /// <summary>
        /// data provider interface of dalete record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountGroupMaster> DeleteAccountGroupMaster(AccountGroupMaster item);
    }
}

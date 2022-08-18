using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountGroupMasterServiceAccess : IAccountGroupMasterServiceAccess
    {
        IAccountGroupMasterBA _accountGroupMasterBA = null;
        public AccountGroupMasterServiceAccess()
        {
            _accountGroupMasterBA = new AccountGroupMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account Group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> InsertAccountGroupMaster(AccountGroupMaster item)
        {
            return _accountGroupMasterBA.InsertAccountGroupMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account Group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> UpdateAccountGroupMaster(AccountGroupMaster item)
        {
            return _accountGroupMasterBA.UpdateAccountGroupMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account Group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> DeleteAccountGroupMaster(AccountGroupMaster item)
        {
            return _accountGroupMasterBA.DeleteAccountGroupMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account Group master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGroupMaster> GetBySearch(AccountGroupMasterSearchRequest searchRequest)
        {
            return _accountGroupMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account Group master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGroupMaster> SelectByID(AccountGroupMaster item)
        {
            return _accountGroupMasterBA.SelectByID(item);
        }

    }
}

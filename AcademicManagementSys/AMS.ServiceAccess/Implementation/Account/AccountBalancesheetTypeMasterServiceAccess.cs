using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountBalancesheetTypeMasterServiceAccess: IAccountBalancesheetTypeMasterServiceAccess
    {
        IAccountBalancesheetTypeMasterBA _accountBalancesheetTypeMasterBA = null;
        public AccountBalancesheetTypeMasterServiceAccess()
        {
            _accountBalancesheetTypeMasterBA = new AccountBalancesheetTypeMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> InsertAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            return _accountBalancesheetTypeMasterBA.InsertAccountBalancesheetTypeMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> UpdateAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            return _accountBalancesheetTypeMasterBA.UpdateAccountBalancesheetTypeMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> DeleteAccountBalancesheetTypeMaster(AccountBalancesheetTypeMaster item)
        {
            return _accountBalancesheetTypeMasterBA.DeleteAccountBalancesheetTypeMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account balance sheet master type table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetTypeMaster> GetBySearch(AccountBalancesheetTypeMasterSearchRequest searchRequest)
        {
            return _accountBalancesheetTypeMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account balance sheet type master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountBalancesheetTypeMaster> SelectByID(AccountBalancesheetTypeMaster item)
        {
            return _accountBalancesheetTypeMasterBA.SelectByID(item);
        }

    }
}

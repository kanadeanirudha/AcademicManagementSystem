using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountCategoryMasterServiceAccess: IAccountCategoryMasterServiceAccess
    {
        IAccountCategoryMasterBA _accountCategoryMasterBA = null;
        public AccountCategoryMasterServiceAccess()
        {
            _accountCategoryMasterBA = new AccountCategoryMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> InsertAccountCategoryMaster(AccountCategoryMaster item)
        {
            return _accountCategoryMasterBA.InsertAccountCategoryMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> UpdateAccountCategoryMaster(AccountCategoryMaster item)
        {
            return _accountCategoryMasterBA.UpdateAccountCategoryMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> DeleteAccountCategoryMaster(AccountCategoryMaster item)
        {
            return _accountCategoryMasterBA.DeleteAccountCategoryMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account category master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMaster> GetBySearch(AccountCategoryMasterSearchRequest searchRequest)
        {
            return _accountCategoryMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all category name list from account category master table.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMaster> GetCategoryList(AccountCategoryMasterSearchRequest searchRequest)
        {
            return _accountCategoryMasterBA.GetCategoryList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account category master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMaster> SelectByID(AccountCategoryMaster item)
        {
            return _accountCategoryMasterBA.SelectByID(item);
        }
    }
}

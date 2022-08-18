using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
    public class AccountHeadMasterServiceAccess: IAccountHeadMasterServiceAccess
    {
        IAccountHeadMasterBA _accountHeadMasterBA = null;
        public AccountHeadMasterServiceAccess()
        {
            _accountHeadMasterBA = new AccountHeadMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> InsertAccountHeadMaster(AccountHeadMaster item)
        {
            return _accountHeadMasterBA.InsertAccountHeadMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> UpdateAccountHeadMaster(AccountHeadMaster item)
        {
            return _accountHeadMasterBA.UpdateAccountHeadMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> DeleteAccountHeadMaster(AccountHeadMaster item)
        {
            return _accountHeadMasterBA.DeleteAccountHeadMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account head master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMaster> GetBySearch(AccountHeadMasterSearchRequest searchRequest)
        {
            return _accountHeadMasterBA.GetAccountHeadMasterBySearch(searchRequest);
        }

        /// <summary>
        /// /// Service access of select all head name list form account head master table.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMaster> GetHeadNameList(AccountHeadMasterSearchRequest searchRequest)
        {
            return _accountHeadMasterBA.GetAccountHeadNameList(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account head master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMaster> SelectByID(AccountHeadMaster item)
        {
            return _accountHeadMasterBA.GetAccountHeadMasterByID(item);
        }
    }
}

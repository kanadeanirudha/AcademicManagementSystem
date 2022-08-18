using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AccountChequeBookMasterServiceAccess : IAccountChequeBookMasterServiceAccess
    {
        IAccountChequeBookMasterBA _accountChequeBookMasterBA = null;

        public AccountChequeBookMasterServiceAccess() 
        {
            _accountChequeBookMasterBA = new AccountChequeBookMasterBA();
        }

        /// <summary>
        /// Service access of create new record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> InsertAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            return _accountChequeBookMasterBA.InsertAccountChequeBookMaster(item);
        }

        /// <summary>
        /// Service access of update a specific record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> UpdateAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            return _accountChequeBookMasterBA.UpdateAccountChequeBookMaster(item);
        }

        /// <summary>
        /// Service access of delete a selected record from account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> DeleteAccountChequeBookMaster(AccountChequeBookMaster item)
        {
            return _accountChequeBookMasterBA.DeleteAccountChequeBookMaster(item);
        }

        /// <summary>
        /// /// Service access of select all record from account cheque book master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountChequeBookMaster> GetBySearch(AccountChequeBookMasterSearchRequest searchRequest)
        {
            return _accountChequeBookMasterBA.GetBySearch(searchRequest);
        }

        /// <summary>
        /// Service access of select a record from account cheque book master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> SelectByID(AccountChequeBookMaster item)
        {
            return _accountChequeBookMasterBA.SelectByID(item);
        }

                /// <summary>
        /// Service access of select a record from account cheque book master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountChequeBookMaster> SelectByAccountID(AccountChequeBookMaster item)
        {
            return _accountChequeBookMasterBA.SelectByAccountID(item);
        }
        
    }
}


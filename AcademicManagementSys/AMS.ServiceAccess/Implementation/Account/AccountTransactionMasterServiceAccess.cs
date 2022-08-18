using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountTransactionMasterServiceAccess : IAccountTransactionMasterServiceAccess
    {
        IAccountTransactionMasterBA _accTransactionMasterBA = null;
        public AccountTransactionMasterServiceAccess()
        {
            _accTransactionMasterBA = new AccountTransactionMasterBA();
        }
        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item)
        {
            return _accTransactionMasterBA.InsertAccountTransactionMaster(item);
        }
        public IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item)
        {
            return _accTransactionMasterBA.UpdateAccountTransactionMaster(item);
        }
        public IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item)
        {
            return _accTransactionMasterBA.DeleteAccountTransactionMaster(item);
        }
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearch(AccountTransactionMasterSearchRequest searchRequest)
        {
            return _accTransactionMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest)
        {
            return _accTransactionMasterBA.GetBySearchForEditView(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest)
        {
            return _accTransactionMasterBA.GetAccountList(searchRequest);
        }
        public IBaseEntityResponse<AccountTransactionMaster> SelectByID(AccountTransactionMaster item)
        {
            return _accTransactionMasterBA.SelectByID(item);
        }

        public IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item)
        {
            return _accTransactionMasterBA.InsertAccountVoucherRequest(item);
        }
        public IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest)
        {
            return _accTransactionMasterBA.GetVoucherDetailsForApproval(searchRequest);
        }
    }
}

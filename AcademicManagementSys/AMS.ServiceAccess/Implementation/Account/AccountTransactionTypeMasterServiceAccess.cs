using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountTransactionTypeMasterServiceAccess : IAccountTransactionTypeMasterServiceAccess
    {
        IAccountTransactionTypeMasterBA _accTransactionTypeMasterBA = null;
        public AccountTransactionTypeMasterServiceAccess()
        {
            _accTransactionTypeMasterBA = new AccountTransactionTypeMasterBA();
        }
        public IBaseEntityResponse<AccountTransactionTypeMaster> InsertAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            return _accTransactionTypeMasterBA.InsertAccountTransactionTypeMaster(item);
        }
        public IBaseEntityResponse<AccountTransactionTypeMaster> UpdateAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            return _accTransactionTypeMasterBA.UpdateAccountTransactionTypeMaster(item);
        }
        public IBaseEntityResponse<AccountTransactionTypeMaster> DeleteAccountTransactionTypeMaster(AccountTransactionTypeMaster item)
        {
            return _accTransactionTypeMasterBA.DeleteAccountTransactionTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetBySearch(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            return _accTransactionTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeList(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            return _accTransactionTypeMasterBA.GetTransactionTypeList(searchRequest);
        }
        public IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeSearchList(AccountTransactionTypeMasterSearchRequest searchRequest)
        {
            return _accTransactionTypeMasterBA.GetTransactionTypeSearchList(searchRequest);
        }
        public IBaseEntityResponse<AccountTransactionTypeMaster> SelectByID(AccountTransactionTypeMaster item)
        {
            return _accTransactionTypeMasterBA.SelectByID(item);
        }
    }
}

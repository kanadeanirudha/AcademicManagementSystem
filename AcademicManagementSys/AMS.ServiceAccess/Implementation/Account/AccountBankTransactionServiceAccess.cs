using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountBankTransactionServiceAccess : IAccountBankTransactionServiceAccess
    {
        IAccountBankTransactionBA _accBankTransactionBA = null;
        public AccountBankTransactionServiceAccess()
        {
            _accBankTransactionBA = new AccountBankTransactionBA();
        }
        public IBaseEntityResponse<AccountBankTransaction> InsertAccountBankTransaction(AccountBankTransaction item)
        {
            return _accBankTransactionBA.InsertAccountBankTransaction(item);
        }
        public IBaseEntityResponse<AccountBankTransaction> UpdateAccountBankTransaction(AccountBankTransaction item)
        {
            return _accBankTransactionBA.UpdateAccountBankTransaction(item);
        }
        public IBaseEntityResponse<AccountBankTransaction> DeleteAccountBankTransaction(AccountBankTransaction item)
        {
            return _accBankTransactionBA.DeleteAccountBankTransaction(item);
        }
        public IBaseEntityCollectionResponse<AccountBankTransaction> GetBySearch(AccountBankTransactionSearchRequest searchRequest)
        {
            return _accBankTransactionBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<AccountBankTransaction> SelectByID(AccountBankTransaction item)
        {
            return _accBankTransactionBA.SelectByID(item);
        }
    }
}

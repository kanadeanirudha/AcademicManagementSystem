using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class AccountCentreOpeningBalanceServiceAccess : IAccountCentreOpeningBalanceServiceAccess
    {
        IAccountCentreOpeningBalanceBA _accCentreOpeningBalanceBA = null;
        public AccountCentreOpeningBalanceServiceAccess()
        {
            _accCentreOpeningBalanceBA = new AccountCentreOpeningBalanceBA();
        }
        public IBaseEntityResponse<AccountCentreOpeningBalance> InsertAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            return _accCentreOpeningBalanceBA.InsertAccountCentreOpeningBalance(item);
        }
        public IBaseEntityResponse<AccountCentreOpeningBalance> UpdateAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            return _accCentreOpeningBalanceBA.UpdateAccountCentreOpeningBalance(item);
        }
        public IBaseEntityResponse<AccountCentreOpeningBalance> DeleteAccountCentreOpeningBalance(AccountCentreOpeningBalance item)
        {
            return _accCentreOpeningBalanceBA.DeleteAccountCentreOpeningBalance(item);
        }
        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearch(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            return _accCentreOpeningBalanceBA.GetBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearchIndividualAccount(AccountCentreOpeningBalanceSearchRequest searchRequest)
        {
            return _accCentreOpeningBalanceBA.GetBySearchIndividualAccount(searchRequest);
        }
        public IBaseEntityResponse<AccountCentreOpeningBalance> SelectByID(AccountCentreOpeningBalance item)
        {
            return _accCentreOpeningBalanceBA.SelectByID(item);
        }
    }
}

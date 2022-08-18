using AMS.Base.DTO;
using AMS.Business;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class AccountChequeBookDetailsServiceAccess : IAccountChequeBookDetailsServiceAccess
	{
		IAccountChequeBookDetailsBA _AccountChequeBookDetailsBA = null;
		public AccountChequeBookDetailsServiceAccess()
		{
			_AccountChequeBookDetailsBA = new AccountChequeBookDetailsBA();
		}
		public IBaseEntityResponse<AccountChequeBookDetails> InsertAccountChequeBookDetails(AccountChequeBookDetails item)
		{
			return _AccountChequeBookDetailsBA.InsertAccountChequeBookDetails(item);
		}
		public IBaseEntityResponse<AccountChequeBookDetails> UpdateAccountChequeBookDetails(AccountChequeBookDetails item)
		{
			return _AccountChequeBookDetailsBA.UpdateAccountChequeBookDetails(item);
		}
		public IBaseEntityResponse<AccountChequeBookDetails> DeleteAccountChequeBookDetails(AccountChequeBookDetails item)
		{
			return _AccountChequeBookDetailsBA.DeleteAccountChequeBookDetails(item);
		}
		public IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearch(AccountChequeBookDetailsSearchRequest searchRequest)
		{
			return _AccountChequeBookDetailsBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearchForEditView(AccountChequeBookDetailsSearchRequest searchRequest)
		{
            return _AccountChequeBookDetailsBA.GetBySearchForEditView(searchRequest);
		}
		public IBaseEntityResponse<AccountChequeBookDetails> SelectByID(AccountChequeBookDetails item)
		{
			return _AccountChequeBookDetailsBA.SelectByID(item);
		}
	}
}

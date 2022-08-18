using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
	public interface IAccountChequeBookDetailsServiceAccess
	{
		IBaseEntityResponse<AccountChequeBookDetails> InsertAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityResponse<AccountChequeBookDetails> UpdateAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityResponse<AccountChequeBookDetails> DeleteAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearch(AccountChequeBookDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearchForEditView(AccountChequeBookDetailsSearchRequest searchRequest);
		IBaseEntityResponse<AccountChequeBookDetails> SelectByID(AccountChequeBookDetails item);
	}
}

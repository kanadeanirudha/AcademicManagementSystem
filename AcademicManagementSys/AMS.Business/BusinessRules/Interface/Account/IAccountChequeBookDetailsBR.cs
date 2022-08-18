using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IAccountChequeBookDetailsBR
	{
		IValidateBusinessRuleResponse InsertAccountChequeBookDetailsValidate(AccountChequeBookDetails item);
		IValidateBusinessRuleResponse UpdateAccountChequeBookDetailsValidate(AccountChequeBookDetails item);
		IValidateBusinessRuleResponse DeleteAccountChequeBookDetailsValidate(AccountChequeBookDetails item);
	}
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IAccountTransactionMasterBR
    {
        IValidateBusinessRuleResponse InsertAccountTransactionMasterValidate(AccountTransactionMaster item);
        IValidateBusinessRuleResponse UpdateAccountTransactionMasterValidate(AccountTransactionMaster item);
        IValidateBusinessRuleResponse DeleteAccountTransactionMasterValidate(AccountTransactionMaster item);
    }
}

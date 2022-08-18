using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IAccountSessionMasterBR
	{
		IValidateBusinessRuleResponse InsertAccountSessionMasterValidate(AccountSessionMaster item);
		IValidateBusinessRuleResponse UpdateAccountSessionMasterValidate(AccountSessionMaster item);
		IValidateBusinessRuleResponse DeleteAccountSessionMasterValidate(AccountSessionMaster item);
        IValidateBusinessRuleResponse InsertAccountYearEndJobValidate(AccountSessionMaster item);
    }
}

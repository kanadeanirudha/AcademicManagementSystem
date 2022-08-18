using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IGeneralTypeOfAccountBR
	{
		IValidateBusinessRuleResponse InsertGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
		IValidateBusinessRuleResponse UpdateGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
		IValidateBusinessRuleResponse DeleteGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
	}
}

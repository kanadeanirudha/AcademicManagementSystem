using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IFeeCriteriaParametersAndValuesBR
	{
		IValidateBusinessRuleResponse InsertFeeCriteriaParametersAndValuesValidate(FeeCriteriaParametersAndValues item);
		IValidateBusinessRuleResponse UpdateFeeCriteriaParametersAndValuesValidate(FeeCriteriaParametersAndValues item);
		IValidateBusinessRuleResponse DeleteFeeCriteriaParametersAndValuesValidate(FeeCriteriaParametersAndValues item);
	}
}

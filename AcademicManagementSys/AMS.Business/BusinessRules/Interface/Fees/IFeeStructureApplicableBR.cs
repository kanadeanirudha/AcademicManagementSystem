using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IFeeStructureApplicableBR
	{
		IValidateBusinessRuleResponse InsertFeeStructureApplicableValidate(FeeStructureApplicable item);
		IValidateBusinessRuleResponse UpdateFeeStructureApplicableValidate(FeeStructureApplicable item);
		IValidateBusinessRuleResponse DeleteFeeStructureApplicableValidate(FeeStructureApplicable item);
        IValidateBusinessRuleResponse CreateFeeStructureRequestApproval(FeeStructureApplicable item);
	}
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IPurchaseRequirementMasterBR
	{
		IValidateBusinessRuleResponse InsertPurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
		IValidateBusinessRuleResponse UpdatePurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
		IValidateBusinessRuleResponse DeletePurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
	}
}

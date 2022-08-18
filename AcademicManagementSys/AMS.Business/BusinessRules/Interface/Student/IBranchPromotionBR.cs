using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IBranchPromotionBR
	{
		IValidateBusinessRuleResponse InsertBranchPromotionValidate(BranchPromotion item);
		IValidateBusinessRuleResponse UpdateBranchPromotionValidate(BranchPromotion item);
		IValidateBusinessRuleResponse DeleteBranchPromotionValidate(BranchPromotion item);
	}
}

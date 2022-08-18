using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface ISalaryGradePayMasterBR
	{
		IValidateBusinessRuleResponse InsertSalaryGradePayMasterValidate(SalaryGradePayMaster item);
		IValidateBusinessRuleResponse UpdateSalaryGradePayMasterValidate(SalaryGradePayMaster item);
		IValidateBusinessRuleResponse DeleteSalaryGradePayMasterValidate(SalaryGradePayMaster item);
	}
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryDeductionMasterBR
    {
        IValidateBusinessRuleResponse InsertSalaryDeductionMasterValidate(SalaryDeductionMaster item);
        IValidateBusinessRuleResponse UpdateSalaryDeductionMasterValidate(SalaryDeductionMaster item);
        IValidateBusinessRuleResponse DeleteSalaryDeductionMasterValidate(SalaryDeductionMaster item);
    }
}

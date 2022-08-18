using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryPayRulesBR
    {
        IValidateBusinessRuleResponse InsertSalaryPayRulesValidate(SalaryPayRules item);
        IValidateBusinessRuleResponse UpdateSalaryPayRulesValidate(SalaryPayRules item);
        IValidateBusinessRuleResponse DeleteSalaryPayRulesValidate(SalaryPayRules item);
    }
}

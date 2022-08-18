using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryDeductionCurrentSettingBR
    {
        IValidateBusinessRuleResponse InsertSalaryDeductionCurrentSettingValidate(SalaryDeductionCurrentSetting item);
        IValidateBusinessRuleResponse UpdateSalaryDeductionCurrentSettingValidate(SalaryDeductionCurrentSetting item);
        IValidateBusinessRuleResponse DeleteSalaryDeductionCurrentSettingValidate(SalaryDeductionCurrentSetting item);
    }
}

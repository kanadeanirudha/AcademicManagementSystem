using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryAllowanceCurrentSettingBR
    {
        IValidateBusinessRuleResponse InsertSalaryAllowanceCurrentSettingValidate(SalaryAllowanceCurrentSetting item);
        IValidateBusinessRuleResponse UpdateSalaryAllowanceCurrentSettingValidate(SalaryAllowanceCurrentSetting item);
        IValidateBusinessRuleResponse DeleteSalaryAllowanceCurrentSettingValidate(SalaryAllowanceCurrentSetting item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryAllowanceMasterBR
    {
        IValidateBusinessRuleResponse InsertSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);
        IValidateBusinessRuleResponse UpdateSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);
        IValidateBusinessRuleResponse DeleteSalaryAllowanceMasterValidate(SalaryAllowanceMaster item);
    }
}

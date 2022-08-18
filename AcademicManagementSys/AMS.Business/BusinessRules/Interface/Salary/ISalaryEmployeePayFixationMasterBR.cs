using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryEmployeePayFixationMasterBR
    {
        IValidateBusinessRuleResponse InsertSalaryEmployeePayFixationMasterValidate(SalaryEmployeePayFixationMaster item);
        IValidateBusinessRuleResponse UpdateSalaryEmployeePayFixationMasterValidate(SalaryEmployeePayFixationMaster item);
        IValidateBusinessRuleResponse DeleteSalaryEmployeePayFixationMasterValidate(SalaryEmployeePayFixationMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeShiftApplicableMasterBR
    {
        IValidateBusinessRuleResponse InsertEmployeeShiftApplicableMasterValidate(EmployeeShiftApplicableMaster item);
        IValidateBusinessRuleResponse UpdateEmployeeShiftApplicableMasterValidate(EmployeeShiftApplicableMaster item);
        IValidateBusinessRuleResponse DeleteEmployeeShiftApplicableMasterValidate(EmployeeShiftApplicableMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeContactDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeContactDetailsValidate(EmployeeContactDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeContactDetailsValidate(EmployeeContactDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeContactDetailsValidate(EmployeeContactDetails item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeeServiceDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
        IValidateBusinessRuleResponse UpdateEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
        IValidateBusinessRuleResponse DeleteEmployeeServiceDetailsValidate(EmployeeServiceDetails item);
    }
}

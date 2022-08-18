using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmployeePictureDetailsBR
    {
        IValidateBusinessRuleResponse InsertEmployeePictureDetailsValidate(EmployeePictureDetails item);
        IValidateBusinessRuleResponse UpdateEmployeePictureDetailsValidate(EmployeePictureDetails item);
        IValidateBusinessRuleResponse DeleteEmployeePictureDetailsValidate(EmployeePictureDetails item);
    }
}

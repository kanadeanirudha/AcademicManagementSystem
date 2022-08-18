using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IStudentRegistrationFormBR
    {
        IValidateBusinessRuleResponse InsertStudentRegistrationFormValidate(StudentRegistrationForm item);
        IValidateBusinessRuleResponse UpdateStudentRegistrationFormValidate(StudentRegistrationForm item);
        IValidateBusinessRuleResponse DeleteStudentRegistrationFormValidate(StudentRegistrationForm item);
    }
}

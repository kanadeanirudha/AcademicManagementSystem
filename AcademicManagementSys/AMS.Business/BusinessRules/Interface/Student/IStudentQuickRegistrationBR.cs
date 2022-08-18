using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IStudentQuickRegistrationBR
    {
        IValidateBusinessRuleResponse InsertStudentQuickRegistrationValidate(StudentQuickRegistration item);
        IValidateBusinessRuleResponse UpdateStudentQuickRegistrationValidate(StudentQuickRegistration item);
        IValidateBusinessRuleResponse DeleteStudentQuickRegistrationValidate(StudentQuickRegistration item);
    }
}

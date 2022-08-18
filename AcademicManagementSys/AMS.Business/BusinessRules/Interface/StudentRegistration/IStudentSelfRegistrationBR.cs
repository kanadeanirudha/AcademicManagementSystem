using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IStudentSelfRegistrationBR
    {
        IValidateBusinessRuleResponse InsertStudentSelfRegistrationValidate(StudentSelfRegistration item);
        IValidateBusinessRuleResponse UpdateStudentSelfRegistrationValidate(StudentSelfRegistration item);
        IValidateBusinessRuleResponse DeleteStudentSelfRegistrationValidate(StudentSelfRegistration item);
    }
}

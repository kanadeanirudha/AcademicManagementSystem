using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IStudentRegistrationAcademicApprovalBR
    {
        IValidateBusinessRuleResponse InsertStudentRegistrationAcademicApprovalValidate(StudentRegistrationAcademicApproval item);
        IValidateBusinessRuleResponse UpdateStudentRegistrationAcademicApprovalValidate(StudentRegistrationAcademicApproval item);
        IValidateBusinessRuleResponse DeleteStudentRegistrationAcademicApprovalValidate(StudentRegistrationAcademicApproval item);
    }
}

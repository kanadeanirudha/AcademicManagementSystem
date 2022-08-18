using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IStudentIdentityCardBR
    {
        IValidateBusinessRuleResponse InsertStudentIdentityCardValidate(StudentIdentityCard item);
        IValidateBusinessRuleResponse UpdateStudentIdentityCardValidate(StudentIdentityCard item);
        IValidateBusinessRuleResponse DeleteStudentIdentityCardValidate(StudentIdentityCard item);
    }
}

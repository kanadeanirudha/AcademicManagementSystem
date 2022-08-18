using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolQualifyingExamSubjectBR
    {
        IValidateBusinessRuleResponse InsertToolQualifyingExamSubjectValidate(ToolQualifyingExamSubject item);
        IValidateBusinessRuleResponse UpdateToolQualifyingExamSubjectValidate(ToolQualifyingExamSubject item);
        IValidateBusinessRuleResponse DeleteToolQualifyingExamSubjectValidate(ToolQualifyingExamSubject item);
    }
}

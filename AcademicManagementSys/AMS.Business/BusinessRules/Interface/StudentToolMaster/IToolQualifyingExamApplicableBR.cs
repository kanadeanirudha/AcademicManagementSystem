using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolQualifyingExamApplicableBR
    {
        IValidateBusinessRuleResponse InsertToolQualifyingExamApplicableValidate(ToolQualifyingExamApplicable item);
        IValidateBusinessRuleResponse UpdateToolQualifyingExamApplicableValidate(ToolQualifyingExamApplicable item);
        IValidateBusinessRuleResponse DeleteToolQualifyingExamApplicableValidate(ToolQualifyingExamApplicable item);
    }
}

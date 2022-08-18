using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEntranceExamValidationParameterBR
    {
        IValidateBusinessRuleResponse InsertEntranceExamValidationParameterValidate(EntranceExamValidationParameter item);
        IValidateBusinessRuleResponse UpdateEntranceExamValidationParameterValidate(EntranceExamValidationParameter item);
        IValidateBusinessRuleResponse DeleteEntranceExamValidationParameterValidate(EntranceExamValidationParameter item);
    }
}

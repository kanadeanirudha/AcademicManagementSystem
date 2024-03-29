﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEntranceExamValidationParameterApplicableBR
    {
        IValidateBusinessRuleResponse InsertEntranceExamValidationParameterApplicableValidate(EntranceExamValidationParameterApplicable item);
        IValidateBusinessRuleResponse UpdateEntranceExamValidationParameterApplicableValidate(EntranceExamValidationParameterApplicable item);
        IValidateBusinessRuleResponse DeleteEntranceExamValidationParameterApplicableValidate(EntranceExamValidationParameterApplicable item);
    }
}

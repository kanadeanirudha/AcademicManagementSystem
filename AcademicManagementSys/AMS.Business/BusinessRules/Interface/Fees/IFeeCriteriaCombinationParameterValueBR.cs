﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IFeeCriteriaCombinationParameterValueBR
    {
        IValidateBusinessRuleResponse InsertFeeCriteriaCombinationParameterValueValidate(FeeCriteriaCombinationParameterValue item);
        IValidateBusinessRuleResponse UpdateFeeCriteriaCombinationParameterValueValidate(FeeCriteriaCombinationParameterValue item);
        IValidateBusinessRuleResponse DeleteFeeCriteriaCombinationParameterValueValidate(FeeCriteriaCombinationParameterValue item);
    }
}

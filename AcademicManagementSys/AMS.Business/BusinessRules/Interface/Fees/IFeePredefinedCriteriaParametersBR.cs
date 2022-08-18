﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeePredefinedCriteriaParametersBR
    {
        IValidateBusinessRuleResponse InsertFeePredefinedCriteriaParametersValidate(FeePredefinedCriteriaParameters item);
        IValidateBusinessRuleResponse UpdateFeePredefinedCriteriaParametersValidate(FeePredefinedCriteriaParameters item);
        IValidateBusinessRuleResponse DeleteFeePredefinedCriteriaParametersValidate(FeePredefinedCriteriaParameters item);
    }
}

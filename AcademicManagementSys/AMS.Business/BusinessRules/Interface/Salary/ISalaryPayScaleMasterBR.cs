﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ISalaryPayScaleMasterBR
    {
        IValidateBusinessRuleResponse InsertSalaryPayScaleMasterValidate(SalaryPayScaleMaster item);
        IValidateBusinessRuleResponse UpdateSalaryPayScaleMasterValidate(SalaryPayScaleMaster item);
        IValidateBusinessRuleResponse DeleteSalaryPayScaleMasterValidate(SalaryPayScaleMaster item);
    }
}

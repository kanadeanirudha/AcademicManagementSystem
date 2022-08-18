﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeAccountTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertFeeAccountTypeMasterValidate(FeeAccountTypeMaster item);
        IValidateBusinessRuleResponse UpdateFeeAccountTypeMasterValidate(FeeAccountTypeMaster item);
        IValidateBusinessRuleResponse DeleteFeeAccountTypeMasterValidate(FeeAccountTypeMaster item);
    }
}

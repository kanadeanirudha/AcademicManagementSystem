﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralEducationMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralEducationMasterValidate(GeneralEducationMaster item);

        IValidateBusinessRuleResponse UpdateGeneralEducationMasterValidate(GeneralEducationMaster item);

        IValidateBusinessRuleResponse DeleteGeneralEducationMasterValidate(GeneralEducationMaster item);
    }
}

﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminRoleApplicableDetailsBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);

        IValidateBusinessRuleResponse UpdateAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);

        IValidateBusinessRuleResponse DeleteAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);
    }
}

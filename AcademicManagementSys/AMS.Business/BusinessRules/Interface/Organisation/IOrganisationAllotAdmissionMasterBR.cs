﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationAllotAdmissionMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationAllotAdmissionMasterValidate(OrganisationAllotAdmissionMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationAllotAdmissionMasterValidate(OrganisationAllotAdmissionMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationAllotAdmissionMasterValidate(OrganisationAllotAdmissionMaster item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOrganisationDepartmentMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);

        IValidateBusinessRuleResponse UpdateOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);

        IValidateBusinessRuleResponse DeleteOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);
    }
}

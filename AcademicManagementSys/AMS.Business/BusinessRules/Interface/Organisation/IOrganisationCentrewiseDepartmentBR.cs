using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationCentrewiseDepartmentBR
    {
        IValidateBusinessRuleResponse InsertOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse UpdateOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse InsertUpdateOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse DeleteOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
    }
}

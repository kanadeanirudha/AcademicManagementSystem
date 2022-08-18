using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminRoleModuleAccessBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleModuleAccessValidate(AdminRoleModuleAccess item);

        IValidateBusinessRuleResponse UpdateAdminRoleModuleAccessValidate(AdminRoleModuleAccess item);

        IValidateBusinessRuleResponse DeleteAdminRoleModuleAccessValidate(AdminRoleModuleAccess item);
    }
}

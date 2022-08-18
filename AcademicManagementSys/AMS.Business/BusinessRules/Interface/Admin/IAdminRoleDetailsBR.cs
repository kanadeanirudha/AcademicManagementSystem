using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminRoleDetailsBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleDetailsValidate(AdminRoleDetails item);

        IValidateBusinessRuleResponse UpdateAdminRoleDetailsValidate(AdminRoleDetails item);

        IValidateBusinessRuleResponse DeleteAdminRoleDetailsValidate(AdminRoleDetails item);
    }
}

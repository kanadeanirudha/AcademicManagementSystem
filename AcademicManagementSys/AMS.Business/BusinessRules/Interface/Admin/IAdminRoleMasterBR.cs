using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminRoleMasterBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleMasterValidate(AdminRoleMaster item);

        IValidateBusinessRuleResponse UpdateAdminRoleMasterValidate(AdminRoleMaster item);

        IValidateBusinessRuleResponse DeleteAdminRoleMasterValidate(AdminRoleMaster item);
    }
}

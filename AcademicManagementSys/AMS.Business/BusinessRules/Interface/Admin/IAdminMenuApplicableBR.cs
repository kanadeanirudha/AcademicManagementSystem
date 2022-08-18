using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminMenuApplicableBR
    {
        IValidateBusinessRuleResponse InsertAdminMenuApplicableValidate(AdminMenuApplicable item);

        IValidateBusinessRuleResponse UpdateAdminMenuApplicableValidate(AdminMenuApplicable item);

        IValidateBusinessRuleResponse DeleteAdminMenuApplicableValidate(AdminMenuApplicable item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IDashboardBR
    {
        IValidateBusinessRuleResponse InsertDashboardValidate(Dashboard item);
        IValidateBusinessRuleResponse UpdateDashboardValidate(Dashboard item);
        IValidateBusinessRuleResponse DeleteDashboardValidate(Dashboard item);

        IValidateBusinessRuleResponse InsertContaintAllocateStatusValidate(Dashboard item);
        IValidateBusinessRuleResponse DeleteContaintAllocateStatusValidate(Dashboard item);
    }
}

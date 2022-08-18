using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveAvailedBR
    {
        IValidateBusinessRuleResponse InsertLeaveAvailedValidate(LeaveAvailed item);
        IValidateBusinessRuleResponse UpdateLeaveAvailedValidate(LeaveAvailed item);
        IValidateBusinessRuleResponse DeleteLeaveAvailedValidate(LeaveAvailed item);
    }
}

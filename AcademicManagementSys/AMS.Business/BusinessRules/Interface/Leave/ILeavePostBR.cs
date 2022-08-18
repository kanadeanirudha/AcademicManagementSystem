using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeavePostBR
    {
        IValidateBusinessRuleResponse InsertLeavePostValidate(LeavePost item);
        IValidateBusinessRuleResponse UpdateLeavePostValidate(LeavePost item);
        IValidateBusinessRuleResponse DeleteLeavePostValidate(LeavePost item);
    }
}

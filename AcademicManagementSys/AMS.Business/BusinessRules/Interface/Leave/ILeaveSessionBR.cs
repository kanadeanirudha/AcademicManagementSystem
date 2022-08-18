using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveSessionBR
    {
        IValidateBusinessRuleResponse InsertLeaveSessionValidate(LeaveSession item);
        IValidateBusinessRuleResponse UpdateLeaveSessionValidate(LeaveSession item);
        IValidateBusinessRuleResponse DeleteLeaveSessionValidate(LeaveSession item);

        ////------------------------Leave Session Details--------------------------////
        IValidateBusinessRuleResponse InsertLeaveSessionDetailsValidate(LeaveSession item);
        IValidateBusinessRuleResponse UpdateLeaveSessionDetailsValidate(LeaveSession item);
        IValidateBusinessRuleResponse DeleteLeaveSessionDetailsValidate(LeaveSession item);

    }
}

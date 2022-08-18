using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveAttendanceSpanLockBR
    {
        IValidateBusinessRuleResponse InsertLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
        IValidateBusinessRuleResponse UpdateLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
        IValidateBusinessRuleResponse DeleteLeaveAttendanceSpanLockValidate(LeaveAttendanceSpanLock item);
    }
}

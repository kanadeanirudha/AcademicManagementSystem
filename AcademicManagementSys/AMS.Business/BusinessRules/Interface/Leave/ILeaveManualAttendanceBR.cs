using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveManualAttendanceBR
    {
        IValidateBusinessRuleResponse InsertLeaveManualAttendanceValidate(LeaveManualAttendance item);
        IValidateBusinessRuleResponse UpdateLeaveManualAttendanceValidate(LeaveManualAttendance item);
        IValidateBusinessRuleResponse DeleteLeaveManualAttendanceValidate(LeaveManualAttendance item);
    }
}

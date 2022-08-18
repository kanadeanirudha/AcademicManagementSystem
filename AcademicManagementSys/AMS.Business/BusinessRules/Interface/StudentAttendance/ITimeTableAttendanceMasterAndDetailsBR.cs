using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface ITimeTableAttendanceMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertTimeTableAttendanceMasterAndDetailsValidate(TimeTableAttendanceMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateTimeTableAttendanceMasterAndDetailsValidate(TimeTableAttendanceMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteTimeTableAttendanceMasterAndDetailsValidate(TimeTableAttendanceMasterAndDetails item);
    }
}

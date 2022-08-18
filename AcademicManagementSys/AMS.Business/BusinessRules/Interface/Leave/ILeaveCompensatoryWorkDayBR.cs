using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveCompensatoryWorkDayBR
    {
        IValidateBusinessRuleResponse InsertLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
        IValidateBusinessRuleResponse UpdateLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
        IValidateBusinessRuleResponse DeleteLeaveCompensatoryWorkDayValidate(LeaveCompensatoryWorkDay item);
    }
}

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeaveRuleExemptedEmployeeServiceAccess
    {
        IBaseEntityResponse<LeaveRuleExemptedEmployee> InsertLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> UpdateLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> GetBySearch(LeaveRuleExemptedEmployeeSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> SelectByID(LeaveRuleExemptedEmployee item);
    }
}

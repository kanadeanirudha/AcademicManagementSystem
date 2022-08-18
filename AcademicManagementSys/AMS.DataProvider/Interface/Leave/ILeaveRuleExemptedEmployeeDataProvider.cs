using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ILeaveRuleExemptedEmployeeDataProvider
    {
        IBaseEntityResponse<LeaveRuleExemptedEmployee> InsertLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> UpdateLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> GetLeaveRuleExemptedEmployeeBySearch(LeaveRuleExemptedEmployeeSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> GetLeaveRuleExemptedEmployeeByID(LeaveRuleExemptedEmployee item);
    }
}

using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveRuleExemptedEmployeeServiceAccess : ILeaveRuleExemptedEmployeeServiceAccess
    {
        ILeaveRuleExemptedEmployeeBA _leaveRuleExemptedEmployeeBA = null;
        public LeaveRuleExemptedEmployeeServiceAccess()
        {
            _leaveRuleExemptedEmployeeBA = new LeaveRuleExemptedEmployeeBA();
        }
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> InsertLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            return _leaveRuleExemptedEmployeeBA.InsertLeaveRuleExemptedEmployee(item);
        }
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> UpdateLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            return _leaveRuleExemptedEmployeeBA.UpdateLeaveRuleExemptedEmployee(item);
        }
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            return _leaveRuleExemptedEmployeeBA.DeleteLeaveRuleExemptedEmployee(item);
        }
        public IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> GetBySearch(LeaveRuleExemptedEmployeeSearchRequest searchRequest)
        {
            return _leaveRuleExemptedEmployeeBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> SelectByID(LeaveRuleExemptedEmployee item)
        {
            return _leaveRuleExemptedEmployeeBA.SelectByID(item);
        }
    }
}

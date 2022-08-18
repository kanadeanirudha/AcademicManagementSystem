using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveRuleMasterServiceAccess : ILeaveRuleMasterServiceAccess
    {
        ILeaveRuleMasterBA _leaveRuleMasterBA = null;
        public LeaveRuleMasterServiceAccess()
        {
            _leaveRuleMasterBA = new LeaveRuleMasterBA();
        }
        public IBaseEntityResponse<LeaveRuleMaster> InsertLeaveRuleMaster(LeaveRuleMaster item)
        {
            return _leaveRuleMasterBA.InsertLeaveRuleMaster(item);
        }
        public IBaseEntityResponse<LeaveRuleMaster> UpdateLeaveRuleMaster(LeaveRuleMaster item)
        {
            return _leaveRuleMasterBA.UpdateLeaveRuleMaster(item); 
        }
        public IBaseEntityResponse<LeaveRuleMaster> DeleteLeaveRuleMaster(LeaveRuleMaster item)
        {
            return _leaveRuleMasterBA.DeleteLeaveRuleMaster(item);
        }
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetBySearch(LeaveRuleMasterSearchRequest searchRequest)
        {
            return _leaveRuleMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveRuleMaster> SelectByID(LeaveRuleMaster item)
        {
            return _leaveRuleMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<LeaveRuleMaster> GetByLeaveCode(LeaveRuleMasterSearchRequest searchRequest)
        {
            return _leaveRuleMasterBA.GetByLeaveCode(searchRequest);
        }
        public IBaseEntityResponse<LeaveRuleMaster> GetLeaveDetails(LeaveRuleMaster item)
        {
            return _leaveRuleMasterBA.GetLeaveDetails(item);
        }
        public IBaseEntityCollectionResponse<LeaveRuleMaster> LeaveRuleStatusGetByCentreAndEmployee(LeaveRuleMasterSearchRequest searchRequest)
        {
            return _leaveRuleMasterBA.LeaveRuleStatusGetByCentreAndEmployee(searchRequest);
        }
        
    }
}

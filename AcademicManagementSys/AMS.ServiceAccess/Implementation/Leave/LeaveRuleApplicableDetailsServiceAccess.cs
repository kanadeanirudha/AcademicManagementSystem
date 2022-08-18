using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveRuleApplicableDetailsServiceAccess : ILeaveRuleApplicableDetailsServiceAccess
    {
        ILeaveRuleApplicableDetailsBA _leaveRuleApplicableDetailsBA = null;
        public LeaveRuleApplicableDetailsServiceAccess()
        {
            _leaveRuleApplicableDetailsBA = new LeaveRuleApplicableDetailsBA();
        }
        public IBaseEntityResponse<LeaveRuleApplicableDetails> InsertLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            return _leaveRuleApplicableDetailsBA.InsertLeaveRuleApplicableDetails(item);
        }
        public IBaseEntityResponse<LeaveRuleApplicableDetails> UpdateLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            return _leaveRuleApplicableDetailsBA.UpdateLeaveRuleApplicableDetails(item);
        }
        public IBaseEntityResponse<LeaveRuleApplicableDetails> DeleteLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item)
        {
            return _leaveRuleApplicableDetailsBA.DeleteLeaveRuleApplicableDetails(item);
        }
        public IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> GetBySearch(LeaveRuleApplicableDetailsSearchRequest searchRequest)
        {
            return _leaveRuleApplicableDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> SelectByLeaveRuleMasterID(LeaveRuleApplicableDetailsSearchRequest searchRequest)
        {
            return _leaveRuleApplicableDetailsBA.SelectByLeaveRuleMasterID(searchRequest);
        }        
        public IBaseEntityResponse<LeaveRuleApplicableDetails> SelectByID(LeaveRuleApplicableDetails item)
        {
            return _leaveRuleApplicableDetailsBA.SelectByID(item);
        }
    }
}

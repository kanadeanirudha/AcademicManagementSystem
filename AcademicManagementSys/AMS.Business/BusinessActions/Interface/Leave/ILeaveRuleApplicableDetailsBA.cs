using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ILeaveRuleApplicableDetailsBA
    {
        IBaseEntityResponse<LeaveRuleApplicableDetails> InsertLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> UpdateLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> DeleteLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> GetBySearch(LeaveRuleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> SelectByLeaveRuleMasterID(LeaveRuleApplicableDetailsSearchRequest searchRequest);        
        IBaseEntityResponse<LeaveRuleApplicableDetails> SelectByID(LeaveRuleApplicableDetails item);
    }
}

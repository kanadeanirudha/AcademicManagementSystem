using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ILeaveRuleApplicableDetailsDataProvider
    {
        IBaseEntityResponse<LeaveRuleApplicableDetails> InsertLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> UpdateLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityResponse<LeaveRuleApplicableDetails> DeleteLeaveRuleApplicableDetails(LeaveRuleApplicableDetails item);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> GetLeaveRuleApplicableDetailsBySearch(LeaveRuleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> SelectByLeaveRuleMasterID(LeaveRuleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleApplicableDetails> GetLeaveRuleApplicableDetailsByID(LeaveRuleApplicableDetails item);
    }
}

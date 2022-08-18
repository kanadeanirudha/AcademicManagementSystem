using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveLateMarkRulesDetailsServiceAccess : ILeaveLateMarkRulesDetailsServiceAccess
    {
        ILeaveLateMarkRulesDetailsBA _leaveLateMarkRulesDetailsBA = null;
        public LeaveLateMarkRulesDetailsServiceAccess()
        {
            _leaveLateMarkRulesDetailsBA = new LeaveLateMarkRulesDetailsBA();
        }
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> InsertLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            return _leaveLateMarkRulesDetailsBA.InsertLeaveLateMarkRulesDetails(item);
        }
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> UpdateLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            return _leaveLateMarkRulesDetailsBA.UpdateLeaveLateMarkRulesDetails(item);
        }
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetails item)
        {
            return _leaveLateMarkRulesDetailsBA.DeleteLeaveLateMarkRulesDetails(item);
        }
        public IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> GetBySearch(LeaveLateMarkRulesDetailsSearchRequest searchRequest)
        {
            return _leaveLateMarkRulesDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveLateMarkRulesDetails> SelectByID(LeaveLateMarkRulesDetails item)
        {
            return _leaveLateMarkRulesDetailsBA.SelectByID(item);
        }
    }
}

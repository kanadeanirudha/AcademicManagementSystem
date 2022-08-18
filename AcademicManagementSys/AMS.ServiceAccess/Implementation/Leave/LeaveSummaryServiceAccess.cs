using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveSummaryServiceAccess : ILeaveSummaryServiceAccess
    {
        ILeaveSummaryBA _leaveSummaryBA = null;
        public LeaveSummaryServiceAccess()
        {
            _leaveSummaryBA = new LeaveSummaryBA();
        }
        public IBaseEntityResponse<LeaveSummary> InsertLeaveSummary(LeaveSummary item)
        {
            return _leaveSummaryBA.InsertLeaveSummary(item);
        }
        public IBaseEntityResponse<LeaveSummary> UpdateLeaveSummary(LeaveSummary item)
        {
            return _leaveSummaryBA.UpdateLeaveSummary(item);
        }
        public IBaseEntityResponse<LeaveSummary> DeleteLeaveSummary(LeaveSummary item)
        {
            return _leaveSummaryBA.DeleteLeaveSummary(item);
        }
        public IBaseEntityCollectionResponse<LeaveSummary> GetBySearch(LeaveSummarySearchRequest searchRequest)
        {
            return _leaveSummaryBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveSummary> SelectByID(LeaveSummary item)
        {
            return _leaveSummaryBA.SelectByID(item);
        }
    }
}

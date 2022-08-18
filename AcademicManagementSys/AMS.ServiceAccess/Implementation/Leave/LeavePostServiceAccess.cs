using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeavePostServiceAccess : ILeavePostServiceAccess
    {
        ILeavePostBA _LeavePostBA = null;
        public LeavePostServiceAccess()
        {
            _LeavePostBA = new LeavePostBA();
        }
        public IBaseEntityResponse<LeavePost> InsertLeavePostAtOpening(LeavePost item)
        {
            return _LeavePostBA.InsertLeavePostAtOpening(item);
        }
        public IBaseEntityResponse<LeavePost> UpdateLeavePost(LeavePost item)
        {
            return _LeavePostBA.UpdateLeavePost(item);
        }
        public IBaseEntityResponse<LeavePost> DeleteLeavePost(LeavePost item)
        {
            return _LeavePostBA.DeleteLeavePost(item);
        }
        public IBaseEntityCollectionResponse<LeavePost> GetBySearch(LeavePostSearchRequest searchRequest)
        {
            return _LeavePostBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeavePost> SelectByID(LeavePost item)
        {
            return _LeavePostBA.SelectByID(item);
        }
        public IBaseEntityResponse<LeavePost> InsertLeavePostAtYearEnd(LeavePost item)
        {
            return _LeavePostBA.InsertLeavePostAtYearEnd(item);
        }
        public IBaseEntityCollectionResponse<LeavePost> GetLeaveSummaryAtTheYearEndBySearch(LeavePostSearchRequest searchRequest)
        {
            return _LeavePostBA.GetLeaveSummaryAtTheYearEndBySearch(searchRequest);
        }
        
    }
}

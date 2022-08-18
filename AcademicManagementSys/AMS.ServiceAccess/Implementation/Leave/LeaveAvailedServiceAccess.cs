using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveAvailedServiceAccess : ILeaveAvailedServiceAccess
    {
        ILeaveAvailedBA _leaveAvailedBA = null;
        public LeaveAvailedServiceAccess()
        {
            _leaveAvailedBA = new LeaveAvailedBA();
        }
        public IBaseEntityResponse<LeaveAvailed> InsertLeaveAvailed(LeaveAvailed item)
        {
            return _leaveAvailedBA.InsertLeaveAvailed(item);
        }
        public IBaseEntityResponse<LeaveAvailed> UpdateLeaveAvailed(LeaveAvailed item)
        {
            return _leaveAvailedBA.UpdateLeaveAvailed(item);
        }
        public IBaseEntityResponse<LeaveAvailed> DeleteLeaveAvailed(LeaveAvailed item)
        {
            return _leaveAvailedBA.DeleteLeaveAvailed(item);
        }
        public IBaseEntityCollectionResponse<LeaveAvailed> GetBySearch(LeaveAvailedSearchRequest searchRequest)
        {
            return _leaveAvailedBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveAvailed> SelectByID(LeaveAvailed item)
        {
            return _leaveAvailedBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<LeaveAvailed> GetLeaveRequestForApproval_ByPersonID(LeaveAvailedSearchRequest searchRequest)
        {
            return _leaveAvailedBA.GetLeaveRequestForApproval_ByPersonID(searchRequest);
        }        
    }
}

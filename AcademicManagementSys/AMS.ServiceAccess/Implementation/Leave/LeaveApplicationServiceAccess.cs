using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveApplicationServiceAccess : ILeaveApplicationServiceAccess
    {
        ILeaveApplicationBA _leaveApplicationBA = null;
        public LeaveApplicationServiceAccess()
        {
            _leaveApplicationBA = new LeaveApplicationBA();
        }
        public IBaseEntityResponse<LeaveApplication> InsertLeaveApplication(LeaveApplication item)
        {
            return _leaveApplicationBA.InsertLeaveApplication(item);
        }
        public IBaseEntityResponse<LeaveApplication> UpdateLeaveApplication(LeaveApplication item)
        {
            return _leaveApplicationBA.UpdateLeaveApplication(item);
        }
        public IBaseEntityResponse<LeaveApplication> DeleteLeaveApplication(LeaveApplication item)
        {
            return _leaveApplicationBA.DeleteLeaveApplication(item);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetBySearch(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveApplication> SelectByID(LeaveApplication item)
        {
            return _leaveApplicationBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveSummaryByEmployeeID(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetLeaveSummaryByEmployeeID(searchRequest);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationStatusByEmployeeID(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetLeaveApplicationStatusByEmployeeID(searchRequest);
        }
        

        //--------------- LeaveApplicationCancel ---------------------

        public IBaseEntityResponse<LeaveApplication> InsertLeaveApplicationCancel(LeaveApplication item)
        {
            return _leaveApplicationBA.InsertLeaveApplicationCancel(item);
        }
        public IBaseEntityResponse<LeaveApplication> UpdateLeaveApplicationCancel(LeaveApplication item)
        {
            return _leaveApplicationBA.UpdateLeaveApplicationCancel(item);
        }
        public IBaseEntityResponse<LeaveApplication> DeleteLeaveApplicationCancel(LeaveApplication item)
        {
            return _leaveApplicationBA.DeleteLeaveApplicationCancel(item);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelBySearch(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetLeaveApplicationCancelBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveApplication> SelectLeaveApplicationCancelByID(LeaveApplication item)
        {
            return _leaveApplicationBA.SelectLeaveApplicationCancelByID(item);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelViewDetails(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetLeaveApplicationCancelViewDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetLeaveApplicationApprocedPendingStatus_SearchList(searchRequest);
        }

        public IBaseEntityCollectionResponse<LeaveApplication>GetEmployeeBalanceLeave(LeaveApplicationSearchRequest searchRequest)
        {
            return _leaveApplicationBA.GetEmployeeBalanceLeave(searchRequest);
        }
    }
}

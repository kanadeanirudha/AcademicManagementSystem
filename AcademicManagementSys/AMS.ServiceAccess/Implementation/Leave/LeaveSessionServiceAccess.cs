using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveSessionServiceAccess : ILeaveSessionServiceAccess
    {
        ILeaveSessionBA _leaveSessionBA = null;
        public LeaveSessionServiceAccess()
        {
            _leaveSessionBA = new LeaveSessionBA();
        }
        public IBaseEntityResponse<LeaveSession> InsertLeaveSession(LeaveSession item)
        {
            return _leaveSessionBA.InsertLeaveSession(item);
        }
        public IBaseEntityResponse<LeaveSession> UpdateLeaveSession(LeaveSession item)
        {
            return _leaveSessionBA.UpdateLeaveSession(item);
        }
        public IBaseEntityResponse<LeaveSession> DeleteLeaveSession(LeaveSession item)
        {
            return _leaveSessionBA.DeleteLeaveSession(item);
        }
        public IBaseEntityCollectionResponse<LeaveSession> GetBySearch(LeaveSessionSearchRequest searchRequest)
        {
            return _leaveSessionBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveSession> SelectByID(LeaveSession item)
        {
            return _leaveSessionBA.SelectByID(item);
        }
        public IBaseEntityResponse<LeaveSession> SelectByEmployeeIDAndCentreCode(LeaveSessionSearchRequest searchRequest)
        {
            return _leaveSessionBA.SelectByEmployeeIDAndCentreCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<LeaveSession> GetByFromLeaveSessionID(LeaveSessionSearchRequest searchRequest)
        {
            return _leaveSessionBA.GetByFromLeaveSessionID(searchRequest);
        }
       


        public IBaseEntityResponse<LeaveSession> InsertLeaveSessionDetails(LeaveSession item)
        {
            return _leaveSessionBA.InsertLeaveSessionDetails(item);
        }
        public IBaseEntityResponse<LeaveSession> UpdateLeaveSessionDetails(LeaveSession item)
        {
            return _leaveSessionBA.UpdateLeaveSessionDetails(item);
        }
        public IBaseEntityResponse<LeaveSession> DeleteLeaveSessionDetails(LeaveSession item)
        {
            return _leaveSessionBA.DeleteLeaveSessionDetails(item);
        }
        public IBaseEntityCollectionResponse<LeaveSession> GetLeaveSessionDetailsBySearch(LeaveSessionSearchRequest searchRequest)
        {
            return _leaveSessionBA.GetLeaveSessionDetailsBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveSession> SelectLeaveSessionDetailsByID(LeaveSession item)
        {
            return _leaveSessionBA.SelectLeaveSessionDetailsByID(item);
        }

    }
}

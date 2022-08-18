using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveManualAttendanceServiceAccess : ILeaveManualAttendanceServiceAccess
    {
        ILeaveManualAttendanceBA _leaveManualAttendanceBA = null;
        public LeaveManualAttendanceServiceAccess()
        {
            _leaveManualAttendanceBA = new LeaveManualAttendanceBA();
        }
        public IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item)
        {
            return _leaveManualAttendanceBA.InsertLeaveManualAttendance(item);
        }
        public IBaseEntityResponse<LeaveManualAttendance> UpdateLeaveManualAttendance(LeaveManualAttendance item)
        {
            return _leaveManualAttendanceBA.UpdateLeaveManualAttendance(item);
        }
        public IBaseEntityResponse<LeaveManualAttendance> DeleteLeaveManualAttendance(LeaveManualAttendance item)
        {
            return _leaveManualAttendanceBA.DeleteLeaveManualAttendance(item);
        }
        public IBaseEntityCollectionResponse<LeaveManualAttendance> GetBySearch(LeaveManualAttendanceSearchRequest searchRequest)
        {
            return _leaveManualAttendanceBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveManualAttendance> SelectByID(LeaveManualAttendance item)
        {
            return _leaveManualAttendanceBA.SelectByID(item);
        }
    }
}

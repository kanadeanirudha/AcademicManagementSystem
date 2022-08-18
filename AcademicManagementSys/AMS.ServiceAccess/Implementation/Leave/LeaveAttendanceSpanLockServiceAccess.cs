using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class LeaveAttendanceSpanLockServiceAccess : ILeaveAttendanceSpanLockServiceAccess
    {
        ILeaveAttendanceSpanLockBA _leaveAttendanceSpanLockBA = null;
        public LeaveAttendanceSpanLockServiceAccess()
        {
            _leaveAttendanceSpanLockBA = new LeaveAttendanceSpanLockBA();
        }
        public IBaseEntityResponse<LeaveAttendanceSpanLock> InsertLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            return _leaveAttendanceSpanLockBA.InsertLeaveAttendanceSpanLock(item);
        }
        public IBaseEntityResponse<LeaveAttendanceSpanLock> UpdateLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            return _leaveAttendanceSpanLockBA.UpdateLeaveAttendanceSpanLock(item);
        }
        public IBaseEntityResponse<LeaveAttendanceSpanLock> DeleteLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item)
        {
            return _leaveAttendanceSpanLockBA.DeleteLeaveAttendanceSpanLock(item);
        }
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetBySearch(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            return _leaveAttendanceSpanLockBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByID(LeaveAttendanceSpanLock item)
        {
            return _leaveAttendanceSpanLockBA.SelectByID(item);
        }
        public IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByCentreCode(LeaveAttendanceSpanLock item)
        {
            return _leaveAttendanceSpanLockBA.SelectByCentreCode(item);
        }
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCode(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            return _leaveAttendanceSpanLockBA.GetByCentreCode(searchRequest);
        }
        public IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCodeDepartmentIDAndSalarySpanID(LeaveAttendanceSpanLockSearchRequest searchRequest)
        {
            return _leaveAttendanceSpanLockBA.GetByCentreCodeDepartmentIDAndSalarySpanID(searchRequest);
        }
        
    }
}

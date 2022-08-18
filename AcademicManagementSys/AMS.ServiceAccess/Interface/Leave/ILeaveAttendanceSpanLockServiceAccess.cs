using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface ILeaveAttendanceSpanLockServiceAccess
    {
        IBaseEntityResponse<LeaveAttendanceSpanLock> InsertLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> UpdateLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> DeleteLeaveAttendanceSpanLock(LeaveAttendanceSpanLock item);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetBySearch(LeaveAttendanceSpanLockSearchRequest searchRequest);
        IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByID(LeaveAttendanceSpanLock item);
        IBaseEntityResponse<LeaveAttendanceSpanLock> SelectByCentreCode(LeaveAttendanceSpanLock item);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCode(LeaveAttendanceSpanLockSearchRequest searchRequest);
        IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> GetByCentreCodeDepartmentIDAndSalarySpanID(LeaveAttendanceSpanLockSearchRequest searchRequest);        
    }
}




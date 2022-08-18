using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ILeaveManualAttendanceDataProvider
    {
        IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> UpdateLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> DeleteLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityCollectionResponse<LeaveManualAttendance> GetLeaveManualAttendanceBySearch(LeaveManualAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<LeaveManualAttendance> GetLeaveManualAttendanceByID(LeaveManualAttendance item);
    }
}

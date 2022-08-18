using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ILeaveManualAttendanceBA
    {
        IBaseEntityResponse<LeaveManualAttendance> InsertLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> UpdateLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityResponse<LeaveManualAttendance> DeleteLeaveManualAttendance(LeaveManualAttendance item);
        IBaseEntityCollectionResponse<LeaveManualAttendance> GetBySearch(LeaveManualAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<LeaveManualAttendance> SelectByID(LeaveManualAttendance item);
    }
}

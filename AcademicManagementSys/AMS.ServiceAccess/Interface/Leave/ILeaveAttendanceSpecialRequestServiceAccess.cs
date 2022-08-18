using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
	public interface ILeaveAttendanceSpecialRequestServiceAccess
	{
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> UpdateLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> DeleteLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> GetBySearch(LeaveAttendanceSpecialRequestSearchRequest searchRequest);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> SelectByID(LeaveAttendanceSpecialRequest item);
	}
}

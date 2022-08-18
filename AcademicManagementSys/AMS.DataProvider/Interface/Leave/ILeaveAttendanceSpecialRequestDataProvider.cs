using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ILeaveAttendanceSpecialRequestDataProvider
	{
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> UpdateLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> DeleteLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item);
		IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> GetLeaveAttendanceSpecialRequestBySearch(LeaveAttendanceSpecialRequestSearchRequest searchRequest);
		IBaseEntityResponse<LeaveAttendanceSpecialRequest> GetLeaveAttendanceSpecialRequestByID(LeaveAttendanceSpecialRequest item);
	}
}

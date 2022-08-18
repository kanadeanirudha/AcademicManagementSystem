using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface ILeaveAttendanceExemptionBA
	{
		IBaseEntityResponse<LeaveAttendanceExemption> InsertLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityResponse<LeaveAttendanceExemption> UpdateLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityResponse<LeaveAttendanceExemption> DeleteLeaveAttendanceExemption(LeaveAttendanceExemption item);
		IBaseEntityCollectionResponse<LeaveAttendanceExemption> GetBySearch(LeaveAttendanceExemptionSearchRequest searchRequest);
		IBaseEntityResponse<LeaveAttendanceExemption> SelectByID(LeaveAttendanceExemption item);
	}
}

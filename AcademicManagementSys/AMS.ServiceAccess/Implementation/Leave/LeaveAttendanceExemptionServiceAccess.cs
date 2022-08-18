using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class LeaveAttendanceExemptionServiceAccess : ILeaveAttendanceExemptionServiceAccess
	{
		ILeaveAttendanceExemptionBA _leaveAttendanceExemptionBA = null;
		public LeaveAttendanceExemptionServiceAccess()
		{
			_leaveAttendanceExemptionBA = new LeaveAttendanceExemptionBA();
		}
		public IBaseEntityResponse<LeaveAttendanceExemption> InsertLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			return _leaveAttendanceExemptionBA.InsertLeaveAttendanceExemption(item);
		}
		public IBaseEntityResponse<LeaveAttendanceExemption> UpdateLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			return _leaveAttendanceExemptionBA.UpdateLeaveAttendanceExemption(item);
		}
		public IBaseEntityResponse<LeaveAttendanceExemption> DeleteLeaveAttendanceExemption(LeaveAttendanceExemption item)
		{
			return _leaveAttendanceExemptionBA.DeleteLeaveAttendanceExemption(item);
		}
		public IBaseEntityCollectionResponse<LeaveAttendanceExemption> GetBySearch(LeaveAttendanceExemptionSearchRequest searchRequest)
		{
			return _leaveAttendanceExemptionBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<LeaveAttendanceExemption> SelectByID(LeaveAttendanceExemption item)
		{
			return _leaveAttendanceExemptionBA.SelectByID(item);
		}
	}
}

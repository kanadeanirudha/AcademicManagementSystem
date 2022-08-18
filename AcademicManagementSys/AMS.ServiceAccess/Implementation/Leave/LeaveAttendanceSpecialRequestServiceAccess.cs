using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class LeaveAttendanceSpecialRequestServiceAccess : ILeaveAttendanceSpecialRequestServiceAccess
	{
		ILeaveAttendanceSpecialRequestBA _LeaveAttendanceSpecialRequestBA = null;
		public LeaveAttendanceSpecialRequestServiceAccess()
		{
			_LeaveAttendanceSpecialRequestBA = new LeaveAttendanceSpecialRequestBA();
		}
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> InsertLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			return _LeaveAttendanceSpecialRequestBA.InsertLeaveAttendanceSpecialRequest(item);
		}
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> UpdateLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			return _LeaveAttendanceSpecialRequestBA.UpdateLeaveAttendanceSpecialRequest(item);
		}
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> DeleteLeaveAttendanceSpecialRequest(LeaveAttendanceSpecialRequest item)
		{
			return _LeaveAttendanceSpecialRequestBA.DeleteLeaveAttendanceSpecialRequest(item);
		}
		public IBaseEntityCollectionResponse<LeaveAttendanceSpecialRequest> GetBySearch(LeaveAttendanceSpecialRequestSearchRequest searchRequest)
		{
			return _LeaveAttendanceSpecialRequestBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<LeaveAttendanceSpecialRequest> SelectByID(LeaveAttendanceSpecialRequest item)
		{
			return _LeaveAttendanceSpecialRequestBA.SelectByID(item);
		}
	}
}

using AMS.Base.DTO;
using AMS.Business;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class TimeTableAttendanceMasterAndDetailsServiceAccess : ITimeTableAttendanceMasterAndDetailsServiceAccess
    {
        ITimeTableAttendanceMasterAndDetailsBA _TimeTableAttendanceMasterAndDetailsBA = null;
		public TimeTableAttendanceMasterAndDetailsServiceAccess()
		{
			_TimeTableAttendanceMasterAndDetailsBA = new TimeTableAttendanceMasterAndDetailsBA();
		}
    }
}

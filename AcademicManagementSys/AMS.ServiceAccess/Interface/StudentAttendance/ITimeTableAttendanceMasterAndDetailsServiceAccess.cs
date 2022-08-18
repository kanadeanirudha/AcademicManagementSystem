using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ITimeTableAttendanceMasterAndDetailsServiceAccess
	{
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> InsertStudentMaster(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> UpdateStudentMaster(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> DeleteStudentMaster(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetStudentSearchList(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetBySearch(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);
    }
}

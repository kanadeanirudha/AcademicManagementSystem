using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business
{
    public interface ITimeTableAttendanceMasterAndDetailsBA
    {
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> InsertTimeTableAttendanceMasterAndDetailsr(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> UpdateTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> DeleteTimeTableAttendanceMasterAndDetailsr(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetTimeTableAttendanceMasterAndDetailsSearchList(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetBySearch(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);
    }
}

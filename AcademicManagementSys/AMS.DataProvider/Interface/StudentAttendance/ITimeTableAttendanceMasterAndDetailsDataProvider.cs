using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface ITimeTableAttendanceMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> InsertTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> UpdateTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityResponse<TimeTableAttendanceMasterAndDetails> DeleteTimeTableAttendanceMasterAndDetails(TimeTableAttendanceMasterAndDetails item);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetStudentSearchList(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<TimeTableAttendanceMasterAndDetails> GetTimeTableAttendanceMasterAndDetailsBySearch(TimeTableAttendanceMasterAndDetailsSearchRequest searchRequest);

    }
}
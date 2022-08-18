using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class EntranceExamScheduleAndScheduleDetailSearchRequest : Request
    {
        //EntranceExamSchedule Table proprty.
        public int EntranceExamScheduleID { get; set; }
        public string ScheduleName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ScheduleTimeStart { get; set; }
        public DateTime ScheduleEndTime { get; set; }
        public int OnlineExamExaminationQuestionPaperID { get; set; }
        public int OnlineExamExaminationMasterID { get; set; }
        public int EntranceExamInfrastructureDetailID { get; set; }
        public int EntranceExamCenteApllicableToExamID { get; set; }
        public int TotalStudentApllicableID { get; set; }

        //EntranceExamScheduleDetail Table proprty.
        public int EntranceExamScheduleDetailID { get; set; }        
        public int StudentRegistrationID { get; set; }
        

        //Common Property.
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }

        //Extra Property.
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string EntranceExamScheduleSearchWord { get; set; }
        public string EntranceExamScheduleDetailSearchWord { get; set; }
        public int ExaminationID { get; set; }
        public int StudentCount { get; set; }
        public int OnlineExamApplicableExamToCourseID { get; set; }
        public int EntranceExamAvailbleCentreID { get; set; }

        //For Student List..
        public string StudentName { get; set; }
        public string AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
    }
}

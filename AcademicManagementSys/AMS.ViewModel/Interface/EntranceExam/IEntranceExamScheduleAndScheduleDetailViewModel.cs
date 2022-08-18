using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamScheduleAndScheduleDetailViewModel
    {

        EntranceExamScheduleAndScheduleDetail EntranceExamScheduleAndScheduleDetailDTO { get; set; }

        //EntranceExamSchedule Table Property.
        int EntranceExamScheduleID { get; set; }
        string ScheduleName { get; set; }
        string ScheduleDate { get; set; }
        string ScheduleTimeStart { get; set; }
        string ScheduleEndTime { get; set; }
        int OnlineExamExaminationQuestionPaperID { get; set; }
        int OnlineExamExaminationMasterID { get; set; }
        int EntranceExamInfrastructureDetailID { get; set; }
        int EntranceExamCenteApllicableToExamID { get; set; }
        int TotalStudentApllicable { get; set; }

        //EntranceExamScheduleDetail Table Property.
        int EntranceExamScheduleDetailID { get; set; }        
        int StudentRegistrationID { get; set; }
        int OnlineExamApplicableExamToCourseID { get; set; }
        int EntranceExamAvailbleCentreID { get; set; }
        

        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }

    }
}

using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class EntranceExamScheduleAndScheduleDetail : BaseDTO
    {
        //EntranceExamSchedule Table proprty.
        public int EntranceExamScheduleID { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDate { get; set; }
        public string ScheduleTimeStart { get; set; }
        public string ScheduleEndTime { get; set; }
        public int OnlineExamExaminationQuestionPaperID { get; set; }
        public int OnlineExamExaminationMasterID { get; set; }
        public int EntranceExamInfrastructureDetailID { get; set; }
        public int EntranceExamCenteApllicableToExamID { get; set; }
        public int TotalStudentApllicable { get; set; }


        //EntranceExamScheduleDetail Table proprty.
        public int EntranceExamScheduleDetailID { get; set; }       
        public int StudentRegistrationID { get; set; }
        public string SelectedUnAllotedStudentXml { get; set; }

        
        public int EntranceExamAvailableCentresID { get; set; }
        public int CentreWiseSessionID { get; set; }        
        public string CentreName { get; set; }
        public int TotelRoom { get; set; }

        //Common property.
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

         //Extra Property.        
        public int SessionID { get; set; }         
        public string CentreCode { get; set; }
        public int CourseYearDetailID { get; set; }
        public string ExaminationFromDate { get; set; }
        public string ExaminationUpToDate { get; set; }   
        public string RoomName { get; set; }
        public int RoomNumber { get; set; }

        public string ExaminationName { get; set; }
        public int ExaminationID { get; set; }
        public string ExtraDescription { get; set; }
        public int TotalRoom { get; set; }
        public int RoomCapacity { get; set; }
        public int StudentCount { get; set; }
        public int OnlineExamApplicableExamToCourseID { get; set; }
        public int EntranceExamAvailbleCentreID { get; set; }

        //For Student List..
        public string StudentName { get; set; }
        public string AcademicYear { get; set; }
        public int AcademicYearID { get; set; }
        public string PaperSet { get; set; }
        public bool AllotedFlag { get; set; }
    }
}

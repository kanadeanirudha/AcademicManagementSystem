using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExaminationMasterAndCourseApplicable : BaseDTO
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationMaster Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineExamExaminationMasterID { get; set; }
        public string ExaminationName { get; set; }
        public string Purpose { get; set; }
        public int AcadSessionID { get; set; }
        public string ExaminationFor { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationCourseApplicable Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int OnlineExamExaminationCourseApplicableID { get; set; }
        public int CourseYearID { get; set; }
        public int SemesterMasterID { get; set; }
        public int DepartmentID { get; set; }
        public Int16 ExaminationStatus { get; set; }
        public string ExaminationStartDate { get; set; }
        public string ExaminationEndDate { get; set; }
        public string ResultAnnounceDate { get; set; }
        public bool IsResultAnnounce { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~COmmon Prperty~~~~~~~~~~~~~~~~~~~~~~~~~~
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }
    }
}

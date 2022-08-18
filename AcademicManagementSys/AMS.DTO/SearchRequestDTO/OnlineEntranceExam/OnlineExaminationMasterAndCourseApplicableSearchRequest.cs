using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExaminationMasterAndCourseApplicableSearchRequest : Request
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


        //~~~~~~~~~~~~~~~~~~~~~~~~~~Comman Property~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }

    }
}

using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOnlineExaminationMasterAndCourseApplicableViewModel
    {
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationMaster Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~~
        int OnlineExamExaminationMasterID { get; set; }
        string ExaminationName { get; set; }
        string Purpose { get; set; }
        int AcadSessionID { get; set; }
        string ExaminationFor { get; set; }


        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~OnlineExamExaminationCourseApplicable Table Property~~~~~~~~~~~~~~~~~~~~~~~~~~
        int OnlineExamExaminationCourseApplicableID { get; set; }
        int CourseYearID { get; set; }
        int SemesterMasterID { get; set; }
        int DepartmentID { get; set; }
        Int16 ExaminationStatus { get; set; }
        string ExaminationStartDate { get; set; }
        string ExaminationEndDate { get; set; }
        string ResultAnnounceDate { get; set; }
        bool IsResultAnnounce { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Common Prperty~~~~~~~~~~~~~~~~~~~~~~~~~~
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }
        string errorMessage { get; set; }

    }
}

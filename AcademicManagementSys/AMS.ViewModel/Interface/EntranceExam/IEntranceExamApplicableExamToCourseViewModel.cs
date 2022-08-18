using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEntranceExamApplicableExamToCourseViewModel
    {
        EntranceExamApplicableExamToCourse EntranceExamApplicableExamToCourseDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        int CourseYearDetailID
        {
            get;
            set;
        }
        int SessionID
        {
            get;
            set;
        }
        int OnlineExamExaminationMasterID
        {
            get;
            set;
        }

        string CentreCode
        {
            get;
            set;
        }
        string ExaminationFromDate
        {
            get;
            set;
        }
        string ExaminationUpToDate
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}

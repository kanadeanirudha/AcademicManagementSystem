using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OnlineExamStudentApplicable : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public int OnlineExaminationMasterID
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public int SubjectID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public string CourseYearDescription
        {
            get;
            set;
        }
        public string SubjectDescription
        {
            get;
            set;
        }
        public int SemesterMstID
        {
            get;
            set;
        }
        public string SectionDetailDescription
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string XMLString
        {
            get;
            set;
        }
        public int OnlineExamSubjectGroupScheduleID
        {
            get;
            set;
        }
        public int CenterwiseSessionID
        {
            get;
            set;
        }
        public Int16 RequestedEntranceExamCentresID
        {
            get;
            set;
        }
        public Int32 OnlineExamIndStudentExamInfoID
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EntranceExamApplicableExamToCourse : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int CourseYearDetailID
        {
            get;
            set;
        }
        public string CourseName
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public string SessionName { get; set; }
        public int OnlineExamExaminationMasterID
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string ExaminationFromDate
        {
            get;
            set;
        }
        public string ExaminationUpToDate
        {
            get;
            set;
        }
        public string ExaminationName
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

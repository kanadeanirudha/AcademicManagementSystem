using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string StudentFullName
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
       
        public int RollNumber
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int SectionDetailID
        {
            get;
            set;
        }
        public int CourseYearId
        {
            get;
            set;
        }
        public int CategoryId
        {
            get;
            set;
        }
        public int StudentId
        {
            get;
            set;
        }
        
        public string AcademicYear
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string AdmissionStatus
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }

        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }


        public string SearchWord { get; set; }
        public int maxResult { get; set; }

        public string SearchType { get; set; }
        public int SessionID { get; set; }
    }
}

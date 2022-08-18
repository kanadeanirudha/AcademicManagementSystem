using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentChangeCourseRequestApplicationSearchRequest : Request
    {
        public int Id
        {
            get;
            set;
        }
        public int ChangeRequestMasterId
        {
            get;
            set;
        }
        public int StudentId
        {
            get;
            set;
        }
        public DateTime ApplicationDate
        {
            get;
            set;
        }
        public int AcademicYearId
        {
            get;
            set;
        }
        public int OldCourseId
        {
            get;
            set;
        }
        public int NewCourseId
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public int NewSectionDetailsID
        {
            get;
            set;
        }
        public string CenterCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int OldSectionDetailID
        {
            get;
            set;
        }
        public int RequestSectionDetailID
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}

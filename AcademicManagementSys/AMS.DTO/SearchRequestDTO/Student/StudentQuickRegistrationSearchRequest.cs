using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentQuickRegistrationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string MotherName
        {
            get;
            set;
        }
        public string StudentEmailID
        {
            get;
            set;
        }
        public int BranchID
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
        public bool StudentActiveFlag
        {
            get;
            set;
        }
        public bool StudentStatus
        {
            get;
            set;
        }
        public string StatusCode
        {
            get;
            set;
        }
        public string StuAdmissionCode
        {
            get;
            set;
        }
        public string AcademicYear
        {
            get;
            set;
        }
        public string AdmitAcademicYear
        {
            get;
            set;
        }
        public DateTime FirstAdmissionDateTime
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string AdmissionPattern
        {
            get;
            set;
        }
        public int TransferSectionID
        {
            get;
            set;
        }
        public string DirectSecYrAdmissionMode
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
    }
}

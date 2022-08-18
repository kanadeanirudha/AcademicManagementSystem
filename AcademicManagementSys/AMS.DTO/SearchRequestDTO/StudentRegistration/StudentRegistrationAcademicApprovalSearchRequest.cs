using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentRegistrationAcademicApprovalSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int RegistrationID
        {
            get;
            set;
        }
        public string AuthorisationType
        {
            get;
            set;
        }
        public int RoleID
        {
            get;
            set;
        }
        public bool Status
        {
            get;
            set;
        }
        public string ReasonIfRejected
        {
            get;
            set;
        }
        public string EducationType
        {
            get;
            set;
        }
        public bool IslastStatus
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
        public int PersonID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
    }
    public class PreviousWorkExperienceAcademicApprovalSearchRequest : Request
    {
        public int RegistrationID { get; set; }
    }
    
}

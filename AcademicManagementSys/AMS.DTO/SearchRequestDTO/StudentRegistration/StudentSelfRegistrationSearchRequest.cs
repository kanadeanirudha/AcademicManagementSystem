using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentSelfRegistrationSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string Password
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
        public string ContactNumber
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public DateTime DateOfBirth
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
        public bool IsActive
        {
            get;
            set;
        }
        public string WebRegistrationStatus
        {
            get;
            set;
        }
        public string WebAdminComments
        {
            get;
            set;
        }
        public DateTime ApprovalDate
        {
            get;
            set;
        }
        public int AdminApprovedBy
        {
            get;
            set;
        }
        public int StudentID
        {
            get;
            set;
        }
        public string StudentCode
        {
            get;
            set;
        }
        public int ApprovStudSecEmployeeID
        {
            get;
            set;
        }
        public int ApprovAcctSecEmployeeID
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
        public int BranchDetailID
        {
            get;
            set;
        }
        public string ApplicableForEntranceExam
        {
            get;
            set;
        }
        
      
    }
}

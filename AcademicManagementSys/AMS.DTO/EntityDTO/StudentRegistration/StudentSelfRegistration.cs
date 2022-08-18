using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class StudentSelfRegistration : BaseDTO
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
        public string Name
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
        public string DateOfBirth
        {
            get;
            set;
        }
        public string CenterCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int CountryID
        {
            get;
            set;
        }

        public int RegionID
        {
            get;
            set;
        }
        public int CategoryID
        {
            get;
            set;
        }
        public int CasteID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int StudentRegistrationMasterID
        {
            get;
            set;
        }
        
        public string WebRegistrationStatus
        {
            get;
            set;
        }
        public string ApproveRejectStatus
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
        public int AdmissionPattern
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
        public int BranchDetailID
        {
            get;
            set;
        }
        public string BranchDescription
        {
            get;
            set;
        }
        public string DivisionDescription
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public string StandardDescription
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string CountryName { get; set; }
        public string OtherRegion
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        
    }
}

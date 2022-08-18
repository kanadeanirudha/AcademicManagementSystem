using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentSelfRegistrationViewModel
    {
        StudentSelfRegistration StudentSelfRegistrationDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        string EmailID
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string MiddleName
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;
        }
        string ContactNumber
        {
            get;
            set;
        }
        string Gender
        {
            get;
            set;
        }
        string DateOfBirth
        {
            get;
            set;
        }
        string CenterCode
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
         int CountryID
        {
            get;
            set;
        }

         int CategoryID
         {
             get;
             set;
         }
        int CasteID
         {
             get;
             set;
         }
        int RegionID
        {
            get;
            set;
        }
        string OtherRegion
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        string WebRegistrationStatus
        {
            get;
            set;
        }
        string WebAdminComments
        {
            get;
            set;
        }
        DateTime ApprovalDate
        {
            get;
            set;
        }
        int AdminApprovedBy
        {
            get;
            set;
        }
        int StudentID
        {
            get;
            set;
        }
        string StudentCode
        {
            get;
            set;
        }
        int ApprovStudSecEmployeeID
        {
            get;
            set;
        }
        int ApprovAcctSecEmployeeID
        {
            get;
            set;
        }
        int StandardNumber
        {
            get;
            set;
        }
        int AdmissionPattern
        {
            get;
            set;
        }
        int BranchDetailID
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

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
    public interface IStudentSelfRegistrationBaseViewModel
    {


    }
}

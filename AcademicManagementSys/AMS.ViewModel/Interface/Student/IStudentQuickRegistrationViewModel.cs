using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentQuickRegistrationViewModel
    {
        StudentQuickRegistration StudentQuickRegistrationDTO { get; set; }
        int ID
        {
            get;
            set;
        }
        string StudentCode
        {
            get;
            set;
        }
         string FullName
        {
            get;
            set;
        }
         int UniversityID
        {
            get;
            set;
        }
         string StudentQuickInformation
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }
        string StudentGender
        {
            get;
            set;
        }
        string DateofBirth
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
        string MotherName
        {
            get;
            set;
        }
        string AcademicSessionID
        {
            get;
            set;
        }
        string StudentMobileNumber
        {
            get;
            set;
        }

        string StudentEmailID
        {
            get;
            set;
        }
        int BranchID
        {
            get;
            set;
        }
        int SectionDetailID
        {
            get;
            set;
        }
        int CourseYearId
        {
            get;
            set;
        }
        string AdmittedSessionID
        {
            get;
            set;
        }
        bool StudentActiveFlag
        {
            get;
            set;
        }

        bool IsBackStudent
        {
            get;
            set;
        }
        bool StudentStatus
        {
            get;
            set;
        }
        string StatusCode
        {
            get;
            set;
        }
        string StuAdmissionCode
        {
            get;
            set;
        }
        string AcademicYear
        {
            get;
            set;
        }
        string AdmitAcademicYear
        {
            get;
            set;
        }
        DateTime FirstAdmissionDatetime
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string AdmissionPattern
        {
            get;
            set;
        }
        int TransferSectionID
        {
            get;
            set;
        }
        string DirectSecYrAdmissionMode
        {
            get;
            set;
        }
        bool IsActive
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
}


using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentChangeCourseRequestApplicationViewModel
    {
        int Id
        {
            get;
            set;
        }
       int ChangeRequestMasterId
        {
            get;
            set;
        }
       int StudentId
        {
            get;
            set;
        }

       string UserLoginId
       {
           get;
           set;
       }
        DateTime ApplicationDate
        {
            get;
            set;
        }
         int AcademicYearId
        {
            get;
            set;
        }
        int OldCourseId
        {
            get;
            set;
        }
       int NewCourseId
        {
            get;
            set;
        }
       string CentreName
       {
           get;
           set;
       }

       string UniversityName
       {
           get;
           set;
       }
       string BranchDescription
       {
           get;
           set;
       }
       bool ApprovalStatus
        {
            get;
            set;
        }
       int NewSectionDetailsID
        {
            get;
            set;
        }
       int OldSectionDetailID
        {
            get;
            set;
        }
        int RequestSectionDetailID
        {
            get;
            set;
        }
        string CenterCode
        {
            get;
            set;
        }
        string AdmittedCourse
        {
            get;
            set;
        }
        string NewCourse
        {
            get;
            set;
        }
    
      string OldSection
        {
            get;
            set;
        }
      string NewSection
        {
            get;
            set;
        }
       string University
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
        int RoleID
        {
            get;
            set;
        }
       DateTime ApprovalDate
        {
            get;
            set;
        }

      string ApplicationReason
        {
            get;
            set;
        }
       string CancellationReason
        {
            get;
            set;
        }
       bool ApplicationStatus
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



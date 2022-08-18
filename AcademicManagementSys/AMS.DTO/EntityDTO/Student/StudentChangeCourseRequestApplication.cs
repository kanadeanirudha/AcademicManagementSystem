using System;
using AMS.Base.DTO;
namespace AMS.DTO
{
    public class StudentChangeCourseRequestApplication : BaseDTO
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
        public string UserLoginId
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
        public bool ApprovalStatus
        {
            get;
            set;
        }
        public int NewSectionDetailsID
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
        public int BranchID
        {
            get;
            set;
        }
        public string CenterCode
        {
            get;
            set;
        }
        public string UniversityName
        {
            get;
            set;
        }
        public string BranchDescription
        {
            get;
            set;
        }
        
        public string CentreName
        {
            get;
            set;
        }
        public string University
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int RoleID
        {
            get;
            set;
        }
        public DateTime ApprovalDate
        {
            get;
            set;
        }

        public string ApplicationReason
        {
            get;
            set;
        }
        public string CancellationReason
        {
            get;
            set;
        }
        public bool ApplicationStatus
        {
            get;
            set;
        }
       public string AdmittedCourse
        {
            get;
            set;
        }
        
       public string NewCourse
        {
            get;
            set;
        }
       public string OldSection
       {
           get;
           set;
       }
       public string NewSection
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
        public string errorMessage { get; set; }
    }
}

using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentSectionChangeRequestViewModel
    {
        StudentSectionChangeRequest StudentSectionChangeRequestDTO { get; set; }
         int ID
        {
            get;
            set;
        }
        // int StudentID
        //{
        //    get;
        //    set;
        //}
         int RequestSectionDetailId
        {
            get;
            set;
        }
         int SessionID
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         int OldSectionDetailID
        {
            get;
            set;
        }
         string StatusOfRequest
        {
            get;
            set;
        }
         int ApprovedEmployeeId
        {
            get;
            set;
        }
         string ApprovedDate
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

         string CentreName { get; set; }
         string SessionName { get; set; }

          int StudentId { get; set; }
          string StudentName { get; set; }
          int BranchId { get; set; }
          string BranchDescription { get; set; }
          string SectionDesc { get; set; }
          string CourseYearDesc { get; set; }
          string AcademicYear { get; set; }
          string AdmissionNumber { get; set; } 
    }
}

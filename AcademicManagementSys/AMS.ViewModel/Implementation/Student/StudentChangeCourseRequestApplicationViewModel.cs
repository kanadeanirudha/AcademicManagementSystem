using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{

    public class StudentChangeCourseRequestApplicationViewModel : IStudentChangeCourseRequestApplicationViewModel
    {

        public StudentChangeCourseRequestApplicationViewModel()
        {
            StudentChangeCourseRequestApplicationDTO = new StudentChangeCourseRequestApplication();
        }
      public  StudentChangeCourseRequestApplication StudentChangeCourseRequestApplicationDTO
        {
            get;
            set;
        }

     
       public int Id
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.Id > 0) ? StudentChangeCourseRequestApplicationDTO.Id : new int();
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.Id = value;
            }
        }


       public int ChangeRequestMasterId
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ChangeRequestMasterId : new int();
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.ChangeRequestMasterId = value;
            }
        }
       public int StudentId
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.StudentId : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.StudentId = value;
           }
       }

       public string UserLoginId
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.UserLoginId : string.Empty;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.UserLoginId = value;
            }
        
       }
       public string UniversityName
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.UniversityName : string.Empty;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.UniversityName = value;
            }
        
       }
       public string BranchDescription
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.BranchDescription : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.BranchDescription = value;
           }

       }
        
     
       [Display(Name = "ApplicationDate")]
       public DateTime ApplicationDate
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ApplicationDate : DateTime.Now;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.ApplicationDate = value;
           }
       }
       public int AcademicYearId
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.AcademicYearId : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.AcademicYearId = value;
           }
       }
       public int OldCourseId
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.OldCourseId : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.OldCourseId = value;
           }
       }
       public int NewCourseId
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.NewCourseId : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.NewCourseId = value;
           }
       }
       [Display(Name = "ApprovalStatus")]
       public bool ApprovalStatus
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ApprovalStatus : false;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.ApprovalStatus = value;
           }
       }
       public int NewSectionDetailsID
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.NewSectionDetailsID : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.NewSectionDetailsID = value;
           }
       }
       public int OldSectionDetailID
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.OldSectionDetailID : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.OldSectionDetailID = value;
           }
       }
       public int RequestSectionDetailID
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.RequestSectionDetailID : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.RequestSectionDetailID = value;
           }
       }

       public string CenterCode
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.CenterCode : string.Empty;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.CenterCode = value;
            }
        
       }
       public string CentreName
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.CentreName : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.CentreName = value;
           }

       }

     
       public string AdmittedCourse
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.AdmittedCourse : string.Empty;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.AdmittedCourse = value;
            }
        }
       public string NewCourse
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.NewCourse : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.NewCourse = value;
           }
       }

       public string OldSection
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.OldSection : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.OldSection = value;
           }
       }
       public string NewSection
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.NewSection : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.NewSection = value;
           }
       }
       public string University
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.University : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.University = value;
           }
       }

        

       public int UniversityID
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.UniversityID : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.UniversityID = value;
           }
       }
       public int RoleID
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.RoleID : new int();
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.RoleID = value;
           }
       }
       [Display(Name = "ApprovalDate")]
       public DateTime ApprovalDate
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ApprovalDate : DateTime.Now;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.ApprovalDate = value;
           }
       }

       public string ApplicationReason
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ApplicationReason : string.Empty;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.ApplicationReason = value;
            }
        }
       public string CancellationReason
       {
           get
           {
               return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.CancellationReason : string.Empty;
           }
           set
           {
               StudentChangeCourseRequestApplicationDTO.CancellationReason = value;
           }
       }

       [Display(Name = "ApplicationStatus")]
       public bool ApplicationStatus
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.ApplicationStatus : false;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.ApplicationStatus = value;
            }
        }
        

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.IsDeleted : false;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.CreatedBy > 0) ? StudentChangeCourseRequestApplicationDTO.CreatedBy : new int();
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null) ? StudentChangeCourseRequestApplicationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.ModifiedBy.HasValue) ? StudentChangeCourseRequestApplicationDTO.ModifiedBy : new int();
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.ModifiedDate.HasValue) ? StudentChangeCourseRequestApplicationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.DeletedBy.HasValue) ? StudentChangeCourseRequestApplicationDTO.DeletedBy : new int();
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentChangeCourseRequestApplicationDTO != null && StudentChangeCourseRequestApplicationDTO.DeletedDate.HasValue) ? StudentChangeCourseRequestApplicationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentChangeCourseRequestApplicationDTO.DeletedDate = value;
            }
        }
        public string SelectedCategoryID
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Threading.Tasks;
using AMS.DTO;

namespace AMS.ViewModel
{
    public class StudentSectionChangeRequestViewModel : IStudentSectionChangeRequestViewModel
    {
        public StudentSectionChangeRequestViewModel()
       {
           StudentSectionChangeRequestDTO = new StudentSectionChangeRequest();
           StudentMasterDTO = new StudentMaster();
       }

        public StudentSectionChangeRequest StudentSectionChangeRequestDTO { get; set; }
        public StudentMaster StudentMasterDTO { get; set; }
        public int ID
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.ID > 0) ? StudentSectionChangeRequestDTO.ID : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.ID = value;
            }
        }
        public int RequestSectionDetailId
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.RequestSectionDetailId > 0) ? StudentSectionChangeRequestDTO.RequestSectionDetailId : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.RequestSectionDetailId = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.SessionID > 0) ? StudentSectionChangeRequestDTO.SessionID : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.SessionID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.CentreCode : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.CentreCode = value;
            }
        }
        public int OldSectionDetailID
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.OldSectionDetailID > 0) ? StudentSectionChangeRequestDTO.OldSectionDetailID : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.OldSectionDetailID = value;
            }
        }
        public string StatusOfRequest
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.StatusOfRequest : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.StatusOfRequest = value;
            }
        }
        public int ApprovedEmployeeId
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.ApprovedEmployeeId > 0) ? StudentSectionChangeRequestDTO.ApprovedEmployeeId : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.ApprovedEmployeeId = value;
            }
        }
        public string ApprovedDate
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.ApprovedDate : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.ApprovedDate = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.IsActive : false;
            }
            set
            {
                StudentSectionChangeRequestDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.IsDeleted : false;
            }
            set
            {
                StudentSectionChangeRequestDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.CreatedBy > 0) ? StudentSectionChangeRequestDTO.CreatedBy : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StudentSectionChangeRequestDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.ModifiedBy > 0) ? StudentSectionChangeRequestDTO.ModifiedBy : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StudentSectionChangeRequestDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null && StudentSectionChangeRequestDTO.DeletedBy > 0) ? StudentSectionChangeRequestDTO.DeletedBy : new int();
            }
            set
            {
                StudentSectionChangeRequestDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StudentSectionChangeRequestDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        public string CentreName
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.CentreName : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.CentreName = value;
            }
        }

         [Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
        public string SessionName
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.SessionName : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.SessionName = value;
            }
        }

        public int StudentId { get; set; }
        [Display(Name = "DisplayName_StudentName", ResourceType = typeof(AMS.Common.Resources))]
        public string StudentName
        {
            get
            {
                return (StudentSectionChangeRequestDTO != null) ? StudentSectionChangeRequestDTO.StudentName : string.Empty;
            }
            set
            {
                StudentSectionChangeRequestDTO.StudentName = value;
            }
        }
        public int BranchId { get; set; }

        [Display(Name = "DisplayName_SectionDetailID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionDetailIDRequired")]
        public int SectionDetailID { get; set; }

        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string BranchDescription { get; set; }

        [Display(Name = "DisplayName_SectionDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string SectionDesc { get; set; }

         [Display(Name = "DisplayName_CourseYearDesc", ResourceType = typeof(AMS.Common.Resources))]
        public string CourseYearDesc { get; set; }

        [Display(Name = "DisplayName_AcademicYear", ResourceType = typeof(AMS.Common.Resources))]
        public string AcademicYear { get; set; }

           [Display(Name = "DisplayName_AdmissionNumber", ResourceType = typeof(AMS.Common.Resources))]
        public string AdmissionNumber { get; set; }
        public int CourseYearId { get; set; }

        public string StudentCode { get; set; }
    }
}

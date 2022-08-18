using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeExperienceViewModel
    {
        public EmployeeExperienceViewModel()
        {
            EmployeeExperienceDTO = new EmployeeExperience();
        }
        public EmployeeExperience EmployeeExperienceDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ID > 0) ? EmployeeExperienceDTO.ID : new int();
            }
            set
            {
                EmployeeExperienceDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.EmployeeID > 0) ? EmployeeExperienceDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeExperienceDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_ExperienceFromYear", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExperienceFromYearRequired")]
        //[Required(ErrorMessage = "Experience from year should be specified")]
        public string ExperienceFromYear
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.ExperienceFromYear : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.ExperienceFromYear = value;
            }
        }

        [Display(Name = "DisplayName_ExperienceToYear", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExperienceToYearRequired")]
        //   [Required(ErrorMessage = "Experience To Year should not be blank.")]
        public string ExperienceToYear
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.ExperienceToYear : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.ExperienceToYear = value;
            }
        }
        [Display(Name = "DisplayName_ExperienceInMonth", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 ExperienceInMonth
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ExperienceInMonth > 0) ? EmployeeExperienceDTO.ExperienceInMonth : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.ExperienceInMonth = value;
            }
        }

        [Display(Name = "DisplayName_PreviousOrganisationName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PreviousOrganisationNameRequired")]
        public string PreviousOrganisationName
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.PreviousOrganisationName : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.PreviousOrganisationName = value;
            }
        }

        [Display(Name = "DisplayName_PreviousOrganisationAddress", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PreviousOrganisationAddressRequired")]       
        public string PreviousOrganisationAddress
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.PreviousOrganisationAddress : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.PreviousOrganisationAddress = value;
            }
        }

        [Display(Name = "DisplayName_Designation", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DesignationRequired")]
        public string Designation
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.Designation : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.Designation = value;
            }
        }

        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RemarksRequired")]
        public string Remarks
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.Remarks = value;
            }
        }

        [Display(Name = "DisplayName_GeneralExperienceTypeMasterID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralExperienceTypeMasterIDRequired")]
        //  [Required(ErrorMessage = "General Experience Type1 must be selected")]
        public int GeneralExperienceTypeMasterID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralExperienceTypeMasterID > 0) ? EmployeeExperienceDTO.GeneralExperienceTypeMasterID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralExperienceTypeMasterID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralExperienceType", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralExperienceTypeRequired")]
        public string GeneralExperienceType
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralExperienceType : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralExperienceType = value;
            }
        }

        [Display(Name = "DisplayName_LastPayDrawnPayScale", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LastPayDrawnPayScaleRequired")]
        public string LastPayDrawnPayScale
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.LastPayDrawnPayScale : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.LastPayDrawnPayScale = value;
            }
        }

        [Display(Name = "DisplayName_NatureOfAppointment", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NatureOfAppointmentRequired")]
        public string NatureOfAppointment
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.NatureOfAppointment : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.NatureOfAppointment = value;
            }
        }

        [Display(Name = "DisplayName_GeneralJobStatusID", ResourceType = typeof(AMS.Common.Resources))]
        public int GeneralJobStatusID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralJobStatusID > 0) ? EmployeeExperienceDTO.GeneralJobStatusID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralJobStatusID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralJobStatus", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralJobStatusRequired")]
        public string GeneralJobStatus
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralJobStatus : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralJobStatus = value;
            }
        }

        [Display(Name = "DisplayName_AppointmentOrderNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AppointmentOrderNumberRequired")]
        public string AppointmentOrderNumber
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.AppointmentOrderNumber : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.AppointmentOrderNumber = value;
            }
        }

        [Display(Name = "DisplayName_AppointmentOrderDate", ResourceType = typeof(AMS.Common.Resources))]
        public string AppointmentOrderDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.AppointmentOrderDate : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.AppointmentOrderDate = value;
            }
        }

        [Display(Name = "DisplayName_UniversityApprovalNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalNumberRequired")]
        public string UniversityApprovalNumber
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalNumber = value;
            }
        }


        [Display(Name = "DisplayName_UniversityApprovalDate", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityApprovalDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalDate : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalDate = value;
            }
        }

        [Display(Name = "DisplayName_GeneralBoardUniversityID", ResourceType = typeof(AMS.Common.Resources))]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralBoardUniversityID > 0) ? EmployeeExperienceDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralBoardUniversityID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralBoardUniversityName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralBoardUniversityNameRequired")]
        public string GeneralBoardUniversityName
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralBoardUniversityName : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralBoardUniversityName = value;
            }
        }

        [Display(Name = "DisplayName_SubjectForApproval", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectForApprovalRequired")]
        public string SubjectForApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.SubjectForApproval : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.SubjectForApproval = value;
            }
        }

        [Display(Name = "DisplayName_UniversityApprovalType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalTypeRequired")]
        public string UniversityApprovalType
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalType : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalType = value;
            }
        }

        [Display(Name = "DisplayName_MonthOfApproval", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 MonthOfApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.MonthOfApproval > 0) ? EmployeeExperienceDTO.MonthOfApproval : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.MonthOfApproval = value;
            }
        }

        [Display(Name = "DisplayName_YearOfApproval", ResourceType = typeof(AMS.Common.Resources))]
        public Int16 YearOfApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.YearOfApproval > 0) ? EmployeeExperienceDTO.YearOfApproval : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.YearOfApproval = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.IsActive : false;
            }
            set
            {
                EmployeeExperienceDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.IsDeleted : false;
            }
            set
            {
                EmployeeExperienceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.CreatedBy > 0) ? EmployeeExperienceDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ModifiedBy.HasValue) ? EmployeeExperienceDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ModifiedDate.HasValue) ? EmployeeExperienceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.DeletedBy.HasValue) ? EmployeeExperienceDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.DeletedDate.HasValue) ? EmployeeExperienceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }



        public int ExperienceID { get; set; }
    }
}

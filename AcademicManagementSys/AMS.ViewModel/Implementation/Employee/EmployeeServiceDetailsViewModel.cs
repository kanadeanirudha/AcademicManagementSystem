using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeServiceDetailsViewModel
    {
        public EmployeeServiceDetailsViewModel()
        {
            EmployeeServiceDetailsDTO = new EmployeeServiceDetails();
        }

        public EmployeeServiceDetails EmployeeServiceDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ID > 0) ? EmployeeServiceDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.ID = value;
            }
        }

        public int CurrentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.CurrentID > 0) ? EmployeeServiceDetailsDTO.CurrentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.CurrentID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.EmployeeID > 0) ? EmployeeServiceDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeCode = value;
            }
        }

        public int SequenceNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.SequenceNumber > 0) ? EmployeeServiceDetailsDTO.SequenceNumber : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.SequenceNumber = value;
            }
        }

        [Display(Name = "DisplayName_OrderNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrderNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string OrderNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OrderNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OrderNumber = value;
            }
        }


        [Display(Name = "DisplayName_OrderDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrderDateRequired")]
        public string OrderDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OrderDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OrderDate = value;
            }
        }

        [Display(Name = "DisplayName_AcceptedByEmployee", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AcceptedByEmployeeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string AcceptedByEmployee
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.AcceptedByEmployee : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.AcceptedByEmployee = value;
            }
        }

        [Display(Name = "DisplayName_PromotionDemotionFlag", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PromotionDemotionFlagRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string PromotionDemotionFlag
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PromotionDemotionFlag : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PromotionDemotionFlag = value;
            }
        }

        [Display(Name = "DisplayName_PromotionDemotionDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PromotionDemotionDateRequired")]
        public string PromotionDemotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PromotionDemotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PromotionDemotionDate = value;
            }
        }

        [Display(Name = "DisplayName_PreviousPromotionDemotionDate", ResourceType = typeof(AMS.Common.Resources))]
        public string PreviousPromotionDemotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeDesignationMasterID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeDesignationMasterIDRequired")]
        public int EmployeeDesignationMasterID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.EmployeeDesignationMasterID > 0) ? EmployeeServiceDetailsDTO.EmployeeDesignationMasterID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeDesignationMasterID = value;
            }
        }

        public string EmployeeDesignation
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeDesignation : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeDesignation = value;
            }
        }

        [Display(Name = "DisplayName_DepartmentID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DepartmentIDRequired")]
        public int DepartmentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DepartmentID > 0) ? EmployeeServiceDetailsDTO.DepartmentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.DepartmentID = value;
            }
        }
        public string DepartmentName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.DepartmentName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.DepartmentName = value;
            }
        }

        [Display(Name = "DisplayName_ChargeTakingDate", ResourceType = typeof(AMS.Common.Resources))]
        public string ChargeTakingDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.ChargeTakingDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.ChargeTakingDate = value;
            }
        }

        [Display(Name = "DisplayName_OldDesignationID", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OldDesignationIDRequired")]
        public int OldDesignationID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.OldDesignationID > 0) ? EmployeeServiceDetailsDTO.OldDesignationID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDesignationID = value;
            }
        }

        public int OldDepartmentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.OldDepartmentID > 0) ? EmployeeServiceDetailsDTO.OldDepartmentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDepartmentID = value;
            }
        }

        [Display(Name = "DisplayName_OldDepartmentName", ResourceType = typeof(AMS.Common.Resources))]
        public string OldDepartmentName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OldDepartmentName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDepartmentName = value;
            }
        }

        [Display(Name = "DisplayName_CollegeApprovalDate", ResourceType = typeof(AMS.Common.Resources))]
        public string CollegeApprovalDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CollegeApprovalDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CollegeApprovalDate = value;
            }
        }

        [Display(Name = "DisplayName_UniversityApprovalDate", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityApprovalDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalDate = value;
            }
        }

        [Display(Name = "DisplayName_CollegeApprovalNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CollegeApprovalNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CollegeApprovalNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CollegeApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CollegeApprovalNumber = value;
            }
        }

        [Display(Name = "DisplayName_UniversityApprovalNumber", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string UniversityApprovalNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalNumber = value;
            }
        }

        [Display(Name = "DisplayName_NatureOfDuty", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NatureOfDutyRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string NatureOfDuty
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.NatureOfDuty : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.NatureOfDuty = value;
            }
        }

        [Display(Name = "DisplayName_BasicAmount", ResourceType = typeof(AMS.Common.Resources))]
        public decimal BasicAmount
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.BasicAmount > 0) ? EmployeeServiceDetailsDTO.BasicAmount : new decimal();
            }
            set
            {
                EmployeeServiceDetailsDTO.BasicAmount = value;
            }
        }

        //[Display(Name = "DisplayName_ApprovedBy", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApprovedByRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string ApprovedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.ApprovedBy : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.ApprovedBy = value;
            }
        }

        [Display(Name = "DisplayName_NewGrade", ResourceType = typeof(AMS.Common.Resources))]
        //  [Display(Name = "NewGrade")]
        public decimal NewGrade
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.NewGrade > 0) ? EmployeeServiceDetailsDTO.NewGrade : new decimal();
            }
            set
            {
                EmployeeServiceDetailsDTO.NewGrade = value;
            }
        }

        [Display(Name = "NewPayscaleID")]
        public int NewPayscaleID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.NewPayscaleID > 0) ? EmployeeServiceDetailsDTO.NewPayscaleID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.NewPayscaleID = value;
            }
        }

        [Display(Name = "DisplayName_NatureOfAppointment", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NatureOfAppointment")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string NatureOfAppointment
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.NatureOfAppointment : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.NatureOfAppointment = value;
            }
        }

        //[Display(Name = "DisplayName_UniversityApprovalType", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalTypeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string UniversityApprovalType
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalType : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalType = value;
            }
        }

        [Display(Name = "DisplayName_BoardUniversityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BoardUniversityID")]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.GeneralBoardUniversityID > 0) ? EmployeeServiceDetailsDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.GeneralBoardUniversityID = value;
            }
        }

        [Display(Name = "DisplayName_SubjectForApproval", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectForApprovalRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string SubjectForApproval
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.SubjectForApproval : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.SubjectForApproval = value;
            }
        }

        [Display(Name = "DisplayName_GrantedPromotionDate", ResourceType = typeof(AMS.Common.Resources))]
        public string GrantedPromotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.GrantedPromotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionDate = value;
            }
        }

        [Display(Name = "DisplayName_GrantedPromotionDesignationID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GrantedPromotionDesignationIDRequired")]
        public int GrantedPromotionDesignationID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.GrantedPromotionDesignationID > 0) ? EmployeeServiceDetailsDTO.GrantedPromotionDesignationID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionDesignationID = value;
            }
        }

        [Display(Name = "DisplayName_GrantedPromotionLevel", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GrantedPromotionLevelRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string GrantedPromotionLevel
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.GrantedPromotionLevel : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionLevel = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.CreatedBy > 0) ? EmployeeServiceDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ModifiedBy.HasValue) ? EmployeeServiceDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ModifiedDate.HasValue) ? EmployeeServiceDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DeletedBy.HasValue) ? EmployeeServiceDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DeletedDate.HasValue) ? EmployeeServiceDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_OldCentreCodeFlag", ResourceType = typeof(AMS.Common.Resources))]
        public string OldCentreCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OldCentreCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OldCentreCode = value;
            }
        }
        [Display(Name = "DisplayName_IsCurrentFlag", ResourceType = typeof(AMS.Common.Resources))]
        // [Display(Name = "DisplayName_IsCurrentFlag")]
        public bool IsCurrentFlag
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsCurrentFlag : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsCurrentFlag = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        public string CentreName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CentreName = value;
            }
        }
    }
}

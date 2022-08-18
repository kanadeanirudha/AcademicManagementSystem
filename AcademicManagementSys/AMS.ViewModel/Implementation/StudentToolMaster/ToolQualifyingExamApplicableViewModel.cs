using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualifyingExamApplicableBaseViewModel : IToolQualifyingExamApplicableBaseViewModel
    {
        public ToolQualifyingExamApplicableBaseViewModel()
        {
            ToolQualifyingExamApplicableDTO = new ToolQualifyingExamApplicable();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public ToolQualifyingExamApplicable ToolQualifyingExamApplicableDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string SelectedUniversityID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }
        public int ID
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.ID > 0) ? ToolQualifyingExamApplicableDTO.ID : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.ID = value;
            }
        }

        public int QualifyingExamMstID
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.QualifyingExamMstID : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.QualifyingExamMstID = value;
            }
        }
        [Display(Name = "DisplayName_QualifyingExamName", ResourceType = typeof(AMS.Common.Resources))]
        public string QualifyingExamName
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.QualifyingExamName : string.Empty;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.QualifyingExamName = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.BranchDescription : string.Empty;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.BranchDescription = value;
            }
        }
        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BranchDescriptionRequired")]
        public int BranchDetailID
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.BranchDetailID > 0) ? ToolQualifyingExamApplicableDTO.BranchDetailID : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.BranchDetailID = value;
            }
        }

        [Display(Name = "DisplayName_StandardNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardNumberRequired")]
        public int StandardNumber
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.StandardNumber : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.StandardNumber = value;
            }
        }


        public bool IsActive
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.IsActive : false;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.IsDeleted : false;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.CreatedBy > 0) ? ToolQualifyingExamApplicableDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.ModifiedBy.HasValue) ? ToolQualifyingExamApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.ModifiedDate.HasValue) ? ToolQualifyingExamApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.DeletedBy.HasValue) ? ToolQualifyingExamApplicableDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualifyingExamApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null && ToolQualifyingExamApplicableDTO.DeletedDate.HasValue) ? ToolQualifyingExamApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.DeletedDate = value;
            }
        }


        public bool StatusFlag
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.StatusFlag : false;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.StatusFlag = value;
            }
        }
        [Display(Name = "DisplayName_CenterName", ResourceType = typeof(AMS.Common.Resources))]
        public string CenterName
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.CenterName : string.Empty;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.CenterName = value;
            }
        }
        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityName
        {
            get
            {
                return (ToolQualifyingExamApplicableDTO != null) ? ToolQualifyingExamApplicableDTO.UniversityName : string.Empty;
            }
            set
            {
                ToolQualifyingExamApplicableDTO.UniversityName = value;
            }
        }
        public string SelectedCategoryID
        {
            get;
            set;
        }

        public string CentreCodeWithName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string UniversityIDWithName
        {
            get;
            set;
        }
    }
}


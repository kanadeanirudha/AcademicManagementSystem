using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualificationApplicableBaseViewModel : IToolQualificationApplicableBaseViewModel
    {
        public ToolQualificationApplicableBaseViewModel()
        {
            ToolQualificationApplicableDTO = new ToolQualificationApplicable();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public ToolQualificationApplicable ToolQualificationApplicableDTO
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
        //public string BranchDescription
        //{
        //    get;
        //    set;
        //}
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
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.ID > 0) ? ToolQualificationApplicableDTO.ID : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.ID = value;
            }
        }

        public int QualificationExamMstID
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.QualificationExamMstID : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.QualificationExamMstID = value;
            }
        }
         [Display(Name = "DisplayName_QualificationExamName", ResourceType = typeof(AMS.Common.Resources))]
        public string QualificationExamName
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.QualificationExamName : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.QualificationExamName = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.BranchDescription : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.BranchDescription = value;
            }
        }
       
       
        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BranchDescriptionRequired")]
        public int BranchDetailID
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.BranchDetailID > 0) ? ToolQualificationApplicableDTO.BranchDetailID : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.BranchDetailID = value;
            }
        }

       [Display(Name = "DisplayName_StandardNumber", ResourceType = typeof(AMS.Common.Resources))]
       [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardNumberRequired")]
        public int StandardNumber
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.StandardNumber : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.StandardNumber = value;
            }
        }
        [Display(Name = "From Date")]
        [Required(ErrorMessage = "Please select From Date.")]
        public string FromDate
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.FromDate : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.FromDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.IsActive : false;
            }
            set
            {
                ToolQualificationApplicableDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.IsDeleted : false;
            }
            set
            {
                ToolQualificationApplicableDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.CreatedBy > 0) ? ToolQualificationApplicableDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.ModifiedBy.HasValue) ? ToolQualificationApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.ModifiedDate.HasValue) ? ToolQualificationApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.DeletedBy.HasValue) ? ToolQualificationApplicableDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualificationApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualificationApplicableDTO != null && ToolQualificationApplicableDTO.DeletedDate.HasValue) ? ToolQualificationApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationApplicableDTO.DeletedDate = value;
            }
        }


        public bool StatusFlag
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.StatusFlag : false;
            }
            set
            {
                ToolQualificationApplicableDTO.StatusFlag = value;
            }
        }
        [Display(Name = "DisplayName_CenterName", ResourceType = typeof(AMS.Common.Resources))]
        public string CenterName
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.CenterName : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.CenterName = value;
            }
        }
        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityName
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.UniversityName : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.UniversityName = value;
            }
        }
        public string StandardDescription
        {
            get
            {
                return (ToolQualificationApplicableDTO != null) ? ToolQualificationApplicableDTO.StandardDescription : string.Empty;
            }
            set
            {
                ToolQualificationApplicableDTO.StandardDescription = value;
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


using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{

    public class ToolTemplateApplicableViewModel : IToolTemplateApplicableViewModel
    {

        public ToolTemplateApplicableViewModel()
        {
            ToolTemplateApplicableDTO = new ToolTemplateApplicable();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public ToolTemplateApplicable ToolTemplateApplicableDTO { get; set; }
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
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.ID > 0) ? ToolTemplateApplicableDTO.ID : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.ID = value;
            }
        }

        public int TemplateID
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.TemplateID : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.TemplateID = value;
            }
        }
        [Display(Name = "DisplayName_TemplateName", ResourceType = typeof(AMS.Common.Resources))]
        public string TemplateName
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.TemplateName : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.TemplateName = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.BranchDescription : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.BranchDescription = value;
            }
        }
        [Display(Name = "DisplayName_BranchDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BranchDescriptionRequired")]
        public int BranchDetailID
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.BranchDetailID > 0) ? ToolTemplateApplicableDTO.BranchDetailID : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.BranchDetailID = value;
            }
        }

        [Display(Name = "DisplayName_StandardNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardNumberRequired")]
        public int StandardNumber
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.StandardNumber : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.StandardNumber = value;
            }
        }
        [Display(Name = "DisplayName_CentreWiseSession", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreWiseSessionRequired")]
        public int CentreWiseSessionID
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.CentreWiseSessionID : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.CentreWiseSessionID = value;
            }
        }
        [Display(Name = "DisplayName_FromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FromDateRequired")]
        //[Display(Name = "From Date")]
        //[Required(ErrorMessage = "Please select From Date.")]
        public string FromDate
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.FromDate : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.FromDate = value;
            }
        }

        [Display(Name=" To Date")]
        public String ToDate
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.ToDate : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.ToDate = value;
            }
        }
         [Display(Name = "DisplayName_IsApplicableForEntranceExam", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsApplicableForEntranceExam
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.IsApplicableForEntranceExam : false;
            }
            set
            {
                ToolTemplateApplicableDTO.IsApplicableForEntranceExam = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.IsActive : false;
            }
            set
            {
                ToolTemplateApplicableDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.IsDeleted : false;
            }
            set
            {
                ToolTemplateApplicableDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.CreatedBy > 0) ? ToolTemplateApplicableDTO.CreatedBy : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateApplicableDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.ModifiedBy.HasValue) ? ToolTemplateApplicableDTO.ModifiedBy : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.ModifiedDate.HasValue) ? ToolTemplateApplicableDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateApplicableDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.DeletedBy.HasValue) ? ToolTemplateApplicableDTO.DeletedBy : new int();
            }
            set
            {
                ToolTemplateApplicableDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolTemplateApplicableDTO != null && ToolTemplateApplicableDTO.DeletedDate.HasValue) ? ToolTemplateApplicableDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateApplicableDTO.DeletedDate = value;
            }
        }


        public bool StatusFlag
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.StatusFlag : false;
            }
            set
            {
                ToolTemplateApplicableDTO.StatusFlag = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        public string CenterName
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.CenterName : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.CenterName = value;
            }
        }
        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityName
        {
            get
            {
                return (ToolTemplateApplicableDTO != null) ? ToolTemplateApplicableDTO.UniversityName : string.Empty;
            }
            set
            {
                ToolTemplateApplicableDTO.UniversityName = value;
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

        public string UniversityIDWithName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

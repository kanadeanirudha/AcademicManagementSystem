using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel.Implementation.Employee
{
    public class GeneralExperienceTypeMasterViewModel
    {

        public GeneralExperienceTypeMasterViewModel()
        {
            GeneralExperienceTypeMasterDTO = new GeneralExperienceTypeMaster();
        }

        public GeneralExperienceTypeMaster GeneralExperienceTypeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.ID > 0) ? GeneralExperienceTypeMasterDTO.ID : new int();
            }
            set
            {
                GeneralExperienceTypeMasterDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_ExperienceTypeDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExperienceTypeDescriptionRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string ExperienceTypeDescription
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null) ? GeneralExperienceTypeMasterDTO.ExperienceTypeDescription : string.Empty;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.ExperienceTypeDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null) ? GeneralExperienceTypeMasterDTO.IsActive : false;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null) ? GeneralExperienceTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.CreatedBy > 0) ? GeneralExperienceTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralExperienceTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null) ? GeneralExperienceTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.ModifiedBy.HasValue) ? GeneralExperienceTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralExperienceTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.ModifiedDate.HasValue) ? GeneralExperienceTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.DeletedBy.HasValue) ? GeneralExperienceTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralExperienceTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralExperienceTypeMasterDTO != null && GeneralExperienceTypeMasterDTO.DeletedDate.HasValue) ? GeneralExperienceTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralExperienceTypeMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

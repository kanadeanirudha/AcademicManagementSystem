using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel.Implementation.Employee
{
    public class GeneralJobProfileViewModel
    {

        public GeneralJobProfileViewModel()
        {
            GeneralJobProfileDTO = new GeneralJobProfile();
        }

        public GeneralJobProfile GeneralJobProfileDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ID > 0) ? GeneralJobProfileDTO.ID : new int();
            }
            set
            {
                GeneralJobProfileDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_JobProfileDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobProfileDescriptionRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string JobProfileDescription
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                GeneralJobProfileDTO.JobProfileDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.IsActive : false;
            }
            set
            {
                GeneralJobProfileDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.IsDeleted : false;
            }
            set
            {
                GeneralJobProfileDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.CreatedBy > 0) ? GeneralJobProfileDTO.CreatedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null) ? GeneralJobProfileDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ModifiedBy.HasValue) ? GeneralJobProfileDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.ModifiedDate.HasValue) ? GeneralJobProfileDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.DeletedBy.HasValue) ? GeneralJobProfileDTO.DeletedBy : new int();
            }
            set
            {
                GeneralJobProfileDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralJobProfileDTO != null && GeneralJobProfileDTO.DeletedDate.HasValue) ? GeneralJobProfileDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralJobProfileDTO.DeletedDate = value;
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

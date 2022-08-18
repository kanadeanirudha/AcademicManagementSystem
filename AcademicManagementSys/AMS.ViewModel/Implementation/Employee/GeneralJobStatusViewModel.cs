using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralJobStatusViewModel : IGeneralJobStatusViewModel
    {

        public GeneralJobStatusViewModel()
        {
            GeneralJobStatusDTO = new GeneralJobStatus();
        }

        public GeneralJobStatus GeneralJobStatusDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.ID > 0) ? GeneralJobStatusDTO.ID : new int();
            }
            set
            {
                GeneralJobStatusDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_JobStatusDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusDescriptionRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string JobStatusDescription
        {
            get
            {
                return (GeneralJobStatusDTO != null) ? GeneralJobStatusDTO.JobStatusDescription : string.Empty;
            }
            set
            {
                GeneralJobStatusDTO.JobStatusDescription = value;
            }
        }

        [Display(Name = "DisplayName_JobStatusCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JobStatusCodeRequired")]
        public string JobStatusCode
        {
            get
            {
                return (GeneralJobStatusDTO != null) ? GeneralJobStatusDTO.JobStatusCode : string.Empty;
            }
            set
            {
                GeneralJobStatusDTO.JobStatusCode = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (GeneralJobStatusDTO != null) ? GeneralJobStatusDTO.IsActive : false;
            }
            set
            {
                GeneralJobStatusDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralJobStatusDTO != null) ? GeneralJobStatusDTO.IsDeleted : false;
            }
            set
            {
                GeneralJobStatusDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.CreatedBy > 0) ? GeneralJobStatusDTO.CreatedBy : new int();
            }
            set
            {
                GeneralJobStatusDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralJobStatusDTO != null) ? GeneralJobStatusDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralJobStatusDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.ModifiedBy.HasValue) ? GeneralJobStatusDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralJobStatusDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.ModifiedDate.HasValue) ? GeneralJobStatusDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralJobStatusDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.DeletedBy.HasValue) ? GeneralJobStatusDTO.DeletedBy : new int();
            }
            set
            {
                GeneralJobStatusDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralJobStatusDTO != null && GeneralJobStatusDTO.DeletedDate.HasValue) ? GeneralJobStatusDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralJobStatusDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}



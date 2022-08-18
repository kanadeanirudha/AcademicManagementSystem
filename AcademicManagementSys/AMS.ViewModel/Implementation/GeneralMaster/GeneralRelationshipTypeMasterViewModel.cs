using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralRelationshipTypeMasterViewModel : IGeneralRelationshipTypeMasterViewModel
    {

        public GeneralRelationshipTypeMasterViewModel()
        {


            GeneralRelationshipTypeMasterDTO = new GeneralRelationshipTypeMaster();
        }

        public GeneralRelationshipTypeMaster GeneralRelationshipTypeMasterDTO
        {
            get;
            set;
        }

        public List<GeneralRelationshipTypeMaster> ListGeneralRelationshipTypeMaster
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.ID > 0) ? GeneralRelationshipTypeMasterDTO.ID : new int();
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_Description", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DescriptionRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string Description
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null) ? GeneralRelationshipTypeMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.Description = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null) ? GeneralRelationshipTypeMasterDTO.IsActive : false;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null) ? GeneralRelationshipTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.CreatedBy > 0) ? GeneralRelationshipTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null) ? GeneralRelationshipTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.ModifiedBy.HasValue) ? GeneralRelationshipTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.ModifiedDate.HasValue) ? GeneralRelationshipTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.DeletedBy.HasValue) ? GeneralRelationshipTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralRelationshipTypeMasterDTO != null && GeneralRelationshipTypeMasterDTO.DeletedDate.HasValue) ? GeneralRelationshipTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralRelationshipTypeMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

    }
}

using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualificationExamMasterBaseViewModel : IToolQualificationExamMasterBaseViewModel
    {
        public ToolQualificationExamMasterBaseViewModel()
        {

        }

        public ToolQualificationExamMaster ToolQualificationExamMasterDTO
        {
            get;
            set;
        }



    }
    public class ToolQualificationExamMasterViewModel : IToolQualificationExamMasterViewModel
    {

        public ToolQualificationExamMasterViewModel()
        {
            ToolQualificationExamMasterDTO = new ToolQualificationExamMaster();
        }

        public ToolQualificationExamMaster ToolQualificationExamMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.ID > 0) ? ToolQualificationExamMasterDTO.ID : new int();
            }
            set
            {
                ToolQualificationExamMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_QualificationName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_QualificationNameRequired")]
        public string QualificationName
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null) ? ToolQualificationExamMasterDTO.QualificationName : string.Empty;
            }
            set
            {
                ToolQualificationExamMasterDTO.QualificationName = value;
            }
        }
        [Display(Name = "DisplayName_EducationType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EducationTypeRequired")]
        public string EducationType
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null) ? ToolQualificationExamMasterDTO.EducationType : string.Empty;
            }
            set
            {
                ToolQualificationExamMasterDTO.EducationType = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null) ? ToolQualificationExamMasterDTO.IsDeleted : false;
            }
            set
            {
                ToolQualificationExamMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.CreatedBy > 0) ? ToolQualificationExamMasterDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualificationExamMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null) ? ToolQualificationExamMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationExamMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.ModifiedBy.HasValue) ? ToolQualificationExamMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualificationExamMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.ModifiedDate.HasValue) ? ToolQualificationExamMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationExamMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.DeletedBy.HasValue) ? ToolQualificationExamMasterDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualificationExamMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualificationExamMasterDTO != null && ToolQualificationExamMasterDTO.DeletedDate.HasValue) ? ToolQualificationExamMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualificationExamMasterDTO.DeletedDate = value;
            }
        }



    }
}

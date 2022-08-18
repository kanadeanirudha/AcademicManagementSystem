using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolQualifyingExamMasterBaseViewModel : IToolQualifyingExamMasterBaseViewModel
    {
        public ToolQualifyingExamMasterBaseViewModel()
        {
           
        }

        public ToolQualifyingExamMaster ToolQualifyingExamMasterDTO
        {
            get;
            set;
        }
       


    }
    public class ToolQualifyingExamMasterViewModel : IToolQualifyingExamMasterViewModel
    {

        public ToolQualifyingExamMasterViewModel()
        {
            ToolQualifyingExamMasterDTO = new ToolQualifyingExamMaster();
        }

        public ToolQualifyingExamMaster ToolQualifyingExamMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.ID > 0) ? ToolQualifyingExamMasterDTO.ID : new int();
            }
            set
            {
                ToolQualifyingExamMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_ExamName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExamNameRequired")]
        public string ExamName
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null) ? ToolQualifyingExamMasterDTO.ExamName : string.Empty;
            }
            set
            {
                ToolQualifyingExamMasterDTO.ExamName = value;
            }
        }
      
      
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null) ? ToolQualifyingExamMasterDTO.IsDeleted : false;
            }
            set
            {
                ToolQualifyingExamMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.CreatedBy > 0) ? ToolQualifyingExamMasterDTO.CreatedBy : new int();
            }
            set
            {
                ToolQualifyingExamMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null) ? ToolQualifyingExamMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.ModifiedBy.HasValue) ? ToolQualifyingExamMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ToolQualifyingExamMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.ModifiedDate.HasValue) ? ToolQualifyingExamMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.DeletedBy.HasValue) ? ToolQualifyingExamMasterDTO.DeletedBy : new int();
            }
            set
            {
                ToolQualifyingExamMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolQualifyingExamMasterDTO != null && ToolQualifyingExamMasterDTO.DeletedDate.HasValue) ? ToolQualifyingExamMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolQualifyingExamMasterDTO.DeletedDate = value;
            }
        }



    }
}

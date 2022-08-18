using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralLeaveDocumentViewModel : IGeneralLeaveDocumentViewModel
    {

        public GeneralLeaveDocumentViewModel()
        {
            GeneralLeaveDocumentDTO = new GeneralLeaveDocument();
        }

        public GeneralLeaveDocument GeneralLeaveDocumentDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.ID > 0) ? GeneralLeaveDocumentDTO.ID : new int();
            }
            set
            {
                GeneralLeaveDocumentDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_DocumentID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DocumentIDRequired")]
        public string DocumentName
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.DocumentName : string.Empty;
            }
            set
            {
                GeneralLeaveDocumentDTO.DocumentName = value;
            }
        }

        [Display(Name = "DisplayName_DocumentType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DocumentTypeRequired")]
        public string DocumentType
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.DocumentType : string.Empty;
            }
            set
            {
                GeneralLeaveDocumentDTO.DocumentType = value;
            }
        }

        
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DocumentDescriptionRequired")]
        [Display(Name = "DisplayName_DocumentDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string DocumentDescription
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.DocumentDescription : string.Empty;
            }
            set
            {
                GeneralLeaveDocumentDTO.DocumentDescription = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.IsActive : false;
            }
            set
            {
                GeneralLeaveDocumentDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.IsDeleted : false;
            }
            set
            {
                GeneralLeaveDocumentDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.CreatedBy > 0) ? GeneralLeaveDocumentDTO.CreatedBy : new int();
            }
            set
            {
                GeneralLeaveDocumentDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null) ? GeneralLeaveDocumentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralLeaveDocumentDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.ModifiedBy.HasValue) ? GeneralLeaveDocumentDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralLeaveDocumentDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.ModifiedDate.HasValue) ? GeneralLeaveDocumentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralLeaveDocumentDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.DeletedBy.HasValue) ? GeneralLeaveDocumentDTO.DeletedBy : new int();
            }
            set
            {
                GeneralLeaveDocumentDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralLeaveDocumentDTO != null && GeneralLeaveDocumentDTO.DeletedDate.HasValue) ? GeneralLeaveDocumentDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralLeaveDocumentDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

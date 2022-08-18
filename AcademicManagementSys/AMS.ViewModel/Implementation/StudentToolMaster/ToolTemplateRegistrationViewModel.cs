using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class ToolTemplateRegistrationBaseViewModel : IToolTemplateRegistrationBaseViewModel
    {

      

    }
    public class ToolTemplateRegistrationViewModel : IToolTemplateRegistrationViewModel
    {

       public ToolTemplateRegistrationViewModel()
        {
            ToolTemplateRegistrationDTO = new ToolTemplateRegistration();
        }

        public ToolTemplateRegistration ToolTemplateRegistrationDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.ID > 0) ? ToolTemplateRegistrationDTO.ID : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.ID = value;
            }
        }
        public string Title
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Title : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Title = value;
            }
        }
        public int ParentID
        {
            get
            {
                return ToolTemplateRegistrationDTO != null ? ToolTemplateRegistrationDTO.ParentID : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.ParentID = value;
            }
        }
        public int NumberOfColumn
        {
            get
            {
                return ToolTemplateRegistrationDTO != null ? ToolTemplateRegistrationDTO.NumberOfColumn : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.NumberOfColumn = value;
            }
        }
        public int SequenceNo
        {
            get
            {
                return ToolTemplateRegistrationDTO != null ? ToolTemplateRegistrationDTO.SequenceNo : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.SequenceNo = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.IsDeleted : false;
            }
            set
            {
                ToolTemplateRegistrationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.CreatedBy > 0) ? ToolTemplateRegistrationDTO.CreatedBy : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateRegistrationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.ModifiedBy.HasValue) ? ToolTemplateRegistrationDTO.ModifiedBy : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.ModifiedDate.HasValue) ? ToolTemplateRegistrationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateRegistrationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.DeletedBy.HasValue) ? ToolTemplateRegistrationDTO.DeletedBy : new int();
            }
            set
            {
                ToolTemplateRegistrationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null && ToolTemplateRegistrationDTO.DeletedDate.HasValue) ? ToolTemplateRegistrationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ToolTemplateRegistrationDTO.DeletedDate = value;
            }
        }

        public IEnumerable<SelectListItem> ToolRegistrationFieldMasterListItems
        {
            get
            {
                return new SelectList(ToolRegistrationFieldMasterList, "ID", "TypeName");
            }
        }

        public List<ToolTemplateRegistration> ToolRegistrationFieldMasterList
        {
            get;
            set;
        }

        public string Data1
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data1 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data1 = value;
            }
        }
        public string Data2
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data2 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data2 = value;
            }
        }
        public string Data3
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data3 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data3 = value;
            }
        }
        public string Data4
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data4 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data4 = value;
            }
        }
        public string Data5
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data5 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data5 = value;
            }
        }
        public string Data6
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data6 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data6 = value;
            }
        }
        public string Data7
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data7 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data7 = value;
            }
        }
        public string Data8
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data8 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data8 = value;
            }
        }
        public string Data9
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data9 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data9 = value;
            }
        }
        public string Data10
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.Data10 : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.Data10 = value;
            }
        }
        public string TemplateName
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.TemplateName : string.Empty;
            }
            set
            {
                ToolTemplateRegistrationDTO.TemplateName = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (ToolTemplateRegistrationDTO != null) ? ToolTemplateRegistrationDTO.IsActive : false;
            }
            set
            {
                ToolTemplateRegistrationDTO.IsActive = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralTaxMasterViewModel : IGeneralTaxMasterViewModel
    {

        public GeneralTaxMasterViewModel()
        {
            GeneralTaxMasterDTO = new GeneralTaxMaster();
          // GetGeneralTaxMasterList = new List<GeneralTaxMaster>();
        }

        public GeneralTaxMaster GeneralTaxMasterDTO
        {
            get;
            set;
        }
        //public List<GeneralTaxMaster> GetGeneralTaxMasterList { get; set; }
        ////public IEnumerable<SelectListItem> ListGeneralTaxMasterItems
        ////{
        ////    get
        ////    {
        ////        return new SelectList(GetGeneralTaxMasterList, "ID", "TaxName");
        ////    }
        ////}

        public int ID
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.ID > 0) ? GeneralTaxMasterDTO.ID : new int();
            }
            set
            {
                GeneralTaxMasterDTO.ID = value;
            }
        }
        public string SelectedTaxMasterID
        {
            get;
            set;
        }
       
        [Display(Name = "DisplayName_TaxName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TaxNameRequired")]
        //[Required(ErrorMessage = "Tax name should not be blank.")]
        //[Display(Name = "Tax Name")]
        public string TaxName
        {
            get
            {
                return (GeneralTaxMasterDTO != null) ? GeneralTaxMasterDTO.TaxName : string.Empty;
            }
            set
            {
                GeneralTaxMasterDTO.TaxName = value;
            }
        }

        [Display(Name = "DisplayName_TaxRate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TaxRateRequired")]
       // [Required(ErrorMessage = "Tax Rate should not be blank.")]
        //[Display(Name = "Tax Rate")]
        
        public decimal TaxRate
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.TaxRate > 0) ? GeneralTaxMasterDTO.TaxRate : new decimal();
            }
            set
            {
                GeneralTaxMasterDTO.TaxRate = value;
            }
        }

        [Display(Name = "DisplayName_IsCompoundTax", ResourceType = typeof(Resources))]
        public bool IsCompoundTax
        {
            get
            {
                return (GeneralTaxMasterDTO != null) ? GeneralTaxMasterDTO.IsCompoundTax : false;
            }
            set
            {
                GeneralTaxMasterDTO.IsCompoundTax = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralTaxMasterDTO != null) ? GeneralTaxMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralTaxMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.CreatedBy > 0) ? GeneralTaxMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTaxMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralTaxMasterDTO != null) ? GeneralTaxMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.ModifiedBy.HasValue) ? GeneralTaxMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTaxMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.ModifiedDate.HasValue) ? GeneralTaxMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.DeletedBy.HasValue) ? GeneralTaxMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTaxMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTaxMasterDTO != null && GeneralTaxMasterDTO.DeletedDate.HasValue) ? GeneralTaxMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTaxMasterDTO.DeletedDate = value;
            }
        }

       
        public string errorMessage { get; set; }
    }
}


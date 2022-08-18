using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AMS.ViewModel
{
    public class CRMSaleAccountProgressTypeMasterAndRuleViewModel : ICRMSaleAccountProgressTypeMasterAndRuleViewModel
    {

        public CRMSaleAccountProgressTypeMasterAndRuleViewModel()
        {
            CRMSaleAccountProgressTypeMasterAndRuleDTO = new CRMSaleAccountProgressTypeMasterAndRule();
        }
        //CRMSaleAccountProgressType
        public CRMSaleAccountProgressTypeMasterAndRule CRMSaleAccountProgressTypeMasterAndRuleDTO
        {
            get;
            set;
        }
        public Int16 CRMSaleAccountProgressTypeID
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeID : new Int16();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeID = value;
            }
        }
    
        [Display(Name = "Progress Type")]
        [Required(ErrorMessage = "Progress type should not be blank")]
        public string ProgressType
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.ProgressType : String.Empty;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ProgressType = value;
            }
        }
        public string ColourGuide
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.ColourGuide : String.Empty;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ColourGuide = value;
            }
        }
      

        //CRMSaleAccountProgressTypeRule
        public Int16 CRMSaleAccountProgressTypeRuleID
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeRuleID : new Int16();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.CRMSaleAccountProgressTypeRuleID = value;
            }
        }

        public Int16 Days
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.Days : new Int16();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.Days = value;
            }
        }

        [Display(Name = "From Date")]
        [Required(ErrorMessage = "From Date should not be blank")]
        public string FromDate
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.FromDate : String.Empty;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.FromDate = value;
            }
        }


        [Display(Name = "Operator")]
        [Required(ErrorMessage = "Please select Employee")]
        public string Operator
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.Operator : String.Empty;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.Operator = value;
            }
        }
      
        public string UptoDate
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.UptoDate : String.Empty;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.UptoDate = value;
            }
        }
        public bool IsCurrent
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.IsCurrent : false;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.IsCurrent = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.IsDeleted : false;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null && CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedBy > 0) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedBy : new int();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null && CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedBy.HasValue) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedBy : new int();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null && CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedDate.HasValue) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.DeletedBy : new int();
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CRMSaleAccountProgressTypeMasterAndRuleDTO != null) ? CRMSaleAccountProgressTypeMasterAndRuleDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CRMSaleAccountProgressTypeMasterAndRuleDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }




    }
}


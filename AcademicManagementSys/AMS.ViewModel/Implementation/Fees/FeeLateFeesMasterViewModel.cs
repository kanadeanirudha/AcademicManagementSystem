using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeLateFeesMasterViewModel : IFeeLateFeesMasterViewModel
    {
        public FeeLateFeesMasterViewModel()
        {
            FeeLateFeesMasterDTO = new FeeLateFeesMaster();
            FeeSubTypeList = new List<FeeTypeAndSubType>();
            PeriodList = new List<FeeLateFeesMaster>();
        }
        public List<FeeLateFeesMaster> PeriodList { get; set; }
        public List<FeeTypeAndSubType> FeeSubTypeList { get; set; }
        public IEnumerable<SelectListItem> FeeSubTypeListItems
        {
            get
            {
                return new SelectList(FeeSubTypeList, "FeeSubTypeID", "FeeSubTypeDesc");
            }
        }
        public IEnumerable<SelectListItem> PeriodListItem { get { return new SelectList(PeriodList, "PeriodTypeID", "PeriodType"); } }
        public FeeLateFeesMaster FeeLateFeesMasterDTO { get; set; }
        //-----------------------Properties of FeeLateFeesMaster  table----------------------------------
        public int ID
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.ID > 0) ? FeeLateFeesMasterDTO.ID : new int();
            }
            set
            {
                FeeLateFeesMasterDTO.ID = value;
            }
        }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description should not be blank")]
        public string LateFeeDescription
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.LateFeeDescription : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeDescription = value;
            }
        }
        [Display(Name = "Late Fee Type")]
        [Required(ErrorMessage = "Late Fee Type must be selected")]
        public string LateFeeType
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.LateFeeType : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeType = value;
            }
        }
        [Display(Name = "Fixed/Slab Flag")]
        [Required(ErrorMessage = "Fixed/Slab Flag must be selected")]
        public string SlabFixedFlag
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.SlabFixedFlag : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.SlabFixedFlag = value;
            }
        }
        [Display(Name = "Late Fee Amount")]
        [Required(ErrorMessage = "Late Fee Amount should not be blank")]
        public decimal LateFeeAmount
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.LateFeeAmount > 0) ? FeeLateFeesMasterDTO.LateFeeAmount : new decimal();
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeAmount = value;
            }
        }
            [Display(Name = "Late Fee Amount")]
        public decimal LateFeeAmountForSlab
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.LateFeeAmountForSlab > 0) ? FeeLateFeesMasterDTO.LateFeeAmountForSlab : new decimal();
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeAmountForSlab = value;
            }
        }
        [Display(Name = "Period Type")]
        public int PeriodTypeID
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.PeriodTypeID > 0) ? FeeLateFeesMasterDTO.PeriodTypeID : new int();
            }
            set
            {
                FeeLateFeesMasterDTO.PeriodTypeID = value;
            }
        }
        [Display(Name = "Period Type")]
        public string PeriodType
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.PeriodType : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.PeriodType = value;
            }
        }
        [Display(Name = "Period Type")]
        public string PeriodTypeForSlab
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.PeriodTypeForSlab : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.PeriodTypeForSlab = value;
            }
        }
        public int FeeSubTypeID
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.FeeSubTypeID > 0) ? FeeLateFeesMasterDTO.FeeSubTypeID : new int();
            }
            set
            {
                FeeLateFeesMasterDTO.FeeSubTypeID = value;
            }
        }
                [Display(Name = "Fee Sub Type")]
         [Required(ErrorMessage = "Fee Sub Type should not be blank")]
        public string FeeSubType
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.FeeSubType : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.FeeSubType = value;
            }
        }
        [Display(Name = "Is Incremental ?")]
        public bool IsIncremental
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.IsIncremental : false;
            }
            set
            {
                FeeLateFeesMasterDTO.IsIncremental = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.IsActive : false;
            }
            set
            {
                FeeLateFeesMasterDTO.IsActive = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.CreatedBy > 0) ? FeeLateFeesMasterDTO.CreatedBy : new short();
            }
            set
            {
                FeeLateFeesMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeLateFeesMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.ModifiedBy > 0) ? FeeLateFeesMasterDTO.ModifiedBy : new short();
            }
            set
            {
                FeeLateFeesMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeLateFeesMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.DeletedBy > 0) ? FeeLateFeesMasterDTO.DeletedBy : new short();
            }
            set
            {
                FeeLateFeesMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeLateFeesMasterDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.IsDeleted : false;
            }
            set
            {
                FeeLateFeesMasterDTO.IsDeleted = value;
            }
        }

        //-------------------------Properties of FeeLateFeeSlabDetails  table---------------------------
        public int LateFeesMasterID
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.LateFeesMasterID > 0) ? FeeLateFeesMasterDTO.LateFeesMasterID : new int();
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeesMasterID = value;
            }
        }
        [Display(Name = "From")]
        public string LateFeeSlabFrom
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.LateFeeSlabFrom : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeSlabFrom = value;
            }
        }
        [Display(Name = "UpTo")]
        public string LateFeeSlabTo
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.LateFeeSlabTo : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeSlabTo = value;
            }
        }
        [Display(Name = "Late Fee Value")]
        public decimal LateFeeValue
        {
            get
            {
                return (FeeLateFeesMasterDTO != null && FeeLateFeesMasterDTO.LateFeeValue > 0) ? FeeLateFeesMasterDTO.LateFeeValue : new decimal();
            }
            set
            {
                FeeLateFeesMasterDTO.LateFeeValue = value;
            }
        }
        public string errorMessage { get; set; }
        public string SelectedXml
        {
            get
            {
                return (FeeLateFeesMasterDTO != null) ? FeeLateFeesMasterDTO.SelectedXml : string.Empty;
            }
            set
            {
                FeeLateFeesMasterDTO.SelectedXml = value;
            }
        }
    }
}

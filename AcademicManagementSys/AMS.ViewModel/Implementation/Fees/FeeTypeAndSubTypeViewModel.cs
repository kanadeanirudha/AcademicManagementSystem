using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FeeTypeAndSubTypeViewModel : IFeeTypeAndSubTypeViewModel
    {
        public FeeTypeAndSubTypeViewModel()
        {
            FeeTypeAndSubTypeDTO = new FeeTypeAndSubType();
            AccountMasterList = new List<AccountMaster>();
            FeeSubTypeList = new List<FeeTypeAndSubType>();
        }
        public List<AccountMaster> AccountMasterList { get; set; }
        public List<FeeTypeAndSubType> FeeSubTypeList { get; set; }
        public IEnumerable<SelectListItem> AccountMasterListItems
        {
            get {
                return new SelectList(AccountMasterList, "ID", "AccountName");
            }
        }
        public IEnumerable<SelectListItem> FeeSubTypeListItems
        {
            get
            {
                return new SelectList(FeeSubTypeList, "FeeSubTypeID", "FeeSubTypeDesc");
            }
        }
        public FeeTypeAndSubType FeeTypeAndSubTypeDTO { get; set; }
        //-------------------------------FeeType ------------------------------------
        public short ID
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.ID > 0) ? FeeTypeAndSubTypeDTO.ID : new short();
            }
            set
            {
                FeeTypeAndSubTypeDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_FeeTypeDesc", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FeeTypeDescRequired")]
        public string FeeTypeDesc
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.FeeTypeDesc : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeTypeDesc = value;
            }
        }
        [Display(Name = "DisplayName_FeeTypeCode", ResourceType = typeof(Resources))]
        public string FeeTypeCode
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.FeeTypeCode : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeTypeCode = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.IsActive : false;
            }
            set
            {
                FeeTypeAndSubTypeDTO.IsActive = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.CreatedBy > 0) ? FeeTypeAndSubTypeDTO.CreatedBy : new short();
            }
            set
            {
                FeeTypeAndSubTypeDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FeeTypeAndSubTypeDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.ModifiedBy > 0) ? FeeTypeAndSubTypeDTO.ModifiedBy : new short();
            }
            set
            {
                FeeTypeAndSubTypeDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FeeTypeAndSubTypeDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.DeletedBy > 0) ? FeeTypeAndSubTypeDTO.DeletedBy : new short();
            }
            set
            {
                FeeTypeAndSubTypeDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FeeTypeAndSubTypeDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.IsDeleted : false;
            }
            set
            {
                FeeTypeAndSubTypeDTO.IsDeleted = value;
            }
        }

        //-------------------------------Fee Sub Type---------------------------------
        public short FeeSubTypeID
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.FeeSubTypeID > 0) ? FeeTypeAndSubTypeDTO.FeeSubTypeID : new short();
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeSubTypeID = value;
            }
        }
        [Display(Name = "DisplayName_FeeSubTypeDesc", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FeeSubTypeDescRequired")]
        public string FeeSubTypeDesc
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.FeeSubTypeDesc : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeSubTypeDesc = value;
            }
        }
        [Display(Name = "DisplayName_FeeSubShortDesc", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FeeSubShortDescRequired")]
        public string FeeSubShortDesc
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.FeeSubShortDesc : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeSubShortDesc = value;
            }
        }
        [Display(Name = "DisplayName_AccountID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_AccountIDRequired")]
        public int AccountID
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.AccountID > 0) ? FeeTypeAndSubTypeDTO.AccountID : new int();
            }
            set
            {
                FeeTypeAndSubTypeDTO.AccountID = value;
            }
        }
        [Display(Name = "DisplayName_SubTypeIdentification", ResourceType = typeof(Resources))]
        public string SubTypeIdentification
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null ) ? FeeTypeAndSubTypeDTO.SubTypeIdentification : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.SubTypeIdentification = value;
            }
        }
        public int ConsiderFeeTypeID
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null && FeeTypeAndSubTypeDTO.ConsiderFeeTypeID > 0) ? FeeTypeAndSubTypeDTO.ConsiderFeeTypeID : new int();
            }
            set
            {
                FeeTypeAndSubTypeDTO.ConsiderFeeTypeID = value;
            }
        }
        [Display(Name = "DisplayName_CarryForwardFeeSubtypeID", ResourceType = typeof(Resources))]
        public string CarryForwardFeeSubtypeID
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null ) ? FeeTypeAndSubTypeDTO.CarryForwardFeeSubtypeID : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.CarryForwardFeeSubtypeID = value;
            }
        }
       
        public string CarryForwardAcctEffects
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null) ? FeeTypeAndSubTypeDTO.CarryForwardAcctEffects : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.CarryForwardAcctEffects = value;
            }
        }
        [Display(Name = "DisplayName_FeeSource", ResourceType = typeof(Resources))]
        public string FeeSource
        {
            get
            {
                return (FeeTypeAndSubTypeDTO != null ) ? FeeTypeAndSubTypeDTO.FeeSource : string.Empty;
            }
            set
            {
                FeeTypeAndSubTypeDTO.FeeSource = value;
            }
        }

        public string errorMessage { get; set; }
        public bool IsFeeTypeTransaction {get;set;}
        [Display(Name = "DisplayName_SelectedBalanceSheet", ResourceType = typeof(Resources))]
        public string SelectedBalanceSheet { get; set; }
        public int SelectedBalanceSheetID { get; set; }
    }
}

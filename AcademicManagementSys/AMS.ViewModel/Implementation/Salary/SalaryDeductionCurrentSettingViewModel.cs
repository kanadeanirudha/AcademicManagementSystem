using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryDeductionCurrentSettingViewModel : ISalaryDeductionCurrentSettingViewModel
    {
        public SalaryDeductionCurrentSettingViewModel()
        {
            SalaryDeductionCurrentSettingDTO = new SalaryDeductionCurrentSetting();
        }
        public SalaryDeductionCurrentSetting SalaryDeductionCurrentSettingDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.ID > 0) ? SalaryDeductionCurrentSettingDTO.ID : new Int32(); }
            set { SalaryDeductionCurrentSettingDTO.ID = value; }
        }
        public Int32 SalaryDeductionMasterID
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID > 0) ? SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID : new Int32(); }
            set { SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID = value; }
        }
        public Decimal Percentage
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.Percentage > 0) ? SalaryDeductionCurrentSettingDTO.Percentage : new Decimal(); }
            set { SalaryDeductionCurrentSettingDTO.Percentage = value; }
        }
        
        public Int16 MapAccountID
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.MapAccountID > 0) ? SalaryDeductionCurrentSettingDTO.MapAccountID : new Int16(); }
            set { SalaryDeductionCurrentSettingDTO.MapAccountID = value; }
        }
        [Display(Name = "Calculate On")]
        public Int16 CalculateOn
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.CalculateOn > 0) ? SalaryDeductionCurrentSettingDTO.CalculateOn : new Int16(); }
            set { SalaryDeductionCurrentSettingDTO.CalculateOn = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.CreatedBy > 0) ? SalaryDeductionCurrentSettingDTO.CreatedBy : new Int32(); }
            set { SalaryDeductionCurrentSettingDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.CreatedDate != null) ? SalaryDeductionCurrentSettingDTO.CreatedDate : String.Empty; }
            set { SalaryDeductionCurrentSettingDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.ModifiedBy > 0) ? SalaryDeductionCurrentSettingDTO.ModifiedBy : new Int32(); }
            set { SalaryDeductionCurrentSettingDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.ModifiedDate != null) ? SalaryDeductionCurrentSettingDTO.ModifiedDate : String.Empty; }
            set { SalaryDeductionCurrentSettingDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.DeletedBy > 0) ? SalaryDeductionCurrentSettingDTO.DeletedBy : new Int32(); }
            set { SalaryDeductionCurrentSettingDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.DeletedDate != null) ? SalaryDeductionCurrentSettingDTO.DeletedDate : String.Empty; }
            set { SalaryDeductionCurrentSettingDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryDeductionCurrentSettingDTO != null) ? SalaryDeductionCurrentSettingDTO.IsDeleted : false; }
            set { SalaryDeductionCurrentSettingDTO.IsDeleted = value; }
        }
        [Display(Name = "Deduction Head Name")]
        public String DeductionHeadName
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.DeductionHeadName != null) ? SalaryDeductionCurrentSettingDTO.DeductionHeadName : String.Empty; }
            set { SalaryDeductionCurrentSettingDTO.DeductionHeadName = value; }
        }
        [Display(Name = "Fix Amount")]
        public Decimal FixAmount
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.FixAmount > 0) ? SalaryDeductionCurrentSettingDTO.FixAmount : new Decimal(); }
            set { SalaryDeductionCurrentSettingDTO.FixAmount = value; }
        }
      
        [Display(Name = "Account Name")]
        public string AccountName
        {
            get { return (SalaryDeductionCurrentSettingDTO != null && SalaryDeductionCurrentSettingDTO.AccountName != null) ? SalaryDeductionCurrentSettingDTO.AccountName : string.Empty; }
            set { SalaryDeductionCurrentSettingDTO.AccountName = value; }
        }
    }
}

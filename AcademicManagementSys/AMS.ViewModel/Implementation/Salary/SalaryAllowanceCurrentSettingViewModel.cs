using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryAllowanceCurrentSettingViewModel : ISalaryAllowanceCurrentSettingViewModel
    {
        public SalaryAllowanceCurrentSettingViewModel()
        {
            SalaryAllowanceCurrentSettingDTO = new SalaryAllowanceCurrentSetting();
        }
        public SalaryAllowanceCurrentSetting SalaryAllowanceCurrentSettingDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.ID > 0) ? SalaryAllowanceCurrentSettingDTO.ID : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.ID = value; }
        }
        public Int32 SalaryAllowanceMasterID
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID > 0) ? SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID = value; }
        }
        public Decimal Percentage
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.Percentage > 0) ? SalaryAllowanceCurrentSettingDTO.Percentage : new Decimal(); }
            set { SalaryAllowanceCurrentSettingDTO.Percentage = value; }
        }
         [Display(Name = "Effected Date")]
        public String EffectedDate
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.EffectedDate != null) ? SalaryAllowanceCurrentSettingDTO.EffectedDate : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.EffectedDate = value; }
        }
         [Display(Name = "Close Date")]
        public String CloseDate
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.CloseDate != null) ? SalaryAllowanceCurrentSettingDTO.CloseDate : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.CloseDate = value; }
        }
         [Display(Name = "Is Current")]
        public bool IsCurrent
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null) ? SalaryAllowanceCurrentSettingDTO.IsCurrent : false; }
            set { SalaryAllowanceCurrentSettingDTO.IsCurrent = value; }
        }
        public Int32 SalaryPayRulesID
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID > 0) ? SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID = value; }
        }
        public Int16 MapAccountID
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.MapAccountID > 0) ? SalaryAllowanceCurrentSettingDTO.MapAccountID : new Int16(); }
            set { SalaryAllowanceCurrentSettingDTO.MapAccountID = value; }
        }
        [Display(Name = "Calculate On")]
        public Int16 CalculateOn
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.CalculateOn > 0) ? SalaryAllowanceCurrentSettingDTO.CalculateOn : new Int16(); }
            set { SalaryAllowanceCurrentSettingDTO.CalculateOn = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.CreatedBy > 0) ? SalaryAllowanceCurrentSettingDTO.CreatedBy : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.CreatedDate != null) ? SalaryAllowanceCurrentSettingDTO.CreatedDate : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.ModifiedBy > 0) ? SalaryAllowanceCurrentSettingDTO.ModifiedBy : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.ModifiedDate != null) ? SalaryAllowanceCurrentSettingDTO.ModifiedDate : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.DeletedBy > 0) ? SalaryAllowanceCurrentSettingDTO.DeletedBy : new Int32(); }
            set { SalaryAllowanceCurrentSettingDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.DeletedDate != null) ? SalaryAllowanceCurrentSettingDTO.DeletedDate : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null) ? SalaryAllowanceCurrentSettingDTO.IsDeleted : false; }
            set { SalaryAllowanceCurrentSettingDTO.IsDeleted = value; }
        }
        [Display(Name = "Allowance Head Name")]
        public String AllowanceHeadName
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.AllowanceHeadName != null) ? SalaryAllowanceCurrentSettingDTO.AllowanceHeadName : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.AllowanceHeadName = value; }
        }
        [Display(Name = "Fixed Amount")]
        public Decimal FixedAmount
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.FixedAmount > 0) ? SalaryAllowanceCurrentSettingDTO.FixedAmount : new Decimal(); }
            set { SalaryAllowanceCurrentSettingDTO.FixedAmount = value; }
        }
        [Display(Name = "Pay Scale Rule Description")]
        public String PayScaleRuleDescription
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription != null) ? SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription : String.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription = value; }
        }
        [Display(Name = "Account Name")]
        public string AccountName
        {
            get { return (SalaryAllowanceCurrentSettingDTO != null && SalaryAllowanceCurrentSettingDTO.AccountName != null) ? SalaryAllowanceCurrentSettingDTO.AccountName : string.Empty; }
            set { SalaryAllowanceCurrentSettingDTO.AccountName = value; }
        }
    }
}

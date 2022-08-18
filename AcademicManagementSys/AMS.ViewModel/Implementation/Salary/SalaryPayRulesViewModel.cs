using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryPayRulesViewModel : ISalaryPayRulesViewModel
    {
        public SalaryPayRulesViewModel()
        {
            SalaryPayRulesDTO = new SalaryPayRules();
        }
        public SalaryPayRules SalaryPayRulesDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.ID > 0) ? SalaryPayRulesDTO.ID : new Int32(); }
            set { SalaryPayRulesDTO.ID = value; }
        }
        [Display(Name = "Pay Scale Rule Description")]
        public String PayScaleRuleDescription
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.PayScaleRuleDescription != null) ? SalaryPayRulesDTO.PayScaleRuleDescription : String.Empty; }
            set { SalaryPayRulesDTO.PayScaleRuleDescription = value; }
        }
        [Display(Name = "Pay Scale Rule Active From")]
        public String PayScaleFromDate
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.PayScaleFromDate != null) ? SalaryPayRulesDTO.PayScaleFromDate : String.Empty; }
            set { SalaryPayRulesDTO.PayScaleFromDate = value; }
        }
        [Display(Name = "Pay Scale Rule Active Upto")]
        public String PayScaleUptoDate
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.PayScaleUptoDate != null) ? SalaryPayRulesDTO.PayScaleUptoDate : String.Empty; }
            set { SalaryPayRulesDTO.PayScaleUptoDate = value; }
        }
        public bool IsActive
        {
            get { return (SalaryPayRulesDTO != null) ? SalaryPayRulesDTO.IsActive : false; }
            set { SalaryPayRulesDTO.IsActive = value; }
        }
        public Int16 SequenceNumber
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.SequenceNumber > 0) ? SalaryPayRulesDTO.SequenceNumber : new Int16(); }
            set { SalaryPayRulesDTO.SequenceNumber = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.CreatedBy > 0) ? SalaryPayRulesDTO.CreatedBy : new Int32(); }
            set { SalaryPayRulesDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.CreatedDate != null) ? SalaryPayRulesDTO.CreatedDate : String.Empty; }
            set { SalaryPayRulesDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.ModifiedBy > 0) ? SalaryPayRulesDTO.ModifiedBy : new Int32(); }
            set { SalaryPayRulesDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.ModifiedDate != null) ? SalaryPayRulesDTO.ModifiedDate : String.Empty; }
            set { SalaryPayRulesDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.DeletedBy > 0) ? SalaryPayRulesDTO.DeletedBy : new Int32(); }
            set { SalaryPayRulesDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryPayRulesDTO != null && SalaryPayRulesDTO.DeletedDate != null) ? SalaryPayRulesDTO.DeletedDate : String.Empty; }
            set { SalaryPayRulesDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryPayRulesDTO != null) ? SalaryPayRulesDTO.IsDeleted : false; }
            set { SalaryPayRulesDTO.IsDeleted = value; }
        }
        public string errorMessage { get; set; }
    }
}

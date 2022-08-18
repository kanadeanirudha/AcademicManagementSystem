using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryAllowanceCurrentSetting : BaseDTO
    {
        public int ID { get; set; }
        public int SalaryAllowanceMasterID { get; set; }
        public decimal FixedAmount { get; set; }
        public decimal Percentage { get; set; }
        public string EffectedDate { get; set; }
        public string CloseDate { get; set; }
        public bool IsCurrent { get; set; }
        public Int32 SalaryPayRulesID { get; set; }
        public Int16 MapAccountID { get; set; }
        public Int16 CalculateOn { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string AllowanceHeadName { get; set; }
        public string PayScaleRuleDescription { get; set; }
        public string AccountName { get; set; }
    }
}

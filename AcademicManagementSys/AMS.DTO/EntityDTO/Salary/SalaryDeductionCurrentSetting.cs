using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryDeductionCurrentSetting : BaseDTO
    {
        public Int32 ID { get; set; }
        public Int32 SalaryDeductionMasterID { get; set; }
        public decimal FixAmount { get; set; }
        public decimal Percentage { get; set; }
        public Int16 MapAccountID { get; set; }
        public Int16 CalculateOn { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeductionHeadName { get; set; }
       
        public string AccountName { get; set; }
    }
}

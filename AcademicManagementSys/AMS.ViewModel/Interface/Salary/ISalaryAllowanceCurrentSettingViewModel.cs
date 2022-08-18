using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryAllowanceCurrentSettingViewModel
    {
        SalaryAllowanceCurrentSetting SalaryAllowanceCurrentSettingDTO { get; set; }
        Int32 ID { get; set; }
        Int32 SalaryAllowanceMasterID { get; set; }
        decimal FixedAmount { get; set; }
        decimal Percentage { get; set; }
        string EffectedDate { get; set; }
        string CloseDate { get; set; }
        bool IsCurrent { get; set; }
        Int32 SalaryPayRulesID { get; set; }
        Int16 MapAccountID { get; set; }
        Int16 CalculateOn { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}

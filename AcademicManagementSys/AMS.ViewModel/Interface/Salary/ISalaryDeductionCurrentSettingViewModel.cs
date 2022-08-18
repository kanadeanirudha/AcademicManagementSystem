using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryDeductionCurrentSettingViewModel
    {
        SalaryDeductionCurrentSetting SalaryDeductionCurrentSettingDTO { get; set; }
        Int32 ID { get; set; }
        Int32 SalaryDeductionMasterID { get; set; }
        decimal FixAmount { get; set; }
        decimal Percentage { get; set; }
        
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

using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryPayRulesViewModel
    {
        SalaryPayRules SalaryPayRulesDTO { get; set; }
        Int32 ID { get; set; }
        string PayScaleRuleDescription { get; set; }
        string PayScaleFromDate { get; set; }
        string PayScaleUptoDate { get; set; }
        bool IsActive { get; set; }
        Int16 SequenceNumber { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}

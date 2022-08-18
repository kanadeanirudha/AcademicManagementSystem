using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryDeductionMasterViewModel
    {
        SalaryDeductionMaster SalaryDeductionMasterDTO { get; set; }
        Int32 ID { get; set; }
        string DeductionHeadName { get; set; }
        string DeductionType { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}

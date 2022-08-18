using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryPayScaleMasterViewModel
    {
        SalaryPayScaleMaster SalaryPayScaleMasterDTO { get; set; }
        Int16 ID { get; set; }
        Int32 DesignationID { get; set; }
        string PayScaleRange { get; set; }
        decimal RangeFrom { get; set; }
        decimal RangeUpto { get; set; }
        decimal PayBandIncrementPercent { get; set; }
        Int32 PaybandPeriodSpan { get; set; }
        string PaybandPeriodUnit { get; set; }
        Int32 SalaryPayRulesID { get; set; }
        Int32 CreatedBy { get; set; }
        string CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        string ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        string DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}

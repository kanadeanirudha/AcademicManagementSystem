using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryPayScaleMasterSearchRequest : Request
    {
        public Int16 ID { get; set; }
        public Int32 DesignationID { get; set; }
        public string PayScaleRange { get; set; }
        public decimal RangeFrom { get; set; }
        public decimal RangeUpto { get; set; }
        public decimal PayBandIncrementPercent { get; set; }
        public Int32 PaybandPeriodSpan { get; set; }
        public string PaybandPeriodUnit { get; set; }
        public Int32 SalaryPayRulesID { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }

        public string SearchBy { get; set; }

        public string SortDirection { get; set; }
    }
}

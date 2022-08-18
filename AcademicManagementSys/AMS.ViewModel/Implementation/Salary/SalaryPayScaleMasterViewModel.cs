using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryPayScaleMasterViewModel : ISalaryPayScaleMasterViewModel
    {
        public SalaryPayScaleMasterViewModel()
        {
            SalaryPayScaleMasterDTO = new SalaryPayScaleMaster();
        }
        public SalaryPayScaleMaster SalaryPayScaleMasterDTO { get; set; }
        public Int16 ID
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.ID > 0) ? SalaryPayScaleMasterDTO.ID : new Int16(); }
            set { SalaryPayScaleMasterDTO.ID = value; }
        }
        [Display(Name="Designation")]
        public Int32 DesignationID
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.DesignationID > 0) ? SalaryPayScaleMasterDTO.DesignationID : new Int32(); }
            set { SalaryPayScaleMasterDTO.DesignationID = value; }
        }
        [Display(Name = "Pay Scale Range")]
        public String PayScaleRange
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.PayScaleRange != null) ? SalaryPayScaleMasterDTO.PayScaleRange : String.Empty; }
            set { SalaryPayScaleMasterDTO.PayScaleRange = value; }
        }
        public String PayScaleRuleDescription
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.PayScaleRuleDescription != null) ? SalaryPayScaleMasterDTO.PayScaleRuleDescription : String.Empty; }
            set { SalaryPayScaleMasterDTO.PayScaleRuleDescription = value; }
        }
        public String Description
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.Description != null) ? SalaryPayScaleMasterDTO.Description : String.Empty; }
            set { SalaryPayScaleMasterDTO.Description = value; }
        }
        [Display(Name="Range From")]
        public Decimal RangeFrom
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.RangeFrom > 0) ? SalaryPayScaleMasterDTO.RangeFrom : new Decimal(); }
            set { SalaryPayScaleMasterDTO.RangeFrom = value; }
        }
        [Display(Name="Range Upto")]
        public Decimal RangeUpto
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.RangeUpto > 0) ? SalaryPayScaleMasterDTO.RangeUpto : new Decimal(); }
            set { SalaryPayScaleMasterDTO.RangeUpto = value; }
        }
        [Display(Name="Pay Band Increment Percent")]
        public Decimal PayBandIncrementPercent
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.PayBandIncrementPercent > 0) ? SalaryPayScaleMasterDTO.PayBandIncrementPercent : new Decimal(); }
            set { SalaryPayScaleMasterDTO.PayBandIncrementPercent = value; }
        }
        [Display(Name="Pay Band Period Span")]
        public Int32 PaybandPeriodSpan
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.PaybandPeriodSpan > 0) ? SalaryPayScaleMasterDTO.PaybandPeriodSpan : new Int32(); }
            set { SalaryPayScaleMasterDTO.PaybandPeriodSpan = value; }
        }
        [Display(Name = "Pay Band Period Unit")]
        public String PaybandPeriodUnit
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.PaybandPeriodUnit != null) ? SalaryPayScaleMasterDTO.PaybandPeriodUnit : String.Empty; }
            set { SalaryPayScaleMasterDTO.PaybandPeriodUnit = value; }
        }
        [Display(Name = "Salary Pay Rules")]
        public Int32 SalaryPayRulesID
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.SalaryPayRulesID > 0) ? SalaryPayScaleMasterDTO.SalaryPayRulesID : new Int32(); }
            set { SalaryPayScaleMasterDTO.SalaryPayRulesID = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.CreatedBy > 0) ? SalaryPayScaleMasterDTO.CreatedBy : new Int32(); }
            set { SalaryPayScaleMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.CreatedDate != null) ? SalaryPayScaleMasterDTO.CreatedDate : String.Empty; }
            set { SalaryPayScaleMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.ModifiedBy > 0) ? SalaryPayScaleMasterDTO.ModifiedBy : new Int32(); }
            set { SalaryPayScaleMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.ModifiedDate != null) ? SalaryPayScaleMasterDTO.ModifiedDate : String.Empty; }
            set { SalaryPayScaleMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.DeletedBy > 0) ? SalaryPayScaleMasterDTO.DeletedBy : new Int32(); }
            set { SalaryPayScaleMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryPayScaleMasterDTO != null && SalaryPayScaleMasterDTO.DeletedDate != null) ? SalaryPayScaleMasterDTO.DeletedDate : String.Empty; }
            set { SalaryPayScaleMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryPayScaleMasterDTO != null) ? SalaryPayScaleMasterDTO.IsDeleted : false; }
            set { SalaryPayScaleMasterDTO.IsDeleted = value; }
        }
    }
}

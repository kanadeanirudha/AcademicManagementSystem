using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface ISalaryEmployeePayFixationMasterViewModel
    {
        Int32 ID { get; set; }
        Int32 EmployeeID { get; set; }
        //String EmployeeFirstName { get; set; }
        //String EmployeeLastName { get; set; }
        String EmployeeName { get; set; }
        Decimal PayScaleRange { get; set; }
        Decimal GradePayAmount { get; set; }
        //public Int32 OldSalaryEmployeePayFixationMasterID{get;set;}
        decimal Basic { get; set; }
        Int16 SalaryPayScaleMasterID { get; set; }
        Int16 SalaryGradePayMasterID { get; set; }
        // Int16 PayIncrementCount{get;set;}
        // decimal BandPay{get;set;}
        // decimal GradePay{get;set;}
        // Int16 ApprovedStatus{get;set;}
        //Int32 ApprovedBy{get;set;}
        // bool IsCurrent{get;set;}
        //string OrderDate{get;set;}
        // string OrderNumber{get;set;}
        // string EffectiveFrom{get;set;}
        //bool IsNeedGenerateArriers{get;set;}
         byte ArriersGenerationStatus { get; set; }
         Int32 CreatedBy { get; set; }
         string CreatedDate { get; set; }
         Int32 ModifiedBy { get; set; }
         string ModifiedDate { get; set; }
         Int32 DeletedBy { get; set; }
         string DeletedDate { get; set; }
         bool IsDeleted { get; set; }
    }
}

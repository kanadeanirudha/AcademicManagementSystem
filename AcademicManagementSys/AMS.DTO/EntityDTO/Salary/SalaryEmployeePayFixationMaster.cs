using AMS.Base.DTO;
using System;
namespace AMS.DTO
    {
    public class SalaryEmployeePayFixationMaster : BaseDTO
    {
        public Int32 ID{get;set;}
        public Int32 EmployeeID{get;set;}
        public String EmployeeFirstName { get; set; }
        public String EmployeeLastName { get; set; }
        public String EmployeeName { get; set; }
        public Decimal PayScaleRange { get; set; }
        public Decimal GradePayAmount { get; set; }
        public Int32 OldSalaryEmployeePayFixationMasterID { get; set; }
        public decimal Basic{get;set;}
        public Int16 SalaryPayScaleMasterID{get;set;}
        public Int16 SalaryGradePayMasterID{get;set;}
        public Int16 PayIncrementCount { get; set; }
        public decimal BandPay { get; set; }
        public decimal GradePay { get; set; }
        public Int16 ApprovedStatus { get; set; }
        public Int32 ApprovedBy { get; set; }
        public bool IsCurrent { get; set; }
        public string OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public string EffectiveFrom { get; set; }
        public bool IsNeedGenerateArriers { get; set; }
        public byte ArriersGenerationStatus{get;set;}
        public Int32 CreatedBy{get;set;}
        public string CreatedDate{get;set;}
        public Int32 ModifiedBy{get;set;}
        public string ModifiedDate{get;set;}
        public Int32 DeletedBy{get;set;}
        public string DeletedDate{get;set;}
        public bool IsDeleted{get;set;}
    }
    }

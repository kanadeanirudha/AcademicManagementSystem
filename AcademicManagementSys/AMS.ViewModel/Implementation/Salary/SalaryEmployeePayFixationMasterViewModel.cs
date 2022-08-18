using AMS.Common;
using AMS.DTO;
using AMS.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class SalaryEmployeePayFixationMasterViewModel : ISalaryEmployeePayFixationMasterViewModel
    {
        public SalaryEmployeePayFixationMasterViewModel()
        {
            SalaryEmployeePayFixationMasterDTO = new SalaryEmployeePayFixationMaster();
            PayScaleRangeList = new List<SalaryPayScaleMaster>();
        }
        public List<SalaryPayScaleMaster> PayScaleRangeList { get; set; }
        public IEnumerable<SelectListItem> PayScaleRangeListItems { get { return new SelectList(PayScaleRangeList, "SalaryPayScaleMasterID", "PayScaleRange"); } }

        public SalaryEmployeePayFixationMaster SalaryEmployeePayFixationMasterDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.ID > 0) ? SalaryEmployeePayFixationMasterDTO.ID : new Int32(); }
            set { SalaryEmployeePayFixationMasterDTO.ID = value; }
        }
        public Int32 EmployeeID
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.EmployeeID > 0) ? SalaryEmployeePayFixationMasterDTO.EmployeeID : new Int32(); }
            set { SalaryEmployeePayFixationMasterDTO.EmployeeID = value; }
        }
        public Int16 SalaryPayScaleMasterID
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID > 0) ? SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID : new Int16(); }
            set { SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID = value; }
        }
        public Int16 SalaryGradePayMasterID
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID > 0) ? SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID : new Int16(); }
            set { SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID = value; }
        }
        [Display(Name = "Employee Name")]
        public String EmployeeName
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.EmployeeName != null) ? SalaryEmployeePayFixationMasterDTO.EmployeeName : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.EmployeeName = value; }
        }
        public String EmployeeLastName
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.EmployeeLastName != null) ? SalaryEmployeePayFixationMasterDTO.EmployeeLastName : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.EmployeeLastName = value; }
        }
        public String EmployeeFirstName
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.EmployeeFirstName != null) ? SalaryEmployeePayFixationMasterDTO.EmployeeLastName : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.EmployeeFirstName = value; }
        }
           [Display(Name = "Order Number")]
        public string OrderNumber
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.OrderNumber : string.Empty;
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.OrderNumber = value;
            }
        }
           [Display(Name = "Order Date")]
        public string OrderDate
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.OrderDate : string.Empty;
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.OrderDate = value;
          
            }
        }
           [Display(Name = "Effective From")]
        public string EffectiveFrom
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.EffectiveFrom : string.Empty;
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.EffectiveFrom = value;
            }
        }
        [Display(Name = "Is Need To Generate Arriers")]
        public bool IsNeedGenerateArriers
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.IsNeedGenerateArriers : false;
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.IsNeedGenerateArriers = value;
            }
        }
        public int OldSalaryEmployeePayFixationMasterID
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.OldSalaryEmployeePayFixationMasterID > 0) ? SalaryEmployeePayFixationMasterDTO.OldSalaryEmployeePayFixationMasterID : new int();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.OldSalaryEmployeePayFixationMasterID = value;
            }
        }
        public Int16 PayIncrementCount
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.PayIncrementCount > 0) ? SalaryEmployeePayFixationMasterDTO.PayIncrementCount : new Int16();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.PayIncrementCount = value;
            }
        }
        public decimal BandPay
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.BandPay > 0) ? SalaryEmployeePayFixationMasterDTO.BandPay : new decimal();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.BandPay = value;
            }
        }
        public decimal GradePay
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.GradePay > 0) ? SalaryEmployeePayFixationMasterDTO.GradePay : new decimal();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.GradePay = value;
            }
        }
        public bool IsCurrent
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.IsCurrent : false;
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.IsCurrent = value;
            }
        }
        public Int16 ApprovedStatus
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.ApprovedStatus > 0) ? SalaryEmployeePayFixationMasterDTO.ApprovedStatus : new Int16();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.ApprovedStatus = value;
            }
        }
       public int ApprovedBy
        {
            get
            {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.ApprovedBy > 0) ? SalaryEmployeePayFixationMasterDTO.ApprovedBy : new int();
            }
            set
            {
                SalaryEmployeePayFixationMasterDTO.ApprovedBy = value;
            }
        }
        [Display(Name = "Basic")]
        public decimal Basic
        {
            get {
                return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.Basic > 0) ? SalaryEmployeePayFixationMasterDTO.Basic : new decimal();
            }
            set { SalaryEmployeePayFixationMasterDTO.Basic = value; }
        }
        [Display(Name = "Pay Scale Range")]
        public decimal PayScaleRange
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.PayScaleRange > 0) ? SalaryEmployeePayFixationMasterDTO.PayScaleRange : new decimal(); }
            set { SalaryEmployeePayFixationMasterDTO.PayScaleRange = value; }
        }
        [Display(Name = "Grade Pay Amount")]
        public decimal GradePayAmount
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.GradePayAmount > 0) ? SalaryEmployeePayFixationMasterDTO.GradePayAmount : new decimal(); }
            set { SalaryEmployeePayFixationMasterDTO.GradePayAmount = value; }
        }
        [Display(Name = "Arriers Generation Status")]
        public Byte ArriersGenerationStatus
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus : new Byte(); }
            set { SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus= value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.CreatedBy > 0) ? SalaryEmployeePayFixationMasterDTO.CreatedBy : new Int32(); }
            set { SalaryEmployeePayFixationMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.CreatedDate != null) ? SalaryEmployeePayFixationMasterDTO.CreatedDate : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.ModifiedBy > 0) ? SalaryEmployeePayFixationMasterDTO.ModifiedBy : new Int32(); }
            set { SalaryEmployeePayFixationMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.ModifiedDate != null) ? SalaryEmployeePayFixationMasterDTO.ModifiedDate : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.DeletedBy > 0) ? SalaryEmployeePayFixationMasterDTO.DeletedBy : new Int32(); }
            set { SalaryEmployeePayFixationMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null && SalaryEmployeePayFixationMasterDTO.DeletedDate != null) ? SalaryEmployeePayFixationMasterDTO.DeletedDate : String.Empty; }
            set { SalaryEmployeePayFixationMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryEmployeePayFixationMasterDTO != null) ? SalaryEmployeePayFixationMasterDTO.IsDeleted : false; }
            set { SalaryEmployeePayFixationMasterDTO.IsDeleted = value; }
        }
    }
}


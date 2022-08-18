using System;
using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryGradePayMasterViewModel : ISalaryGradePayMasterViewModel
    {
        public SalaryGradePayMasterViewModel()
        {
            SalaryGradePayMasterDTO = new SalaryGradePayMaster();
        }
        public SalaryGradePayMaster SalaryGradePayMasterDTO { get; set; }
        public Int16 ID
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.ID > 0) ? SalaryGradePayMasterDTO.ID : new Int16(); }
            set { SalaryGradePayMasterDTO.ID = value; }
        }
        [Display(Name="Designation")]
        public Int32 DesignationID
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.DesignationID > 0) ? SalaryGradePayMasterDTO.DesignationID : new Int32(); }
            set { SalaryGradePayMasterDTO.DesignationID = value; }
        }
         [Display(Name = "Salary Pay Rules")]
        public Int32 SalaryPayRulesID
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.SalaryPayRulesID > 0) ? SalaryGradePayMasterDTO.SalaryPayRulesID : new Int32(); }
            set { SalaryGradePayMasterDTO.SalaryPayRulesID = value; }
        }
        [Display(Name = "Grade Pay Amount")]
       public Decimal GradePayAmount
         {
             get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.GradePayAmount > 0) ? SalaryGradePayMasterDTO.GradePayAmount : new Decimal(); }
             set { SalaryGradePayMasterDTO.GradePayAmount = value; }
         }
         public String Description
         {
             get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.Description != null) ? SalaryGradePayMasterDTO.Description : String.Empty; }
             set { SalaryGradePayMasterDTO.Description = value; }
         }
       public String PayScaleRuleDescription
       {
           get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.PayScaleRuleDescription !=null) ? SalaryGradePayMasterDTO.PayScaleRuleDescription : String.Empty; }
           set { SalaryGradePayMasterDTO.PayScaleRuleDescription = value; }
       }
        public Int32 CreatedBy
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.CreatedBy > 0) ? SalaryGradePayMasterDTO.CreatedBy : new Int32(); }
            set { SalaryGradePayMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.CreatedDate != null) ? SalaryGradePayMasterDTO.CreatedDate : String.Empty; }
            set { SalaryGradePayMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.ModifiedBy > 0) ? SalaryGradePayMasterDTO.ModifiedBy : new Int32(); }
            set { SalaryGradePayMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.ModifiedDate != null) ? SalaryGradePayMasterDTO.ModifiedDate : String.Empty; }
            set { SalaryGradePayMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.DeletedBy > 0) ? SalaryGradePayMasterDTO.DeletedBy : new Int32(); }
            set { SalaryGradePayMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryGradePayMasterDTO != null && SalaryGradePayMasterDTO.DeletedDate != null) ? SalaryGradePayMasterDTO.DeletedDate : String.Empty; }
            set { SalaryGradePayMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryGradePayMasterDTO != null) ? SalaryGradePayMasterDTO.IsDeleted : false; }
            set { SalaryGradePayMasterDTO.IsDeleted = value; }
        }
    }
}

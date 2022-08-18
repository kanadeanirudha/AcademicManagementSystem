using System;
using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryDeductionMasterViewModel : ISalaryDeductionMasterViewModel
    {
        public SalaryDeductionMasterViewModel()
        {
            SalaryDeductionMasterDTO = new SalaryDeductionMaster();
        }
        public SalaryDeductionMaster SalaryDeductionMasterDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ID > 0) ? SalaryDeductionMasterDTO.ID : new Int32(); }
            set { SalaryDeductionMasterDTO.ID = value; }
        }
        [Display(Name = "Deduction Head Name")]
        public String DeductionHeadName
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeductionHeadName != null) ? SalaryDeductionMasterDTO.DeductionHeadName : String.Empty; }
            set { SalaryDeductionMasterDTO.DeductionHeadName = value; }
        }
        [Display(Name = "Deduction Type")]
        public String DeductionType
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeductionType != null) ? SalaryDeductionMasterDTO.DeductionType : String.Empty; }
            set { SalaryDeductionMasterDTO.DeductionType = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.CreatedBy > 0) ? SalaryDeductionMasterDTO.CreatedBy : new Int32(); }
            set { SalaryDeductionMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.CreatedDate != null) ? SalaryDeductionMasterDTO.CreatedDate : String.Empty; }
            set { SalaryDeductionMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ModifiedBy > 0) ? SalaryDeductionMasterDTO.ModifiedBy : new Int32(); }
            set { SalaryDeductionMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ModifiedDate != null) ? SalaryDeductionMasterDTO.ModifiedDate : String.Empty; }
            set { SalaryDeductionMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeletedBy > 0) ? SalaryDeductionMasterDTO.DeletedBy : new Int32(); }
            set { SalaryDeductionMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeletedDate != null) ? SalaryDeductionMasterDTO.DeletedDate : String.Empty; }
            set { SalaryDeductionMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.IsDeleted : false; }
            set { SalaryDeductionMasterDTO.IsDeleted = value; }
        }
    }
}

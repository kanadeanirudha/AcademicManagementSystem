using System;
using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class SalaryAllowanceMasterViewModel : ISalaryAllowanceMasterViewModel
    {
        public SalaryAllowanceMasterViewModel()
        {
            SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
        }
        public SalaryAllowanceMaster SalaryAllowanceMasterDTO { get; set; }
        public Int32 ID
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ID > 0) ? SalaryAllowanceMasterDTO.ID : new Int32(); }
            set { SalaryAllowanceMasterDTO.ID = value; }
        }
        [Display(Name = "Allowance Head Name")]
        public String AllowanceHeadName
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.AllowanceHeadName != null) ? SalaryAllowanceMasterDTO.AllowanceHeadName : String.Empty; }
            set { SalaryAllowanceMasterDTO.AllowanceHeadName = value; }
        }
        [Display(Name = "Allowance Type")]
        public String AllowanceType
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.AllowanceType != null) ? SalaryAllowanceMasterDTO.AllowanceType : String.Empty; }
            set { SalaryAllowanceMasterDTO.AllowanceType = value; }
        }
        public Int32 CreatedBy
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.CreatedBy > 0) ? SalaryAllowanceMasterDTO.CreatedBy : new Int32(); }
            set { SalaryAllowanceMasterDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.CreatedDate != null) ? SalaryAllowanceMasterDTO.CreatedDate : String.Empty; }
            set { SalaryAllowanceMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ModifiedBy > 0) ? SalaryAllowanceMasterDTO.ModifiedBy : new Int32(); }
            set { SalaryAllowanceMasterDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ModifiedDate != null) ? SalaryAllowanceMasterDTO.ModifiedDate : String.Empty; }
            set { SalaryAllowanceMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.DeletedBy > 0) ? SalaryAllowanceMasterDTO.DeletedBy : new Int32(); }
            set { SalaryAllowanceMasterDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.DeletedDate != null) ? SalaryAllowanceMasterDTO.DeletedDate : String.Empty; }
            set { SalaryAllowanceMasterDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.IsDeleted : false; }
            set { SalaryAllowanceMasterDTO.IsDeleted = value; }
        }
    }
}

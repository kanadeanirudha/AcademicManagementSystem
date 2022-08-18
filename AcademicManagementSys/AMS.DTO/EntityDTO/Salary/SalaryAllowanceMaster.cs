using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryAllowanceMaster : BaseDTO
    {
        public Int32 ID { get; set; }
        public string AllowanceHeadName { get; set; }
        public string AllowanceType { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
      
    }
}

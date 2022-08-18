using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalaryGradePayMaster : BaseDTO
    {
        public Int16 ID { get; set; }
        public Int32 DesignationID { get; set; }
        public Decimal GradePayAmount { get; set; }
        public Int32 SalaryPayRulesID { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public String Description { get; set; }
        public String PayScaleRuleDescription { get; set; }
        public String ErrorMessage { get; set; }
    }
}

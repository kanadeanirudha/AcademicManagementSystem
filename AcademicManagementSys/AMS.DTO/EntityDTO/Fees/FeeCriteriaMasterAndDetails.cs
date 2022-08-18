using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class FeeCriteriaMasterAndDetails : BaseDTO
    {
        //-----------------------------Fee Criteria Master-----------------------------
        public int ID { get; set; }
        public string FeeCriteriaDescription { get; set; }
        public string FeeCriteriaCode { get; set; }
        public short FeeTypeID { get; set; }
        public short AccBalanceSheetID { get; set; }
        public bool IsActive { get; set; }
        public string CentreCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        //----------------------------Fee Criteria Details -------------------------------

        public int FeeCriteriaDetailsID { get; set; }
        public int FeeCriteriaParametersID { get; set; }
        public string CentreName { get; set; }
        public string FeeTypeDesc{ get; set; }
        public string FeeCriteriaParametersDescription { get; set; }
        public string FeeCriteriaParametersXML { get; set; }

        public string errorMessage { get; set; }
        public bool IsFeeCriteriaMasterTransaction { get; set; }
        public string AccBalanceSheetName { get; set; }

    }
}

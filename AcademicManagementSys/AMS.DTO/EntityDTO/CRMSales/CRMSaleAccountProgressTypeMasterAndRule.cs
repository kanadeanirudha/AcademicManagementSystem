using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMSaleAccountProgressTypeMasterAndRule : BaseDTO
    {
        //CRMSaleAccountProgressType
        public Int16 CRMSaleAccountProgressTypeID
        {
            get;
            set;
        }
        public string ProgressType
        {
            get;
            set;
        }
        public string ColourGuide
        {
            get;
            set;
        }

        //CRMSaleAccountProgressTypeRule

        public Int16 CRMSaleAccountProgressTypeRuleID
        {
            get;
            set;
        }
        public Int16 Days
        {
            get;
            set;
        }
        public string Operator
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public bool IsCurrent
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

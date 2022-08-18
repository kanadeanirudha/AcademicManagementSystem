using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class CRMCallType : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string CallTypeDescription
        {
            get;
            set;
        }
        public string RelatedWith
        {
            get;
            set;
        }
        public string MenuLink
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
    }
}


using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class HMComfirtType : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }

        public string ComfirtType
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
    }

}
       
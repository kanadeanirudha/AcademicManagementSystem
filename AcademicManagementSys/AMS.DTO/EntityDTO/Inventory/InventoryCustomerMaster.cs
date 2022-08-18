using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryCustomerMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
       
        public string Name
        {
            get;
            set;
        }
        public string ContactNumber
        {
            get;
            set;
        }
         public string Address
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
        public string errorMessage { get; set; }
    }
}

using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishItemLicenseAllocation : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public int LicenseTypeID
        {
            get;
            set;
        }
        public int FishFishermenMasterID
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
        public bool IsLastRecord
        {
            get;
            set;
        }
        public bool IsActive
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
        public string PaymentMode
        {
            get;
            set;
        }


        //------------------Exrta Field----------------
        public string LocationName
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }
    }
}

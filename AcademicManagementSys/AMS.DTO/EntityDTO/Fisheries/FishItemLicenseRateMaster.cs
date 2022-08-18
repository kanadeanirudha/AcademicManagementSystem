using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishItemLicenseRate : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        
        public string CentreCode
        {
            get;
            set;
        }
        public int LicenseTypeID
        {
            get;
            set;
        }
        public decimal Rate
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




        //-----------------------Extra Property---------------------//
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    }
}

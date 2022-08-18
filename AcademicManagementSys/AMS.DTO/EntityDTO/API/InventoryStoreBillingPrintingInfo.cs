using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class InventoryStoreBillingPrintingInfo : BaseDTO
    {
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string DisplayIcon
        {
            get;
            set;
        }
        public string Footer
        {
            get;
            set;
        }
        public string LogoPath
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string TelephoneNumber
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
        public string Greeting
        {
            get;
            set;
        }
        public bool IsFooter
        {
            get;
            set;
        }
        public bool IsLogoPath
        {
            get;
            set;
        }
        public bool IsPincode
        {
            get;
            set;
        }
        public bool IsTelephoneNumber
        {
            get;
            set;
        }
        public bool IsFaxNumber
        {
            get;
            set;
        }
        public bool IsEmailID
        {
            get;
            set;
        }
        public bool IsUrl
        {
            get;
            set;
        }
        public bool isGreeting
        {
            get;
            set;
        }
        public bool IsAddress
        {
            get;
            set;
        }
        public bool IsCityName
        {
            get;
            set;
        }
        public int CityId
        {
            get;
            set;
        }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool Flag { get; set; }
        public string LastSyncDate { get; set; }
        public string CityName { get; set; }


    }
}

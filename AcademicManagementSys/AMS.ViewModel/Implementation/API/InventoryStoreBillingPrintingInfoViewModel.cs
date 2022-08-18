using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryStoreBillingPrintingInfoViewModel : IInventoryStoreBillingPrintingInfoViewModel
    {
        public InventoryStoreBillingPrintingInfoViewModel()
        {
            InventoryStoreBillingPrintingInfoDTO = new InventoryStoreBillingPrintingInfo();
        }

        public InventoryStoreBillingPrintingInfo InventoryStoreBillingPrintingInfoDTO
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.GeneralUnitsID : new int();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.GeneralUnitsID = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.UnitName : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.UnitName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.CentreCode = value;
            }
        }
        public string Address
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.Address : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.Address = value;
            }
        }

        public string DisplayIcon
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.DisplayIcon : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.DisplayIcon = value;
            }
        }
        public string Footer
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.Footer : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.Footer = value;
            }
        }
        public string LogoPath
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.LogoPath : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.LogoPath = value;
            }
        }
        public string Pincode
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.Pincode : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.Pincode = value;
            }
        }
        public string TelephoneNumber
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.TelephoneNumber : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.TelephoneNumber = value;
            }
        }
        public string FaxNumber
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.FaxNumber : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.FaxNumber = value;
            }
        }
        public string EmailID
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.EmailID : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.EmailID = value;
            }
        }

        public string Url
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.Url : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.Url = value;
            }
        }
        public string Greeting
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.Greeting : string.Empty;
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.Greeting = value;
            }
        }
        public bool isGreeting
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.isGreeting : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.isGreeting = value;
            }
        }
        public bool IsFooter
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsFooter : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsFooter = value;
            }
        }
        public bool IsLogoPath
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsLogoPath : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsLogoPath = value;
            }
        }
        public bool IsPincode
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsPincode : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsPincode = value;
            }
        }
        public bool IsTelephoneNumber
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsTelephoneNumber : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsTelephoneNumber = value;
            }
        }
        public bool IsFaxNumber
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsFaxNumber : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsFaxNumber = value;
            }
        }
        public bool IsEmailID
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsEmailID : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsEmailID = value;
            }
        }
        public bool IsUrl
        {
            get
            {
                return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsUrl : new bool();
            }
            set
            {
                InventoryStoreBillingPrintingInfoDTO.IsUrl = value;
            }
        }
        public Int32 CreatedBy
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.CreatedBy > 0) ? InventoryStoreBillingPrintingInfoDTO.CreatedBy : new Int32(); }
            set { InventoryStoreBillingPrintingInfoDTO.CreatedBy = value; }
        }
        public String CreatedDate
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.CreatedDate != null) ? InventoryStoreBillingPrintingInfoDTO.CreatedDate : String.Empty; }
            set { InventoryStoreBillingPrintingInfoDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.ModifiedBy > 0) ? InventoryStoreBillingPrintingInfoDTO.ModifiedBy : new Int32(); }
            set { InventoryStoreBillingPrintingInfoDTO.ModifiedBy = value; }
        }
        public String ModifiedDate
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.ModifiedDate != null) ? InventoryStoreBillingPrintingInfoDTO.ModifiedDate : String.Empty; }
            set { InventoryStoreBillingPrintingInfoDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.DeletedBy > 0) ? InventoryStoreBillingPrintingInfoDTO.DeletedBy : new Int32(); }
            set { InventoryStoreBillingPrintingInfoDTO.DeletedBy = value; }
        }
        public String DeletedDate
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.DeletedDate != null) ? InventoryStoreBillingPrintingInfoDTO.DeletedDate : String.Empty; }
            set { InventoryStoreBillingPrintingInfoDTO.DeletedDate = value; }
        }
        public bool IsDeleted
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null) ? InventoryStoreBillingPrintingInfoDTO.IsDeleted : false; }
            set { InventoryStoreBillingPrintingInfoDTO.IsDeleted = value; }
        }
        public string LastSyncDate
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.LastSyncDate != null) ? InventoryStoreBillingPrintingInfoDTO.LastSyncDate : string.Empty; }
            set { InventoryStoreBillingPrintingInfoDTO.LastSyncDate = value; }
        }
        public string CityName
        {
            get { return (InventoryStoreBillingPrintingInfoDTO != null && InventoryStoreBillingPrintingInfoDTO.CityName != null) ? InventoryStoreBillingPrintingInfoDTO.CityName : string.Empty; }
            set { InventoryStoreBillingPrintingInfoDTO.CityName = value; }
        }

    }
}

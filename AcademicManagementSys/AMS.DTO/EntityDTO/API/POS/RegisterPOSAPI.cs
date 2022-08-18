using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class RegisterPOSAPI : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int POSMasterID
        {
            get;
            set;
        }

        public string TokenCode
        {
            get;
            set;
        }

        public string TimeZone
        {
            get;
            set;
        }

        public int CounterMstID
        {
            get;
            set;
        }


        public int CreatedBy
        {
            get;
            set;
        }

        public string DeviceToken
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public string InvSaleMasterXML
        {
            get;
            set;
        }
        public string InvSaleTransactionXML
        {
            get;
            set;
        }
        public string InvSaleVoucherXML
        {
            get;
            set;
        }
        public string InvSaleReturnMasterXML
        {
            get;
            set;
        }
        public string InvSaleReturnTransactionXML
        {
            get;
            set;
        }
        public string InvSaleReturnVoucherXML
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public string BaseUoMcode
        {
            get;
            set;
        }
        public string BaseBarCode
        {
            get;
            set;
        }
        public string ItemCategoryCode
        {
            get;
            set;
        }
        public int GenTaxGroupMasterId
        {
            get;
            set;
        }
        public int GeneralItemCodeID
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string UomCode
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public decimal ConversionFactor
        {
            get;
            set;
        }
        public string ItemDisplayFromDate
        {
            get;
            set;
        }
        public string itemDisplayUpto
        {
            get;
            set;
        }
        public int TaxGroupID
        {
            get;
            set;
        }
        public decimal TaxInPercentage
        {
            get;
            set;
        }
        public string CreatedDate
        {
            get;
            set;
        }
        public string ModifiedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public bool Flag
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public string LastSyncDate
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int AccBalancesheetID
        {
            get;
            set;
        }
        public int InventoryCounterLogID
        {
            get;
            set;
        }
        public string KeyField
        {
            get;
            set;
        }
        public string DisplayFormat
        {
            get;
            set;
        }
        public string CurrentNumber
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public Int16 StartNumber
        {
            get;
            set;
        }
        public string Prefix
        {
            get;
            set;
        }
        public string Seperator
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
    }
}

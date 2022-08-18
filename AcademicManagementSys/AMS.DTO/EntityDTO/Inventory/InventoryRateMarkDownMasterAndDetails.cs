using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRateMarkDownMasterAndDetails : BaseDTO
    {
        public Int64 ID 
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        public string ItemName { get; set; }
        public string TransactionDate
        {
            get;
            set;
        }

        public decimal RateMarkDownAmount
        {
            get;
            set;
        }

        public Int16 BalanceSheetID
        {
            get;
            set;
        }

        public Int64 RateMarkDownDetailID
        {
            get;
            set;
        }

        public Int64 RateMarkDownMasterID
        {
            get;
            set;

        }
        public int ItemID 
        {
            get;
            set;

        }
        public decimal RateDecreaseByPercentage
        {
            get;
            set;
        }
        public string CategoryDescription
        {
            get;
            set;
        }
        public string CategoryCode
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
        public string SelectedXml { get; set; }

    }
}

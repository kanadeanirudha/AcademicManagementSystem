using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryDatewiseItemTransaction : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public string ItemName { get; set; }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal PurchaseRate
        {
            get;
            set;
        }
        public decimal RetailRate
        {
            get;
            set;
        }
        public DateTime TransactionDate
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
    }
}
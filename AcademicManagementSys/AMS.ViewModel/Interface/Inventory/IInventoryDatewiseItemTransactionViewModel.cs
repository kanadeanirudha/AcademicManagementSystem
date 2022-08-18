using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IInventoryDatewiseItemTransactionViewModel
    {
        InventoryDatewiseItemTransaction InventoryDatewiseItemTransactionDTO { get; set; }
         Int64 ID
        {
            get;
            set;
        }
         int ItemID
        {
            get;
            set;
        }
         decimal Quantity
        {
            get;
            set;
        }
         decimal PurchaseRate
        {
            get;
            set;
        }
         decimal RetailRate
        {
            get;
            set;
        }
         DateTime TransactionDate
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}

using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IInventoryPurchaseMasterAndTransactionViewModel
    {
        InventoryPurchaseMasterAndTransaction InventoryPurchaseMasterAndTransactionDTO { get; set; }

        //---------------------------------------InventoryPurchaseMaster-----------------------------
         int ID
        {
            get;
            set;
        }
         string TransactionDate
        {
            get;
            set;
        }
         string BillNumber
        {
            get;
            set;
        }
         decimal BillAmount
        {
            get;
            set;
        }
         string SupplierName
        {
            get;
            set;
        }
         int BalanceSheetID
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

        //---------------------------------------InventoryPurchaseTransaction-----------------------------
         int PurcahseTransactionID
        {
            get;
            set;
        }
         int PurchaseMasterID
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
         decimal Rate
        {
            get;
            set;
        }
         int UnitID
         {
             get;
             set;
         }
         string UnitCode
         {
             get;
             set;
         }
         int LocationID
         {
             get;
             set;
         }
         string Location
         {
             get;
             set;
         }
         string errorMessage { get; set; }
         string SelectedBalanceSheet { get; set; }
    }
}

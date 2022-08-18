using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IInventorySalesMasterAndTransactionViewModel
    {
        InventorySalesMasterAndTransaction InventorySalesMasterAndTransactionDTO { get; set; }
        //---------------------------------------InventorySalesMaster-----------------------------
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
         string CustomerName
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
        //--------------------------------------InventorySalesTransaction------------------------------
         int SalesTransactionID
        {
            get;
            set;
        }
         int SaleMasterID
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

         string errorMessage { get; set; }
         string SelectedBalanceSheet { get; set; }
         List<InventoryInWardMasterAndInWardDetails> systemseeting { get; set; }
         string FieldName { get; set; }
         int FieldValue { get; set; }
    }
}

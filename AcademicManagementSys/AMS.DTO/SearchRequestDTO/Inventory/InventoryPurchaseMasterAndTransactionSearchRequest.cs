using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryPurchaseMasterAndTransactionSearchRequest : Request
    {
        //---------------------------------------InventoryPurchaseMaster-----------------------------
        public int ID
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string BillNumber
        {
            get;
            set;
        }
        public decimal BillAmount
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
        public int BalanceSheetID
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public Int16 AccBalsheetMstID { get; set; }

        //---------------------------------------InventoryPurchaseTransaction-----------------------------
        public int InvPurchaseMasterID
        {
            get;
            set;
        }
        public int InvItemID
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }

    }
}

using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
     public class InventoryItemSaleReturnMasterSearchRequest : Request
    {
        //--------------------------------------InvSalesRetrunTransaction-----------------------------
        public int InvSalesRetrunMasterID { get; set; }
        public string TransactionDate { get; set; }
        public string BillNumber { get; set; }
        public decimal SalesReturnAmount { get; set; }
        public string CustomerName { get; set; }
        public int BalanceSheetID { get; set; }
        public int CounterLogID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public decimal PaymentByCustomer { get; set; }
        public decimal ReturnChange { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }

        //--------------------------------------InvSalesRetrunTransaction------------------------------
        public int InvSalesRetrunTransactionID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int GenTaxGroupMasterID { get; set; }

        //-----------------------------common property----------------
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int RowLength { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }     
   


        //--------------------------------Extra Property-----------------------------------
        public int CustomerID { get; set; }
        public string CustomerType { get; set; }
        public int InvBufferSalesMasterID { get; set; }        
    }
}

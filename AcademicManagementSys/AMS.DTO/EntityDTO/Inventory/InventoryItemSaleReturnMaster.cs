using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryItemSaleReturnMaster : BaseDTO
    {
        //--------------------------------------InvSalesRetrunTransaction-----------------------------
        public int InvSalesReturnMasterID { get; set; }
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
        public decimal DeliveryCharge { get; set; }

        //--------------------------------------InvSalesRetrunTransaction------------------------------
        public int InvSalesRetrunTransactionID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public string ExpiryDate { get; set; }
        
        //-----------------------------common property----------------
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate  { get; set; }

        //-------------------------------------Extra Property------------------------------
        public string ItemName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerType { get; set; }
        public int InvBufferSalesMasterID { get; set; }
        public string CustomerContactNo { get; set; }
        public decimal ItemAmount { get; set; }
        public int InvSalesDetailsID { get; set; }
        public string UnitCode { get; set; }
        public string CustomerAddress { get; set; }
        public string CounterName { get; set; }
        public string BatchNumber { get; set; }
        public decimal DiscountInPercentage { get; set; }
        public int ReturnQuantity { get; set; }
        public int TotalItem { get; set; }
        public decimal TotalReturnAmount { get; set; }
        public string BillDate { get; set; }
        public string Customer { get; set; }
        public decimal TaxInPercentage { get; set; }
        public decimal BillAmount { get; set; }
        public int AccountSessionID { get; set; }
        public decimal RoundUpAmount { get; set; }
        public decimal NetAmount { get; set; }

        //For XML
        public string ReturnItemDetailxml { get; set; }

         
        //public decimal Discount { get; set; }        
        //       
        //public bool BillPrintStatus { get; set; }
        //public int SalesTransactionID { get; set; }
        //public int SaleMasterID { get; set; }       
        //public int UnitID { get; set; }
        //public string CurrencyCode { get; set; }
        //public string EmployeeName { get; set; }
        //public string errorMessage { get; set; }
        //public string SelectedBalanceSheet { get; set; }
        //public string XMLstring { get; set; }
        //public string CentreCode { get; set; }
        //public string AvailableStock { get; set; }
        //public string MachineCode { get; set; }
        //
        //public string CounterOpeningCash { get; set; }
        //public int CounterLoginStatus { get; set; }
        //public int LoginUserCount { get; set; }
        //public string CounterClosingCash { get; set; }
        //public int CounterID { get; set; }
        //public int InvCounterApplicableDetailsID { get; set; }
        //public string SelectedCounterID { get; set; }
        //public string PrintingLine1 { get; set; }
        //public string PrintingLine2 { get; set; }
        //public string PrintingLine3 { get; set; }
        //public string PrintingLine4 { get; set; }
        //public Int16 AccBalsheetMstID { get; set; }
        //public decimal TodaySale { get; set; }
    }
}

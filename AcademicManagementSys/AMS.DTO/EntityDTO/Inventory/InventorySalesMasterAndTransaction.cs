using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventorySalesMasterAndTransaction : BaseDTO
    {
        //---------------------------------------InventorySalesMaster-----------------------------
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
        public decimal TotalBillAmount
        {
            get;
            set;
        }
        public int TotalItem
        {
            get;
            set;
        }
        
        public decimal Discount
        {
            get;
            set;
        }
        public decimal Tax
        {
            get;
            set;
        }
        public int GeneralTaxGroupID { get; set; }
        public int BatchID { get; set; }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string ExpiryDate
        {
            get;
            set;
        } 
        public string BatchNumber { get; set; }
        public decimal DiscountInPercentage
        {
            get;
            set;
        }
        
        public decimal RoundUpAmount
        {
            get;
            set;
        }
        public decimal ItemAmount
        {
            get;
            set;
        }
        
        public string CustomerName
        {
            get;
            set;
        }
        public string CustomerContactNo
        {
            get;
            set;
        }
        public string CustomerAddress
        {
            get;
            set;
        }
        public string CustomerType
        {
            get;
            set;
        }
        public int BalanceSheetID
        {
            get;
            set;
        }
        public int CustomerID
        {
            get;
            set;
        }
        public bool BillPrintStatus
        {
            get;
            set;
        }
        public bool IsExpiry
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

        //--------------------------------------InventorySalesTransaction------------------------------
        public int SalesTransactionID
        {
            get;
            set;
        }
        public int SaleMasterID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public int InvSalesDetailsID
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
        public decimal Rate
        {
            get;
            set;
        }
        public int CounterLogID
        {
            get;
            set;
        }

        public int UnitID { get; set; }
        public string UnitCode { get; set; }
        public string CurrencyCode { get; set; }

        public int LocationID { get; set; }
        public string Location { get; set; }
        public string EmployeeName { get; set; }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public string XMLstring { get; set; }
        public string CentreCode { get; set; }
        public string AvailableStock { get; set; }
        public string MachineCode { get; set; }
        public int AccountSessionID { get; set; }
        public string CounterName { get; set; }
        public string CounterOpeningCash { get; set; }
        public int CounterLoginStatus { get; set; }
        public int LoginUserCount { get; set; }
        public string CounterClosingCash { get; set; }
        public int CounterID { get; set; }
        public int InvCounterApplicableDetailsID { get; set; }
        public string SelectedCounterID { get; set; }
        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }
        public Int16 AccBalsheetMstID { get; set; }
        public decimal TodaySale { get; set; }
        public decimal LocationWiseSale { get; set; }
        public decimal TotalTaxAmount{ get; set; }
        public decimal TotalGrossAmount{ get; set; }
        public decimal TotalDiscount { get; set; }
        public string HoldBillReference { get; set; }
        public decimal TaxInPercentage{ get; set; }
        public decimal DeliveryCharge { get; set; }
        public int OpenBillCount { get; set; }
        public decimal PaymentByCustomer{ get; set; }
        public decimal ReturnChange { get; set; }
        public decimal NetAmount { get; set; }

        public string ActionOn { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public string FieldName
        {
            get;
            set;
        }
        public int FieldValue
        {
            get;
            set;
        }
        public string PolicyApplicableStatus
        {
            get;
            set;
        }
        public string PolicyDefaultAnswer
        {
            get;
            set;
        }
        public string PolicyCode
        {
            get;
            set;
        }
        public decimal RateIncludingtax
        {
            get;
            set;
        }
        public decimal TodaysTotalSale
        {
            get;
            set;
        }
        public decimal TotalSaleReturnAmount
        {
            get;
            set;
        }

        public decimal TotalBillAmountIncludeTaxTemplate
        {
            get;
            set;
        }
    }
}

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryPurchaseMasterAndTransaction : BaseDTO
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
        public string CentreCode
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        public string ParameterXml
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

        //---------------------------------------InventoryPurchaseTransaction-----------------------------
        public int PurcahseTransactionID
        {
            get;
            set;
        }

        public int PurchaseMasterID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public string ItemName
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
        public int UnitID
        {
            get;
            set;
        }
        public string UnitCode
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedBalanceSheet { get; set; }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public decimal TaxRate { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public decimal taxpercentage { get; set; }
        public decimal Discount
        { get; set; }
        public decimal discountpercentage
        { get; set; }
        public bool IsRateInclusiveTax
        {
            get;
            set;
        }
        public decimal Hamali
        {
            get;
            set;
        }
        public decimal OtherExpenses
        {
            get;
            set;
        }
        public decimal TotalBillAmountincludingTax
        {
            get;
            set;
        }
        public bool Isexpiry
        {
            get;
            set;
        }
        public decimal RoundUpAmount
        {
            get;
            set;
        }
        public decimal RateID
        {
            get;
            set;
        }
        public int BatchID
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string ActionOn { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
    }
}

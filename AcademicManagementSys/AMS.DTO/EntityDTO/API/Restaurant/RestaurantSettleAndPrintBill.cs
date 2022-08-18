using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RestaurantSettleAndPrintBill : BaseDTO
    {
        public int ID { get; set; }
        public int InventorySaleMasterID{ get; set; }
        public int RestaurantTableOrderID { get; set; }
        public string GlobalInvoiceNumber { get; set; }
        public string TransactionDate { get; set; }
        public string CentreCode { get; set; }
        public decimal BillAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string DeliveryCharge { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal PaymentByCustomer { get; set; }
        public decimal ReturnChange { get; set; }
        public int CounterID { get; set; }
        public decimal RoundUpAmount { get; set; }
        public string Customer { get; set; }
        public bool PaymentMode { get; set; }
        public string BillRelevantTo { get; set; }
        public string CustomerCode { get; set; }
        public int InventoryCounterLogID { get; set; }
        public string ItemNumber { get; set; }
        public string MenuName { get; set; }
        public int GeneralItemCodeID { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountInPercentage { get; set; }
        public string TaxInPercentage { get; set; }
        public string Quantity { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public string Price { get; set; }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string UOMCode { get; set; }
        public string BillNumber { get; set; }        
        public decimal ItemAmount { get; set; }
        public int GeneralUnitsID { get; set; }
        public byte PaidUnpaidFlag { get; set; }
        public decimal LocalInvoiceNumber { get; set; }
        public string TransactionNumber { get; set; }
        public bool IsPaid { get; set; }
        public bool IsAvailableForPOS { get; set; }
        
        public string ItemName { get; set; }
        public int VariationMasterId { get; set; }
        public string TableNumber { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Status
        { get; set; }
        public int SalePromotionActivityDetailsID
        {
            get;
            set;
        }
        public decimal DiscountInPercent { get; set; }
        public bool PromotionActivityFlag { get; set; }
        public bool IsRestaurant { get; set; }
        public int SaleTransactionID { get; set; }
    }


}

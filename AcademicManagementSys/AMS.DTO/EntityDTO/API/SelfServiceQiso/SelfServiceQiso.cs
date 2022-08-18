using AMS.Base.DTO;
namespace AMS.DTO
{
    public class SelfServiceQiso : BaseDTO
    {
        public int ID { get; set; }
        public string TransacationDate { get; set; }
        public string TransactionUpToDate { get; set; }
        public string TableNumber { get; set; }
        public string TableVariant { get; set; }
        public string TotalMembers { get; set; }
        public int OrderByID { get; set; }
        public string OrderStatus { get; set; }
        public string KOTStatus { get; set; }
        public int BillPaidStatus { get; set; }
        public string TotalBillAmt { get; set; }
        public string CentreCode { get; set; }
        public int GeneralUnitsId { get; set; }
        public string PaidBillNumber { get; set; }
        public int RestaurantTableOrdersID { get; set; }
        public string OrderDateTime { get; set; }
        public string ExpectedTimeGivenForOrder { get; set; }
        public string KOTNumbe { get; set; }
        public string OrderReceiveDateTime { get; set; }
        public bool IsOrderPostedInBill { get; set; }
        public int RestaurantTableOrdersDetailID { get; set; }
        public int ItemID { get; set; }
        public string Qty { get; set; }
        public string OrderXML { get; set; }
        public int GeneralItemMasterID { get; set; }
        public string UomCode { get; set; }
        public string IsBOMRelevant { get; set; }
        public int InventoryVariationMasterID { get; set; }
        public int Price { get; set; }
        public int InventoryLocationMasterID { get; set; }
        public string MenuName { get; set; }
        public short IsRelatedWithCafe { get; set; }        
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public short IsOrderServed { get; set; }
        public string PaymentReferenceCode { get; set; }
        public bool IsTakeAway{ get; set; }

        public int InventorySaleMasterID { get; set; }
        public bool IsBillPaid { get; set; }
        
        public int RestaurantTableOrderID { get; set; }
        public string GlobalInvoiceNumber { get; set; }
        public string TransactionDate { get; set; }
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
        public bool IsAvailableForPOS { get; set; }
        public string BillRelevantTo { get; set; }
        public string CustomerCode { get; set; }
        public int InventoryCounterLogID { get; set; }
        public string ItemNumber { get; set; }
        public int GeneralItemCodeID { get; set; }
        public decimal TaxAmount { get; set; }
        public bool DiscountAmount { get; set; }
        public bool DiscountInPercentage { get; set; }
        public string TaxInPercentage { get; set; }
        public string Quantity { get; set; }
        public int GenTaxGroupMasterID { get; set; }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string UOMCode { get; set; }
        public string BillNumber { get; set; }
        public decimal ItemAmount { get; set; }
        public int GeneralUnitsID { get; set; }
        public int Status
        { get; set; }

        public string SaleTransactionXML { get; set; }
        public decimal TotalBillAmount { get; set; }
    }
}

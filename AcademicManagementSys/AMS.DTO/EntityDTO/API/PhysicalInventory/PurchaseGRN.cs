using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class PurchaseGRN : BaseDTO
    {
        public int ID{get;set;}
        public int PurchaseOrderMasterID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public int PurchaseGRNMasterID { get; set; }
        public int PurchaseGRNDetailsID{ get;set;}
        public string GRNNumber { get; set; }
        public bool Received { get; set; }
        public string GRNTransDate { get; set; }
        public bool IsLocked { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate{ get; set;}
        public string ItemName{ get;set; }
        public decimal ReceivedQuantity{ get;set;}
        public decimal ReceivedQuantityPerItem { get; set; }
        public decimal RemainingQuantity{get; set;}
        public int ReceivingLocationID {get;set;}
        public int StorageLocationID { get; set; }
        public string XMLstring { get; set; }
        public string StorageLocationName{get; set;}
        public string ReceivingLocationName{get;set;}
        public string Remark{get; set;}
        public int BatchID{ get;set;}
        public decimal BatchQuantity{ get;set;}
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int ItemNumber{ get; set;}
        public string BarCode{get;set;}
        public string OrderUomCode{ get;set; }
        public int GeneralItemCodeID{get;set;}
        public decimal BaseUOMQuantity{   get;  set; }
        public string BaseUOMCode {  get; set; }
        public byte SerialAndBatchManagedBy{ get;  set; }
        public decimal LockedGRNQuantity{get;set; }
        public bool GRNIsLockedStatusFlag{get; set;}
        public decimal GrossAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Freight { get; set; }
        public decimal ShippingHandling { get; set; }
        public string ShelfLife{get; set;}
        public string RemainingShelfLife { get;set;}
        public int VendorID{ get; set;}
        public bool ReturnGoods { get;set;}
        public string VendorName { get; set; }
        public int VendorNumber { get; set; }
        public string SearchWord { get; set; }
        public int PurchaseOrderType { get; set; }
        public byte POStatus { get; set; }
        public string PurchaseBillID { get; set; }
        public decimal SoldQuantity { get; set; }
        public bool IsBatchSold { get; set; }
        public string SaleDate { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

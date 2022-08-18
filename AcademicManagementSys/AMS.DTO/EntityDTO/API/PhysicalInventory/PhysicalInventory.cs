using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class PhysicalInventory : BaseDTO
    {
        public int ID { get; set; }
        public string TransactionDate { get; set; }
        public int InventoryPhysicalStockAdjustmentID { get; set; }
        public int ItemNumber { get; set; }
        public string ItemBarCode { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public short Action { get; set; }
        public short ActionStatus { get; set; }
        public int FromLocation { get; set; }
        public Int16 GeneralUnitsID { get; set; }
        public decimal CurrentStockQty { get; set; }
        public string SaleUOM { get; set; }
        public string BaseUOM { get; set; }
        public string PhysicalInventoryStockDetails { get; set; }
        public string PhysicalInventoryVoucherXml { get; set; }
        public string ItemDescription { get; set; }
        public decimal ConversionFactor { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}

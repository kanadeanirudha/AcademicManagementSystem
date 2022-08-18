using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RestaurantKOTOrderDetails : BaseDTO
    {
        public  int ID { get; set; }
        public string TransactionDate { get; set; }
        public string RestaurantKOTOrderDetailTransactionDate { get; set; }
        public string ExpectedTimeForDelevery { get; set; }
        public int RestaurantKOTOrderID { get; set; }
        public int RestaurantTableOrdersID { get; set; }
        public int RestaurantKOTOrderDetailID { get; set; }
        public int RestaurantKOTOrderDetailRestaurantKOTOrderID { get; set; }
        public int RestaurantKOTOrderDetailJobStatus { get; set; }
        public decimal Qty { get; set; }
        public string Remark { get; set; }        
        public string KOTOrderXML { get; set; }
        public string CentreCode { get; set; }
        public int JobStatus { get; set; }
        public int CookById { get; set; }
        public int GeneralUnitsId { get; set; }
        public int GeneralItemMasterID { get; set; }
        public string UomCode { get; set; }
        public int IsBOMRelevant { get; set; }
        public decimal Price { get; set; }
        public short ResponseFlag { get; set; }        
        public int InventoryVariationMasterID { get; set; }
        public int InventoryLocationMasterID { get; set; }
        public string MenuName { get; set; }
        public string TableNumber { get; set; }
        public short IsRelatedWithCafe { get; set; }
        public int RestaurantTableOrdersDetailID { get; set; }
        public string ComplitedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsTakeAway { get; set; }
        public string PaidBillNumber { get; set; }
        public int SaleMasterID { get; set; }
        public string LocalInvoiceNumber { get; set; }
        public int RestaurantBillOrderdetailsID { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public bool StatusFlag { get; set; }
        public string ItemNumber { get; set; }
        public decimal Quantity { get; set; }
        public int SalePromotionActivityDetailsID { get; set; }
        public string ItemName { get; set; }
        public bool IsRestaurant { get; set; }
    }
}

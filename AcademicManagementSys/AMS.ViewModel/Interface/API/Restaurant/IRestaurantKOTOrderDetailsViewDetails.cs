namespace AMS.ViewModel
{
    public class IRestaurantKOTOrderDetailsViewModel
    {
        public int ID { get; set; }
        public string TransactionDate { get; set; }
        public string RestaurantKOTOrderDetailTransactionDate { get; set; }
        public string ExpectedTimeForDelevery { get; set; }
        public int RestaurantKOTOrderID { get; set; }
        public int RestaurantTableOrdersID { get; set; }
        public int RestaurantKOTOrderDetailID { get; set; }
        public int RestaurantKOTOrderDetailRestaurantKOTOrderID { get; set; }
        public int RestaurantKOTOrderDetailJobStatus { get; set; }
        public string Qty { get; set; }
        public string CentreCode { get; set; }
        public int JobStatus { get; set; }
        public int CookById { get; set; }
        public int GeneralUnitsId { get; set; }
        public int GeneralItemMasterID { get; set; }
        public string UomCode { get; set; }
        public string IsBOMRelevant { get; set; }
        public int Price { get; set; }
        public int InventoryVariationMasterID { get; set; }
        public int InventoryLocationMasterID { get; set; }
        public string MenuName { get; set; }
        public string TableNumber { get; set; }
        public int IsRelatedWithCafe { get; set; }
        public int RestaurantTableOrdersDetailID { get; set; }
        public int ComplitedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}

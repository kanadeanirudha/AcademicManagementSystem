namespace AMS.ViewModel
{
    public class IRestaurantTableOrderViewModel
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
        public int PaidBillNumber { get; set; }
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
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

       
    }
}

using System;
namespace AMS.ViewModel
{
    public class IRestaurantCategoryAndMenuViewModel
    {
        public int ID { get; set; }
        public string MenuCategory { get; set; }
        public int InventoryRecipeMenuCategoryID { get; set; }
        public string MenuCategoryCode { get; set; }
        public int MenuCategoryID { get; set; }
        public string MenuType { get; set; }
        public string UomCode { get; set; }
        public string UnitName { get; set; }
        public string CentreCode { get; set; }
        public int InventoryLocationMasterID { get; set; }
        public int GeneralUnitsID { get; set; }
        public string MenuDescription { get; set; }
        public int IsBOMRelevant { get; set; }
        public int InventoryVariationMasterID { get; set; }
        public string BillingItemName { get; set; }
        public int Price { get; set; }
        public int RelatedWithCafe { get; set; }
        public int GeneralItemMasterID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

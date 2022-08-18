using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class RestaurantCategoryAndMenu : BaseDTO
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
        public decimal Price { get; set; }
        public int RelatedWithCafe { get; set; }
        public int GeneralItemMasterID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsRestaurant { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }

        public string RecipeMenuImage { get; set; }

        public string Name { get; set; }
        public int SalePromotionActivityMasterID { get; set; }
        public int SalePromotionPlanDetailsId { get; set; }
        public decimal DiscountInPercent { get; set; }
        public bool PromotionActivityFlag { get; set; }
        public int SalePromotionActivityDetailsID { get; set; }

        public string LastSyncDate { get; set; }
        public int RecipeMasterID { get; set; }

        public byte ProductConcessionFreeType { get; set; }
        public bool IsCoupanOrGiftVoucherApplicable { get; set; }
        public Int16 HowManyQtyToBuy { get; set; }
        public Int16 GiftItemQty { get; set; }
        public string PlanTypeCode { get; set; }
        public string RecipeVariationDescription { get; set; }
        public bool Flag { get; set; }
    }

   
}

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRecipeDetails : BaseDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VersionCode { get; set; }
        public int PrimaryItemOutputID { get; set; }
        public int OldRecipeID { get; set; }
        public string BOMRelevant { get; set; }
        public string BillingItemName { get; set; }
        public string ArabicTransalation { get; set; }
        public string RecipeMenuImage { get; set; }
        public decimal Price { get; set; }
        public byte RelatedWithCafe { get; set; }

        public Int16 InventoryVariationMasterID { get; set; }
        public Int16 InventoryRecipeMasterID { get; set; }
        public string RecipeVariationTitle { get; set; }
        public string RecipeVariationDescription { get; set; }
        public bool IsActive { get; set; }
        public bool Flag { get; set; }

        public int InventoryRecipeFormulaDetailsID { get; set; }
        public int ItemNumber { get; set; }
        public bool InoutType { get; set; }
        public decimal Quantity { get; set; }
        public string UOMCode { get; set; }
        public Int16 RecipeMasterID { get; set; }
        public Int16 OrderNumber { get; set; }
        public bool IsOptionalIngrediant { get; set; }
        public decimal cost { get; set; }

         
        //Common fields
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string LastSyncDate { get; set; }

    }


}

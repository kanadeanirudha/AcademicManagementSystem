using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryRecipeDetailsViewModel : IInventoryRecipeDetailsViewModel
    {
        public InventoryRecipeDetailsViewModel()
        {
            InventoryRecipeDetailsDTO = new InventoryRecipeDetails();
        }
        public InventoryRecipeDetails InventoryRecipeDetailsDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.ID : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.ID = value;
            }
        }
        public string LastSyncDate
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.LastSyncDate != string.Empty) ? InventoryRecipeDetailsDTO.LastSyncDate : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.LastSyncDate = value;
            }
        }
        public string Title
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.Title != string.Empty) ? InventoryRecipeDetailsDTO.Title : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.Title = value;
            }
        }
        public string Description
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.Description != string.Empty) ? InventoryRecipeDetailsDTO.Description : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.Description = value;
            }
        }

        public string VersionCode
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.VersionCode != string.Empty) ? InventoryRecipeDetailsDTO.VersionCode : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.VersionCode = value;
            }
        }

        public int PrimaryItemOutputID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.PrimaryItemOutputID : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.PrimaryItemOutputID = value;
            }
        }

        public int OldRecipeID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.OldRecipeID : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.OldRecipeID = value;
            }
        }
        public string BOMRelevant
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.BOMRelevant != string.Empty) ? InventoryRecipeDetailsDTO.BOMRelevant : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.BOMRelevant = value;
            }
        }
        public string BillingItemName
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.BillingItemName != string.Empty) ? InventoryRecipeDetailsDTO.BillingItemName : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.BillingItemName = value;
            }
        }
        public string ArabicTransalation
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.ArabicTransalation != string.Empty) ? InventoryRecipeDetailsDTO.ArabicTransalation : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.ArabicTransalation = value;
            }
        }
        public string RecipeMenuImage
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.RecipeMenuImage != string.Empty) ? InventoryRecipeDetailsDTO.RecipeMenuImage : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.RecipeMenuImage = value;
            }
        }
        public decimal Price
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.Price : new decimal();
            }
            set
            {
                InventoryRecipeDetailsDTO.Price = value;
            }
        }
        public byte RelatedWithCafe
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.RelatedWithCafe : new byte();
            }
            set
            {
                InventoryRecipeDetailsDTO.RelatedWithCafe = value;
            }
        }
        // fields for varination master 

        public Int16 InventoryVariationMasterID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.InventoryVariationMasterID : new Int16();
            }
            set
            {
                InventoryRecipeDetailsDTO.InventoryVariationMasterID = value;
            }
        }
        public Int16 InventoryRecipeMasterID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.InventoryRecipeMasterID : new Int16();
            }
            set
            {
                InventoryRecipeDetailsDTO.InventoryRecipeMasterID = value;
            }
        }
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.RecipeVariationTitle != string.Empty) ? InventoryRecipeDetailsDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.RecipeVariationTitle = value;
            }
        }
        public string RecipeVariationDescription
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.RecipeVariationDescription != string.Empty) ? InventoryRecipeDetailsDTO.RecipeVariationDescription : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.RecipeVariationDescription = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.IsActive : false;
            }
            set
            {
                InventoryRecipeDetailsDTO.IsActive = value;
            }
        }
        //Fields for recipe formula details
        public int InventoryRecipeFormulaDetailsID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.InventoryRecipeFormulaDetailsID : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.InventoryRecipeFormulaDetailsID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.ItemNumber : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.ItemNumber = value;
            }
        }
        public bool InoutType
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.InoutType : false;
            }
            set
            {
                InventoryRecipeDetailsDTO.InoutType = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.Quantity : new decimal();
            }
            set
            {
                InventoryRecipeDetailsDTO.Quantity = value;
            }
        }
        public string UOMCode
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.UOMCode != string.Empty) ? InventoryRecipeDetailsDTO.UOMCode : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.UOMCode = value;
            }
        }
        public Int16 RecipeMasterID
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.RecipeMasterID : new Int16();
            }
            set
            {
                InventoryRecipeDetailsDTO.RecipeMasterID = value;
            }
        }
        public Int16 OrderNumber
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.OrderNumber : new Int16();
            }
            set
            {
                InventoryRecipeDetailsDTO.OrderNumber = value;
            }
        }
        public bool IsOptionalIngrediant
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.IsOptionalIngrediant : false;
            }
            set
            {
                InventoryRecipeDetailsDTO.IsOptionalIngrediant = value;
            }
        }
        public decimal cost
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.cost : new decimal();
            }
            set
            {
                InventoryRecipeDetailsDTO.cost = value;
            }
        }
        //Common fields
        public int CreatedBy
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.CreatedBy > 0) ? InventoryRecipeDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeDetailsDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.ModifiedBy != string.Empty) ? InventoryRecipeDetailsDTO.ModifiedBy : string.Empty;
            }
            set
            {
                InventoryRecipeDetailsDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeDetailsDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null && InventoryRecipeDetailsDTO.DeletedBy > 0) ? InventoryRecipeDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryRecipeDetailsDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null) ? InventoryRecipeDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeDetailsDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (InventoryRecipeDetailsDTO != null ? InventoryRecipeDetailsDTO.IsDeleted : new bool());
            }
            set
            {
                InventoryRecipeDetailsDTO.IsDeleted = value;
            }
        }


    }
}

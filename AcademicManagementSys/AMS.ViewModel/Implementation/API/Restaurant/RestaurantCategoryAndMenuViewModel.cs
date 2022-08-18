using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RestaurantCategoryAndMenuViewModel : IRestaurantCategoryAndMenuViewModel
    {
        public RestaurantCategoryAndMenuViewModel()
        {
             RestaurantCategoryAndMenuDTO = new RestaurantCategoryAndMenu();
        }
        public RestaurantCategoryAndMenu RestaurantCategoryAndMenuDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.ID > 0) ? RestaurantCategoryAndMenuDTO.ID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.ID = value;
            }
        }
        public int InventoryRecipeMenuCategoryID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.InventoryRecipeMenuCategoryID > 0) ? RestaurantCategoryAndMenuDTO.InventoryRecipeMenuCategoryID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.InventoryRecipeMenuCategoryID = value;
            }
        }

        public string MenuCategory
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.MenuCategory != string.Empty) ? RestaurantCategoryAndMenuDTO.MenuCategory : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.MenuCategory = value;
            }
        }

        public string MenuCategoryCode
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.MenuCategoryCode != string.Empty) ? RestaurantCategoryAndMenuDTO.MenuCategoryCode : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.MenuCategoryCode = value;
            }
        }

        public string MenuType
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.MenuType != string.Empty) ? RestaurantCategoryAndMenuDTO.MenuType : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.MenuType = value;
            }
        }

        public string UomCode
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.UomCode != string.Empty) ? RestaurantCategoryAndMenuDTO.UomCode : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.UomCode = value;
            }
        }

        public string UnitName
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.UnitName != string.Empty) ? RestaurantCategoryAndMenuDTO.UnitName : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.UnitName = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.CentreCode != string.Empty) ? RestaurantCategoryAndMenuDTO.CentreCode : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.CentreCode = value;
            }
        
        }

        public int InventoryLocationMasterID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.InventoryLocationMasterID > 0) ? RestaurantCategoryAndMenuDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.InventoryLocationMasterID = value;
            }
        }
        public int MenuCategoryID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.MenuCategoryID > 0) ? RestaurantCategoryAndMenuDTO.MenuCategoryID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.MenuCategoryID = value;
            }
        }

        public int GeneralUnitsID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.GeneralUnitsID > 0) ? RestaurantCategoryAndMenuDTO.GeneralUnitsID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.GeneralUnitsID = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.GeneralItemMasterID > 0) ? RestaurantCategoryAndMenuDTO.GeneralItemMasterID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.GeneralItemMasterID = value;
            }
        }
        public string MenuDescription
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.CentreCode != string.Empty) ? RestaurantCategoryAndMenuDTO.CentreCode : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.MenuDescription = value;
            }
        }

        public string BillingItemName
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.BillingItemName != string.Empty) ? RestaurantCategoryAndMenuDTO.BillingItemName : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.BillingItemName = value;
            }
        }

        public int IsBOMRelevant
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.IsBOMRelevant > 0) ? RestaurantCategoryAndMenuDTO.IsBOMRelevant : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.IsBOMRelevant = value;
            }
        }

        public int InventoryVariationMasterID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.InventoryVariationMasterID > 0) ? RestaurantCategoryAndMenuDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.InventoryVariationMasterID = value;
            }
        }
        public decimal Price
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.Price > 0) ? RestaurantCategoryAndMenuDTO.Price : new decimal();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.Price = value;
            }
        }
        public int RelatedWithCafe
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.RelatedWithCafe > 0) ? RestaurantCategoryAndMenuDTO.RelatedWithCafe : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.RelatedWithCafe = value;
            }
        }

       
        public int CreatedBy
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.CreatedBy > 0) ? RestaurantCategoryAndMenuDTO.CreatedBy : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                 return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.CreatedDate = value;
            }
        }

        public string ModifiedBy
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.ModifiedBy != string.Empty) ? RestaurantCategoryAndMenuDTO.ModifiedBy : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                 return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.DeletedBy > 0) ? RestaurantCategoryAndMenuDTO.DeletedBy : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null ? RestaurantCategoryAndMenuDTO.IsDeleted : new bool());
            }
            set
            {
                RestaurantCategoryAndMenuDTO.IsDeleted = value;
            }
        }
        public bool IsRestaurant
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null ? RestaurantCategoryAndMenuDTO.IsRestaurant : new bool());
            }
            set
            {
                RestaurantCategoryAndMenuDTO.IsRestaurant = value;
            }
        }
        public string CurrencyCode
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.CurrencyCode != string.Empty) ? RestaurantCategoryAndMenuDTO.CurrencyCode : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.CurrencyCode = value;
            }
        }
        public string CurrencyName
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.CurrencyName != string.Empty) ? RestaurantCategoryAndMenuDTO.CurrencyName : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.CurrencyName = value;
            }
        }

        public string Name
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.Name != string.Empty) ? RestaurantCategoryAndMenuDTO.Name : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.Name = value;
            }
        }
        public bool PromotionActivityFlag
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null ? RestaurantCategoryAndMenuDTO.PromotionActivityFlag : new bool());
            }
            set
            {
                RestaurantCategoryAndMenuDTO.PromotionActivityFlag = value;
            }
        }
        public int SalePromotionActivityMasterID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.SalePromotionActivityMasterID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.SalePromotionActivityMasterID = value;
            }
        }
        public int SalePromotionPlanDetailsId
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.SalePromotionPlanDetailsId : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.SalePromotionPlanDetailsId = value;
            }
        }
        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.SalePromotionActivityDetailsID = value;
            }
        }
        public decimal DiscountInPercent
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null) ? RestaurantCategoryAndMenuDTO.DiscountInPercent : new decimal();
            }
            set
            {
                RestaurantCategoryAndMenuDTO.DiscountInPercent = value;
            }
        }
        public string LastSyncDate
        {
            get
            {
                return (RestaurantCategoryAndMenuDTO != null && RestaurantCategoryAndMenuDTO.LastSyncDate != string.Empty) ? RestaurantCategoryAndMenuDTO.LastSyncDate : string.Empty;
            }
            set
            {
                RestaurantCategoryAndMenuDTO.LastSyncDate = value;
            }
        }
    }
}

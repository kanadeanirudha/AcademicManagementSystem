using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryItemMasterViewModel : IInventoryItemMasterViewModel
    {
        public InventoryItemMasterViewModel()
        {
            InventoryItemMasterDTO = new InventoryItemMaster();
            GeneralUnitMasterList = new List<GeneralUnitMaster>();
            InventoryItemCategoryMasterList = new List<InventoryItemCategoryMaster>();
            GeneralCurrencyMasterList = new List<GeneralCurrencyMaster>();
            GeneralTaxGroupMasterList = new List<GeneralTaxGroupMaster>();


        }
        public InventoryItemMaster InventoryItemMasterDTO { get; set; }
        public List<GeneralUnitMaster> GeneralUnitMasterList { get; set; }
        public List<InventoryItemCategoryMaster> InventoryItemCategoryMasterList { get; set; }
        public List<GeneralCurrencyMaster> GeneralCurrencyMasterList { get; set; }
        public List<GeneralTaxGroupMaster> GeneralTaxGroupMasterList { get; set; }

        public IEnumerable<SelectListItem> GeneralUnitMasterListItems
        {
            get
            {
                return new SelectList(GeneralUnitMasterList, "ID", "ShortCode");
            }
        }

        public IEnumerable<SelectListItem> InventoryItemCategoryListItems
        {
            get
            {
                return new SelectList(InventoryItemCategoryMasterList, "CategoryCode", "CategoryDescription");
            }
        }

        public IEnumerable<SelectListItem> GeneralCurrencyListItems
        {
            get
            {
                return new SelectList(GeneralCurrencyMasterList, "CurrencyCode", "CurrencyName");
            }
        }

        public IEnumerable<SelectListItem> GeneralTaxGroupListItems
        {
            get
            {
                return new SelectList(GeneralTaxGroupMasterList, "ID", "TaxGroupName");
            }
        }
        //-----------------------------Inventory Item Master--------------------------
        public int ID
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ID > 0) ? InventoryItemMasterDTO.ID : new int();
            }
            set
            {
                InventoryItemMasterDTO.ID = value;
            }
        }
        [Display(Name = "Item Name :")]
        [Required(ErrorMessage = "Item name should not be blank")]
        public string ItemName
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ItemName = value;
            }
        }
        [Display(Name = "Item Family :")]
        [Required(ErrorMessage = "Item family should not be blank")]
        public string ItemFamily
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ItemFamily : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ItemFamily = value;
            }
        }
        [Display(Name = "Packing Unit :")]
        //[Required(ErrorMessage = "Packing unit should not be blank")]
        public string PackingUnit
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.PackingUnit : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.PackingUnit = value;
            }
        }
        [Display(Name = "Packing Type :")]
        //[Required(ErrorMessage = "Packing type should not be blank")]
        public string PackingType
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.PackingType : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.PackingType = value;
            }
        }
        [Display(Name = "Item Code :")]
        [Required(ErrorMessage = "Item code should not be blank")]
        public string ItemCode
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ItemCode : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ItemCode = value;
            }
        }
        //[Display(Name = "Purchase Rate :")]
        //public decimal PurchaseRate
        //{
        //    get
        //    {
        //        return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.PurchaseRate > 0) ? InventoryItemMasterDTO.PurchaseRate : new decimal();
        //    }
        //    set
        //    {
        //        InventoryItemMasterDTO.PurchaseRate = value;
        //    }
        //}
        //[Display(Name = "Sale Rate :")]
        //public decimal SaleRate
        //{
        //    get
        //    {
        //        return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.SaleRate > 0) ? InventoryItemMasterDTO.SaleRate : new decimal();
        //    }
        //    set
        //    {
        //        InventoryItemMasterDTO.SaleRate = value;
        //    }
        //}

        [Display(Name = "Retail Rate :")]
        [Required(ErrorMessage = "Retail Rate should not be blank")]
        public decimal RetailRate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.RetailRate : new decimal();
            }
            set
            {
                InventoryItemMasterDTO.RetailRate = value;
            }
        }
        [Display(Name = "WholeSale Rate :")]
        public string WholeSaleRate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.WholeSaleRate : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.WholeSaleRate = value;
            }
        }
        [Display(Name = "Special Rate :")]
        public string SpecialRate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.SpecialRate : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.SpecialRate = value;
            }
        }
        [Display(Name = "MRP :")]
        public string MaximumRetialPrice
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.MaximumRetialPrice : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.MaximumRetialPrice = value;
            }
        }

        [Display(Name = "Is Sale Rate Depend On Purchase :")]
        public bool IsSaleRateDependOnPuchase
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsSaleRateDependOnPuchase : false;
            }
            set
            {
                InventoryItemMasterDTO.IsSaleRateDependOnPuchase = value;
            }
        }


        [Display(Name = "Sale Rate Factor In Percentage :")]
        [Required(ErrorMessage = "Sale Rate In Percentage should not be blank")]
        public decimal SaleRateFactorInPercentage
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.SaleRateFactorInPercentage : new decimal();
            }
            set
            {
                InventoryItemMasterDTO.SaleRateFactorInPercentage = value;
            }
        }


        [Display(Name = "Retail Rate Factor In Percentage :")]
        [Required(ErrorMessage = "Retail Rate In Percentage should not be blank")]
        public decimal RetailRateFactorInPercentage
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.RetailRateFactorInPercentage : new decimal();
            }
            set
            {
                InventoryItemMasterDTO.RetailRateFactorInPercentage = value;
            }
        }

        //public string POSCode
        //{
        //    get
        //    {
        //        return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.POSCode : string.Empty;
        //    }
        //    set
        //    {
        //        InventoryItemMasterDTO.POSCode = value;
        //    }
        //}
        [Display(Name = "Currency :")]
        [Required(ErrorMessage = "Currency should not be blank")]
        public string CurrencyCode
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.CurrencyCode : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.CurrencyCode = value;
            }
        }
        //public decimal CurrentStockQty
        //{
        //    get
        //    {
        //        return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.CurrentStockQty > 0) ? InventoryItemMasterDTO.CurrentStockQty : new decimal();
        //    }
        //    set
        //    {
        //        InventoryItemMasterDTO.CurrentStockQty = value;
        //    }
        //}
        public byte[] Picture
        {
            get;
            set;
        }
        [Display(Name = "Unit :")]
        [Required(ErrorMessage = "Please select Unit")]
        public int UnitID
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.UnitID > 0) ? InventoryItemMasterDTO.UnitID : new short();
            }
            set
            {
                InventoryItemMasterDTO.UnitID = value;
            }
        }

        [Display(Name = "Tax Group :")]
        public string GenTaxGroupMasterID
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.GenTaxGroupMasterID : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.GenTaxGroupMasterID = value;
            }
        }

        public string UnitCode
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.UnitCode = value;
            }
        }
        [Display(Name = "Category :")]
        [Required(ErrorMessage = "Please select Category")]
        public string ItemCategoryCode
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ItemCategoryCode = value;
            }
        }

        public string ItemCategoryDescription
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ItemCategoryDescription : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ItemCategoryDescription = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsActive : false;
            }
            set
            {
                InventoryItemMasterDTO.IsActive = value;
            }
        }

        public bool IsSerialNumber
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsSerialNumber : false;
            }
            set
            {
                InventoryItemMasterDTO.IsSerialNumber = value;
            }
        }

        public bool IsRateTaxesCentrerwise
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsRateTaxesCentrerwise : false;
            }
            set
            {
                InventoryItemMasterDTO.IsRateTaxesCentrerwise = value;
            }
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.CreatedBy > 0) ? InventoryItemMasterDTO.CreatedBy : new short();
            }
            set
            {
                InventoryItemMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryItemMasterDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ModifiedBy > 0) ? InventoryItemMasterDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryItemMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryItemMasterDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.DeletedBy > 0) ? InventoryItemMasterDTO.DeletedBy : new short();
            }
            set
            {
                InventoryItemMasterDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryItemMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        [Display(Name = "Is Expiry :")]
        public bool IsExpiry
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsExpiry : false;
            }
            set
            {
                InventoryItemMasterDTO.IsExpiry = value;
            }
        }
        [Display(Name = "Is Tax Inclusive :")]
        public bool IsTaxInclusive
        {
            get
            {
                return (InventoryItemMasterDTO != null) ? InventoryItemMasterDTO.IsTaxInclusive : false;
            }
            set
            {
                InventoryItemMasterDTO.IsTaxInclusive = value;
            }
        }

        public int ItemFamilyMasterID
        {
            get
            {              
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ItemFamilyMasterID > 0) ? InventoryItemMasterDTO.ItemFamilyMasterID : new int();
            }
            set
            {
                InventoryItemMasterDTO.ItemFamilyMasterID = value;           
            }
        }

        public int ItemPackingUnitMasterID
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ItemPackingUnitMasterID > 0) ? InventoryItemMasterDTO.ItemPackingUnitMasterID : new int();
            }
            set
            {
                InventoryItemMasterDTO.ItemPackingUnitMasterID = value;
            }
        }

        public int ItemPackingTypeMasterID
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ItemPackingTypeMasterID > 0) ? InventoryItemMasterDTO.ItemPackingTypeMasterID : new int();
            }
            set
            {
                InventoryItemMasterDTO.ItemPackingTypeMasterID = value;
            }
        }

        public int ActionID
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ActionID > 0) ? InventoryItemMasterDTO.ActionID : new int();
            }
            set
            {
                InventoryItemMasterDTO.ActionID = value;
            }
        }

        public string ActionOn
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ActionOn != "") ? InventoryItemMasterDTO.ActionOn : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ActionOn = value;
            }
        }
        public string ActionName
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.ActionName != "") ? InventoryItemMasterDTO.ActionName : string.Empty;
            }
            set
            {
                InventoryItemMasterDTO.ActionName = value;
            }
        }

        [Display(Name = "Min Indent Level:")]
        [Required(ErrorMessage = "Minimum indent level should not blank.")]
        public decimal MinIndentLevel
        {
            get
            {
                return (InventoryItemMasterDTO != null && InventoryItemMasterDTO.MinIndentLevel > 0) ? InventoryItemMasterDTO.MinIndentLevel : new decimal();
            }
            set
            {
                InventoryItemMasterDTO.MinIndentLevel = value;
            }
        }

    }
}

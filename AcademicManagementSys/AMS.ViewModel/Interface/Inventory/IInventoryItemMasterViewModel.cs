using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IInventoryItemMasterViewModel
    {
        InventoryItemMaster InventoryItemMasterDTO { get; set; }

        int ID
        {
            get;
            set;
        }
        string ItemName
        {
            get;
            set;
        }
        string ItemCode
        {
            get;
            set;
        }
        //decimal PurchaseRate
        //{
        //    get;
        //    set;
        //}
        //decimal SaleRate
        //{
        //    get;
        //    set;
        //}
        decimal RetailRate
        {
            get;
            set;
        }
        string WholeSaleRate
        {
            get;
            set;
        }
        string SpecialRate
        {
            get;
            set;
        }
        string MaximumRetialPrice
        {
            get;
            set;
        }
        bool IsSaleRateDependOnPuchase
        {
            get;
            set;
        }
        bool IsSerialNumber
        {
            get;
            set;
        }
        bool IsRateTaxesCentrerwise
        {
            get;
            set;
        }


        decimal SaleRateFactorInPercentage
        {
            get;
            set;
        }
        decimal RetailRateFactorInPercentage
        {
            get;
            set;
        }
        //string POSCode
        //{
        //    get;
        //    set;
        //}
        string CurrencyCode
        {
            get;
            set;
        }
        string ItemCategoryDescription
        {
            get;
            set;
        }


        //decimal CurrentStockQty { get; set; }
        byte[] Picture
        {
            get;
            set;
        }
        int UnitID
        {
            get;
            set;
        }
        string GenTaxGroupMasterID
        {
            get;
            set;
        }
        string UnitCode
        {
            get;
            set;
        }
        string ItemCategoryCode
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
        int ItemFamilyMasterID { get; set; }
        int ItemPackingUnitMasterID { get; set; }
        int ItemPackingTypeMasterID { get; set; }
        decimal MinIndentLevel { get; set; }
    }
}

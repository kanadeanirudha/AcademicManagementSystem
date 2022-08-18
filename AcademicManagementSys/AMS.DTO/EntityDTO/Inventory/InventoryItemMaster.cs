using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class InventoryItemMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public string ItemName
		{
			get;
			set;
		}
        public string ItemFamily
		{
			get;
			set;
		}
        public string PackingUnit
        {
            get;
            set;
        }
        public string PackingType
        {
            get;
            set;
        }
		public string ItemCode
		{
			get;
			set;
		}
		public decimal PurchaseRate
		{
			get;
			set;
		}
        public decimal SaleRate
		{
			get;
			set;
		}
        public decimal RetailRate
        {
            get;
            set;
        }
        public decimal RateDecreaseByPercentage
        {
            get;
            set;
        }
        public string WholeSaleRate
        {
            get;
            set;
        }
        public string SpecialRate
        {
            get;
            set;
        }
        public string MaximumRetialPrice
        {
            get;
            set;
        }
        public bool IsSaleRateDependOnPuchase
        {
            get;
            set;
        }
        public bool IsSerialNumber
        {
            get;
            set;
        }
        public bool IsRateTaxesCentrerwise
        {
            get;
            set;
        }
        
        
        public decimal SaleRateFactorInPercentage
        {
            get;
            set;
        }
        public decimal RetailRateFactorInPercentage
        {
            get;
            set;
        }
		public string POSCode
		{
			get;
			set;
		}
		public string CurrencyCode
		{
			get;
			set;
		}
        public string ItemCategoryDescription
		{
			get;
			set;
		}
      
       
        public decimal CurrentStockQty { get; set; }
		public byte[] Picture
		{
			get;
			set;
		}
		public int UnitID
		{
			get;
			set;
		}
        public string GenTaxGroupMasterID
        {
            get;
            set;
        }
        public string UnitCode
		{
			get;
			set;
		}
        public string ItemCategoryCode
        {
            get;
            set;
        }
		public bool IsActive
		{
			get;
			set;
		}
		public bool IsDeleted
		{
			get;
			set;
		}
		public int CreatedBy
		{
			get;
			set;
		}
		public DateTime CreatedDate
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}
        public string errorMessage { get; set; }
        public bool IsExpiry
        {
            get;
            set;
        }
        public bool IsTaxInclusive
        {
            get;
            set;
        }
        public decimal TaxRatePercentage
        {
            get;
            set;
        }
        public int BatchID
        {
            get;
            set;
        }
        public string BatchNumber
        {
            get;
            set;
        }
        public decimal BatchQuantity
        {
            get;
            set;
        }
        public string ExpiryDate
        {
            get;
            set;
        }
        public decimal MinIndentLevel { get; set; }

        //Extra Property
        public int ItemFamilyMasterID { get; set; }
        public int ItemPackingUnitMasterID { get; set; }
        public int ItemPackingTypeMasterID { get; set; }
        public string ActionOn { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public decimal TaxAmount
        {
            get;
            set;
        }
        public decimal SaleRateExcludingtax
        {
            get;
            set;
        }
	}
}

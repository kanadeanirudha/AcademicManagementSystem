using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryPurchaseMasterAndTransactionViewModel : IInventoryPurchaseMasterAndTransactionViewModel
    {
        public InventoryPurchaseMasterAndTransactionViewModel()
        {
            InventoryPurchaseMasterAndTransactionDTO = new InventoryPurchaseMasterAndTransaction();
            InventoryPurchaseMasterAndTransactionList = new List<InventoryPurchaseMasterAndTransaction>();
        }
        public InventoryPurchaseMasterAndTransaction InventoryPurchaseMasterAndTransactionDTO { get; set; }
        public List<InventoryPurchaseMasterAndTransaction> InventoryPurchaseMasterAndTransactionList { get; set; }
        //---------------------------------------InventorySalesMaster-----------------------------
        public int ID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.ID > 0) ? InventoryPurchaseMasterAndTransactionDTO.ID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.TransactionDate = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.BillNumber : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BillNumber = value;
            }
        }
        [Display(Name = "Amount")]
        public decimal BillAmount
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.BillAmount > 0) ? InventoryPurchaseMasterAndTransactionDTO.BillAmount : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BillAmount = value;
            }
        }
        [Display(Name = "Supplier Name")]
        public string SupplierName
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.SupplierName : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.SupplierName = value;
            }
        }
        public int BalanceSheetID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.BalanceSheetID > 0) ? InventoryPurchaseMasterAndTransactionDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BalanceSheetID = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.IsActive : false;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.IsActive = value;
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
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.CreatedBy > 0) ? InventoryPurchaseMasterAndTransactionDTO.CreatedBy : new short();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.ModifiedBy > 0) ? InventoryPurchaseMasterAndTransactionDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.DeletedBy > 0) ? InventoryPurchaseMasterAndTransactionDTO.DeletedBy : new short();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.DeletedDate = value;
            }
        }
        //--------------------------------------InventorySalesTransaction------------------------------
        public int PurcahseTransactionID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.PurcahseTransactionID > 0) ? InventoryPurchaseMasterAndTransactionDTO.PurcahseTransactionID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.PurcahseTransactionID = value;
            }
        }
        public int PurchaseMasterID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.PurchaseMasterID > 0) ? InventoryPurchaseMasterAndTransactionDTO.PurchaseMasterID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.PurchaseMasterID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.ItemID > 0) ? InventoryPurchaseMasterAndTransactionDTO.ItemID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ItemID = value;
            }
        }
        [Display(Name = "Item Name")]
        public string ItemName
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ItemName = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.Quantity > 0) ? InventoryPurchaseMasterAndTransactionDTO.Quantity : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Quantity = value;
            }
        }
        [Display(Name = "Rate Per Unit")]
        public decimal Rate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.Rate > 0) ? InventoryPurchaseMasterAndTransactionDTO.Rate : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Rate = value;
            }
        }
        public int UnitID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.UnitID > 0) ? InventoryPurchaseMasterAndTransactionDTO.UnitID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.UnitID = value;
            }
        }
        
        [Display (Name = "Unit")]
        public string UnitCode
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.UnitCode = value;
            }
        }
        [AllowHtml]
        public string ParameterXml
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.ParameterXml : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ParameterXml = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.LocationID > 0) ? InventoryPurchaseMasterAndTransactionDTO.LocationID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.LocationID = value;
            }
        }
        public string Location
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.Location : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Location = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.errorMessage : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.errorMessage = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.SelectedBalanceSheet : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.SelectedBalanceSheet = value;
            }
        }


        public List<InventoryLocationMaster> LocationList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }
        [Display(Name = "Batch NO")]
        public string BatchNumber
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.BatchNumber : string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.ExpiryDate: string.Empty;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.ExpiryDate = value;
            }
        }
        public decimal TaxRate
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.TaxRate > 0) ? InventoryPurchaseMasterAndTransactionDTO.TaxRate : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.TaxRate = value;
            }
        }
        public int GenTaxGroupMasterID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.GenTaxGroupMasterID > 0) ? InventoryPurchaseMasterAndTransactionDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.GenTaxGroupMasterID = value;
            }
        }
        public decimal taxpercentage
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.taxpercentage > 0) ? InventoryPurchaseMasterAndTransactionDTO.taxpercentage : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.taxpercentage = value;
            }
        }
        [Display(Name = "Discount(%)")]
        public decimal Discount
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.Discount > 0) ? InventoryPurchaseMasterAndTransactionDTO.Discount : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Discount = value;
            }
        }
        public decimal discountpercentage
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.discountpercentage > 0) ? InventoryPurchaseMasterAndTransactionDTO.discountpercentage : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.discountpercentage = value;
            }
        }
        [Display(Name = "Tax Inclusives")]
        public bool IsRateInclusiveTax
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.IsRateInclusiveTax : false;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.IsRateInclusiveTax = value;
            }
        }
        public decimal Hamali
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.Hamali > 0) ? InventoryPurchaseMasterAndTransactionDTO.Hamali : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Hamali = value;
            }
        }
        public decimal OtherExpenses
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.OtherExpenses > 0) ? InventoryPurchaseMasterAndTransactionDTO.OtherExpenses : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.OtherExpenses = value;
            }
        }


        public decimal TotalBillAmountincludingTax
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.TotalBillAmountincludingTax > 0) ? InventoryPurchaseMasterAndTransactionDTO.TotalBillAmountincludingTax : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.TotalBillAmountincludingTax = value;
            }
        }
        public bool Isexpiry
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null) ? InventoryPurchaseMasterAndTransactionDTO.Isexpiry : false;
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.Isexpiry = value;
            }
        }
       
        public decimal RateID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.RateID > 0) ? InventoryPurchaseMasterAndTransactionDTO.RateID : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.RateID = value;
            }
        }
        public decimal RoundUpAmount
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.RoundUpAmount > 0) ? InventoryPurchaseMasterAndTransactionDTO.RoundUpAmount : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.RoundUpAmount = value;
            }
        }
        public decimal BatchQuantity
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.BatchQuantity > 0) ? InventoryPurchaseMasterAndTransactionDTO.BatchQuantity : new decimal();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BatchQuantity = value;
            }
        }
        public int BatchID
        {
            get
            {
                return (InventoryPurchaseMasterAndTransactionDTO != null && InventoryPurchaseMasterAndTransactionDTO.BatchID > 0) ? InventoryPurchaseMasterAndTransactionDTO.BatchID : new int();
            }
            set
            {
                InventoryPurchaseMasterAndTransactionDTO.BatchID = value;
            }
        }

    }
}

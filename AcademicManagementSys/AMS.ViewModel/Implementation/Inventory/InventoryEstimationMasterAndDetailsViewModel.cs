using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryEstimationMasterAndDetailsViewModel : IInventoryEstimationMasterAndDetailsViewModel
    {
        public InventoryEstimationMasterAndDetailsViewModel() 
        {
            InventoryEstimationMasterAndDetailsDTO = new InventoryEstimationMasterAndDetails();
            InventoryEstimationMasterAndDetailsList = new List<InventoryEstimationMasterAndDetails>();
            LocationList = new List<InventoryLocationMaster>();
        }
        public List<InventoryEstimationMasterAndDetails> InventoryEstimationMasterAndDetailsList { get; set; }
        public InventoryEstimationMasterAndDetails InventoryEstimationMasterAndDetailsDTO { get; set; }
        public List<InventoryLocationMaster> LocationList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }
        //--------------------------------Properties of EstimationMaster Table-----------------------------------
      public int ID
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.ID > 0) ? InventoryEstimationMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.ID = value;
            }
        }
      public string TransactionDate
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.TransactionDate : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.TransactionDate = value;
          }
      }
      [Display(Name = "Customer Name")]
      [Required(ErrorMessage = "Customer name should not be blank")]
      public string CustomerName
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.CustomerName : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.CustomerName = value;
          }
      }
      [Display(Name = "Customer Address ")]
      [Required(ErrorMessage = "Customer address should not be blank")]
      public string CustomerAddress
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.CustomerAddress : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.CustomerAddress = value;
          }
      }
      [Display(Name="Contact No.")]
      [Required(ErrorMessage = "Customer contact number should not be blank")]
      public string CustomerMobileNumber
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.CustomerMobileNumber : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.CustomerMobileNumber = value;
          }
      }
      [Display(Name = "Estimation Amount")]
      public decimal EstimationAmount
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.EstimationAmount > 0) ? InventoryEstimationMasterAndDetailsDTO.EstimationAmount : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.EstimationAmount = value;
          }
      }
      public bool EstimationStatus
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.EstimationStatus : false;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.EstimationStatus = value;
          }
      }
      public Int16 BalanceSheetID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.BalanceSheetID > 0) ? InventoryEstimationMasterAndDetailsDTO.BalanceSheetID : new Int16();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.BalanceSheetID = value;
          }
      }
      public bool IsPendingForBill
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.IsPendingForBill : false;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.IsPendingForBill = value;
          }
      }
      public string BillNumber
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.BillNumber : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.BillNumber = value;
          }
      }
      public  bool IsActive
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.IsActive = value;
            }
        }
      public  bool IsDeleted
        {
            get;
            set;
        }
      public  int CreatedBy
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.CreatedBy > 0) ? InventoryEstimationMasterAndDetailsDTO.CreatedBy : new short();
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.CreatedBy = value;
            }
        }
      public  DateTime CreatedDate
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.CreatedDate = value;
            }
        }
      public  int? ModifiedBy
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.ModifiedBy > 0) ? InventoryEstimationMasterAndDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
      public  DateTime? ModifiedDate
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.ModifiedDate = value;
            }
        }
      public  int? DeletedBy
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.DeletedBy > 0) ? InventoryEstimationMasterAndDetailsDTO.DeletedBy : new short();
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.DeletedBy = value;
            }
        }
      public  DateTime? DeletedDate
        {
            get
            {
                return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryEstimationMasterAndDetailsDTO.DeletedDate = value;
            }
        }
       //----------------------------Properties of EstimationDetails Table-----------------------------------
      public int EstimationDetailID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.EstimationDetailID > 0) ? InventoryEstimationMasterAndDetailsDTO.EstimationDetailID : new int();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.EstimationDetailID = value;
          }
      }
      public int ItemID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.ItemID > 0) ? InventoryEstimationMasterAndDetailsDTO.ItemID : new int();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.ItemID = value;
          }
      }
      public string ItemName
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.ItemName : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.ItemName = value;
          }
      }
      public decimal Quantity
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.Quantity > 0) ? InventoryEstimationMasterAndDetailsDTO.Quantity : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.Quantity = value;
          }
      }
      public decimal Rate
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.Rate > 0) ? InventoryEstimationMasterAndDetailsDTO.Rate : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.Rate = value;
          }
      }
          [Required]
        [Display(Name="Location :")]
      public int LocationID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.LocationID > 0) ? InventoryEstimationMasterAndDetailsDTO.LocationID : new int();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.LocationID = value;
          }
      }

      public string errorMessage
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.errorMessage : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.errorMessage = value;
          }
      }
      public string SelectedBalanceSheet
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.SelectedBalanceSheet : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.SelectedBalanceSheet = value;
          }
      }
      public string XMLstring
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.XMLstring : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.XMLstring = value;
          }
      }
      public string EstimateLocationWiseXMLstring
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.EstimateLocationWiseXMLstring : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.EstimateLocationWiseXMLstring = value;
          }
      }
      public decimal AvailableStock
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.AvailableStock > 0) ? InventoryEstimationMasterAndDetailsDTO.AvailableStock : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.AvailableStock = value;
          }
      }
      public int UnitID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.UnitID > 0) ? InventoryEstimationMasterAndDetailsDTO.UnitID : new int();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.UnitID = value;
          }
      }
      public string UnitCode
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null) ? InventoryEstimationMasterAndDetailsDTO.UnitCode : string.Empty;
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.UnitCode = value;
          }
      }
      public decimal Total
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.Total > 0) ? InventoryEstimationMasterAndDetailsDTO.Total : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.Total = value;
          }
      }
      [Display(Name = "Tax(%)")]
      public decimal TotalTaxAmount
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.TotalTaxAmount > 0) ? InventoryEstimationMasterAndDetailsDTO.TotalTaxAmount : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.TotalTaxAmount = value;
          }
      }
      [Display(Name = "Discount(%)")]
      public decimal TotalDiscountAmount
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.TotalDiscountAmount > 0) ? InventoryEstimationMasterAndDetailsDTO.TotalDiscountAmount : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.TotalDiscountAmount = value;
          }
      }
      public int GenTaxGroupMasterID { get; set; }
      public decimal taxpercentage { get; set; }
      public decimal RateDecreaseByPercentage { get; set; }
      public decimal TotalTaxAmountt { get; set; }
      public decimal totalTaxString
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.totalTaxString > 0) ? InventoryEstimationMasterAndDetailsDTO.totalTaxString : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.totalTaxString = value;
          }
      }
      public decimal totalDiscountString
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.totalDiscountString > 0) ? InventoryEstimationMasterAndDetailsDTO.totalDiscountString : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.totalDiscountString = value;
          }
      }
      public int CustomerID
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.CustomerID > 0) ? InventoryEstimationMasterAndDetailsDTO.CustomerID : new int();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.CustomerID = value;
          }
      }

      public decimal DiscountAmountForItem
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.DiscountAmountForItem > 0) ? InventoryEstimationMasterAndDetailsDTO.DiscountAmountForItem : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.DiscountAmountForItem = value;
          }
      }
      public decimal TotalTaxForItem
      {
          get
          {
              return (InventoryEstimationMasterAndDetailsDTO != null && InventoryEstimationMasterAndDetailsDTO.TotalTaxForItem > 0) ? InventoryEstimationMasterAndDetailsDTO.TotalTaxForItem : new decimal();
          }
          set
          {
              InventoryEstimationMasterAndDetailsDTO.TotalTaxForItem = value;
          }
      }
    }
}

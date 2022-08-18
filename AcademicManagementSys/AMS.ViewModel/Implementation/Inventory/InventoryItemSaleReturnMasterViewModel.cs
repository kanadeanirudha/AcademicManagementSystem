using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryItemSaleReturnMasterViewModel : IInventoryItemSaleReturnMasterViewModel
    {
        public InventoryItemSaleReturnMasterViewModel()
        {
            InventoryItemSaleReturnMasterDTO = new InventoryItemSaleReturnMaster();
            LocationList = new List<InventoryLocationMaster>();
            InventoryCounterMasterList = new List<InventoryCounterMaster>();
            InventoryReturnItemDetailList = new List<InventoryItemSaleReturnMaster>();
            InventoryOperatorSaleReportList = new List<InventoryItemSaleReturnMaster>();
        }

        public IEnumerable<SelectListItem> InventoryReturnItemDetailListItems
        {
            get
            {
                return new SelectList(InventoryReturnItemDetailList, "ItemID", "ItemName");
            }
        }

        public List<InventoryItemSaleReturnMaster> InventoryReturnItemDetailList
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> InventoryOperatorSaleReportListItems
        {
            get
            {
                return new SelectList(InventoryOperatorSaleReportList, "ItemID", "ItemName");
            }
        }

        public List<InventoryItemSaleReturnMaster> InventoryOperatorSaleReportList
        {
            get;
            set;
        }



        public List<InventoryLocationMaster> LocationList { get; set; }
        public List<InventoryCounterMaster> InventoryCounterMasterList { get; set; }
        public IEnumerable<SelectListItem> LocationListItems
        {
            get
            {
                return new SelectList(LocationList, "ID", "LocationName");
            }
        }
        public IEnumerable<SelectListItem> InventoryCounterMasterListItems
        {
            get
            {
                return new SelectList(InventoryCounterMasterList, "CounterIDAndCounterApplicableID", "CounterName");
            }
        }
        public InventoryItemSaleReturnMaster InventoryItemSaleReturnMasterDTO { get; set; }
        //---------------------------------------InventorySalesReturnMaster-----------------------------
        public int InvSalesReturnMasterID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.InvSalesReturnMasterID > 0) ? InventoryItemSaleReturnMasterDTO.InvSalesReturnMasterID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.InvSalesReturnMasterID = value;
            }
        }
        public string TransactionDate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TransactionDate = value;
            }
        }
        public string BillNumber
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.BillNumber : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.BillNumber = value;
            }
        }
        [Display(Name = "Return Amount")]
        public decimal SalesReturnAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.SalesReturnAmount > 0) ? InventoryItemSaleReturnMasterDTO.SalesReturnAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.SalesReturnAmount = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CustomerName : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CustomerName = value;
            }
        }

        public int BalanceSheetID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.BalanceSheetID > 0) ? InventoryItemSaleReturnMasterDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.BalanceSheetID = value;
            }
        }
        public int CounterLogID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.CounterLogID > 0) ? InventoryItemSaleReturnMasterDTO.CounterLogID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CounterLogID = value;
            }
        }

        public int LocationID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.LocationID > 0) ? InventoryItemSaleReturnMasterDTO.LocationID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.LocationID = value;
            }
        }

        public decimal PaymentByCustomer
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.PaymentByCustomer > 0) ? InventoryItemSaleReturnMasterDTO.PaymentByCustomer : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.PaymentByCustomer = value;
            }
        }


        public decimal ReturnChange
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.ReturnChange > 0) ? InventoryItemSaleReturnMasterDTO.ReturnChange : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ReturnChange = value;
            }
        }

        public decimal TotalTaxAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TotalTaxAmount > 0) ? InventoryItemSaleReturnMasterDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TotalTaxAmount = value;
            }
        }

        public decimal TotalDiscountAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TotalDiscountAmount > 0) ? InventoryItemSaleReturnMasterDTO.TotalDiscountAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TotalDiscountAmount = value;
            }
        }


        //--------------------------------------InventorySalesRetrunTransaction------------------------------

        public int InvSalesRetrunTransactionID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.InvSalesRetrunTransactionID > 0) ? InventoryItemSaleReturnMasterDTO.InvSalesRetrunTransactionID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.InvSalesRetrunTransactionID = value;
            }
        }

        public int ItemID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.ItemID > 0) ? InventoryItemSaleReturnMasterDTO.ItemID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ItemID = value;
            }
        }
        [Display(Name = "DisplayName_ItemName", ResourceType = typeof(Resources))]
        public string ItemName
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ItemName = value;
            }
        }

        [Display(Name = "DisplayName_Quantity", ResourceType = typeof(Resources))]
        public decimal Quantity
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.Quantity > 0) ? InventoryItemSaleReturnMasterDTO.Quantity : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.Quantity = value;
            }
        }
        [Display(Name = "DisplayName_Rate", ResourceType = typeof(Resources))]
        public decimal Rate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.Rate > 0) ? InventoryItemSaleReturnMasterDTO.Rate : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.Rate = value;
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TaxAmount > 0) ? InventoryItemSaleReturnMasterDTO.TaxAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TaxAmount = value;
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.DiscountAmount > 0) ? InventoryItemSaleReturnMasterDTO.DiscountAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.DiscountAmount = value;
            }
        }

        public int GenTaxGroupMasterID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.GenTaxGroupMasterID > 0) ? InventoryItemSaleReturnMasterDTO.GenTaxGroupMasterID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.GenTaxGroupMasterID = value;
            }
        }


        //-----------------------------------------Comman Property--------------------------------------------------        
        public bool IsActive
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.IsActive : false;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.CreatedBy > 0) ? InventoryItemSaleReturnMasterDTO.CreatedBy : new short();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.ModifiedBy > 0) ? InventoryItemSaleReturnMasterDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.DeletedBy > 0) ? InventoryItemSaleReturnMasterDTO.DeletedBy : new short();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.DeletedDate = value;
            }
        }
        
        
        //-------------------------------------Extra Property------------------------------------------------
        public string LocationName
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.LocationName : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.LocationName = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.ErrorMessage : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ErrorMessage = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.CustomerID > 0) ? InventoryItemSaleReturnMasterDTO.CustomerID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CustomerID = value;
            }
        }

        public string CustomerType
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CustomerType : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CustomerType = value;
            }
        }

        public int InvBufferSalesMasterID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.InvBufferSalesMasterID > 0) ? InventoryItemSaleReturnMasterDTO.InvBufferSalesMasterID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.InvBufferSalesMasterID = value;
            }
        }

        public string CustomerContactNo
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CustomerContactNo : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CustomerContactNo = value;
            }
        }

        public decimal ItemAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.ItemAmount > 0) ? InventoryItemSaleReturnMasterDTO.ItemAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ItemAmount = value;
            }
        }

        public int InvSalesDetailsID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.InvSalesDetailsID > 0) ? InventoryItemSaleReturnMasterDTO.InvSalesDetailsID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.InvSalesDetailsID = value;
            }
        }

        public string UnitCode
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.UnitCode : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.UnitCode = value;
            }
        }

        public string CustomerAddress
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CustomerAddress : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CustomerAddress = value;
            }
        }

        public string CounterName
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.CounterName : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.CounterName = value;
            }
        }

        public string BatchNumber
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.BatchNumber : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.BatchNumber = value;
            }
        }
        public decimal DiscountInPercentage 
        { 
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.DiscountInPercentage > 0) ? InventoryItemSaleReturnMasterDTO.DiscountInPercentage : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.DiscountInPercentage = value;
            }
        }

        public int TotalItem 
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TotalItem > 0) ? InventoryItemSaleReturnMasterDTO.TotalItem : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TotalItem = value;
            }
        }

        [Display(Name="Total Retuen Amount")]
        public decimal TotalReturnAmount 
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TotalReturnAmount > 0) ? InventoryItemSaleReturnMasterDTO.TotalReturnAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TotalReturnAmount = value;
            }
        }

        public string BillDate
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.BillDate : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.BillDate = value;
            }
        }


        public string Customer
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.Customer : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.Customer = value;
            }
        }

        public decimal TaxInPercentage
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.TaxInPercentage > 0) ? InventoryItemSaleReturnMasterDTO.TaxInPercentage : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.TaxInPercentage = value;
            }
        }

        public int AccountSessionID
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.AccountSessionID > 0) ? InventoryItemSaleReturnMasterDTO.AccountSessionID : new int();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.AccountSessionID = value;
            }
        }

        public decimal RoundUpAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.RoundUpAmount > 0) ? InventoryItemSaleReturnMasterDTO.RoundUpAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.RoundUpAmount = value;
            }
        }

        public decimal NetAmount
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.NetAmount > 0) ? InventoryItemSaleReturnMasterDTO.NetAmount : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.NetAmount = value;
            }
        }

        public decimal DeliveryCharge
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null && InventoryItemSaleReturnMasterDTO.DeliveryCharge > 0) ? InventoryItemSaleReturnMasterDTO.DeliveryCharge : new decimal();
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.DeliveryCharge = value;
            }
        }


        // For Xml
        public string ReturnItemDetailxml
        {
            get
            {
                return (InventoryItemSaleReturnMasterDTO != null) ? InventoryItemSaleReturnMasterDTO.ReturnItemDetailxml : string.Empty;
            }
            set
            {
                InventoryItemSaleReturnMasterDTO.ReturnItemDetailxml = value;
            }
        }
    }
}
